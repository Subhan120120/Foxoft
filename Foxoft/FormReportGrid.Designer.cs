
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gV_Report = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_LayoutSave = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_LayoutLoad = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_GridOptions = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_DesignClear = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gV_Report;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(820, 420);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_Report});
            // 
            // gV_Report
            // 
            this.gV_Report.GridControl = this.gridControl1;
            this.gV_Report.Name = "gV_Report";
            this.gV_Report.OptionsBehavior.Editable = false;
            this.gV_Report.OptionsLayout.Columns.StoreAllOptions = true;
            this.gV_Report.OptionsLayout.Columns.StoreAppearance = true;
            this.gV_Report.OptionsLayout.StoreAllOptions = true;
            this.gV_Report.OptionsLayout.StoreAppearance = true;
            this.gV_Report.OptionsLayout.StoreFormatRules = true;
            this.gV_Report.OptionsView.ShowFooter = true;
            this.gV_Report.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_Report_RowStyle);
            this.gV_Report.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gV_Report_ShowingEditor);
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
            this.bBI_DesignClear});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
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
            this.bBI_DesignClear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.bBI_DesignClear.Name = "bBI_DesignClear";
            this.bBI_DesignClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DesignClear_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hesabat";
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
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormReportGrid";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Report;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bBI_GridOptions;
        private DevExpress.XtraBars.BarButtonItem bBI_LayoutSave;
        private DevExpress.XtraBars.BarButtonItem bBI_LayoutLoad;
        private DevExpress.XtraBars.BarButtonItem bBI_DesignClear;
    }
}