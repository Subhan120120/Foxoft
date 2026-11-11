namespace Foxoft
{
    partial class FormSalesBonusBatchAssign
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
            this.lkpPlan = new DevExpress.XtraEditors.LookUpEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.spinTargetAmount = new DevExpress.XtraEditors.SpinEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.chkCloseExisting = new DevExpress.XtraEditors.CheckEdit();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.lblSelectedCount = new DevExpress.XtraEditors.LabelControl();
            this.gridPersonnel = new MyGridControl();
            this.viewPersonnel = new MyGridView();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPositionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddendumNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseExisting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPersonnel)).BeginInit();
            this.SuspendLayout();

            // layout
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            // lkpPlan
            this.lkpPlan.Properties.DisplayMember = "PlanName";
            this.lkpPlan.Properties.ValueMember = "SalesBonusPlanId";
            this.lkpPlan.Properties.NullText = "";
            this.lkpPlan.Properties.ShowHeader = true;
            this.lkpPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPlan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPlan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpPlan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlanName", Foxoft.Properties.Resources.Entity_SalesBonusPlan_PlanName),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CalcMethodText", Foxoft.Properties.Resources.Entity_SalesBonusPlan_CalcMethod),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TriggerTypeText", Foxoft.Properties.Resources.Entity_SalesBonusPlan_TriggerType)
            });

            // dtStart
            this.dtStart.Properties.NullText = "";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            // dtEnd
            this.dtEnd.Properties.NullText = "";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            // spinTargetAmount
            this.spinTargetAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinTargetAmount.Properties.DisplayFormat.FormatString = "n2";
            this.spinTargetAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinTargetAmount.Properties.EditFormat.FormatString = "n2";
            this.spinTargetAmount.Properties.Mask.EditMask = "n2";
            this.spinTargetAmount.Properties.MinValue = 0m;
            this.spinTargetAmount.Properties.MaxValue = 1000000000m;
            this.spinTargetAmount.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinTargetAmount.Properties.NullText = "";

            // checkboxes
            this.chkIsActive.Text = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_IsActive;
            this.chkIsActive.Checked = true;
            this.chkCloseExisting.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_CloseExisting;
            this.chkCloseExisting.Checked = true;

            // buttons
            this.btnSelectAll.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_SelectAll;
            this.btnUnselectAll.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_UnselectAll;
            this.lblSelectedCount.Text = "";
            this.lblSelectedCount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

            this.btnSave.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_Assign;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            // gridPersonnel & viewPersonnel
            this.gridPersonnel.MainView = this.viewPersonnel;
            this.gridPersonnel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewPersonnel });
            this.viewPersonnel.GridControl = this.gridPersonnel;
            this.viewPersonnel.Name = "viewPersonnel";
            this.viewPersonnel.OptionsBehavior.Editable = false;
            this.viewPersonnel.OptionsSelection.MultiSelect = true;
            this.viewPersonnel.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.viewPersonnel.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.viewPersonnel.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.viewPersonnel.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = false;
            this.viewPersonnel.OptionsView.ShowAutoFilterRow = true;
            this.viewPersonnel.OptionsView.ShowGroupPanel = false;
            this.viewPersonnel.OptionsView.ColumnAutoWidth = true;

            this.colCurrAccCode.Caption = Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode;
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 1;
            this.colCurrAccCode.Width = 110;

            this.colFullName.Caption = Foxoft.Properties.Resources.Common_EmployeeName;
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            this.colFullName.Width = 200;

            this.colStoreCode.Caption = Foxoft.Properties.Resources.Entity_CurrAcc_StoreCode;
            this.colStoreCode.FieldName = "StoreCode";
            this.colStoreCode.Name = "colStoreCode";
            this.colStoreCode.Visible = true;
            this.colStoreCode.VisibleIndex = 3;
            this.colStoreCode.Width = 110;

            this.colPositionName.Caption = Foxoft.Properties.Resources.Entity_TrEmployeePosition_PositionId;
            this.colPositionName.FieldName = "PositionName";
            this.colPositionName.Name = "colPositionName";
            this.colPositionName.Visible = true;
            this.colPositionName.VisibleIndex = 4;
            this.colPositionName.Width = 140;

            this.colContractNumber.Caption = Foxoft.Properties.Resources.Entity_TrEmployeeContract_ContractNumber;
            this.colContractNumber.FieldName = "ContractNumber";
            this.colContractNumber.Name = "colContractNumber";
            this.colContractNumber.Visible = true;
            this.colContractNumber.VisibleIndex = 5;
            this.colContractNumber.Width = 100;

            this.colAddendumNumber.Caption = Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_AddendumNumber;
            this.colAddendumNumber.FieldName = "AddendumNumber";
            this.colAddendumNumber.Name = "colAddendumNumber";
            this.colAddendumNumber.Visible = true;
            this.colAddendumNumber.VisibleIndex = 6;
            this.colAddendumNumber.Width = 100;

            this.colCurrentPlan.Caption = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_CurrentPlan;
            this.colCurrentPlan.FieldName = "CurrentPlanName";
            this.colCurrentPlan.Name = "colCurrentPlan";
            this.colCurrentPlan.Visible = true;
            this.colCurrentPlan.VisibleIndex = 7;
            this.colCurrentPlan.Width = 160;

            this.viewPersonnel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCurrAccCode,
                this.colFullName,
                this.colStoreCode,
                this.colPositionName,
                this.colContractNumber,
                this.colAddendumNumber,
                this.colCurrentPlan
            });

            // layout hierarchy
            this.layout.Root = root;

            // Settings Group
            var grpSettings = root.AddGroup();
            grpSettings.Text = Foxoft.Properties.Resources.Form_SalesBonusAssignmentEdit_Caption_New;
            grpSettings.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;

            var itemPlan = grpSettings.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId, this.lkpPlan);

            var rowDates = grpSettings.AddGroup();
            rowDates.GroupBordersVisible = false;
            rowDates.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            rowDates.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_StartDate, this.dtStart);
            rowDates.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_EndDate, this.dtEnd);

            var rowTarget = grpSettings.AddGroup();
            rowTarget.GroupBordersVisible = false;
            rowTarget.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            rowTarget.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_TargetAmount, this.spinTargetAmount);
            rowTarget.AddItem("", this.chkIsActive).TextVisible = false;
            rowTarget.AddItem("", this.chkCloseExisting).TextVisible = false;

            grpSettings.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_Note, this.txtNote);

            // Personnel Group
            var grpPersonnel = root.AddGroup();
            grpPersonnel.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_Personnel;
            grpPersonnel.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;

            var rowQuick = grpPersonnel.AddGroup();
            rowQuick.GroupBordersVisible = false;
            rowQuick.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            rowQuick.AddItem("", this.btnSelectAll).TextVisible = false;
            rowQuick.AddItem("", this.btnUnselectAll).TextVisible = false;
            rowQuick.AddItem("", this.lblSelectedCount).TextVisible = false;

            grpPersonnel.AddItem("", this.gridPersonnel).TextVisible = false;

            // Bottom Buttons Group
            var grpButtons = root.AddGroup();
            grpButtons.GroupBordersVisible = false;
            grpButtons.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            grpButtons.AddItem("", this.btnSave).TextVisible = false;
            grpButtons.AddItem("", this.btnCancel).TextVisible = false;

            this.Controls.Add(this.layout);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Name = "FormSalesBonusBatchAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusBatchAssign_Title;

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseExisting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPersonnel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.LookUpEdit lkpPlan;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.SpinEdit spinTargetAmount;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.CheckEdit chkCloseExisting;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.LabelControl lblSelectedCount;
        private MyGridControl gridPersonnel;
        private MyGridView viewPersonnel;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colAddendumNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPlan;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}