
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductList));
            this.gC_ProductList = new DevExpress.XtraGrid.GridControl();
            this.gV_ProductList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_ProductList
            // 
            this.gC_ProductList.DataMember = "DcProduct";
            this.gC_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_ProductList.Location = new System.Drawing.Point(0, 158);
            this.gC_ProductList.MainView = this.gV_ProductList;
            this.gC_ProductList.Name = "gC_ProductList";
            this.gC_ProductList.Size = new System.Drawing.Size(865, 358);
            this.gC_ProductList.TabIndex = 0;
            this.gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_ProductList});
            // 
            // gV_ProductList
            // 
            this.gV_ProductList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductCode,
            this.colBarcode,
            this.colProductTypeCode,
            this.colUsePos,
            this.colPromotionCode,
            this.colPromotionCode2,
            this.colTaxRate,
            this.colIsDisabled,
            this.colPosDiscountRate,
            this.colRetailPrice,
            this.colProductDescription});
            this.gV_ProductList.GridControl = this.gC_ProductList;
            this.gV_ProductList.Name = "gV_ProductList";
            this.gV_ProductList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_ProductList_FocusedRowChanged);
            this.gV_ProductList.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            this.colProductCode.Width = 82;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 2;
            this.colBarcode.Width = 56;
            // 
            // colProductTypeCode
            // 
            this.colProductTypeCode.FieldName = "ProductTypeCode";
            this.colProductTypeCode.Name = "colProductTypeCode";
            this.colProductTypeCode.Width = 93;
            // 
            // colUsePos
            // 
            this.colUsePos.FieldName = "UsePos";
            this.colUsePos.Name = "colUsePos";
            this.colUsePos.Width = 50;
            // 
            // colPromotionCode
            // 
            this.colPromotionCode.FieldName = "PromotionCode";
            this.colPromotionCode.Name = "colPromotionCode";
            this.colPromotionCode.Visible = true;
            this.colPromotionCode.VisibleIndex = 5;
            this.colPromotionCode.Width = 50;
            // 
            // colPromotionCode2
            // 
            this.colPromotionCode2.FieldName = "PromotionCode2";
            this.colPromotionCode2.Name = "colPromotionCode2";
            this.colPromotionCode2.Visible = true;
            this.colPromotionCode2.VisibleIndex = 6;
            this.colPromotionCode2.Width = 50;
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 7;
            this.colTaxRate.Width = 50;
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            this.colIsDisabled.Width = 50;
            // 
            // colPosDiscountRate
            // 
            this.colPosDiscountRate.FieldName = "PosDiscountRate";
            this.colPosDiscountRate.Name = "colPosDiscountRate";
            this.colPosDiscountRate.Visible = true;
            this.colPosDiscountRate.VisibleIndex = 4;
            this.colPosDiscountRate.Width = 53;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.FieldName = "TrPrices.Price";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 3;
            this.colRetailPrice.Width = 54;
            // 
            // colProductDescription
            // 
            this.colProductDescription.FieldName = "ProductDescription";
            this.colProductDescription.Name = "colProductDescription";
            this.colProductDescription.Visible = true;
            this.colProductDescription.VisibleIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.BBI_ProductNew,
            this.btn_ProductEdit});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
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
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
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
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_ProductList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_ProductList;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Barcode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsePos;
        private DevExpress.XtraGrid.Columns.GridColumn col_PromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn col_TaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn col_IsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn col_PosDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn col_RetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUsePos;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductNew;
        private DevExpress.XtraBars.BarButtonItem btn_ProductEdit;
    }
}