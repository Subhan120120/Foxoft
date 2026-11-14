using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
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
        private readonly AttendanceConfigStore configStore = new();
        private DcAttendanceSetting entity;

        public FormAttendanceSettings()
        {
            InitializeComponent();

            InitDropdowns();
            InitStoreDropdown();
            LoadSettings();
            LoadDeviceLocks();

            lkpRuleStore.EditValueChanged += (_, __) => LoadStoreRule();
            btnSaveStoreRule.Click += (_, __) => SaveStoreRule();
            btnRefreshDevices.Click += (_, __) => LoadDeviceLocks();
            repoBtnUnlock.ButtonClick += RepoBtnUnlock_ButtonClick;

            btnSave.Click += (_, __) => SaveSettings();
            btnCancel.Click += (_, __) => Close();
        }

        private void InitStoreDropdown()
        {
            var stores = db.DcCurrAccs.AsNoTracking()
                .Where(x => !x.IsDisabled && x.CurrAccTypeCode == CurrAccType.Store)
                .OrderBy(x => x.CurrAccCode)
                .Select(x => new { x.CurrAccCode, StoreName = x.CurrAccCode + " - " + x.CurrAccDesc })
                .ToList();

            lkpRuleStore.Properties.DataSource = stores;
            lkpRuleStore.Properties.DisplayMember = "StoreName";
            lkpRuleStore.Properties.ValueMember = "CurrAccCode";

            if (stores.Any())
            {
                lkpRuleStore.EditValue = stores.First().CurrAccCode;
                LoadStoreRule();
            }
        }

        private void LoadStoreRule()
        {
            string? storeCode = lkpRuleStore.EditValue as string;
            if (string.IsNullOrEmpty(storeCode))
            {
                spRuleLat.Value = 0;
                spRuleLon.Value = 0;
                spRuleRadius.Value = 0;
                txtRuleIps.Text = string.Empty;
                chkStoreEnforceWifi.Checked = false;
                return;
            }

            var rule = configStore.GetStoreRule(storeCode, lkpRuleStore.Text);
            spRuleLat.Value = (decimal)rule.Latitude;
            spRuleLon.Value = (decimal)rule.Longitude;
            spRuleRadius.Value = (decimal)rule.AllowedRadiusMeters;
            txtRuleIps.Text = rule.AllowedWifiIps != null ? string.Join(", ", rule.AllowedWifiIps) : string.Empty;
            chkStoreEnforceWifi.Checked = rule.EnforceWifiIp;
        }

        private void SaveStoreRule()
        {
            string? storeCode = lkpRuleStore.EditValue as string;
            if (string.IsNullOrEmpty(storeCode))
                return;

            var ipList = (txtRuleIps.Text ?? string.Empty)
                .Split(new[] { ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .ToList();

            var rule = new StoreAttendanceRule
            {
                StoreCode = storeCode,
                StoreName = lkpRuleStore.Text,
                Latitude = (double)spRuleLat.Value,
                Longitude = (double)spRuleLon.Value,
                AllowedRadiusMeters = (double)spRuleRadius.Value,
                AllowedWifiIps = ipList,
                EnforceQr = true,
                EnforceWifiIp = chkStoreEnforceWifi.Checked,
                EnforceGps = true,
                EnforceDeviceLock = true
            };

            configStore.SaveStoreRule(rule);

            XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceSettings_SaveSuccess, Properties.Resources.Common_Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadDeviceLocks()
        {
            var locks = configStore.GetAllDeviceLocks();
            gcDeviceLocks.DataSource = locks;
        }

        private void RepoBtnUnlock_ButtonClick(object? sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gvDeviceLocks.FocusedRowHandle;
            if (rowHandle < 0)
                return;

            if (gvDeviceLocks.GetRow(rowHandle) is not EmployeeDeviceLock deviceLock)
                return;

            string displayName = !string.IsNullOrWhiteSpace(deviceLock.EmployeeName)
                ? deviceLock.EmployeeName
                : deviceLock.CurrAccCode;

            string confirmMessage = string.Format(
                Properties.Resources.Form_AttendanceSettings_ResetDeviceConfirm,
                displayName);

            if (XtraMessageBox.Show(this, confirmMessage, Properties.Resources.Form_AttendanceSettings_ResetDeviceLock,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = configStore.UnlockDevice(deviceLock.CurrAccCode);
                if (success)
                {
                    XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceSettings_DeviceUnlocked,
                        Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeviceLocks();
                }
            }
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
            chkAutoFloatingRestDay.Checked = entity.AutoFloatingRestDayEnabled;
            spMaxWeeklyRestDays.Value = entity.MaxWeeklyRestDays;

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

            chkRequireDynamicQrCode.Checked = entity.RequireDynamicQrCode;
            chkRequireGpsGeofencing.Checked = entity.RequireGpsGeofencing;
            chkRequireDeviceLock.Checked = entity.RequireDeviceLock;
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
            entity.AutoFloatingRestDayEnabled = chkAutoFloatingRestDay.Checked;
            entity.MaxWeeklyRestDays = (int)spMaxWeeklyRestDays.Value;

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

            entity.RequireDynamicQrCode = chkRequireDynamicQrCode.Checked;
            entity.RequireGpsGeofencing = chkRequireGpsGeofencing.Checked;
            entity.RequireDeviceLock = chkRequireDeviceLock.Checked;

            if (db.Entry(entity).State == EntityState.Detached)
                db.DcAttendanceSettings.Add(entity);

            db.SaveChanges();

            XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceSettings_SaveSuccess, Properties.Resources.Common_Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
