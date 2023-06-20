
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
            gC_Report = new MyGridControl();
            gV_Report = new MyGridView(gC_Report);
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_LayoutSave = new DevExpress.XtraBars.BarButtonItem();
            bBI_LayoutLoad = new DevExpress.XtraBars.BarButtonItem();
            bBI_GridOptions = new DevExpress.XtraBars.BarButtonItem();
            bBI_DesignClear = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_Quit = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)gC_Report).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Report).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_Report
            // 
            gC_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_Report.Location = new System.Drawing.Point(0, 158);
            gC_Report.MainView = gV_Report;
            gC_Report.Name = "gC_Report";
            gC_Report.Size = new System.Drawing.Size(820, 420);
            gC_Report.TabIndex = 0;
            gC_Report.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Report });
            gC_Report.ProcessGridKey += gC_Report_ProcessGridKey;
            // 
            // gV_Report
            // 
            gV_Report.GridControl = gC_Report;
            gV_Report.Name = "gV_Report";
            gV_Report.OptionsBehavior.Editable = false;
            gV_Report.OptionsLayout.Columns.StoreAllOptions = true;
            gV_Report.OptionsLayout.Columns.StoreAppearance = true;
            gV_Report.OptionsLayout.StoreAllOptions = true;
            gV_Report.OptionsLayout.StoreAppearance = true;
            gV_Report.OptionsLayout.StoreFormatRules = true;
            gV_Report.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            gV_Report.OptionsView.ShowFooter = true;
            gV_Report.RowStyle += gV_Report_RowStyle;
            gV_Report.PopupMenuShowing += gV_Report_PopupMenuShowing;
            gV_Report.CalcRowHeight += gV_Report_CalcRowHeight;
            gV_Report.ShowingEditor += gV_Report_ShowingEditor;
            gV_Report.CustomUnboundColumnData += gV_Report_CustomUnboundColumnData;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, bBI_LayoutSave, bBI_LayoutLoad, bBI_GridOptions, bBI_DesignClear, bBI_ExportXlsx, bBI_Refresh, bBI_Quit, barButtonItem1, barButtonItem2 });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 11;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.PageHeaderItemLinks.Add(bBI_Quit);
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(820, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_LayoutSave
            // 
            bBI_LayoutSave.Caption = "Dizaynı Saxla";
            bBI_LayoutSave.Id = 1;
            bBI_LayoutSave.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("bBI_LayoutSave.ImageOptions.Image");
            bBI_LayoutSave.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("bBI_LayoutSave.ImageOptions.LargeImage");
            bBI_LayoutSave.Name = "bBI_LayoutSave";
            bBI_LayoutSave.ItemClick += bBI_LayoutSave_ItemClick;
            // 
            // bBI_LayoutLoad
            // 
            bBI_LayoutLoad.Caption = "Dizaynı Al";
            bBI_LayoutLoad.Id = 2;
            bBI_LayoutLoad.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("bBI_LayoutLoad.ImageOptions.Image");
            bBI_LayoutLoad.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("bBI_LayoutLoad.ImageOptions.LargeImage");
            bBI_LayoutLoad.Name = "bBI_LayoutLoad";
            bBI_LayoutLoad.ItemClick += bBI_LayoutLoad_ItemClick;
            // 
            // bBI_GridOptions
            // 
            bBI_GridOptions.Caption = "Dizayn Düzəltmə";
            bBI_GridOptions.Id = 3;
            bBI_GridOptions.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_GridOptions.ImageOptions.SvgImage");
            bBI_GridOptions.Name = "bBI_GridOptions";
            bBI_GridOptions.ItemClick += bBI_gridOptions_ItemClick;
            // 
            // bBI_DesignClear
            // 
            bBI_DesignClear.Caption = "Dizaynı Sıfırla";
            bBI_DesignClear.Id = 4;
            bBI_DesignClear.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DesignClear.ImageOptions.SvgImage");
            bBI_DesignClear.Name = "bBI_DesignClear";
            bBI_DesignClear.ItemClick += bBI_DesignClear_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = "Excelə İxrac Et";
            bBI_ExportXlsx.Id = 5;
            bBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = "Yenilə";
            bBI_Refresh.Id = 6;
            bBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Refresh.ImageOptions.SvgImage");
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_Quit
            // 
            bBI_Quit.Id = 8;
            bBI_Quit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Quit.ImageOptions.SvgImage");
            bBI_Quit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            bBI_Quit.Name = "bBI_Quit";
            bBI_Quit.ItemClick += bBI_Quit_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Kolon Əlavə Et";
            barButtonItem1.Id = 9;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup3, ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Hesabat";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Data";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_LayoutSave);
            ribbonPageGroup1.ItemLinks.Add(bBI_LayoutLoad);
            ribbonPageGroup1.ItemLinks.Add(bBI_GridOptions);
            ribbonPageGroup1.ItemLinks.Add(bBI_DesignClear);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Dizayn";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup2.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Export";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 578);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(820, 24);
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Test";
            barButtonItem2.Id = 10;
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // FormReportGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(820, 602);
            Controls.Add(gC_Report);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormReportGrid";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gC_Report).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Report).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}