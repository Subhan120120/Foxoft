using Foxoft.Models;

namespace Foxoft
{
    partial class FormPriceTypeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriceTypeList));
            this.myGridControl1 = new Foxoft.MyGridControl();
            this.trPriceTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_priceType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriceTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BBI_New = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.Əməliyat = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_priceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // myGridControl1
            // 
            this.myGridControl1.DataSource = this.trPriceTypeBindingSource;
            this.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridControl1.Location = new System.Drawing.Point(0, 158);
            this.myGridControl1.MainView = this.gV_priceType;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(509, 312);
            this.myGridControl1.TabIndex = 0;
            this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_priceType});
            // 
            // trPriceTypeBindingSource
            // 
            this.trPriceTypeBindingSource.DataSource = typeof(Foxoft.Models.DcPriceType);
            // 
            // gV_priceType
            // 
            this.gV_priceType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriceTypeCode,
            this.colPriceTypeDesc});
            this.gV_priceType.DetailHeight = 303;
            this.gV_priceType.GridControl = this.myGridControl1;
            this.gV_priceType.Name = "gV_priceType";
            this.gV_priceType.OptionsView.ShowGroupPanel = false;
            // 
            // colPriceTypeCode
            // 
            this.colPriceTypeCode.FieldName = "PriceTypeCode";
            this.colPriceTypeCode.Name = "colPriceTypeCode";
            this.colPriceTypeCode.Visible = true;
            this.colPriceTypeCode.VisibleIndex = 0;
            // 
            // colPriceTypeDesc
            // 
            this.colPriceTypeDesc.FieldName = "PriceTypeDesc";
            this.colPriceTypeDesc.Name = "colPriceTypeDesc";
            this.colPriceTypeDesc.Visible = true;
            this.colPriceTypeDesc.VisibleIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BBI_New,
            this.BBI_Delete,
            this.BBI_Refresh,
            this.BBI_Edit});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.Əməliyat});
            this.ribbonControl1.Size = new System.Drawing.Size(509, 158);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // BBI_New
            // 
            this.BBI_New.Caption = "Yeni";
            this.BBI_New.Id = 1;
            this.BBI_New.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_New.ImageOptions.SvgImage")));
            this.BBI_New.Name = "BBI_New";
            // 
            // BBI_Delete
            // 
            this.BBI_Delete.Caption = "Sil";
            this.BBI_Delete.Id = 2;
            this.BBI_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Delete.ImageOptions.SvgImage")));
            this.BBI_Delete.Name = "BBI_Delete";
            // 
            // BBI_Refresh
            // 
            this.BBI_Refresh.Caption = "Yenilə";
            this.BBI_Refresh.Id = 3;
            this.BBI_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Refresh.ImageOptions.SvgImage")));
            this.BBI_Refresh.Name = "BBI_Refresh";
            // 
            // BBI_Edit
            // 
            this.BBI_Edit.Caption = "Dəyiş";
            this.BBI_Edit.Id = 4;
            this.BBI_Edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Edit.ImageOptions.SvgImage")));
            this.BBI_Edit.Name = "BBI_Edit";
            // 
            // Əməliyat
            // 
            this.Əməliyat.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.Əməliyat.Name = "Əməliyat";
            this.Əməliyat.Text = "Qiymət Tipi";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_New);
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_Edit);
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_Delete);
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_Refresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Əməliyat";
            // 
            // FormPriceTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 470);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormPriceTypeList";
            this.Ribbon = this.ribbonControl1;
            this.Text = "1 c";
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_priceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_priceType;
        private System.Windows.Forms.BindingSource trPriceTypeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIsConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceTypeDesc;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage Əməliyat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
    }
}