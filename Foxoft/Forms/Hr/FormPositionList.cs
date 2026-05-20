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
    public partial class FormPositionList : RibbonForm
    {
        private readonly subContext db = new();

        public FormPositionList()
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
            var list = db.DcPositions.AsNoTracking()
                .OrderBy(x => x.PositionCode)
                .Select(x => new
                {
                    x.Id,
                    x.PositionCode, x.PositionName, x.IsActive
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["PositionCode"] != null) gridView1.Columns["PositionCode"].Caption = Properties.Resources.Entity_DcPosition_PositionCode;
            if (gridView1.Columns["PositionName"] != null) gridView1.Columns["PositionName"].Caption = Properties.Resources.Entity_DcPosition_PositionName;
            if (gridView1.Columns["IsActive"] != null) gridView1.Columns["IsActive"].Caption = Properties.Resources.Entity_DcPosition_IsActive;

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
            using var f = new FormPositionEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormPositionEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_PositionList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcPositions.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            db.DcPositions.Remove(entity);
            db.SaveChanges();
            LoadData();
        }
    }
}
