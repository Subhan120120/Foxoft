using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
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

         //if (gV_ProductList.ActiveFilterCriteria is null)
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
         else
            dcProduct = null;
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
         if (dcProduct is not null)
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

         if (e.KeyCode == Keys.Enter && dcProduct is not null)
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
            //gV.OptionsFind.FindNullPrompt = "Axtarın...";
         }
         isFirstPaint = false;
      }

      private void bBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
      {
         string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         gC_ProductList.ExportToXlsx(pathDesktop + @"\ProductList.xlsx");
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
      }

      private void gV_ProductList_RowCellStyle(object sender, RowCellStyleEventArgs e)
      {
         //GridView gridView = sender as GridView;

         //try
         //{
         //   // Apply the ReadOnly style  
         //   if (e.RowHandle >= 0 && e.Column == colBalance)
         //   {
         //      GridViewInfo viewInfo = gridView.GetViewInfo() as GridViewInfo;
         //      GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;
         //      // Check if there are style conditions  
         //      if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
         //      {
         //         // Check if there are FormatRules that should override the ReadOnly style  
         //         bool hasrules = false;
         //         foreach (var rule in gridView.FormatRules)
         //         {
         //            if (rule.IsFit(e.CellValue, gridView.GetDataSourceRowIndex(e.RowHandle)))
         //            {
         //               hasrules = true;
         //               break;
         //            }
         //         }
         //         if (!hasrules)
         //            e.Appearance.ForeColor = Color.Gray;
         //      }
         //   }
         //   // This is to fix the selection color when a color is set for the column  
         //   if (e.Column.AppearanceCell.Options.UseBackColor && gridView.IsCellSelected(e.RowHandle, e.Column))
         //      e.Appearance.BackColor = gridView.PaintAppearance.SelectedRow.BackColor;
         //}
         //catch (Exception ex)
         //{
         //   System.Diagnostics.Debug.Print(ex.Message);
         //}
      }

      private void gV_ProductList_RowStyle(object sender, RowStyleEventArgs e)
      {
         GridView view = sender as GridView;

         if (view.GetRowCellValue(e.RowHandle, colBalance) is not null)
         {
            int balance = (int)view.GetRowCellValue(e.RowHandle, colBalance);

            if (balance == 0)
               e.Appearance.ForeColor = Color.Gray;
         }
      }

      private void bBI_ProductDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (efMethods.ProductExist(dcProduct.ProductCode))
         {
            if (MessageBox.Show("Silmek Isteyirsiz? \n " + dcProduct.ProductDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               efMethods.DeleteProduct(dcProduct);

               LoadProducts(productTypeCode);
            }
         }
         else
            XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
      }

      private void bBI_ProductRefresh_ItemClick(object sender, ItemClickEventArgs e)
      {
         LoadProducts(productTypeCode);
      }

      private void BBI_Feature_ItemClick(object sender, ItemClickEventArgs e)
      {

      }
   }
}