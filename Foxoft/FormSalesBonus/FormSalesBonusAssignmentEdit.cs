using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormSalesBonusAssignmentEdit : XtraForm
    {
        private readonly Guid? id;
        private TrSalesBonusAssignment entity = null!;

        public FormSalesBonusAssignmentEdit(Guid? assignmentId)
        {
            InitializeComponent();
            id = assignmentId;

            Text = id == null ? Properties.Resources.Form_SalesBonusAssignmentEdit_Caption_New : Properties.Resources.Form_SalesBonusAssignmentEdit_Caption_Edit;

            btnSalesPerson.ButtonClick += BtnSalesPerson_ButtonClick;
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
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

        private void LoadEntity()
        {
            using var db = new subContext();

            lkpPlan.Properties.DataSource = db.DcSalesBonusPlans.AsNoTracking()
                .Where(x => x.IsActive || (id != null && x.Assignments.Any(a => a.SalesBonusAssignmentId == id.Value)))
                .OrderBy(x => x.PlanName)
                .ToList()
                .Select(x => new
                {
                    x.SalesBonusPlanId,
                    x.PlanName,
                    CalcMethodText = SalesBonusTexts.Text(x.CalcMethod),
                    TriggerTypeText = SalesBonusTexts.Text(x.TriggerType)
                })
                .ToList();

            if (id == null)
            {
                entity = new TrSalesBonusAssignment
                {
                    SalesBonusAssignmentId = Guid.NewGuid(),
                    StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                };
            }
            else
            {
                entity = db.TrSalesBonusAssignments.AsNoTracking().First(x => x.SalesBonusAssignmentId == id.Value);
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.SalesPersonCode);
                if (emp != null)
                    txtSalesPersonName.Text = EmployeeName(emp);
            }

            btnSalesPerson.EditValue = string.IsNullOrEmpty(entity.SalesPersonCode) ? null : entity.SalesPersonCode;
            lkpPlan.EditValue = entity.SalesBonusPlanId == Guid.Empty ? null : (Guid?)entity.SalesBonusPlanId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
            spinTargetAmount.EditValue = entity.TargetAmount;
            chkIsActive.Checked = entity.IsActive;
            txtNote.Text = entity.Note;
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

            entity.SalesPersonCode = salesPersonCode;
            entity.SalesBonusPlanId = planId;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;
            entity.TargetAmount = spinTargetAmount.EditValue == null || spinTargetAmount.EditValue == DBNull.Value
                ? null
                : Convert.ToDecimal(spinTargetAmount.EditValue);
            entity.IsActive = chkIsActive.Checked;
            entity.Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

            if (entity.EndDate != null && entity.EndDate < entity.StartDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new subContext();

                // Eyni plan + satıcı üçün üst-üstə düşən aktiv təyinat olmamalıdır.
                DateTime start = entity.StartDate;
                DateTime end = entity.EndDate ?? DateTime.MaxValue.Date;
                bool overlap = db.TrSalesBonusAssignments.Any(x =>
                    x.SalesBonusAssignmentId != entity.SalesBonusAssignmentId
                    && x.SalesBonusPlanId == planId
                    && x.SalesPersonCode == salesPersonCode
                    && x.IsActive
                    && x.StartDate <= end
                    && (x.EndDate == null || x.EndDate >= start));

                if (entity.IsActive && overlap)
                {
                    XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusAssignmentEdit_Overlap, Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (id == null)
                {
                    entity.CreatedUserName = Authorization.CurrAccCode;
                    entity.CreatedDate = DateTime.Now;
                    entity.LastUpdatedUserName = Authorization.CurrAccCode;
                    entity.LastUpdatedDate = DateTime.Now;
                    db.TrSalesBonusAssignments.Add(entity);
                }
                else
                {
                    var target = db.TrSalesBonusAssignments.First(x => x.SalesBonusAssignmentId == id.Value);
                    target.SalesPersonCode = entity.SalesPersonCode;
                    target.SalesBonusPlanId = entity.SalesBonusPlanId;
                    target.StartDate = entity.StartDate;
                    target.EndDate = entity.EndDate;
                    target.TargetAmount = entity.TargetAmount;
                    target.IsActive = entity.IsActive;
                    target.Note = entity.Note;
                    target.LastUpdatedUserName = Authorization.CurrAccCode;
                    target.LastUpdatedDate = DateTime.Now;
                }

                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
