using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public class DailyAttendanceVM : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string CurrAccCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string? StoreCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? PositionName { get; set; }
        public string? ScheduleName { get; set; }

        public DateTime? PlannedCheckInTime { get; set; }
        public DateTime? PlannedCheckOutTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime? EffectiveStartTime { get; set; }

        public int BreakMinutes { get; set; }
        public int WorkedMinutes { get; set; }
        public decimal WorkedHours => Math.Round((decimal)WorkedMinutes / 60.0m, 2);

        public int LateMinutes { get; set; }
        public int EarlyExitMinutes { get; set; }
        public int OvertimeMinutes { get; set; }
        public int ApprovedOvertimeMinutes { get; set; }

        public AttendanceStatus AttendanceStatus { get; set; }
        public string StatusDesc => AttendanceStatus.ToString();

        public Guid? LeaveRequestId { get; set; }
        public string? LeaveTypeName { get; set; }

        public bool IsManualOverride { get; set; }
        public string? Notes { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public partial class FormDailyAttendanceManager : RibbonForm
    {
        private readonly subContext db = new();
        private readonly AttendanceCalculationService calcService = new();
        private BindingList<DailyAttendanceVM> viewList = new();

        public FormDailyAttendanceManager()
        {
            InitializeComponent();

            barEditDate.EditValue = DateTime.Today;
            InitFilters();

            Load += (_, __) => LoadData();
            btnRefresh.ItemClick += (_, __) => LoadData();
            barEditDate.EditValueChanged += (_, __) => LoadData();
            barEditStore.EditValueChanged += (_, __) => LoadData();
            barEditStatus.EditValueChanged += (_, __) => FilterGrid();

            btnMarkExcused.ItemClick += (_, __) => MarkSelectedExcused();
            btnMarkUnexcused.ItemClick += (_, __) => MarkSelectedUnexcused();
            btnMarkRestDay.ItemClick += (_, __) => MarkSelectedRestDay();
            btnApproveOvertime.ItemClick += (_, __) => ApproveSelectedOvertime();
            btnRecalculate.ItemClick += (_, __) => RecalculateDay();
            btnSave.ItemClick += (_, __) => SaveChanges();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.RowStyle += GridView1_RowStyle;
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

        private void LoadData()
        {
            if (barEditDate.EditValue is not DateTime selectedDate)
                selectedDate = DateTime.Today;

            string? storeCode = barEditStore.EditValue?.ToString();

            // Mövcud qeydləri gətir
            var attendances = db.TrAttendances
                .Include(a => a.DcCurrAcc)
                .Include(a => a.WorkSchedule)
                .Include(a => a.LeaveRequest).ThenInclude(l => l!.LeaveType)
                .Where(a => a.WorkDate.Date == selectedDate.Date)
                .ToList();

            // Əgər seçilmiş gün üçün hələ davamiyyət qeydləri yoxdursa, avtomatik hesabla
            if (!attendances.Any())
            {
                calcService.CalculateAttendance(selectedDate.Date, selectedDate.Date, storeCode, null, null, null, true);
                attendances = db.TrAttendances
                    .Include(a => a.DcCurrAcc)
                    .Include(a => a.WorkSchedule)
                    .Include(a => a.LeaveRequest).ThenInclude(l => l!.LeaveType)
                    .Where(a => a.WorkDate.Date == selectedDate.Date)
                    .ToList();
            }

            var empCodes = attendances.Select(a => a.CurrAccCode).Distinct().ToList();

            var empPositions = db.TrEmployeePositions.AsNoTracking()
                .Include(p => p.Position).ThenInclude(pos => pos.Department)
                .Where(p => empCodes.Contains(p.CurrAccCode) &&
                            p.StartDate <= selectedDate &&
                            (p.EndDate == null || p.EndDate >= selectedDate))
                .ToList();

            var list = new List<DailyAttendanceVM>();

            foreach (var a in attendances)
            {
                if (!string.IsNullOrWhiteSpace(storeCode) && a.DcCurrAcc.StoreCode != storeCode)
                    continue;

                var pos = empPositions.FirstOrDefault(p => p.CurrAccCode == a.CurrAccCode);

                list.Add(new DailyAttendanceVM
                {
                    Id = a.Id,
                    CurrAccCode = a.CurrAccCode,
                    EmployeeName = (!string.IsNullOrWhiteSpace(a.DcCurrAcc.CurrAccDesc)
                        ? a.DcCurrAcc.CurrAccDesc
                        : $"{a.DcCurrAcc.FirstName} {a.DcCurrAcc.LastName}".Trim()),
                    StoreCode = a.DcCurrAcc.StoreCode,
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
                    Notes = a.Notes
                });
            }

            viewList = new BindingList<DailyAttendanceVM>(list.OrderBy(x => x.EmployeeName).ToList());
            gridControl1.DataSource = viewList;

            FormatGrid();
            FilterGrid();
        }

        private void FormatGrid()
        {
            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
            if (gridView1.Columns["LeaveRequestId"] != null) gridView1.Columns["LeaveRequestId"].Visible = false;

            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_CurrAcc_Code;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["StoreCode"] != null) gridView1.Columns["StoreCode"].Caption = Properties.Resources.Common_Store;
            if (gridView1.Columns["DepartmentName"] != null) gridView1.Columns["DepartmentName"].Caption = Properties.Resources.Entity_DcDepartment_DepartmentName;
            if (gridView1.Columns["PositionName"] != null) gridView1.Columns["PositionName"].Caption = Properties.Resources.Entity_DcPosition_PositionName;
            if (gridView1.Columns["ScheduleName"] != null) gridView1.Columns["ScheduleName"].Caption = Properties.Resources.ERP_ACE_WorkSchedules;

            if (gridView1.Columns["PlannedCheckInTime"] != null)
            {
                gridView1.Columns["PlannedCheckInTime"].Caption = Properties.Resources.Entity_Attendance_PlannedCheckIn;
                gridView1.Columns["PlannedCheckInTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["PlannedCheckInTime"].DisplayFormat.FormatString = "HH:mm";
            }
            if (gridView1.Columns["PlannedCheckOutTime"] != null)
            {
                gridView1.Columns["PlannedCheckOutTime"].Caption = Properties.Resources.Entity_Attendance_PlannedCheckOut;
                gridView1.Columns["PlannedCheckOutTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["PlannedCheckOutTime"].DisplayFormat.FormatString = "HH:mm";
            }
            if (gridView1.Columns["CheckInTime"] != null)
            {
                gridView1.Columns["CheckInTime"].Caption = Properties.Resources.Entity_TrAttendance_CheckInTime;
                gridView1.Columns["CheckInTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["CheckInTime"].DisplayFormat.FormatString = "HH:mm";
            }
            if (gridView1.Columns["CheckOutTime"] != null)
            {
                gridView1.Columns["CheckOutTime"].Caption = Properties.Resources.Entity_TrAttendance_CheckOutTime;
                gridView1.Columns["CheckOutTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["CheckOutTime"].DisplayFormat.FormatString = "HH:mm";
            }
            if (gridView1.Columns["EffectiveStartTime"] != null)
            {
                gridView1.Columns["EffectiveStartTime"].Caption = Properties.Resources.Entity_Attendance_EffectiveStart;
                gridView1.Columns["EffectiveStartTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["EffectiveStartTime"].DisplayFormat.FormatString = "HH:mm";
            }

            if (gridView1.Columns["BreakMinutes"] != null) gridView1.Columns["BreakMinutes"].Caption = Properties.Resources.Common_Break;
            if (gridView1.Columns["WorkedMinutes"] != null) gridView1.Columns["WorkedMinutes"].Caption = Properties.Resources.Entity_TrAttendance_WorkedMinutes;
            if (gridView1.Columns["WorkedHours"] != null) gridView1.Columns["WorkedHours"].Caption = Properties.Resources.Common_Hours;
            if (gridView1.Columns["LateMinutes"] != null) gridView1.Columns["LateMinutes"].Caption = Properties.Resources.Entity_Attendance_LateMinutes;
            if (gridView1.Columns["EarlyExitMinutes"] != null) gridView1.Columns["EarlyExitMinutes"].Caption = Properties.Resources.Entity_Attendance_EarlyExitMinutes;
            if (gridView1.Columns["OvertimeMinutes"] != null) gridView1.Columns["OvertimeMinutes"].Caption = Properties.Resources.Entity_Attendance_OvertimeMinutes;
            if (gridView1.Columns["ApprovedOvertimeMinutes"] != null) gridView1.Columns["ApprovedOvertimeMinutes"].Caption = Properties.Resources.Entity_Attendance_ApprovedOvertimeMinutes;
            if (gridView1.Columns["StatusDesc"] != null) gridView1.Columns["StatusDesc"].Caption = Properties.Resources.Entity_Attendance_Status;
            if (gridView1.Columns["LeaveTypeName"] != null) gridView1.Columns["LeaveTypeName"].Caption = Properties.Resources.ERP_ACE_LeaveRequests;
            if (gridView1.Columns["Notes"] != null) gridView1.Columns["Notes"].Caption = Properties.Resources.Common_Note;

            gridView1.BestFitColumns();
        }

        private void FilterGrid()
        {
            string? statusFilter = barEditStatus.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(statusFilter) || statusFilter == Properties.Resources.Form_DailyAttendance_AllStatus)
            {
                gridView1.ActiveFilterCriteria = null;
            }
            else
            {
                gridView1.ActiveFilterString = $"[StatusDesc] = '{statusFilter}'";
            }
        }

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var row = gridView1.GetRow(e.RowHandle) as DailyAttendanceVM;
            if (row == null) return;

            switch (row.AttendanceStatus)
            {
                case AttendanceStatus.AbsentUnexcused:
                    e.Appearance.BackColor = Color.FromArgb(255, 235, 235);
                    e.Appearance.ForeColor = Color.DarkRed;
                    break;
                case AttendanceStatus.Late:
                case AttendanceStatus.EarlyExit:
                    e.Appearance.BackColor = Color.FromArgb(255, 250, 230);
                    e.Appearance.ForeColor = Color.DarkGoldenrod;
                    break;
                case AttendanceStatus.AbsentExcused:
                case AttendanceStatus.SickLeave:
                case AttendanceStatus.BusinessTrip:
                    e.Appearance.BackColor = Color.FromArgb(235, 245, 255);
                    e.Appearance.ForeColor = Color.DarkBlue;
                    break;
                case AttendanceStatus.RestDay:
                    e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
                    e.Appearance.ForeColor = Color.Gray;
                    break;
                case AttendanceStatus.Present:
                    e.Appearance.BackColor = Color.FromArgb(240, 255, 240);
                    e.Appearance.ForeColor = Color.DarkGreen;
                    break;
            }
        }

        private void MarkSelectedExcused()
        {
            var selectedRow = gridView1.GetFocusedRow() as DailyAttendanceVM;
            if (selectedRow == null) return;

            // Standart üzrlü icazə növü tap (PersonalPermission və ya digər)
            var leaveType = db.HrLeaveTypes.FirstOrDefault(x => x.TypeCode == "PersonalPermission")
                            ?? db.HrLeaveTypes.FirstOrDefault();

            selectedRow.AttendanceStatus = AttendanceStatus.AbsentExcused;
            selectedRow.LeaveTypeName = leaveType?.TypeName ?? Properties.Resources.Form_DailyAttendance_MarkExcused;
            selectedRow.IsManualOverride = true;
            selectedRow.Notes = "HR tərəfindən icazəli qeyd edildi";

            var att = db.TrAttendances.FirstOrDefault(x => x.Id == selectedRow.Id);
            if (att != null)
            {
                att.AttendanceStatus = AttendanceStatus.AbsentExcused;
                att.IsManualOverride = true;
                att.Notes = selectedRow.Notes;
            }

            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void MarkSelectedUnexcused()
        {
            var selectedRow = gridView1.GetFocusedRow() as DailyAttendanceVM;
            if (selectedRow == null) return;

            selectedRow.AttendanceStatus = AttendanceStatus.AbsentUnexcused;
            selectedRow.LeaveTypeName = null;
            selectedRow.IsManualOverride = true;
            selectedRow.Notes = "HR tərəfindən üzrsüz qeyd edildi";

            var att = db.TrAttendances.FirstOrDefault(x => x.Id == selectedRow.Id);
            if (att != null)
            {
                att.AttendanceStatus = AttendanceStatus.AbsentUnexcused;
                att.IsManualOverride = true;
                att.Notes = selectedRow.Notes;
                att.LeaveRequestId = null;
            }

            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void MarkSelectedRestDay()
        {
            var selectedRow = gridView1.GetFocusedRow() as DailyAttendanceVM;
            if (selectedRow == null) return;

            selectedRow.AttendanceStatus = AttendanceStatus.RestDay;
            selectedRow.LeaveTypeName = null;
            selectedRow.PlannedCheckInTime = null;
            selectedRow.PlannedCheckOutTime = null;
            selectedRow.LateMinutes = 0;
            selectedRow.EarlyExitMinutes = 0;
            selectedRow.OvertimeMinutes = 0;
            selectedRow.ApprovedOvertimeMinutes = 0;
            selectedRow.WorkedMinutes = 0;
            selectedRow.IsManualOverride = true;
            selectedRow.Notes = "Manual istirahət günü təyin edildi";

            var att = db.TrAttendances.FirstOrDefault(x => x.Id == selectedRow.Id);
            if (att != null)
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
                att.Notes = selectedRow.Notes;
                att.LeaveRequestId = null;
            }

            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void ApproveSelectedOvertime()
        {
            var selectedRow = gridView1.GetFocusedRow() as DailyAttendanceVM;
            if (selectedRow == null) return;

            if (selectedRow.OvertimeMinutes <= 0)
            {
                XtraMessageBox.Show(this, "Bu işçi üçün əlavə iş vaxtı qeydə alınmayıb.", Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            selectedRow.ApprovedOvertimeMinutes = selectedRow.OvertimeMinutes;
            selectedRow.IsManualOverride = true;

            var att = db.TrAttendances.FirstOrDefault(x => x.Id == selectedRow.Id);
            if (att != null)
            {
                att.ApprovedOvertimeMinutes = selectedRow.OvertimeMinutes;
                att.IsManualOverride = true;
            }

            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void RecalculateDay()
        {
            if (barEditDate.EditValue is not DateTime selectedDate)
                selectedDate = DateTime.Today;

            string? storeCode = barEditStore.EditValue?.ToString();

            calcService.CalculateAttendance(selectedDate.Date, selectedDate.Date, storeCode, null, null, null, true);
            LoadData();

            XtraMessageBox.Show(this, "Seçilmiş gün üçün davamiyyət yenidən hesablandı.", Properties.Resources.Common_Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveChanges()
        {
            db.SaveChanges();
            XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_SavedSuccess, Properties.Resources.Common_Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
