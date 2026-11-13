using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormAttendanceSettings : XtraForm
    {
        private readonly subContext db = new();
        private DcAttendanceSetting entity;

        public FormAttendanceSettings()
        {
            InitializeComponent();

            InitDropdowns();
            LoadSettings();

            btnSave.Click += (_, __) => SaveSettings();
            btnCancel.Click += (_, __) => Close();
        }

        private void InitDropdowns()
        {
            // Schedules
            var schedules = db.DcWorkSchedules.AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new { x.Id, x.ScheduleName })
                .ToList();
            lkpDefaultSchedule.Properties.DataSource = schedules;
            lkpDefaultSchedule.Properties.DisplayMember = "ScheduleName";
            lkpDefaultSchedule.Properties.ValueMember = "Id";

            // Attendance Methods
            cmbAttendanceMethod.Properties.Items.Clear();
            foreach (AttendanceMethod m in Enum.GetValues(typeof(AttendanceMethod)))
                cmbAttendanceMethod.Properties.Items.Add(m);

            // Late Methods
            cmbLateCalculationMethod.Properties.Items.Clear();
            foreach (LateCalculationMethod m in Enum.GetValues(typeof(LateCalculationMethod)))
                cmbLateCalculationMethod.Properties.Items.Add(m);

            // Late Rounding
            cmbLateRoundingMethod.Properties.Items.Clear();
            foreach (LateRoundingMethod m in Enum.GetValues(typeof(LateRoundingMethod)))
                cmbLateRoundingMethod.Properties.Items.Add(m);

            // Overtime Policy
            cmbOvertimePolicy.Properties.Items.Clear();
            foreach (OvertimePolicy p in Enum.GetValues(typeof(OvertimePolicy)))
                cmbOvertimePolicy.Properties.Items.Add(p);
        }

        private void LoadSettings()
        {
            entity = db.DcAttendanceSettings.FirstOrDefault() ?? new DcAttendanceSetting { Id = 1 };

            chkAttendanceEnabled.Checked = entity.AttendanceEnabled;
            lkpDefaultSchedule.EditValue = entity.DefaultWorkScheduleId;
            cmbAttendanceMethod.SelectedItem = entity.AttendanceMethod;
            spDebounceMinutes.Value = entity.DebounceMinutes;
            chkRequireApproval.Checked = entity.RequireApproval;
            chkAllowManualEntry.Checked = entity.AllowManualEntry;
            chkAllowAttendanceCorrection.Checked = entity.AllowAttendanceCorrection;
            chkAutoCalculate.Checked = entity.AutoCalculateAttendance;
            chkAutoCloseDay.Checked = entity.AutoCloseDay;

            spGracePeriod.Value = entity.GracePeriodMinutes;
            cmbLateCalculationMethod.SelectedItem = entity.LateCalculationMethod;
            cmbLateRoundingMethod.SelectedItem = entity.LateRoundingMethod;
            chkAllowLateCorrection.Checked = entity.AllowLateCorrection;
            chkLateApprovalRequired.Checked = entity.LateApprovalRequired;

            spEarlyExitGracePeriod.Value = entity.EarlyExitGracePeriodMinutes;
            cmbOvertimePolicy.SelectedItem = entity.OvertimePolicy;
            spMinOvertimeMinutes.Value = entity.MinOvertimeMinutes;
            spOvertimeRoundingMinutes.Value = entity.OvertimeRoundingMinutes;

            chkNotifyHrOnLate.Checked = entity.NotifyHrOnLate;
            chkNotifyManagerOnAbsence.Checked = entity.NotifyManagerOnAbsence;
            chkNotifyOnMissingCheckOut.Checked = entity.NotifyOnMissingCheckOut;
        }

        private void SaveSettings()
        {
            entity.AttendanceEnabled = chkAttendanceEnabled.Checked;
            entity.DefaultWorkScheduleId = lkpDefaultSchedule.EditValue is Guid g ? g : null;
            entity.AttendanceMethod = cmbAttendanceMethod.SelectedItem is AttendanceMethod am ? am : AttendanceMethod.Both;
            entity.DebounceMinutes = (int)spDebounceMinutes.Value;
            entity.RequireApproval = chkRequireApproval.Checked;
            entity.AllowManualEntry = chkAllowManualEntry.Checked;
            entity.AllowAttendanceCorrection = chkAllowAttendanceCorrection.Checked;
            entity.AutoCalculateAttendance = chkAutoCalculate.Checked;
            entity.AutoCloseDay = chkAutoCloseDay.Checked;

            entity.GracePeriodMinutes = (int)spGracePeriod.Value;
            entity.LateCalculationMethod = cmbLateCalculationMethod.SelectedItem is LateCalculationMethod lm ? lm : LateCalculationMethod.Actual;
            entity.LateRoundingMethod = cmbLateRoundingMethod.SelectedItem is LateRoundingMethod lr ? lr : LateRoundingMethod.None;
            entity.AllowLateCorrection = chkAllowLateCorrection.Checked;
            entity.LateApprovalRequired = chkLateApprovalRequired.Checked;

            entity.EarlyExitGracePeriodMinutes = (int)spEarlyExitGracePeriod.Value;
            entity.OvertimePolicy = cmbOvertimePolicy.SelectedItem is OvertimePolicy op ? op : OvertimePolicy.Auto;
            entity.MinOvertimeMinutes = (int)spMinOvertimeMinutes.Value;
            entity.OvertimeRoundingMinutes = (int)spOvertimeRoundingMinutes.Value;

            entity.NotifyHrOnLate = chkNotifyHrOnLate.Checked;
            entity.NotifyManagerOnAbsence = chkNotifyManagerOnAbsence.Checked;
            entity.NotifyOnMissingCheckOut = chkNotifyOnMissingCheckOut.Checked;

            if (db.Entry(entity).State == EntityState.Detached)
                db.DcAttendanceSettings.Add(entity);

            db.SaveChanges();

            XtraMessageBox.Show(this, "Davamiyyət ayarları uğurla yadda saxlanıldı.", Properties.Resources.Common_Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
