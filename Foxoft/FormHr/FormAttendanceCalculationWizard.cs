using DevExpress.XtraEditors;
using DevExpress.XtraWizard;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormAttendanceCalculationWizard : XtraForm
    {
        private readonly subContext db = new();
        private readonly AttendanceCalculationService calcService = new();
        private AttendanceCalculationResult? lastResult;

        public FormAttendanceCalculationWizard()
        {
            InitializeComponent();

            InitControls();

            wizardControl1.SelectedPageChanging += WizardControl1_SelectedPageChanging;
            wizardControl1.FinishClick += WizardControl1_FinishClick;
            wizardControl1.CancelClick += (_, __) => Close();
        }

        private void InitControls()
        {
            var now = DateTime.Today;
            dtFrom.DateTime = new DateTime(now.Year, now.Month, 1);
            dtTo.DateTime = dtFrom.DateTime.AddMonths(1).AddDays(-1);

            // Stores
            var stores = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Store)
                .Select(x => new { x.CurrAccCode, x.CurrAccDesc })
                .ToList();
            lkpStore.Properties.DataSource = stores;
            lkpStore.Properties.DisplayMember = "CurrAccDesc";
            lkpStore.Properties.ValueMember = "CurrAccCode";

            // Departments
            var depts = db.DcDepartments.AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new { x.Id, x.DepartmentName })
                .ToList();
            lkpDepartment.Properties.DataSource = depts;
            lkpDepartment.Properties.DisplayMember = "DepartmentName";
            lkpDepartment.Properties.ValueMember = "Id";

            // Settings
            var settings = db.DcAttendanceSettings.FirstOrDefault() ?? new DcAttendanceSetting();
            spGracePeriod.Value = settings.GracePeriodMinutes;
            spDebounce.Value = settings.DebounceMinutes;

            cmbLateMethod.Properties.Items.Clear();
            cmbLateMethod.Properties.Items.Add(LateCalculationMethod.Actual);
            cmbLateMethod.Properties.Items.Add(LateCalculationMethod.AfterGrace);
            cmbLateMethod.SelectedItem = settings.LateCalculationMethod;

            cmbOvertimePolicy.Properties.Items.Clear();
            cmbOvertimePolicy.Properties.Items.Add(OvertimePolicy.Auto);
            cmbOvertimePolicy.Properties.Items.Add(OvertimePolicy.PreApproved);
            cmbOvertimePolicy.SelectedItem = settings.OvertimePolicy;

            cmbLateMethod.SelectedIndexChanged += (_, __) => UpdateHelpDescriptions();
            spGracePeriod.ValueChanged += (_, __) => UpdateHelpDescriptions();
            cmbOvertimePolicy.SelectedIndexChanged += (_, __) => UpdateHelpDescriptions();
            spDebounce.ValueChanged += (_, __) => UpdateHelpDescriptions();

            UpdateHelpDescriptions();
        }

        private void UpdateHelpDescriptions()
        {
            int grace = (int)spGracePeriod.Value;
            int debounce = (int)spDebounce.Value;

            // Late Method explanation
            if (cmbLateMethod.SelectedItem is LateCalculationMethod lm && lm == LateCalculationMethod.AfterGrace)
            {
                int sampleLate = 2;
                lblLateMethodDesc.Text = string.Format(Properties.Resources.Form_AttendanceWizard_LateAfterGraceDesc, grace, sampleLate);
            }
            else
            {
                int sampleLate = Math.Max(7, grace + 2);
                lblLateMethodDesc.Text = string.Format(Properties.Resources.Form_AttendanceWizard_LateActualDesc, grace, sampleLate);
            }

            // Overtime Policy explanation
            if (cmbOvertimePolicy.SelectedItem is OvertimePolicy op && op == OvertimePolicy.PreApproved)
            {
                lblOvertimePolicyDesc.Text = Properties.Resources.Form_AttendanceWizard_OTPreApprovedDesc;
            }
            else
            {
                lblOvertimePolicyDesc.Text = Properties.Resources.Form_AttendanceWizard_OTAutoDesc;
            }

            // General help (Grace & Debounce)
            lblGeneralHelpDesc.Text = string.Format(Properties.Resources.Form_AttendanceWizard_GeneralHelpDesc, grace, debounce);
        }

        private void WizardControl1_SelectedPageChanging(object sender, WizardPageChangingEventArgs e)
        {
            // Validations before leaving filter page
            if (e.PrevPage == wizardPageDateFilter && e.Direction == Direction.Forward)
            {
                if (dtFrom.DateTime > dtTo.DateTime)
                {
                    XtraMessageBox.Show(this, "Başlanğıc tarixi bitmə tarixindən böyük ola bilməz.", Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            // Entering preview page: calculate and display
            if (e.Page == wizardPagePreview)
            {
                RunPreviewCalculation();
            }
        }

        private void RunPreviewCalculation()
        {
            var customSettings = new DcAttendanceSetting
            {
                GracePeriodMinutes = (int)spGracePeriod.Value,
                DebounceMinutes = (int)spDebounce.Value,
                LateCalculationMethod = cmbLateMethod.SelectedItem is LateCalculationMethod lm ? lm : LateCalculationMethod.Actual,
                OvertimePolicy = cmbOvertimePolicy.SelectedItem is OvertimePolicy op ? op : OvertimePolicy.Auto
            };

            string? storeCode = lkpStore.EditValue?.ToString();
            Guid? deptId = lkpDepartment.EditValue is Guid g ? g : null;

            // In-memory calculation for preview
            lastResult = calcService.CalculateAttendance(
                dtFrom.DateTime.Date,
                dtTo.DateTime.Date,
                storeCode,
                deptId,
                null,
                customSettings,
                false // preview only, don't save yet
            );

            lblSummary.Text = $"Ümumi Qeydlər: {lastResult.TotalProcessedRecords}  |  İşdə: {lastResult.PresentCount}  |  Gecikmə: {lastResult.LateCount}  |  Üzrsüz: {lastResult.UnexcusedAbsenceCount}  |  İcazəli: {lastResult.ExcusedAbsenceCount}  |  Əlavə İş: {Math.Round(lastResult.TotalOvertimeMinutes / 60.0, 1)} saat";

            var previewVMs = lastResult.ProcessedAttendances.Select(a => new
            {
                a.CurrAccCode,
                WorkDate = a.WorkDate.ToString("yyyy-MM-dd"),
                CheckIn = a.CheckInTime?.ToString("HH:mm") ?? "-",
                CheckOut = a.CheckOutTime?.ToString("HH:mm") ?? "-",
                WorkedHours = Math.Round((decimal)a.WorkedMinutes / 60.0m, 2),
                LateMinutes = a.LateMinutes,
                EarlyExitMinutes = a.EarlyExitMinutes,
                OvertimeMinutes = a.ApprovedOvertimeMinutes,
                Status = a.AttendanceStatus.ToString()
            }).ToList();

            gridPreview.DataSource = previewVMs;
            gridViewPreview.BestFitColumns();
        }

        private void WizardControl1_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var customSettings = new DcAttendanceSetting
            {
                GracePeriodMinutes = (int)spGracePeriod.Value,
                DebounceMinutes = (int)spDebounce.Value,
                LateCalculationMethod = cmbLateMethod.SelectedItem is LateCalculationMethod lm ? lm : LateCalculationMethod.Actual,
                OvertimePolicy = cmbOvertimePolicy.SelectedItem is OvertimePolicy op ? op : OvertimePolicy.Auto
            };

            string? storeCode = lkpStore.EditValue?.ToString();
            Guid? deptId = lkpDepartment.EditValue is Guid g ? g : null;

            // Final save calculation to database
            calcService.CalculateAttendance(
                dtFrom.DateTime.Date,
                dtTo.DateTime.Date,
                storeCode,
                deptId,
                null,
                customSettings,
                true // commit to database
            );

            // Generate monthly timesheet if requested
            if (chkGenerateTimesheet.Checked)
            {
                for (var cur = new DateTime(dtFrom.DateTime.Year, dtFrom.DateTime.Month, 1);
                     cur <= dtTo.DateTime;
                     cur = cur.AddMonths(1))
                {
                    calcService.GenerateMonthlyTimesheet(cur.Year, cur.Month, storeCode, true);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
