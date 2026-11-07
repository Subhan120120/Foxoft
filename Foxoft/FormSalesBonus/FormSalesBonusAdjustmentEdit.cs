using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    /// <summary>Manual bonus düzəlişi (+/-): jurnala Adjust növlü sətir yazır. Qeyd məcburidir (audit).</summary>
    public partial class FormSalesBonusAdjustmentEdit : XtraForm
    {
        private readonly string? initialSalesPersonCode;

        public FormSalesBonusAdjustmentEdit(string? salesPersonCode)
        {
            InitializeComponent();
            initialSalesPersonCode = salesPersonCode;

            dtDate.DateTime = DateTime.Today;

            btnSalesPerson.ButtonClick += BtnSalesPerson_ButtonClick;
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadLookups();
        }

        private void BtnSalesPerson_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList form = new(new byte[] { (byte)CurrAccType.Personnel }, false, btnSalesPerson.EditValue?.ToString());
            if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
            {
                btnSalesPerson.EditValue = form.dcCurrAcc.CurrAccCode;
                txtSalesPersonName.Text = EmployeeName(form.dcCurrAcc);
            }
        }

        private static string EmployeeName(DcCurrAcc emp)
        {
            string name = $"{emp.FirstName} {emp.LastName}".Trim();
            return string.IsNullOrWhiteSpace(name) ? (emp.CurrAccDesc ?? string.Empty) : name;
        }

        private void LoadLookups()
        {
            using var db = new subContext();
            lkpPlan.Properties.DataSource = db.DcSalesBonusPlans.AsNoTracking()
                .OrderByDescending(x => x.IsActive)
                .ThenBy(x => x.PlanName)
                .Select(x => new { x.SalesBonusPlanId, x.PlanName })
                .ToList();

            if (!string.IsNullOrWhiteSpace(initialSalesPersonCode))
            {
                btnSalesPerson.EditValue = initialSalesPersonCode;
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == initialSalesPersonCode);
                if (emp != null)
                    txtSalesPersonName.Text = EmployeeName(emp);
            }
        }

        private void Save()
        {
            string? salesPersonCode = btnSalesPerson.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(salesPersonCode))
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lkpPlan.EditValue is not Guid planId)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_SalesBonusAssignment_PlanId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal amount = Math.Round(spinAmount.Value, 2);
            if (amount == 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusAdjustment_AmountRequired, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string note = txtNote.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(note))
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusAdjustment_NoteRequired, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                new SalesBonusService().AddAdjustment(salesPersonCode, planId, dtDate.DateTime.Date, amount, note, Authorization.CurrAccCode);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
