
using Foxoft.AppCode;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportFilter));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            LUE_ReportCustomization = new DevExpress.XtraEditors.LookUpEdit();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_ReportEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ReportNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_ReportDelete = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportCustomAdd = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportCustomSave = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportCustomDelete = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            Hesaba = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            filterControl_Inner = new NotEditableFilterControl();
            btn_ShowReport = new DevExpress.XtraEditors.SimpleButton();
            filterControl_Outer = new ExcelButtonFilterControl();
            buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_ReportCustomization.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(LUE_ReportCustomization);
            layoutControl1.Controls.Add(filterControl_Inner);
            layoutControl1.Controls.Add(btn_ShowReport);
            layoutControl1.Controls.Add(filterControl_Outer);
            layoutControl1.Controls.Add(buttonEdit1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1040, 383, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(992, 516);
            layoutControl1.TabIndex = 17;
            layoutControl1.Text = "layoutControl1";
            // 
            // LUE_ReportCustomization
            // 
            LUE_ReportCustomization.Location = new Point(12, 223);
            LUE_ReportCustomization.MenuManager = ribbonControl1;
            LUE_ReportCustomization.Name = "LUE_ReportCustomization";
            LUE_ReportCustomization.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_ReportCustomization.Properties.NullText = "";
            LUE_ReportCustomization.Size = new Size(968, 20);
            LUE_ReportCustomization.StyleController = layoutControl1;
            LUE_ReportCustomization.TabIndex = 2;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_ReportEdit, bBI_ReportNew, bBI_ReportDelete, BBI_ReportCustomAdd, BBI_ReportCustomSave, BBI_ReportCustomDelete });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 11;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(992, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_ReportEdit
            // 
            bBI_ReportEdit.Caption = "Dəyiş";
            bBI_ReportEdit.Id = 1;
            bBI_ReportEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ReportEdit.ImageOptions.SvgImage");
            bBI_ReportEdit.Name = "bBI_ReportEdit";
            bBI_ReportEdit.ItemClick += bBI_ReportEdit_ItemClick;
            // 
            // bBI_ReportNew
            // 
            bBI_ReportNew.Caption = "Yeni";
            bBI_ReportNew.Id = 5;
            bBI_ReportNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ReportNew.ImageOptions.SvgImage");
            bBI_ReportNew.Name = "bBI_ReportNew";
            bBI_ReportNew.ItemClick += bBI_ReportNew_ItemClick;
            // 
            // bBI_ReportDelete
            // 
            bBI_ReportDelete.Caption = "Sil";
            bBI_ReportDelete.Id = 6;
            bBI_ReportDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ReportDelete.ImageOptions.SvgImage");
            bBI_ReportDelete.Name = "bBI_ReportDelete";
            bBI_ReportDelete.ItemClick += bBI_ReportDelete_ItemClick;
            // 
            // BBI_ReportCustomAdd
            // 
            BBI_ReportCustomAdd.Caption = "Dizayn Əlavə Et";
            BBI_ReportCustomAdd.Id = 8;
            BBI_ReportCustomAdd.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportCustomAdd.ImageOptions.SvgImage");
            BBI_ReportCustomAdd.Name = "BBI_ReportCustomAdd";
            // 
            // BBI_ReportCustomSave
            // 
            BBI_ReportCustomSave.Caption = "Dizaynı Yadda Saxla";
            BBI_ReportCustomSave.Id = 9;
            BBI_ReportCustomSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportCustomSave.ImageOptions.SvgImage");
            BBI_ReportCustomSave.Name = "BBI_ReportCustomSave";
            // 
            // BBI_ReportCustomDelete
            // 
            BBI_ReportCustomDelete.Caption = "Dizaynı Sil";
            BBI_ReportCustomDelete.Id = 10;
            BBI_ReportCustomDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportCustomDelete.ImageOptions.SvgImage");
            BBI_ReportCustomDelete.Name = "BBI_ReportCustomDelete";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { Hesaba, ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Hesabat";
            // 
            // Hesaba
            // 
            Hesaba.ItemLinks.Add(bBI_ReportNew);
            Hesaba.ItemLinks.Add(bBI_ReportEdit);
            Hesaba.ItemLinks.Add(bBI_ReportDelete);
            Hesaba.Name = "Hesaba";
            Hesaba.Text = "Əməliyat";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_ReportCustomAdd);
            ribbonPageGroup1.ItemLinks.Add(BBI_ReportCustomSave);
            ribbonPageGroup1.ItemLinks.Add(BBI_ReportCustomDelete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Fərdiləşdirmə";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 674);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(992, 24);
            // 
            // filterControl_Inner
            // 
            filterControl_Inner.AllowCustomExpressions = DevExpress.Utils.DefaultBoolean.False;
            filterControl_Inner.Location = new Point(12, 12);
            filterControl_Inner.Name = "filterControl_Inner";
            filterControl_Inner.NodeSeparatorHeight = 2;
            filterControl_Inner.ShowActionButtonMode = DevExpress.XtraEditors.ShowActionButtonMode.Default;
            filterControl_Inner.Size = new Size(968, 197);
            filterControl_Inner.TabIndex = 0;
            filterControl_Inner.Text = "filterControlInner";
            filterControl_Inner.CustomValueEditor += filterControl_Inner_CustomValueEditor;
            // 
            // btn_ShowReport
            // 
            btn_ShowReport.Location = new Point(12, 482);
            btn_ShowReport.Name = "btn_ShowReport";
            btn_ShowReport.Size = new Size(968, 22);
            btn_ShowReport.StyleController = layoutControl1;
            btn_ShowReport.TabIndex = 4;
            btn_ShowReport.Text = "Göstər";
            btn_ShowReport.Click += btn_ShowReport_Click;
            // 
            // filterControl_Outer
            // 
            filterControl_Outer.Location = new Point(12, 247);
            filterControl_Outer.MyIcon = null;
            filterControl_Outer.Name = "filterControl_Outer";
            filterControl_Outer.NodeSeparatorHeight = 2;
            filterControl_Outer.ShowActionButtonMode = DevExpress.XtraEditors.ShowActionButtonMode.Default;
            filterControl_Outer.Size = new Size(968, 207);
            filterControl_Outer.TabIndex = 3;
            filterControl_Outer.Text = "filterControlOuter";
            filterControl_Outer.CustomValueEditor += filterControl_Outer_CustomValueEditor;
            // 
            // buttonEdit1
            // 
            buttonEdit1.Location = new Point(81, 458);
            buttonEdit1.MenuManager = ribbonControl1;
            buttonEdit1.Name = "buttonEdit1";
            buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo) });
            buttonEdit1.Size = new Size(899, 20);
            buttonEdit1.StyleController = layoutControl1;
            buttonEdit1.TabIndex = 5;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem3, layoutControlItem4, layoutControlItem1, splitterItem1, layoutControlItem2, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new Size(992, 516);
            Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = filterControl_Outer;
            layoutControlItem3.Location = new Point(0, 235);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(972, 211);
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btn_ShowReport;
            layoutControlItem4.Location = new Point(0, 470);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(972, 26);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = filterControl_Inner;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(972, 201);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.AllowHotTrack = true;
            splitterItem1.Location = new Point(0, 201);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new Size(972, 10);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = LUE_ReportCustomization;
            layoutControlItem2.Location = new Point(0, 211);
            layoutControlItem2.MinSize = new Size(159, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(972, 24);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = buttonEdit1;
            layoutControlItem5.Location = new Point(0, 446);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(972, 24);
            layoutControlItem5.Text = "Dizayn Faylı";
            layoutControlItem5.TextSize = new Size(57, 13);
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("xls", "image://svgimages/export/exporttoxls.svg");
            // 
            // FormReportFilter
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 698);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormReportFilter";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Report Filter";
            WindowState = FormWindowState.Maximized;
            Load += FormReport_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LUE_ReportCustomization.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_ShowReport;
      private ExcelButtonFilterControl filterControl_Outer;
      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup Hesaba;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraLayout.LayoutControlGroup Root;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
      private DevExpress.XtraBars.BarButtonItem bBI_ReportEdit;
      private DevExpress.XtraBars.BarButtonItem bBI_ReportNew;
      private DevExpress.XtraBars.BarButtonItem bBI_ReportDelete;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
      private NotEditableFilterControl filterControl_Inner;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportCustomAdd;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportCustomSave;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportCustomDelete;
        private DevExpress.XtraEditors.LookUpEdit LUE_ReportCustomization;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}