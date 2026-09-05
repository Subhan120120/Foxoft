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
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            panelControlTop = new DevExpress.XtraEditors.PanelControl();
            btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            lblCompletionInfo = new DevExpress.XtraEditors.LabelControl();
            lblSummary = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)panelControlTop).BeginInit();
            panelControlTop.SuspendLayout();
            completionWizardPage1.SuspendLayout();
            SuspendLayout();
            // 
            // wizardControl1
            // 
            wizardControl1.Controls.Add(welcomeWizardPage1);
            wizardControl1.Controls.Add(wizardPageEmployees);
            wizardControl1.Controls.Add(completionWizardPage1);
            wizardControl1.Dock = DockStyle.Fill;
            wizardControl1.ImageOptions.ImageWidth = 200;
            wizardControl1.Name = "wizardControl1";
            wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { welcomeWizardPage1, wizardPageEmployees, completionWizardPage1 });
            wizardControl1.Size = new Size(950, 560);
            wizardControl1.Text = "Payroll Calculation Wizard";
            wizardControl1.CancelClick += WizardControl1_CancelClick;
            wizardControl1.FinishClick += WizardControl1_FinishClick;
            wizardControl1.NextClick += WizardControl1_NextClick;
            // 
            // welcomeWizardPage1
            // 
            welcomeWizardPage1.Controls.Add(lblWelcomeInfo);
            welcomeWizardPage1.Controls.Add(lblSelectPeriod);
            welcomeWizardPage1.Controls.Add(lkpPeriod);
            welcomeWizardPage1.IntroductionText = Properties.Resources.Form_PayrollWizard_WelcomeText;
            welcomeWizardPage1.Name = "welcomeWizardPage1";
            welcomeWizardPage1.Size = new Size(718, 428);
            welcomeWizardPage1.Text = "Welcome to Payroll Calculation Wizard";
            // 
            // lblWelcomeInfo
            // 
            lblWelcomeInfo.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblWelcomeInfo.Appearance.Options.UseFont = true;
            lblWelcomeInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblWelcomeInfo.Location = new Point(30, 40);
            lblWelcomeInfo.Name = "lblWelcomeInfo";
            lblWelcomeInfo.Size = new Size(500, 34);
            lblWelcomeInfo.TabIndex = 0;
            lblWelcomeInfo.Text = "This wizard allows you to automatically calculate salaries for employees based on active contracts.";
            // 
            // lblSelectPeriod
            // 
            lblSelectPeriod.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectPeriod.Appearance.Options.UseFont = true;
            lblSelectPeriod.Location = new Point(30, 100);
            lblSelectPeriod.Name = "lblSelectPeriod";
            lblSelectPeriod.Size = new Size(114, 15);
            lblSelectPeriod.TabIndex = 1;
            lblSelectPeriod.Text = "Select Payroll Period";
            // 
            // lkpPeriod
            // 
            lkpPeriod.Location = new Point(30, 125);
            lkpPeriod.Name = "lkpPeriod";
            lkpPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodName", Properties.Resources.Entity_TrPayrollHeader_PeriodId) });
            lkpPeriod.Properties.DisplayMember = "PeriodName";
            lkpPeriod.Properties.NullText = Properties.Resources.Form_PayrollWizard_SelectPeriod;
            lkpPeriod.Properties.ValueMember = "Id";
            lkpPeriod.Size = new Size(260, 20);
            lkpPeriod.TabIndex = 2;
            lkpPeriod.EditValueChanged += LkpPeriod_EditValueChanged;
            // 
            // wizardPageEmployees
            // 
            wizardPageEmployees.Controls.Add(gridControlEmployees);
            wizardPageEmployees.Controls.Add(panelControlTop);
            wizardPageEmployees.DescriptionText = Properties.Resources.Form_PayrollWizard_EmployeesText;
            wizardPageEmployees.Name = "wizardPageEmployees";
            wizardPageEmployees.Size = new Size(918, 417);
            wizardPageEmployees.Text = "Employee Salaries";
            // 
            // gridControlEmployees
            // 
            gridControlEmployees.Dock = DockStyle.Fill;
            gridControlEmployees.Location = new Point(0, 36);
            gridControlEmployees.MainView = gridViewEmployees;
            gridControlEmployees.Name = "gridControlEmployees";
            gridControlEmployees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoCheckSelected, repoCalcBaseSalary, repoCalcBonus, repoCalcDeduction });
            gridControlEmployees.Size = new Size(918, 381);
            gridControlEmployees.TabIndex = 1;
            gridControlEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewEmployees });
            // 
            // gridViewEmployees
            // 
            gridViewEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSelected, colCurrAccCode, colEmployeeName, colPositionName, colDepartmentName, colBaseSalary, colBonus, colDeduction, colGrossSalary, colNetSalary, colStatus });
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
            colPositionName.Width = 110;
            // 
            // colDepartmentName
            // 
            colDepartmentName.Caption = Properties.Resources.Entity_DcDepartment_DepartmentName;
            colDepartmentName.FieldName = "DepartmentName";
            colDepartmentName.Name = "colDepartmentName";
            colDepartmentName.OptionsColumn.AllowEdit = false;
            colDepartmentName.Visible = true;
            colDepartmentName.VisibleIndex = 4;
            colDepartmentName.Width = 110;
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
            // colStatus
            // 
            colStatus.Caption = Properties.Resources.Common_Status;
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 10;
            colStatus.Width = 90;
            // 
            // panelControlTop
            // 
            panelControlTop.Controls.Add(btnSelectAll);
            panelControlTop.Controls.Add(btnUnselectAll);
            panelControlTop.Dock = DockStyle.Top;
            panelControlTop.Location = new Point(0, 0);
            panelControlTop.Name = "panelControlTop";
            panelControlTop.Size = new Size(918, 36);
            panelControlTop.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(5, 5);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(95, 25);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "Select All";
            btnSelectAll.Click += BtnSelectAll_Click;
            // 
            // btnUnselectAll
            // 
            btnUnselectAll.Location = new Point(106, 5);
            btnUnselectAll.Name = "btnUnselectAll";
            btnUnselectAll.Size = new Size(95, 25);
            btnUnselectAll.TabIndex = 1;
            btnUnselectAll.Text = "Unselect All";
            btnUnselectAll.Click += BtnUnselectAll_Click;
            // 
            // completionWizardPage1
            // 
            completionWizardPage1.Controls.Add(lblCompletionInfo);
            completionWizardPage1.Controls.Add(lblSummary);
            completionWizardPage1.FinishText = Properties.Resources.Form_PayrollWizard_CompletionText;
            completionWizardPage1.Name = "completionWizardPage1";
            completionWizardPage1.ProceedText = "";
            completionWizardPage1.Size = new Size(718, 428);
            completionWizardPage1.Text = "Salary Calculation Completed";
            // 
            // lblCompletionInfo
            // 
            lblCompletionInfo.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblCompletionInfo.Appearance.Options.UseFont = true;
            lblCompletionInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblCompletionInfo.Location = new Point(30, 40);
            lblCompletionInfo.Name = "lblCompletionInfo";
            lblCompletionInfo.Size = new Size(500, 17);
            lblCompletionInfo.TabIndex = 0;
            lblCompletionInfo.Text = "Payroll calculation is ready. Click Finish to save payrolls.";
            // 
            // lblSummary
            // 
            lblSummary.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSummary.Appearance.Options.UseFont = true;
            lblSummary.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblSummary.Location = new Point(30, 95);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(500, 0);
            lblSummary.TabIndex = 1;
            // 
            // FormPayrollWizard
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 560);
            Controls.Add(wizardControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPayrollWizard";
            StartPosition = FormStartPosition.CenterParent;
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
            ((System.ComponentModel.ISupportInitialize)panelControlTop).EndInit();
            panelControlTop.ResumeLayout(false);
            completionWizardPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPageEmployees;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl lblWelcomeInfo;
        private DevExpress.XtraEditors.LabelControl lblSelectPeriod;
        private DevExpress.XtraEditors.LookUpEdit lkpPeriod;
        private DevExpress.XtraEditors.PanelControl panelControlTop;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
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
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.LabelControl lblCompletionInfo;
        private DevExpress.XtraEditors.LabelControl lblSummary;
    }
}