
namespace Foxoft
{
    partial class FormReportGrid
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportGrid));
         this.gC_Report = new MyGridControl();
         this.gV_Report = new MyGridView(this);
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_LayoutSave = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_LayoutLoad = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_GridOptions = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_DesignClear = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Quit = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_Report)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_Report)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_Report
         // 
         this.gC_Report.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_Report.Location = new System.Drawing.Point(0, 158);
         this.gC_Report.MainView = this.gV_Report;
         this.gC_Report.Name = "gC_Report";
         this.gC_Report.Size = new System.Drawing.Size(820, 420);
         this.gC_Report.TabIndex = 0;
         this.gC_Report.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_Report});
         this.gC_Report.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_Report_ProcessGridKey);
         // 
         // gV_Report
         // 
         this.gV_Report.GridControl = this.gC_Report;
         this.gV_Report.Name = "gV_Report";
         this.gV_Report.OptionsBehavior.Editable = false;
         this.gV_Report.OptionsLayout.Columns.StoreAllOptions = true;
         this.gV_Report.OptionsLayout.Columns.StoreAppearance = true;
         this.gV_Report.OptionsLayout.StoreAllOptions = true;
         this.gV_Report.OptionsLayout.StoreAppearance = true;
         this.gV_Report.OptionsLayout.StoreFormatRules = true;
         this.gV_Report.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
         this.gV_Report.OptionsView.ShowFooter = true;
         this.gV_Report.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_Report_RowStyle);
         this.gV_Report.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gV_Report_PopupMenuShowing);
         this.gV_Report.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gV_Report_CalcRowHeight);
         this.gV_Report.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gV_Report_ShowingEditor);
         this.gV_Report.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gV_Report_CustomUnboundColumnData);
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_LayoutSave,
            this.bBI_LayoutLoad,
            this.bBI_GridOptions,
            this.bBI_DesignClear,
            this.bBI_ExportXlsx,
            this.bBI_Refresh,
            this.bBI_Quit,
            this.barButtonItem1});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 10;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_Quit);
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(820, 158);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // bBI_LayoutSave
         // 
         this.bBI_LayoutSave.Caption = "Dizaynı Saxla";
         this.bBI_LayoutSave.Id = 1;
         this.bBI_LayoutSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBI_LayoutSave.ImageOptions.Image")));
         this.bBI_LayoutSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBI_LayoutSave.ImageOptions.LargeImage")));
         this.bBI_LayoutSave.Name = "bBI_LayoutSave";
         this.bBI_LayoutSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_LayoutSave_ItemClick);
         // 
         // bBI_LayoutLoad
         // 
         this.bBI_LayoutLoad.Caption = "Dizaynı Al";
         this.bBI_LayoutLoad.Id = 2;
         this.bBI_LayoutLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBI_LayoutLoad.ImageOptions.Image")));
         this.bBI_LayoutLoad.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBI_LayoutLoad.ImageOptions.LargeImage")));
         this.bBI_LayoutLoad.Name = "bBI_LayoutLoad";
         this.bBI_LayoutLoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_LayoutLoad_ItemClick);
         // 
         // bBI_GridOptions
         // 
         this.bBI_GridOptions.Caption = "Dizayn Düzəltmə";
         this.bBI_GridOptions.Id = 3;
         this.bBI_GridOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_GridOptions.ImageOptions.SvgImage")));
         this.bBI_GridOptions.Name = "bBI_GridOptions";
         this.bBI_GridOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_gridOptions_ItemClick);
         // 
         // bBI_DesignClear
         // 
         this.bBI_DesignClear.Caption = "Dizaynı Sıfırla";
         this.bBI_DesignClear.Id = 4;
         this.bBI_DesignClear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_DesignClear.ImageOptions.SvgImage")));
         this.bBI_DesignClear.Name = "bBI_DesignClear";
         this.bBI_DesignClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DesignClear_ItemClick);
         // 
         // bBI_ExportXlsx
         // 
         this.bBI_ExportXlsx.Caption = "Excelə İxrac Et";
         this.bBI_ExportXlsx.Id = 5;
         this.bBI_ExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage")));
         this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
         this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
         // 
         // bBI_Refresh
         // 
         this.bBI_Refresh.Caption = "Yenilə";
         this.bBI_Refresh.Id = 6;
         this.bBI_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Refresh.ImageOptions.SvgImage")));
         this.bBI_Refresh.Name = "bBI_Refresh";
         this.bBI_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Refresh_ItemClick);
         // 
         // bBI_Quit
         // 
         this.bBI_Quit.Id = 8;
         this.bBI_Quit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Quit.ImageOptions.SvgImage")));
         this.bBI_Quit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
         this.bBI_Quit.Name = "bBI_Quit";
         this.bBI_Quit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Quit_ItemClick);
         // 
         // barButtonItem1
         // 
         this.barButtonItem1.Caption = "test";
         this.barButtonItem1.Id = 9;
         this.barButtonItem1.Name = "barButtonItem1";
         this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Hesabat";
         // 
         // ribbonPageGroup3
         // 
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_Refresh);
         this.ribbonPageGroup3.Name = "ribbonPageGroup3";
         this.ribbonPageGroup3.Text = "Data";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_LayoutSave);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_LayoutLoad);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_GridOptions);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_DesignClear);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "Dizayn";
         // 
         // ribbonPageGroup2
         // 
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_ExportXlsx);
         this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
         this.ribbonPageGroup2.Name = "ribbonPageGroup2";
         this.ribbonPageGroup2.Text = "Export";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 578);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(820, 24);
         // 
         // ribbonPage2
         // 
         this.ribbonPage2.Name = "ribbonPage2";
         this.ribbonPage2.Text = "ribbonPage2";
         // 
         // FormReportGrid
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(820, 602);
         this.Controls.Add(this.gC_Report);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormReportGrid";
         this.Ribbon = this.ribbonControl1;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.gC_Report)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_Report)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        public MyGridControl gC_Report;
        private MyGridView gV_Report;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_GridOptions;
        private DevExpress.XtraBars.BarButtonItem bBI_LayoutSave;
        private DevExpress.XtraBars.BarButtonItem bBI_LayoutLoad;
        private DevExpress.XtraBars.BarButtonItem bBI_DesignClear;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
      private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
      private DevExpress.XtraBars.BarButtonItem bBI_Quit;
      private DevExpress.XtraBars.BarButtonItem barButtonItem1;
   }
}