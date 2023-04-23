
using DevExpress.Utils;

namespace Foxoft
{
    partial class FormFeatureList
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
            this.gC_FeatureList = new DevExpress.XtraGrid.GridControl();
            this.dcFeaturesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_FeatureList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FeatureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FeatureDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_FeatureNew = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Report1 = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_FeatureDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_CurAccRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gC_FeatureList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcFeaturesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_FeatureList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_FeatureList
            // 
            this.gC_FeatureList.DataSource = this.dcFeaturesBindingSource;
            this.gC_FeatureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_FeatureList.Location = new System.Drawing.Point(0, 158);
            this.gC_FeatureList.MainView = this.gV_FeatureList;
            this.gC_FeatureList.Name = "gC_FeatureList";
            this.gC_FeatureList.Size = new System.Drawing.Size(858, 413);
            this.gC_FeatureList.TabIndex = 0;
            this.gC_FeatureList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_FeatureList});
            this.gC_FeatureList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_FeatureList_Paint);
            this.gC_FeatureList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_FeatureList_ProcessGridKey);
            // 
            // gV_FeatureList
            // 
            this.gV_FeatureList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate,
            this.col_FeatureCode,
            this.col_FeatureDesc});
            this.gV_FeatureList.CustomizationFormBounds = new System.Drawing.Rectangle(760, 248, 264, 272);
            this.gV_FeatureList.GridControl = this.gC_FeatureList;
            this.gV_FeatureList.Name = "gV_FeatureList";
            this.gV_FeatureList.OptionsFind.FindDelay = 100;
            this.gV_FeatureList.OptionsView.ShowGroupPanel = false;
            this.gV_FeatureList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_FeatureList_FocusedRowChanged);
            this.gV_FeatureList.ColumnFilterChanged += new System.EventHandler(this.gV_FeatureList_ColumnFilterChanged);
            this.gV_FeatureList.DoubleClick += new System.EventHandler(this.gV_FeatureList_DoubleClick);
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
            // col_FeatureCode
            // 
            this.col_FeatureCode.FieldName = "FeatureCode";
            this.col_FeatureCode.Name = "col_FeatureCode";
            this.col_FeatureCode.Visible = true;
            this.col_FeatureCode.VisibleIndex = 0;
            // 
            // col_FeatureDesc
            // 
            this.col_FeatureDesc.FieldName = "FeatureDesc";
            this.col_FeatureDesc.Name = "col_FeatureDesc";
            this.col_FeatureDesc.Visible = true;
            this.col_FeatureDesc.VisibleIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_FeatureNew,
            this.bBI_CurAccEdit,
            this.bBI_quit,
            this.bBI_Report1,
            this.bBI_ExportXlsx,
            this.bBI_FeatureDelete,
            this.bBI_CurAccRefresh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(858, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bBI_FeatureNew
            // 
            this.bBI_FeatureNew.Caption = "Yeni";
            this.bBI_FeatureNew.Id = 1;
            this.bBI_FeatureNew.Name = "bBI_FeatureNew";
            this.bBI_FeatureNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_FeatureNew_ItemClick);
            // 
            // bBI_CurAccEdit
            // 
            this.bBI_CurAccEdit.Caption = "Dəyiş";
            this.bBI_CurAccEdit.Id = 2;
            this.bBI_CurAccEdit.Name = "bBI_CurAccEdit";
            this.bBI_CurAccEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_FeatureEdit_ItemClick);
            // 
            // bBI_quit
            // 
            this.bBI_quit.Caption = "Bağla";
            this.bBI_quit.Id = 4;
            this.bBI_quit.Name = "bBI_quit";
            this.bBI_quit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_quit_ItemClick);
            // 
            // bBI_Report1
            // 
            this.bBI_Report1.Caption = "Müştəri ilə Haqq Hesab";
            this.bBI_Report1.Id = 5;
            this.bBI_Report1.Name = "bBI_Report1";
            this.bBI_Report1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Report1_ItemClick);
            // 
            // bBI_ExportXlsx
            // 
            this.bBI_ExportXlsx.Caption = "Excelə Göndər";
            this.bBI_ExportXlsx.Id = 6;
            this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
            // 
            // bBI_FeatureDelete
            // 
            this.bBI_FeatureDelete.Caption = "Sil";
            this.bBI_FeatureDelete.Id = 7;
            this.bBI_FeatureDelete.Name = "bBI_FeatureDelete";
            this.bBI_FeatureDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_FeatureDelete_ItemClick);
            // 
            // bBI_CurAccRefresh
            // 
            this.bBI_CurAccRefresh.Caption = "Yenilə";
            this.bBI_CurAccRefresh.Id = 8;
            this.bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
            this.bBI_CurAccRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_FeatureRefresh_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Depo";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_FeatureNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_FeatureDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bBI_Report1);
            this.ribbonPageGroup3.ItemLinks.Add(this.bBI_ExportXlsx);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hesabat";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 571);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(858, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // FormFeatureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 595);
            this.Controls.Add(this.gC_FeatureList);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormFeatureList";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Özəlliklər Siyahısı";
            ((System.ComponentModel.ISupportInitialize)(this.gC_FeatureList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcFeaturesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_FeatureList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_FeatureList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_FeatureList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_FeatureNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_quit;
        private DevExpress.XtraBars.BarButtonItem bBI_Report1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private System.Windows.Forms.BindingSource dcFeaturesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraBars.BarButtonItem bBI_FeatureDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn col_FeatureCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_FeatureDesc;
    }
}