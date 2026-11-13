using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft.AppCode.Service
{
    public class AttendanceCalculationResult
    {
        public int TotalProcessedRecords { get; set; }
        public int PresentCount { get; set; }
        public int LateCount { get; set; }
        public int EarlyExitCount { get; set; }
        public int ExcusedAbsenceCount { get; set; }
        public int UnexcusedAbsenceCount { get; set; }
        public int RestDayCount { get; set; }
        public int TotalLateMinutes { get; set; }
        public int TotalOvertimeMinutes { get; set; }
        public List<TrAttendance> ProcessedAttendances { get; set; } = new();
    }

    public class AttendanceCalculationService
    {
        /// <summary>
        /// Anti-Double Punch (Debounce): Eyni cihazda X dəqiqə ərzində təkrar vurulan logları filtr edir.
        /// </summary>
        public void ApplyDebounceFilter(subContext db, int debounceMinutes)
        {
            if (debounceMinutes <= 0) return;

            var unignoredLogs = db.TrAttendanceLogs
                .Where(x => !x.IsIgnored)
                .OrderBy(x => x.CurrAccCode)
                .ThenBy(x => x.DeviceCode)
                .ThenBy(x => x.LogDateTime)
                .ToList();

            string? lastCurrAcc = null;
            string? lastDevice = null;
            DateTime? lastTime = null;

            foreach (var log in unignoredLogs)
            {
                if (lastCurrAcc == log.CurrAccCode &&
                    string.Equals(lastDevice, log.DeviceCode, StringComparison.OrdinalIgnoreCase) &&
                    lastTime.HasValue &&
                    (log.LogDateTime - lastTime.Value).TotalMinutes < debounceMinutes)
                {
                    log.IsIgnored = true;
                    log.IgnoreReason = $"Anti-Double Punch ({debounceMinutes} dəqiqə daxilində təkrar oxuma)";
                }
                else
                {
                    lastCurrAcc = log.CurrAccCode;
                    lastDevice = log.DeviceCode;
                    lastTime = log.LogDateTime;
                }
            }

            db.SaveChanges();
        }

        /// <summary>
        /// Seçilmiş tarix intervalı və filtrlər üzrə davamiyyəti tam hesablayır.
        /// </summary>
        public AttendanceCalculationResult CalculateAttendance(
            DateTime fromDate,
            DateTime toDate,
            string? storeCode = null,
            Guid? departmentId = null,
            string? currAccCode = null,
            DcAttendanceSetting? customSettings = null,
            bool saveToDb = true)
        {
            using var db = new subContext();

            var settings = customSettings ?? db.DcAttendanceSettings
                .Include(x => x.DefaultWorkSchedule)
                    .ThenInclude(s => s!.Days)
                .FirstOrDefault() ?? new DcAttendanceSetting();

            // Təkrar vuruşları süz
            if (settings.DebounceMinutes > 0 && saveToDb)
            {
                ApplyDebounceFilter(db, settings.DebounceMinutes);
            }

            // İşçiləri yüklə
            var employeeQuery = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel);

            if (!string.IsNullOrWhiteSpace(storeCode))
                employeeQuery = employeeQuery.Where(x => x.StoreCode == storeCode);

            if (!string.IsNullOrWhiteSpace(currAccCode))
                employeeQuery = employeeQuery.Where(x => x.CurrAccCode == currAccCode);

            var employees = employeeQuery.ToList();

            if (departmentId.HasValue)
            {
                var empCodesInDept = db.TrEmployeePositions.AsNoTracking()
                    .Include(p => p.Position)
                    .Where(p => p.Position.DepartmentId == departmentId.Value &&
                                (p.EndDate == null || p.EndDate >= fromDate))
                    .Select(p => p.CurrAccCode)
                    .Distinct()
                    .ToHashSet();

                employees = employees.Where(e => empCodesInDept.Contains(e.CurrAccCode)).ToList();
            }

            // Bütün aktiv qrafikləri və günlərini yüklə
            var allSchedules = db.DcWorkSchedules.AsNoTracking()
                .Include(x => x.Days)
                .ToDictionary(x => x.Id);

            DcWorkSchedule? defaultSchedule = null;
            if (settings.DefaultWorkScheduleId.HasValue && allSchedules.ContainsKey(settings.DefaultWorkScheduleId.Value))
            {
                defaultSchedule = allSchedules[settings.DefaultWorkScheduleId.Value];
            }
            else
            {
                defaultSchedule = allSchedules.Values.FirstOrDefault();
            }

            // İşçilərin fərdi qrafik təyinatları
            var empSchedules = db.TrEmployeeWorkSchedules.AsNoTracking()
                .Where(x => x.StartDate <= toDate && (x.EndDate == null || x.EndDate >= fromDate))
                .ToList();

            // Tarix aralığındakı xam loglar
            var dateStart = fromDate.Date;
            var dateEnd = toDate.Date.AddDays(1).AddTicks(-1);

            var rawLogs = db.TrAttendanceLogs.AsNoTracking()
                .Where(x => !x.IsIgnored && x.LogDateTime >= dateStart && x.LogDateTime <= dateEnd)
                .ToList();

            // Təsdiqlənmiş məzuniyyət və icazə müraciətləri
            var approvedLeaves = db.HrLeaveRequests.AsNoTracking()
                .Include(x => x.LeaveType)
                .Include(x => x.RequestDays)
                .Where(x => x.Status == LeaveStatus.Approved &&
                            x.StartDate <= dateEnd && x.EndDate >= dateStart)
                .ToList();

            // Təsdiqlənmiş artıq iş müraciətləri
            var approvedOvertimes = db.TrOvertimeRequests.AsNoTracking()
                .Where(x => x.IsApproved && x.WorkDate >= dateStart && x.WorkDate <= dateEnd)
                .ToList();

            // Mövcud gündəlik davamiyyət qeydləri
            var existingAttendances = db.TrAttendances
                .Where(x => x.WorkDate >= dateStart && x.WorkDate <= dateEnd)
                .ToList();

            var result = new AttendanceCalculationResult();

            for (var currentDate = fromDate.Date; currentDate <= toDate.Date; currentDate = currentDate.AddDays(1))
            {
                var dayOfWeek = currentDate.DayOfWeek;

                foreach (var emp in employees)
                {
                    // İşçinin həmin tarixə uyğun iş qrafikini tap
                    var empScheduleAssignment = empSchedules
                        .Where(s => s.CurrAccCode == emp.CurrAccCode &&
                                    s.StartDate <= currentDate &&
                                    (s.EndDate == null || s.EndDate >= currentDate))
                        .OrderByDescending(s => s.StartDate)
                        .FirstOrDefault();

                    DcWorkSchedule? schedule = null;
                    if (empScheduleAssignment != null && allSchedules.ContainsKey(empScheduleAssignment.WorkScheduleId))
                        schedule = allSchedules[empScheduleAssignment.WorkScheduleId];
                    else
                        schedule = defaultSchedule;

                    DcWorkScheduleDay? daySchedule = schedule?.Days.FirstOrDefault(d => d.DayOfWeek == dayOfWeek);
                    bool isPlannedWorkDay = daySchedule?.IsWorkDay ?? false;

                    // Həmin günə aid təsdiqlənmiş icazə varmı?
                    var empLeave = approvedLeaves
                        .FirstOrDefault(l => l.CurrAccCode == emp.CurrAccCode &&
                                             l.StartDate.Date <= currentDate &&
                                             l.EndDate.Date >= currentDate);

                    HrLeaveRequestDay? leaveDayDetail = empLeave?.RequestDays.FirstOrDefault(d => d.Date.Date == currentDate);

                    // Həmin günə aid xam giriş-çıxış vuruşları
                    var dayLogs = rawLogs
                        .Where(l => l.CurrAccCode == emp.CurrAccCode && l.LogDateTime.Date == currentDate)
                        .OrderBy(l => l.LogDateTime)
                        .ToList();

                    // Mövcud qeyd
                    var attendance = existingAttendances
                        .FirstOrDefault(a => a.CurrAccCode == emp.CurrAccCode && a.WorkDate.Date == currentDate);

                    if (attendance == null)
                    {
                        attendance = new TrAttendance
                        {
                            Id = Guid.NewGuid(),
                            CurrAccCode = emp.CurrAccCode,
                            WorkDate = currentDate
                        };
                        if (saveToDb) db.TrAttendances.Add(attendance);
                    }
                    else if (attendance.IsManualOverride)
                    {
                        // Əgər istifadəçi əl ilə redaktə edib qoruyubsa, toxunmuruq
                        result.ProcessedAttendances.Add(attendance);
                        continue;
                    }

                    attendance.WorkScheduleId = schedule?.Id;

                    if (daySchedule != null && isPlannedWorkDay)
                    {
                        attendance.PlannedCheckInTime = currentDate.Add(daySchedule.StartTime);
                        attendance.PlannedCheckOutTime = currentDate.Add(daySchedule.EndTime);
                        attendance.PlannedWorkMinutes = daySchedule.PlannedWorkMinutes;
                        attendance.BreakMinutes = daySchedule.BreakDurationMinutes;
                    }
                    else
                    {
                        attendance.PlannedCheckInTime = null;
                        attendance.PlannedCheckOutTime = null;
                        attendance.PlannedWorkMinutes = 0;
                        attendance.BreakMinutes = 0;
                    }

                    if (dayLogs.Any())
                    {
                        var firstPunch = dayLogs.First().LogDateTime;
                        var lastPunch = dayLogs.Last().LogDateTime;

                        attendance.CheckInTime = firstPunch;
                        attendance.CheckOutTime = dayLogs.Count > 1 ? lastPunch : (DateTime?)null;

                        // 1. İşə Başlama və Gecikmə Hesablanması
                        int lateMinutes = 0;
                        DateTime effectiveStart = firstPunch;

                        if (attendance.PlannedCheckInTime.HasValue)
                        {
                            var plannedStart = attendance.PlannedCheckInTime.Value;

                            if (firstPunch <= plannedStart)
                            {
                                // Qrafikdən tez gəlibsə, faktiki işə başlama qrafik vaxtı qəbul edilir
                                effectiveStart = plannedStart;
                                lateMinutes = 0;
                            }
                            else
                            {
                                var diffMinutes = (int)(firstPunch - plannedStart).TotalMinutes;

                                // Saatlıq icazə yoxlanışı (məsələn səhər saatlarında icazə alıbsa)
                                if (leaveDayDetail != null && leaveDayDetail.StartTime.HasValue && leaveDayDetail.EndTime.HasValue)
                                {
                                    var leaveStart = currentDate.Add(leaveDayDetail.StartTime.Value);
                                    var leaveEnd = currentDate.Add(leaveDayDetail.EndTime.Value);
                                    if (firstPunch <= leaveEnd && plannedStart >= leaveStart)
                                    {
                                        diffMinutes = 0; // İcazə çərçivəsindədir, gecikmə yoxdur
                                    }
                                }

                                if (diffMinutes <= settings.GracePeriodMinutes)
                                {
                                    // Güzəşt müddəti daxilindədir
                                    lateMinutes = 0;
                                    effectiveStart = plannedStart;
                                }
                                else
                                {
                                    if (settings.LateCalculationMethod == LateCalculationMethod.Actual)
                                        lateMinutes = diffMinutes;
                                    else // AfterGrace
                                        lateMinutes = Math.Max(0, diffMinutes - settings.GracePeriodMinutes);

                                    // Yuvarlaqlaşdırma
                                    if ((int)settings.LateRoundingMethod > 0)
                                    {
                                        int round = (int)settings.LateRoundingMethod;
                                        lateMinutes = ((lateMinutes + round - 1) / round) * round;
                                    }

                                    effectiveStart = firstPunch;
                                }
                            }
                        }

                        attendance.EffectiveStartTime = effectiveStart;
                        attendance.LateMinutes = lateMinutes;

                        // 2. Erkən Çıxış Hesablanması
                        int earlyExitMinutes = 0;
                        if (attendance.CheckOutTime.HasValue && attendance.PlannedCheckOutTime.HasValue)
                        {
                            var plannedEnd = attendance.PlannedCheckOutTime.Value;
                            var actualEnd = attendance.CheckOutTime.Value;

                            if (actualEnd < plannedEnd)
                            {
                                var diffMinutes = (int)(plannedEnd - actualEnd).TotalMinutes;

                                // Saatlıq icazə yoxlanışı (məsələn 14:00 - 16:00 icazə istəyib)
                                if (leaveDayDetail != null && leaveDayDetail.StartTime.HasValue && leaveDayDetail.EndTime.HasValue)
                                {
                                    var leaveStart = currentDate.Add(leaveDayDetail.StartTime.Value);
                                    var leaveEnd = currentDate.Add(leaveDayDetail.EndTime.Value);
                                    if (actualEnd >= leaveStart && plannedEnd <= leaveEnd)
                                    {
                                        diffMinutes = 0; // İcazəli vaxtdır
                                    }
                                }

                                if (diffMinutes > settings.EarlyExitGracePeriodMinutes)
                                {
                                    earlyExitMinutes = diffMinutes;
                                }
                            }
                        }
                        attendance.EarlyExitMinutes = earlyExitMinutes;

                        // 3. Əlavə İş (Overtime) Hesablanması
                        int overtimeMinutes = 0;
                        int approvedOtMinutes = 0;

                        if (attendance.CheckOutTime.HasValue && attendance.PlannedCheckOutTime.HasValue)
                        {
                            var plannedEnd = attendance.PlannedCheckOutTime.Value;
                            var actualEnd = attendance.CheckOutTime.Value;

                            if (actualEnd > plannedEnd)
                            {
                                var diffMinutes = (int)(actualEnd - plannedEnd).TotalMinutes;
                                if (diffMinutes >= settings.MinOvertimeMinutes)
                                {
                                    overtimeMinutes = diffMinutes;

                                    if (settings.OvertimePolicy == OvertimePolicy.Auto)
                                    {
                                        approvedOtMinutes = overtimeMinutes;
                                    }
                                    else // PreApproved
                                    {
                                        var preApproved = approvedOvertimes
                                            .FirstOrDefault(o => o.CurrAccCode == emp.CurrAccCode && o.WorkDate.Date == currentDate);
                                        if (preApproved != null)
                                            approvedOtMinutes = Math.Min(overtimeMinutes, preApproved.OvertimeMinutes);
                                    }
                                }
                            }
                        }

                        attendance.OvertimeMinutes = overtimeMinutes;
                        attendance.ApprovedOvertimeMinutes = approvedOtMinutes;

                        // 4. İşlənmiş Dəqiqələr
                        if (attendance.CheckOutTime.HasValue)
                        {
                            var grossMinutes = (int)(attendance.CheckOutTime.Value - effectiveStart).TotalMinutes;
                            int netMinutes = Math.Max(0, grossMinutes - attendance.BreakMinutes);
                            attendance.WorkedMinutes = netMinutes;
                        }
                        else
                        {
                            // Çıxış qeydə alınmayıb (tək vuruş)
                            attendance.WorkedMinutes = 0;
                        }

                        // 5. Status
                        if (attendance.LateMinutes > 0 && attendance.EarlyExitMinutes > 0)
                            attendance.AttendanceStatus = AttendanceStatus.Late;
                        else if (attendance.LateMinutes > 0)
                            attendance.AttendanceStatus = AttendanceStatus.Late;
                        else if (attendance.EarlyExitMinutes > 0)
                            attendance.AttendanceStatus = AttendanceStatus.EarlyExit;
                        else
                            attendance.AttendanceStatus = AttendanceStatus.Present;

                        attendance.LeaveRequestId = empLeave?.Id;
                    }
                    else
                    {
                        // Qapı / log vuruşu yoxdur
                        attendance.CheckInTime = null;
                        attendance.CheckOutTime = null;
                        attendance.EffectiveStartTime = null;
                        attendance.WorkedMinutes = 0;
                        attendance.LateMinutes = 0;
                        attendance.EarlyExitMinutes = 0;
                        attendance.OvertimeMinutes = 0;
                        attendance.ApprovedOvertimeMinutes = 0;

                        if (!isPlannedWorkDay)
                        {
                            attendance.AttendanceStatus = AttendanceStatus.RestDay;
                            attendance.LeaveRequestId = null;
                        }
                        else if (empLeave != null)
                        {
                            attendance.LeaveRequestId = empLeave.Id;
                            if (empLeave.LeaveType?.TypeCode == "SickLeave")
                                attendance.AttendanceStatus = AttendanceStatus.SickLeave;
                            else if (empLeave.LeaveType?.TypeCode == "BusinessTrip")
                                attendance.AttendanceStatus = AttendanceStatus.BusinessTrip;
                            else
                                attendance.AttendanceStatus = AttendanceStatus.AbsentExcused;
                        }
                        else
                        {
                            attendance.AttendanceStatus = AttendanceStatus.AbsentUnexcused;
                            attendance.LeaveRequestId = null;
                        }
                    }

                    attendance.CalculatedAt = DateTime.Now;
                    result.ProcessedAttendances.Add(attendance);

                    // Statistikalar
                    result.TotalProcessedRecords++;
                    switch (attendance.AttendanceStatus)
                    {
                        case AttendanceStatus.Present: result.PresentCount++; break;
                        case AttendanceStatus.Late: result.LateCount++; break;
                        case AttendanceStatus.EarlyExit: result.EarlyExitCount++; break;
                        case AttendanceStatus.AbsentExcused:
                        case AttendanceStatus.SickLeave:
                        case AttendanceStatus.BusinessTrip: result.ExcusedAbsenceCount++; break;
                        case AttendanceStatus.AbsentUnexcused: result.UnexcusedAbsenceCount++; break;
                        case AttendanceStatus.RestDay: result.RestDayCount++; break;
                    }
                    result.TotalLateMinutes += attendance.LateMinutes;
                    result.TotalOvertimeMinutes += attendance.ApprovedOvertimeMinutes;
                }
            }

            if (saveToDb)
            {
                db.SaveChanges();
            }

            return result;
        }

        /// <summary>
        /// Aylıq Tabel (Timesheet Summary) yaradır və ya yeniləyir.
        /// Bu göstəricilər birbaşa əməkhaqqı (Payroll) moduluna ötürülür.
        /// </summary>
        public List<TrMonthlyTimesheet> GenerateMonthlyTimesheet(int year, int month, string? storeCode = null, bool saveToDb = true)
        {
            using var db = new subContext();

            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Əlaqədar PayrollPeriod tap (əgər varsa)
            var payrollPeriod = db.DcPayrollPeriods.AsNoTracking()
                .FirstOrDefault(p => p.PeriodYear == year && p.PeriodMonth == month);

            var query = db.TrAttendances.AsNoTracking()
                .Include(a => a.DcCurrAcc)
                .Where(a => a.WorkDate >= startDate && a.WorkDate <= endDate);

            if (!string.IsNullOrWhiteSpace(storeCode))
                query = query.Where(a => a.DcCurrAcc.StoreCode == storeCode);

            var attendances = query.ToList();

            var existingSheets = db.TrMonthlyTimesheets
                .Where(t => t.Year == year && t.Month == month)
                .ToList();

            var grouped = attendances.GroupBy(a => a.CurrAccCode);
            var resultList = new List<TrMonthlyTimesheet>();

            foreach (var grp in grouped)
            {
                var empCode = grp.Key;
                var sheet = existingSheets.FirstOrDefault(t => t.CurrAccCode == empCode);

                if (sheet == null)
                {
                    sheet = new TrMonthlyTimesheet
                    {
                        Id = Guid.NewGuid(),
                        CurrAccCode = empCode,
                        Year = year,
                        Month = month
                    };
                    if (saveToDb) db.TrMonthlyTimesheets.Add(sheet);
                }
                else if (sheet.IsLocked)
                {
                    // Bağlanmış / təsdiqlənmiş tabel dəyişdirilmir
                    resultList.Add(sheet);
                    continue;
                }

                sheet.PayrollPeriodId = payrollPeriod?.Id;
                sheet.ScheduledDays = grp.Count(a => a.PlannedWorkMinutes > 0);
                sheet.WorkedDays = grp.Count(a => a.WorkedMinutes > 0 ||
                                                  a.AttendanceStatus == AttendanceStatus.Present ||
                                                  a.AttendanceStatus == AttendanceStatus.Late ||
                                                  a.AttendanceStatus == AttendanceStatus.EarlyExit);

                sheet.WorkedHours = Math.Round((decimal)grp.Sum(a => a.WorkedMinutes) / 60.0m, 2);
                sheet.UnexcusedAbsenceDays = grp.Count(a => a.AttendanceStatus == AttendanceStatus.AbsentUnexcused);
                sheet.ExcusedAbsenceDays = grp.Count(a => a.AttendanceStatus == AttendanceStatus.AbsentExcused);
                sheet.LateMinutes = grp.Sum(a => a.LateMinutes);
                sheet.EarlyExitMinutes = grp.Sum(a => a.EarlyExitMinutes);

                sheet.TotalOvertimeHours = Math.Round((decimal)grp.Sum(a => a.OvertimeMinutes) / 60.0m, 2);
                sheet.ApprovedOvertimeHours = Math.Round((decimal)grp.Sum(a => a.ApprovedOvertimeMinutes) / 60.0m, 2);

                sheet.PaidLeaveDays = grp.Count(a => a.AttendanceStatus == AttendanceStatus.AbsentExcused && a.LeaveRequest?.LeaveType?.IsPaid == true);
                sheet.UnpaidLeaveDays = grp.Count(a => a.AttendanceStatus == AttendanceStatus.AbsentExcused && a.LeaveRequest?.LeaveType?.IsPaid == false);
                sheet.SickLeaveDays = grp.Count(a => a.AttendanceStatus == AttendanceStatus.SickLeave);

                sheet.CalculatedDate = DateTime.Now;
                resultList.Add(sheet);
            }

            if (saveToDb)
            {
                db.SaveChanges();
            }

            return resultList;
        }
    }
}
