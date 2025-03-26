
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportGrid));
            gC_Report = new MyGridControl();
            gV_Report = new MyGridView(this);
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_LayoutSave = new DevExpress.XtraBars.BarButtonItem();
            bBI_LayoutLoad = new DevExpress.XtraBars.BarButtonItem();
            bBI_GridOptions = new DevExpress.XtraBars.BarButtonItem();
            bBI_DesignClear = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            BBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            BBI_PrintPreview = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            BBI_AddColumnString = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnInt32 = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnBoolean = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnDateTime = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnTimeSpan = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnDecimal = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddColumnObject = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)gC_Report).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Report).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // gC_Report
            // 
            gC_Report.Dock = DockStyle.Fill;
            gC_Report.Location = new Point(0, 158);
            gC_Report.MainView = gV_Report;
            gC_Report.Name = "gC_Report";
            gC_Report.Size = new Size(820, 420);
            gC_Report.TabIndex = 0;
            gC_Report.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Report });
            gC_Report.ProcessGridKey += gC_Report_ProcessGridKey;
            // 
            // gridView1
            // 
            gV_Report.GridControl = gC_Report;
            gV_Report.Name = "gridView1";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_LayoutSave, bBI_LayoutLoad, bBI_GridOptions, bBI_DesignClear, bBI_ExportXlsx, bBI_Refresh, barButtonItem2, BBI_ExportExcel, BBI_PrintPreview, barButtonItem1, barSubItem1, BBI_AddColumnString, BBI_AddColumnInt32, BBI_AddColumnBoolean, BBI_AddColumnDateTime, BBI_AddColumnTimeSpan, BBI_AddColumnDecimal, BBI_AddColumnObject });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 25;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(820, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_LayoutSave
            // 
            bBI_LayoutSave.Caption = "Dizaynı Saxla";
            bBI_LayoutSave.Id = 1;
            bBI_LayoutSave.ImageOptions.Image = (Image)resources.GetObject("bBI_LayoutSave.ImageOptions.Image");
            bBI_LayoutSave.ImageOptions.LargeImage = (Image)resources.GetObject("bBI_LayoutSave.ImageOptions.LargeImage");
            bBI_LayoutSave.Name = "bBI_LayoutSave";
            bBI_LayoutSave.ItemClick += bBI_LayoutSave_ItemClick;
            // 
            // bBI_LayoutLoad
            // 
            bBI_LayoutLoad.Caption = "Dizaynı Al";
            bBI_LayoutLoad.Id = 2;
            bBI_LayoutLoad.ImageOptions.Image = (Image)resources.GetObject("bBI_LayoutLoad.ImageOptions.Image");
            bBI_LayoutLoad.ImageOptions.LargeImage = (Image)resources.GetObject("bBI_LayoutLoad.ImageOptions.LargeImage");
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
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Test";
            barButtonItem2.Id = 10;
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // BBI_ExportExcel
            // 
            BBI_ExportExcel.Caption = "Excel'ə Göndər";
            BBI_ExportExcel.Id = 11;
            BBI_ExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ExportExcel.ImageOptions.SvgImage");
            BBI_ExportExcel.Name = "BBI_ExportExcel";
            BBI_ExportExcel.ItemClick += BBI_ExportExcel_ItemClick;
            // 
            // BBI_PrintPreview
            // 
            BBI_PrintPreview.Caption = "Print Görünüş";
            BBI_PrintPreview.Id = 12;
            BBI_PrintPreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_PrintPreview.ImageOptions.SvgImage");
            BBI_PrintPreview.Name = "BBI_PrintPreview";
            BBI_PrintPreview.ItemClick += BBI_PrintPreview_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 14;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "Kolon Əlavə Et";
            barSubItem1.Id = 16;
            barSubItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barSubItem1.ImageOptions.SvgImage");
            barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnString), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnInt32), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnBoolean), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnDateTime), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnTimeSpan), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnDecimal), new DevExpress.XtraBars.LinkPersistInfo(BBI_AddColumnObject) });
            barSubItem1.Name = "barSubItem1";
            // 
            // BBI_AddColumnString
            // 
            BBI_AddColumnString.Caption = "String";
            BBI_AddColumnString.Id = 17;
            BBI_AddColumnString.Name = "BBI_AddColumnString";
            BBI_AddColumnString.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnInt32
            // 
            BBI_AddColumnInt32.Caption = "Int32";
            BBI_AddColumnInt32.Id = 18;
            BBI_AddColumnInt32.Name = "BBI_AddColumnInt32";
            BBI_AddColumnInt32.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnBoolean
            // 
            BBI_AddColumnBoolean.Caption = "Boolean";
            BBI_AddColumnBoolean.Id = 19;
            BBI_AddColumnBoolean.Name = "BBI_AddColumnBoolean";
            BBI_AddColumnBoolean.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnDateTime
            // 
            BBI_AddColumnDateTime.Caption = "DateTime";
            BBI_AddColumnDateTime.Id = 20;
            BBI_AddColumnDateTime.Name = "BBI_AddColumnDateTime";
            BBI_AddColumnDateTime.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnTimeSpan
            // 
            BBI_AddColumnTimeSpan.Caption = "TimeSpan";
            BBI_AddColumnTimeSpan.Id = 21;
            BBI_AddColumnTimeSpan.Name = "BBI_AddColumnTimeSpan";
            BBI_AddColumnTimeSpan.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnDecimal
            // 
            BBI_AddColumnDecimal.Caption = "decimal";
            BBI_AddColumnDecimal.Id = 23;
            BBI_AddColumnDecimal.Name = "BBI_AddColumnDecimal";
            BBI_AddColumnDecimal.ItemClick += AddColumn_ItemClick;
            // 
            // BBI_AddColumnObject
            // 
            BBI_AddColumnObject.Caption = "Object";
            BBI_AddColumnObject.Id = 24;
            BBI_AddColumnObject.Name = "BBI_AddColumnObject";
            BBI_AddColumnObject.ItemClick += AddColumn_ItemClick;
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
            ribbonPageGroup1.ItemLinks.Add(barSubItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Dizayn";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.ItemLinks.Add(BBI_ExportExcel);
            ribbonPageGroup2.ItemLinks.Add(BBI_PrintPreview);
            ribbonPageGroup2.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Export";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 578);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(820, 24);
            // 
            // popupMenu1
            // 
            popupMenu1.ItemLinks.Add(barButtonItem1);
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbonControl1;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("bo_report", "image://svgimages/business objects/bo_report.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            // 
            // FormReportGrid
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 602);
            Controls.Add(gC_Report);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormReportGrid";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Form1";
            FormClosing += FormReportGrid_FormClosing;
            KeyDown += FormReportGrid_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_Report).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Report).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarButtonItem BBI_ExportExcel;
        private DevExpress.XtraBars.BarButtonItem BBI_PrintPreview;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnString;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnInt32;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnBoolean;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnDateTime;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnTimeSpan;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnDecimal;
        private DevExpress.XtraBars.BarButtonItem BBI_AddColumnObject;
    }
}