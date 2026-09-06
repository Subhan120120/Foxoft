using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormCurrAccContactDetailList : RibbonForm
    {
        EfMethods efMethods = new();
        subContext dbContext;
        private string currAccCode;

        public FormCurrAccContactDetailList(string currAccCode)
        {
            InitializeComponent();

            this.currAccCode = currAccCode;

            BBI_New.ImageOptions.SvgImage = svgImageCollection1["add"];
            BBI_Edit.ImageOptions.SvgImage = svgImageCollection1["edit"];
            BBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            BBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
        }

        private void FormCurrAccContactDetailList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dbContext = new subContext();

            List<DcCurrAccContactDetail> data = dbContext.DcCurrAccContactDetails
                .Where(x => x.CurrAccCode == currAccCode)
                .Include(x => x.DcContactType)
                .ToList();

            gridControl1.DataSource = data;
            gridView1.BestFitColumns();

            // Hide navigation/FK columns
            if (gridView1.Columns["CurrAccCode"] != null)
                gridView1.Columns["CurrAccCode"].Visible = false;
            if (gridView1.Columns["DcCurrAcc"] != null)
                gridView1.Columns.Remove(gridView1.Columns["DcCurrAcc"]);
            if (gridView1.Columns["DcContactType"] != null)
                gridView1.Columns.Remove(gridView1.Columns["DcContactType"]);
        }

        private DcCurrAccContactDetail GetFocusedEntity()
        {
            if (gridView1.FocusedRowHandle >= 0)
                return gridView1.GetFocusedRow() as DcCurrAccContactDetail;
            return null;
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccContactDetail frm = new(currAccCode);
            if (frm.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditFocusedRow();
        }

        private void EditFocusedRow()
        {
            DcCurrAccContactDetail entity = GetFocusedEntity();
            if (entity != null)
            {
                FormCurrAccContactDetail frm = new(currAccCode, entity.Id);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData();
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_CurrAccContactDetailList_NoItemToDelete,
                    Resources.Common_Attention);
            }
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DcCurrAccContactDetail entity = GetFocusedEntity();
            if (entity != null)
            {
                if (XtraMessageBox.Show(
                        string.Format(Resources.Message_ConfirmDelete, entity.ContactDesc),
                        Resources.Common_Attention,
                        MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteEntity(entity);
                    LoadData();
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_CurrAccContactDetailList_NoItemToDelete,
                    Resources.Common_Attention);
            }
        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            EditFocusedRow();
        }

        private void FormCurrAccContactDetailList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
