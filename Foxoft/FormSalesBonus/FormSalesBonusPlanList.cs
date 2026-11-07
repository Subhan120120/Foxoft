using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormSalesBonusPlanList : RibbonForm
    {
        public FormSalesBonusPlanList()
        {
            InitializeComponent();
            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => EditItem();
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        private void LoadData()
        {
            using var db = new subContext();

            var list = db.DcSalesBonusPlans.AsNoTracking()
                .OrderByDescending(x => x.IsActive)
                .ThenBy(x => x.PlanName)
                .Select(x => new
                {
                    x.SalesBonusPlanId,
                    x.PlanName,
                    x.CalcMethod,
                    x.TriggerType,
                    x.PeriodType,
                    x.Rate,
                    x.FixedAmount,
                    x.IsActive,
                    x.Description,
                    AssignmentCount = x.Assignments.Count(a => a.IsActive)
                })
                .ToList()
                .Select(x => new
                {
                    Id = x.SalesBonusPlanId,
                    x.PlanName,
                    CalcMethodText = SalesBonusTexts.Text(x.CalcMethod),
                    TriggerTypeText = SalesBonusTexts.Text(x.TriggerType),
                    PeriodTypeText = SalesBonusTexts.Text(x.PeriodType),
                    x.Rate,
                    x.FixedAmount,
                    x.IsActive,
                    x.AssignmentCount,
                    x.Description
                })
                .ToList();

            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
        }

        private Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormSalesBonusPlanEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormSalesBonusPlanEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var db = new subContext();

            // Jurnalda əməliyyatı olan plan silinmir (audit): deaktiv edilməlidir.
            if (db.TrSalesBonusTxns.Any(x => x.SalesBonusPlanId == id.Value))
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanList_HasTxns, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcSalesBonusPlans
                .Include(x => x.Assignments)
                .FirstOrDefault(x => x.SalesBonusPlanId == id.Value);
            if (entity == null) return;

            try
            {
                db.TrSalesBonusAssignments.RemoveRange(entity.Assignments);
                db.DcSalesBonusPlans.Remove(entity);
                db.SaveChanges();
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
