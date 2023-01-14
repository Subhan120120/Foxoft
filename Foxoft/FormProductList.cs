using DevExpress.Data;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormProductList : RibbonForm
   {
      EfMethods efMethods = new();
      public DcProduct dcProduct { get; set; }
      string imageFolder;
      public string productCode { get; set; }
      public byte productTypeCode;

      RepositoryItemPictureEdit riPictureEdit = new();
      GridColumn colImage = new();

      public FormProductList()
      {
         InitializeComponent();
         bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);

         SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
         if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
            imageFolder = settingStore.ImageFolder;

         byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
         MemoryStream stream = new(byteArray);
         OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
         gV_ProductList.RestoreLayoutFromStream(stream, option);

         colImage.FieldName = "Image";
         colImage.Caption = "Şəkil";
         colImage.UnboundType = UnboundColumnType.Object;
         colImage.OptionsColumn.AllowEdit = false;
         colImage.Visible = true;
         colImage.OptionsColumn.FixedWidth = true;
         colImage.ColumnEdit = riPictureEdit;
         riPictureEdit.SizeMode = PictureSizeMode.Zoom;
         gC_ProductList.RepositoryItems.Add(riPictureEdit);

         ribbonControl1.Minimized = true;
      }

      public FormProductList(byte productTypeCode)
          : this()
      {
         this.productTypeCode = productTypeCode;
         LoadProducts(productTypeCode);

         gV_ProductList.Columns.Add(colImage);
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

         //gV_ProductList.ShowFindPanel();
         //gV_ProductList.OptionsFind.FindFilterColumns = "ProductDesc";
         //gV_ProductList.OptionsFind.FindNullPrompt = "Axtarın...";
      }

      public Dictionary<string, Image> imageCache = new(StringComparer.OrdinalIgnoreCase);
      private void gV_ProductList_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
      {
         if (e.Column.FieldName == "Image" && e.IsGetData)
         {
            GridView view = sender as GridView;
            int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
            string fileName = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;
            fileName += ".jpg";
            if (!string.IsNullOrEmpty(imageFolder))
            {
               string path = Path.Combine(imageFolder, fileName);
               if (!imageCache.ContainsKey(path))
               {
                  Image img = GetImage(path);
                  imageCache.Add(path, img);
               }
               e.Value = imageCache[path];
            }
         }
      }

      Image GetImage(string path)
      {
         Image img = Resources.NoPhoto;

         if (File.Exists(path))
            img = Image.FromStream(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

         return img;
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
         gV_ProductList.MakeRowVisible(gV_ProductList.FocusedRowHandle);
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
         FormProduct formProduct = new(productTypeCode, true);
         if (formProduct.ShowDialog(this) == DialogResult.OK)
         {
            LoadProducts(productTypeCode);
         }
      }

      private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dcProduct is not null)
         {
            FormProduct formProduct = new(productTypeCode, dcProduct.ProductCode);

            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
               int fr = gV_ProductList.FocusedRowHandle;

               LoadProducts(productTypeCode);

               gV_ProductList.FocusedRowHandle = fr;

               string path = Path.Combine(imageFolder, formProduct.dcProduct.ProductCode + ".jpg");
               imageCache.Remove(path);
            }
         }
         else
            MessageBox.Show("Məhsul Seçilməyib");
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
                  string filter = " where [ProductCode] = '" + productCode + "' ";
                  string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                  FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
                  formGrid.Show();
               }
            }

            if (e.KeyCode == Keys.C && e.Control)
            {
               //if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
               //   Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString());
               //else
               //   MessageBox.Show("The value in the selected cell is null or empty!");

               object cellValue = view.GetFocusedValue();
               if (view.FocusedColumn == colImage)
                  Clipboard.SetImage((Image)cellValue);
               else
                  Clipboard.SetText(cellValue.ToString());


               e.Handled = true;
            }

            if (e.KeyCode == Keys.F10)
            {
               object productCode = view.GetFocusedRowCellValue(colProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1004);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";
                  string filter = " where [ProductCode] = '" + productCode + "' ";
                  string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                  FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);

                  formGrid.Show();
               }
            }
         }
      }

      // AutoFocus FindPanel
      bool isFirstPaint = true;
      private void gC_ProductList_Paint(object sender, PaintEventArgs e)
      {
         //GridControl gC = sender as GridControl;
         //GridView gV = gC.MainView as GridView;

         //if (isFirstPaint)
         //{
         //   if (!gV.FindPanelVisible)
         //      gV.ShowFindPanel();
         //   gV.ShowFindPanel();

         //   gV.OptionsFind.FindFilterColumns = "ProductDesc";
         //   //gV.OptionsFind.FindNullPrompt = "Axtarın...";
         //}
         //isFirstPaint = false;
      }

      private void bBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
      {
         SaveFileDialog saveFileDialog1 = new();
         saveFileDialog1.Filter = "Excel Faylı|*.xlsx";
         saveFileDialog1.Title = "Excel Faylı Yadda Saxla";
         saveFileDialog1.FileName = $@"ProductList.xlsx";
         saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         saveFileDialog1.DefaultExt = "*.xlsx";

         if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            gC_ProductList.ExportToXlsx(saveFileDialog1.FileName);
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

      //AutoFocus FindPanel
      private void gC_ProductList_Load(object sender, EventArgs e)
      {
         GridControl gC = sender as GridControl;
         GridView gV = gC.MainView as GridView;
         if (gV is not null)
         {
            gV_ProductList.OptionsFind.FindFilterColumns = "ProductDesc";
            gV_ProductList.OptionsFind.FindNullPrompt = "Axtarın...";

            if (!gV.FindPanelVisible)
               gC.BeginInvoke(new Action(gV.ShowFindPanel));
         }
      }

      private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
      {
         DcReport dcReport = efMethods.SelectReport(3);
         object ProductCode = gV_ProductList.GetFocusedRowCellValue(colProductCode);

         if (ProductCode is not null)
         {
            string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";
            string filter = " where [ProductCode] = '" + ProductCode + "' ";
            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
            FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
            formGrid.Show();
         }
      }

      private void gV_ProductList_CalcRowHeight(object sender, RowHeightEventArgs e)
      {
         GridView gV = sender as GridView;
         if (e.RowHandle == GridControl.AutoFilterRowHandle)
            e.RowHeight = 25;
         colImage.Width = gV.RowHeight;
      }

      private string subConnString = ConfigurationManager
                 .OpenExeConfiguration(ConfigurationUserLevel.None)
                 .ConnectionStrings
                 .ConnectionStrings["Foxoft.Properties.Settings.subConnString"]
                 .ConnectionString;
      private void BarcodePrint_ItemClick(object sender, ItemClickEventArgs e)
      {
         ReportClass reportClass = new();

         string designPath = "";

         if (!File.Exists(designPath))
            designPath = reportClass.SelectDesign();
         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new();
            SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString));
            dataSource.Name = "Barcode";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            XtraReport xtraReport = reportClass.CreateReport(dataSource, designPath);

            if (xtraReport is not null)
            {
               ReportDesignTool printTool = new(xtraReport);
               printTool.ShowRibbonDesigner();
            }
         }
      }
   }
}