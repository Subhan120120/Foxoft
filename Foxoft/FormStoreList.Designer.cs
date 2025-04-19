namespace Foxoft
{
    partial class FormStoreList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStoreList));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_New = new DevExpress.XtraBars.BarButtonItem();
            BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gC_StoreList = new DevExpress.XtraGrid.GridControl();
            dcStoresBindingSource = new BindingSource(components);
            gV_StoreList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gC_StoreList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcStoresBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_StoreList).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_New, BBI_Edit, BBI_Refresh, BBI_Delete, BBI_ExportXlsx });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(800, 158);
            // 
            // BBI_New
            // 
            BBI_New.Caption = "Yeni";
            BBI_New.Id = 1;
            BBI_New.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_New.ImageOptions.SvgImage");
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = "Dəyiş";
            BBI_Edit.Id = 2;
            BBI_Edit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Edit.ImageOptions.SvgImage");
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = "Yenilə";
            BBI_Refresh.Id = 3;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Refresh.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Sil";
            BBI_Delete.Id = 4;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_ExportXlsx
            // 
            BBI_ExportXlsx.Caption = "Excelə Göndər";
            BBI_ExportXlsx.Id = 5;
            BBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ExportXlsx.ImageOptions.SvgImage");
            BBI_ExportXlsx.Name = "BBI_ExportXlsx";
            BBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Export";
            // 
            // gC_StoreList
            // 
            gC_StoreList.DataSource = dcStoresBindingSource;
            gC_StoreList.Dock = DockStyle.Fill;
            gC_StoreList.Location = new Point(0, 158);
            gC_StoreList.MainView = gV_StoreList;
            gC_StoreList.MenuManager = ribbonControl1;
            gC_StoreList.Name = "gC_StoreList";
            gC_StoreList.Size = new Size(800, 292);
            gC_StoreList.TabIndex = 1;
            gC_StoreList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_StoreList });
            gC_StoreList.ProcessGridKey += GC_StoreList_ProcessGridKey;
            // 
            // dcStoresBindingSource
            // 
            dcStoresBindingSource.DataSource = typeof(Models.DcCurrAcc);
            // 
            // gV_StoreList
            // 
            gV_StoreList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCurrAccCode, colCurrAccDesc, colCompanyCode, colOfficeCode, colStoreCode, colIsDisabled, colAddress, colPhoneNum });
            gV_StoreList.GridControl = gC_StoreList;
            gV_StoreList.Name = "gV_StoreList";
            gV_StoreList.OptionsView.ShowGroupPanel = false;
            gV_StoreList.FocusedRowChanged += gV_StoreList_FocusedRowChanged;
            gV_StoreList.ColumnFilterChanged += gV_StoreList_ColumnFilterChanged;
            gV_StoreList.DoubleClick += gV_StoreList_DoubleClick;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 0;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 1;
            // 
            // colCompanyCode
            // 
            colCompanyCode.FieldName = "CompanyCode";
            colCompanyCode.Name = "colCompanyCode";
            colCompanyCode.Visible = true;
            colCompanyCode.VisibleIndex = 2;
            // 
            // colOfficeCode
            // 
            colOfficeCode.FieldName = "OfficeCode";
            colOfficeCode.Name = "colOfficeCode";
            colOfficeCode.Visible = true;
            colOfficeCode.VisibleIndex = 3;
            // 
            // colStoreCode
            // 
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.Visible = true;
            colStoreCode.VisibleIndex = 4;
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            colIsDisabled.Visible = true;
            colIsDisabled.VisibleIndex = 5;
            // 
            // colAddress
            // 
            colAddress.FieldName = "Address";
            colAddress.Name = "colAddress";
            colAddress.Visible = true;
            colAddress.VisibleIndex = 6;
            // 
            // colPhoneNum
            // 
            colPhoneNum.FieldName = "PhoneNum";
            colPhoneNum.Name = "colPhoneNum";
            colPhoneNum.Visible = true;
            colPhoneNum.VisibleIndex = 7;
            // 
            // FormStoreList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gC_StoreList);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormStoreList";
            Ribbon = ribbonControl1;
            Text = "Form1";
            KeyDown += FormStoreList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gC_StoreList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcStoresBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_StoreList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_StoreList;
        private BindingSource dcStoresBindingSource;
        private DevExpress.XtraGrid.GridControl gC_StoreList;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNum;
        private DevExpress.XtraBars.BarButtonItem BBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}