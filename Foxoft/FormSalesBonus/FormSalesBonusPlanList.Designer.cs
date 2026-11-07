namespace Foxoft
{
    partial class FormSalesBonusPlanList
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colPlanName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTriggerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFixedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignmentCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            //
            // ribbon
            //
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1100, 158);
            //
            // btnNew
            //
            this.btnNew.Caption = Foxoft.Properties.Resources.Common_New;
            this.btnNew.Id = 1;
            this.btnNew.Name = "btnNew";
            //
            // btnEdit
            //
            this.btnEdit.Caption = Foxoft.Properties.Resources.Common_Edit;
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            //
            // btnDelete
            //
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            //
            // btnRefresh
            //
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            //
            // btnClose
            //
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 5;
            this.btnClose.Name = "btnClose";
            //
            // ribbonPage1
            //
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.ERP_ACE_HumanResource;
            //
            // ribbonPageGroup1
            //
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanList_Caption;
            //
            // gridControl1
            //
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1100, 542);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // gridView1
            //
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlanName,
            this.colCalcMethod,
            this.colTriggerType,
            this.colPeriodType,
            this.colRate,
            this.colFixedAmount,
            this.colIsActive,
            this.colAssignmentCount,
            this.colDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            //
            // columns
            //
            this.colPlanName.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_PlanName;
            this.colPlanName.FieldName = "PlanName";
            this.colPlanName.Name = "colPlanName";
            this.colPlanName.Visible = true;
            this.colPlanName.VisibleIndex = 0;
            this.colPlanName.Width = 200;

            this.colCalcMethod.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_CalcMethod;
            this.colCalcMethod.FieldName = "CalcMethodText";
            this.colCalcMethod.Name = "colCalcMethod";
            this.colCalcMethod.Visible = true;
            this.colCalcMethod.VisibleIndex = 1;
            this.colCalcMethod.Width = 220;

            this.colTriggerType.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_TriggerType;
            this.colTriggerType.FieldName = "TriggerTypeText";
            this.colTriggerType.Name = "colTriggerType";
            this.colTriggerType.Visible = true;
            this.colTriggerType.VisibleIndex = 2;
            this.colTriggerType.Width = 180;

            this.colPeriodType.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_PeriodType;
            this.colPeriodType.FieldName = "PeriodTypeText";
            this.colPeriodType.Name = "colPeriodType";
            this.colPeriodType.Visible = true;
            this.colPeriodType.VisibleIndex = 3;
            this.colPeriodType.Width = 90;

            this.colRate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_Rate;
            this.colRate.DisplayFormat.FormatString = "n4";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 4;
            this.colRate.Width = 90;

            this.colFixedAmount.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_FixedAmount;
            this.colFixedAmount.DisplayFormat.FormatString = "n2";
            this.colFixedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFixedAmount.FieldName = "FixedAmount";
            this.colFixedAmount.Name = "colFixedAmount";
            this.colFixedAmount.Visible = true;
            this.colFixedAmount.VisibleIndex = 5;
            this.colFixedAmount.Width = 90;

            this.colIsActive.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_IsActive;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 6;
            this.colIsActive.Width = 60;

            this.colAssignmentCount.Caption = Foxoft.Properties.Resources.Form_SalesBonusPlanList_AssignmentCount;
            this.colAssignmentCount.FieldName = "AssignmentCount";
            this.colAssignmentCount.Name = "colAssignmentCount";
            this.colAssignmentCount.Visible = true;
            this.colAssignmentCount.VisibleIndex = 7;
            this.colAssignmentCount.Width = 110;

            this.colDescription.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_Description;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 8;
            this.colDescription.Width = 250;
            //
            // FormSalesBonusPlanList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormSalesBonusPlanList";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanName;
        private DevExpress.XtraGrid.Columns.GridColumn colCalcMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colTriggerType;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodType;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colFixedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignmentCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
    }
}
