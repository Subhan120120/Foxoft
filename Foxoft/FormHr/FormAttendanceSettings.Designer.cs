namespace Foxoft
{
    partial class FormAttendanceSettings
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkAttendanceEnabled = new DevExpress.XtraEditors.CheckEdit();
            this.lkpDefaultSchedule = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbAttendanceMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spDebounceMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.chkRequireApproval = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowManualEntry = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowAttendanceCorrection = new DevExpress.XtraEditors.CheckEdit();
            this.chkAutoCalculate = new DevExpress.XtraEditors.CheckEdit();
            this.chkAutoCloseDay = new DevExpress.XtraEditors.CheckEdit();
            this.chkAutoFloatingRestDay = new DevExpress.XtraEditors.CheckEdit();
            this.spMaxWeeklyRestDays = new DevExpress.XtraEditors.SpinEdit();
            this.lblFloatingRestHelp = new DevExpress.XtraEditors.LabelControl();
            this.spGracePeriod = new DevExpress.XtraEditors.SpinEdit();
            this.cmbLateCalculationMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbLateRoundingMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkAllowLateCorrection = new DevExpress.XtraEditors.CheckEdit();
            this.chkLateApprovalRequired = new DevExpress.XtraEditors.CheckEdit();
            this.spEarlyExitGracePeriod = new DevExpress.XtraEditors.SpinEdit();
            this.lblLateHelp = new DevExpress.XtraEditors.LabelControl();
            this.cmbOvertimePolicy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spMinOvertimeMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.spOvertimeRoundingMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.lblOvertimeHelp = new DevExpress.XtraEditors.LabelControl();
            this.chkNotifyHrOnLate = new DevExpress.XtraEditors.CheckEdit();
            this.chkNotifyManagerOnAbsence = new DevExpress.XtraEditors.CheckEdit();
            this.chkNotifyOnMissingCheckOut = new DevExpress.XtraEditors.CheckEdit();
            this.lblNotifyHelp = new DevExpress.XtraEditors.LabelControl();
            this.chkRequireDynamicQrCode = new DevExpress.XtraEditors.CheckEdit();
            this.chkRequireGpsGeofencing = new DevExpress.XtraEditors.CheckEdit();
            this.chkRequireDeviceLock = new DevExpress.XtraEditors.CheckEdit();
            this.lblWebSecurityHelp = new DevExpress.XtraEditors.LabelControl();
            this.lkpRuleStore = new DevExpress.XtraEditors.LookUpEdit();
            this.spRuleLat = new DevExpress.XtraEditors.SpinEdit();
            this.spRuleLon = new DevExpress.XtraEditors.SpinEdit();
            this.spRuleRadius = new DevExpress.XtraEditors.SpinEdit();
            this.txtRuleIps = new DevExpress.XtraEditors.TextEdit();
            this.chkStoreEnforceWifi = new DevExpress.XtraEditors.CheckEdit();
            this.btnSaveStoreRule = new DevExpress.XtraEditors.SimpleButton();
            this.gcDeviceLocks = new DevExpress.XtraGrid.GridControl();
            this.gvDeviceLocks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisteredAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUsedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlockAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnUnlock = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnRefreshDevices = new DevExpress.XtraEditors.SimpleButton();
            this.lblDeviceLockHelp = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();

            this.tabGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupGeneralMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemEnabled = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDefaultSchedule = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAttendanceMethod = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDebounce = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRequireApproval = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAllowManual = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAllowCorrection = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAutoCalculate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAutoCloseDay = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupFloatingRest = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemAutoFloatingRestDay = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemMaxWeeklyRestDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemFloatingRestHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemGeneral = new DevExpress.XtraLayout.EmptySpaceItem();

            this.tabLate = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupLateCalc = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemGrace = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemLateCalc = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemLateRound = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemAllowLateCorrection = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemLateApproval = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupEarlyExit = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemEarlyExitGrace = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupLateHelp = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemLateHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemLate = new DevExpress.XtraLayout.EmptySpaceItem();

            this.tabOvertime = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupOvertimeSettings = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemOTPolicy = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemMinOT = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemOTRounding = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupOvertimeHelp = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemOTHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemOvertime = new DevExpress.XtraLayout.EmptySpaceItem();

            this.tabNotifications = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupNotificationTriggers = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemNotifyLate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemNotifyAbsence = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemNotifyMissing = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupNotificationHelp = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemNotifyHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemNotifications = new DevExpress.XtraLayout.EmptySpaceItem();

            this.tabWebSecurity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupWebSecurityChecks = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemRequireDynamicQrCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRequireGpsGeofencing = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRequireDeviceLock = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupStoreSecurityRules = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemRuleStore = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRuleLat = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRuleLon = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRuleRadius = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRuleIps = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemStoreEnforceWifi = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemSaveStoreRule = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemSaveStore = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupWebSecurityHelp = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemWebSecurityHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemWebSecurity = new DevExpress.XtraLayout.EmptySpaceItem();

            this.tabDeviceLocks = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupDeviceLocksGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemDeviceLockHelp = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRefreshDevices = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDeviceLocksGrid = new DevExpress.XtraLayout.LayoutControlItem();

            this.emptySpaceItemBottom = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAttendanceEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDefaultSchedule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAttendanceMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDebounceMinutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireApproval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowManualEntry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAttendanceCorrection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalculate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCloseDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoFloatingRestDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaxWeeklyRestDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGracePeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLateCalculationMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLateRoundingMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowLateCorrection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLateApprovalRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEarlyExitGracePeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOvertimePolicy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinOvertimeMinutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spOvertimeRoundingMinutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyHrOnLate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyManagerOnAbsence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyOnMissingCheckOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireDynamicQrCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireGpsGeofencing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireDeviceLock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRuleStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleLat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleLon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleRadius.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleIps.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreEnforceWifi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceLocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeviceLocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnUnlock)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGeneralMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDefaultSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAttendanceMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDebounce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoCalculate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoCloseDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFloatingRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoFloatingRestDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMaxWeeklyRestDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemFloatingRestHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemGeneral)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabLate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGrace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowLateCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupEarlyExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEarlyExitGrace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLate)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertimeSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTPolicy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMinOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTRounding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertimeHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemOvertime)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupNotificationTriggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyLate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyMissing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupNotificationHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemNotifications)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabWebSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupWebSecurityChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireDynamicQrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireGpsGeofencing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireDeviceLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupStoreSecurityRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleIps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStoreEnforceWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSaveStoreRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemSaveStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupWebSecurityHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemWebSecurityHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemWebSecurity)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabDeviceLocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDeviceLocksGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDeviceLockHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRefreshDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDeviceLocksGrid)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).BeginInit();
            this.SuspendLayout();

            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkAttendanceEnabled);
            this.layoutControl1.Controls.Add(this.lkpDefaultSchedule);
            this.layoutControl1.Controls.Add(this.cmbAttendanceMethod);
            this.layoutControl1.Controls.Add(this.spDebounceMinutes);
            this.layoutControl1.Controls.Add(this.chkRequireApproval);
            this.layoutControl1.Controls.Add(this.chkAllowManualEntry);
            this.layoutControl1.Controls.Add(this.chkAllowAttendanceCorrection);
            this.layoutControl1.Controls.Add(this.chkAutoCalculate);
            this.layoutControl1.Controls.Add(this.chkAutoCloseDay);
            this.layoutControl1.Controls.Add(this.chkAutoFloatingRestDay);
            this.layoutControl1.Controls.Add(this.spMaxWeeklyRestDays);
            this.layoutControl1.Controls.Add(this.lblFloatingRestHelp);
            this.layoutControl1.Controls.Add(this.spGracePeriod);
            this.layoutControl1.Controls.Add(this.cmbLateCalculationMethod);
            this.layoutControl1.Controls.Add(this.cmbLateRoundingMethod);
            this.layoutControl1.Controls.Add(this.chkAllowLateCorrection);
            this.layoutControl1.Controls.Add(this.chkLateApprovalRequired);
            this.layoutControl1.Controls.Add(this.spEarlyExitGracePeriod);
            this.layoutControl1.Controls.Add(this.lblLateHelp);
            this.layoutControl1.Controls.Add(this.cmbOvertimePolicy);
            this.layoutControl1.Controls.Add(this.spMinOvertimeMinutes);
            this.layoutControl1.Controls.Add(this.spOvertimeRoundingMinutes);
            this.layoutControl1.Controls.Add(this.lblOvertimeHelp);
            this.layoutControl1.Controls.Add(this.chkNotifyHrOnLate);
            this.layoutControl1.Controls.Add(this.chkNotifyManagerOnAbsence);
            this.layoutControl1.Controls.Add(this.chkNotifyOnMissingCheckOut);
            this.layoutControl1.Controls.Add(this.lblNotifyHelp);
            this.layoutControl1.Controls.Add(this.chkRequireDynamicQrCode);
            this.layoutControl1.Controls.Add(this.chkRequireGpsGeofencing);
            this.layoutControl1.Controls.Add(this.chkRequireDeviceLock);
            this.layoutControl1.Controls.Add(this.lblWebSecurityHelp);
            this.layoutControl1.Controls.Add(this.lkpRuleStore);
            this.layoutControl1.Controls.Add(this.spRuleLat);
            this.layoutControl1.Controls.Add(this.spRuleLon);
            this.layoutControl1.Controls.Add(this.spRuleRadius);
            this.layoutControl1.Controls.Add(this.txtRuleIps);
            this.layoutControl1.Controls.Add(this.chkStoreEnforceWifi);
            this.layoutControl1.Controls.Add(this.btnSaveStoreRule);
            this.layoutControl1.Controls.Add(this.gcDeviceLocks);
            this.layoutControl1.Controls.Add(this.btnRefreshDevices);
            this.layoutControl1.Controls.Add(this.lblDeviceLockHelp);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroupRoot;
            this.layoutControl1.Size = new System.Drawing.Size(860, 640);
            this.layoutControl1.TabIndex = 0;

            // 
            // chkAttendanceEnabled
            // 
            this.chkAttendanceEnabled.Name = "chkAttendanceEnabled";
            this.chkAttendanceEnabled.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkAttendanceEnabled.Properties.Appearance.Options.UseFont = true;
            this.chkAttendanceEnabled.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AttendanceEnabled;

            // 
            // lkpDefaultSchedule
            // 
            this.lkpDefaultSchedule.Name = "lkpDefaultSchedule";
            this.lkpDefaultSchedule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.lkpDefaultSchedule.Properties.NullText = "";

            // 
            // cmbAttendanceMethod
            // 
            this.cmbAttendanceMethod.Name = "cmbAttendanceMethod";
            this.cmbAttendanceMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbAttendanceMethod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // 
            // spDebounceMinutes
            // 
            this.spDebounceMinutes.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spDebounceMinutes.Name = "spDebounceMinutes";
            this.spDebounceMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spDebounceMinutes.Properties.IsFloatValue = false;
            this.spDebounceMinutes.Properties.MaskSettings.Set("mask", "N0");
            this.spDebounceMinutes.Properties.MaxValue = new decimal(new int[] { 60, 0, 0, 0 });

            // 
            // chkRequireApproval
            // 
            this.chkRequireApproval.Name = "chkRequireApproval";
            this.chkRequireApproval.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_RequireApproval;

            // 
            // chkAllowManualEntry
            // 
            this.chkAllowManualEntry.Name = "chkAllowManualEntry";
            this.chkAllowManualEntry.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AllowManualEntry;

            // 
            // chkAllowAttendanceCorrection
            // 
            this.chkAllowAttendanceCorrection.Name = "chkAllowAttendanceCorrection";
            this.chkAllowAttendanceCorrection.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AllowAttendanceCorrection;

            // 
            // chkAutoCalculate
            // 
            this.chkAutoCalculate.Name = "chkAutoCalculate";
            this.chkAutoCalculate.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AutoCalculate;

            // 
            // chkAutoCloseDay
            // 
            this.chkAutoCloseDay.Name = "chkAutoCloseDay";
            this.chkAutoCloseDay.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AutoCloseDay;

            // 
            // chkAutoFloatingRestDay
            // 
            this.chkAutoFloatingRestDay.Name = "chkAutoFloatingRestDay";
            this.chkAutoFloatingRestDay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkAutoFloatingRestDay.Properties.Appearance.Options.UseFont = true;
            this.chkAutoFloatingRestDay.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AutoFloatingRestDay;

            // 
            // spMaxWeeklyRestDays
            // 
            this.spMaxWeeklyRestDays.EditValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spMaxWeeklyRestDays.Name = "spMaxWeeklyRestDays";
            this.spMaxWeeklyRestDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spMaxWeeklyRestDays.Properties.IsFloatValue = false;
            this.spMaxWeeklyRestDays.Properties.MaskSettings.Set("mask", "N0");
            this.spMaxWeeklyRestDays.Properties.MaxValue = new decimal(new int[] { 7, 0, 0, 0 });
            this.spMaxWeeklyRestDays.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // lblFloatingRestHelp
            // 
            this.lblFloatingRestHelp.AllowHtmlString = true;
            this.lblFloatingRestHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblFloatingRestHelp.Appearance.Options.UseForeColor = true;
            this.lblFloatingRestHelp.Appearance.Options.UseTextOptions = true;
            this.lblFloatingRestHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblFloatingRestHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblFloatingRestHelp.Name = "lblFloatingRestHelp";
            this.lblFloatingRestHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_FloatingRestHelp;

            // 
            // spGracePeriod
            // 
            this.spGracePeriod.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spGracePeriod.Name = "spGracePeriod";
            this.spGracePeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spGracePeriod.Properties.IsFloatValue = false;
            this.spGracePeriod.Properties.MaskSettings.Set("mask", "N0");
            this.spGracePeriod.Properties.MaxValue = new decimal(new int[] { 120, 0, 0, 0 });

            // 
            // cmbLateCalculationMethod
            // 
            this.cmbLateCalculationMethod.Name = "cmbLateCalculationMethod";
            this.cmbLateCalculationMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbLateCalculationMethod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // 
            // cmbLateRoundingMethod
            // 
            this.cmbLateRoundingMethod.Name = "cmbLateRoundingMethod";
            this.cmbLateRoundingMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbLateRoundingMethod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // 
            // chkAllowLateCorrection
            // 
            this.chkAllowLateCorrection.Name = "chkAllowLateCorrection";
            this.chkAllowLateCorrection.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_AllowLateCorrection;

            // 
            // chkLateApprovalRequired
            // 
            this.chkLateApprovalRequired.Name = "chkLateApprovalRequired";
            this.chkLateApprovalRequired.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_LateApprovalRequired;

            // 
            // spEarlyExitGracePeriod
            // 
            this.spEarlyExitGracePeriod.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spEarlyExitGracePeriod.Name = "spEarlyExitGracePeriod";
            this.spEarlyExitGracePeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spEarlyExitGracePeriod.Properties.IsFloatValue = false;
            this.spEarlyExitGracePeriod.Properties.MaskSettings.Set("mask", "N0");
            this.spEarlyExitGracePeriod.Properties.MaxValue = new decimal(new int[] { 120, 0, 0, 0 });

            // 
            // lblLateHelp
            // 
            this.lblLateHelp.AllowHtmlString = true;
            this.lblLateHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblLateHelp.Appearance.Options.UseForeColor = true;
            this.lblLateHelp.Appearance.Options.UseTextOptions = true;
            this.lblLateHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLateHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLateHelp.Name = "lblLateHelp";
            this.lblLateHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_LateHelp;

            // 
            // cmbOvertimePolicy
            // 
            this.cmbOvertimePolicy.Name = "cmbOvertimePolicy";
            this.cmbOvertimePolicy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbOvertimePolicy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // 
            // spMinOvertimeMinutes
            // 
            this.spMinOvertimeMinutes.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spMinOvertimeMinutes.Name = "spMinOvertimeMinutes";
            this.spMinOvertimeMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spMinOvertimeMinutes.Properties.IsFloatValue = false;
            this.spMinOvertimeMinutes.Properties.MaskSettings.Set("mask", "N0");
            this.spMinOvertimeMinutes.Properties.MaxValue = new decimal(new int[] { 240, 0, 0, 0 });

            // 
            // spOvertimeRoundingMinutes
            // 
            this.spOvertimeRoundingMinutes.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spOvertimeRoundingMinutes.Name = "spOvertimeRoundingMinutes";
            this.spOvertimeRoundingMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spOvertimeRoundingMinutes.Properties.IsFloatValue = false;
            this.spOvertimeRoundingMinutes.Properties.MaskSettings.Set("mask", "N0");
            this.spOvertimeRoundingMinutes.Properties.MaxValue = new decimal(new int[] { 60, 0, 0, 0 });

            // 
            // lblOvertimeHelp
            // 
            this.lblOvertimeHelp.AllowHtmlString = true;
            this.lblOvertimeHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblOvertimeHelp.Appearance.Options.UseForeColor = true;
            this.lblOvertimeHelp.Appearance.Options.UseTextOptions = true;
            this.lblOvertimeHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblOvertimeHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblOvertimeHelp.Name = "lblOvertimeHelp";
            this.lblOvertimeHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_OvertimeHelp;

            // 
            // chkNotifyHrOnLate
            // 
            this.chkNotifyHrOnLate.Name = "chkNotifyHrOnLate";
            this.chkNotifyHrOnLate.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_NotifyHrOnLate;

            // 
            // chkNotifyManagerOnAbsence
            // 
            this.chkNotifyManagerOnAbsence.Name = "chkNotifyManagerOnAbsence";
            this.chkNotifyManagerOnAbsence.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_NotifyManagerOnAbsence;

            // 
            // chkNotifyOnMissingCheckOut
            // 
            this.chkNotifyOnMissingCheckOut.Name = "chkNotifyOnMissingCheckOut";
            this.chkNotifyOnMissingCheckOut.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_NotifyOnMissingCheckOut;

            // 
            // lblNotifyHelp
            // 
            this.lblNotifyHelp.AllowHtmlString = true;
            this.lblNotifyHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblNotifyHelp.Appearance.Options.UseForeColor = true;
            this.lblNotifyHelp.Appearance.Options.UseTextOptions = true;
            this.lblNotifyHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblNotifyHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblNotifyHelp.Name = "lblNotifyHelp";
            this.lblNotifyHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_NotificationHelp;

            // 
            // chkRequireDynamicQrCode
            // 
            this.chkRequireDynamicQrCode.Name = "chkRequireDynamicQrCode";
            this.chkRequireDynamicQrCode.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_RequireDynamicQrCode;

            // 
            // chkRequireGpsGeofencing
            // 
            this.chkRequireGpsGeofencing.Name = "chkRequireGpsGeofencing";
            this.chkRequireGpsGeofencing.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_RequireGpsGeofencing;

            // 
            // chkRequireDeviceLock
            // 
            this.chkRequireDeviceLock.Name = "chkRequireDeviceLock";
            this.chkRequireDeviceLock.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_RequireDeviceLock;

            // 
            // lblWebSecurityHelp
            // 
            this.lblWebSecurityHelp.AllowHtmlString = true;
            this.lblWebSecurityHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblWebSecurityHelp.Appearance.Options.UseForeColor = true;
            this.lblWebSecurityHelp.Appearance.Options.UseTextOptions = true;
            this.lblWebSecurityHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblWebSecurityHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblWebSecurityHelp.Name = "lblWebSecurityHelp";
            this.lblWebSecurityHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_WebSecurityHelp;

            // 
            // lkpRuleStore
            // 
            this.lkpRuleStore.Name = "lkpRuleStore";
            this.lkpRuleStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.lkpRuleStore.Properties.NullText = "";

            // 
            // spRuleLat
            // 
            this.spRuleLat.EditValue = new decimal(new int[] { 404093, 0, 0, 262144 });
            this.spRuleLat.Name = "spRuleLat";
            this.spRuleLat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spRuleLat.Properties.DisplayFormat.FormatString = "F6";
            this.spRuleLat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spRuleLat.Properties.EditFormat.FormatString = "F6";
            this.spRuleLat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spRuleLat.Properties.MaskSettings.Set("mask", "n6");
            this.spRuleLat.Properties.MaxValue = new decimal(new int[] { 90, 0, 0, 0 });
            this.spRuleLat.Properties.MinValue = new decimal(new int[] { 90, 0, 0, -2147483648 });

            // 
            // spRuleLon
            // 
            this.spRuleLon.EditValue = new decimal(new int[] { 498671, 0, 0, 262144 });
            this.spRuleLon.Name = "spRuleLon";
            this.spRuleLon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spRuleLon.Properties.DisplayFormat.FormatString = "F6";
            this.spRuleLon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spRuleLon.Properties.EditFormat.FormatString = "F6";
            this.spRuleLon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spRuleLon.Properties.MaskSettings.Set("mask", "n6");
            this.spRuleLon.Properties.MaxValue = new decimal(new int[] { 180, 0, 0, 0 });
            this.spRuleLon.Properties.MinValue = new decimal(new int[] { 180, 0, 0, -2147483648 });

            // 
            // spRuleRadius
            // 
            this.spRuleRadius.EditValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spRuleRadius.Name = "spRuleRadius";
            this.spRuleRadius.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.spRuleRadius.Properties.IsFloatValue = false;
            this.spRuleRadius.Properties.MaskSettings.Set("mask", "N0");
            this.spRuleRadius.Properties.MaxValue = new decimal(new int[] { 50000, 0, 0, 0 });
            this.spRuleRadius.Properties.MinValue = new decimal(new int[] { 5, 0, 0, 0 });

            // 
            // txtRuleIps
            // 
            this.txtRuleIps.Name = "txtRuleIps";

            // 
            // chkStoreEnforceWifi
            // 
            this.chkStoreEnforceWifi.Name = "chkStoreEnforceWifi";
            this.chkStoreEnforceWifi.Properties.Caption = Foxoft.Properties.Resources.Form_AttendanceSettings_RequireWifiIp;

            // 
            // btnSaveStoreRule
            // 
            this.btnSaveStoreRule.Name = "btnSaveStoreRule";
            this.btnSaveStoreRule.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_SaveStoreRule;

            // 
            // gcDeviceLocks
            // 
            this.gcDeviceLocks.MainView = this.gvDeviceLocks;
            this.gcDeviceLocks.Name = "gcDeviceLocks";
            this.gcDeviceLocks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repoBtnUnlock
            });
            this.gcDeviceLocks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gvDeviceLocks
            });

            // 
            // gvDeviceLocks
            // 
            this.gvDeviceLocks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCurrAccCode,
                this.colEmployeeName,
                this.colDeviceName,
                this.colDeviceId,
                this.colRegisteredAt,
                this.colLastUsedAt,
                this.colUnlockAction
            });
            this.gvDeviceLocks.GridControl = this.gcDeviceLocks;
            this.gvDeviceLocks.Name = "gvDeviceLocks";
            this.gvDeviceLocks.OptionsView.ShowGroupPanel = false;
            this.gvDeviceLocks.OptionsView.ShowIndicator = false;

            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.Caption = "İşçi Kodu";
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.OptionsColumn.AllowEdit = false;
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 0;
            this.colCurrAccCode.Width = 90;

            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "İşçi Adı";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 150;

            // 
            // colDeviceName
            // 
            this.colDeviceName.Caption = "Cihaz Modeli";
            this.colDeviceName.FieldName = "DeviceName";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.OptionsColumn.AllowEdit = false;
            this.colDeviceName.Visible = true;
            this.colDeviceName.VisibleIndex = 2;
            this.colDeviceName.Width = 120;

            // 
            // colDeviceId
            // 
            this.colDeviceId.Caption = "Cihaz Tokeni";
            this.colDeviceId.FieldName = "DeviceId";
            this.colDeviceId.Name = "colDeviceId";
            this.colDeviceId.OptionsColumn.AllowEdit = false;
            this.colDeviceId.Visible = true;
            this.colDeviceId.VisibleIndex = 3;
            this.colDeviceId.Width = 160;

            // 
            // colRegisteredAt
            // 
            this.colRegisteredAt.Caption = "Qeydiyyat Tarixi";
            this.colRegisteredAt.DisplayFormat.FormatString = "g";
            this.colRegisteredAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRegisteredAt.FieldName = "RegisteredAt";
            this.colRegisteredAt.Name = "colRegisteredAt";
            this.colRegisteredAt.OptionsColumn.AllowEdit = false;
            this.colRegisteredAt.Visible = true;
            this.colRegisteredAt.VisibleIndex = 4;
            this.colRegisteredAt.Width = 110;

            // 
            // colLastUsedAt
            // 
            this.colLastUsedAt.Caption = "Son İstifadə";
            this.colLastUsedAt.DisplayFormat.FormatString = "g";
            this.colLastUsedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUsedAt.FieldName = "LastUsedAt";
            this.colLastUsedAt.Name = "colLastUsedAt";
            this.colLastUsedAt.OptionsColumn.AllowEdit = false;
            this.colLastUsedAt.Visible = true;
            this.colLastUsedAt.VisibleIndex = 5;
            this.colLastUsedAt.Width = 110;

            // 
            // colUnlockAction
            // 
            this.colUnlockAction.Caption = "Əməliyyat";
            this.colUnlockAction.ColumnEdit = this.repoBtnUnlock;
            this.colUnlockAction.Name = "colUnlockAction";
            this.colUnlockAction.Visible = true;
            this.colUnlockAction.VisibleIndex = 6;
            this.colUnlockAction.Width = 80;

            // 
            // repoBtnUnlock
            // 
            this.repoBtnUnlock.AutoHeight = false;
            this.repoBtnUnlock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            });
            this.repoBtnUnlock.Name = "repoBtnUnlock";
            this.repoBtnUnlock.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_RefreshDevices;

            // 
            // lblDeviceLockHelp
            // 
            this.lblDeviceLockHelp.AllowHtmlString = true;
            this.lblDeviceLockHelp.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblDeviceLockHelp.Appearance.Options.UseForeColor = true;
            this.lblDeviceLockHelp.Appearance.Options.UseTextOptions = true;
            this.lblDeviceLockHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDeviceLockHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblDeviceLockHelp.Name = "lblDeviceLockHelp";
            this.lblDeviceLockHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_DeviceLockHelp;

            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;

            // 
            // btnCancel
            // 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            // 
            // layoutControlGroupRoot
            // 
            this.layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupRoot.GroupBordersVisible = false;
            this.layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.tabbedControlGroup1,
                this.emptySpaceItemBottom,
                this.layoutItemSave,
                this.layoutItemCancel
            });
            this.layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(860, 640);
            this.layoutControlGroupRoot.TextVisible = false;

            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.tabGeneral;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(840, 574);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.tabGeneral,
                this.tabLate,
                this.tabOvertime,
                this.tabNotifications,
                this.tabWebSecurity,
                this.tabDeviceLocks
            });

            // 
            // tabGeneral
            // 
            this.tabGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupGeneralMain,
                this.groupFloatingRest,
                this.emptySpaceItemGeneral
            });
            this.tabGeneral.Location = new System.Drawing.Point(0, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(816, 526);
            this.tabGeneral.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_General;

            // 
            // groupGeneralMain
            // 
            this.groupGeneralMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemEnabled,
                this.layoutItemDefaultSchedule,
                this.layoutItemAttendanceMethod,
                this.layoutItemDebounce,
                this.layoutItemRequireApproval,
                this.layoutItemAllowManual,
                this.layoutItemAllowCorrection,
                this.layoutItemAutoCalculate,
                this.layoutItemAutoCloseDay
            });
            this.groupGeneralMain.Location = new System.Drawing.Point(0, 0);
            this.groupGeneralMain.Name = "groupGeneralMain";
            this.groupGeneralMain.Size = new System.Drawing.Size(816, 175);
            this.groupGeneralMain.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_GeneralMain;

            // 
            // layoutItemEnabled
            // 
            this.layoutItemEnabled.Control = this.chkAttendanceEnabled;
            this.layoutItemEnabled.Location = new System.Drawing.Point(0, 0);
            this.layoutItemEnabled.Name = "layoutItemEnabled";
            this.layoutItemEnabled.Size = new System.Drawing.Size(792, 24);
            this.layoutItemEnabled.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemEnabled.TextVisible = false;

            // 
            // layoutItemDefaultSchedule
            // 
            this.layoutItemDefaultSchedule.Control = this.lkpDefaultSchedule;
            this.layoutItemDefaultSchedule.Location = new System.Drawing.Point(0, 24);
            this.layoutItemDefaultSchedule.Name = "layoutItemDefaultSchedule";
            this.layoutItemDefaultSchedule.Size = new System.Drawing.Size(396, 24);
            this.layoutItemDefaultSchedule.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_DefaultSchedule;
            this.layoutItemDefaultSchedule.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemAttendanceMethod
            // 
            this.layoutItemAttendanceMethod.Control = this.cmbAttendanceMethod;
            this.layoutItemAttendanceMethod.Location = new System.Drawing.Point(396, 24);
            this.layoutItemAttendanceMethod.Name = "layoutItemAttendanceMethod";
            this.layoutItemAttendanceMethod.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAttendanceMethod.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_AttendanceMethod;
            this.layoutItemAttendanceMethod.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemDebounce
            // 
            this.layoutItemDebounce.Control = this.spDebounceMinutes;
            this.layoutItemDebounce.Location = new System.Drawing.Point(0, 48);
            this.layoutItemDebounce.Name = "layoutItemDebounce";
            this.layoutItemDebounce.Size = new System.Drawing.Size(396, 24);
            this.layoutItemDebounce.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_DebounceMinutes;
            this.layoutItemDebounce.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemRequireApproval
            // 
            this.layoutItemRequireApproval.Control = this.chkRequireApproval;
            this.layoutItemRequireApproval.Location = new System.Drawing.Point(396, 48);
            this.layoutItemRequireApproval.Name = "layoutItemRequireApproval";
            this.layoutItemRequireApproval.Size = new System.Drawing.Size(396, 24);
            this.layoutItemRequireApproval.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemRequireApproval.TextVisible = false;

            // 
            // layoutItemAllowManual
            // 
            this.layoutItemAllowManual.Control = this.chkAllowManualEntry;
            this.layoutItemAllowManual.Location = new System.Drawing.Point(0, 72);
            this.layoutItemAllowManual.Name = "layoutItemAllowManual";
            this.layoutItemAllowManual.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAllowManual.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAllowManual.TextVisible = false;

            // 
            // layoutItemAllowCorrection
            // 
            this.layoutItemAllowCorrection.Control = this.chkAllowAttendanceCorrection;
            this.layoutItemAllowCorrection.Location = new System.Drawing.Point(396, 72);
            this.layoutItemAllowCorrection.Name = "layoutItemAllowCorrection";
            this.layoutItemAllowCorrection.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAllowCorrection.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAllowCorrection.TextVisible = false;

            // 
            // layoutItemAutoCalculate
            // 
            this.layoutItemAutoCalculate.Control = this.chkAutoCalculate;
            this.layoutItemAutoCalculate.Location = new System.Drawing.Point(0, 96);
            this.layoutItemAutoCalculate.Name = "layoutItemAutoCalculate";
            this.layoutItemAutoCalculate.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAutoCalculate.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAutoCalculate.TextVisible = false;

            // 
            // layoutItemAutoCloseDay
            // 
            this.layoutItemAutoCloseDay.Control = this.chkAutoCloseDay;
            this.layoutItemAutoCloseDay.Location = new System.Drawing.Point(396, 96);
            this.layoutItemAutoCloseDay.Name = "layoutItemAutoCloseDay";
            this.layoutItemAutoCloseDay.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAutoCloseDay.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAutoCloseDay.TextVisible = false;

            // 
            // groupFloatingRest
            // 
            this.groupFloatingRest.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemAutoFloatingRestDay,
                this.layoutItemMaxWeeklyRestDays,
                this.layoutItemFloatingRestHelp
            });
            this.groupFloatingRest.Location = new System.Drawing.Point(0, 175);
            this.groupFloatingRest.Name = "groupFloatingRest";
            this.groupFloatingRest.Size = new System.Drawing.Size(816, 125);
            this.groupFloatingRest.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_FloatingRest;

            // 
            // layoutItemAutoFloatingRestDay
            // 
            this.layoutItemAutoFloatingRestDay.Control = this.chkAutoFloatingRestDay;
            this.layoutItemAutoFloatingRestDay.Location = new System.Drawing.Point(0, 0);
            this.layoutItemAutoFloatingRestDay.Name = "layoutItemAutoFloatingRestDay";
            this.layoutItemAutoFloatingRestDay.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAutoFloatingRestDay.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAutoFloatingRestDay.TextVisible = false;

            // 
            // layoutItemMaxWeeklyRestDays
            // 
            this.layoutItemMaxWeeklyRestDays.Control = this.spMaxWeeklyRestDays;
            this.layoutItemMaxWeeklyRestDays.Location = new System.Drawing.Point(396, 0);
            this.layoutItemMaxWeeklyRestDays.Name = "layoutItemMaxWeeklyRestDays";
            this.layoutItemMaxWeeklyRestDays.Size = new System.Drawing.Size(396, 24);
            this.layoutItemMaxWeeklyRestDays.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_MaxWeeklyRestDays;
            this.layoutItemMaxWeeklyRestDays.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemFloatingRestHelp
            // 
            this.layoutItemFloatingRestHelp.Control = this.lblFloatingRestHelp;
            this.layoutItemFloatingRestHelp.Location = new System.Drawing.Point(0, 24);
            this.layoutItemFloatingRestHelp.Name = "layoutItemFloatingRestHelp";
            this.layoutItemFloatingRestHelp.Size = new System.Drawing.Size(792, 55);
            this.layoutItemFloatingRestHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemFloatingRestHelp.TextVisible = false;

            // 
            // emptySpaceItemGeneral
            // 
            this.emptySpaceItemGeneral.AllowHotTrack = false;
            this.emptySpaceItemGeneral.Location = new System.Drawing.Point(0, 300);
            this.emptySpaceItemGeneral.Name = "emptySpaceItemGeneral";
            this.emptySpaceItemGeneral.Size = new System.Drawing.Size(816, 226);
            this.emptySpaceItemGeneral.TextSize = new System.Drawing.Size(0, 0);

            // 
            // tabLate
            // 
            this.tabLate.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupLateCalc,
                this.groupEarlyExit,
                this.groupLateHelp,
                this.emptySpaceItemLate
            });
            this.tabLate.Location = new System.Drawing.Point(0, 0);
            this.tabLate.Name = "tabLate";
            this.tabLate.Size = new System.Drawing.Size(816, 526);
            this.tabLate.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_Late;

            // 
            // groupLateCalc
            // 
            this.groupLateCalc.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemGrace,
                this.layoutItemLateCalc,
                this.layoutItemLateRound,
                this.layoutItemAllowLateCorrection,
                this.layoutItemLateApproval
            });
            this.groupLateCalc.Location = new System.Drawing.Point(0, 0);
            this.groupLateCalc.Name = "groupLateCalc";
            this.groupLateCalc.Size = new System.Drawing.Size(816, 150);
            this.groupLateCalc.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_LateCalc;

            // 
            // layoutItemGrace
            // 
            this.layoutItemGrace.Control = this.spGracePeriod;
            this.layoutItemGrace.Location = new System.Drawing.Point(0, 0);
            this.layoutItemGrace.Name = "layoutItemGrace";
            this.layoutItemGrace.Size = new System.Drawing.Size(396, 24);
            this.layoutItemGrace.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_GracePeriod;
            this.layoutItemGrace.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemLateCalc
            // 
            this.layoutItemLateCalc.Control = this.cmbLateCalculationMethod;
            this.layoutItemLateCalc.Location = new System.Drawing.Point(396, 0);
            this.layoutItemLateCalc.Name = "layoutItemLateCalc";
            this.layoutItemLateCalc.Size = new System.Drawing.Size(396, 24);
            this.layoutItemLateCalc.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_LateCalculationMethod;
            this.layoutItemLateCalc.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemLateRound
            // 
            this.layoutItemLateRound.Control = this.cmbLateRoundingMethod;
            this.layoutItemLateRound.Location = new System.Drawing.Point(0, 24);
            this.layoutItemLateRound.Name = "layoutItemLateRound";
            this.layoutItemLateRound.Size = new System.Drawing.Size(396, 24);
            this.layoutItemLateRound.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_LateRoundingMethod;
            this.layoutItemLateRound.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemAllowLateCorrection
            // 
            this.layoutItemAllowLateCorrection.Control = this.chkAllowLateCorrection;
            this.layoutItemAllowLateCorrection.Location = new System.Drawing.Point(396, 24);
            this.layoutItemAllowLateCorrection.Name = "layoutItemAllowLateCorrection";
            this.layoutItemAllowLateCorrection.Size = new System.Drawing.Size(396, 24);
            this.layoutItemAllowLateCorrection.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemAllowLateCorrection.TextVisible = false;

            // 
            // layoutItemLateApproval
            // 
            this.layoutItemLateApproval.Control = this.chkLateApprovalRequired;
            this.layoutItemLateApproval.Location = new System.Drawing.Point(0, 48);
            this.layoutItemLateApproval.Name = "layoutItemLateApproval";
            this.layoutItemLateApproval.Size = new System.Drawing.Size(792, 24);
            this.layoutItemLateApproval.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemLateApproval.TextVisible = false;

            // 
            // groupEarlyExit
            // 
            this.groupEarlyExit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemEarlyExitGrace
            });
            this.groupEarlyExit.Location = new System.Drawing.Point(0, 150);
            this.groupEarlyExit.Name = "groupEarlyExit";
            this.groupEarlyExit.Size = new System.Drawing.Size(816, 75);
            this.groupEarlyExit.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_EarlyExit;

            // 
            // layoutItemEarlyExitGrace
            // 
            this.layoutItemEarlyExitGrace.Control = this.spEarlyExitGracePeriod;
            this.layoutItemEarlyExitGrace.Location = new System.Drawing.Point(0, 0);
            this.layoutItemEarlyExitGrace.Name = "layoutItemEarlyExitGrace";
            this.layoutItemEarlyExitGrace.Size = new System.Drawing.Size(792, 24);
            this.layoutItemEarlyExitGrace.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_EarlyExitGracePeriod;
            this.layoutItemEarlyExitGrace.TextSize = new System.Drawing.Size(185, 13);

            // 
            // groupLateHelp
            // 
            this.groupLateHelp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemLateHelp
            });
            this.groupLateHelp.Location = new System.Drawing.Point(0, 225);
            this.groupLateHelp.Name = "groupLateHelp";
            this.groupLateHelp.Size = new System.Drawing.Size(816, 80);
            this.groupLateHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_LateHelp;

            // 
            // layoutItemLateHelp
            // 
            this.layoutItemLateHelp.Control = this.lblLateHelp;
            this.layoutItemLateHelp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemLateHelp.Name = "layoutItemLateHelp";
            this.layoutItemLateHelp.Size = new System.Drawing.Size(792, 45);
            this.layoutItemLateHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemLateHelp.TextVisible = false;

            // 
            // emptySpaceItemLate
            // 
            this.emptySpaceItemLate.AllowHotTrack = false;
            this.emptySpaceItemLate.Location = new System.Drawing.Point(0, 305);
            this.emptySpaceItemLate.Name = "emptySpaceItemLate";
            this.emptySpaceItemLate.Size = new System.Drawing.Size(816, 221);
            this.emptySpaceItemLate.TextSize = new System.Drawing.Size(0, 0);

            // 
            // tabOvertime
            // 
            this.tabOvertime.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupOvertimeSettings,
                this.groupOvertimeHelp,
                this.emptySpaceItemOvertime
            });
            this.tabOvertime.Location = new System.Drawing.Point(0, 0);
            this.tabOvertime.Name = "tabOvertime";
            this.tabOvertime.Size = new System.Drawing.Size(816, 526);
            this.tabOvertime.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_Overtime;

            // 
            // groupOvertimeSettings
            // 
            this.groupOvertimeSettings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemOTPolicy,
                this.layoutItemMinOT,
                this.layoutItemOTRounding
            });
            this.groupOvertimeSettings.Location = new System.Drawing.Point(0, 0);
            this.groupOvertimeSettings.Name = "groupOvertimeSettings";
            this.groupOvertimeSettings.Size = new System.Drawing.Size(816, 105);
            this.groupOvertimeSettings.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_OvertimeSettings;

            // 
            // layoutItemOTPolicy
            // 
            this.layoutItemOTPolicy.Control = this.cmbOvertimePolicy;
            this.layoutItemOTPolicy.Location = new System.Drawing.Point(0, 0);
            this.layoutItemOTPolicy.Name = "layoutItemOTPolicy";
            this.layoutItemOTPolicy.Size = new System.Drawing.Size(396, 24);
            this.layoutItemOTPolicy.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_OvertimePolicy;
            this.layoutItemOTPolicy.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemMinOT
            // 
            this.layoutItemMinOT.Control = this.spMinOvertimeMinutes;
            this.layoutItemMinOT.Location = new System.Drawing.Point(396, 0);
            this.layoutItemMinOT.Name = "layoutItemMinOT";
            this.layoutItemMinOT.Size = new System.Drawing.Size(396, 24);
            this.layoutItemMinOT.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_MinOvertimeMinutes;
            this.layoutItemMinOT.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemOTRounding
            // 
            this.layoutItemOTRounding.Control = this.spOvertimeRoundingMinutes;
            this.layoutItemOTRounding.Location = new System.Drawing.Point(0, 24);
            this.layoutItemOTRounding.Name = "layoutItemOTRounding";
            this.layoutItemOTRounding.Size = new System.Drawing.Size(792, 24);
            this.layoutItemOTRounding.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_OvertimeRoundingMinutes;
            this.layoutItemOTRounding.TextSize = new System.Drawing.Size(185, 13);

            // 
            // groupOvertimeHelp
            // 
            this.groupOvertimeHelp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemOTHelp
            });
            this.groupOvertimeHelp.Location = new System.Drawing.Point(0, 105);
            this.groupOvertimeHelp.Name = "groupOvertimeHelp";
            this.groupOvertimeHelp.Size = new System.Drawing.Size(816, 80);
            this.groupOvertimeHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_OvertimeHelp;

            // 
            // layoutItemOTHelp
            // 
            this.layoutItemOTHelp.Control = this.lblOvertimeHelp;
            this.layoutItemOTHelp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemOTHelp.Name = "layoutItemOTHelp";
            this.layoutItemOTHelp.Size = new System.Drawing.Size(792, 45);
            this.layoutItemOTHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemOTHelp.TextVisible = false;

            // 
            // emptySpaceItemOvertime
            // 
            this.emptySpaceItemOvertime.AllowHotTrack = false;
            this.emptySpaceItemOvertime.Location = new System.Drawing.Point(0, 185);
            this.emptySpaceItemOvertime.Name = "emptySpaceItemOvertime";
            this.emptySpaceItemOvertime.Size = new System.Drawing.Size(816, 341);
            this.emptySpaceItemOvertime.TextSize = new System.Drawing.Size(0, 0);

            // 
            // tabNotifications
            // 
            this.tabNotifications.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupNotificationTriggers,
                this.groupNotificationHelp,
                this.emptySpaceItemNotifications
            });
            this.tabNotifications.Location = new System.Drawing.Point(0, 0);
            this.tabNotifications.Name = "tabNotifications";
            this.tabNotifications.Size = new System.Drawing.Size(816, 526);
            this.tabNotifications.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_Notifications;

            // 
            // groupNotificationTriggers
            // 
            this.groupNotificationTriggers.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemNotifyLate,
                this.layoutItemNotifyAbsence,
                this.layoutItemNotifyMissing
            });
            this.groupNotificationTriggers.Location = new System.Drawing.Point(0, 0);
            this.groupNotificationTriggers.Name = "groupNotificationTriggers";
            this.groupNotificationTriggers.Size = new System.Drawing.Size(816, 125);
            this.groupNotificationTriggers.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_NotificationTriggers;

            // 
            // layoutItemNotifyLate
            // 
            this.layoutItemNotifyLate.Control = this.chkNotifyHrOnLate;
            this.layoutItemNotifyLate.Location = new System.Drawing.Point(0, 0);
            this.layoutItemNotifyLate.Name = "layoutItemNotifyLate";
            this.layoutItemNotifyLate.Size = new System.Drawing.Size(792, 24);
            this.layoutItemNotifyLate.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemNotifyLate.TextVisible = false;

            // 
            // layoutItemNotifyAbsence
            // 
            this.layoutItemNotifyAbsence.Control = this.chkNotifyManagerOnAbsence;
            this.layoutItemNotifyAbsence.Location = new System.Drawing.Point(0, 24);
            this.layoutItemNotifyAbsence.Name = "layoutItemNotifyAbsence";
            this.layoutItemNotifyAbsence.Size = new System.Drawing.Size(792, 24);
            this.layoutItemNotifyAbsence.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemNotifyAbsence.TextVisible = false;

            // 
            // layoutItemNotifyMissing
            // 
            this.layoutItemNotifyMissing.Control = this.chkNotifyOnMissingCheckOut;
            this.layoutItemNotifyMissing.Location = new System.Drawing.Point(0, 48);
            this.layoutItemNotifyMissing.Name = "layoutItemNotifyMissing";
            this.layoutItemNotifyMissing.Size = new System.Drawing.Size(792, 24);
            this.layoutItemNotifyMissing.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemNotifyMissing.TextVisible = false;

            // 
            // groupNotificationHelp
            // 
            this.groupNotificationHelp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemNotifyHelp
            });
            this.groupNotificationHelp.Location = new System.Drawing.Point(0, 125);
            this.groupNotificationHelp.Name = "groupNotificationHelp";
            this.groupNotificationHelp.Size = new System.Drawing.Size(816, 80);
            this.groupNotificationHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_NotificationHelp;

            // 
            // layoutItemNotifyHelp
            // 
            this.layoutItemNotifyHelp.Control = this.lblNotifyHelp;
            this.layoutItemNotifyHelp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemNotifyHelp.Name = "layoutItemNotifyHelp";
            this.layoutItemNotifyHelp.Size = new System.Drawing.Size(792, 45);
            this.layoutItemNotifyHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemNotifyHelp.TextVisible = false;

            // 
            // emptySpaceItemNotifications
            // 
            this.emptySpaceItemNotifications.AllowHotTrack = false;
            this.emptySpaceItemNotifications.Location = new System.Drawing.Point(0, 205);
            this.emptySpaceItemNotifications.Name = "emptySpaceItemNotifications";
            this.emptySpaceItemNotifications.Size = new System.Drawing.Size(816, 321);
            this.emptySpaceItemNotifications.TextSize = new System.Drawing.Size(0, 0);

            // 
            // tabWebSecurity
            // 
            this.tabWebSecurity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupWebSecurityChecks,
                this.groupStoreSecurityRules,
                this.groupWebSecurityHelp,
                this.emptySpaceItemWebSecurity
            });
            this.tabWebSecurity.Location = new System.Drawing.Point(0, 0);
            this.tabWebSecurity.Name = "tabWebSecurity";
            this.tabWebSecurity.Size = new System.Drawing.Size(816, 526);
            this.tabWebSecurity.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_WebSecurity;

            // 
            // groupWebSecurityChecks
            // 
            this.groupWebSecurityChecks.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemRequireDynamicQrCode,
                this.layoutItemRequireGpsGeofencing,
                this.layoutItemRequireDeviceLock
            });
            this.groupWebSecurityChecks.Location = new System.Drawing.Point(0, 0);
            this.groupWebSecurityChecks.Name = "groupWebSecurityChecks";
            this.groupWebSecurityChecks.Size = new System.Drawing.Size(816, 102);
            this.groupWebSecurityChecks.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_WebSecurity;

            // 
            // layoutItemRequireDynamicQrCode
            // 
            this.layoutItemRequireDynamicQrCode.Control = this.chkRequireDynamicQrCode;
            this.layoutItemRequireDynamicQrCode.Location = new System.Drawing.Point(0, 0);
            this.layoutItemRequireDynamicQrCode.Name = "layoutItemRequireDynamicQrCode";
            this.layoutItemRequireDynamicQrCode.Size = new System.Drawing.Size(792, 24);
            this.layoutItemRequireDynamicQrCode.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemRequireDynamicQrCode.TextVisible = false;

            // 
            // layoutItemRequireGpsGeofencing
            // 
            this.layoutItemRequireGpsGeofencing.Control = this.chkRequireGpsGeofencing;
            this.layoutItemRequireGpsGeofencing.Location = new System.Drawing.Point(0, 24);
            this.layoutItemRequireGpsGeofencing.Name = "layoutItemRequireGpsGeofencing";
            this.layoutItemRequireGpsGeofencing.Size = new System.Drawing.Size(792, 24);
            this.layoutItemRequireGpsGeofencing.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemRequireGpsGeofencing.TextVisible = false;

            // 
            // layoutItemRequireDeviceLock
            // 
            this.layoutItemRequireDeviceLock.Control = this.chkRequireDeviceLock;
            this.layoutItemRequireDeviceLock.Location = new System.Drawing.Point(0, 48);
            this.layoutItemRequireDeviceLock.Name = "layoutItemRequireDeviceLock";
            this.layoutItemRequireDeviceLock.Size = new System.Drawing.Size(792, 24);
            this.layoutItemRequireDeviceLock.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemRequireDeviceLock.TextVisible = false;

            // 
            // groupStoreSecurityRules
            // 
            this.groupStoreSecurityRules.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemRuleStore,
                this.layoutItemRuleLat,
                this.layoutItemRuleLon,
                this.layoutItemRuleRadius,
                this.layoutItemRuleIps,
                this.layoutItemStoreEnforceWifi,
                this.layoutItemSaveStoreRule,
                this.emptySpaceItemSaveStore
            });
            this.groupStoreSecurityRules.Location = new System.Drawing.Point(0, 102);
            this.groupStoreSecurityRules.Name = "groupStoreSecurityRules";
            this.groupStoreSecurityRules.Size = new System.Drawing.Size(816, 170);
            this.groupStoreSecurityRules.Text = "Filial Təhlükəsizlik və Məkan Qaydaları (GPS & Wi-Fi)";

            // 
            // layoutItemRuleStore
            // 
            this.layoutItemRuleStore.Control = this.lkpRuleStore;
            this.layoutItemRuleStore.Location = new System.Drawing.Point(0, 0);
            this.layoutItemRuleStore.Name = "layoutItemRuleStore";
            this.layoutItemRuleStore.Size = new System.Drawing.Size(792, 24);
            this.layoutItemRuleStore.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Store;
            this.layoutItemRuleStore.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemRuleLat
            // 
            this.layoutItemRuleLat.Control = this.spRuleLat;
            this.layoutItemRuleLat.Location = new System.Drawing.Point(0, 24);
            this.layoutItemRuleLat.Name = "layoutItemRuleLat";
            this.layoutItemRuleLat.Size = new System.Drawing.Size(396, 24);
            this.layoutItemRuleLat.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Latitude;
            this.layoutItemRuleLat.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemRuleLon
            // 
            this.layoutItemRuleLon.Control = this.spRuleLon;
            this.layoutItemRuleLon.Location = new System.Drawing.Point(396, 24);
            this.layoutItemRuleLon.Name = "layoutItemRuleLon";
            this.layoutItemRuleLon.Size = new System.Drawing.Size(396, 24);
            this.layoutItemRuleLon.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Longitude;
            this.layoutItemRuleLon.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemRuleRadius
            // 
            this.layoutItemRuleRadius.Control = this.spRuleRadius;
            this.layoutItemRuleRadius.Location = new System.Drawing.Point(0, 48);
            this.layoutItemRuleRadius.Name = "layoutItemRuleRadius";
            this.layoutItemRuleRadius.Size = new System.Drawing.Size(396, 24);
            this.layoutItemRuleRadius.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Radius;
            this.layoutItemRuleRadius.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemRuleIps
            // 
            this.layoutItemRuleIps.Control = this.txtRuleIps;
            this.layoutItemRuleIps.Location = new System.Drawing.Point(396, 48);
            this.layoutItemRuleIps.Name = "layoutItemRuleIps";
            this.layoutItemRuleIps.Size = new System.Drawing.Size(396, 24);
            this.layoutItemRuleIps.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_AllowedWifiIps;
            this.layoutItemRuleIps.TextSize = new System.Drawing.Size(185, 13);

            // 
            // layoutItemStoreEnforceWifi
            // 
            this.layoutItemStoreEnforceWifi.Control = this.chkStoreEnforceWifi;
            this.layoutItemStoreEnforceWifi.Location = new System.Drawing.Point(0, 72);
            this.layoutItemStoreEnforceWifi.Name = "layoutItemStoreEnforceWifi";
            this.layoutItemStoreEnforceWifi.Size = new System.Drawing.Size(792, 24);
            this.layoutItemStoreEnforceWifi.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemStoreEnforceWifi.TextVisible = false;

            // 
            // layoutItemSaveStoreRule
            // 
            this.layoutItemSaveStoreRule.Control = this.btnSaveStoreRule;
            this.layoutItemSaveStoreRule.Location = new System.Drawing.Point(0, 96);
            this.layoutItemSaveStoreRule.MaxSize = new System.Drawing.Size(200, 32);
            this.layoutItemSaveStoreRule.MinSize = new System.Drawing.Size(180, 28);
            this.layoutItemSaveStoreRule.Name = "layoutItemSaveStoreRule";
            this.layoutItemSaveStoreRule.Size = new System.Drawing.Size(200, 32);
            this.layoutItemSaveStoreRule.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutItemSaveStoreRule.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemSaveStoreRule.TextVisible = false;

            // 
            // emptySpaceItemSaveStore
            // 
            this.emptySpaceItemSaveStore.AllowHotTrack = false;
            this.emptySpaceItemSaveStore.Location = new System.Drawing.Point(200, 96);
            this.emptySpaceItemSaveStore.Name = "emptySpaceItemSaveStore";
            this.emptySpaceItemSaveStore.Size = new System.Drawing.Size(592, 32);
            this.emptySpaceItemSaveStore.TextSize = new System.Drawing.Size(0, 0);

            // 
            // groupWebSecurityHelp
            // 
            this.groupWebSecurityHelp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemWebSecurityHelp
            });
            this.groupWebSecurityHelp.Location = new System.Drawing.Point(0, 272);
            this.groupWebSecurityHelp.Name = "groupWebSecurityHelp";
            this.groupWebSecurityHelp.Size = new System.Drawing.Size(816, 75);
            this.groupWebSecurityHelp.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Group_NotificationHelp;

            // 
            // layoutItemWebSecurityHelp
            // 
            this.layoutItemWebSecurityHelp.Control = this.lblWebSecurityHelp;
            this.layoutItemWebSecurityHelp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemWebSecurityHelp.Name = "layoutItemWebSecurityHelp";
            this.layoutItemWebSecurityHelp.Size = new System.Drawing.Size(792, 40);
            this.layoutItemWebSecurityHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemWebSecurityHelp.TextVisible = false;

            // 
            // emptySpaceItemWebSecurity
            // 
            this.emptySpaceItemWebSecurity.AllowHotTrack = false;
            this.emptySpaceItemWebSecurity.Location = new System.Drawing.Point(0, 347);
            this.emptySpaceItemWebSecurity.Name = "emptySpaceItemWebSecurity";
            this.emptySpaceItemWebSecurity.Size = new System.Drawing.Size(816, 179);
            this.emptySpaceItemWebSecurity.TextSize = new System.Drawing.Size(0, 0);

            // 
            // tabDeviceLocks
            // 
            this.tabDeviceLocks.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.groupDeviceLocksGrid
            });
            this.tabDeviceLocks.Location = new System.Drawing.Point(0, 0);
            this.tabDeviceLocks.Name = "tabDeviceLocks";
            this.tabDeviceLocks.Size = new System.Drawing.Size(816, 526);
            this.tabDeviceLocks.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Tab_DeviceLocks;

            // 
            // groupDeviceLocksGrid
            // 
            this.groupDeviceLocksGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemDeviceLockHelp,
                this.layoutItemRefreshDevices,
                this.layoutItemDeviceLocksGrid
            });
            this.groupDeviceLocksGrid.Location = new System.Drawing.Point(0, 0);
            this.groupDeviceLocksGrid.Name = "groupDeviceLocksGrid";
            this.groupDeviceLocksGrid.Size = new System.Drawing.Size(816, 526);
            this.groupDeviceLocksGrid.Text = "Təsdiqlənmiş Mobil Cihazlar (Device Lock)";

            // 
            // layoutItemDeviceLockHelp
            // 
            this.layoutItemDeviceLockHelp.Control = this.lblDeviceLockHelp;
            this.layoutItemDeviceLockHelp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemDeviceLockHelp.Name = "layoutItemDeviceLockHelp";
            this.layoutItemDeviceLockHelp.Size = new System.Drawing.Size(672, 32);
            this.layoutItemDeviceLockHelp.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemDeviceLockHelp.TextVisible = false;

            // 
            // layoutItemRefreshDevices
            // 
            this.layoutItemRefreshDevices.Control = this.btnRefreshDevices;
            this.layoutItemRefreshDevices.Location = new System.Drawing.Point(672, 0);
            this.layoutItemRefreshDevices.MaxSize = new System.Drawing.Size(120, 32);
            this.layoutItemRefreshDevices.MinSize = new System.Drawing.Size(100, 28);
            this.layoutItemRefreshDevices.Name = "layoutItemRefreshDevices";
            this.layoutItemRefreshDevices.Size = new System.Drawing.Size(120, 32);
            this.layoutItemRefreshDevices.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutItemRefreshDevices.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemRefreshDevices.TextVisible = false;

            // 
            // layoutItemDeviceLocksGrid
            // 
            this.layoutItemDeviceLocksGrid.Control = this.gcDeviceLocks;
            this.layoutItemDeviceLocksGrid.Location = new System.Drawing.Point(0, 32);
            this.layoutItemDeviceLocksGrid.Name = "layoutItemDeviceLocksGrid";
            this.layoutItemDeviceLocksGrid.Size = new System.Drawing.Size(792, 458);
            this.layoutItemDeviceLocksGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemDeviceLocksGrid.TextVisible = false;

            // 
            // emptySpaceItemBottom
            // 
            this.emptySpaceItemBottom.AllowHotTrack = false;
            this.emptySpaceItemBottom.Location = new System.Drawing.Point(0, 574);
            this.emptySpaceItemBottom.Name = "emptySpaceItemBottom";
            this.emptySpaceItemBottom.Size = new System.Drawing.Size(600, 46);
            this.emptySpaceItemBottom.TextSize = new System.Drawing.Size(0, 0);

            // 
            // layoutItemSave
            // 
            this.layoutItemSave.Control = this.btnSave;
            this.layoutItemSave.Location = new System.Drawing.Point(600, 574);
            this.layoutItemSave.MaxSize = new System.Drawing.Size(120, 46);
            this.layoutItemSave.MinSize = new System.Drawing.Size(110, 32);
            this.layoutItemSave.Name = "layoutItemSave";
            this.layoutItemSave.Size = new System.Drawing.Size(120, 46);
            this.layoutItemSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutItemSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemSave.TextVisible = false;

            // 
            // layoutItemCancel
            // 
            this.layoutItemCancel.Control = this.btnCancel;
            this.layoutItemCancel.Location = new System.Drawing.Point(720, 574);
            this.layoutItemCancel.MaxSize = new System.Drawing.Size(120, 46);
            this.layoutItemCancel.MinSize = new System.Drawing.Size(110, 32);
            this.layoutItemCancel.Name = "layoutItemCancel";
            this.layoutItemCancel.Size = new System.Drawing.Size(120, 46);
            this.layoutItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemCancel.TextVisible = false;

            // 
            // FormAttendanceSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.layoutControl1);
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "FormAttendanceSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_AttendanceSettings_Caption;

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAttendanceEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDefaultSchedule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAttendanceMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDebounceMinutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireApproval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowManualEntry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAttendanceCorrection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalculate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCloseDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoFloatingRestDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaxWeeklyRestDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGracePeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLateCalculationMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLateRoundingMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowLateCorrection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLateApprovalRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEarlyExitGracePeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOvertimePolicy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinOvertimeMinutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spOvertimeRoundingMinutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyHrOnLate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyManagerOnAbsence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotifyOnMissingCheckOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireDynamicQrCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireGpsGeofencing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireDeviceLock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRuleStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleLat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleLon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRuleRadius.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleIps.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreEnforceWifi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceLocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeviceLocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnUnlock)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGeneralMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDefaultSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAttendanceMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDebounce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoCalculate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoCloseDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFloatingRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAutoFloatingRestDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMaxWeeklyRestDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemFloatingRestHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemGeneral)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabLate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGrace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemAllowLateCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupEarlyExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEarlyExitGrace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLateHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLate)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertimeSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTPolicy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMinOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTRounding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertimeHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOTHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemOvertime)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupNotificationTriggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyLate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyMissing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupNotificationHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNotifyHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemNotifications)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabWebSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupWebSecurityChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireDynamicQrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireGpsGeofencing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRequireDeviceLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupStoreSecurityRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRuleIps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStoreEnforceWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSaveStoreRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemSaveStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupWebSecurityHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemWebSecurityHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemWebSecurity)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.tabDeviceLocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDeviceLocksGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDeviceLockHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRefreshDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDeviceLocksGrid)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;

        private DevExpress.XtraLayout.LayoutControlGroup tabGeneral;
        private DevExpress.XtraLayout.LayoutControlGroup groupGeneralMain;
        private DevExpress.XtraLayout.LayoutControlGroup groupFloatingRest;
        private DevExpress.XtraLayout.LayoutControlGroup tabLate;
        private DevExpress.XtraLayout.LayoutControlGroup groupLateCalc;
        private DevExpress.XtraLayout.LayoutControlGroup groupEarlyExit;
        private DevExpress.XtraLayout.LayoutControlGroup groupLateHelp;
        private DevExpress.XtraLayout.LayoutControlGroup tabOvertime;
        private DevExpress.XtraLayout.LayoutControlGroup groupOvertimeSettings;
        private DevExpress.XtraLayout.LayoutControlGroup groupOvertimeHelp;
        private DevExpress.XtraLayout.LayoutControlGroup tabNotifications;
        private DevExpress.XtraLayout.LayoutControlGroup groupNotificationTriggers;
        private DevExpress.XtraLayout.LayoutControlGroup groupNotificationHelp;

        private DevExpress.XtraEditors.CheckEdit chkAttendanceEnabled;
        private DevExpress.XtraEditors.LookUpEdit lkpDefaultSchedule;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAttendanceMethod;
        private DevExpress.XtraEditors.SpinEdit spDebounceMinutes;
        private DevExpress.XtraEditors.CheckEdit chkRequireApproval;
        private DevExpress.XtraEditors.CheckEdit chkAllowManualEntry;
        private DevExpress.XtraEditors.CheckEdit chkAllowAttendanceCorrection;
        private DevExpress.XtraEditors.CheckEdit chkAutoCalculate;
        private DevExpress.XtraEditors.CheckEdit chkAutoCloseDay;
        private DevExpress.XtraEditors.CheckEdit chkAutoFloatingRestDay;
        private DevExpress.XtraEditors.SpinEdit spMaxWeeklyRestDays;
        private DevExpress.XtraEditors.LabelControl lblFloatingRestHelp;

        private DevExpress.XtraEditors.SpinEdit spGracePeriod;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLateCalculationMethod;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLateRoundingMethod;
        private DevExpress.XtraEditors.CheckEdit chkAllowLateCorrection;
        private DevExpress.XtraEditors.CheckEdit chkLateApprovalRequired;
        private DevExpress.XtraEditors.SpinEdit spEarlyExitGracePeriod;
        private DevExpress.XtraEditors.LabelControl lblLateHelp;

        private DevExpress.XtraEditors.ComboBoxEdit cmbOvertimePolicy;
        private DevExpress.XtraEditors.SpinEdit spMinOvertimeMinutes;
        private DevExpress.XtraEditors.SpinEdit spOvertimeRoundingMinutes;
        private DevExpress.XtraEditors.LabelControl lblOvertimeHelp;

        private DevExpress.XtraEditors.CheckEdit chkNotifyHrOnLate;
        private DevExpress.XtraEditors.CheckEdit chkNotifyManagerOnAbsence;
        private DevExpress.XtraEditors.CheckEdit chkNotifyOnMissingCheckOut;
        private DevExpress.XtraEditors.LabelControl lblNotifyHelp;

        private DevExpress.XtraEditors.CheckEdit chkRequireDynamicQrCode;
        private DevExpress.XtraEditors.CheckEdit chkRequireGpsGeofencing;
        private DevExpress.XtraEditors.CheckEdit chkRequireDeviceLock;
        private DevExpress.XtraEditors.LabelControl lblWebSecurityHelp;

        private DevExpress.XtraEditors.LookUpEdit lkpRuleStore;
        private DevExpress.XtraEditors.SpinEdit spRuleLat;
        private DevExpress.XtraEditors.SpinEdit spRuleLon;
        private DevExpress.XtraEditors.SpinEdit spRuleRadius;
        private DevExpress.XtraEditors.TextEdit txtRuleIps;
        private DevExpress.XtraEditors.CheckEdit chkStoreEnforceWifi;
        private DevExpress.XtraEditors.SimpleButton btnSaveStoreRule;

        private DevExpress.XtraGrid.GridControl gcDeviceLocks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeviceLocks;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceId;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisteredAt;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUsedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlockAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnUnlock;
        private DevExpress.XtraEditors.SimpleButton btnRefreshDevices;
        private DevExpress.XtraEditors.LabelControl lblDeviceLockHelp;

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        private DevExpress.XtraLayout.LayoutControlItem layoutItemEnabled;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDefaultSchedule;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAttendanceMethod;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDebounce;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRequireApproval;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAllowManual;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAllowCorrection;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAutoCalculate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAutoCloseDay;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAutoFloatingRestDay;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMaxWeeklyRestDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemFloatingRestHelp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemGeneral;

        private DevExpress.XtraLayout.LayoutControlItem layoutItemGrace;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemLateCalc;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemLateRound;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemAllowLateCorrection;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemLateApproval;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEarlyExitGrace;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemLateHelp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemLate;

        private DevExpress.XtraLayout.LayoutControlItem layoutItemOTPolicy;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMinOT;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemOTRounding;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemOTHelp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemOvertime;

        private DevExpress.XtraLayout.LayoutControlItem layoutItemNotifyLate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNotifyAbsence;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNotifyMissing;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNotifyHelp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemNotifications;

        private DevExpress.XtraLayout.LayoutControlGroup tabWebSecurity;
        private DevExpress.XtraLayout.LayoutControlGroup groupWebSecurityChecks;
        private DevExpress.XtraLayout.LayoutControlGroup groupWebSecurityHelp;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRequireDynamicQrCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRequireGpsGeofencing;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRequireDeviceLock;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemWebSecurityHelp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemWebSecurity;

        private DevExpress.XtraLayout.LayoutControlGroup groupStoreSecurityRules;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRuleStore;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRuleLat;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRuleLon;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRuleRadius;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRuleIps;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemStoreEnforceWifi;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSaveStoreRule;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemSaveStore;

        private DevExpress.XtraLayout.LayoutControlGroup tabDeviceLocks;
        private DevExpress.XtraLayout.LayoutControlGroup groupDeviceLocksGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDeviceLockHelp;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRefreshDevices;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDeviceLocksGrid;

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBottom;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemCancel;
    }
}
