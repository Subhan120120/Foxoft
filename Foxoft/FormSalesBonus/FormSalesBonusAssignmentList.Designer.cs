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
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnNew = new DevExpress.XtraBars.BarButtonItem();
            btnBatchAssign = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            btnClose = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridControl1 = new MyGridControl();
            gridView1 = new MyGridView();
            colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colSalesPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlanName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCalcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colTargetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, btnNew, btnBatchAssign, btnEdit, btnDelete, btnRefresh, btnClose });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 7;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(1100, 158);
            // 
            // btnNew
            // 
            btnNew.Caption = Properties.Resources.Common_New;
            btnNew.Id = 1;
            btnNew.Name = "btnNew";
            // 
            // btnBatchAssign
            // 
            btnBatchAssign.Caption = Properties.Resources.Form_SalesBonusAssignmentList_BatchAssign;
            btnBatchAssign.Id = 6;
            btnBatchAssign.Name = "btnBatchAssign";
            // 
            // btnEdit
            // 
            btnEdit.Caption = Properties.Resources.Common_Edit;
            btnEdit.Id = 2;
            btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            btnDelete.Caption = Properties.Resources.Common_Delete;
            btnDelete.Id = 3;
            btnDelete.Name = "btnDelete";
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = Properties.Resources.Common_Refresh;
            btnRefresh.Id = 4;
            btnRefresh.Name = "btnRefresh";
            // 
            // btnClose
            // 
            btnClose.Caption = Properties.Resources.Common_Close;
            btnClose.Id = 5;
            btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Properties.Resources.ERP_ACE_HumanResource;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnNew);
            ribbonPageGroup1.ItemLinks.Add(btnBatchAssign);
            ribbonPageGroup1.ItemLinks.Add(btnEdit);
            ribbonPageGroup1.ItemLinks.Add(btnDelete);
            ribbonPageGroup1.ItemLinks.Add(btnRefresh);
            ribbonPageGroup1.ItemLinks.Add(btnClose);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Properties.Resources.Form_SalesBonusAssignmentList_Caption;
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbon;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1100, 542);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSalesPersonCode, colSalesPersonName, colPlanName, colCalcMethod, colStartDate, colEndDate, colTargetAmount, colIsActive, colNote });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSalesPersonCode
            // 
            colSalesPersonCode.Caption = Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode;
            colSalesPersonCode.FieldName = "SalesPersonCode";
            colSalesPersonCode.Name = "colSalesPersonCode";
            colSalesPersonCode.Visible = true;
            colSalesPersonCode.VisibleIndex = 0;
            colSalesPersonCode.Width = 110;
            // 
            // colSalesPersonName
            // 
            colSalesPersonName.Caption = Properties.Resources.Common_EmployeeName;
            colSalesPersonName.FieldName = "SalesPersonName";
            colSalesPersonName.Name = "colSalesPersonName";
            colSalesPersonName.Visible = true;
            colSalesPersonName.VisibleIndex = 1;
            colSalesPersonName.Width = 200;
            // 
            // colPlanName
            // 
            colPlanName.Caption = Properties.Resources.Entity_SalesBonusAssignment_PlanId;
            colPlanName.FieldName = "PlanName";
            colPlanName.Name = "colPlanName";
            colPlanName.Visible = true;
            colPlanName.VisibleIndex = 2;
            colPlanName.Width = 200;
            // 
            // colCalcMethod
            // 
            colCalcMethod.Caption = Properties.Resources.Entity_SalesBonusPlan_CalcMethod;
            colCalcMethod.FieldName = "CalcMethodText";
            colCalcMethod.Name = "colCalcMethod";
            colCalcMethod.Visible = true;
            colCalcMethod.VisibleIndex = 3;
            colCalcMethod.Width = 200;
            // 
            // colStartDate
            // 
            colStartDate.Caption = Properties.Resources.Entity_SalesBonusAssignment_StartDate;
            colStartDate.FieldName = "StartDate";
            colStartDate.Name = "colStartDate";
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 4;
            colStartDate.Width = 100;
            // 
            // colEndDate
            // 
            colEndDate.Caption = Properties.Resources.Entity_SalesBonusAssignment_EndDate;
            colEndDate.FieldName = "EndDate";
            colEndDate.Name = "colEndDate";
            colEndDate.Visible = true;
            colEndDate.VisibleIndex = 5;
            colEndDate.Width = 100;
            // 
            // colTargetAmount
            // 
            colTargetAmount.Caption = Properties.Resources.Entity_SalesBonusAssignment_TargetAmount;
            colTargetAmount.DisplayFormat.FormatString = "n2";
            colTargetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTargetAmount.FieldName = "TargetAmount";
            colTargetAmount.Name = "colTargetAmount";
            colTargetAmount.Visible = true;
            colTargetAmount.VisibleIndex = 6;
            colTargetAmount.Width = 120;
            // 
            // colIsActive
            // 
            colIsActive.Caption = Properties.Resources.Entity_SalesBonusAssignment_IsActive;
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 7;
            colIsActive.Width = 60;
            // 
            // colNote
            // 
            colNote.Caption = Properties.Resources.Entity_SalesBonusAssignment_Note;
            colNote.FieldName = "Note";
            colNote.Name = "colNote";
            colNote.Visible = true;
            colNote.VisibleIndex = 8;
            colNote.Width = 250;
            // 
            // FormSalesBonusAssignmentList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(gridControl1);
            Controls.Add(ribbon);
            Name = "FormSalesBonusAssignmentList";
            Ribbon = ribbon;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bonus Plan Assignments";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnBatchAssign;
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
