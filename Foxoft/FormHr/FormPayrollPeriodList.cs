using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayrollPeriodList : RibbonForm
    {
        private readonly subContext db = new();

        public FormPayrollPeriodList()
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
            var list = db.DcPayrollPeriods.AsNoTracking()
                .OrderBy(x => x.PeriodYear)
                .Select(x => new
                {
                    x.Id,
                    x.PeriodYear, x.PeriodMonth, x.IsClosed
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["PeriodYear"] != null) gridView1.Columns["PeriodYear"].Caption = Properties.Resources.Entity_TrPayrollPeriod_StartDate + " (Year)";
            if (gridView1.Columns["PeriodMonth"] != null) gridView1.Columns["PeriodMonth"].Caption = Properties.Resources.Entity_TrPayrollPeriod_StartDate + " (Month)";
            if (gridView1.Columns["IsClosed"] != null) gridView1.Columns["IsClosed"].Caption = Properties.Resources.Entity_TrPayrollPeriod_IsClosed;

            gridView1.BestFitColumns();
        }

        public Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormPayrollPeriodEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormPayrollPeriodEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_PayrollPeriodList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcPayrollPeriods.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            db.DcPayrollPeriods.Remove(entity);
            db.SaveChanges();
            LoadData();
        }
    }
}
