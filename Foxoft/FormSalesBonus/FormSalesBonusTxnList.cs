using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using static Foxoft.AppCode.Service.SalesBonusCalculator;

namespace Foxoft
{
    public partial class FormSalesBonusTxnList : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private bool canCalculate;

        public FormSalesBonusTxnList()
        {
            InitializeComponent();

            canCalculate = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "SalesBonusCalculate");
            btnCalculate.Enabled = canCalculate;
            btnAdjustment.Enabled = canCalculate;

            DateTime today = DateTime.Today;
            dtFrom.DateTime = new DateTime(today.Year, today.Month, 1);
            dtTo.DateTime = dtFrom.DateTime.AddMonths(1).AddDays(-1);

            btnSalesPerson.ButtonClick += BtnSalesPerson_ButtonClick;
            lkpPlan.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == ButtonPredefines.Delete)
                    lkpPlan.EditValue = null;
            };

            btnRefresh.ItemClick += (_, __) => LoadData();
            btnCalculate.ItemClick += (_, __) => OpenCalculate();
            btnAdjustment.ItemClick += (_, __) => OpenAdjustment();
            btnDetails.ItemClick += (_, __) => ShowDetails();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => ShowDetails();
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            Load += (_, __) =>
            {
                LoadPlans();
                LoadData();
            };
        }

        private void BtnSalesPerson_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                btnSalesPerson.EditValue = null;
                return;
            }

            FormCurrAccList form = new(new byte[] { (byte)CurrAccType.Personnel }, false, btnSalesPerson.EditValue?.ToString());
            if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
                btnSalesPerson.EditValue = form.dcCurrAcc.CurrAccCode;
        }

        private void LoadPlans()
        {
            using var db = new subContext();
            lkpPlan.Properties.DataSource = db.DcSalesBonusPlans.AsNoTracking()
                .OrderBy(x => x.PlanName)
                .Select(x => new { x.SalesBonusPlanId, x.PlanName })
                .ToList();
        }

        private void LoadData()
        {
            using var db = new subContext();

            DateTime from = dtFrom.EditValue == null ? DateTime.MinValue : dtFrom.DateTime.Date;
            DateTime to = dtTo.EditValue == null ? DateTime.MaxValue.Date : dtTo.DateTime.Date;
            string? salesPersonCode = btnSalesPerson.EditValue?.ToString();
            Guid? planId = lkpPlan.EditValue is Guid g ? g : null;
            bool onlyPending = chkOnlyPending.Checked;

            IQueryable<TrSalesBonusTxn> q = db.TrSalesBonusTxns.AsNoTracking()
                .Include(x => x.DcSalesBonusPlan)
                .Include(x => x.DcCurrAcc)
                .Where(x => x.DocumentDate >= from && x.DocumentDate <= to);

            if (!string.IsNullOrWhiteSpace(salesPersonCode))
                q = q.Where(x => x.SalesPersonCode == salesPersonCode);
            if (planId.HasValue)
                q = q.Where(x => x.SalesBonusPlanId == planId.Value);
            if (onlyPending)
                q = q.Where(x => x.PayrollHeaderId == null);

            var list = q.OrderByDescending(x => x.DocumentDate)
                .ThenByDescending(x => x.CreatedDate)
                .ToList()
                .Select(x => new
                {
                    Id = x.SalesBonusTxnId,
                    x.DocumentDate,
                    TxnTypeText = SalesBonusTexts.Text(x.TxnType),
                    x.SalesPersonCode,
                    SalesPersonName = EmployeeName(x.DcCurrAcc),
                    PlanName = x.DcSalesBonusPlan?.PlanName,
                    PeriodText = PeriodText(x.PeriodYear, x.PeriodNo, x.DcSalesBonusPlan?.PeriodType ?? BonusPeriodType.Monthly),
                    x.BaseAmount,
                    x.Rate,
                    x.Amount,
                    x.InvoiceDocumentNumber,
                    x.PaymentDocumentNumber,
                    PayrollStatusText = x.PayrollHeaderId.HasValue
                        ? Properties.Resources.Entity_SalesBonusTxn_PayrollIncluded
                        : Properties.Resources.Entity_SalesBonusTxn_PayrollPending,
                    x.Note,
                    x.CreatedUserName,
                    x.CreatedDate,
                    x.CalcDetails
                })
                .ToList();

            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
        }

        private static string EmployeeName(DcCurrAcc? emp)
        {
            if (emp == null) return string.Empty;
            string name = $"{emp.FirstName} {emp.LastName}".Trim();
            return string.IsNullOrWhiteSpace(name) ? (emp.CurrAccDesc ?? string.Empty) : name;
        }

        private void OpenCalculate()
        {
            if (!canCalculate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Common_NoPermission, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var f = new FormSalesBonusCalc();
            f.ShowDialog(this);
            LoadData();
        }

        private void OpenAdjustment()
        {
            if (!canCalculate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Common_NoPermission, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var f = new FormSalesBonusAdjustmentEdit(btnSalesPerson.EditValue?.ToString());
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void ShowDetails()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return;

            string? details = row.GetType().GetProperty("CalcDetails")?.GetValue(row)?.ToString();
            string? note = row.GetType().GetProperty("Note")?.GetValue(row)?.ToString();

            using var f = new FormSalesBonusTxnDetails(note, details);
            f.ShowDialog(this);
        }
    }
}
