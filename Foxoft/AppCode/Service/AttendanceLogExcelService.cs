using DevExpress.Spreadsheet;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Foxoft.AppCode.Service
{
    public class AttendanceLogImportResult
    {
        public int TotalReadRows { get; set; }
        public int ImportedCount { get; set; }
        public int SkippedDuplicateCount { get; set; }
        public int ErrorCount { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class AttendanceLogExcelService
    {
        private readonly subContext db = new();

        public AttendanceLogImportResult Import(string filePath, string? defaultDeviceCode = null)
        {
            var result = new AttendanceLogImportResult();

            if (!File.Exists(filePath))
            {
                result.Errors.Add("Fayl tapılmadı: " + filePath);
                return result;
            }

            using var workbook = new Workbook();
            workbook.LoadDocument(filePath);

            if (workbook.Worksheets.Count == 0)
            {
                result.Errors.Add("Excel sənədində heç bir vərəq tapılmadı.");
                return result;
            }

            var worksheet = workbook.Worksheets[0];
            var range = worksheet.GetUsedRange();
            if (range == null || range.RowCount < 2)
            {
                result.Errors.Add("Excel cədvəlində məlumat tapılmadı.");
                return result;
            }

            // 1. Sütunların indekslərini müəyyən et
            int colCode = -1;
            int colDateTime = -1;
            int colDate = -1;
            int colTime = -1;
            int colDevice = -1;
            int colPunchType = -1;

            int headerRowIndex = 0;
            for (int r = 0; r < Math.Min(5, range.RowCount); r++)
            {
                for (int c = 0; c < range.ColumnCount; c++)
                {
                    string header = (worksheet.Cells[r, c].Value?.ToString() ?? "").Trim().ToLowerInvariant();
                    if (string.IsNullOrWhiteSpace(header)) continue;

                    if (colCode == -1 && (header.Contains("curracc") || header.Contains("işçi") || header.Contains("isci") ||
                                          header.Contains("employee") || header.Contains("pin") || header.Contains("badge") ||
                                          header.Contains("user id") || header.Contains("userid") || header.Contains("ac-no") ||
                                          header == "id" || header == "kod" || header == "code"))
                    {
                        colCode = c;
                        headerRowIndex = r;
                    }
                    else if (colDateTime == -1 && (header.Contains("datetime") || header.Contains("tarix/saat") ||
                                                  header.Contains("tarix və saat") || header.Contains("date/time") ||
                                                  header.Contains("logdate") || header.Contains("vuruş vaxtı") || header.Contains("vaxt")))
                    {
                        colDateTime = c;
                        headerRowIndex = r;
                    }
                    else if (colDate == -1 && (header == "date" || header == "tarix" || header.Contains("tarix")))
                    {
                        colDate = c;
                        headerRowIndex = r;
                    }
                    else if (colTime == -1 && (header == "time" || header == "saat" || header.Contains("saat")))
                    {
                        colTime = c;
                        headerRowIndex = r;
                    }
                    else if (colDevice == -1 && (header.Contains("device") || header.Contains("cihaz") ||
                                                 header.Contains("terminal") || header.Contains("turniket") || header.Contains("location")))
                    {
                        colDevice = c;
                    }
                    else if (colPunchType == -1 && (header.Contains("punch") || header.Contains("növ") ||
                                                    header.Contains("nov") || header.Contains("status") || header.Contains("state") || header.Contains("in/out")))
                    {
                        colPunchType = c;
                    }
                }

                if (colCode != -1 && (colDateTime != -1 || (colDate != -1 && colTime != -1)))
                    break;
            }

            // Əgər sütun başlıqları adla tapılmadısa, avtomatik təxmin: 0-cı sütun kod, 1-ci sütun tarix/saat
            if (colCode == -1) colCode = 0;
            if (colDateTime == -1 && (colDate == -1 || colTime == -1)) colDateTime = 1;

            // 2. İşçilərin siyahısını bazadan yüklə
            var personnelList = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel)
                .ToList();

            var settings = db.DcAttendanceSettings.AsNoTracking().FirstOrDefault() ?? new DcAttendanceSetting();
            int debounceMinutes = settings.DebounceMinutes;

            var newLogs = new List<TrAttendanceLog>();
            string userName = Authorization.CurrAccCode ?? "System";

            for (int r = headerRowIndex + 1; r < range.RowCount; r++)
            {
                result.TotalReadRows++;

                // İşçi kodu oxu
                var rawCodeVal = worksheet.Cells[r, colCode].Value;
                string empCodeRaw = (rawCodeVal?.ToString() ?? "").Trim();
                if (string.IsNullOrWhiteSpace(empCodeRaw)) continue;

                // İşçini tap
                var emp = personnelList.FirstOrDefault(p =>
                    string.Equals(p.CurrAccCode, empCodeRaw, StringComparison.OrdinalIgnoreCase));

                if (emp == null)
                {
                    // Alternativ: rəqəmsal ID uyğunlaşdırması (məs: Excel-də "1", bazada "IS0001" və ya əksinə)
                    emp = personnelList.FirstOrDefault(p =>
                        p.CurrAccCode.EndsWith(empCodeRaw, StringComparison.OrdinalIgnoreCase) ||
                        empCodeRaw.EndsWith(p.CurrAccCode, StringComparison.OrdinalIgnoreCase));
                }

                if (emp == null)
                {
                    result.ErrorCount++;
                    if (result.Errors.Count < 50)
                        result.Errors.Add($"Sətir {r + 1}: '{empCodeRaw}' kodlu işçi tapılmadı.");
                    continue;
                }

                // Tarix/Saat oxu
                DateTime? logDt = null;
                if (colDateTime != -1)
                {
                    logDt = ReadCellDateTime(worksheet.Cells[r, colDateTime]);
                }
                else if (colDate != -1 && colTime != -1)
                {
                    var d = ReadCellDateTime(worksheet.Cells[r, colDate]);
                    var t = ReadCellTimeSpan(worksheet.Cells[r, colTime]);
                    if (d.HasValue && t.HasValue)
                        logDt = d.Value.Date.Add(t.Value);
                    else if (d.HasValue)
                        logDt = d.Value;
                }

                if (!logDt.HasValue || logDt.Value.Year < 2000)
                {
                    result.ErrorCount++;
                    if (result.Errors.Count < 50)
                        result.Errors.Add($"Sətir {r + 1}: Tarix/saat oxunmadı.");
                    continue;
                }

                DateTime punchTime = logDt.Value;

                // Cihaz kodu
                string devCode = defaultDeviceCode ?? "ExcelImport";
                if (colDevice != -1)
                {
                    var dVal = (worksheet.Cells[r, colDevice].Value?.ToString() ?? "").Trim();
                    if (!string.IsNullOrWhiteSpace(dVal)) devCode = dVal;
                }

                // Vuruş növü
                PunchType pType = PunchType.AutoDetect;
                if (colPunchType != -1)
                {
                    string ptStr = (worksheet.Cells[r, colPunchType].Value?.ToString() ?? "").Trim().ToLowerInvariant();
                    if (ptStr.Contains("in") || ptStr.Contains("giriş") || ptStr.Contains("giris"))
                        pType = PunchType.CheckIn;
                    else if (ptStr.Contains("out") || ptStr.Contains("çıxış") || ptStr.Contains("cixis"))
                        pType = PunchType.CheckOut;
                }

                // Minimum və maksimum tarixləri qeyd et
                if (!result.MinDate.HasValue || punchTime < result.MinDate.Value)
                    result.MinDate = punchTime.Date;
                if (!result.MaxDate.HasValue || punchTime > result.MaxDate.Value)
                    result.MaxDate = punchTime.Date;

                // Dublikat yoxlanışı (həm bu sessiyada yaradılanlar arasında, həm bazada)
                bool isDupInSession = newLogs.Any(x => x.CurrAccCode == emp.CurrAccCode &&
                                                      Math.Abs((x.LogDateTime - punchTime).TotalSeconds) < 1);
                if (isDupInSession)
                {
                    result.SkippedDuplicateCount++;
                    continue;
                }

                bool isDupInDb = db.TrAttendanceLogs.AsNoTracking().Any(x =>
                    x.CurrAccCode == emp.CurrAccCode &&
                    x.LogDateTime >= punchTime.AddSeconds(-1) &&
                    x.LogDateTime <= punchTime.AddSeconds(1));

                if (isDupInDb)
                {
                    result.SkippedDuplicateCount++;
                    continue;
                }

                // Debounce (Anti-double punch) yoxlanışı
                bool isDebounced = false;
                if (debounceMinutes > 0)
                {
                    isDebounced = newLogs.Any(x => x.CurrAccCode == emp.CurrAccCode &&
                                                  x.DeviceCode == devCode &&
                                                  Math.Abs((x.LogDateTime - punchTime).TotalMinutes) < debounceMinutes &&
                                                  !x.IsIgnored);
                }

                newLogs.Add(new TrAttendanceLog
                {
                    Id = Guid.NewGuid(),
                    CurrAccCode = emp.CurrAccCode,
                    LogDateTime = punchTime,
                    DeviceCode = devCode,
                    PunchType = pType,
                    SourceMethod = PunchSourceMethod.ExcelImport,
                    IsIgnored = isDebounced,
                    IgnoreReason = isDebounced ? "Debounce (təkrar vuruş)" : null,
                    CreatedDate = DateTime.Now,
                    CreatedUserName = userName
                });

                result.ImportedCount++;
            }

            if (newLogs.Any())
            {
                db.TrAttendanceLogs.AddRange(newLogs);
                db.SaveChanges();
            }

            return result;
        }

        private static DateTime? ReadCellDateTime(Cell cell)
        {
            if (cell.Value.IsEmpty) return null;

            if (cell.Value.IsDateTime)
                return cell.Value.DateTimeValue;

            if (cell.Value.IsNumeric)
            {
                try
                {
                    double d = cell.Value.NumericValue;
                    if (d > 30000 && d < 70000)
                        return DateTime.FromOADate(d);
                }
                catch { }
            }

            string text = cell.Value.ToString().Trim();
            if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt) ||
                DateTime.TryParse(text, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt) ||
                DateTime.TryParseExact(text, new[] {
                    "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy HH:mm:ss",
                    "dd.MM.yyyy HH:mm", "yyyy-MM-dd HH:mm", "dd/MM/yyyy HH:mm",
                    "dd.MM.yyyy", "yyyy-MM-dd", "dd/MM/yyyy", "M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt"
                }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return dt;
            }

            return null;
        }

        private static TimeSpan? ReadCellTimeSpan(Cell cell)
        {
            if (cell.Value.IsEmpty) return null;

            if (cell.Value.IsDateTime)
                return cell.Value.DateTimeValue.TimeOfDay;

            if (cell.Value.IsNumeric)
            {
                try
                {
                    double val = cell.Value.NumericValue;
                    if (val >= 0 && val < 1) // Excel vaxtı günün kəsri kimi saxlayır
                        return TimeSpan.FromDays(val);
                }
                catch { }
            }

            string text = cell.Value.ToString().Trim();
            if (TimeSpan.TryParse(text, out var ts))
                return ts;

            if (DateTime.TryParse(text, out var dt))
                return dt.TimeOfDay;

            return null;
        }
    }
}
