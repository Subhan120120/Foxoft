
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
         this.gC_ProductList = new DevExpress.XtraGrid.GridControl();
         this.dcProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_ProductList = new DevExpress.XtraGrid.Views.Grid.GridView();
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
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
         this.btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ProductDelete = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ProductRefresh = new DevExpress.XtraBars.BarButtonItem();
         this.BBI_Feature = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
         this.BarcodePrint = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
         this.BBI_query = new DevExpress.XtraBars.BarButtonItem();
         this.BBI_ReportProduct = new DevExpress.XtraBars.BarButtonItem();
         this.BBI_ReportDesignProduct = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
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
         this.gC_ProductList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_ProductList_Paint);
         this.gC_ProductList.Load += new System.EventHandler(this.gC_ProductList_Load);
         this.gC_ProductList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_ProductList_ProcessGridKey);
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
            this.colBalanceS});
         this.gV_ProductList.CustomizationFormBounds = new System.Drawing.Rectangle(624, 401, 264, 272);
         this.gV_ProductList.GridControl = this.gC_ProductList;
         this.gV_ProductList.Name = "gV_ProductList";
         this.gV_ProductList.OptionsFind.FindDelay = 100;
         this.gV_ProductList.OptionsFind.FindFilterColumns = "ProductDesc";
         this.gV_ProductList.OptionsView.ShowGroupPanel = false;
         this.gV_ProductList.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gV_ProductList_RowCellStyle);
         this.gV_ProductList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_ProductList_RowStyle);
         this.gV_ProductList.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gV_Report_PopupMenuShowing);
         this.gV_ProductList.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gV_ProductList_CalcRowHeight);
         this.gV_ProductList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_ProductList_FocusedRowChanged);
         this.gV_ProductList.ColumnFilterChanged += new System.EventHandler(this.gV_ProductList_ColumnFilterChanged);
         this.gV_ProductList.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gV_ProductList_CustomUnboundColumnData);
         this.gV_ProductList.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.BBI_ProductNew,
            this.btn_ProductEdit,
            this.bBI_ExportExcel,
            this.bBI_quit,
            this.barButtonItem1,
            this.bBI_ProductDelete,
            this.bBI_ProductRefresh,
            this.BBI_Feature,
            this.barButtonItem3,
            this.BarcodePrint,
            this.barButtonItem2,
            this.BBI_query,
            this.BBI_ReportProduct,
            this.BBI_ReportDesignProduct});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 26;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3});
         this.ribbonControl1.Size = new System.Drawing.Size(865, 158);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // BBI_ProductNew
         // 
         this.BBI_ProductNew.Caption = "Yeni";
         this.BBI_ProductNew.Id = 1;
         this.BBI_ProductNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ProductNew.ImageOptions.SvgImage")));
         this.BBI_ProductNew.Name = "BBI_ProductNew";
         this.BBI_ProductNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ProductNew_ItemClick);
         // 
         // btn_ProductEdit
         // 
         this.btn_ProductEdit.Caption = "Dəyiş";
         this.btn_ProductEdit.Id = 2;
         this.btn_ProductEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ProductEdit.ImageOptions.SvgImage")));
         this.btn_ProductEdit.Name = "btn_ProductEdit";
         this.btn_ProductEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_productEdit_ItemClick);
         // 
         // bBI_ExportExcel
         // 
         this.bBI_ExportExcel.Caption = "Excele At";
         this.bBI_ExportExcel.Id = 5;
         this.bBI_ExportExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage")));
         this.bBI_ExportExcel.Name = "bBI_ExportExcel";
         this.bBI_ExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportExcel_ItemClick);
         // 
         // bBI_quit
         // 
         this.bBI_quit.Caption = "Bağla";
         this.bBI_quit.Id = 6;
         this.bBI_quit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_quit.ImageOptions.SvgImage")));
         this.bBI_quit.Name = "bBI_quit";
         this.bBI_quit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_quit_ItemClick);
         // 
         // barButtonItem1
         // 
         this.barButtonItem1.Caption = "Sil";
         this.barButtonItem1.Id = 7;
         this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
         this.barButtonItem1.Name = "barButtonItem1";
         this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
         // 
         // bBI_ProductDelete
         // 
         this.bBI_ProductDelete.Caption = "Sil";
         this.bBI_ProductDelete.Id = 8;
         this.bBI_ProductDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ProductDelete.ImageOptions.SvgImage")));
         this.bBI_ProductDelete.Name = "bBI_ProductDelete";
         this.bBI_ProductDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ProductDelete_ItemClick);
         // 
         // bBI_ProductRefresh
         // 
         this.bBI_ProductRefresh.Caption = "Yenilə";
         this.bBI_ProductRefresh.Id = 9;
         this.bBI_ProductRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ProductRefresh.ImageOptions.SvgImage")));
         this.bBI_ProductRefresh.Name = "bBI_ProductRefresh";
         this.bBI_ProductRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ProductRefresh_ItemClick);
         // 
         // BBI_Feature
         // 
         this.BBI_Feature.Caption = "Ozellik";
         this.BBI_Feature.Id = 13;
         this.BBI_Feature.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Feature.ImageOptions.SvgImage")));
         this.BBI_Feature.Name = "BBI_Feature";
         this.BBI_Feature.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_Feature_ItemClick);
         // 
         // barButtonItem3
         // 
         this.barButtonItem3.Caption = "Məhsulun Bütün Hərəkətləri";
         this.barButtonItem3.Id = 20;
         this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
         this.barButtonItem3.Name = "barButtonItem3";
         this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
         // 
         // BarcodePrint
         // 
         this.BarcodePrint.Caption = "Barkod Çapı";
         this.BarcodePrint.Id = 21;
         this.BarcodePrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BarcodePrint.ImageOptions.SvgImage")));
         this.BarcodePrint.Name = "BarcodePrint";
         this.BarcodePrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarcodePrint_ItemClick);
         // 
         // barButtonItem2
         // 
         this.barButtonItem2.Caption = "Barkod Dizayn";
         this.barButtonItem2.Id = 22;
         this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
         this.barButtonItem2.Name = "barButtonItem2";
         this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
         // 
         // BBI_query
         // 
         this.BBI_query.Caption = "Sorğu";
         this.BBI_query.Id = 23;
         this.BBI_query.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_query.ImageOptions.SvgImage")));
         this.BBI_query.Name = "BBI_query";
         this.BBI_query.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_Query_ItemClick);
         // 
         // BBI_ReportProduct
         // 
         this.BBI_ReportProduct.Caption = "Hesabat";
         this.BBI_ReportProduct.Id = 24;
         this.BBI_ReportProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ReportProduct.ImageOptions.SvgImage")));
         this.BBI_ReportProduct.Name = "BBI_ReportProduct";
         this.BBI_ReportProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ReportProduct_ItemClick);
         // 
         // BBI_ReportDesignProduct
         // 
         this.BBI_ReportDesignProduct.Caption = "Hesabat";
         this.BBI_ReportDesignProduct.Id = 25;
         this.BBI_ReportDesignProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ReportDesignProduct.ImageOptions.SvgImage")));
         this.BBI_ReportDesignProduct.Name = "BBI_ReportDesignProduct";
         this.BBI_ReportDesignProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ReportDesignProduct_ItemClick);
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
         this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
         this.ribbonPageGroup3.ItemLinks.Add(this.BBI_ReportProduct);
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
            this.ribbonPageGroup5});
         this.ribbonPage3.Name = "ribbonPage3";
         this.ribbonPage3.Text = "Ayarlar";
         // 
         // ribbonPageGroup5
         // 
         this.ribbonPageGroup5.ItemLinks.Add(this.BBI_query);
         this.ribbonPageGroup5.ItemLinks.Add(this.BBI_ReportDesignProduct);
         this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
         this.ribbonPageGroup5.Name = "ribbonPageGroup5";
         this.ribbonPageGroup5.Text = "Data";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 639);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(865, 24);
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
         this.Load += new System.EventHandler(this.FormProductList_Load);
         ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl gC_ProductList;
      private DevExpress.XtraGrid.Views.Grid.GridView gV_ProductList;
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
      private DevExpress.XtraBars.BarButtonItem barButtonItem3;
      private DevExpress.XtraBars.BarButtonItem BarcodePrint;
      private DevExpress.XtraBars.BarButtonItem barButtonItem2;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
      private DevExpress.XtraBars.BarButtonItem BBI_query;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
      private DevExpress.XtraBars.BarButtonItem BBI_ReportProduct;
      private DevExpress.XtraBars.BarButtonItem BBI_ReportDesignProduct;
   }
}