namespace Foxoft
{
    partial class FormSalesBonusTxnList
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
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalculate = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdjustment = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetails = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControl();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnSalesPerson = new DevExpress.XtraEditors.ButtonEdit();
            this.lkpPlan = new DevExpress.XtraEditors.LookUpEdit();
            this.chkOnlyPending = new DevExpress.XtraEditors.CheckEdit();
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTxnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayrollStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            this.layoutFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOnlyPending.Properties)).BeginInit();
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
            this.btnRefresh,
            this.btnCalculate,
            this.btnAdjustment,
            this.btnDetails,
            this.btnClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1200, 158);
            //
            // buttons
            //
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 1;
            this.btnRefresh.Name = "btnRefresh";
            this.btnCalculate.Caption = Foxoft.Properties.Resources.Form_SalesBonusTxnList_Calculate;
            this.btnCalculate.Id = 2;
            this.btnCalculate.Name = "btnCalculate";
            this.btnAdjustment.Caption = Foxoft.Properties.Resources.Form_SalesBonusTxnList_Adjustment;
            this.btnAdjustment.Id = 3;
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnDetails.Caption = Foxoft.Properties.Resources.Form_SalesBonusTxnList_Details;
            this.btnDetails.Id = 4;
            this.btnDetails.Name = "btnDetails";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCalculate);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdjustment);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDetails);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = Foxoft.Properties.Resources.Form_SalesBonusTxnList_Caption;
            //
            // layoutFilter
            //
            this.layoutFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutFilter.Size = new System.Drawing.Size(1200, 62);
            var filterRoot = new DevExpress.XtraLayout.LayoutControlGroup
            {
                EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True,
                GroupBordersVisible = false,
                DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal
            };
            this.layoutFilter.Root = filterRoot;

            foreach (var dt in new[] { this.dtFrom, this.dtTo })
            {
                dt.Properties.NullText = "";
                dt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
                dt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            }

            this.btnSalesPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnSalesPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });

            this.lkpPlan.Properties.DisplayMember = "PlanName";
            this.lkpPlan.Properties.ValueMember = "SalesBonusPlanId";
            this.lkpPlan.Properties.NullText = "";
            this.lkpPlan.Properties.ShowHeader = false;
            this.lkpPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPlan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPlan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });
            this.lkpPlan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlanName", "") });

            this.chkOnlyPending.Text = Foxoft.Properties.Resources.Form_SalesBonusTxnList_OnlyPending;

            this.layoutFilter.AddItem(Foxoft.Properties.Resources.Form_SalesBonusTxnList_DateFrom, this.dtFrom);
            this.layoutFilter.AddItem(Foxoft.Properties.Resources.Form_SalesBonusTxnList_DateTo, this.dtTo);
            this.layoutFilter.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode, this.btnSalesPerson);
            this.layoutFilter.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId, this.lkpPlan);
            this.layoutFilter.AddItem("", this.chkOnlyPending);
            //
            // gridControl1
            //
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // gridView1
            //
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentDate,
            this.colTxnType,
            this.colSalesPersonCode,
            this.colSalesPersonName,
            this.colPlanName,
            this.colPeriod,
            this.colBaseAmount,
            this.colRate,
            this.colAmount,
            this.colInvoice,
            this.colPayment,
            this.colPayrollStatus,
            this.colNote,
            this.colCreatedUserName,
            this.colCreatedDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            //
            // columns
            //
            this.colDocumentDate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_DocumentDate;
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 0;
            this.colDocumentDate.Width = 90;

            this.colTxnType.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_TxnType;
            this.colTxnType.FieldName = "TxnTypeText";
            this.colTxnType.Name = "colTxnType";
            this.colTxnType.Visible = true;
            this.colTxnType.VisibleIndex = 1;
            this.colTxnType.Width = 110;

            this.colSalesPersonCode.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode;
            this.colSalesPersonCode.FieldName = "SalesPersonCode";
            this.colSalesPersonCode.Name = "colSalesPersonCode";
            this.colSalesPersonCode.Visible = true;
            this.colSalesPersonCode.VisibleIndex = 2;
            this.colSalesPersonCode.Width = 100;

            this.colSalesPersonName.Caption = Foxoft.Properties.Resources.Common_EmployeeName;
            this.colSalesPersonName.FieldName = "SalesPersonName";
            this.colSalesPersonName.Name = "colSalesPersonName";
            this.colSalesPersonName.Visible = true;
            this.colSalesPersonName.VisibleIndex = 3;
            this.colSalesPersonName.Width = 160;

            this.colPlanName.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId;
            this.colPlanName.FieldName = "PlanName";
            this.colPlanName.Name = "colPlanName";
            this.colPlanName.Visible = true;
            this.colPlanName.VisibleIndex = 4;
            this.colPlanName.Width = 160;

            this.colPeriod.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_Period;
            this.colPeriod.FieldName = "PeriodText";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.Visible = true;
            this.colPeriod.VisibleIndex = 5;
            this.colPeriod.Width = 80;

            this.colBaseAmount.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_BaseAmount;
            this.colBaseAmount.DisplayFormat.FormatString = "n2";
            this.colBaseAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseAmount.FieldName = "BaseAmount";
            this.colBaseAmount.Name = "colBaseAmount";
            this.colBaseAmount.Visible = true;
            this.colBaseAmount.VisibleIndex = 6;
            this.colBaseAmount.Width = 110;

            this.colRate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_Rate;
            this.colRate.DisplayFormat.FormatString = "n4";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 7;
            this.colRate.Width = 80;

            this.colAmount.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_Amount;
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}") });
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 8;
            this.colAmount.Width = 110;

            this.colInvoice.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_InvoiceDocumentNumber;
            this.colInvoice.FieldName = "InvoiceDocumentNumber";
            this.colInvoice.Name = "colInvoice";
            this.colInvoice.Visible = true;
            this.colInvoice.VisibleIndex = 9;
            this.colInvoice.Width = 110;

            this.colPayment.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_PaymentDocumentNumber;
            this.colPayment.FieldName = "PaymentDocumentNumber";
            this.colPayment.Name = "colPayment";
            this.colPayment.Visible = true;
            this.colPayment.VisibleIndex = 10;
            this.colPayment.Width = 110;

            this.colPayrollStatus.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_PayrollStatus;
            this.colPayrollStatus.FieldName = "PayrollStatusText";
            this.colPayrollStatus.Name = "colPayrollStatus";
            this.colPayrollStatus.Visible = true;
            this.colPayrollStatus.VisibleIndex = 11;
            this.colPayrollStatus.Width = 150;

            this.colNote.Caption = Foxoft.Properties.Resources.Entity_SalesBonusTxn_Note;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 12;
            this.colNote.Width = 200;

            this.colCreatedUserName.Caption = Foxoft.Properties.Resources.Entity_Base_CreatedUserName;
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 13;
            this.colCreatedUserName.Width = 100;

            this.colCreatedDate.Caption = Foxoft.Properties.Resources.Entity_Base_CreatedDate;
            this.colCreatedDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 14;
            this.colCreatedDate.Width = 120;
            //
            // FormSalesBonusTxnList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutFilter);
            this.Controls.Add(this.ribbon);
            this.Name = "FormSalesBonusTxnList";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusTxnList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            this.layoutFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOnlyPending.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCalculate;
        private DevExpress.XtraBars.BarButtonItem btnAdjustment;
        private DevExpress.XtraBars.BarButtonItem btnDetails;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutFilter;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.ButtonEdit btnSalesPerson;
        private DevExpress.XtraEditors.LookUpEdit lkpPlan;
        private DevExpress.XtraEditors.CheckEdit chkOnlyPending;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTxnType;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanName;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colPayrollStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
    }
}
