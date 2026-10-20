namespace Foxoft
{
    partial class FormGoogleContactWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGoogleContactWizard));
            wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            lblWelcomeInfo = new DevExpress.XtraEditors.LabelControl();
            groupControlConnection = new DevExpress.XtraEditors.GroupControl();
            lblConnectionStatus = new DevExpress.XtraEditors.LabelControl();
            btnCheckConnection = new DevExpress.XtraEditors.SimpleButton();
            btnResetToken = new DevExpress.XtraEditors.SimpleButton();
            groupControlFilter = new DevExpress.XtraEditors.GroupControl();
            chkFilterCustomer = new DevExpress.XtraEditors.CheckEdit();
            chkFilterSupplier = new DevExpress.XtraEditors.CheckEdit();
            chkFilterPersonnel = new DevExpress.XtraEditors.CheckEdit();
            chkFilterOthers = new DevExpress.XtraEditors.CheckEdit();
            chkOnlyWithPhone = new DevExpress.XtraEditors.CheckEdit();
            wizardPageAccounts = new DevExpress.XtraWizard.WizardPage();
            gridControlAccounts = new MyGridControl();
            gridViewAccounts = new MyGridView();
            colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            colGoogleContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            colExistsInGoogle = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckExistsInGoogle = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            panelControlTop = new DevExpress.XtraEditors.PanelControl();
            btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            btnSelectNewOnly = new DevExpress.XtraEditors.SimpleButton();
            lblAccountsSummary = new DevExpress.XtraEditors.LabelControl();
            wizardPageOptions = new DevExpress.XtraWizard.WizardPage();
            groupControlNameFormat = new DevExpress.XtraEditors.GroupControl();
            rgNameFormat = new DevExpress.XtraEditors.RadioGroup();
            groupControlPrefix = new DevExpress.XtraEditors.GroupControl();
            chkAddPrefix = new DevExpress.XtraEditors.CheckEdit();
            txtPrefix = new DevExpress.XtraEditors.TextEdit();
            groupControlAdditional = new DevExpress.XtraEditors.GroupControl();
            chkIncludeNote = new DevExpress.XtraEditors.CheckEdit();
            chkSetOrganization = new DevExpress.XtraEditors.CheckEdit();
            chkSkipDuplicates = new DevExpress.XtraEditors.CheckEdit();
            completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            lblSummary = new DevExpress.XtraEditors.LabelControl();
            btnStartExport = new DevExpress.XtraEditors.SimpleButton();
            progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            lblProgressStatus = new DevExpress.XtraEditors.LabelControl();
            memoLog = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)wizardControl1).BeginInit();
            wizardControl1.SuspendLayout();
            welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlConnection).BeginInit();
            groupControlConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlFilter).BeginInit();
            groupControlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkFilterCustomer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterSupplier.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterPersonnel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterOthers.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkOnlyWithPhone.Properties).BeginInit();
            wizardPageAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckExistsInGoogle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).BeginInit();
            panelControlTop.SuspendLayout();
            wizardPageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlNameFormat).BeginInit();
            groupControlNameFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rgNameFormat.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPrefix).BeginInit();
            groupControlPrefix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkAddPrefix.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrefix.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlAdditional).BeginInit();
            groupControlAdditional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkIncludeNote.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSetOrganization.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSkipDuplicates.Properties).BeginInit();
            completionWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoLog.Properties).BeginInit();
            SuspendLayout();
            // 
            // wizardControl1
            // 
            wizardControl1.Controls.Add(welcomeWizardPage1);
            wizardControl1.Controls.Add(wizardPageAccounts);
            wizardControl1.Controls.Add(wizardPageOptions);
            wizardControl1.Controls.Add(completionWizardPage1);
            wizardControl1.Dock = DockStyle.Fill;
            wizardControl1.ImageOptions.ImageWidth = 200;
            wizardControl1.Name = "wizardControl1";
            wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { welcomeWizardPage1, wizardPageAccounts, wizardPageOptions, completionWizardPage1 });
            wizardControl1.Size = new Size(880, 560);
            wizardControl1.Text = "Google Contacts Export Wizard";
            wizardControl1.CancelClick += WizardControl1_CancelClick;
            wizardControl1.FinishClick += WizardControl1_FinishClick;
            wizardControl1.NextClick += WizardControl1_NextClick;
            // 
            // welcomeWizardPage1
            // 
            welcomeWizardPage1.Controls.Add(lblWelcomeInfo);
            welcomeWizardPage1.Controls.Add(groupControlConnection);
            welcomeWizardPage1.Controls.Add(groupControlFilter);
            welcomeWizardPage1.IntroductionText = Properties.Resources.Form_GoogleContactWizard_WelcomeSubtitle;
            welcomeWizardPage1.Name = "welcomeWizardPage1";
            welcomeWizardPage1.Size = new Size(648, 428);
            welcomeWizardPage1.Text = "Export Contacts to Google Contacts";
            // 
            // lblWelcomeInfo
            // 
            lblWelcomeInfo.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblWelcomeInfo.Appearance.Options.UseFont = true;
            lblWelcomeInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblWelcomeInfo.Location = new Point(20, 15);
            lblWelcomeInfo.Name = "lblWelcomeInfo";
            lblWelcomeInfo.Size = new Size(620, 68);
            lblWelcomeInfo.TabIndex = 0;
            lblWelcomeInfo.Text = resources.GetString("lblWelcomeInfo.Text");
            // 
            // groupControlConnection
            // 
            groupControlConnection.Controls.Add(lblConnectionStatus);
            groupControlConnection.Controls.Add(btnCheckConnection);
            groupControlConnection.Controls.Add(btnResetToken);
            groupControlConnection.Location = new Point(20, 80);
            groupControlConnection.Name = "groupControlConnection";
            groupControlConnection.Size = new Size(620, 100);
            groupControlConnection.TabIndex = 1;
            groupControlConnection.Text = "Google Account Connection";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConnectionStatus.Appearance.Options.UseFont = true;
            lblConnectionStatus.Location = new Point(15, 35);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(173, 15);
            lblConnectionStatus.TabIndex = 0;
            lblConnectionStatus.Text = "Connection status: Not verified";
            // 
            // btnCheckConnection
            // 
            btnCheckConnection.Location = new Point(15, 60);
            btnCheckConnection.Name = "btnCheckConnection";
            btnCheckConnection.Size = new Size(220, 28);
            btnCheckConnection.TabIndex = 1;
            btnCheckConnection.Text = "Check / Connect Google Account";
            btnCheckConnection.Click += BtnCheckConnection_Click;
            // 
            // btnResetToken
            // 
            btnResetToken.Location = new Point(245, 60);
            btnResetToken.Name = "btnResetToken";
            btnResetToken.Size = new Size(130, 28);
            btnResetToken.TabIndex = 2;
            btnResetToken.Text = "Switch Account";
            btnResetToken.Click += BtnResetToken_Click;
            // 
            // groupControlFilter
            // 
            groupControlFilter.Controls.Add(chkFilterCustomer);
            groupControlFilter.Controls.Add(chkFilterSupplier);
            groupControlFilter.Controls.Add(chkFilterPersonnel);
            groupControlFilter.Controls.Add(chkFilterOthers);
            groupControlFilter.Controls.Add(chkOnlyWithPhone);
            groupControlFilter.Location = new Point(20, 195);
            groupControlFilter.Name = "groupControlFilter";
            groupControlFilter.Size = new Size(620, 150);
            groupControlFilter.TabIndex = 2;
            groupControlFilter.Text = "Account Filter";
            // 
            // chkFilterCustomer
            // 
            chkFilterCustomer.EditValue = true;
            chkFilterCustomer.Location = new Point(15, 35);
            chkFilterCustomer.Name = "chkFilterCustomer";
            chkFilterCustomer.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_FilterCustomers;
            chkFilterCustomer.Size = new Size(150, 20);
            chkFilterCustomer.TabIndex = 0;
            // 
            // chkFilterSupplier
            // 
            chkFilterSupplier.EditValue = true;
            chkFilterSupplier.Location = new Point(180, 35);
            chkFilterSupplier.Name = "chkFilterSupplier";
            chkFilterSupplier.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_FilterSuppliers;
            chkFilterSupplier.Size = new Size(150, 20);
            chkFilterSupplier.TabIndex = 1;
            // 
            // chkFilterPersonnel
            // 
            chkFilterPersonnel.EditValue = true;
            chkFilterPersonnel.Location = new Point(345, 35);
            chkFilterPersonnel.Name = "chkFilterPersonnel";
            chkFilterPersonnel.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_FilterPersonnel;
            chkFilterPersonnel.Size = new Size(180, 20);
            chkFilterPersonnel.TabIndex = 2;
            // 
            // chkFilterOthers
            // 
            chkFilterOthers.Location = new Point(15, 70);
            chkFilterOthers.Name = "chkFilterOthers";
            chkFilterOthers.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_FilterOthers;
            chkFilterOthers.Size = new Size(250, 20);
            chkFilterOthers.TabIndex = 3;
            // 
            // chkOnlyWithPhone
            // 
            chkOnlyWithPhone.EditValue = true;
            chkOnlyWithPhone.Location = new Point(15, 105);
            chkOnlyWithPhone.Name = "chkOnlyWithPhone";
            chkOnlyWithPhone.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkOnlyWithPhone.Properties.Appearance.Options.UseFont = true;
            chkOnlyWithPhone.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_OnlyWithPhone;
            chkOnlyWithPhone.Size = new Size(350, 20);
            chkOnlyWithPhone.TabIndex = 4;
            // 
            // wizardPageAccounts
            // 
            wizardPageAccounts.Controls.Add(gridControlAccounts);
            wizardPageAccounts.Controls.Add(panelControlTop);
            wizardPageAccounts.DescriptionText = Properties.Resources.Form_GoogleContactWizard_StepAccountsSubtitle;
            wizardPageAccounts.Name = "wizardPageAccounts";
            wizardPageAccounts.Size = new Size(848, 417);
            wizardPageAccounts.Text = "Select Accounts";
            // 
            // gridControlAccounts
            // 
            gridControlAccounts.Dock = DockStyle.Fill;
            gridControlAccounts.Location = new Point(0, 40);
            gridControlAccounts.MainView = gridViewAccounts;
            gridControlAccounts.Name = "gridControlAccounts";
            gridControlAccounts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoCheckSelected, repoCheckExistsInGoogle });
            gridControlAccounts.Size = new Size(848, 377);
            gridControlAccounts.TabIndex = 1;
            gridControlAccounts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAccounts });
            // 
            // gridViewAccounts
            // 
            gridViewAccounts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSelected, colCurrAccCode, colCurrAccDesc, colFirstName, colLastName, colPhoneNum, colAddress, colGoogleContactName, colExistsInGoogle });
            gridViewAccounts.GridControl = gridControlAccounts;
            gridViewAccounts.Name = "gridViewAccounts";
            gridViewAccounts.OptionsView.ShowAutoFilterRow = true;
            gridViewAccounts.OptionsView.ShowGroupPanel = false;
            gridViewAccounts.RowStyle += GridViewAccounts_RowStyle;
            gridViewAccounts.CellValueChanging += GridViewAccounts_CellValueChanging;
            // 
            // colSelected
            // 
            colSelected.Caption = " ";
            colSelected.ColumnEdit = repoCheckSelected;
            colSelected.FieldName = "Selected";
            colSelected.Name = "colSelected";
            colSelected.Visible = true;
            colSelected.VisibleIndex = 0;
            colSelected.Width = 40;
            // 
            // repoCheckSelected
            // 
            repoCheckSelected.AutoHeight = false;
            repoCheckSelected.Name = "repoCheckSelected";
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = "Current Account Code";
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.OptionsColumn.AllowEdit = false;
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 1;
            colCurrAccCode.Width = 90;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.Caption = "Current Account Name";
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.OptionsColumn.AllowEdit = false;
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 2;
            colCurrAccDesc.Width = 180;
            // 
            // colFirstName
            // 
            colFirstName.Caption = "First Name";
            colFirstName.FieldName = "FirstName";
            colFirstName.Name = "colFirstName";
            colFirstName.OptionsColumn.AllowEdit = false;
            colFirstName.Visible = true;
            colFirstName.VisibleIndex = 3;
            colFirstName.Width = 90;
            // 
            // colLastName
            // 
            colLastName.Caption = "Last Name";
            colLastName.FieldName = "LastName";
            colLastName.Name = "colLastName";
            colLastName.OptionsColumn.AllowEdit = false;
            colLastName.Visible = true;
            colLastName.VisibleIndex = 4;
            colLastName.Width = 90;
            // 
            // colPhoneNum
            // 
            colPhoneNum.Caption = "Phone";
            colPhoneNum.FieldName = "PhoneNum";
            colPhoneNum.Name = "colPhoneNum";
            colPhoneNum.OptionsColumn.AllowEdit = false;
            colPhoneNum.Visible = true;
            colPhoneNum.VisibleIndex = 5;
            colPhoneNum.Width = 120;
            // 
            // colAddress
            // 
            colAddress.Caption = "Address";
            colAddress.FieldName = "Address";
            colAddress.Name = "colAddress";
            colAddress.OptionsColumn.AllowEdit = false;
            colAddress.Visible = true;
            colAddress.VisibleIndex = 6;
            colAddress.Width = 140;
            // 
            // colGoogleContactName
            // 
            colGoogleContactName.Caption = "Google Contact Name";
            colGoogleContactName.FieldName = "GoogleContactName";
            colGoogleContactName.Name = "colGoogleContactName";
            colGoogleContactName.OptionsColumn.AllowEdit = false;
            colGoogleContactName.Width = 150;
            // 
            // colExistsInGoogle
            // 
            colExistsInGoogle.Caption = "Exists in Google";
            colExistsInGoogle.ColumnEdit = repoCheckExistsInGoogle;
            colExistsInGoogle.FieldName = "ExistsInGoogle";
            colExistsInGoogle.Name = "colExistsInGoogle";
            colExistsInGoogle.OptionsColumn.AllowEdit = false;
            colExistsInGoogle.OptionsColumn.ReadOnly = true;
            colExistsInGoogle.Visible = true;
            colExistsInGoogle.VisibleIndex = 7;
            colExistsInGoogle.Width = 130;
            // 
            // repoCheckExistsInGoogle
            // 
            repoCheckExistsInGoogle.AutoHeight = false;
            repoCheckExistsInGoogle.Name = "repoCheckExistsInGoogle";
            // 
            // panelControlTop
            // 
            panelControlTop.Controls.Add(btnSelectAll);
            panelControlTop.Controls.Add(btnUnselectAll);
            panelControlTop.Controls.Add(btnSelectNewOnly);
            panelControlTop.Controls.Add(lblAccountsSummary);
            panelControlTop.Dock = DockStyle.Top;
            panelControlTop.Location = new Point(0, 0);
            panelControlTop.Name = "panelControlTop";
            panelControlTop.Size = new Size(848, 40);
            panelControlTop.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(10, 6);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(95, 26);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "Select All";
            btnSelectAll.Click += BtnSelectAll_Click;
            // 
            // btnUnselectAll
            // 
            btnUnselectAll.Location = new Point(110, 6);
            btnUnselectAll.Name = "btnUnselectAll";
            btnUnselectAll.Size = new Size(105, 26);
            btnUnselectAll.TabIndex = 1;
            btnUnselectAll.Text = "Unselect All";
            btnUnselectAll.Click += BtnUnselectAll_Click;
            // 
            // btnSelectNewOnly
            // 
            btnSelectNewOnly.Location = new Point(220, 6);
            btnSelectNewOnly.Name = "btnSelectNewOnly";
            btnSelectNewOnly.Size = new Size(140, 26);
            btnSelectNewOnly.TabIndex = 2;
            btnSelectNewOnly.Text = "Select Only New";
            btnSelectNewOnly.Click += BtnSelectNewOnly_Click;
            // 
            // lblAccountsSummary
            // 
            lblAccountsSummary.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAccountsSummary.Appearance.Options.UseFont = true;
            lblAccountsSummary.Location = new Point(370, 12);
            lblAccountsSummary.Name = "lblAccountsSummary";
            lblAccountsSummary.Size = new Size(0, 15);
            lblAccountsSummary.TabIndex = 3;
            // 
            // wizardPageOptions
            // 
            wizardPageOptions.Controls.Add(groupControlNameFormat);
            wizardPageOptions.Controls.Add(groupControlPrefix);
            wizardPageOptions.Controls.Add(groupControlAdditional);
            wizardPageOptions.DescriptionText = Properties.Resources.Form_GoogleContactWizard_StepOptionsSubtitle;
            wizardPageOptions.Name = "wizardPageOptions";
            wizardPageOptions.Size = new Size(848, 417);
            wizardPageOptions.Text = "Export Options";
            // 
            // groupControlNameFormat
            // 
            groupControlNameFormat.Controls.Add(rgNameFormat);
            groupControlNameFormat.Location = new Point(20, 20);
            groupControlNameFormat.Name = "groupControlNameFormat";
            groupControlNameFormat.Size = new Size(620, 100);
            groupControlNameFormat.TabIndex = 0;
            groupControlNameFormat.Text = "Contact Name Format";
            // 
            // rgNameFormat
            // 
            rgNameFormat.Dock = DockStyle.Fill;
            rgNameFormat.EditValue = 0;
            rgNameFormat.Location = new Point(2, 23);
            rgNameFormat.Name = "rgNameFormat";
            rgNameFormat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, Properties.Resources.Form_GoogleContactWizard_NameFormatDesc), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, Properties.Resources.Form_GoogleContactWizard_NameFormatFirstLast) });
            rgNameFormat.Size = new Size(616, 75);
            rgNameFormat.TabIndex = 0;
            // 
            // groupControlPrefix
            // 
            groupControlPrefix.Controls.Add(chkAddPrefix);
            groupControlPrefix.Controls.Add(txtPrefix);
            groupControlPrefix.Location = new Point(20, 135);
            groupControlPrefix.Name = "groupControlPrefix";
            groupControlPrefix.Size = new Size(620, 85);
            groupControlPrefix.TabIndex = 1;
            groupControlPrefix.Text = "Name Prefix";
            // 
            // chkAddPrefix
            // 
            chkAddPrefix.Location = new Point(15, 35);
            chkAddPrefix.Name = "chkAddPrefix";
            chkAddPrefix.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_AddPrefix;
            chkAddPrefix.Size = new Size(220, 20);
            chkAddPrefix.TabIndex = 0;
            chkAddPrefix.CheckedChanged += ChkAddPrefix_CheckedChanged;
            // 
            // txtPrefix
            // 
            txtPrefix.EditValue = "[Foxoft] ";
            txtPrefix.Enabled = false;
            txtPrefix.Location = new Point(250, 35);
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new Size(180, 20);
            txtPrefix.TabIndex = 1;
            // 
            // groupControlAdditional
            // 
            groupControlAdditional.Controls.Add(chkIncludeNote);
            groupControlAdditional.Controls.Add(chkSetOrganization);
            groupControlAdditional.Controls.Add(chkSkipDuplicates);
            groupControlAdditional.Location = new Point(20, 235);
            groupControlAdditional.Name = "groupControlAdditional";
            groupControlAdditional.Size = new Size(620, 140);
            groupControlAdditional.TabIndex = 2;
            groupControlAdditional.Text = "Additional Details";
            // 
            // chkIncludeNote
            // 
            chkIncludeNote.EditValue = true;
            chkIncludeNote.Location = new Point(15, 35);
            chkIncludeNote.Name = "chkIncludeNote";
            chkIncludeNote.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_IncludeNote;
            chkIncludeNote.Size = new Size(550, 20);
            chkIncludeNote.TabIndex = 0;
            // 
            // chkSetOrganization
            // 
            chkSetOrganization.EditValue = true;
            chkSetOrganization.Location = new Point(15, 68);
            chkSetOrganization.Name = "chkSetOrganization";
            chkSetOrganization.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_SetOrganization;
            chkSetOrganization.Size = new Size(550, 20);
            chkSetOrganization.TabIndex = 1;
            // 
            // chkSkipDuplicates
            // 
            chkSkipDuplicates.EditValue = true;
            chkSkipDuplicates.Location = new Point(15, 101);
            chkSkipDuplicates.Name = "chkSkipDuplicates";
            chkSkipDuplicates.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkSkipDuplicates.Properties.Appearance.Options.UseFont = true;
            chkSkipDuplicates.Properties.Caption = Properties.Resources.Form_GoogleContactWizard_SkipDuplicates;
            chkSkipDuplicates.Size = new Size(550, 20);
            chkSkipDuplicates.TabIndex = 2;
            // 
            // completionWizardPage1
            // 
            completionWizardPage1.Controls.Add(lblSummary);
            completionWizardPage1.Controls.Add(btnStartExport);
            completionWizardPage1.Controls.Add(progressBar);
            completionWizardPage1.Controls.Add(lblProgressStatus);
            completionWizardPage1.Controls.Add(memoLog);
            completionWizardPage1.FinishText = Properties.Resources.Form_GoogleContactWizard_CompletionText;
            completionWizardPage1.Name = "completionWizardPage1";
            completionWizardPage1.Size = new Size(648, 428);
            completionWizardPage1.Text = "Export Contacts";
            // 
            // lblSummary
            // 
            lblSummary.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSummary.Appearance.Options.UseFont = true;
            lblSummary.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblSummary.Location = new Point(20, 15);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(620, 0);
            lblSummary.TabIndex = 0;
            // 
            // btnStartExport
            // 
            btnStartExport.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStartExport.Appearance.Options.UseFont = true;
            btnStartExport.Location = new Point(20, 60);
            btnStartExport.Name = "btnStartExport";
            btnStartExport.Size = new Size(180, 32);
            btnStartExport.TabIndex = 1;
            btnStartExport.Text = "Start Export";
            btnStartExport.Click += BtnStartExport_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 102);
            progressBar.Name = "progressBar";
            progressBar.Properties.ShowTitle = true;
            progressBar.Size = new Size(620, 22);
            progressBar.TabIndex = 2;
            // 
            // lblProgressStatus
            // 
            lblProgressStatus.Location = new Point(20, 130);
            lblProgressStatus.Name = "lblProgressStatus";
            lblProgressStatus.Size = new Size(0, 13);
            lblProgressStatus.TabIndex = 3;
            // 
            // memoLog
            // 
            memoLog.Location = new Point(20, 155);
            memoLog.Name = "memoLog";
            memoLog.Properties.ReadOnly = true;
            memoLog.Size = new Size(620, 220);
            memoLog.TabIndex = 4;
            // 
            // FormGoogleContactWizard
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 560);
            Controls.Add(wizardControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGoogleContactWizard";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Google Contacts Export Wizard";
            FormClosing += FormGoogleContactWizard_FormClosing;
            Load += FormGoogleContactWizard_Load;
            ((System.ComponentModel.ISupportInitialize)wizardControl1).EndInit();
            wizardControl1.ResumeLayout(false);
            welcomeWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlConnection).EndInit();
            groupControlConnection.ResumeLayout(false);
            groupControlConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlFilter).EndInit();
            groupControlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkFilterCustomer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterSupplier.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterPersonnel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkFilterOthers.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkOnlyWithPhone.Properties).EndInit();
            wizardPageAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckExistsInGoogle).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).EndInit();
            panelControlTop.ResumeLayout(false);
            panelControlTop.PerformLayout();
            wizardPageOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlNameFormat).EndInit();
            groupControlNameFormat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rgNameFormat.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPrefix).EndInit();
            groupControlPrefix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkAddPrefix.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrefix.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlAdditional).EndInit();
            groupControlAdditional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkIncludeNote.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSetOrganization.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSkipDuplicates.Properties).EndInit();
            completionWizardPage1.ResumeLayout(false);
            completionWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoLog.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPageAccounts;
        private DevExpress.XtraWizard.WizardPage wizardPageOptions;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl lblWelcomeInfo;
        private DevExpress.XtraEditors.GroupControl groupControlConnection;
        private DevExpress.XtraEditors.LabelControl lblConnectionStatus;
        private DevExpress.XtraEditors.SimpleButton btnCheckConnection;
        private DevExpress.XtraEditors.SimpleButton btnResetToken;
        private DevExpress.XtraEditors.GroupControl groupControlFilter;
        private DevExpress.XtraEditors.CheckEdit chkFilterCustomer;
        private DevExpress.XtraEditors.CheckEdit chkFilterSupplier;
        private DevExpress.XtraEditors.CheckEdit chkFilterPersonnel;
        private DevExpress.XtraEditors.CheckEdit chkFilterOthers;
        private DevExpress.XtraEditors.CheckEdit chkOnlyWithPhone;
        private DevExpress.XtraEditors.PanelControl panelControlTop;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectNewOnly;
        private DevExpress.XtraEditors.LabelControl lblAccountsSummary;
        private MyGridControl gridControlAccounts;
        private MyGridView gridViewAccounts;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colGoogleContactName;
        private DevExpress.XtraGrid.Columns.GridColumn colExistsInGoogle;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckExistsInGoogle;
        private DevExpress.XtraEditors.GroupControl groupControlNameFormat;
        private DevExpress.XtraEditors.RadioGroup rgNameFormat;
        private DevExpress.XtraEditors.GroupControl groupControlPrefix;
        private DevExpress.XtraEditors.CheckEdit chkAddPrefix;
        private DevExpress.XtraEditors.TextEdit txtPrefix;
        private DevExpress.XtraEditors.GroupControl groupControlAdditional;
        private DevExpress.XtraEditors.CheckEdit chkIncludeNote;
        private DevExpress.XtraEditors.CheckEdit chkSetOrganization;
        private DevExpress.XtraEditors.CheckEdit chkSkipDuplicates;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.SimpleButton btnStartExport;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraEditors.LabelControl lblProgressStatus;
        private DevExpress.XtraEditors.MemoEdit memoLog;
    }
}
