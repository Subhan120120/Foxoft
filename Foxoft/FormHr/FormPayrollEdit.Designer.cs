namespace Foxoft
{
    partial class FormPayrollEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPayrollEdit));

            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_reportPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_SendWhatsapp = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTools = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();

            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);

            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.btnEditEmployee = new DevExpress.XtraEditors.ButtonEdit();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.lkpPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.gridLines = new MyGridControl();
            this.viewLines = new MyGridView();
            this.btnAddLine = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveLine = new DevExpress.XtraEditors.SimpleButton();
            this.spGrossSalary = new DevExpress.XtraEditors.SpinEdit();
            this.spNetSalary = new DevExpress.XtraEditors.SpinEdit();

            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGrossSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNetSalary.Properties)).BeginInit();
            this.SuspendLayout();

            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl1.ExpandCollapseItem,
                this.bBI_SaveAndClose,
                this.bBI_reportPreview,
                this.bBI_SendWhatsapp
            });
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1
            });
            this.ribbonControl1.Size = new System.Drawing.Size(1050, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;

            // 
            // bBI_SaveAndClose
            // 
            this.bBI_SaveAndClose.Caption = Foxoft.Properties.Resources.Common_Save;
            this.bBI_SaveAndClose.Id = 1;
            this.bBI_SaveAndClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndClose.ImageOptions.SvgImage");
            this.bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            this.bBI_SaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SaveAndClose_ItemClick);

            // 
            // bBI_reportPreview
            // 
            this.bBI_reportPreview.Caption = Foxoft.Properties.Resources.Form_PayrollEdit_Button_ReportPreview;
            this.bBI_reportPreview.Id = 2;
            this.bBI_reportPreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_reportPreview.ImageOptions.SvgImage");
            this.bBI_reportPreview.Name = "bBI_reportPreview";
            this.bBI_reportPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_reportPreview_ItemClick);

            // 
            // bBI_SendWhatsapp
            // 
            this.bBI_SendWhatsapp.Caption = Foxoft.Properties.Resources.Form_PayrollEdit_Button_SendWhatsapp;
            this.bBI_SendWhatsapp.Id = 3;
            this.bBI_SendWhatsapp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SendWhatsapp.ImageOptions.SvgImage");
            this.bBI_SendWhatsapp.Name = "bBI_SendWhatsapp";
            this.bBI_SendWhatsapp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SendWhatsapp_ItemClick);

            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.rpgOperations,
                this.rpgTools,
                this.rpgExport
            });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.Form_PaymentDetail_RibbonPage_Main;

            // 
            // rpgOperations
            // 
            this.rpgOperations.ItemLinks.Add(this.bBI_SaveAndClose);
            this.rpgOperations.Name = "rpgOperations";
            this.rpgOperations.Text = Foxoft.Properties.Resources.Common_Save;

            // 
            // rpgTools
            // 
            this.rpgTools.ItemLinks.Add(this.bBI_reportPreview);
            this.rpgTools.Name = "rpgTools";
            this.rpgTools.Text = Foxoft.Properties.Resources.Form_PaymentDetail_RibbonGroup_Tools;

            // 
            // rpgExport
            // 
            this.rpgExport.ItemLinks.Add(this.bBI_SendWhatsapp);
            this.rpgExport.Name = "rpgExport";
            this.rpgExport.Text = "Export";

            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 696);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1050, 24);

            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("whatsapp_unsend", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.whatsapp_unsend"));
            this.svgImageCollection1.Add("whatsapp_sent", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.whatsapp_sent"));

            // 
            // layout
            // 
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.btnEditEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnEditEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            this.txtEmployeeName.Properties.ReadOnly = true;

            this.lkpPeriod.Properties.DisplayMember = "PeriodName";
            this.lkpPeriod.Properties.ValueMember = "Id";
            this.lkpPeriod.Properties.NullText = "";
            this.lkpPeriod.Properties.ShowHeader = true;
            this.lkpPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPeriod.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodYear", Foxoft.Properties.Resources.Entity_TrPayrollPeriod_PeriodYear),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodMonth", Foxoft.Properties.Resources.Entity_TrPayrollPeriod_PeriodMonth)
            });

            this.spGrossSalary.Properties.ReadOnly = true;
            this.spGrossSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spGrossSalary.Properties.DisplayFormat.FormatString = "N2";
            this.spNetSalary.Properties.ReadOnly = true;
            this.spNetSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spNetSalary.Properties.DisplayFormat.FormatString = "N2";

            this.layout.Controls.Add(this.spGrossSalary);
            this.layout.Controls.Add(this.spNetSalary);

            this.btnAddLine.Text = Foxoft.Properties.Resources.Common_New;
            this.btnRemoveLine.Text = Foxoft.Properties.Resources.Common_Delete;

            this.gridLines.MainView = this.viewLines;
            this.viewLines.GridControl = this.gridLines;
            this.viewLines.OptionsView.ShowGroupPanel = false;
            this.viewLines.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.viewLines.OptionsBehavior.Editable = true;
            this.viewLines.OptionsView.ColumnAutoWidth = false;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_CurrAccCode, this.btnEditEmployee);
            this.layout.AddItem(Foxoft.Properties.Resources.Common_EmployeeName, this.txtEmployeeName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_PeriodId, this.lkpPeriod);

            var grpLines = root.AddGroup();
            grpLines.Text = Foxoft.Properties.Resources.Form_PayrollEdit_Lines;
            grpLines.AddItem("", this.gridLines);

            var grpLineButtons = root.AddGroup();
            grpLineButtons.GroupBordersVisible = false;
            grpLineButtons.AddItem("", this.btnAddLine);
            grpLineButtons.AddItem("", this.btnRemoveLine);

            var grpTotals = root.AddGroup();
            grpTotals.Text = Foxoft.Properties.Resources.Form_PayrollEdit_Totals;
            grpTotals.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_GrossSalary, this.spGrossSalary);
            grpTotals.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_NetSalary, this.spNetSalary);

            this.Controls.Add(this.layout);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);

            // FormPayrollEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 720);
            this.Name = "FormPayrollEdit";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGrossSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNetSalary.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOperations;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTools;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExport;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bBI_reportPreview;
        private DevExpress.XtraBars.BarButtonItem bBI_SendWhatsapp;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.ButtonEdit btnEditEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LookUpEdit lkpPeriod;
        private MyGridControl gridLines;
        private MyGridView viewLines;
        private DevExpress.XtraEditors.SimpleButton btnAddLine;
        private DevExpress.XtraEditors.SimpleButton btnRemoveLine;
        private DevExpress.XtraEditors.SpinEdit spGrossSalary;
        private DevExpress.XtraEditors.SpinEdit spNetSalary;
    }
}
