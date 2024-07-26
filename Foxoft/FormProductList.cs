using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormProductList : RibbonForm
    {
        SettingStore settingStore = new();
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        CustomMethods cM = new();

        string barcodeDesignFile = @"Barcode.repx";
        public byte[] productTypeArr;
        public DcProduct dcProduct { get; set; }
        public string productCode { get; set; }

        GridColumn colImage = new();
        GridColumn colProductCode = new();
        GridColumn colProductCost = new();
        GridColumn colBalance = new();


        public FormProductList()
        {
            InitializeComponent();

            Events();

            AddReports();

            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore?.ImageFolder);

            LoadLayout();

            RepositoryItemPictureEdit riPictureEdit = new();
            colImage.FieldName = "Image";
            colImage.Caption = "Şəkil";
            colImage.UnboundType = UnboundColumnType.Object;
            colImage.OptionsColumn.AllowEdit = false;
            colImage.Visible = true;
            colImage.OptionsColumn.FixedWidth = true;
            colImage.ColumnEdit = riPictureEdit;
            riPictureEdit.SizeMode = PictureSizeMode.Zoom;
            riPictureEdit.NullText = " ";
            gC_ProductList.RepositoryItems.Add(riPictureEdit);

            ribbonControl1.Minimized = true;
        }

        public FormProductList(byte[] productTypeArr)
            : this()
        {
            this.productTypeArr = productTypeArr;
            LoadProducts(productTypeArr);
            gV_ProductList.PopulateColumns();
            LoadLayout();
            gV_ProductList.Columns.Add(colImage);
            gV_ProductList.BestFitColumns();
        }

        public FormProductList(byte[] productTypeArr, string productCode)
            : this(productTypeArr)
        {
            this.productCode = productCode;
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
            FocusValue(productCode);
        }

        private void Events()
        {
            Load += FormProductList_Load;
            Activated += FormProductList_Activated;
            BBI_Save.ItemClick += BBI_Save_ItemClick;
            BBI_Show.ItemClick += BBI_Show_ItemClick;
            BBI_ProductNew.ItemClick += BBI_ProductNew_ItemClick;
            bBI_ExportExcel.ItemClick += bBI_ExportExcel_ItemClick;
            bBI_quit.ItemClick += bBI_quit_ItemClick;
            bBI_ProductDelete.ItemClick += bBI_ProductDelete_ItemClick;
            bBI_ProductRefresh.ItemClick += bBI_ProductRefresh_ItemClick;
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            BBI_query.ItemClick += BBI_Query_ItemClick;
            btn_ProductEdit.ItemClick += btn_productEdit_ItemClick;
            gC_ProductList.ProcessGridKey += gC_ProductList_ProcessGridKey;
            gV_ProductList.CustomUnboundColumnData += gV_ProductList_CustomUnboundColumnData;
            gV_ProductList.RowCellStyle += gV_ProductList_RowCellStyle;
            gV_ProductList.RowStyle += gV_ProductList_RowStyle;
            gV_ProductList.PopupMenuShowing += gV_ProductList_PopupMenuShowing;
            gV_ProductList.CalcRowHeight += gV_ProductList_CalcRowHeight;
            gV_ProductList.FocusedRowChanged += gV_ProductList_FocusedRowChanged;
            gV_ProductList.ColumnFilterChanged += gV_ProductList_ColumnFilterChanged;
            gV_ProductList.CustomUnboundColumnData += gV_ProductList_CustomUnboundColumnData;
            gV_ProductList.DoubleClick += gridView1_DoubleClick;
        }

        private void FocusValue(string productCode)
        {
            int rowHandle = gV_ProductList.LocateByValue(0, colProductCode, productCode);
            if (rowHandle != GridControl.InvalidRowHandle)
                gV_ProductList.FocusedRowHandle = rowHandle;
        }

        private void FormProductList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gV_ProductList is not null)
            {
                gV_ProductList.FindPanelVisible = false;
                if (!gV_ProductList.FindPanelVisible)
                    gC_ProductList.BeginInvoke(new Action(gV_ProductList.ShowFindPanel));
            }

            LoadProducts(productTypeArr);
        }

        private void AddReports()
        {
            BSI_Report.LinksPersistInfo.Clear();

            List<TrFormReport> trFormReports = efMethods.SelectFormReports("Products");

            BarButtonItem BBI;

            foreach (TrFormReport report in trFormReports)
            {
                BBI = new();
                BBI.Caption = report.DcReport.ReportName;
                BBI.ImageOptions.SvgImage = svgImageCollection1["report"];
                BBI.Name = report.DcReport.ReportId.ToString();
                if (!string.IsNullOrEmpty(report.Shortcut))
                {
                    KeysConverter cvt = new();
                    Keys key = (Keys)cvt.ConvertFrom(report.Shortcut);
                    BBI.ItemShortcut = new BarShortcut(key);
                }
                BSI_Report.LinksPersistInfo.Add(new LinkPersistInfo(BBI));

                ((ISupportInitialize)ribbonControl1).BeginInit();
                ribbonControl1.Items.Add(BBI);
                ((ISupportInitialize)ribbonControl1).EndInit();

                BBI.ItemClick += (sender, e) =>
                {
                    DcReport dcReport = report.DcReport;

                    string filter = "";
                    if (dcProduct is not null)
                        filter = "[ProductCode] = '" + dcProduct.ProductCode + "' ";
                    else
                    {
                        List<DataRowView> mydata = GetFilteredData<DataRowView>(gV_ProductList).ToList();
                        string combined = "";
                        foreach (DataRowView rowView in mydata)
                            combined += "'" + rowView["ProductCode"].ToString() + "',";

                        combined = combined.Substring(0, combined.Length - 1);
                        filter = "[ProductCode] in ( " + combined + ")";
                    }

                    string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

                    string query = dcReport.ReportQuery;
                    if (query.Contains("{ProductCode}"))
                        query = query.Replace("{ProductCode}", " and " + filter); // filter sorgunun icinde temsilci ile deyisdirilir

                    if (dcReport.ReportTypeId == 1)
                    {
                        FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
                        formGrid.Show();
                    }
                    else if (dcReport.ReportTypeId == 2)
                    {
                        FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }
                };
            }

            BBI = new();
            BBI.Caption = "Əlavə Et";
            BBI.ImageOptions.SvgImage = svgImageCollection1["add"];
            BBI.Name = "Add";

            BSI_Report.LinksPersistInfo.Add(new LinkPersistInfo(BBI));
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ribbonControl1.Items.Add(BBI);
            ((ISupportInitialize)ribbonControl1).EndInit();

            BBI.ItemClick += (sender, e) =>
            {
                using FormCommonList<TrFormReport> form = new("", "ReportId", "", "FormCode", "Products");
                try
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                        efMethods.InsertFormReport("Products", Convert.ToInt32(form.Value_Id));
                    AddReports();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            };
        }

        private void SaveLayout()
        {
            string fileName = "FormProductList.xml";
            string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files");
            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_ProductList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName), option);
        }

        private void LoadLayout()
        {

            colProductCode = gV_ProductList.Columns[nameof(DcProduct.ProductCode)];
            colBalance = gV_ProductList.Columns[nameof(DcProduct.Balance)];
            colProductCost = gV_ProductList.Columns[nameof(DcProduct.ProductCost)];

            gV_ProductList.OptionsFind.FindFilterColumns = "*;Məhsulun Geniş Adı;" + nameof(dcProduct.ProductDesc) + ';' + nameof(dcProduct.HierarchyCode);
            gV_ProductList.OptionsFind.FindNullPrompt = "Axtarın...";

            string fileName = "FormProductList.xml";
            string layoutFilePath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", fileName);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };

            if (File.Exists(layoutFilePath))
                gV_ProductList.RestoreLayoutFromXml(layoutFilePath, option);
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                MemoryStream stream = new(byteArray);
                gV_ProductList.RestoreLayoutFromStream(stream, option);
            }

            if (colProductCost != null)
            {
                colProductCost.OptionsColumn.ShowInCustomizationForm = false;
                colProductCost.Visible = false;

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Column_ProductCost");
                if (currAccHasClaims)
                {
                    colProductCost.OptionsColumn.ShowInCustomizationForm = true;
                    colProductCost.Visible = true;
                }
            }

            txtEdit_filtercolumns.EditValue = gV_ProductList.OptionsFind.FindFilterColumns;
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
                if (CustomExtensions.DirectoryExist(settingStore?.ImageFolder))
                {
                    string path = settingStore.ImageFolder + @"\" + fileName;
                    if (!imageCache.ContainsKey(path))
                    {
                        Image img = GetImage(path);
                        imageCache.Add(path, img);
                        //img.Dispose();
                    }
                    e.Value = imageCache[path];
                }
            }
        }

        Image GetImage(string path)
        {
            Image img = null;

            if (File.Exists(path))
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    try
                    {
                        img = Image.FromStream(stream);
                    }
                    catch (Exception)
                    {
                    }
                }

            return img;
        }

        private void LoadProducts(byte[] productTypeArr)
        {
            object dataSource = null;

            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_ProductList");
            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    string ts = String.Join(",", productTypeArr);
                    string where = " Where ProductTypeCode in (" + ts + ") ";
                    string query = cM.AddTop(dcReport.ReportQuery, int.MaxValue);

                    query = cM.AddFilters(query, dcReport);
                    SqlParameter[] sqlParameters = cM.AddParameters(dcReport);

                    string qryMaster = "select * from (" + query + " \n) as Master " + where + " order by RowNumber";
                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    if (dt.Rows.Count > 0)
                        dataSource = dt;
                }
            }

            if (dataSource is null)
            {
                if (productTypeArr != null && productTypeArr.Length > 0)
                    dataSource = efMethods.SelectProductsByTypeByFilter(productTypeArr, gV_ProductList.ActiveFilterCriteria);
                else if (productTypeArr == null)
                    dataSource = efMethods.SelectProducts();
            }

            dcProductsBindingSource.DataSource = dataSource;

            if (gV_ProductList.FocusedRowHandle >= 0)
            {
                object productCode = gV_ProductList.GetFocusedRowCellValue("ProductCode");
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString());
            }
            else
                dcProduct = null;

            gV_ProductList.BestFitColumns();
            gV_ProductList.MakeRowVisible(gV_ProductList.FocusedRowHandle);

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

        }

        private void gV_ProductList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object productCode = view.GetFocusedRowCellValue(nameof(dcProduct.ProductCode));
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString());
            }
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
            FormProduct formProduct = new(productTypeArr.FirstOrDefault(), true);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts(productTypeArr);
                FocusValue(formProduct.dcProduct.ProductCode);
            }
        }

        private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcProduct is not null)
            {
                FormProduct formProduct = new(dcProduct.ProductTypeCode, dcProduct.ProductCode);

                if (formProduct.ShowDialog(this) == DialogResult.OK)
                {
                    int fr = gV_ProductList.FocusedRowHandle;

                    if (CustomExtensions.DirectoryExist(settingStore?.ImageFolder))
                    {
                        string path = settingStore.ImageFolder + @"\" + dcProduct.ProductCode + ".jpg";
                        imageCache.Remove(path);
                    }

                    LoadProducts(productTypeArr);

                    gV_ProductList.FocusedRowHandle = fr;
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

                if (e.KeyCode == Keys.B && e.Control)
                {
                    List<DcProduct> dcProducts = new();
                    dcProducts.Add(dcProduct);

                    ReportClass reportClass = new();
                    XtraReport xtraReport = reportClass.CreateReport(dcProducts, "PriceList_OneProduct.repx");

                    using (MemoryStream ms = new())
                    {
                        xtraReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile, Resolution = 480 });
                        Image img = Image.FromStream(ms);
                        Clipboard.SetImage(img);
                    };

                    e.Handled = true;
                }
            }
        }

        private void bBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trace.Write("\n Before 'SaveFileDialog saveFileDialog1 = new();' ");
            XtraSaveFileDialog sFD = new();
            Trace.Write("\n Before ' saveFileDialog1.Filter = 'Excel Faylı | *.xlsx';' ");
            sFD.Filter = "Excel Faylı|*.xlsx";
            Trace.Write("\n Before 'saveFileDialog1.Title = 'Excel Faylı Yadda Saxla';' ");
            sFD.Title = "Excel Faylı Yadda Saxla";
            Trace.Write("\n Before 'saveFileDialog1.FileName = this.Text");
            sFD.FileName = this.Text;
            Trace.Write("\n Before 'saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);' ");
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Trace.Write("\n Before 'saveFileDialog1.DefaultExt = ' *.xlsx';' ");
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_ProductList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gV_ProductList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object productCode = view.GetFocusedRowCellValue(nameof(dcProduct.ProductCode));
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString());
            }
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

                    if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                    {
                        string path = settingStore.ImageFolder + @"\" + dcProduct.ProductCode + ".jpg";
                        imageCache.Remove(path);
                    }

                    LoadProducts(productTypeArr);
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan mal yoxdur");
        }

        private void bBI_ProductRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProducts(productTypeArr);
        }

        private void gV_ProductList_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView gV = sender as GridView;
            if (e.RowHandle == GridControl.AutoFilterRowHandle)
                e.RowHeight = 25;
            colImage.Width = gV.RowHeight;
        }

        private void BarcodePrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowReportPreview();
        }

        private void ShowReportPreview()
        {
            XtraReport xtraReport = GetBarcodeReport();

            if (xtraReport is not null)
            {
                ReportPrintTool printTool = new(xtraReport);
                printTool.ShowRibbonPreview();
            }
        }

        private XtraReport GetBarcodeReport()
        {
            ReportClass reportClass = new();
            DsMethods dsMethods = new();
            DevExpress.DataAccess.Sql.SqlQuery sqlQuerySale = dsMethods.SelectProduct(dcProduct.ProductCode);
            return reportClass.GetReport("Barcode", barcodeDesignFile, new DevExpress.DataAccess.Sql.SqlQuery[] { sqlQuerySale });
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = GetBarcodeReport();

            if (xtraReport is not null)
            {
                ReportDesignTool printTool = new(xtraReport);
                printTool.ShowRibbonDesigner();
            }
        }

        private void gV_ProductList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //menu.Items.Clear();
                if (menu.Column != null)
                {
                    menu.Items.Add(CreateMenuItem("Save Layout", menu.Column, null));
                    menu.Items.Add(CreateCheckItem("Filter Column", menu.Column, null));
                }
            }
        }

        DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, gV_ProductList.OptionsFind.FindFilterColumns.Contains(column.FieldName), image, new EventHandler(OnCanMoveItemClick));
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        DXMenuItem CreateMenuItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_ItemClick), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        void OnCanMoveItemClick(object sender, EventArgs e)
        {
            DXMenuCheckItem item = sender as DXMenuCheckItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            string fieldName = ";" + info.Column.FieldName;
            if (item.Checked)
                gV_ProductList.OptionsFind.FindFilterColumns += fieldName;

            else
                gV_ProductList.OptionsFind.FindFilterColumns = gV_ProductList.OptionsFind.FindFilterColumns.Replace(fieldName, "");
        }

        // Menu item click handler.
        void DXMenuItem_ItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            SaveLayout();
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                this.Column = column;
            }
            public GridColumn Column;
        }

        private void BBI_Query_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_ProductList");
            if (dcReport is not null)
            {
                int id = dcReport.ReportId;
                FormReportEditor formQueryEditor = new(id);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                    LoadProducts(productTypeArr);
            }
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
        }

        private void BBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            gV_ProductList.OptionsFind.FindFilterColumns = txtEdit_filtercolumns.EditValue.ToString();
        }

        private void BBI_Show_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(gV_ProductList.OptionsFind.FindFilterColumns);
        }
    }
}