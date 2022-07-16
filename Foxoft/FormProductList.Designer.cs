﻿
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
            this.gV_ProductList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_ProductList
            // 
            this.gC_ProductList.DataSource = this.dcProductsBindingSource;
            this.gC_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_ProductList.Location = new System.Drawing.Point(0, 158);
            this.gC_ProductList.MainView = this.gV_ProductList;
            this.gC_ProductList.Name = "gC_ProductList";
            this.gC_ProductList.Size = new System.Drawing.Size(865, 358);
            this.gC_ProductList.TabIndex = 0;
            this.gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_ProductList});
            this.gC_ProductList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_ProductList_Paint);
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
            this.colLastUpdatedDate});
            this.gV_ProductList.CustomizationFormBounds = new System.Drawing.Rectangle(624, 401, 264, 272);
            this.gV_ProductList.GridControl = this.gC_ProductList;
            this.gV_ProductList.Name = "gV_ProductList";
            this.gV_ProductList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_ProductList_FocusedRowChanged);
            this.gV_ProductList.ColumnFilterChanged += new System.EventHandler(this.gV_ProductList_ColumnFilterChanged);
            this.gV_ProductList.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(865, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // BBI_ProductNew
            // 
            this.BBI_ProductNew.Caption = "Yeni Məhsul";
            this.BBI_ProductNew.Id = 1;
            this.BBI_ProductNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ProductNew.ImageOptions.SvgImage")));
            this.BBI_ProductNew.Name = "BBI_ProductNew";
            this.BBI_ProductNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ProductNew_ItemClick);
            // 
            // btn_ProductEdit
            // 
            this.btn_ProductEdit.Caption = "Məhsulu Dəyiş";
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
            this.barButtonItem1.Caption = "Test";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_ProductNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_ProductEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_ExportExcel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Mehsul";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Test";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 516);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(865, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // dcProductsBindingSource
            // 
            this.dcProductsBindingSource.DataSource = typeof(Foxoft.Models.DcProduct);
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            // 
            // colProductDesc
            // 
            this.colProductDesc.FieldName = "ProductDesc";
            this.colProductDesc.Name = "colProductDesc";
            this.colProductDesc.Visible = true;
            this.colProductDesc.VisibleIndex = 1;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 2;
            // 
            // colProductTypeCode
            // 
            this.colProductTypeCode.FieldName = "ProductTypeCode";
            this.colProductTypeCode.Name = "colProductTypeCode";
            this.colProductTypeCode.Visible = true;
            this.colProductTypeCode.VisibleIndex = 3;
            // 
            // colUsePos
            // 
            this.colUsePos.FieldName = "UsePos";
            this.colUsePos.Name = "colUsePos";
            this.colUsePos.Visible = true;
            this.colUsePos.VisibleIndex = 4;
            // 
            // colPromotionCode
            // 
            this.colPromotionCode.FieldName = "PromotionCode";
            this.colPromotionCode.Name = "colPromotionCode";
            this.colPromotionCode.Visible = true;
            this.colPromotionCode.VisibleIndex = 5;
            // 
            // colPromotionCode2
            // 
            this.colPromotionCode2.FieldName = "PromotionCode2";
            this.colPromotionCode2.Name = "colPromotionCode2";
            this.colPromotionCode2.Visible = true;
            this.colPromotionCode2.VisibleIndex = 6;
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 7;
            // 
            // colPosDiscount
            // 
            this.colPosDiscount.FieldName = "PosDiscount";
            this.colPosDiscount.Name = "colPosDiscount";
            this.colPosDiscount.Visible = true;
            this.colPosDiscount.VisibleIndex = 8;
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            this.colIsDisabled.Visible = true;
            this.colIsDisabled.VisibleIndex = 9;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 10;
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.FieldName = "PurchasePrice";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.Visible = true;
            this.colPurchasePrice.VisibleIndex = 11;
            // 
            // colWholesalePrice
            // 
            this.colWholesalePrice.FieldName = "WholesalePrice";
            this.colWholesalePrice.Name = "colWholesalePrice";
            this.colWholesalePrice.Visible = true;
            this.colWholesalePrice.VisibleIndex = 12;
            // 
            // colUseInternet
            // 
            this.colUseInternet.FieldName = "UseInternet";
            this.colUseInternet.Name = "colUseInternet";
            this.colUseInternet.Visible = true;
            this.colUseInternet.VisibleIndex = 13;
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 14;
            // 
            // colLastPurchasePrice
            // 
            this.colLastPurchasePrice.FieldName = "LastPurchasePrice";
            this.colLastPurchasePrice.Name = "colLastPurchasePrice";
            this.colLastPurchasePrice.Visible = true;
            this.colLastPurchasePrice.VisibleIndex = 15;
            // 
            // colLastSalePrice
            // 
            this.colLastSalePrice.FieldName = "LastSalePrice";
            this.colLastSalePrice.Name = "colLastSalePrice";
            this.colLastSalePrice.Visible = true;
            this.colLastSalePrice.VisibleIndex = 16;
            // 
            // colDcProductType
            // 
            this.colDcProductType.FieldName = "DcProductType";
            this.colDcProductType.Name = "colDcProductType";
            this.colDcProductType.Visible = true;
            this.colDcProductType.VisibleIndex = 17;
            // 
            // colTrPrices
            // 
            this.colTrPrices.FieldName = "TrPrices";
            this.colTrPrices.Name = "colTrPrices";
            this.colTrPrices.Visible = true;
            this.colTrPrices.VisibleIndex = 18;
            // 
            // colTrInvoiceLines
            // 
            this.colTrInvoiceLines.FieldName = "TrInvoiceLines";
            this.colTrInvoiceLines.Name = "colTrInvoiceLines";
            this.colTrInvoiceLines.Visible = true;
            this.colTrInvoiceLines.VisibleIndex = 19;
            // 
            // colTrFeature
            // 
            this.colTrFeature.FieldName = "TrFeature";
            this.colTrFeature.Name = "colTrFeature";
            this.colTrFeature.Visible = true;
            this.colTrFeature.VisibleIndex = 20;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 21;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 22;
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            this.colLastUpdatedUserName.Visible = true;
            this.colLastUpdatedUserName.VisibleIndex = 23;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 24;
            // 
            // FormProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 540);
            this.Controls.Add(this.gC_ProductList);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormProductList";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "FormProductList";
            this.Load += new System.EventHandler(this.FormProductList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).EndInit();
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
    }
}