namespace Foxoft
{
    partial class FormSalesBonusCalc
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
            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.spinYear = new DevExpress.XtraEditors.SpinEdit();
            this.spinMonth = new DevExpress.XtraEditors.SpinEdit();
            this.btnSalesPerson = new DevExpress.XtraEditors.ButtonEdit();
            this.lkpPlan = new DevExpress.XtraEditors.LookUpEdit();
            this.chkIncludeAuto = new DevExpress.XtraEditors.CheckEdit();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnPost = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScope = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelta = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.spinYear.Properties.MinValue = 2000;
            this.spinYear.Properties.MaxValue = 2100;
            this.spinYear.Properties.IsFloatValue = false;
            this.spinYear.Properties.Mask.EditMask = "d";
            this.spinMonth.Properties.MinValue = 1;
            this.spinMonth.Properties.MaxValue = 12;
            this.spinMonth.Properties.IsFloatValue = false;
            this.spinMonth.Properties.Mask.EditMask = "d";

            this.btnSalesPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnSalesPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });

            this.lkpPlan.Properties.DisplayMember = "PlanName";
            this.lkpPlan.Properties.ValueMember = "SalesBonusPlanId";
            this.lkpPlan.Properties.NullText = "";
            this.lkpPlan.Properties.ShowHeader = true;
            this.lkpPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPlan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPlan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });
            this.lkpPlan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlanName", Foxoft.Properties.Resources.Entity_SalesBonusPlan_PlanName),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TriggerTypeText", Foxoft.Properties.Resources.Entity_SalesBonusPlan_TriggerType) });

            this.chkIncludeAuto.Text = Foxoft.Properties.Resources.Form_SalesBonusCalc_IncludeAutoPlans;

            this.btnPreview.Text = Foxoft.Properties.Resources.Common_Preview;
            this.btnPost.Text = Foxoft.Properties.Resources.Form_SalesBonusCalc_Post;
            this.btnPost.Enabled = false;
            this.btnClose.Text = Foxoft.Properties.Resources.Common_Close;

            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colSalesPersonCode, this.colSalesPersonName, this.colPlanName, this.colScope, this.colBaseAmount, this.colExpected, this.colPosted, this.colDelta });
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ColumnAutoWidth = true;

            this.colSalesPersonCode.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode;
            this.colSalesPersonCode.FieldName = "SalesPersonCode";
            this.colSalesPersonCode.Name = "colSalesPersonCode";
            this.colSalesPersonCode.Visible = true;
            this.colSalesPersonCode.VisibleIndex = 0;

            this.colSalesPersonName.Caption = Foxoft.Properties.Resources.Common_EmployeeName;
            this.colSalesPersonName.FieldName = "SalesPersonName";
            this.colSalesPersonName.Name = "colSalesPersonName";
            this.colSalesPersonName.Visible = true;
            this.colSalesPersonName.VisibleIndex = 1;

            this.colPlanName.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId;
            this.colPlanName.FieldName = "PlanName";
            this.colPlanName.Name = "colPlanName";
            this.colPlanName.Visible = true;
            this.colPlanName.VisibleIndex = 2;

            this.colScope.Caption = Foxoft.Properties.Resources.Form_SalesBonusCalc_Scope;
            this.colScope.FieldName = "Scope";
            this.colScope.Name = "colScope";
            this.colScope.Visible = true;
            this.colScope.VisibleIndex = 3;

            this.colBaseAmount.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_BaseAmount;
            this.colBaseAmount.DisplayFormat.FormatString = "n2";
            this.colBaseAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseAmount.FieldName = "BaseAmount";
            this.colBaseAmount.Name = "colBaseAmount";
            this.colBaseAmount.Visible = true;
            this.colBaseAmount.VisibleIndex = 4;

            this.colExpected.Caption = Foxoft.Properties.Resources.Form_SalesBonusCalc_Expected;
            this.colExpected.DisplayFormat.FormatString = "n2";
            this.colExpected.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExpected.FieldName = "Expected";
            this.colExpected.Name = "colExpected";
            this.colExpected.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Expected", "{0:n2}") });
            this.colExpected.Visible = true;
            this.colExpected.VisibleIndex = 5;

            this.colPosted.Caption = Foxoft.Properties.Resources.Form_SalesBonusCalc_Posted;
            this.colPosted.DisplayFormat.FormatString = "n2";
            this.colPosted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPosted.FieldName = "Posted";
            this.colPosted.Name = "colPosted";
            this.colPosted.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Posted", "{0:n2}") });
            this.colPosted.Visible = true;
            this.colPosted.VisibleIndex = 6;

            this.colDelta.Caption = Foxoft.Properties.Resources.Form_SalesBonusCalc_Delta;
            this.colDelta.DisplayFormat.FormatString = "n2";
            this.colDelta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDelta.FieldName = "Delta";
            this.colDelta.Name = "colDelta";
            this.colDelta.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Delta", "{0:n2}") });
            this.colDelta.Visible = true;
            this.colDelta.VisibleIndex = 7;

            this.layout.Root = root;
            var filterGroup = root.AddGroup();
            filterGroup.GroupBordersVisible = false;
            filterGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            filterGroup.AddItem(Foxoft.Properties.Resources.Form_SalesBonusCalc_Year, this.spinYear);
            filterGroup.AddItem(Foxoft.Properties.Resources.Form_SalesBonusCalc_Month, this.spinMonth);
            filterGroup.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode, this.btnSalesPerson);
            filterGroup.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId, this.lkpPlan);

            var optionGroup = root.AddGroup();
            optionGroup.GroupBordersVisible = false;
            optionGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            optionGroup.AddItem("", this.chkIncludeAuto).TextVisible = false;
            optionGroup.AddItem("", this.btnPreview).TextVisible = false;
            optionGroup.AddItem("", this.btnPost).TextVisible = false;
            optionGroup.AddItem("", this.btnClose).TextVisible = false;

            root.AddItem("", this.gridControl1).TextVisible = false;

            this.Controls.Add(this.layout);

            // FormSalesBonusCalc
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "FormSalesBonusCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusCalc_Caption;

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.SpinEdit spinYear;
        private DevExpress.XtraEditors.SpinEdit spinMonth;
        private DevExpress.XtraEditors.ButtonEdit btnSalesPerson;
        private DevExpress.XtraEditors.LookUpEdit lkpPlan;
        private DevExpress.XtraEditors.CheckEdit chkIncludeAuto;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnPost;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanName;
        private DevExpress.XtraGrid.Columns.GridColumn colScope;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colExpected;
        private DevExpress.XtraGrid.Columns.GridColumn colPosted;
        private DevExpress.XtraGrid.Columns.GridColumn colDelta;
    }
}
