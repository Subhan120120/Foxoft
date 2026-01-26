// File: Forms/Hr/FormEmploymentTypeList.cs
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
    public class FormEmploymentTypeList : RibbonForm
    {
        private readonly subContext db = new();
        RibbonControl ribbon;
        BarButtonItem btnNew, btnEdit, btnDelete, btnRefresh, btnClose;
        GridControl grid;
        GridView view;

        public FormEmploymentTypeList()
        {
            Text = "HR - Employment Types";
            Width = 900;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

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
            var group = new RibbonPageGroup("Employment Types");
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

            Load += (_, __) => LoadData();
        }

        private void LoadData()
        {
            var list = db.DcEmploymentTypes.AsNoTracking()
                .OrderBy(x => x.TypeCode)
                .Select(x => new { x.Id, x.TypeCode, x.TypeName, x.IsActive })
                .ToList();

            grid.DataSource = list;
            view.BestFitColumns();
        }

        private Guid? FocusedId()
        {
            var row = view.GetFocusedRow();
            if (row == null) return null;
            var p = row.GetType().GetProperty("Id");
            return p == null ? null : (Guid?)p.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormEmploymentTypeEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormEmploymentTypeEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, "Delete selected employment type?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcEmploymentTypes.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            try
            {
                db.DcEmploymentTypes.Remove(entity);
                db.SaveChanges();
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
