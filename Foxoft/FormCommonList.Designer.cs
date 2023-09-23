using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class FormCommonList<T>
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BBI_query = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Quit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BBI_New = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BBI_query,
            this.bBI_ExportExcel,
            this.BBI_Quit});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.BBI_Quit);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 158);
            // 
            // BBI_query
            // 
            this.BBI_query.Caption = "Sorğu";
            this.BBI_query.Id = 23;
            this.BBI_query.Name = "BBI_query";
            // 
            // bBI_ExportExcel
            // 
            this.bBI_ExportExcel.Caption = "Excele At";
            this.bBI_ExportExcel.Id = 5;
            this.bBI_ExportExcel.Name = "bBI_ExportExcel";
            this.bBI_ExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportExcel_ItemClick);
            // 
            // BBI_Quit
            // 
            this.BBI_Quit.Caption = "barButtonItem1";
            this.BBI_Quit.Id = 2;
            this.BBI_Quit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            this.BBI_Quit.Name = "BBI_Quit";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Əməliyatlar";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_New);
            this.ribbonPageGroup1.ItemLinks.Add(this.BBI_Edit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_Delete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_Refresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Alətlər";
            // 
            // BBI_New
            // 
            this.BBI_New.Caption = "Yeni";
            this.BBI_New.Id = 1;
            this.BBI_New.Name = "BBI_New";
            this.BBI_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_New_ItemClick);
            // 
            // BBI_Edit
            // 
            this.BBI_Edit.Caption = "Dəyiş";
            this.BBI_Edit.Id = 2;
            this.BBI_Edit.Name = "BBI_Edit";
            this.BBI_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_Edit_ItemClick);
            // 
            // bBI_Delete
            // 
            this.bBI_Delete.Caption = "Sil";
            this.bBI_Delete.Id = 8;
            this.bBI_Delete.Name = "bBI_Delete";
            this.bBI_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_Delete_ItemClick);
            // 
            // bBI_Refresh
            // 
            this.bBI_Refresh.Caption = "Yenilə";
            this.bBI_Refresh.Id = 9;
            this.bBI_Refresh.Name = "bBI_Refresh";
            this.bBI_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_Refresh_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BBI_query);
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_ExportExcel);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Data";
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("sendxlsx", "image://svgimages/send/sendxlsx.svg");
            this.svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            this.svgImageCollection1.Add("edit", "image://svgimages/icon builder/actions_edit.svg");
            this.svgImageCollection1.Add("delete", "image://svgimages/scheduling/delete.svg");
            this.svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            this.svgImageCollection1.Add("queryedit", "image://svgimages/dashboards/editdatasource.svg");
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 292);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.ColumnFilterChanged += new System.EventHandler(this.gridView1_ColumnFilterChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.RowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.gridView1_RowLoaded);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // FormCommonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormCommonList";
            this.Ribbon = this.ribbonControl1;
            this.Text = "FormCommonList";
            this.Activated += new System.EventHandler(this.FormCommonList_Activated);
            this.Load += new System.EventHandler(this.FormCommonList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BBI_query;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportExcel;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarButtonItem BBI_Quit;
    }
}