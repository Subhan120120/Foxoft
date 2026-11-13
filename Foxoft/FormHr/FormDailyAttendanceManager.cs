using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Views;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormDailyAttendanceManager : RibbonForm
    {
        private readonly subContext db = new();
        private readonly AttendanceCalculationService calcService = new();
        private BindingList<DailyAttendanceVM> attendanceList = new();
        private BindingList<AttendanceResourceVM> resourceList = new();
        private bool _isSyncingDate;

        public FormDailyAttendanceManager()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            barEditDate.EditValue = DateTime.Today;
            InitFilters();

            Load += (_, __) => LoadData();
            btnRefresh.ItemClick += (_, __) => LoadData();
            barEditDate.EditValueChanged += BarEditDate_EditValueChanged;
            barEditStore.EditValueChanged += (_, __) => LoadData();
            barEditStatus.EditValueChanged += (_, __) => LoadData();

            btnToday.ItemClick += (_, __) => GoToToday();
            btnPrev.ItemClick += (_, __) => GoToPrevious();
            btnNext.ItemClick += (_, __) => GoToNext();

            btnViewTimeline.ItemClick += (_, __) => SetView(SchedulerViewType.Timeline);
            btnViewDay.ItemClick += (_, __) => SetView(SchedulerViewType.Day);
            btnViewWorkWeek.ItemClick += (_, __) => SetView(SchedulerViewType.WorkWeek);
            btnViewMonth.ItemClick += (_, __) => SetView(SchedulerViewType.Month);
            btnViewAgenda.ItemClick += (_, __) => SetView(SchedulerViewType.Agenda);

            btnMarkExcused.ItemClick += (_, __) => MarkSelectedExcused();
            btnMarkUnexcused.ItemClick += (_, __) => MarkSelectedUnexcused();
            btnMarkRestDay.ItemClick += (_, __) => MarkSelectedRestDay();
            btnApproveOvertime.ItemClick += (_, __) => ApproveSelectedOvertime();
            btnRecalculate.ItemClick += (_, __) => RecalculateDay();
            btnEdit.ItemClick += (_, __) => EditSelected();
            btnSave.ItemClick += (_, __) => SaveChanges();
            btnDelete.ItemClick += (_, __) => DeleteSelected();
            btnAttendanceLogs.ItemClick += (_, __) => OpenAttendanceLogs();
            btnClose.ItemClick += (_, __) => Close();

            schedulerControl1.AppointmentViewInfoCustomizing += SchedulerControl1_AppointmentViewInfoCustomizing;
            schedulerControl1.EditAppointmentFormShowing += SchedulerControl1_EditAppointmentFormShowing;
            schedulerControl1.VisibleIntervalChanged += SchedulerControl1_VisibleIntervalChanged;
            schedulerControl1.PopupMenuShowing += SchedulerControl1_PopupMenuShowing;
            schedulerControl1.KeyDown += SchedulerControl1_KeyDown;
            schedulerDataStorage1.AppointmentsChanged += SchedulerDataStorage1_AppointmentsChanged;
            schedulerDataStorage1.AppointmentsDeleted += SchedulerDataStorage1_AppointmentsDeleted;
        }

        private void InitFilters()
        {
            // Stores
            var stores = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Store)
                .Select(x => new { x.CurrAccCode, x.CurrAccDesc })
                .ToList();
            repoStore.DataSource = stores;
            repoStore.DisplayMember = "CurrAccDesc";
            repoStore.ValueMember = "CurrAccCode";

            // Statuses
            repoStatus.Items.Add(Properties.Resources.Form_DailyAttendance_AllStatus);
            foreach (AttendanceStatus status in Enum.GetValues(typeof(AttendanceStatus)))
            {
                repoStatus.Items.Add(status.ToString());
            }
            barEditStatus.EditValue = Properties.Resources.Form_DailyAttendance_AllStatus;
        }

        private void BarEditDate_EditValueChanged(object? sender, EventArgs e)
        {
            if (_isSyncingDate) return;
            if (barEditDate.EditValue is DateTime dt)
            {
                _isSyncingDate = true;
                try
                {
                    schedulerControl1.Start = dt.Date;
                    LoadData();
                }
                finally
                {
                    _isSyncingDate = false;
                }
            }
        }

        private void SchedulerControl1_VisibleIntervalChanged(object? sender, EventArgs e)
        {
            if (_isSyncingDate) return;
            DateTime newStart = schedulerControl1.Start.Date;
            if (barEditDate.EditValue is DateTime cur && cur.Date == newStart)
                return;

            _isSyncingDate = true;
            try
            {
                barEditDate.EditValue = newStart;
                LoadData();
            }
            finally
            {
                _isSyncingDate = false;
            }
        }

        private void GoToToday()
        {
            DateTime today = DateTime.Today;
            barEditDate.EditValue = today;
            schedulerControl1.Start = today;
            LoadData();
        }

        private void GoToPrevious()
        {
            DateTime cur = barEditDate.EditValue as DateTime? ?? DateTime.Today;
            DateTime prev = cur.AddDays(-1);
            barEditDate.EditValue = prev;
            schedulerControl1.Start = prev;
            LoadData();
        }

        private void GoToNext()
        {
            DateTime cur = barEditDate.EditValue as DateTime? ?? DateTime.Today;
            DateTime next = cur.AddDays(1);
            barEditDate.EditValue = next;
            schedulerControl1.Start = next;
            LoadData();
        }

        private void SetView(SchedulerViewType viewType)
        {
            schedulerControl1.ActiveViewType = viewType;
        }

        private void LoadData()
        {
            db.ChangeTracker.Clear();

            if (barEditDate.EditValue is not DateTime selectedDate)
                selectedDate = DateTime.Today;

            string? storeCode = barEditStore.EditValue?.ToString();
            string? statusFilter = barEditStatus.EditValue?.ToString();

            // 1. Visible date range
            DateTime start = selectedDate.Date;
            DateTime end = start.AddDays(1);
            try
            {
                var intervals = schedulerControl1.ActiveView.GetVisibleIntervals();
                if (intervals != null && intervals.Count > 0)
                {
                    start = intervals.Start.Date;
                    end = intervals.End.Date;
                    if (end <= start) end = start.AddDays(1);
                }
            }
            catch
            {
                start = selectedDate.Date;
                end = start.AddDays(1);
            }

            // 2. Load Resources (Employees)
            var empQuery = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel);

            if (!string.IsNullOrWhiteSpace(storeCode))
                empQuery = empQuery.Where(x => x.StoreCode == storeCode);

            var employees = empQuery.OrderBy(x => x.CurrAccDesc).ToList();
            var empCodes = employees.Select(x => x.CurrAccCode).ToList();

            var empPositions = db.TrEmployeePositions.AsNoTracking()
                .Include(p => p.Position).ThenInclude(pos => pos.Department)
                .Where(p => empCodes.Contains(p.CurrAccCode) &&
                            p.StartDate <= end &&
                            (p.EndDate == null || p.EndDate >= start))
                .ToList();

            var resList = new List<AttendanceResourceVM>();
            foreach (var emp in employees)
            {
                var pos = empPositions.FirstOrDefault(p => p.CurrAccCode == emp.CurrAccCode);
                string name = !string.IsNullOrWhiteSpace(emp.CurrAccDesc)
                    ? emp.CurrAccDesc
                    : $"{emp.FirstName} {emp.LastName}".Trim();
                string caption = name;
                if (!string.IsNullOrWhiteSpace(pos?.Position?.PositionName))
                    caption += $" - {pos.Position.PositionName}";

                resList.Add(new AttendanceResourceVM
                {
                    CurrAccCode = emp.CurrAccCode,
                    Caption = caption,
                    DepartmentName = pos?.Position?.Department?.DepartmentName,
                    PositionName = pos?.Position?.PositionName,
                    StoreCode = emp.StoreCode
                });
            }

            // 3. Load Attendances for visible interval
            IQueryable<TrAttendance> query = db.TrAttendances.AsNoTracking()
                .Include(a => a.DcCurrAcc)
                .Include(a => a.WorkSchedule)
                .Include(a => a.LeaveRequest).ThenInclude(l => l!.LeaveType)
                .Where(a => a.WorkDate.Date >= start && a.WorkDate.Date < end);

            if (!string.IsNullOrWhiteSpace(storeCode))
                query = query.Where(a => a.DcCurrAcc.StoreCode == storeCode);

            var attendances = query.ToList();

            // Ensure any employee present in attendances is also in resource list
            foreach (var att in attendances)
            {
                if (resList.All(r => r.CurrAccCode != att.CurrAccCode))
                {
                    string name = !string.IsNullOrWhiteSpace(att.DcCurrAcc?.CurrAccDesc)
                        ? att.DcCurrAcc.CurrAccDesc
                        : $"{att.DcCurrAcc?.FirstName} {att.DcCurrAcc?.LastName}".Trim();
                    resList.Add(new AttendanceResourceVM
                    {
                        CurrAccCode = att.CurrAccCode,
                        Caption = string.IsNullOrWhiteSpace(name) ? att.CurrAccCode : name,
                        StoreCode = att.DcCurrAcc?.StoreCode
                    });
                }
            }

            // Filter by status if specified
            if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != Properties.Resources.Form_DailyAttendance_AllStatus)
            {
                attendances = attendances.Where(x => x.AttendanceStatus.ToString() == statusFilter).ToList();
            }

            // 4. Build Appointment VMs
            var aptList = new List<DailyAttendanceVM>();

            foreach (var a in attendances)
            {
                var pos = empPositions.FirstOrDefault(p => p.CurrAccCode == a.CurrAccCode);
                string empName = !string.IsNullOrWhiteSpace(a.DcCurrAcc?.CurrAccDesc)
                    ? a.DcCurrAcc.CurrAccDesc
                    : $"{a.DcCurrAcc?.FirstName} {a.DcCurrAcc?.LastName}".Trim();

                DateTime workDate = a.WorkDate.Date;
                DateTime startTime;
                DateTime endTime;
                bool allDay;

                if (a.CheckInTime != null)
                {
                    var checkIn = a.CheckInTime.Value;
                    startTime = workDate.AddHours(checkIn.Hour).AddMinutes(checkIn.Minute).AddSeconds(checkIn.Second);

                    if (a.CheckOutTime != null)
                    {
                        var checkOut = a.CheckOutTime.Value;
                        endTime = workDate.AddHours(checkOut.Hour).AddMinutes(checkOut.Minute).AddSeconds(checkOut.Second);
                        if (endTime <= startTime)
                            endTime = endTime.AddDays(1);
                    }
                    else if (a.PlannedCheckOutTime != null)
                    {
                        var planOut = a.PlannedCheckOutTime.Value;
                        endTime = workDate.AddHours(planOut.Hour).AddMinutes(planOut.Minute).AddSeconds(planOut.Second);
                        if (endTime <= startTime)
                            endTime = startTime.AddHours(8);
                    }
                    else
                    {
                        endTime = startTime.AddHours(8);
                    }

                    if (endTime <= startTime) endTime = startTime.AddMinutes(30);
                    allDay = false;
                }
                else if (a.PlannedCheckInTime != null && (a.AttendanceStatus == AttendanceStatus.Present || a.AttendanceStatus == AttendanceStatus.Late || a.AttendanceStatus == AttendanceStatus.EarlyExit))
                {
                    var planIn = a.PlannedCheckInTime.Value;
                    startTime = workDate.AddHours(planIn.Hour).AddMinutes(planIn.Minute).AddSeconds(planIn.Second);

                    if (a.PlannedCheckOutTime != null)
                    {
                        var planOut = a.PlannedCheckOutTime.Value;
                        endTime = workDate.AddHours(planOut.Hour).AddMinutes(planOut.Minute).AddSeconds(planOut.Second);
                        if (endTime <= startTime)
                            endTime = endTime.AddDays(1);
                    }
                    else
                    {
                        endTime = startTime.AddHours(8);
                    }

                    if (endTime <= startTime) endTime = startTime.AddMinutes(30);
                    allDay = false;
                }
                else
                {
                    startTime = workDate;
                    endTime = workDate.AddDays(1);
                    allDay = true;
                }

                string statusText = a.AttendanceStatus.ToString();
                string subject;
                if (allDay)
                {
                    string extra = a.LeaveRequest?.LeaveType?.TypeName ?? a.Notes ?? string.Empty;
                    subject = string.IsNullOrWhiteSpace(extra) ? statusText : $"{statusText} ({extra})";
                }
                else
                {
                    string inStr = a.CheckInTime?.ToString("HH:mm") ?? a.PlannedCheckInTime?.ToString("HH:mm") ?? "-";
                    string outStr = a.CheckOutTime?.ToString("HH:mm") ?? a.PlannedCheckOutTime?.ToString("HH:mm") ?? "-";
                    subject = $"{inStr} - {outStr} [{statusText}]";
                    if (a.LateMinutes > 0)
                        subject += $" Gecikmə: {a.LateMinutes}d";
                    if (a.OvertimeMinutes > 0)
                        subject += $" Əlavə: {a.OvertimeMinutes}d";
                }

                string description =
                    $"İşçi: {empName} ({a.CurrAccCode})\r\n" +
                    $"Tarix: {a.WorkDate:dd.MM.yyyy}\r\n" +
                    $"Status: {statusText}\r\n" +
                    $"Plan: {(a.PlannedCheckInTime?.ToString("HH:mm") ?? "-")} - {(a.PlannedCheckOutTime?.ToString("HH:mm") ?? "-")}\r\n" +
                    $"Faktiki: {(a.CheckInTime?.ToString("HH:mm") ?? "-")} - {(a.CheckOutTime?.ToString("HH:mm") ?? "-")}\r\n" +
                    $"İşlənən: {a.WorkedMinutes} dəq\r\n" +
                    $"Gecikmə: {a.LateMinutes} dəq | Erkən çıxış: {a.EarlyExitMinutes} dəq\r\n" +
                    $"Əlavə iş: {a.OvertimeMinutes} dəq (Təsdiqlənən: {a.ApprovedOvertimeMinutes} dəq)" +
                    (!string.IsNullOrWhiteSpace(a.Notes) ? $"\r\nQeyd: {a.Notes}" : string.Empty);

                aptList.Add(new DailyAttendanceVM
                {
                    Id = a.Id,
                    CurrAccCode = a.CurrAccCode,
                    EmployeeName = empName,
                    StoreCode = a.DcCurrAcc?.StoreCode,
                    DepartmentName = pos?.Position?.Department?.DepartmentName,
                    PositionName = pos?.Position?.PositionName,
                    ScheduleName = a.WorkSchedule?.ScheduleName,
                    PlannedCheckInTime = a.PlannedCheckInTime,
                    PlannedCheckOutTime = a.PlannedCheckOutTime,
                    CheckInTime = a.CheckInTime,
                    CheckOutTime = a.CheckOutTime,
                    EffectiveStartTime = a.EffectiveStartTime,
                    BreakMinutes = a.BreakMinutes,
                    WorkedMinutes = a.WorkedMinutes,
                    LateMinutes = a.LateMinutes,
                    EarlyExitMinutes = a.EarlyExitMinutes,
                    OvertimeMinutes = a.OvertimeMinutes,
                    ApprovedOvertimeMinutes = a.ApprovedOvertimeMinutes,
                    AttendanceStatus = a.AttendanceStatus,
                    LeaveRequestId = a.LeaveRequestId,
                    LeaveTypeName = a.LeaveRequest?.LeaveType?.TypeName,
                    IsManualOverride = a.IsManualOverride,
                    Notes = a.Notes,
                    StartTime = startTime,
                    EndTime = endTime,
                    AllDay = allDay,
                    Subject = subject,
                    Description = description,
                    StatusId = (int)a.AttendanceStatus,
                    LabelId = (int)a.AttendanceStatus
                });
            }

            resourceList = new BindingList<AttendanceResourceVM>(resList);
            attendanceList = new BindingList<DailyAttendanceVM>(aptList);

            schedulerControl1.BeginUpdate();
            try
            {
                schedulerDataStorage1.Resources.DataSource = resourceList;
                schedulerDataStorage1.Appointments.DataSource = attendanceList;
            }
            finally
            {
                schedulerControl1.EndUpdate();
                schedulerControl1.RefreshData();
            }
        }

        private Guid GetAttendanceId(Appointment? apt)
        {
            if (apt == null) return Guid.Empty;

            if (schedulerDataStorage1.GetObjectRow(apt) is DailyAttendanceVM vm && vm.Id != Guid.Empty)
                return vm.Id;

            if (apt.Id is Guid gid && gid != Guid.Empty)
                return gid;

            if (apt.Id != null && Guid.TryParse(apt.Id.ToString(), out var parsedAptId) && parsedAptId != Guid.Empty)
                return parsedAptId;

            var cf = apt.CustomFields["AttendanceId"];
            if (cf is Guid cfg && cfg != Guid.Empty)
                return cfg;

            if (cf != null && Guid.TryParse(cf?.ToString(), out var parsedCfId) && parsedCfId != Guid.Empty)
                return parsedCfId;

            return Guid.Empty;
        }

        private void SchedulerControl1_AppointmentViewInfoCustomizing(object? sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            AttendanceStatus? status = (schedulerDataStorage1.GetObjectRow(e.ViewInfo.Appointment) as DailyAttendanceVM)?.AttendanceStatus;
            if (status == null && e.ViewInfo.Appointment.CustomFields["AttendanceStatus"] is AttendanceStatus st)
                status = st;

            if (status != null)
            {
                switch (status.Value)
                {
                    case AttendanceStatus.Present:
                        e.ViewInfo.Appearance.BackColor = Color.FromArgb(232, 248, 232);
                        e.ViewInfo.Appearance.ForeColor = Color.DarkGreen;
                        e.ViewInfo.Appearance.BorderColor = Color.FromArgb(46, 139, 87);
                        break;
                    case AttendanceStatus.Late:
                    case AttendanceStatus.EarlyExit:
                        e.ViewInfo.Appearance.BackColor = Color.FromArgb(255, 248, 220);
                        e.ViewInfo.Appearance.ForeColor = Color.DarkGoldenrod;
                        e.ViewInfo.Appearance.BorderColor = Color.FromArgb(218, 165, 32);
                        break;
                    case AttendanceStatus.AbsentUnexcused:
                        e.ViewInfo.Appearance.BackColor = Color.FromArgb(255, 230, 230);
                        e.ViewInfo.Appearance.ForeColor = Color.DarkRed;
                        e.ViewInfo.Appearance.BorderColor = Color.FromArgb(178, 34, 34);
                        break;
                    case AttendanceStatus.AbsentExcused:
                    case AttendanceStatus.SickLeave:
                    case AttendanceStatus.BusinessTrip:
                        e.ViewInfo.Appearance.BackColor = Color.FromArgb(230, 242, 255);
                        e.ViewInfo.Appearance.ForeColor = Color.DarkBlue;
                        e.ViewInfo.Appearance.BorderColor = Color.FromArgb(70, 130, 180);
                        break;
                    case AttendanceStatus.RestDay:
                    case AttendanceStatus.Holiday:
                        e.ViewInfo.Appearance.BackColor = Color.FromArgb(245, 245, 245);
                        e.ViewInfo.Appearance.ForeColor = Color.FromArgb(100, 100, 100);
                        e.ViewInfo.Appearance.BorderColor = Color.FromArgb(169, 169, 169);
                        break;
                }
            }
        }

        private void SchedulerControl1_EditAppointmentFormShowing(object? sender, AppointmentFormEventArgs e)
        {
            e.Handled = true;
            Guid attId = GetAttendanceId(e.Appointment);
            if (attId != Guid.Empty)
            {
                using var editForm = new FormAttendanceEdit(attId);
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                using var editForm = new FormAttendanceEdit(null);
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void SchedulerControl1_PopupMenuShowing(object? sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == SchedulerMenuType.AppointmentMenu)
            {
                if (e.HitInfo?.ViewInfo is AppointmentViewInfo avi && avi.Appointment != null)
                {
                    if (!schedulerControl1.SelectedAppointments.Contains(avi.Appointment))
                    {
                        schedulerControl1.SelectedAppointments.Clear();
                        schedulerControl1.SelectedAppointments.Add(avi.Appointment);
                    }
                }

                e.Menu.Items.Clear();

                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Common_Edit, (_, __) => EditSelected()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Form_DailyAttendance_MarkExcused, (_, __) => MarkSelectedExcused()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Form_DailyAttendance_MarkUnexcused, (_, __) => MarkSelectedUnexcused()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Form_DailyAttendance_MarkRestDay, (_, __) => MarkSelectedRestDay()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Form_DailyAttendance_ApproveOvertime, (_, __) => ApproveSelectedOvertime()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Common_Delete, (_, __) => DeleteSelected()));
            }
            else if (e.MenuType == SchedulerMenuType.DefaultMenu)
            {
                e.Menu.Items.Clear();
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Form_DailyAttendance_Recalculate, (_, __) => RecalculateDay()));
                e.Menu.Items.Add(new SchedulerMenuItem(Properties.Resources.Common_Refresh, (_, __) => LoadData()));
            }
        }

        private void SchedulerControl1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                DeleteSelected();
            }
        }

        private void SchedulerDataStorage1_AppointmentsChanged(object? sender, PersistentObjectsEventArgs e)
        {
            bool anySaved = false;
            foreach (Appointment apt in e.Objects)
            {
                Guid attId = GetAttendanceId(apt);
                if (attId != Guid.Empty)
                {
                    var entity = db.TrAttendances.FirstOrDefault(x => x.Id == attId);
                    if (entity != null)
                    {
                        entity.CheckInTime = apt.Start;
                        entity.CheckOutTime = apt.End;
                        entity.IsManualOverride = true;
                        entity.WorkedMinutes = Math.Max(0, (int)(apt.End - apt.Start).TotalMinutes - entity.BreakMinutes);

                        string inStr = apt.Start.ToString("HH:mm");
                        string outStr = apt.End.ToString("HH:mm");
                        apt.Subject = $"{inStr} - {outStr} [{entity.AttendanceStatus}]";

                        var vm = attendanceList.FirstOrDefault(x => x.Id == attId);
                        if (vm != null)
                        {
                            vm.CheckInTime = apt.Start;
                            vm.CheckOutTime = apt.End;
                            vm.StartTime = apt.Start;
                            vm.EndTime = apt.End;
                            vm.WorkedMinutes = entity.WorkedMinutes;
                            vm.IsManualOverride = true;
                            vm.Subject = apt.Subject;
                        }

                        anySaved = true;
                    }
                }
            }

            if (anySaved)
            {
                db.SaveChanges();
            }
        }

        private void SchedulerDataStorage1_AppointmentsDeleted(object? sender, PersistentObjectsEventArgs e)
        {
            var ids = new List<Guid>();
            foreach (Appointment apt in e.Objects)
            {
                Guid attId = GetAttendanceId(apt);
                if (attId != Guid.Empty && !ids.Contains(attId))
                    ids.Add(attId);
            }

            if (ids.Any())
            {
                var entitiesToDelete = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();
                if (entitiesToDelete.Any())
                {
                    db.TrAttendances.RemoveRange(entitiesToDelete);
                    db.SaveChanges();
                }
            }
        }

        private List<Guid> GetSelectedAttendanceIds()
        {
            var list = new List<Guid>();
            foreach (Appointment apt in schedulerControl1.SelectedAppointments)
            {
                Guid id = GetAttendanceId(apt);
                if (id != Guid.Empty && !list.Contains(id))
                    list.Add(id);
            }
            return list;
        }

        private void MarkSelectedExcused()
        {
            var ids = GetSelectedAttendanceIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_NoRecordSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var leaveType = db.HrLeaveTypes.FirstOrDefault(x => x.TypeCode == "PersonalPermission")
                            ?? db.HrLeaveTypes.FirstOrDefault();

            var entities = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();

            foreach (var att in entities)
            {
                att.AttendanceStatus = AttendanceStatus.AbsentExcused;
                att.IsManualOverride = true;
                att.Notes = Properties.Resources.Form_DailyAttendance_MarkExcused;
            }

            db.SaveChanges();
            LoadData();
        }

        private void MarkSelectedUnexcused()
        {
            var ids = GetSelectedAttendanceIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_NoRecordSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var entities = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();

            foreach (var att in entities)
            {
                att.AttendanceStatus = AttendanceStatus.AbsentUnexcused;
                att.IsManualOverride = true;
                att.Notes = Properties.Resources.Form_DailyAttendance_MarkUnexcused;
                att.LeaveRequestId = null;
            }

            db.SaveChanges();
            LoadData();
        }

        private void MarkSelectedRestDay()
        {
            var ids = GetSelectedAttendanceIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_NoRecordSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var entities = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();

            foreach (var att in entities)
            {
                att.AttendanceStatus = AttendanceStatus.RestDay;
                att.PlannedWorkMinutes = 0;
                att.PlannedCheckInTime = null;
                att.PlannedCheckOutTime = null;
                att.LateMinutes = 0;
                att.EarlyExitMinutes = 0;
                att.OvertimeMinutes = 0;
                att.ApprovedOvertimeMinutes = 0;
                att.WorkedMinutes = 0;
                att.IsManualOverride = true;
                att.Notes = Properties.Resources.Form_DailyAttendance_MarkRestDay;
                att.LeaveRequestId = null;
            }

            db.SaveChanges();
            LoadData();
        }

        private void ApproveSelectedOvertime()
        {
            var ids = GetSelectedAttendanceIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_NoRecordSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var entities = db.TrAttendances.Where(x => ids.Contains(x.Id) && x.OvertimeMinutes > 0).ToList();
            if (!entities.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Common_Attention, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var att in entities)
            {
                att.ApprovedOvertimeMinutes = att.OvertimeMinutes;
                att.IsManualOverride = true;
            }

            db.SaveChanges();
            LoadData();
        }

        private void EditSelected()
        {
            var selectedApt = schedulerControl1.SelectedAppointments.FirstOrDefault();
            Guid attId = GetAttendanceId(selectedApt);
            if (attId != Guid.Empty)
            {
                using var editForm = new FormAttendanceEdit(attId);
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_NoRecordSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedAttendanceIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_SelectRowsToDelete,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string confirmMsg = string.Format(Properties.Resources.Form_DailyAttendance_DeleteConfirm, ids.Count);
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entitiesToDelete = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();
            if (entitiesToDelete.Any())
            {
                db.TrAttendances.RemoveRange(entitiesToDelete);
                db.SaveChanges();
            }

            LoadData();

            XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_DeleteSuccess,
                Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RecalculateDay()
        {
            if (barEditDate.EditValue is not DateTime selectedDate)
                selectedDate = DateTime.Today;

            if (selectedDate.Date > DateTime.Today)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_FutureDateWarning,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? storeCode = barEditStore.EditValue?.ToString();

            string confirmMsg = string.Format(Properties.Resources.Form_DailyAttendance_RecalculateConfirm, selectedDate.ToString("dd.MM.yyyy"));
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            calcService.CalculateAttendance(selectedDate.Date, selectedDate.Date, storeCode, null, null, null, true);
            LoadData();

            XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_RecalculatedSuccess,
                Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveChanges()
        {
            db.SaveChanges();
            XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_SavedSuccess,
                Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenAttendanceLogs()
        {
            DateTime? selectedDate = barEditDate.EditValue as DateTime?;
            using var form = new FormAttendanceLogList(selectedDate);
            form.ShowDialog(this);
            LoadData();
        }
    }
}
