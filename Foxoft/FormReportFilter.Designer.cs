
namespace Foxoft
{
    partial class FormReportFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportFilter));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_ReportEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ReportNew = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ReportDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.Hesaba = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.filterControl_Inner = new DevExpress.XtraEditors.FilterControl();
            this.btn_ShowReport = new DevExpress.XtraEditors.SimpleButton();
            this.filterControl_Outer = new DevExpress.XtraEditors.FilterControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.filterControl_Inner);
            this.layoutControl1.Controls.Add(this.btn_ShowReport);
            this.layoutControl1.Controls.Add(this.filterControl_Outer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 158);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(857, 372);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_ReportEdit,
            this.bBI_ReportNew,
            this.bBI_ReportDelete});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(857, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bBI_ReportEdit
            // 
            this.bBI_ReportEdit.Caption = "Dəyiş";
            this.bBI_ReportEdit.Id = 1;
            this.bBI_ReportEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ReportEdit.ImageOptions.SvgImage")));
            this.bBI_ReportEdit.Name = "bBI_ReportEdit";
            this.bBI_ReportEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ReportEdit_ItemClick);
            // 
            // bBI_ReportNew
            // 
            this.bBI_ReportNew.Caption = "Yeni";
            this.bBI_ReportNew.Id = 5;
            this.bBI_ReportNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ReportNew.ImageOptions.SvgImage")));
            this.bBI_ReportNew.Name = "bBI_ReportNew";
            this.bBI_ReportNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ReportNew_ItemClick);
            // 
            // bBI_ReportDelete
            // 
            this.bBI_ReportDelete.Caption = "Sil";
            this.bBI_ReportDelete.Id = 6;
            this.bBI_ReportDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ReportDelete.ImageOptions.SvgImage")));
            this.bBI_ReportDelete.Name = "bBI_ReportDelete";
            this.bBI_ReportDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ReportDelete_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.Hesaba});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hesabat";
            // 
            // Hesaba
            // 
            this.Hesaba.ItemLinks.Add(this.bBI_ReportNew);
            this.Hesaba.ItemLinks.Add(this.bBI_ReportEdit);
            this.Hesaba.ItemLinks.Add(this.bBI_ReportDelete);
            this.Hesaba.Name = "Hesaba";
            this.Hesaba.Text = "Kontrol";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 530);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(857, 24);
            // 
            // filterControl_Inner
            // 
            this.filterControl_Inner.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl_Inner.Location = new System.Drawing.Point(12, 12);
            this.filterControl_Inner.Name = "filterControl_Inner";
            this.filterControl_Inner.NodeSeparatorHeight = 2;
            this.filterControl_Inner.Size = new System.Drawing.Size(833, 131);
            this.filterControl_Inner.TabIndex = 12;
            this.filterControl_Inner.Text = "filterControlInner";
            // 
            // btn_ShowReport
            // 
            this.btn_ShowReport.Location = new System.Drawing.Point(12, 338);
            this.btn_ShowReport.Name = "btn_ShowReport";
            this.btn_ShowReport.Size = new System.Drawing.Size(833, 22);
            this.btn_ShowReport.StyleController = this.layoutControl1;
            this.btn_ShowReport.TabIndex = 11;
            this.btn_ShowReport.Text = "Show Report";
            this.btn_ShowReport.Click += new System.EventHandler(this.btn_ShowReport_Click);
            // 
            // filterControl_Outer
            // 
            this.filterControl_Outer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl_Outer.Location = new System.Drawing.Point(12, 147);
            this.filterControl_Outer.Name = "filterControl_Outer";
            this.filterControl_Outer.NodeSeparatorHeight = 2;
            this.filterControl_Outer.Size = new System.Drawing.Size(833, 187);
            this.filterControl_Outer.TabIndex = 5;
            this.filterControl_Outer.Text = "filterControlOuter";
            this.filterControl_Outer.CustomValueEditor += new System.EventHandler<DevExpress.XtraEditors.Filtering.CustomValueEditorArgs>(this.filterControl1_CustomValueEditor);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(857, 372);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.filterControl_Outer;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 135);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(837, 191);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_ShowReport;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 326);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(837, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.filterControl_Inner;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(837, 135);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // FormReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 554);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormReportFilter";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Report Filter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SimpleButton btn_ShowReport;
        private DevExpress.XtraEditors.FilterControl filterControl_Outer;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Hesaba;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem bBI_ReportEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_ReportNew;
        private DevExpress.XtraBars.BarButtonItem bBI_ReportDelete;
        private DevExpress.XtraEditors.FilterControl filterControl_Inner;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}