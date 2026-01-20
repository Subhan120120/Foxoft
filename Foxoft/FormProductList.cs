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
using DevExpress.XtraVerticalGrid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormProductList : RibbonForm
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        ReportClass reportClass;

        public byte[] productTypeArr;
        public DcProduct dcProduct { get; set; }
        public string focusedProductCode { get; set; }
        public string[] productCodes { get; set; }
        public bool? isDisabled { get; set; }

        GridColumn colImage = new();
        GridColumn colProductCode = new();
        GridColumn colProductCost = new();
        GridColumn colBalance = new();

        string productsFolder;

        public FormProductList()
        {
            InitializeComponent();

            RegisterEvents();

            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9);  // 80% of screen width
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.9); // 80% of screen height

            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            productsFolder = Path.Combine(settingStore.ImageFolder, "Products");
            reportClass = new ReportClass(settingStore.DesignFileFolder);

            string activeFilterStr = $"[{nameof(SettingStore.StoreCode)}] = '" + settingStore.StoreCode + "'";
            reportClass.AddReports(BSI_Reports, "Products", nameof(DcProduct.ProductCode), gV_ProductList);

            AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore?.ImageFolder);

            LoadLayout();

            RepositoryItemPictureEdit riPictureEdit = new();
            colImage.FieldName = "Image";
            colImage.Caption = Resources.Form_ProductList_Column_Image;
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

        public FormProductList(byte[] productTypeArr, bool? isDisabled)
            : this()
        {
            this.productTypeArr = productTypeArr;
            this.isDisabled = isDisabled;
            LoadProducts(productTypeArr);
            gV_ProductList.PopulateColumns();
            LoadLayout();
            gV_ProductList.Columns.Add(colImage);
        }

        public FormProductList(byte[] productTypeArr, bool? isDisabled, string focusedProductCode)
            : this(productTypeArr, isDisabled)
        {
            this.focusedProductCode = focusedProductCode;
        }

        public FormProductList(byte[] productTypeArr, bool? isDisabled, string[] productCodes)
            : this(productTypeArr, isDisabled)
        {
            this.productCodes = productCodes;
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
            FocusValue(focusedProductCode);

            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RegisterEvents()
        {
            Load += FormProductList_Load;
            Activated += FormProductList_Activated;
            BBI_Save.ItemClick += BBI_Save_ItemClick;
            BBI_Show.ItemClick += BBI_Show_ItemClick;
            BBI_ProductNew.ItemClick += BBI_ProductNew_ItemClick;
            bBI_ExportExcel.ItemClick += bBI_ExportExcel_ItemClick;
            bBI_ProductDelete.ItemClick += bBI_ProductDelete_ItemClick;
            bBI_ProductRefresh.ItemClick += bBI_ProductRefresh_ItemClick;
            BBI_query.ItemClick += BBI_Query_ItemClick;
            btn_ProductEdit.ItemClick += btn_productEdit_ItemClick;
            gC_ProductList.ProcessGridKey += gC_ProductList_ProcessGridKey;
            gC_ProductList.Resize += (s, e) => btnEdit_BarcodeSearch_Layout();
            gV_ProductList.RowCellStyle += gV_ProductList_RowCellStyle;
            gV_ProductList.RowStyle += gV_ProductList_RowStyle;
            gV_ProductList.PopupMenuShowing += gV_ProductList_PopupMenuShowing;
            gV_ProductList.CalcRowHeight += gV_ProductList_CalcRowHeight;
            gV_ProductList.FocusedRowChanged += gV_ProductList_FocusedRowChanged;
            gV_ProductList.ColumnFilterChanged += gV_ProductList_ColumnFilterChanged;
            gV_ProductList.CustomUnboundColumnData += gV_ProductList_CustomUnboundColumnData;
            gV_ProductList.DoubleClick += gV_ProductList_DoubleClick;
            gV_ProductList.Layout += (s, e) => btnEdit_BarcodeSearch_Layout();
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

        private void SaveLayout()
        {
            string fileName = "FormProductList.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

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

            // Qeyd: "Məhsulun Geniş Adı" burada SQL sorğusundakı sütun alias-ı kimi istifadə olunur
            gV_ProductList.OptionsFind.FindFilterColumns =
                "*;Məhsulun Geniş Adı;" +
                nameof(DcProduct.ProductDesc) + ';' +
                nameof(DcProduct.HierarchyCode);

            gV_ProductList.OptionsFind.FindNullPrompt = Resources.Form_ProductList_FindPanelPrompt;

            string fileName = "FormProductList.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };

            if (File.Exists(layoutFilePath))
                gV_ProductList.RestoreLayoutFromXml(layoutFilePath, option);
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                using MemoryStream stream = new(byteArray);
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
            if (e.Column.FieldName != "Image" || !e.IsGetData) return;

            var view = (GridView)sender;
            int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
            string code = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

            if (!CustomExtensions.DirectoryExist(productsFolder) || string.IsNullOrEmpty(code))
                return;

            string path = Path.Combine(productsFolder, code, code + ".jpg");

            if (!imageCache.TryGetValue(path, out var img))
            {
                img = GetImage(path);
                imageCache[path] = img;
            }

            e.Value = img;
        }

        Image GetImage(string path)
        {
            if (!File.Exists(path)) return null;

            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var tmp = Image.FromStream(fs))
                {
                    return (Image)tmp.Clone(); // prevents locking the jpg on disk
                }
            }
            catch
            {
                return null;
            }
        }

        void ClearImageCache()
        {
            foreach (var kv in imageCache)
                kv.Value?.Dispose();
            imageCache.Clear();
        }

        private void LoadProducts(byte[] productTypeArr)
        {
            object dataSource = null;

            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_ProductList");
            if (dcReport is not null)
            {
                if (!string.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    string tArr = string.Join(",", productTypeArr);
                    string filtered = $"[{nameof(DcProduct.ProductTypeCode)}] IN ({tArr}) ";

                    if (productCodes is not null && productCodes.Length > 0)
                    {
                        string pArr = string.Join(",", productCodes.Select(x => $"'{x.Replace("'", "''")}'"));
                        filtered += $" AND [{nameof(DcProduct.ProductCode)}] IN ({pArr}) ";
                    }

                    if (isDisabled.HasValue)
                    {
                        string dbValue = (bool)isDisabled ? "1" : "0";
                        filtered = filtered + $"AND IsDisabled = {dbValue}";
                    }

                    SqlParameter[] sqlParameters;
                    string sql = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, filtered, out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(sql, sqlParameters);
                    if (dt.Columns.Count > 0)
                        dataSource = dt;
                }
            }

            dcProductsBindingSource.DataSource = dataSource;

            if (gV_ProductList.FocusedRowHandle >= 0)
            {
                object productCode = gV_ProductList.GetFocusedRowCellValue(nameof(DcProduct.ProductCode));
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString(), productTypeArr);
            }
            else
                dcProduct = null;

            gV_ProductList.MakeRowVisible(gV_ProductList.FocusedRowHandle);
        }

        private void gV_ProductList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object productCode = view.GetFocusedRowCellValue(nameof(DcProduct.ProductCode));
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString(), productTypeArr);
            }
            else
                dcProduct = null;
        }

        private void gV_ProductList_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BBI_ProductNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormProduct formProduct = new(productTypeArr.FirstOrDefault(), true);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts(productTypeArr);
                FocusValue(formProduct.dcProduct.ProductCode);
            }
        }

        private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcProduct is null)
            {
                MessageBox.Show(Resources.Form_ProductList_Message_ProductNotSelected, Resources.Common_Attention);
                return;
            }

            using FormProduct formProduct = new(dcProduct.ProductTypeCode, dcProduct.ProductCode);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                int fr = gV_ProductList.FocusedRowHandle;

                if (CustomExtensions.DirectoryExist(productsFolder))
                {
                    string path = Path.Combine(productsFolder, dcProduct.ProductCode, dcProduct.ProductCode + ".jpg");

                    if (imageCache.TryGetValue(path, out var oldImg))
                    {
                        oldImg?.Dispose();              // dispose first
                        imageCache.Remove(path);
                    }

                    var newImg = GetImage(path);
                    imageCache[path] = newImg;
                }

                LoadProducts(productTypeArr);

                gV_ProductList.FocusedRowHandle = fr;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && gV_ProductList.IsFindPanelVisible)
            {
                if (gC_ProductList.ContainsFocus)// Optional: ensure Find Panel has focus
                {
                    DialogResult = DialogResult.OK;
                    return true; // prevent GridView default behavior
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
                    object cellValue = view.GetFocusedValue();
                    if (view.FocusedColumn == colImage && cellValue is Image image)
                        Clipboard.SetImage(image);
                    else if (cellValue is not null)
                        Clipboard.SetText(cellValue.ToString());

                    e.Handled = true;
                }

                if (e.KeyCode == Keys.B && e.Control)
                {
                    DcReport dcReport = efMethods.SelectReport(1032);
                    string filter = "";

                    if (!string.IsNullOrEmpty(dcProduct.ProductCode))
                        filter = $"{nameof(DcProduct.ProductCode)} = '{dcProduct.ProductCode}'";

                    SqlParameter[] sqlParameters;
                    dcReport.ReportQuery = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, filter, out sqlParameters);
                    DataTable? data = adoMethods.SqlGetDt(dcReport.ReportQuery);

                    XtraReport xtraReport = reportClass.CreateReport(data, dcReport.ReportName + ".repx");

                    using (MemoryStream ms = new())
                    {
                        xtraReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile, Resolution = 480 });
                        using (Image img = Image.FromStream(ms))
                        {
                            Clipboard.SetImage(img);
                        }
                    }

                    e.Handled = true;
                }
            }
        }

        private void bBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_ProductList);
        }

        private void gV_ProductList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object productCode = view.GetFocusedRowCellValue(nameof(DcProduct.ProductCode));
                if (productCode is not null)
                    dcProduct = efMethods.SelectProduct(productCode.ToString(), productTypeArr);
            }
            else
                dcProduct = null;
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
        }

        private void gV_ProductList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // stil üçün istifadə edilmir (şərh olaraq saxlanılıb)
        }

        private void gV_ProductList_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.GetRowCellValue(e.RowHandle, colBalance) is not null)
            {
                decimal balance = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, colBalance));

                if (balance == 0)
                    e.Appearance.ForeColor = Color.Gray;
            }
        }

        private void bBI_ProductDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.ProductExist(dcProduct.ProductCode))
            {
                if (XtraMessageBox.Show(
                        xtraMessageBox(
                            Resources.Common_Attention,
                            string.Format(Resources.Form_ProductList_Message_DeleteProductConfirm, dcProduct.ProductDesc),
                            "actions_delete")) == DialogResult.OK)
                {
                    if (efMethods.BarcodeExistByProduct(dcProduct.ProductCode))
                    {
                        if (XtraMessageBox.Show(
                                xtraMessageBox(
                                    Resources.Common_Attention,
                                    string.Format(Resources.Form_ProductList_Message_DeleteBarcodeConfirm, dcProduct.ProductDesc),
                                    "barcode")) == DialogResult.OK)
                        {
                            efMethods.DeleteBarcodesByProduct(dcProduct.ProductCode);
                        }
                    }

                    efMethods.DeleteProduct(dcProduct);

                    if (CustomExtensions.DirectoryExist(productsFolder))
                    {
                        string path = Path.Combine(productsFolder, dcProduct.ProductCode, dcProduct.ProductCode + ".jpg");
                        if (imageCache.TryGetValue(path, out var oldImg))
                        {
                            oldImg?.Dispose();
                            imageCache.Remove(path);
                        }
                    }

                    LoadProducts(productTypeArr);
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_ProductList_Message_NoProductToDelete, Resources.Common_Attention);
            }
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

        private void gV_ProductList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu.Column != null)
                {
                    menu.Items.Add(CreateMenuItem("Save Layout", menu.Column, null));
                    menu.Items.Add(CreateCheckItem("Filter Column", menu.Column, null));
                }
            }
        }

        DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(
                caption,
                gV_ProductList.OptionsFind.FindFilterColumns.Contains(column.FieldName),
                image,
                new EventHandler(MenuCheckItem_Click));
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        DXMenuItem CreateMenuItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        void MenuCheckItem_Click(object sender, EventArgs e)
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

        void DXMenuItem_Click(object sender, EventArgs e)
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

        private void popupMenuReports_BeforePopup(object sender, CancelEventArgs e)
        {
        }

        private void FormProductList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnEdit_BarcodeSearch_Layout()
        {
            if (!Settings.Default.AppSetting.UseBarcode || !gV_ProductList.IsFindPanelVisible)
            {
                btnEdit_BarcodeSearch.Visible = false;
                return;
            }

            int findPanelHeight = 54; // typical height of DevExpress FindPanel (default)
            int paddingLeft = 8;       // typical left padding/margin of the FindPanel
            int defaultSearchWidth = 562; // approximate width of the default search box

            Point gridControlScreenPoint = gC_ProductList.PointToScreen(Point.Empty);
            Rectangle findPanelRect = new Rectangle(gridControlScreenPoint.X, gridControlScreenPoint.Y, gC_ProductList.Width, findPanelHeight);
            Point additionalEditorScreenPoint = new Point(findPanelRect.Left + paddingLeft + defaultSearchWidth + 6, findPanelRect.Top + (findPanelRect.Height - btnEdit_BarcodeSearch.Height) / 2);
            Point additionalEditorFormPoint = this.PointToClient(additionalEditorScreenPoint);

            btnEdit_BarcodeSearch.Location = additionalEditorFormPoint;
            btnEdit_BarcodeSearch.Visible = true;
            btnEdit_BarcodeSearch.BringToFront();
        }

        private void btnEdit_BarcodeSearch_EditValueChanged(object sender, EventArgs e)
        {
            DcProduct? asd = efMethods.SelectProductByBarcode(btnEdit_BarcodeSearch.EditValue?.ToString());

            if (asd != null)
            {
                gV_ProductList.SetAutoFilterValue(colProductCode, asd.ProductCode, AutoFilterCondition.Default);
                gV_ProductList.FocusedRowHandle = gV_ProductList.GetVisibleRowHandle(0);
            }
            else
            {
                gV_ProductList.SetAutoFilterValue(colProductCode, null, AutoFilterCondition.Default);
            }
        }

        private XtraMessageBoxArgs xtraMessageBox(string caption, string text, string imageName)
        {
            XtraMessageBoxArgs argsDeleteInvoice = new XtraMessageBoxArgs
            {
                Caption = caption,
                Text = text,
                Buttons = new[] { DialogResult.OK, DialogResult.Cancel },
            };
            argsDeleteInvoice.ImageOptions.SvgImage = svgImageCollection1[imageName];
            return argsDeleteInvoice;
        }
    }
}
