
using DevExpress.Utils;

namespace Foxoft
{
    partial class FormProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductList));
            this.gC_ProductList = new Foxoft.MyGridControl();
            this.gV_ProductList = new Foxoft.MyGridView(this);
            this.dcProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWholesalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUseInternet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrPrices = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrInvoiceLines = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrFeature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHierarchyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ProductDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ProductRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Feature = new DevExpress.XtraBars.BarButtonItem();
            this.BarcodePrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_query = new DevExpress.XtraBars.BarButtonItem();
            this.BSI_Report = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.txtEdit_filtercolumns = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BBI_Save = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Show = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_ProductList
            // 
            this.gC_ProductList.DataSource = this.dcProductsBindingSource;
            this.gC_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_ProductList.Location = new System.Drawing.Point(0, 158);
            this.gC_ProductList.MainView = this.gV_ProductList;
            this.gC_ProductList.Name = "gC_ProductList";
            this.gC_ProductList.Size = new System.Drawing.Size(865, 481);
            this.gC_ProductList.TabIndex = 0;
            this.gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_ProductList});
            // 
            // gV_ProductList
            // 
            this.gV_ProductList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductCode,
            this.colProductDesc,
            this.colBarcode,
            this.colProductTypeCode,
            this.colUsePos,
            this.colPromotionCode,
            this.colPromotionCode2,
            this.colTaxRate,
            this.colPosDiscount,
            this.colIsDisabled,
            this.colRetailPrice,
            this.colPurchasePrice,
            this.colWholesalePrice,
            this.colUseInternet,
            this.colBalance,
            this.colLastPurchasePrice,
            this.colLastSalePrice,
            this.colDcProductType,
            this.colTrPrices,
            this.colTrInvoiceLines,
            this.colTrFeature,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate,
            this.colBalanceF,
            this.colBalanceM,
            this.colBalanceS,
            this.colHierarchyCode});
            this.gV_ProductList.CustomizationFormBounds = new System.Drawing.Rectangle(624, 401, 264, 272);
            this.gV_ProductList.GridControl = this.gC_ProductList;
            this.gV_ProductList.Name = "gV_ProductList";
            this.gV_ProductList.OptionsFind.FindDelay = 100;
            this.gV_ProductList.OptionsFind.FindFilterColumns = "ProductDesc;HierarchyCode";
            this.gV_ProductList.OptionsView.ShowGroupPanel = false;
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            this.colProductCode.Width = 77;
            // 
            // colProductDesc
            // 
            this.colProductDesc.FieldName = "ProductDesc";
            this.colProductDesc.Name = "colProductDesc";
            this.colProductDesc.Visible = true;
            this.colProductDesc.VisibleIndex = 1;
            this.colProductDesc.Width = 417;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            // 
            // colProductTypeCode
            // 
            this.colProductTypeCode.FieldName = "ProductTypeCode";
            this.colProductTypeCode.Name = "colProductTypeCode";
            // 
            // colUsePos
            // 
            this.colUsePos.FieldName = "UsePos";
            this.colUsePos.Name = "colUsePos";
            // 
            // colPromotionCode
            // 
            this.colPromotionCode.FieldName = "PromotionCode";
            this.colPromotionCode.Name = "colPromotionCode";
            // 
            // colPromotionCode2
            // 
            this.colPromotionCode2.FieldName = "PromotionCode2";
            this.colPromotionCode2.Name = "colPromotionCode2";
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            // 
            // colPosDiscount
            // 
            this.colPosDiscount.FieldName = "PosDiscount";
            this.colPosDiscount.Name = "colPosDiscount";
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.Name = "colRetailPrice";
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.FieldName = "PurchasePrice";
            this.colPurchasePrice.Name = "colPurchasePrice";
            // 
            // colWholesalePrice
            // 
            this.colWholesalePrice.FieldName = "WholesalePrice";
            this.colWholesalePrice.Name = "colWholesalePrice";
            this.colWholesalePrice.Visible = true;
            this.colWholesalePrice.VisibleIndex = 6;
            this.colWholesalePrice.Width = 122;
            // 
            // colUseInternet
            // 
            this.colUseInternet.FieldName = "UseInternet";
            this.colUseInternet.Name = "colUseInternet";
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            // 
            // colLastPurchasePrice
            // 
            this.colLastPurchasePrice.DisplayFormat.FormatString = "{0:n2}";
            this.colLastPurchasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastPurchasePrice.FieldName = "LastPurchasePrice";
            this.colLastPurchasePrice.Name = "colLastPurchasePrice";
            this.colLastPurchasePrice.Visible = true;
            this.colLastPurchasePrice.VisibleIndex = 5;
            this.colLastPurchasePrice.Width = 105;
            // 
            // colLastSalePrice
            // 
            this.colLastSalePrice.FieldName = "LastSalePrice";
            this.colLastSalePrice.Name = "colLastSalePrice";
            // 
            // colDcProductType
            // 
            this.colDcProductType.FieldName = "DcProductType";
            this.colDcProductType.Name = "colDcProductType";
            // 
            // colTrPrices
            // 
            this.colTrPrices.FieldName = "TrPrices";
            this.colTrPrices.Name = "colTrPrices";
            // 
            // colTrInvoiceLines
            // 
            this.colTrInvoiceLines.FieldName = "TrInvoiceLines";
            this.colTrInvoiceLines.Name = "colTrInvoiceLines";
            // 
            // colTrFeature
            // 
            this.colTrFeature.FieldName = "TrFeature";
            this.colTrFeature.Name = "colTrFeature";
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colBalanceF
            // 
            this.colBalanceF.FieldName = "BalanceF";
            this.colBalanceF.Name = "colBalanceF";
            this.colBalanceF.Visible = true;
            this.colBalanceF.VisibleIndex = 3;
            this.colBalanceF.Width = 85;
            // 
            // colBalanceM
            // 
            this.colBalanceM.FieldName = "BalanceM";
            this.colBalanceM.Name = "colBalanceM";
            this.colBalanceM.Visible = true;
            this.colBalanceM.VisibleIndex = 2;
            this.colBalanceM.Width = 87;
            // 
            // colBalanceS
            // 
            this.colBalanceS.FieldName = "BalanceS";
            this.colBalanceS.Name = "colBalanceS";
            this.colBalanceS.Visible = true;
            this.colBalanceS.VisibleIndex = 4;
            // 
            // colHierarchyCode
            // 
            this.colHierarchyCode.Caption = "gridColumn1";
            this.colHierarchyCode.FieldName = "HierarchyCode";
            this.colHierarchyCode.Name = "colHierarchyCode";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BBI_ProductNew,
            this.btn_ProductEdit,
            this.bBI_ExportExcel,
            this.bBI_quit,
            this.barButtonItem1,
            this.bBI_ProductDelete,
            this.bBI_ProductRefresh,
            this.BBI_Feature,
            this.BarcodePrint,
            this.barButtonItem2,
            this.BBI_query,
            this.BSI_Report,
            this.barButtonItem4,
            this.txtEdit_filtercolumns,
            this.BBI_Save,
            this.BBI_Show});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 37;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(865, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // BBI_ProductNew
            // 
            this.BBI_ProductNew.Caption = "Yeni";
            this.BBI_ProductNew.Id = 1;
            this.BBI_ProductNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ProductNew.ImageOptions.SvgImage")));
            this.BBI_ProductNew.Name = "BBI_ProductNew";
            // 
            // btn_ProductEdit
            // 
            this.btn_ProductEdit.Caption = "Dəyiş";
            this.btn_ProductEdit.Id = 2;
            this.btn_ProductEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ProductEdit.ImageOptions.SvgImage")));
            this.btn_ProductEdit.Name = "btn_ProductEdit";
            // 
            // bBI_ExportExcel
            // 
            this.bBI_ExportExcel.Caption = "Excele At";
            this.bBI_ExportExcel.Id = 5;
            this.bBI_ExportExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage")));
            this.bBI_ExportExcel.Name = "bBI_ExportExcel";
            // 
            // bBI_quit
            // 
            this.bBI_quit.Caption = "Bağla";
            this.bBI_quit.Id = 6;
            this.bBI_quit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_quit.ImageOptions.SvgImage")));
            this.bBI_quit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            this.bBI_quit.Name = "bBI_quit";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Sil";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bBI_ProductDelete
            // 
            this.bBI_ProductDelete.Caption = "Sil";
            this.bBI_ProductDelete.Id = 8;
            this.bBI_ProductDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ProductDelete.ImageOptions.SvgImage")));
            this.bBI_ProductDelete.Name = "bBI_ProductDelete";
            // 
            // bBI_ProductRefresh
            // 
            this.bBI_ProductRefresh.Caption = "Yenilə";
            this.bBI_ProductRefresh.Id = 9;
            this.bBI_ProductRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ProductRefresh.ImageOptions.SvgImage")));
            this.bBI_ProductRefresh.Name = "bBI_ProductRefresh";
            // 
            // BBI_Feature
            // 
            this.BBI_Feature.Caption = "Ozellik";
            this.BBI_Feature.Id = 13;
            this.BBI_Feature.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Feature.ImageOptions.SvgImage")));
            this.BBI_Feature.Name = "BBI_Feature";
            // 
            // BarcodePrint
            // 
            this.BarcodePrint.Caption = "Barkod Çapı";
            this.BarcodePrint.Id = 21;
            this.BarcodePrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarcodePrint.ImageOptions.SvgImage")));
            this.BarcodePrint.Name = "BarcodePrint";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Barkod Dizayn";
            this.barButtonItem2.Id = 22;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // BBI_query
            // 
            this.BBI_query.Caption = "Sorğu";
            this.BBI_query.Id = 23;
            this.BBI_query.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_query.ImageOptions.SvgImage")));
            this.BBI_query.Name = "BBI_query";
            // 
            // BSI_Report
            // 
            this.BSI_Report.Caption = "Hesabat";
            this.BSI_Report.Id = 27;
            this.BSI_Report.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BSI_Report.ImageOptions.SvgImage")));
            this.BSI_Report.Name = "BSI_Report";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "test";
            this.barButtonItem4.Id = 28;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // txtEdit_filtercolumns
            // 
            this.txtEdit_filtercolumns.Caption = "filter columns";
            this.txtEdit_filtercolumns.Edit = this.repositoryItemTextEdit1;
            this.txtEdit_filtercolumns.Id = 34;
            this.txtEdit_filtercolumns.Name = "txtEdit_filtercolumns";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // BBI_Save
            // 
            this.BBI_Save.Caption = "Save";
            this.BBI_Save.Id = 35;
            this.BBI_Save.Name = "BBI_Save";
            // 
            // BBI_Show
            // 
            this.BBI_Show.Caption = "Show";
            this.BBI_Show.Id = 36;
            this.BBI_Show.Name = "BBI_Show";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Məhsul";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_ProductNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_ProductEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_ProductDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_ProductRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_ExportExcel);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.BBI_Feature);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Nəzarət";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.BSI_Report);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hesabat";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.BarcodePrint);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Barkod";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup6});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Ayarlar";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.BBI_query);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Data";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.txtEdit_filtercolumns);
            this.ribbonPageGroup6.ItemLinks.Add(this.BBI_Show);
            this.ribbonPageGroup6.ItemLinks.Add(this.BBI_Save);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Filter Columns";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 639);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(865, 24);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // FormProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 663);
            this.Controls.Add(this.gC_ProductList);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormProductList";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Məhsul Siyahısı";
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyGridControl gC_ProductList;
        private MyGridView gV_ProductList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductNew;
        private DevExpress.XtraBars.BarButtonItem btn_ProductEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportExcel;
        private DevExpress.XtraBars.BarButtonItem bBI_quit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.BindingSource dcProductsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUsePos;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colWholesalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUseInternet;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLastSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDcProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colTrPrices;
        private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceLines;
        private DevExpress.XtraGrid.Columns.GridColumn colTrFeature;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceF;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceM;
        private DevExpress.XtraBars.BarButtonItem bBI_ProductDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_ProductRefresh;
        private DevExpress.XtraBars.BarButtonItem BBI_Feature;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem BarcodePrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem BBI_query;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportProduct;
        private DevExpress.XtraBars.BarSubItem BSI_Report;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colHierarchyCode;
        private DevExpress.XtraBars.BarButtonItem BBI_Save;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem txtEdit_filtercolumns;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem BBI_Show;
    }
}