namespace Foxoft
{
    partial class FormPayrollWizard
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
            wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            lblWelcomeInfo = new DevExpress.XtraEditors.LabelControl();
            lblSelectPeriod = new DevExpress.XtraEditors.LabelControl();
            lkpPeriod = new DevExpress.XtraEditors.LookUpEdit();
            wizardPageEmployees = new DevExpress.XtraWizard.WizardPage();
            gridControlEmployees = new MyGridControl();
            gridViewEmployees = new MyGridView();
            colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPositionName = new DevExpress.XtraGrid.Columns.GridColumn();
            colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcBaseSalary = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcBonus = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colDeduction = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcDeduction = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colGrossSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            colNetSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLookUpCurrency = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcExchangeRate = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colNetSalaryLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviousBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceAfterPayroll = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            panelControlTop = new DevExpress.XtraEditors.PanelControl();
            btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            btnSendWhatsapp = new DevExpress.XtraEditors.SimpleButton();
            wizardPagePaymentSettings = new DevExpress.XtraWizard.WizardPage();
            layoutControlPaymentSettings = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            groupPaymentSettings = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutItemAutoPay = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCashRegister = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentDate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentMethod = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentExchangeRate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentDesc = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPaymentRule = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSettingsInfo = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItemBottom = new DevExpress.XtraLayout.EmptySpaceItem();
            chkAutoPayBalances = new DevExpress.XtraEditors.CheckEdit();
            lkpCashRegister = new DevExpress.XtraEditors.LookUpEdit();
            dtPaymentDate = new DevExpress.XtraEditors.DateEdit();
            lkpPaymentMethod = new DevExpress.XtraEditors.LookUpEdit();
            lkpPaymentCurrency = new DevExpress.XtraEditors.LookUpEdit();
            calcPaymentExchangeRate = new DevExpress.XtraEditors.CalcEdit();
            txtPaymentDesc = new DevExpress.XtraEditors.TextEdit();
            rgPaymentRule = new DevExpress.XtraEditors.RadioGroup();
            lblPaymentSettingsInfo = new DevExpress.XtraEditors.LabelControl();
            wizardPagePaymentList = new DevExpress.XtraWizard.WizardPage();
            gridControlPayment = new MyGridControl();
            gridViewPayment = new MyGridView();
            colPaySelected = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckPaySelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colPayCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayPositionName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayNetSalaryLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayBalanceAfterPayroll = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcPayAmount = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colPayCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLookUpPayCashRegister = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colPayCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPayDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            panelControlPaymentButtons = new DevExpress.XtraEditors.PanelControl();
            btnPaySelectAll = new DevExpress.XtraEditors.SimpleButton();
            btnPayUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            btnApplyBalances = new DevExpress.XtraEditors.SimpleButton();
            btnApplyNetSalaries = new DevExpress.XtraEditors.SimpleButton();
            btnResetPayments = new DevExpress.XtraEditors.SimpleButton();
            btnPayExportExcel = new DevExpress.XtraEditors.SimpleButton();
            completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            lblCompletionInfo = new DevExpress.XtraEditors.LabelControl();
            lblSummary = new DevExpress.XtraEditors.LabelControl();
            chkExportPaymentsOnFinish = new DevExpress.XtraEditors.CheckEdit();
            chkSendWhatsappOnFinish = new DevExpress.XtraEditors.CheckEdit();
            btnExportPaymentsCompletion = new DevExpress.XtraEditors.SimpleButton();
            btnSendWhatsappCompletion = new DevExpress.XtraEditors.SimpleButton();
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            ((System.ComponentModel.ISupportInitialize)wizardControl1).BeginInit();
            wizardControl1.SuspendLayout();
            welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lkpPeriod.Properties).BeginInit();
            wizardPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcBaseSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcDeduction).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLookUpCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcExchangeRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).BeginInit();
            panelControlTop.SuspendLayout();
            wizardPagePaymentSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkAutoPayBalances.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlPaymentSettings).BeginInit();
            layoutControlPaymentSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupRoot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupPaymentSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemAutoPay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemCashRegister).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentMethod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentExchangeRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentRule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemSettingsInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkAutoPayBalances.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkpCashRegister.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkpPaymentMethod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkpPaymentCurrency.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcPaymentExchangeRate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentDesc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentRule.Properties).BeginInit();
            wizardPagePaymentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckPaySelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcPayAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLookUpPayCashRegister).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlPaymentButtons).BeginInit();
            panelControlPaymentButtons.SuspendLayout();
            completionWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkExportPaymentsOnFinish.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSendWhatsappOnFinish.Properties).BeginInit();
            SuspendLayout();
            // 
            // wizardControl1
            // 
            wizardControl1.Controls.Add(welcomeWizardPage1);
            wizardControl1.Controls.Add(wizardPageEmployees);
            wizardControl1.Controls.Add(wizardPagePaymentSettings);
            wizardControl1.Controls.Add(wizardPagePaymentList);
            wizardControl1.Controls.Add(completionWizardPage1);
            wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            wizardControl1.ImageOptions.ImageWidth = 200;
            wizardControl1.Name = "wizardControl1";
            wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { welcomeWizardPage1, wizardPageEmployees, wizardPagePaymentSettings, wizardPagePaymentList, completionWizardPage1 });
            wizardControl1.Size = new System.Drawing.Size(1000, 600);
            wizardControl1.Text = "Payroll Calculation Wizard";
            wizardControl1.CancelClick += WizardControl1_CancelClick;
            wizardControl1.FinishClick += WizardControl1_FinishClick;
            wizardControl1.NextClick += WizardControl1_NextClick;
            wizardControl1.PrevClick += WizardControl1_PrevClick;
            // 
            // welcomeWizardPage1
            // 
            welcomeWizardPage1.Controls.Add(lblWelcomeInfo);
            welcomeWizardPage1.Controls.Add(lblSelectPeriod);
            welcomeWizardPage1.Controls.Add(lkpPeriod);
            welcomeWizardPage1.IntroductionText = Properties.Resources.Form_PayrollWizard_WelcomeText;
            welcomeWizardPage1.Name = "welcomeWizardPage1";
            welcomeWizardPage1.Size = new System.Drawing.Size(768, 468);
            welcomeWizardPage1.Text = "Welcome to Payroll Calculation Wizard";
            // 
            // lblWelcomeInfo
            // 
            lblWelcomeInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblWelcomeInfo.Appearance.Options.UseFont = true;
            lblWelcomeInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblWelcomeInfo.Location = new System.Drawing.Point(30, 40);
            lblWelcomeInfo.Name = "lblWelcomeInfo";
            lblWelcomeInfo.Size = new System.Drawing.Size(500, 34);
            lblWelcomeInfo.TabIndex = 0;
            lblWelcomeInfo.Text = "This wizard allows you to automatically calculate salaries for employees based on active contracts.";
            // 
            // lblSelectPeriod
            // 
            lblSelectPeriod.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSelectPeriod.Appearance.Options.UseFont = true;
            lblSelectPeriod.Location = new System.Drawing.Point(30, 100);
            lblSelectPeriod.Name = "lblSelectPeriod";
            lblSelectPeriod.Size = new System.Drawing.Size(114, 15);
            lblSelectPeriod.TabIndex = 1;
            lblSelectPeriod.Text = "Select Payroll Period";
            // 
            // lkpPeriod
            // 
            lkpPeriod.Location = new System.Drawing.Point(30, 125);
            lkpPeriod.Name = "lkpPeriod";
            lkpPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodName", Properties.Resources.Entity_TrPayrollHeader_PeriodId) });
            lkpPeriod.Properties.DisplayMember = "PeriodName";
            lkpPeriod.Properties.NullText = Properties.Resources.Form_PayrollWizard_SelectPeriod;
            lkpPeriod.Properties.ValueMember = "Id";
            lkpPeriod.Size = new System.Drawing.Size(260, 20);
            lkpPeriod.TabIndex = 2;
            lkpPeriod.EditValueChanged += LkpPeriod_EditValueChanged;
            // 
            // wizardPageEmployees
            // 
            wizardPageEmployees.Controls.Add(gridControlEmployees);
            wizardPageEmployees.Controls.Add(panelControlTop);
            wizardPageEmployees.DescriptionText = Properties.Resources.Form_PayrollWizard_EmployeesText;
            wizardPageEmployees.Name = "wizardPageEmployees";
            wizardPageEmployees.Size = new System.Drawing.Size(968, 457);
            wizardPageEmployees.Text = "Employee Salaries";
            // 
            // gridControlEmployees
            // 
            gridControlEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlEmployees.Location = new System.Drawing.Point(0, 36);
            gridControlEmployees.MainView = gridViewEmployees;
            gridControlEmployees.Name = "gridControlEmployees";
            gridControlEmployees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoCheckSelected, repoCalcBaseSalary, repoCalcBonus, repoCalcDeduction, repoLookUpCurrency, repoCalcExchangeRate });
            gridControlEmployees.Size = new System.Drawing.Size(968, 421);
            gridControlEmployees.TabIndex = 1;
            gridControlEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewEmployees });
            // 
            // gridViewEmployees
            // 
            gridViewEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSelected, colCurrAccCode, colEmployeeName, colPositionName, colDepartmentName, colBaseSalary, colBonus, colDeduction, colGrossSalary, colNetSalary, colCurrencyCode, colExchangeRate, colNetSalaryLoc, colPreviousBalance, colBalanceAfterPayroll, colStatus });
            gridViewEmployees.GridControl = gridControlEmployees;
            gridViewEmployees.Name = "gridViewEmployees";
            gridViewEmployees.OptionsView.ColumnAutoWidth = false;
            gridViewEmployees.OptionsView.ShowAutoFilterRow = true;
            gridViewEmployees.OptionsView.ShowFooter = true;
            gridViewEmployees.CustomDrawRowIndicator += GridViewEmployees_CustomDrawRowIndicator;
            gridViewEmployees.CellValueChanged += GridViewEmployees_CellValueChanged;
            // 
            // colSelected
            // 
            colSelected.Caption = Properties.Resources.Common_Select;
            colSelected.ColumnEdit = repoCheckSelected;
            colSelected.FieldName = "Selected";
            colSelected.Name = "colSelected";
            colSelected.Visible = true;
            colSelected.VisibleIndex = 0;
            colSelected.Width = 55;
            // 
            // repoCheckSelected
            // 
            repoCheckSelected.AutoHeight = false;
            repoCheckSelected.Name = "repoCheckSelected";
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = Properties.Resources.Entity_TrPayrollHeader_CurrAccCode;
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.OptionsColumn.AllowEdit = false;
            colCurrAccCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CurrAccCode", "{0}") });
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 1;
            colCurrAccCode.Width = 90;
            // 
            // colEmployeeName
            // 
            colEmployeeName.Caption = Properties.Resources.Common_EmployeeName;
            colEmployeeName.FieldName = "EmployeeName";
            colEmployeeName.Name = "colEmployeeName";
            colEmployeeName.OptionsColumn.AllowEdit = false;
            colEmployeeName.Visible = true;
            colEmployeeName.VisibleIndex = 2;
            colEmployeeName.Width = 160;
            // 
            // colPositionName
            // 
            colPositionName.Caption = Properties.Resources.Entity_DcPosition_PositionName;
            colPositionName.FieldName = "PositionName";
            colPositionName.Name = "colPositionName";
            colPositionName.OptionsColumn.AllowEdit = false;
            colPositionName.Visible = true;
            colPositionName.VisibleIndex = 3;
            colPositionName.Width = 120;
            // 
            // colDepartmentName
            // 
            colDepartmentName.Caption = Properties.Resources.Entity_DcDepartment_DepartmentName;
            colDepartmentName.FieldName = "DepartmentName";
            colDepartmentName.Name = "colDepartmentName";
            colDepartmentName.OptionsColumn.AllowEdit = false;
            colDepartmentName.Visible = true;
            colDepartmentName.VisibleIndex = 4;
            colDepartmentName.Width = 120;
            // 
            // colBaseSalary
            // 
            colBaseSalary.Caption = Properties.Resources.Entity_TrPayrollHeader_BaseSalary;
            colBaseSalary.ColumnEdit = repoCalcBaseSalary;
            colBaseSalary.DisplayFormat.FormatString = "n2";
            colBaseSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBaseSalary.FieldName = "BaseSalary";
            colBaseSalary.Name = "colBaseSalary";
            colBaseSalary.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BaseSalary", "{0:n2}") });
            colBaseSalary.Visible = true;
            colBaseSalary.VisibleIndex = 5;
            colBaseSalary.Width = 100;
            // 
            // repoCalcBaseSalary
            // 
            repoCalcBaseSalary.AutoHeight = false;
            repoCalcBaseSalary.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcBaseSalary.DisplayFormat.FormatString = "n2";
            repoCalcBaseSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcBaseSalary.EditFormat.FormatString = "n2";
            repoCalcBaseSalary.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcBaseSalary.Mask.EditMask = "n2";
            repoCalcBaseSalary.Name = "repoCalcBaseSalary";
            // 
            // colBonus
            // 
            colBonus.Caption = Properties.Resources.Entity_TrPayrollHeader_Bonus;
            colBonus.ColumnEdit = repoCalcBonus;
            colBonus.DisplayFormat.FormatString = "n2";
            colBonus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBonus.FieldName = "Bonus";
            colBonus.Name = "colBonus";
            colBonus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bonus", "{0:n2}") });
            colBonus.Visible = true;
            colBonus.VisibleIndex = 6;
            colBonus.Width = 90;
            // 
            // repoCalcBonus
            // 
            repoCalcBonus.AutoHeight = false;
            repoCalcBonus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcBonus.DisplayFormat.FormatString = "n2";
            repoCalcBonus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcBonus.EditFormat.FormatString = "n2";
            repoCalcBonus.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcBonus.Mask.EditMask = "n2";
            repoCalcBonus.Name = "repoCalcBonus";
            // 
            // colDeduction
            // 
            colDeduction.Caption = Properties.Resources.Entity_TrPayrollHeader_Deduction;
            colDeduction.ColumnEdit = repoCalcDeduction;
            colDeduction.DisplayFormat.FormatString = "n2";
            colDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDeduction.FieldName = "Deduction";
            colDeduction.Name = "colDeduction";
            colDeduction.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Deduction", "{0:n2}") });
            colDeduction.Visible = true;
            colDeduction.VisibleIndex = 7;
            colDeduction.Width = 90;
            // 
            // repoCalcDeduction
            // 
            repoCalcDeduction.AutoHeight = false;
            repoCalcDeduction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcDeduction.DisplayFormat.FormatString = "n2";
            repoCalcDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcDeduction.EditFormat.FormatString = "n2";
            repoCalcDeduction.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcDeduction.Mask.EditMask = "n2";
            repoCalcDeduction.Name = "repoCalcDeduction";
            // 
            // colGrossSalary
            // 
            colGrossSalary.Caption = Properties.Resources.Entity_TrPayrollHeader_GrossSalary;
            colGrossSalary.DisplayFormat.FormatString = "n2";
            colGrossSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGrossSalary.FieldName = "GrossSalary";
            colGrossSalary.Name = "colGrossSalary";
            colGrossSalary.OptionsColumn.AllowEdit = false;
            colGrossSalary.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrossSalary", "{0:n2}") });
            colGrossSalary.Visible = true;
            colGrossSalary.VisibleIndex = 8;
            colGrossSalary.Width = 100;
            // 
            // colNetSalary
            // 
            colNetSalary.Caption = Properties.Resources.Entity_TrPayrollHeader_NetSalary;
            colNetSalary.DisplayFormat.FormatString = "n2";
            colNetSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNetSalary.FieldName = "NetSalary";
            colNetSalary.Name = "colNetSalary";
            colNetSalary.OptionsColumn.AllowEdit = false;
            colNetSalary.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSalary", "{0:n2}") });
            colNetSalary.Visible = true;
            colNetSalary.VisibleIndex = 9;
            colNetSalary.Width = 100;
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.Caption = Properties.Resources.Entity_Currency_Code;
            colCurrencyCode.ColumnEdit = repoLookUpCurrency;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 10;
            colCurrencyCode.Width = 70;
            // 
            // repoLookUpCurrency
            // 
            repoLookUpCurrency.AutoHeight = false;
            repoLookUpCurrency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLookUpCurrency.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", Properties.Resources.Entity_Currency_Code),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", Properties.Resources.Entity_Currency_Desc),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExchangeRate", Properties.Resources.Entity_Currency_ExchangeRate, 20, DevExpress.Utils.FormatType.Numeric, "n4", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)
            });
            repoLookUpCurrency.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoLookUpCurrency.DisplayMember = "CurrencyCode";
            repoLookUpCurrency.NullText = "";
            repoLookUpCurrency.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repoLookUpCurrency.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            repoLookUpCurrency.ValueMember = "CurrencyCode";
            repoLookUpCurrency.Name = "repoLookUpCurrency";
            repoLookUpCurrency.EditValueChanged += RepoLookUpCurrency_EditValueChanged;
            // 
            // colExchangeRate
            // 
            colExchangeRate.Caption = Properties.Resources.Entity_Currency_ExchangeRate;
            colExchangeRate.ColumnEdit = repoCalcExchangeRate;
            colExchangeRate.DisplayFormat.FormatString = "n4";
            colExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            colExchangeRate.Visible = true;
            colExchangeRate.VisibleIndex = 11;
            colExchangeRate.Width = 85;
            // 
            // repoCalcExchangeRate
            // 
            repoCalcExchangeRate.AutoHeight = false;
            repoCalcExchangeRate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcExchangeRate.DisplayFormat.FormatString = "n4";
            repoCalcExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcExchangeRate.EditFormat.FormatString = "n4";
            repoCalcExchangeRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcExchangeRate.Mask.EditMask = "n4";
            repoCalcExchangeRate.Name = "repoCalcExchangeRate";
            // 
            // colNetSalaryLoc
            // 
            colNetSalaryLoc.Caption = Properties.Resources.Entity_InvoiceLine_AmountLoc;
            colNetSalaryLoc.DisplayFormat.FormatString = "n2";
            colNetSalaryLoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNetSalaryLoc.FieldName = "NetSalaryLoc";
            colNetSalaryLoc.Name = "colNetSalaryLoc";
            colNetSalaryLoc.OptionsColumn.AllowEdit = false;
            colNetSalaryLoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSalaryLoc", "{0:n2}") });
            colNetSalaryLoc.Visible = true;
            colNetSalaryLoc.VisibleIndex = 12;
            colNetSalaryLoc.Width = 100;
            // 
            // colPreviousBalance
            // 
            colPreviousBalance.Caption = Properties.Resources.Form_PayrollWizard_ColPreviousBalance;
            colPreviousBalance.DisplayFormat.FormatString = "n2";
            colPreviousBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviousBalance.FieldName = "PreviousBalance";
            colPreviousBalance.Name = "colPreviousBalance";
            colPreviousBalance.OptionsColumn.AllowEdit = false;
            colPreviousBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PreviousBalance", "{0:n2}") });
            colPreviousBalance.Visible = true;
            colPreviousBalance.VisibleIndex = 13;
            colPreviousBalance.Width = 105;
            // 
            // colBalanceAfterPayroll
            // 
            colBalanceAfterPayroll.Caption = Properties.Resources.Form_PayrollWizard_ColBalanceAfterPayroll;
            colBalanceAfterPayroll.DisplayFormat.FormatString = "n2";
            colBalanceAfterPayroll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBalanceAfterPayroll.FieldName = "BalanceAfterPayroll";
            colBalanceAfterPayroll.Name = "colBalanceAfterPayroll";
            colBalanceAfterPayroll.OptionsColumn.AllowEdit = false;
            colBalanceAfterPayroll.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceAfterPayroll", "{0:n2}") });
            colBalanceAfterPayroll.Visible = true;
            colBalanceAfterPayroll.VisibleIndex = 14;
            colBalanceAfterPayroll.Width = 115;
            // 
            // colStatus
            // 
            colStatus.Caption = Properties.Resources.Common_Status;
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 15;
            colStatus.Width = 90;
            // 
            // panelControlTop
            // 
            panelControlTop.Controls.Add(btnSelectAll);
            panelControlTop.Controls.Add(btnUnselectAll);
            panelControlTop.Controls.Add(btnSendWhatsapp);
            panelControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelControlTop.Location = new System.Drawing.Point(0, 0);
            panelControlTop.Name = "panelControlTop";
            panelControlTop.Size = new System.Drawing.Size(968, 36);
            panelControlTop.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new System.Drawing.Point(5, 5);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new System.Drawing.Size(100, 25);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = Properties.Resources.Common_SelectAll;
            btnSelectAll.Click += BtnSelectAll_Click;
            // 
            // btnUnselectAll
            // 
            btnUnselectAll.Location = new System.Drawing.Point(110, 5);
            btnUnselectAll.Name = "btnUnselectAll";
            btnUnselectAll.Size = new System.Drawing.Size(100, 25);
            btnUnselectAll.TabIndex = 1;
            btnUnselectAll.Text = Properties.Resources.Common_UnselectAll;
            btnUnselectAll.Click += BtnUnselectAll_Click;
            // 
            // btnSendWhatsapp
            // 
            btnSendWhatsapp.Location = new System.Drawing.Point(215, 5);
            btnSendWhatsapp.Name = "btnSendWhatsapp";
            btnSendWhatsapp.Size = new System.Drawing.Size(160, 25);
            btnSendWhatsapp.TabIndex = 2;
            btnSendWhatsapp.Text = Properties.Resources.Form_PayrollWizard_Button_SendWhatsapp;
            btnSendWhatsapp.Click += BtnSendWhatsapp_Click;
            // 
            // wizardPagePaymentSettings
            // 
            wizardPagePaymentSettings.Controls.Add(layoutControlPaymentSettings);
            wizardPagePaymentSettings.DescriptionText = Properties.Resources.Form_PayrollWizard_PaymentSettingsPageText;
            wizardPagePaymentSettings.Name = "wizardPagePaymentSettings";
            wizardPagePaymentSettings.Size = new System.Drawing.Size(968, 457);
            wizardPagePaymentSettings.Text = Properties.Resources.Form_PayrollWizard_PaymentSettingsPageCaption;
            // 
            // layoutControlPaymentSettings
            // 
            layoutControlPaymentSettings.Controls.Add(chkAutoPayBalances);
            layoutControlPaymentSettings.Controls.Add(lkpCashRegister);
            layoutControlPaymentSettings.Controls.Add(dtPaymentDate);
            layoutControlPaymentSettings.Controls.Add(lkpPaymentMethod);
            layoutControlPaymentSettings.Controls.Add(lkpPaymentCurrency);
            layoutControlPaymentSettings.Controls.Add(calcPaymentExchangeRate);
            layoutControlPaymentSettings.Controls.Add(txtPaymentDesc);
            layoutControlPaymentSettings.Controls.Add(rgPaymentRule);
            layoutControlPaymentSettings.Controls.Add(lblPaymentSettingsInfo);
            layoutControlPaymentSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlPaymentSettings.Location = new System.Drawing.Point(0, 0);
            layoutControlPaymentSettings.Name = "layoutControlPaymentSettings";
            layoutControlPaymentSettings.Root = layoutControlGroupRoot;
            layoutControlPaymentSettings.Size = new System.Drawing.Size(968, 457);
            layoutControlPaymentSettings.TabIndex = 0;
            // 
            // chkAutoPayBalances
            // 
            chkAutoPayBalances.EditValue = true;
            chkAutoPayBalances.Location = new System.Drawing.Point(12, 12);
            chkAutoPayBalances.Name = "chkAutoPayBalances";
            chkAutoPayBalances.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            chkAutoPayBalances.Properties.Appearance.Options.UseFont = true;
            chkAutoPayBalances.Properties.Caption = Properties.Resources.Form_PayrollWizard_AutoPayBalances;
            chkAutoPayBalances.Size = new System.Drawing.Size(944, 21);
            chkAutoPayBalances.StyleController = layoutControlPaymentSettings;
            chkAutoPayBalances.TabIndex = 0;
            chkAutoPayBalances.CheckedChanged += ChkAutoPayBalances_CheckedChanged;
            // 
            // lkpCashRegister
            // 
            lkpCashRegister.Location = new System.Drawing.Point(145, 69);
            lkpCashRegister.Name = "lkpCashRegister";
            lkpCashRegister.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpCashRegister.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", Properties.Resources.Entity_CurrAcc_Code),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", Properties.Resources.Entity_CurrAcc_Desc)
            });
            lkpCashRegister.Properties.DisplayMember = "CurrAccDesc";
            lkpCashRegister.Properties.NullText = "";
            lkpCashRegister.Properties.ValueMember = "CurrAccCode";
            lkpCashRegister.Size = new System.Drawing.Size(325, 20);
            lkpCashRegister.StyleController = layoutControlPaymentSettings;
            lkpCashRegister.TabIndex = 1;
            lkpCashRegister.EditValueChanged += LkpCashRegister_EditValueChanged;
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.EditValue = null;
            dtPaymentDate.Location = new System.Drawing.Point(607, 69);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Size = new System.Drawing.Size(337, 20);
            dtPaymentDate.StyleController = layoutControlPaymentSettings;
            dtPaymentDate.TabIndex = 2;
            // 
            // lkpPaymentMethod
            // 
            lkpPaymentMethod.Location = new System.Drawing.Point(145, 93);
            lkpPaymentMethod.Name = "lkpPaymentMethod";
            lkpPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpPaymentMethod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentMethodDesc", Properties.Resources.Entity_PaymentMethod_Desc)
            });
            lkpPaymentMethod.Properties.DisplayMember = "PaymentMethodDesc";
            lkpPaymentMethod.Properties.NullText = "";
            lkpPaymentMethod.Properties.ValueMember = "PaymentMethodId";
            lkpPaymentMethod.Size = new System.Drawing.Size(325, 20);
            lkpPaymentMethod.StyleController = layoutControlPaymentSettings;
            lkpPaymentMethod.TabIndex = 3;
            // 
            // lkpPaymentCurrency
            // 
            lkpPaymentCurrency.Location = new System.Drawing.Point(607, 93);
            lkpPaymentCurrency.Name = "lkpPaymentCurrency";
            lkpPaymentCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpPaymentCurrency.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", Properties.Resources.Entity_Currency_Code),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExchangeRate", Properties.Resources.Entity_Currency_ExchangeRate)
            });
            lkpPaymentCurrency.Properties.DisplayMember = "CurrencyCode";
            lkpPaymentCurrency.Properties.NullText = "";
            lkpPaymentCurrency.Properties.ValueMember = "CurrencyCode";
            lkpPaymentCurrency.Size = new System.Drawing.Size(115, 20);
            lkpPaymentCurrency.StyleController = layoutControlPaymentSettings;
            lkpPaymentCurrency.TabIndex = 4;
            lkpPaymentCurrency.EditValueChanged += LkpPaymentCurrency_EditValueChanged;
            // 
            // calcPaymentExchangeRate
            // 
            calcPaymentExchangeRate.Location = new System.Drawing.Point(838, 93);
            calcPaymentExchangeRate.Name = "calcPaymentExchangeRate";
            calcPaymentExchangeRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcPaymentExchangeRate.Properties.DisplayFormat.FormatString = "n4";
            calcPaymentExchangeRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcPaymentExchangeRate.Properties.EditFormat.FormatString = "n4";
            calcPaymentExchangeRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcPaymentExchangeRate.Properties.Mask.EditMask = "n4";
            calcPaymentExchangeRate.Size = new System.Drawing.Size(106, 20);
            calcPaymentExchangeRate.StyleController = layoutControlPaymentSettings;
            calcPaymentExchangeRate.TabIndex = 5;
            // 
            // txtPaymentDesc
            // 
            txtPaymentDesc.Location = new System.Drawing.Point(145, 117);
            txtPaymentDesc.Name = "txtPaymentDesc";
            txtPaymentDesc.Size = new System.Drawing.Size(799, 20);
            txtPaymentDesc.StyleController = layoutControlPaymentSettings;
            txtPaymentDesc.TabIndex = 6;
            // 
            // rgPaymentRule
            // 
            rgPaymentRule.Location = new System.Drawing.Point(24, 157);
            rgPaymentRule.Name = "rgPaymentRule";
            rgPaymentRule.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                new DevExpress.XtraEditors.Controls.RadioGroupItem(0, Properties.Resources.Form_PayrollWizard_PaymentRule_Balance),
                new DevExpress.XtraEditors.Controls.RadioGroupItem(1, Properties.Resources.Form_PayrollWizard_PaymentRule_NetSalary),
                new DevExpress.XtraEditors.Controls.RadioGroupItem(2, Properties.Resources.Form_PayrollWizard_PaymentRule_Manual)
            });
            rgPaymentRule.SelectedIndex = 0;
            rgPaymentRule.Size = new System.Drawing.Size(920, 80);
            rgPaymentRule.StyleController = layoutControlPaymentSettings;
            rgPaymentRule.TabIndex = 7;
            // 
            // lblPaymentSettingsInfo
            // 
            lblPaymentSettingsInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            lblPaymentSettingsInfo.Appearance.Options.UseFont = true;
            lblPaymentSettingsInfo.Location = new System.Drawing.Point(24, 241);
            lblPaymentSettingsInfo.Name = "lblPaymentSettingsInfo";
            lblPaymentSettingsInfo.Size = new System.Drawing.Size(920, 13);
            lblPaymentSettingsInfo.StyleController = layoutControlPaymentSettings;
            lblPaymentSettingsInfo.TabIndex = 8;
            lblPaymentSettingsInfo.Text = Properties.Resources.Form_PayrollWizard_PaymentSettings_Info;
            // 
            // layoutControlGroupRoot
            // 
            layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupRoot.GroupBordersVisible = false;
            layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                layoutItemAutoPay,
                groupPaymentSettings,
                emptySpaceItemBottom
            });
            layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            layoutControlGroupRoot.Size = new System.Drawing.Size(968, 457);
            layoutControlGroupRoot.TextVisible = false;
            // 
            // layoutItemAutoPay
            // 
            layoutItemAutoPay.Control = chkAutoPayBalances;
            layoutItemAutoPay.Location = new System.Drawing.Point(0, 0);
            layoutItemAutoPay.Name = "layoutItemAutoPay";
            layoutItemAutoPay.Size = new System.Drawing.Size(948, 25);
            layoutItemAutoPay.TextSize = new System.Drawing.Size(0, 0);
            layoutItemAutoPay.TextVisible = false;
            // 
            // groupPaymentSettings
            // 
            groupPaymentSettings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                layoutItemCashRegister,
                layoutItemPaymentDate,
                layoutItemPaymentMethod,
                layoutItemPaymentCurrency,
                layoutItemPaymentExchangeRate,
                layoutItemPaymentDesc,
                layoutItemPaymentRule,
                layoutItemSettingsInfo
            });
            groupPaymentSettings.Location = new System.Drawing.Point(0, 25);
            groupPaymentSettings.Name = "groupPaymentSettings";
            groupPaymentSettings.Size = new System.Drawing.Size(948, 235);
            groupPaymentSettings.Text = Properties.Resources.Form_PayrollWizard_PaymentSettings_Group;
            // 
            // layoutItemCashRegister
            // 
            layoutItemCashRegister.Control = lkpCashRegister;
            layoutItemCashRegister.Location = new System.Drawing.Point(0, 0);
            layoutItemCashRegister.Name = "layoutItemCashRegister";
            layoutItemCashRegister.Size = new System.Drawing.Size(462, 24);
            layoutItemCashRegister.Text = Properties.Resources.Form_PayrollWizard_CashRegister + ":";
            layoutItemCashRegister.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentDate
            // 
            layoutItemPaymentDate.Control = dtPaymentDate;
            layoutItemPaymentDate.Location = new System.Drawing.Point(462, 0);
            layoutItemPaymentDate.Name = "layoutItemPaymentDate";
            layoutItemPaymentDate.Size = new System.Drawing.Size(462, 24);
            layoutItemPaymentDate.Text = Properties.Resources.Form_PayrollWizard_PaymentDate + ":";
            layoutItemPaymentDate.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentMethod
            // 
            layoutItemPaymentMethod.Control = lkpPaymentMethod;
            layoutItemPaymentMethod.Location = new System.Drawing.Point(0, 24);
            layoutItemPaymentMethod.Name = "layoutItemPaymentMethod";
            layoutItemPaymentMethod.Size = new System.Drawing.Size(462, 24);
            layoutItemPaymentMethod.Text = Properties.Resources.Form_PayrollWizard_PaymentMethod + ":";
            layoutItemPaymentMethod.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentCurrency
            // 
            layoutItemPaymentCurrency.Control = lkpPaymentCurrency;
            layoutItemPaymentCurrency.Location = new System.Drawing.Point(462, 24);
            layoutItemPaymentCurrency.Name = "layoutItemPaymentCurrency";
            layoutItemPaymentCurrency.Size = new System.Drawing.Size(231, 24);
            layoutItemPaymentCurrency.Text = Properties.Resources.Form_PayrollWizard_PaymentCurrency + ":";
            layoutItemPaymentCurrency.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentExchangeRate
            // 
            layoutItemPaymentExchangeRate.Control = calcPaymentExchangeRate;
            layoutItemPaymentExchangeRate.Location = new System.Drawing.Point(693, 24);
            layoutItemPaymentExchangeRate.Name = "layoutItemPaymentExchangeRate";
            layoutItemPaymentExchangeRate.Size = new System.Drawing.Size(231, 24);
            layoutItemPaymentExchangeRate.Text = Properties.Resources.Form_PayrollWizard_PaymentExchangeRate + ":";
            layoutItemPaymentExchangeRate.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentDesc
            // 
            layoutItemPaymentDesc.Control = txtPaymentDesc;
            layoutItemPaymentDesc.Location = new System.Drawing.Point(0, 48);
            layoutItemPaymentDesc.Name = "layoutItemPaymentDesc";
            layoutItemPaymentDesc.Size = new System.Drawing.Size(924, 24);
            layoutItemPaymentDesc.Text = Properties.Resources.Form_PayrollWizard_PaymentDesc + ":";
            layoutItemPaymentDesc.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemPaymentRule
            // 
            layoutItemPaymentRule.Control = rgPaymentRule;
            layoutItemPaymentRule.Location = new System.Drawing.Point(0, 72);
            layoutItemPaymentRule.Name = "layoutItemPaymentRule";
            layoutItemPaymentRule.Size = new System.Drawing.Size(924, 100);
            layoutItemPaymentRule.Text = Properties.Resources.Form_PayrollWizard_PaymentRule_Label;
            layoutItemPaymentRule.TextLocation = DevExpress.Utils.Locations.Top;
            layoutItemPaymentRule.TextSize = new System.Drawing.Size(109, 13);
            // 
            // layoutItemSettingsInfo
            // 
            layoutItemSettingsInfo.Control = lblPaymentSettingsInfo;
            layoutItemSettingsInfo.Location = new System.Drawing.Point(0, 172);
            layoutItemSettingsInfo.Name = "layoutItemSettingsInfo";
            layoutItemSettingsInfo.Size = new System.Drawing.Size(924, 17);
            layoutItemSettingsInfo.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSettingsInfo.TextVisible = false;
            // 
            // emptySpaceItemBottom
            // 
            emptySpaceItemBottom.AllowHotTrack = false;
            emptySpaceItemBottom.Location = new System.Drawing.Point(0, 260);
            emptySpaceItemBottom.Name = "emptySpaceItemBottom";
            emptySpaceItemBottom.Size = new System.Drawing.Size(948, 177);
            emptySpaceItemBottom.TextSize = new System.Drawing.Size(0, 0);
            // 
            // wizardPagePaymentList
            // 
            wizardPagePaymentList.Controls.Add(gridControlPayment);
            wizardPagePaymentList.Controls.Add(panelControlPaymentButtons);
            wizardPagePaymentList.DescriptionText = Properties.Resources.Form_PayrollWizard_PaymentListPageText;
            wizardPagePaymentList.Name = "wizardPagePaymentList";
            wizardPagePaymentList.Size = new System.Drawing.Size(968, 457);
            wizardPagePaymentList.Text = Properties.Resources.Form_PayrollWizard_PaymentListPageCaption;
            // 
            // gridControlPayment
            // 
            gridControlPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlPayment.Location = new System.Drawing.Point(0, 36);
            gridControlPayment.MainView = gridViewPayment;
            gridControlPayment.Name = "gridControlPayment";
            gridControlPayment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoCheckPaySelected, repoCalcPayAmount, repoLookUpPayCashRegister });
            gridControlPayment.Size = new System.Drawing.Size(968, 421);
            gridControlPayment.TabIndex = 1;
            gridControlPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewPayment });
            // 
            // gridViewPayment
            // 
            gridViewPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaySelected, colPayDocumentNumber, colPayCurrAccCode, colPayEmployeeName, colPayDepartmentName, colPayPositionName, colPayNetSalaryLoc, colPayBalanceAfterPayroll, colPayCurrencyCode, colPayExchangeRate, colPayAmount, colPayCashRegisterCode });
            gridViewPayment.GridControl = gridControlPayment;
            gridViewPayment.Name = "gridViewPayment";
            gridViewPayment.OptionsView.ColumnAutoWidth = false;
            gridViewPayment.OptionsView.ShowAutoFilterRow = true;
            gridViewPayment.OptionsView.ShowFooter = true;
            gridViewPayment.CustomDrawRowIndicator += GridViewPayment_CustomDrawRowIndicator;
            gridViewPayment.CellValueChanged += GridViewPayment_CellValueChanged;
            // 
            // colPayDocumentNumber
            // 
            colPayDocumentNumber.Caption = Properties.Resources.Entity_PaymentHeader_DocumentNumber;
            colPayDocumentNumber.FieldName = "PaymentDocumentNumber";
            colPayDocumentNumber.Name = "colPayDocumentNumber";
            colPayDocumentNumber.OptionsColumn.AllowEdit = false;
            colPayDocumentNumber.Visible = false;
            colPayDocumentNumber.VisibleIndex = 1;
            colPayDocumentNumber.Width = 110;
            // 
            // colPaySelected
            // 
            colPaySelected.Caption = Properties.Resources.Form_PayrollWizard_ColPaySelected;
            colPaySelected.ColumnEdit = repoCheckPaySelected;
            colPaySelected.FieldName = "PaySelected";
            colPaySelected.Name = "colPaySelected";
            colPaySelected.Visible = true;
            colPaySelected.VisibleIndex = 0;
            colPaySelected.Width = 55;
            // 
            // repoCheckPaySelected
            // 
            repoCheckPaySelected.AutoHeight = false;
            repoCheckPaySelected.Name = "repoCheckPaySelected";
            // 
            // colPayCurrAccCode
            // 
            colPayCurrAccCode.Caption = Properties.Resources.Entity_TrPayrollHeader_CurrAccCode;
            colPayCurrAccCode.FieldName = "CurrAccCode";
            colPayCurrAccCode.Name = "colPayCurrAccCode";
            colPayCurrAccCode.OptionsColumn.AllowEdit = false;
            colPayCurrAccCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CurrAccCode", "{0}") });
            colPayCurrAccCode.Visible = true;
            colPayCurrAccCode.VisibleIndex = 1;
            colPayCurrAccCode.Width = 90;
            // 
            // colPayEmployeeName
            // 
            colPayEmployeeName.Caption = Properties.Resources.Common_EmployeeName;
            colPayEmployeeName.FieldName = "EmployeeName";
            colPayEmployeeName.Name = "colPayEmployeeName";
            colPayEmployeeName.OptionsColumn.AllowEdit = false;
            colPayEmployeeName.Visible = true;
            colPayEmployeeName.VisibleIndex = 2;
            colPayEmployeeName.Width = 160;
            // 
            // colPayDepartmentName
            // 
            colPayDepartmentName.Caption = Properties.Resources.Entity_DcDepartment_DepartmentName;
            colPayDepartmentName.FieldName = "DepartmentName";
            colPayDepartmentName.Name = "colPayDepartmentName";
            colPayDepartmentName.OptionsColumn.AllowEdit = false;
            colPayDepartmentName.Visible = true;
            colPayDepartmentName.VisibleIndex = 3;
            colPayDepartmentName.Width = 120;
            // 
            // colPayPositionName
            // 
            colPayPositionName.Caption = Properties.Resources.Entity_DcPosition_PositionName;
            colPayPositionName.FieldName = "PositionName";
            colPayPositionName.Name = "colPayPositionName";
            colPayPositionName.OptionsColumn.AllowEdit = false;
            colPayPositionName.Visible = true;
            colPayPositionName.VisibleIndex = 4;
            colPayPositionName.Width = 120;
            // 
            // colPayNetSalaryLoc
            // 
            colPayNetSalaryLoc.Caption = Properties.Resources.Entity_TrPayrollHeader_NetSalary;
            colPayNetSalaryLoc.DisplayFormat.FormatString = "n2";
            colPayNetSalaryLoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPayNetSalaryLoc.FieldName = "NetSalaryLoc";
            colPayNetSalaryLoc.Name = "colPayNetSalaryLoc";
            colPayNetSalaryLoc.OptionsColumn.AllowEdit = false;
            colPayNetSalaryLoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSalaryLoc", "{0:n2}") });
            colPayNetSalaryLoc.Visible = true;
            colPayNetSalaryLoc.VisibleIndex = 5;
            colPayNetSalaryLoc.Width = 100;
            // 
            // colPayBalanceAfterPayroll
            // 
            colPayBalanceAfterPayroll.Caption = Properties.Resources.Form_PayrollWizard_ColBalanceAfterPayroll;
            colPayBalanceAfterPayroll.DisplayFormat.FormatString = "n2";
            colPayBalanceAfterPayroll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPayBalanceAfterPayroll.FieldName = "BalanceAfterPayroll";
            colPayBalanceAfterPayroll.Name = "colPayBalanceAfterPayroll";
            colPayBalanceAfterPayroll.OptionsColumn.AllowEdit = false;
            colPayBalanceAfterPayroll.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceAfterPayroll", "{0:n2}") });
            colPayBalanceAfterPayroll.Visible = true;
            colPayBalanceAfterPayroll.VisibleIndex = 6;
            colPayBalanceAfterPayroll.Width = 125;
            // 
            // colPayCurrencyCode
            // 
            colPayCurrencyCode.Caption = Properties.Resources.Entity_Currency_Code;
            colPayCurrencyCode.ColumnEdit = repoLookUpCurrency;
            colPayCurrencyCode.FieldName = "PaymentCurrencyCode";
            colPayCurrencyCode.Name = "colPayCurrencyCode";
            colPayCurrencyCode.Visible = true;
            colPayCurrencyCode.VisibleIndex = 7;
            colPayCurrencyCode.Width = 70;
            // 
            // colPayExchangeRate
            // 
            colPayExchangeRate.Caption = Properties.Resources.Entity_Currency_ExchangeRate;
            colPayExchangeRate.ColumnEdit = repoCalcExchangeRate;
            colPayExchangeRate.DisplayFormat.FormatString = "n4";
            colPayExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPayExchangeRate.FieldName = "PaymentExchangeRate";
            colPayExchangeRate.Name = "colPayExchangeRate";
            colPayExchangeRate.Visible = true;
            colPayExchangeRate.VisibleIndex = 8;
            colPayExchangeRate.Width = 75;
            // 
            // colPayAmount
            // 
            colPayAmount.Caption = Properties.Resources.Form_PayrollWizard_ColPayAmount;
            colPayAmount.ColumnEdit = repoCalcPayAmount;
            colPayAmount.DisplayFormat.FormatString = "n2";
            colPayAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPayAmount.FieldName = "PayAmount";
            colPayAmount.Name = "colPayAmount";
            colPayAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PayAmount", "{0:n2}") });
            colPayAmount.Visible = true;
            colPayAmount.VisibleIndex = 9;
            colPayAmount.Width = 115;
            // 
            // repoCalcPayAmount
            // 
            repoCalcPayAmount.AutoHeight = false;
            repoCalcPayAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcPayAmount.DisplayFormat.FormatString = "n2";
            repoCalcPayAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcPayAmount.EditFormat.FormatString = "n2";
            repoCalcPayAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoCalcPayAmount.Mask.EditMask = "n2";
            repoCalcPayAmount.Name = "repoCalcPayAmount";
            // 
            // colPayCashRegisterCode
            // 
            colPayCashRegisterCode.Caption = Properties.Resources.Form_PayrollWizard_CashRegister;
            colPayCashRegisterCode.ColumnEdit = repoLookUpPayCashRegister;
            colPayCashRegisterCode.FieldName = "CashRegisterCode";
            colPayCashRegisterCode.Name = "colPayCashRegisterCode";
            colPayCashRegisterCode.Visible = true;
            colPayCashRegisterCode.VisibleIndex = 10;
            colPayCashRegisterCode.Width = 150;
            // 
            // repoLookUpPayCashRegister
            // 
            repoLookUpPayCashRegister.AutoHeight = false;
            repoLookUpPayCashRegister.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLookUpPayCashRegister.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", Properties.Resources.Entity_CurrAcc_Code),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", Properties.Resources.Entity_CurrAcc_Desc)
            });
            repoLookUpPayCashRegister.DisplayMember = "CurrAccDesc";
            repoLookUpPayCashRegister.NullText = "";
            repoLookUpPayCashRegister.ValueMember = "CurrAccCode";
            repoLookUpPayCashRegister.Name = "repoLookUpPayCashRegister";
            // 
            // panelControlPaymentButtons
            // 
            panelControlPaymentButtons.Controls.Add(btnPaySelectAll);
            panelControlPaymentButtons.Controls.Add(btnPayUnselectAll);
            panelControlPaymentButtons.Controls.Add(btnApplyBalances);
            panelControlPaymentButtons.Controls.Add(btnApplyNetSalaries);
            panelControlPaymentButtons.Controls.Add(btnResetPayments);
            panelControlPaymentButtons.Controls.Add(btnPayExportExcel);
            panelControlPaymentButtons.Dock = System.Windows.Forms.DockStyle.Top;
            panelControlPaymentButtons.Location = new System.Drawing.Point(0, 0);
            panelControlPaymentButtons.Name = "panelControlPaymentButtons";
            panelControlPaymentButtons.Size = new System.Drawing.Size(968, 36);
            panelControlPaymentButtons.TabIndex = 0;
            // 
            // btnPaySelectAll
            // 
            btnPaySelectAll.Location = new System.Drawing.Point(5, 5);
            btnPaySelectAll.Name = "btnPaySelectAll";
            btnPaySelectAll.Size = new System.Drawing.Size(100, 25);
            btnPaySelectAll.TabIndex = 0;
            btnPaySelectAll.Text = Properties.Resources.Common_SelectAll;
            btnPaySelectAll.Click += BtnPaySelectAll_Click;
            // 
            // btnPayUnselectAll
            // 
            btnPayUnselectAll.Location = new System.Drawing.Point(110, 5);
            btnPayUnselectAll.Name = "btnPayUnselectAll";
            btnPayUnselectAll.Size = new System.Drawing.Size(100, 25);
            btnPayUnselectAll.TabIndex = 1;
            btnPayUnselectAll.Text = Properties.Resources.Common_UnselectAll;
            btnPayUnselectAll.Click += BtnPayUnselectAll_Click;
            // 
            // btnApplyBalances
            // 
            btnApplyBalances.Location = new System.Drawing.Point(215, 5);
            btnApplyBalances.Name = "btnApplyBalances";
            btnApplyBalances.Size = new System.Drawing.Size(160, 25);
            btnApplyBalances.TabIndex = 2;
            btnApplyBalances.Text = Properties.Resources.Form_PayrollWizard_BtnApplyBalances;
            btnApplyBalances.Click += BtnApplyBalances_Click;
            // 
            // btnApplyNetSalaries
            // 
            btnApplyNetSalaries.Location = new System.Drawing.Point(380, 5);
            btnApplyNetSalaries.Name = "btnApplyNetSalaries";
            btnApplyNetSalaries.Size = new System.Drawing.Size(150, 25);
            btnApplyNetSalaries.TabIndex = 3;
            btnApplyNetSalaries.Text = Properties.Resources.Form_PayrollWizard_BtnApplyNetSalaries;
            btnApplyNetSalaries.Click += BtnApplyNetSalaries_Click;
            // 
            // btnResetPayments
            // 
            btnResetPayments.Location = new System.Drawing.Point(535, 5);
            btnResetPayments.Name = "btnResetPayments";
            btnResetPayments.Size = new System.Drawing.Size(95, 25);
            btnResetPayments.TabIndex = 4;
            btnResetPayments.Text = Properties.Resources.Form_PayrollWizard_BtnResetPayments;
            btnResetPayments.Click += BtnResetPayments_Click;
            // 
            // btnPayExportExcel
            // 
            btnPayExportExcel.Location = new System.Drawing.Point(635, 5);
            btnPayExportExcel.Name = "btnPayExportExcel";
            btnPayExportExcel.Size = new System.Drawing.Size(120, 25);
            btnPayExportExcel.TabIndex = 5;
            btnPayExportExcel.Text = Properties.Resources.Common_ExportToExcel;
            btnPayExportExcel.Click += BtnPayExportExcel_Click;
            // 
            // completionWizardPage1
            // 
            completionWizardPage1.Controls.Add(lblCompletionInfo);
            completionWizardPage1.Controls.Add(lblSummary);
            completionWizardPage1.Controls.Add(chkExportPaymentsOnFinish);
            completionWizardPage1.Controls.Add(chkSendWhatsappOnFinish);
            completionWizardPage1.Controls.Add(btnExportPaymentsCompletion);
            completionWizardPage1.Controls.Add(btnSendWhatsappCompletion);
            completionWizardPage1.FinishText = Properties.Resources.Form_PayrollWizard_CompletionText;
            completionWizardPage1.Name = "completionWizardPage1";
            completionWizardPage1.ProceedText = "";
            completionWizardPage1.Size = new System.Drawing.Size(768, 468);
            completionWizardPage1.Text = "Salary Calculation Completed";
            // 
            // lblCompletionInfo
            // 
            lblCompletionInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblCompletionInfo.Appearance.Options.UseFont = true;
            lblCompletionInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblCompletionInfo.Location = new System.Drawing.Point(30, 40);
            lblCompletionInfo.Name = "lblCompletionInfo";
            lblCompletionInfo.Size = new System.Drawing.Size(550, 17);
            lblCompletionInfo.TabIndex = 0;
            lblCompletionInfo.Text = "Payroll calculation is ready. Click Finish to save payrolls.";
            // 
            // lblSummary
            // 
            lblSummary.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblSummary.Appearance.Options.UseFont = true;
            lblSummary.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblSummary.Location = new System.Drawing.Point(30, 75);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new System.Drawing.Size(550, 0);
            lblSummary.TabIndex = 1;
            // 
            // chkExportPaymentsOnFinish
            // 
            chkExportPaymentsOnFinish.Location = new System.Drawing.Point(30, 230);
            chkExportPaymentsOnFinish.Name = "chkExportPaymentsOnFinish";
            chkExportPaymentsOnFinish.Properties.Caption = Properties.Resources.Form_PayrollWizard_ExportPaymentsOnFinish;
            chkExportPaymentsOnFinish.Size = new System.Drawing.Size(450, 20);
            chkExportPaymentsOnFinish.TabIndex = 2;
            // 
            // chkSendWhatsappOnFinish
            // 
            chkSendWhatsappOnFinish.Location = new System.Drawing.Point(30, 260);
            chkSendWhatsappOnFinish.Name = "chkSendWhatsappOnFinish";
            chkSendWhatsappOnFinish.Properties.Caption = Properties.Resources.Form_PayrollWizard_SendWhatsappOnFinish;
            chkSendWhatsappOnFinish.Size = new System.Drawing.Size(450, 20);
            chkSendWhatsappOnFinish.TabIndex = 3;
            // 
            // btnExportPaymentsCompletion
            // 
            btnExportPaymentsCompletion.Location = new System.Drawing.Point(30, 295);
            btnExportPaymentsCompletion.Name = "btnExportPaymentsCompletion";
            btnExportPaymentsCompletion.Size = new System.Drawing.Size(180, 30);
            btnExportPaymentsCompletion.TabIndex = 4;
            btnExportPaymentsCompletion.Text = Properties.Resources.Form_PayrollWizard_Button_ExportPayments;
            btnExportPaymentsCompletion.Click += BtnExportPaymentsCompletion_Click;
            // 
            // btnSendWhatsappCompletion
            // 
            btnSendWhatsappCompletion.Location = new System.Drawing.Point(220, 295);
            btnSendWhatsappCompletion.Name = "btnSendWhatsappCompletion";
            btnSendWhatsappCompletion.Size = new System.Drawing.Size(180, 30);
            btnSendWhatsappCompletion.TabIndex = 5;
            btnSendWhatsappCompletion.Text = Properties.Resources.Form_PayrollWizard_Button_SendWhatsapp;
            btnSendWhatsappCompletion.Click += BtnSendWhatsappCompletion_Click;
            // 
            // FormPayrollWizard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 600);
            Controls.Add(wizardControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPayrollWizard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Payroll Calculation Wizard";
            ((System.ComponentModel.ISupportInitialize)wizardControl1).EndInit();
            wizardControl1.ResumeLayout(false);
            welcomeWizardPage1.ResumeLayout(false);
            welcomeWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lkpPeriod.Properties).EndInit();
            wizardPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcBaseSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcDeduction).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLookUpCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcExchangeRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).EndInit();
            panelControlTop.ResumeLayout(false);
            wizardPagePaymentSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlPaymentSettings).EndInit();
            layoutControlPaymentSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupRoot).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupPaymentSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemAutoPay).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemCashRegister).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentMethod).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentExchangeRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemPaymentRule).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemSettingsInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkAutoPayBalances.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkpCashRegister.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkpPaymentMethod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkpPaymentCurrency.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcPaymentExchangeRate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentDesc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentRule.Properties).EndInit();
            wizardPagePaymentList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckPaySelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcPayAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLookUpPayCashRegister).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlPaymentButtons).EndInit();
            panelControlPaymentButtons.ResumeLayout(false);
            completionWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkExportPaymentsOnFinish.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSendWhatsappOnFinish.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPageEmployees;
        private DevExpress.XtraWizard.WizardPage wizardPagePaymentSettings;
        private DevExpress.XtraWizard.WizardPage wizardPagePaymentList;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl lblWelcomeInfo;
        private DevExpress.XtraEditors.LabelControl lblSelectPeriod;
        private DevExpress.XtraEditors.LookUpEdit lkpPeriod;
        private DevExpress.XtraEditors.PanelControl panelControlTop;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSendWhatsapp;
        private MyGridControl gridControlEmployees;
        private MyGridView gridViewEmployees;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseSalary;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcBaseSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colBonus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colDeduction;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcDeduction;
        private DevExpress.XtraGrid.Columns.GridColumn colGrossSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colNetSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colNetSalaryLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviousBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAfterPayroll;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraLayout.LayoutControl layoutControlPaymentSettings;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraLayout.LayoutControlGroup groupPaymentSettings;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAutoPay;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemCashRegister;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentMethod;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentCurrency;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentExchangeRate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemPaymentRule;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSettingsInfo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBottom;
        private DevExpress.XtraEditors.CheckEdit chkAutoPayBalances;
        private DevExpress.XtraEditors.LookUpEdit lkpCashRegister;
        private DevExpress.XtraEditors.DateEdit dtPaymentDate;
        private DevExpress.XtraEditors.LookUpEdit lkpPaymentMethod;
        private DevExpress.XtraEditors.LookUpEdit lkpPaymentCurrency;
        private DevExpress.XtraEditors.CalcEdit calcPaymentExchangeRate;
        private DevExpress.XtraEditors.TextEdit txtPaymentDesc;
        private DevExpress.XtraEditors.RadioGroup rgPaymentRule;
        private DevExpress.XtraEditors.LabelControl lblPaymentSettingsInfo;
        private DevExpress.XtraEditors.PanelControl panelControlPaymentButtons;
        private DevExpress.XtraEditors.SimpleButton btnPaySelectAll;
        private DevExpress.XtraEditors.SimpleButton btnPayUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnApplyBalances;
        private DevExpress.XtraEditors.SimpleButton btnApplyNetSalaries;
        private DevExpress.XtraEditors.SimpleButton btnResetPayments;
        private DevExpress.XtraEditors.SimpleButton btnPayExportExcel;
        private MyGridControl gridControlPayment;
        private MyGridView gridViewPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colPaySelected;
        private DevExpress.XtraGrid.Columns.GridColumn colPayDocumentNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckPaySelected;
        private DevExpress.XtraGrid.Columns.GridColumn colPayCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPayEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPayDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colPayPositionName;
        private DevExpress.XtraGrid.Columns.GridColumn colPayNetSalaryLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colPayBalanceAfterPayroll;
        private DevExpress.XtraGrid.Columns.GridColumn colPayAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcPayAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPayCashRegisterCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpPayCashRegister;
        private DevExpress.XtraGrid.Columns.GridColumn colPayCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPayExchangeRate;
        private DevExpress.XtraEditors.LabelControl lblCompletionInfo;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.CheckEdit chkExportPaymentsOnFinish;
        private DevExpress.XtraEditors.CheckEdit chkSendWhatsappOnFinish;
        private DevExpress.XtraEditors.SimpleButton btnExportPaymentsCompletion;
        private DevExpress.XtraEditors.SimpleButton btnSendWhatsappCompletion;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}
