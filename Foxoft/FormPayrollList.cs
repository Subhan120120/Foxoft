using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Foxoft
{
    public partial class FormPayrollList : RibbonForm
    {
        EfMethods efMethods = new();
        public FormPayrollList()
        {
            InitializeComponent();
        }

        private void View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void LoadData()
        {
            object list = efMethods.SelectPayrolList();

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

        private void FormPayrollList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var f = new FormPayrollEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, "Delete selected payroll?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            TrPayrollHeader entity = efMethods.SelectEntityByIdWithLine(id);

            if (entity == null) return;

            try
            {
                efMethods.DeleteEntity(entity);
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormPayrollEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }
    }
}
