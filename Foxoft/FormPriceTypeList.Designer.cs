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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriceTypeList));
            myGridControl1 = new MyGridControl();
            trPriceTypeBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_priceType = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPriceTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_New = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            Əməliyat = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPriceTypeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_priceType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = trPriceTypeBindingSource;
            myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myGridControl1.Location = new System.Drawing.Point(0, 158);
            myGridControl1.MainView = gV_priceType;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new System.Drawing.Size(509, 312);
            myGridControl1.TabIndex = 0;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_priceType });
            myGridControl1.ProcessGridKey += myGridControl1_ProcessGridKey;
            // 
            // trPriceTypeBindingSource
            // 
            trPriceTypeBindingSource.DataSource = typeof(DcPriceType);
            // 
            // gV_priceType
            // 
            gV_priceType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPriceTypeCode, colPriceTypeDesc });
            gV_priceType.DetailHeight = 303;
            gV_priceType.GridControl = myGridControl1;
            gV_priceType.Name = "gV_priceType";
            gV_priceType.OptionsView.ShowGroupPanel = false;
            gV_priceType.FocusedRowChanged += gV_priceType_FocusedRowChanged;
            gV_priceType.ColumnFilterChanged += gV_priceType_ColumnFilterChanged;
            gV_priceType.DoubleClick += gV_priceType_DoubleClick;
            // 
            // colPriceTypeCode
            // 
            colPriceTypeCode.FieldName = "PriceTypeCode";
            colPriceTypeCode.Name = "colPriceTypeCode";
            colPriceTypeCode.Visible = true;
            colPriceTypeCode.VisibleIndex = 0;
            // 
            // colPriceTypeDesc
            // 
            colPriceTypeDesc.FieldName = "PriceTypeDesc";
            colPriceTypeDesc.Name = "colPriceTypeDesc";
            colPriceTypeDesc.Visible = true;
            colPriceTypeDesc.VisibleIndex = 1;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, BBI_New, BBI_Delete, BBI_Refresh, BBI_Edit });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { Əməliyat });
            ribbonControl1.Size = new System.Drawing.Size(509, 158);
            // 
            // BBI_New
            // 
            BBI_New.Caption = "Yeni";
            BBI_New.Id = 1;
            BBI_New.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_New.ImageOptions.SvgImage");
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Sil";
            BBI_Delete.Id = 2;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = "Yenilə";
            BBI_Refresh.Id = 3;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Refresh.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = "Dəyiş";
            BBI_Edit.Id = 4;
            BBI_Edit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Edit.ImageOptions.SvgImage");
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // Əməliyat
            // 
            Əməliyat.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            Əməliyat.Name = "Əməliyat";
            Əməliyat.Text = "Qiymət Tipi";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyat";
            // 
            // FormPriceTypeList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(509, 470);
            Controls.Add(myGridControl1);
            Controls.Add(ribbonControl1);
            Name = "FormPriceTypeList";
            Ribbon = ribbonControl1;
            Text = "1 c";
            Activated += FormPriceTypeList_Activated;
            Load += FormPriceTypeList_Load;
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPriceTypeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_priceType).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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