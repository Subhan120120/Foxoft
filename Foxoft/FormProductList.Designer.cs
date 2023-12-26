
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductList));
            gC_ProductList = new MyGridControl();
            gV_ProductList = new MyGridView(this);
            dcProductsBindingSource = new System.Windows.Forms.BindingSource(components);
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            colPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colWholesalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colUseInternet = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colDcProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrPrices = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrInvoiceLines = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrFeature = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceF = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceM = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceS = new DevExpress.XtraGrid.Columns.GridColumn();
            colHierarchyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
            btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bBI_quit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ProductDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_ProductRefresh = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            BBI_query = new DevExpress.XtraBars.BarButtonItem();
            BSI_Report = new DevExpress.XtraBars.BarSubItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            txtEdit_filtercolumns = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            BBI_Save = new DevExpress.XtraBars.BarButtonItem();
            BBI_Show = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            svgImageCollection1 = new SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)gC_ProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_ProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // gC_ProductList
            // 
            gC_ProductList.DataSource = dcProductsBindingSource;
            gC_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_ProductList.Location = new System.Drawing.Point(0, 158);
            gC_ProductList.MainView = gV_ProductList;
            gC_ProductList.Name = "gC_ProductList";
            gC_ProductList.Size = new System.Drawing.Size(865, 481);
            gC_ProductList.TabIndex = 0;
            gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_ProductList });
            // 
            // gV_ProductList
            // 
            gV_ProductList.GridControl = gC_ProductList;
            gV_ProductList.Name = "gV_ProductList";
            // 
            // colProductCode
            // 
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            colProductCode.Width = 77;
            // 
            // colProductDesc
            // 
            colProductDesc.FieldName = "ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 1;
            colProductDesc.Width = 417;
            // 
            // colBarcode
            // 
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
            // 
            // colProductTypeCode
            // 
            colProductTypeCode.FieldName = "ProductTypeCode";
            colProductTypeCode.Name = "colProductTypeCode";
            // 
            // colUsePos
            // 
            colUsePos.FieldName = "UsePos";
            colUsePos.Name = "colUsePos";
            // 
            // colPromotionCode
            // 
            colPromotionCode.FieldName = "PromotionCode";
            colPromotionCode.Name = "colPromotionCode";
            // 
            // colPromotionCode2
            // 
            colPromotionCode2.FieldName = "PromotionCode2";
            colPromotionCode2.Name = "colPromotionCode2";
            // 
            // colTaxRate
            // 
            colTaxRate.FieldName = "TaxRate";
            colTaxRate.Name = "colTaxRate";
            // 
            // colPosDiscount
            // 
            colPosDiscount.FieldName = "PosDiscount";
            colPosDiscount.Name = "colPosDiscount";
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            // 
            // colRetailPrice
            // 
            colRetailPrice.FieldName = "RetailPrice";
            colRetailPrice.Name = "colRetailPrice";
            // 
            // colPurchasePrice
            // 
            colPurchasePrice.FieldName = "PurchasePrice";
            colPurchasePrice.Name = "colPurchasePrice";
            // 
            // colWholesalePrice
            // 
            colWholesalePrice.FieldName = "WholesalePrice";
            colWholesalePrice.Name = "colWholesalePrice";
            colWholesalePrice.Visible = true;
            colWholesalePrice.VisibleIndex = 6;
            colWholesalePrice.Width = 122;
            // 
            // colUseInternet
            // 
            colUseInternet.FieldName = "UseInternet";
            colUseInternet.Name = "colUseInternet";
            // 
            // colBalance
            // 
            colBalance.FieldName = "Balance";
            colBalance.Name = "colBalance";
            // 
            // colLastPurchasePrice
            // 
            colLastPurchasePrice.DisplayFormat.FormatString = "{0:n2}";
            colLastPurchasePrice.DisplayFormat.FormatType = FormatType.Numeric;
            colLastPurchasePrice.FieldName = "LastPurchasePrice";
            colLastPurchasePrice.Name = "colLastPurchasePrice";
            colLastPurchasePrice.Visible = true;
            colLastPurchasePrice.VisibleIndex = 5;
            colLastPurchasePrice.Width = 105;
            // 
            // colLastSalePrice
            // 
            colLastSalePrice.FieldName = "LastSalePrice";
            colLastSalePrice.Name = "colLastSalePrice";
            // 
            // colDcProductType
            // 
            colDcProductType.FieldName = "DcProductType";
            colDcProductType.Name = "colDcProductType";
            // 
            // colTrPrices
            // 
            colTrPrices.FieldName = "TrPrices";
            colTrPrices.Name = "colTrPrices";
            // 
            // colTrInvoiceLines
            // 
            colTrInvoiceLines.FieldName = "TrInvoiceLines";
            colTrInvoiceLines.Name = "colTrInvoiceLines";
            // 
            // colTrFeature
            // 
            colTrFeature.FieldName = "TrFeature";
            colTrFeature.Name = "colTrFeature";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colBalanceF
            // 
            colBalanceF.FieldName = "BalanceF";
            colBalanceF.Name = "colBalanceF";
            colBalanceF.Visible = true;
            colBalanceF.VisibleIndex = 3;
            colBalanceF.Width = 85;
            // 
            // colBalanceM
            // 
            colBalanceM.FieldName = "BalanceM";
            colBalanceM.Name = "colBalanceM";
            colBalanceM.Visible = true;
            colBalanceM.VisibleIndex = 2;
            colBalanceM.Width = 87;
            // 
            // colBalanceS
            // 
            colBalanceS.FieldName = "BalanceS";
            colBalanceS.Name = "colBalanceS";
            colBalanceS.Visible = true;
            colBalanceS.VisibleIndex = 4;
            // 
            // colHierarchyCode
            // 
            colHierarchyCode.Caption = "gridColumn1";
            colHierarchyCode.FieldName = "HierarchyCode";
            colHierarchyCode.Name = "colHierarchyCode";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, BBI_ProductNew, btn_ProductEdit, bBI_ExportExcel, bBI_quit, bBI_ProductDelete, bBI_ProductRefresh, barButtonItem2, BBI_query, BSI_Report, barButtonItem4, txtEdit_filtercolumns, BBI_Save, BBI_Show });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 37;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.PageHeaderItemLinks.Add(bBI_quit);
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage3 });
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1 });
            ribbonControl1.Size = new System.Drawing.Size(865, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // BBI_ProductNew
            // 
            BBI_ProductNew.Caption = "Yeni";
            BBI_ProductNew.Id = 1;
            BBI_ProductNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductNew.ImageOptions.SvgImage");
            BBI_ProductNew.Name = "BBI_ProductNew";
            // 
            // btn_ProductEdit
            // 
            btn_ProductEdit.Caption = "Dəyiş";
            btn_ProductEdit.Id = 2;
            btn_ProductEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ProductEdit.ImageOptions.SvgImage");
            btn_ProductEdit.Name = "btn_ProductEdit";
            // 
            // bBI_ExportExcel
            // 
            bBI_ExportExcel.Caption = "Excele At";
            bBI_ExportExcel.Id = 5;
            bBI_ExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage");
            bBI_ExportExcel.Name = "bBI_ExportExcel";
            // 
            // bBI_quit
            // 
            bBI_quit.Caption = "Bağla";
            bBI_quit.Id = 6;
            bBI_quit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_quit.ImageOptions.SvgImage");
            bBI_quit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            bBI_quit.Name = "bBI_quit";
            // 
            // bBI_ProductDelete
            // 
            bBI_ProductDelete.Caption = "Sil";
            bBI_ProductDelete.Id = 8;
            bBI_ProductDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ProductDelete.ImageOptions.SvgImage");
            bBI_ProductDelete.Name = "bBI_ProductDelete";
            // 
            // bBI_ProductRefresh
            // 
            bBI_ProductRefresh.Caption = "Yenilə";
            bBI_ProductRefresh.Id = 9;
            bBI_ProductRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ProductRefresh.ImageOptions.SvgImage");
            bBI_ProductRefresh.Name = "bBI_ProductRefresh";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Barkod Dizayn";
            barButtonItem2.Id = 22;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            // 
            // BBI_query
            // 
            BBI_query.Caption = "Sorğu";
            BBI_query.Id = 23;
            BBI_query.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_query.ImageOptions.SvgImage");
            BBI_query.Name = "BBI_query";
            // 
            // BSI_Report
            // 
            BSI_Report.Caption = "Hesabat";
            BSI_Report.Id = 27;
            BSI_Report.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Report.ImageOptions.SvgImage");
            BSI_Report.Name = "BSI_Report";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "test";
            barButtonItem4.Id = 28;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // txtEdit_filtercolumns
            // 
            txtEdit_filtercolumns.Caption = "filter columns";
            txtEdit_filtercolumns.Edit = repositoryItemTextEdit1;
            txtEdit_filtercolumns.Id = 34;
            txtEdit_filtercolumns.Name = "txtEdit_filtercolumns";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // BBI_Save
            // 
            BBI_Save.Caption = "Save";
            BBI_Save.Id = 35;
            BBI_Save.Name = "BBI_Save";
            // 
            // BBI_Show
            // 
            BBI_Show.Caption = "Show";
            BBI_Show.Id = 36;
            BBI_Show.Name = "BBI_Show";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Məhsul";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_ProductNew);
            ribbonPageGroup1.ItemLinks.Add(btn_ProductEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_ProductDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_ProductRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportExcel);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Nəzarət";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(BSI_Report);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Hesabat";
            // 
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5, ribbonPageGroup6 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "Ayarlar";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(BBI_query);
            ribbonPageGroup5.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Data";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(txtEdit_filtercolumns);
            ribbonPageGroup6.ItemLinks.Add(BBI_Show);
            ribbonPageGroup6.ItemLinks.Add(BBI_Save);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Filter Columns";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 639);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(865, 24);
            // 
            // popupMenu1
            // 
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbonControl1;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("report", "image://svgimages/business objects/bo_report.svg");
            // 
            // FormProductList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(865, 663);
            Controls.Add(gC_ProductList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormProductList";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            StatusBar = ribbonStatusBar1;
            Text = "Məhsul Siyahısı";
            ((System.ComponentModel.ISupportInitialize)gC_ProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_ProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
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
        private SvgImageCollection svgImageCollection1;
    }
}