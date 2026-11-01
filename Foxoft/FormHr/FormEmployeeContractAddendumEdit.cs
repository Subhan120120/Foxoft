using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmployeeContractAddendumEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid contractId;
        private readonly Guid? id;
        private TrEmployeeContract contract = null!;
        private TrEmployeeContractAddendum entity = null!;

        public FormEmployeeContractAddendumEdit(Guid contractId, Guid? addendumId)
        {
            InitializeComponent();
            this.contractId = contractId;
            this.id = addendumId;

            Text = id == null
                ? Properties.Resources.Form_EmployeeContractAddendumEdit_Caption_New
                : Properties.Resources.Form_EmployeeContractAddendumEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            contract = db.TrEmployeeContracts
                .Include(c => c.DcCurrAcc)
                .First(c => c.Id == contractId);

            string empName = (!string.IsNullOrEmpty(contract.DcCurrAcc.CurrAccDesc)
                ? contract.DcCurrAcc.CurrAccDesc
                : $"{contract.DcCurrAcc.FirstName} {contract.DcCurrAcc.LastName}".Trim());

            string contractDisplay = string.IsNullOrEmpty(contract.ContractNumber)
                ? empName
                : $"{contract.ContractNumber} - {empName}";

            txtContractInfo.Text = contractDisplay;

            var currencies = db.DcCurrencies.AsNoTracking()
                .OrderBy(x => x.CurrencyCode)
                .Select(x => new { x.CurrencyCode, x.CurrencyDesc })
                .ToList();

            lkpCurrency.Properties.DataSource = currencies;

            if (id == null)
            {
                var latestAddendum = db.TrEmployeeContractAddenda
                    .Where(a => a.ContractId == contractId)
                    .OrderByDescending(a => a.StartDate)
                    .FirstOrDefault();

                decimal defaultSalary = latestAddendum?.BaseSalary ?? 0m;
                string defaultCurrency = latestAddendum?.CurrencyCode ?? Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

                entity = new TrEmployeeContractAddendum
                {
                    Id = Guid.NewGuid(),
                    ContractId = contractId,
                    StartDate = DateTime.Today,
                    BaseSalary = defaultSalary,
                    CurrencyCode = defaultCurrency
                };
            }
            else
            {
                entity = db.TrEmployeeContractAddenda.First(x => x.Id == id.Value);
            }

            txtAddendumNumber.Text = entity.AddendumNumber;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
            calcSalary.EditValue = entity.BaseSalary;
            lkpCurrency.EditValue = entity.CurrencyCode;
            txtDescription.Text = entity.Description;
        }

        private void Save()
        {
            if (dtStart.EditValue == null)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_AddendumStartDateRequired,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtStart.DateTime.Date;
            DateTime? endDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;

            if (endDate != null && endDate < startDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.AddendumNumber = txtAddendumNumber.Text?.Trim();
            entity.StartDate = startDate;
            entity.EndDate = endDate;
            entity.BaseSalary = calcSalary.Value;
            entity.CurrencyCode = lkpCurrency.EditValue?.ToString();
            entity.Description = txtDescription.Text?.Trim();

            if (id == null)
            {
                // Auto-close previous open-ended addenda before this startDate
                var previousOpenAddenda = db.TrEmployeeContractAddenda
                    .Where(a => a.ContractId == contractId && a.StartDate < startDate && (a.EndDate == null || a.EndDate >= startDate))
                    .ToList();

                DateTime autoCloseDate = startDate.AddDays(-1);
                foreach (var prev in previousOpenAddenda)
                {
                    prev.EndDate = autoCloseDate;
                }

                db.TrEmployeeContractAddenda.Add(entity);
            }
            else
            {
                db.Entry(entity).State = EntityState.Modified;
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            db.Dispose();
        }
    }
}
