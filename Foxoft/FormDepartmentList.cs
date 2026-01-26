// File: Forms/Hr/FormDepartmentList.cs
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public class FormDepartmentList : RibbonForm
    {
        private readonly subContext db = new();

        private RibbonControl ribbon = null!;
        private BarButtonItem btnNew = null!;
        private BarButtonItem btnEdit = null!;
        private BarButtonItem btnDelete = null!;
        private BarButtonItem btnRefresh = null!;
        private BarButtonItem btnClose = null!;

        private GridControl grid = null!;
        private GridView view = null!;

        public FormDepartmentList()
        {
            Text = "Departments";
            Width = 1100;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;

            BuildUi();
            Load += (_, __) => LoadData();
        }

        private void BuildUi()
        {
            ribbon = new RibbonControl { Dock = DockStyle.Top };
            btnNew = new BarButtonItem(ribbon.Manager, "New");
            btnEdit = new BarButtonItem(ribbon.Manager, "Edit");
            btnDelete = new BarButtonItem(ribbon.Manager, "Delete");
            btnRefresh = new BarButtonItem(ribbon.Manager, "Refresh");
            btnClose = new BarButtonItem(ribbon.Manager, "Close");

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            var page = new RibbonPage("HR");
            var group = new RibbonPageGroup("Departments");
            group.ItemLinks.Add(btnNew);
            group.ItemLinks.Add(btnEdit);
            group.ItemLinks.Add(btnDelete);
            group.ItemLinks.Add(btnRefresh);
            group.ItemLinks.Add(btnClose);
            page.Groups.Add(group);
            ribbon.Pages.Add(page);

            grid = new GridControl { Dock = DockStyle.Fill };
            view = new GridView(grid);
            grid.MainView = view;

            view.OptionsBehavior.Editable = false;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ColumnAutoWidth = false;
            view.DoubleClick += (_, __) => EditItem();
            view.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            Controls.Add(grid);
            Controls.Add(ribbon);
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

            grid.DataSource = list;
            view.BestFitColumns();
        }

        private Guid? FocusedId()
        {
            var row = view.GetFocusedRow();
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

            if (XtraMessageBox.Show(this, "Delete selected department?", "Confirm",
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
