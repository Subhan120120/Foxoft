namespace Foxoft
{
    partial class FormSalesBonusAssignmentList
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
            this.colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTargetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
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
            // buttons
            //
            this.btnNew.Caption = Foxoft.Properties.Resources.Common_New;
            this.btnNew.Id = 1;
            this.btnNew.Name = "btnNew";
            this.btnEdit.Caption = Foxoft.Properties.Resources.Common_Edit;
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
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
            this.ribbonPageGroup1.Text = Foxoft.Properties.Resources.Form_SalesBonusAssignmentList_Caption;
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
            this.colSalesPersonCode,
            this.colSalesPersonName,
            this.colPlanName,
            this.colCalcMethod,
            this.colStartDate,
            this.colEndDate,
            this.colTargetAmount,
            this.colIsActive,
            this.colNote});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            //
            // columns
            //
            this.colSalesPersonCode.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode;
            this.colSalesPersonCode.FieldName = "SalesPersonCode";
            this.colSalesPersonCode.Name = "colSalesPersonCode";
            this.colSalesPersonCode.Visible = true;
            this.colSalesPersonCode.VisibleIndex = 0;
            this.colSalesPersonCode.Width = 110;

            this.colSalesPersonName.Caption = Foxoft.Properties.Resources.Common_EmployeeName;
            this.colSalesPersonName.FieldName = "SalesPersonName";
            this.colSalesPersonName.Name = "colSalesPersonName";
            this.colSalesPersonName.Visible = true;
            this.colSalesPersonName.VisibleIndex = 1;
            this.colSalesPersonName.Width = 200;

            this.colPlanName.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId;
            this.colPlanName.FieldName = "PlanName";
            this.colPlanName.Name = "colPlanName";
            this.colPlanName.Visible = true;
            this.colPlanName.VisibleIndex = 2;
            this.colPlanName.Width = 200;

            this.colCalcMethod.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_CalcMethod;
            this.colCalcMethod.FieldName = "CalcMethodText";
            this.colCalcMethod.Name = "colCalcMethod";
            this.colCalcMethod.Visible = true;
            this.colCalcMethod.VisibleIndex = 3;
            this.colCalcMethod.Width = 200;

            this.colStartDate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_StartDate;
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 4;
            this.colStartDate.Width = 100;

            this.colEndDate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_EndDate;
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 5;
            this.colEndDate.Width = 100;

            this.colTargetAmount.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_TargetAmount;
            this.colTargetAmount.DisplayFormat.FormatString = "n2";
            this.colTargetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTargetAmount.FieldName = "TargetAmount";
            this.colTargetAmount.Name = "colTargetAmount";
            this.colTargetAmount.Visible = true;
            this.colTargetAmount.VisibleIndex = 6;
            this.colTargetAmount.Width = 120;

            this.colIsActive.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_IsActive;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 7;
            this.colIsActive.Width = 60;

            this.colNote.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_Note;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 8;
            this.colNote.Width = 250;
            //
            // FormSalesBonusAssignmentList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormSalesBonusAssignmentList";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusAssignmentList_Caption;
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
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanName;
        private DevExpress.XtraGrid.Columns.GridColumn colCalcMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}
