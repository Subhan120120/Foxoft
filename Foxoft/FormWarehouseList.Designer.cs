
using DevExpress.Utils;

namespace Foxoft
{
   partial class FormWarehouseList
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
         this.gC_WarehouseList = new DevExpress.XtraGrid.GridControl();
         this.dcWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_WarehouseList = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_WarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_WarehouseDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_WarehouseNew = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Report1 = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_WarehouseDelete = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurAccRefresh = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_WarehouseList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcWarehousesBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_WarehouseList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_WarehouseList
         // 
         this.gC_WarehouseList.DataSource = this.dcWarehousesBindingSource;
         this.gC_WarehouseList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_WarehouseList.Location = new System.Drawing.Point(0, 158);
         this.gC_WarehouseList.MainView = this.gV_WarehouseList;
         this.gC_WarehouseList.Name = "gC_WarehouseList";
         this.gC_WarehouseList.Size = new System.Drawing.Size(858, 413);
         this.gC_WarehouseList.TabIndex = 0;
         this.gC_WarehouseList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_WarehouseList});
         this.gC_WarehouseList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_WarehouseList_Paint);
         this.gC_WarehouseList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_WarehouseList_ProcessGridKey);
         // 
         // gV_WarehouseList
         // 
         this.gV_WarehouseList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate,
            this.col_WarehouseCode,
            this.col_WarehouseDesc});
         this.gV_WarehouseList.CustomizationFormBounds = new System.Drawing.Rectangle(760, 248, 264, 272);
         this.gV_WarehouseList.GridControl = this.gC_WarehouseList;
         this.gV_WarehouseList.Name = "gV_WarehouseList";
         this.gV_WarehouseList.OptionsFind.FindDelay = 100;
         this.gV_WarehouseList.OptionsView.ShowGroupPanel = false;
         this.gV_WarehouseList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_WarehouseList_FocusedRowChanged);
         this.gV_WarehouseList.ColumnFilterChanged += new System.EventHandler(this.gV_WarehouseList_ColumnFilterChanged);
         this.gV_WarehouseList.DoubleClick += new System.EventHandler(this.gV_WarehouseList_DoubleClick);
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
         // col_WarehouseCode
         // 
         this.col_WarehouseCode.FieldName = "WarehouseCode";
         this.col_WarehouseCode.Name = "col_WarehouseCode";
         this.col_WarehouseCode.Visible = true;
         this.col_WarehouseCode.VisibleIndex = 0;
         // 
         // col_WarehouseDesc
         // 
         this.col_WarehouseDesc.FieldName = "WarehouseDesc";
         this.col_WarehouseDesc.Name = "col_WarehouseDesc";
         this.col_WarehouseDesc.Visible = true;
         this.col_WarehouseDesc.VisibleIndex = 1;
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_WarehouseNew,
            this.bBI_CurAccEdit,
            this.bBI_quit,
            this.bBI_Report1,
            this.bBI_ExportXlsx,
            this.bBI_WarehouseDelete,
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
         // bBI_WarehouseNew
         // 
         this.bBI_WarehouseNew.Caption = "Yeni";
         this.bBI_WarehouseNew.Id = 1;
         this.bBI_WarehouseNew.Name = "bBI_WarehouseNew";
         this.bBI_WarehouseNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_WarehouseNew_ItemClick);
         // 
         // bBI_CurAccEdit
         // 
         this.bBI_CurAccEdit.Caption = "Dəyiş";
         this.bBI_CurAccEdit.Id = 2;
         this.bBI_CurAccEdit.Name = "bBI_CurAccEdit";
         this.bBI_CurAccEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_WarehouseEdit_ItemClick);
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
         // bBI_WarehouseDelete
         // 
         this.bBI_WarehouseDelete.Caption = "Sil";
         this.bBI_WarehouseDelete.Id = 7;
         this.bBI_WarehouseDelete.Name = "bBI_WarehouseDelete";
         this.bBI_WarehouseDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_WarehouseDelete_ItemClick);
         // 
         // bBI_CurAccRefresh
         // 
         this.bBI_CurAccRefresh.Caption = "Yenilə";
         this.bBI_CurAccRefresh.Id = 8;
         this.bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
         this.bBI_CurAccRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_WarehouseRefresh_ItemClick);
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
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_WarehouseNew);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccEdit);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_WarehouseDelete);
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
         // FormWarehouseList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(858, 595);
         this.Controls.Add(this.gC_WarehouseList);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormWarehouseList";
         this.Ribbon = this.ribbonControl1;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Cari Hesablar";
         ((System.ComponentModel.ISupportInitialize)(this.gC_WarehouseList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcWarehousesBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_WarehouseList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraGrid.GridControl gC_WarehouseList;
      private DevExpress.XtraGrid.Views.Grid.GridView gV_WarehouseList;
      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
      private DevExpress.XtraBars.BarButtonItem bBI_WarehouseNew;
      private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
      private DevExpress.XtraBars.BarButtonItem bBI_quit;
      private DevExpress.XtraBars.BarButtonItem bBI_Report1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
      private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
      private System.Windows.Forms.BindingSource dcWarehousesBindingSource;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
      private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
      private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
      private DevExpress.XtraBars.BarButtonItem bBI_WarehouseDelete;
      private DevExpress.XtraBars.BarButtonItem bBI_CurAccRefresh;
      private DevExpress.XtraGrid.Columns.GridColumn col_WarehouseCode;
      private DevExpress.XtraGrid.Columns.GridColumn col_WarehouseDesc;
   }
}