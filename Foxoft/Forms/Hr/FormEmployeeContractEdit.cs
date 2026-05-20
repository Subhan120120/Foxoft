using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmployeeContractEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrEmployeeContract entity;

        public FormEmployeeContractEdit(Guid? contractId)
        {
            InitializeComponent();
            id = contractId;

            Text = id == null ? Properties.Resources.Form_EmployeeContractEdit_Caption_New : Properties.Resources.Form_EmployeeContractEdit_Caption_Edit;

            btnEmployee.ButtonClick += BtnEmployee_ButtonClick;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void BtnEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
                txtEmployeeName.Text = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
            }
        }

        private void LoadEntity()
        {
            var types = db.DcEmploymentTypes.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.TypeCode)
                .Select(x => new { x.Id, x.TypeCode, x.TypeName })
                .ToList();

            lkpType.Properties.DataSource = types;

            var currencies = db.DcCurrencies.AsNoTracking()
                .OrderBy(x => x.CurrencyCode)
                .Select(x => new { x.CurrencyCode, x.CurrencyDesc })
                .ToList();

            lkpCurrency.Properties.DataSource = currencies;

            if (id == null)
            {
                entity = new TrEmployeeContract
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Today,
                    BaseSalary = 0
                };
            }
            else
            {
                entity = db.TrEmployeeContracts.First(x => x.Id == id.Value);
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    txtEmployeeName.Text = $"{emp.FirstName} {emp.LastName}".Trim();
                }
            }

            btnEmployee.EditValue = entity.CurrAccCode;
            lkpType.EditValue = entity.EmploymentTypeId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
            calcSalary.EditValue = entity.BaseSalary;
            lkpCurrency.EditValue = entity.CurrencyCode;
        }

        private void Save()
        {
            if (btnEmployee.EditValue == null || string.IsNullOrWhiteSpace(btnEmployee.EditValue.ToString()))
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeeContract_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpType.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeeContract_EmploymentTypeId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = btnEmployee.EditValue?.ToString();
            entity.EmploymentTypeId = (Guid)lkpType.EditValue;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;
            entity.BaseSalary = calcSalary.Value;
            entity.CurrencyCode = lkpCurrency.EditValue?.ToString();

            if (entity.EndDate != null && entity.EndDate < entity.StartDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.TrEmployeeContracts.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
