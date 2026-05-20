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
    public partial class FormEmployeePositionList : RibbonForm
    {
        private readonly subContext db = new();

        public FormEmployeePositionList()
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
            var list = db.TrEmployeePositions.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.Position)
                .OrderBy(x => x.CurrAccCode)
                .Select(x => new
                {
                    x.Id,
                    x.CurrAccCode,
                    EmployeeName = (x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName).Trim(),
                    PositionName = x.Position != null ? x.Position.PositionName : "",
                    x.StartDate,
                    x.EndDate
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_TrEmployeePosition_CurrAccCode;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["PositionName"] != null) gridView1.Columns["PositionName"].Caption = Properties.Resources.Entity_TrEmployeePosition_PositionId;
            if (gridView1.Columns["StartDate"] != null) gridView1.Columns["StartDate"].Caption = Properties.Resources.Entity_TrEmployeePosition_StartDate;
            if (gridView1.Columns["EndDate"] != null) gridView1.Columns["EndDate"].Caption = Properties.Resources.Entity_TrEmployeePosition_EndDate;

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
            using var f = new FormEmployeePositionEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormEmployeePositionEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_EmployeePositionList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.TrEmployeePositions.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            db.TrEmployeePositions.Remove(entity);
            db.SaveChanges();
            LoadData();
        }
    }
}
