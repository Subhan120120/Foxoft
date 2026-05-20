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
    public partial class FormDepartmentList : RibbonForm
    {
        private readonly subContext db = new();

        public FormDepartmentList()
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
            var list = db.DcDepartments.AsNoTracking()
                .OrderBy(x => x.DepartmentCode)
                .Select(x => new
                {
                    x.Id,
                    x.DepartmentCode,
                    x.DepartmentName,
                    x.ParentDepartmentId,
                    x.IsActive
                })
                .ToList();

            gridControl1.DataSource = list;
            
            if (gridView1.Columns["DepartmentCode"] != null) gridView1.Columns["DepartmentCode"].Caption = Properties.Resources.Entity_DcDepartment_DepartmentCode;
            if (gridView1.Columns["DepartmentName"] != null) gridView1.Columns["DepartmentName"].Caption = Properties.Resources.Entity_DcDepartment_DepartmentName;
            if (gridView1.Columns["ParentDepartmentId"] != null) gridView1.Columns["ParentDepartmentId"].Caption = Properties.Resources.Entity_DcDepartment_ParentDepartmentId;
            if (gridView1.Columns["IsActive"] != null) gridView1.Columns["IsActive"].Caption = Properties.Resources.Entity_DcDepartment_IsActive;

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
            using var f = new FormDepartmentEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormDepartmentEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_DepartmentList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcDepartments.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            db.DcDepartments.Remove(entity);
            db.SaveChanges();
            LoadData();
        }
    }
}
