using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProductList : RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        public DcProduct dcProduct { get; set; }
        public string productCode { get; set; }
        public byte productTypeCode;

        public FormProductList()
        {
            InitializeComponent();
            bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_ProductList.RestoreLayoutFromStream(stream, option);
        }

        public FormProductList(byte productTypeCode)
            : this()
        {
            this.productTypeCode = productTypeCode;
            if (productTypeCode != 0)
                gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
            else
                gC_ProductList.DataSource = efMethods.SelectProducts();
            gV_ProductList.BestFitColumns();
        }

        public FormProductList(byte productTypeCode, string productCode)
            : this(productTypeCode)
        {
            this.productCode = productCode;
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
        }

        private void gV_ProductList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcProduct = view.GetRow(view.FocusedRowHandle) as DcProduct;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            #region Comment
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            //{
            //    //info.RowHandle
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    dcProduct = new DcProduct()
            //    {
            //        ProductCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductCode"]).ToString(),
            //        Barcode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Barcode"]).ToString(),
            //        ProductDescription = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductDescription"]).ToString(),
            //        RetailPrice = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RetailPrice"]))
            //    };
            //} 
            #endregion

            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                DialogResult = DialogResult.OK;
        }

        private void BBI_ProductNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct(productTypeCode);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                if (productTypeCode != 0)
                    gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
                else
                    gC_ProductList.DataSource = efMethods.SelectProducts();
            }
        }

        private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct(productTypeCode, dcProduct.ProductCode);

            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                int fr = gV_ProductList.FocusedRowHandle;

                if (productTypeCode != 0)
                    gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
                else
                    gC_ProductList.DataSource = efMethods.SelectProducts();

                gV_ProductList.FocusedRowHandle = fr;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowHandle = gV_ProductList.LocateByValue("ProductCode", productCode);

            gV_ProductList.SelectRow(rowHandle);
            gV_ProductList.FocusedRowHandle = rowHandle;
            gV_ProductList.MakeRowVisible(gV_ProductList.FocusedRowHandle);
        }

        private void gC_ProductList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;
            if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
                DialogResult = DialogResult.OK;


            if (e.KeyCode == Keys.F10 && view.SelectedRowsCount > 0)
            {
                object productCode = view.GetFocusedRowCellValue(colProductCode);
                if (productCode != null)
                {
                    DcReport dcReport = efMethods.SelectReport(1004);

                    string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                    string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                    FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, 1004);
                    formGrid.Text = dcReport.ReportName;
                    formGrid.Show();
                }
            }
        }

        private void Autoc_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        // AutoFocus FindPanel
        bool isFirstPaint = true;
        private void gC_ProductList_Paint(object sender, PaintEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (isFirstPaint)
            {
                if (!gV.FindPanelVisible)
                    gV.ShowFindPanel();
                gV.ShowFindPanel();
            }
            isFirstPaint = false;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gC_ProductList.ExportToXlsx(@"C:\Users\Administrator\Desktop\Excel");
        }

        private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}