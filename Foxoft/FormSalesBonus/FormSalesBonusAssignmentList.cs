using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormSalesBonusAssignmentList : RibbonForm
    {
        public FormSalesBonusAssignmentList()
        {
            InitializeComponent();
            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnBatchAssign.ItemClick += (_, __) => BatchAssign();
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

            var list = db.TrSalesBonusAssignments.AsNoTracking()
                .Include(x => x.DcSalesBonusPlan)
                .Include(x => x.DcCurrAcc)
                .OrderByDescending(x => x.IsActive)
                .ThenBy(x => x.SalesPersonCode)
                .ThenByDescending(x => x.StartDate)
                .ToList()
                .Select(x => new
                {
                    Id = x.SalesBonusAssignmentId,
                    SalesBonusPlanId = x.SalesBonusPlanId,
                    x.SalesPersonCode,
                    SalesPersonName = EmployeeName(x.DcCurrAcc),
                    PlanName = x.DcSalesBonusPlan?.PlanName,
                    CalcMethodText = x.DcSalesBonusPlan == null ? string.Empty : SalesBonusTexts.Text(x.DcSalesBonusPlan.CalcMethod),
                    x.StartDate,
                    x.EndDate,
                    x.TargetAmount,
                    x.IsActive,
                    x.Note
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

        private Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private Guid? FocusedPlanId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("SalesBonusPlanId");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormSalesBonusAssignmentEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void BatchAssign()
        {
            Guid? planId = FocusedPlanId();
            using var f = new FormSalesBonusBatchAssign(planId);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormSalesBonusAssignmentEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var selectedRows = gridView1.GetSelectedRows();
            var ids = new List<Guid>();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                foreach (int handle in selectedRows)
                {
                    if (handle >= 0)
                    {
                        var row = gridView1.GetRow(handle);
                        if (row != null)
                        {
                            var prop = row.GetType().GetProperty("Id");
                            if (prop?.GetValue(row) is Guid id)
                                ids.Add(id);
                        }
                    }
                }
            }

            if (ids.Count == 0)
            {
                var id = FocusedId();
                if (id != null) ids.Add(id.Value);
            }

            if (ids.Count == 0) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusAssignmentList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using var db = new subContext();
                var entities = db.TrSalesBonusAssignments.Where(x => ids.Contains(x.SalesBonusAssignmentId)).ToList();
                if (entities.Count == 0) return;

                db.TrSalesBonusAssignments.RemoveRange(entities);
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
