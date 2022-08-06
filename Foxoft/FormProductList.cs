using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
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

         ribbonControl1.Minimized = true;
      }

      public FormProductList(byte productTypeCode)
          : this()
      {
         this.productTypeCode = productTypeCode;
         LoadProducts(productTypeCode);
      }

      public FormProductList(byte productTypeCode, string productCode)
          : this(productTypeCode)
      {
         this.productCode = productCode;
      }

      private void FormProductList_Load(object sender, EventArgs e)
      {
         int rowHandle = gV_ProductList.LocateByValue(0, colProductCode, productCode);
         if (rowHandle != GridControl.InvalidRowHandle)
         {
            gV_ProductList.FocusedRowHandle = rowHandle;
            gV_ProductList.MakeRowVisible(rowHandle);
         }
      }

      private void LoadProducts(byte productTypeCode)
      {
         //subContext dbContext = new subContext();

         //IQueryable<DcProduct> DcProducts = dbContext.DcProducts;
         //CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
         //IQueryable<DcProduct> filteredData = DcProducts.AppendWhere(new CriteriaToExpressionConverter(), gV_ProductList.ActiveFilterCriteria) as IQueryable<DcProduct>;

         //if (Object.ReferenceEquals(gV_ProductList.ActiveFilterCriteria, null))
         //    filteredData = filteredData.Take(10);

         //filteredData.Where(x => x.ProductTypeCode == productTypeCode)
         //                .Include(x => x.TrInvoiceLines)
         //                    .ThenInclude(x => x.TrInvoiceHeader)
         //                .LoadAsync()
         //                .ContinueWith(loadTask => dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());


         if (productTypeCode != 0)
         {
            List<DcProduct> dcProducts = efMethods.SelectProductsByType(productTypeCode, gV_ProductList.ActiveFilterCriteria);
            dcProductsBindingSource.DataSource = dcProducts;
         }
         else if (productTypeCode == 0)
         {
            List<DcProduct> dcProducts = efMethods.SelectProducts();
            dcProductsBindingSource.DataSource = dcProducts;
         }

         if (gV_ProductList.FocusedRowHandle >= 0)
            dcProduct = gV_ProductList.GetRow(gV_ProductList.FocusedRowHandle) as DcProduct;

         gV_ProductList.BestFitColumns();
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

         DialogResult = DialogResult.OK;
      }

      private void BBI_ProductNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         FormProduct formProduct = new FormProduct(productTypeCode);
         if (formProduct.ShowDialog(this) == DialogResult.OK)
         {
            LoadProducts(productTypeCode);
         }
      }

      private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (!Object.ReferenceEquals(dcProduct, null))
         {

            FormProduct formProduct = new FormProduct(productTypeCode, dcProduct.ProductCode);

            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
               int fr = gV_ProductList.FocusedRowHandle;

               LoadProducts(productTypeCode);

               gV_ProductList.FocusedRowHandle = fr;
            }
         }
         else
            MessageBox.Show("Məhsul Seçilməyib");
      }

      private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
      {

      }

      private void gC_ProductList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;

         if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
         {
            DialogResult = DialogResult.OK;
         }

         if (view.SelectedRowsCount > 0)
         {
            if (e.KeyCode == Keys.F9)
            {
               object productCode = view.GetFocusedRowCellValue(colProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1005);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                  string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                  FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport);
                  formGrid.Show();
               }
            }

            if (e.KeyCode == Keys.C && e.Control)
            {
               //if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
               //   Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString());
               //else
               //   MessageBox.Show("The value in the selected cell is null or empty!");

               string cellValue = view.GetFocusedValue().ToString();
               Clipboard.SetText(cellValue);
               e.Handled = true;
            }

            if (e.KeyCode == Keys.F10)
            {
               object productCode = view.GetFocusedRowCellValue(colProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1004);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                  string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                  FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport);
                  formGrid.Show();
               }
            }

         }
      }

      private void ApplySelectedProduct()
      {
         if (gV_ProductList.FocusedRowHandle >= 0)
         {
            dcProduct = gV_ProductList.GetFocusedRow() as DcProduct;
            DialogResult = DialogResult.OK;
         }
         else
         {
            MessageBox.Show("Məhsul Seçilmədi");
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

            gV.OptionsFind.FindFilterColumns = "ProductDesc";
            gV.OptionsFind.FindNullPrompt = "Axtarın...";
         }
         isFirstPaint = false;
      }

      private void bBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
      {
         gC_ProductList.ExportToXlsx(@"C:\Users\Public\Desktop\ProductList.xlsx");
      }

      private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Close();
      }

      private void gV_ProductList_ColumnFilterChanged(object sender, EventArgs e)
      {
         GridView view = sender as GridView;

         if (view.FocusedRowHandle >= 0)
            dcProduct = view.GetRow(view.FocusedRowHandle) as DcProduct;
         else
            dcProduct = null;
         //LoadProducts(productTypeCode);
      }

      private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
      {
         MessageBox.Show(gV_ProductList.ActiveFilterString);
      }
   }
}