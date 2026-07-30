using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormNotificationRule
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_New = new DevExpress.XtraBars.BarButtonItem();
            bBI_Save = new DevExpress.XtraBars.BarButtonItem();
            bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_Cancel = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupRules = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            gC_NotificationRules = new MyGridControl();
            notificationRuleBindingSource = new BindingSource(components);
            gV_NotificationRules = new MyGridView();
            colNotificationRuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotificationTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditNotificationType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colNotificationCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDefaultSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            colAllowPopup = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colThrottleMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemSpinEditThrottleMinutes = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            colChannelCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckedComboBoxEditChannels = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            colPopupMinSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemImageComboBoxSeverity = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)gC_NotificationRules).BeginInit();
            ((ISupportInitialize)notificationRuleBindingSource).BeginInit();
            ((ISupportInitialize)gV_NotificationRules).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).BeginInit();
            ((ISupportInitialize)repositoryItemCheckEdit).BeginInit();
            ((ISupportInitialize)repositoryItemSpinEditThrottleMinutes).BeginInit();
            ((ISupportInitialize)repositoryItemCheckedComboBoxEditChannels).BeginInit();
            ((ISupportInitialize)repositoryItemImageComboBoxSeverity).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("new", "image://svgimages/actions/add.svg");
            svgImageCollection1.Add("save", "image://svgimages/save/save.svg");
            svgImageCollection1.Add("delete", "image://svgimages/scheduling/delete.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("cancel", "image://svgimages/actions/cancel.svg");
            svgImageCollection1.Add("export", "image://svgimages/export/exporttoxlsx.svg");
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_New, bBI_Save, bBI_Delete, bBI_Refresh, bBI_Cancel, bBI_ExportXlsx });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1180, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_New
            // 
            bBI_New.Caption = Resources.Common_New;
            bBI_New.Id = 1;
            bBI_New.ImageOptions.SvgImage = svgImageCollection1["new"];
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_Save
            // 
            bBI_Save.Caption = Resources.Common_Save;
            bBI_Save.Id = 2;
            bBI_Save.ImageOptions.SvgImage = svgImageCollection1["save"];
            bBI_Save.Name = "bBI_Save";
            bBI_Save.ItemClick += bBI_Save_ItemClick;
            // 
            // bBI_Delete
            // 
            bBI_Delete.Caption = Resources.Common_Delete;
            bBI_Delete.Id = 3;
            bBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_Delete.Name = "bBI_Delete";
            bBI_Delete.ItemClick += bBI_Delete_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 4;
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_Cancel
            // 
            bBI_Cancel.Caption = Resources.Common_Cancel;
            bBI_Cancel.Id = 5;
            bBI_Cancel.ImageOptions.SvgImage = svgImageCollection1["cancel"];
            bBI_Cancel.Name = "bBI_Cancel";
            bBI_Cancel.ItemClick += bBI_Cancel_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 6;
            bBI_ExportXlsx.ImageOptions.SvgImage = svgImageCollection1["export"];
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupRules, ribbonPageGroupData, ribbonPageGroupExport });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_NotificationRule;
            // 
            // ribbonPageGroupRules
            // 
            ribbonPageGroupRules.ItemLinks.Add(bBI_New);
            ribbonPageGroupRules.ItemLinks.Add(bBI_Save);
            ribbonPageGroupRules.ItemLinks.Add(bBI_Delete);
            ribbonPageGroupRules.Name = "ribbonPageGroupRules";
            ribbonPageGroupRules.Text = Resources.Form_NotificationRule_Rules;
            // 
            // ribbonPageGroupData
            // 
            ribbonPageGroupData.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupData.ItemLinks.Add(bBI_Cancel);
            ribbonPageGroupData.Name = "ribbonPageGroupData";
            ribbonPageGroupData.Text = Resources.Form_NotificationRule_Data;
            // 
            // ribbonPageGroupExport
            // 
            ribbonPageGroupExport.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroupExport.Name = "ribbonPageGroupExport";
            ribbonPageGroupExport.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 676);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1180, 24);
            // 
            // gC_NotificationRules
            // 
            gC_NotificationRules.DataSource = notificationRuleBindingSource;
            gC_NotificationRules.Dock = DockStyle.Fill;
            gC_NotificationRules.Location = new Point(0, 158);
            gC_NotificationRules.MainView = gV_NotificationRules;
            gC_NotificationRules.MenuManager = ribbonControl1;
            gC_NotificationRules.Name = "gC_NotificationRules";
            gC_NotificationRules.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEditNotificationType, repositoryItemLookUpEditStore, repositoryItemCheckEdit, repositoryItemSpinEditThrottleMinutes, repositoryItemCheckedComboBoxEditChannels, repositoryItemImageComboBoxSeverity });
            gC_NotificationRules.Size = new Size(1180, 518);
            gC_NotificationRules.TabIndex = 0;
            gC_NotificationRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_NotificationRules });
            gC_NotificationRules.ProcessGridKey += gC_NotificationRules_ProcessGridKey;
            // 
            // notificationRuleBindingSource
            // 
            notificationRuleBindingSource.DataSource = typeof(NotificationRule);
            // 
            // gV_NotificationRules
            // 
            gV_NotificationRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNotificationRuleId, colRuleName, colNotificationTypeCode, colNotificationCategoryCode, colDefaultSeverity, colAllowPopup, colStoreCode, colIsEnabled, colThrottleMinutes, colChannelCodes, colPopupMinSeverity, colCreatedDate, colLastUpdatedDate });
            gV_NotificationRules.GridControl = gC_NotificationRules;
            gV_NotificationRules.Name = "gV_NotificationRules";
            gV_NotificationRules.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_NotificationRules.OptionsFind.FindDelay = 100;
            gV_NotificationRules.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gV_NotificationRules.OptionsView.ShowAutoFilterRow = true;
            gV_NotificationRules.OptionsView.ShowFooter = true;
            gV_NotificationRules.OptionsView.ShowGroupPanel = false;
            gV_NotificationRules.CellValueChanged += gV_NotificationRules_CellValueChanged;
            gV_NotificationRules.RowCellStyle += gV_NotificationRules_RowCellStyle;
            gV_NotificationRules.ValidateRow += gV_NotificationRules_ValidateRow;
            gV_NotificationRules.InvalidRowException += gV_NotificationRules_InvalidRowException;
            gV_NotificationRules.PopupMenuShowing += gV_NotificationRules_PopupMenuShowing;
            // 
            // colNotificationRuleId
            // 
            colNotificationRuleId.Caption = Resources.Entity_NotificationRule_Id;
            colNotificationRuleId.FieldName = "NotificationRuleId";
            colNotificationRuleId.Name = "colNotificationRuleId";
            colNotificationRuleId.OptionsColumn.AllowEdit = false;
            colNotificationRuleId.Visible = true;
            colNotificationRuleId.VisibleIndex = 0;
            colNotificationRuleId.Width = 80;
            // 
            // colRuleName
            // 
            colRuleName.Caption = Resources.Entity_NotificationRule_Name;
            colRuleName.FieldName = "RuleName";
            colRuleName.Name = "colRuleName";
            colRuleName.Visible = true;
            colRuleName.VisibleIndex = 1;
            colRuleName.Width = 220;
            // 
            // colNotificationTypeCode
            // 
            colNotificationTypeCode.Caption = Resources.Entity_NotificationType;
            colNotificationTypeCode.ColumnEdit = repositoryItemLookUpEditNotificationType;
            colNotificationTypeCode.FieldName = "NotificationTypeCode";
            colNotificationTypeCode.Name = "colNotificationTypeCode";
            colNotificationTypeCode.Visible = true;
            colNotificationTypeCode.VisibleIndex = 2;
            colNotificationTypeCode.Width = 220;
            // 
            // repositoryItemLookUpEditNotificationType
            // 
            repositoryItemLookUpEditNotificationType.AutoHeight = false;
            repositoryItemLookUpEditNotificationType.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditNotificationType.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo(nameof(NotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code), new LookUpColumnInfo(nameof(NotificationType.CategoryCode), Resources.Entity_NotificationType_CategoryCode), new LookUpColumnInfo(nameof(NotificationType.NotificationTypeDesc), Resources.Entity_NotificationType_Desc), new LookUpColumnInfo(nameof(NotificationType.DefaultSeverity), Resources.Entity_NotificationType_DefaultSeverity) });
            repositoryItemLookUpEditNotificationType.DisplayMember = nameof(NotificationType.NotificationTypeDesc);
            repositoryItemLookUpEditNotificationType.Name = "repositoryItemLookUpEditNotificationType";
            repositoryItemLookUpEditNotificationType.NullText = "";
            repositoryItemLookUpEditNotificationType.SearchMode = SearchMode.AutoSearch;
            repositoryItemLookUpEditNotificationType.ValueMember = nameof(NotificationType.NotificationTypeCode);
            // 
            // colNotificationCategoryCode
            // 
            colNotificationCategoryCode.Caption = Resources.Entity_NotificationType_CategoryCode;
            colNotificationCategoryCode.FieldName = "NotificationType.CategoryCode";
            colNotificationCategoryCode.Name = "colNotificationCategoryCode";
            colNotificationCategoryCode.OptionsColumn.AllowEdit = false;
            colNotificationCategoryCode.Visible = true;
            colNotificationCategoryCode.VisibleIndex = 3;
            colNotificationCategoryCode.Width = 100;
            // 
            // colDefaultSeverity
            // 
            colDefaultSeverity.Caption = Resources.Entity_NotificationType_DefaultSeverity;
            colDefaultSeverity.FieldName = "NotificationType.DefaultSeverity";
            colDefaultSeverity.Name = "colDefaultSeverity";
            colDefaultSeverity.OptionsColumn.AllowEdit = false;
            colDefaultSeverity.Visible = true;
            colDefaultSeverity.VisibleIndex = 4;
            colDefaultSeverity.Width = 100;
            // 
            // colAllowPopup
            // 
            colAllowPopup.Caption = Resources.Entity_NotificationType_AllowPopup;
            colAllowPopup.ColumnEdit = repositoryItemCheckEdit;
            colAllowPopup.FieldName = "NotificationType.AllowPopup";
            colAllowPopup.Name = "colAllowPopup";
            colAllowPopup.OptionsColumn.AllowEdit = false;
            colAllowPopup.Visible = true;
            colAllowPopup.VisibleIndex = 5;
            colAllowPopup.Width = 80;
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colStoreCode.ColumnEdit = repositoryItemLookUpEditStore;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.Visible = true;
            colStoreCode.VisibleIndex = 6;
            colStoreCode.Width = 140;
            // 
            // repositoryItemLookUpEditStore
            // 
            repositoryItemLookUpEditStore.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            repositoryItemLookUpEditStore.AutoHeight = false;
            repositoryItemLookUpEditStore.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditStore.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccCode), Resources.Entity_CurrAcc_Code), new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccDesc), Resources.Entity_CurrAcc_Desc) });
            repositoryItemLookUpEditStore.DisplayMember = nameof(DcCurrAcc.CurrAccDesc);
            repositoryItemLookUpEditStore.Name = "repositoryItemLookUpEditStore";
            repositoryItemLookUpEditStore.NullText = Resources.Form_NotificationRule_AllStores;
            repositoryItemLookUpEditStore.SearchMode = SearchMode.AutoSearch;
            repositoryItemLookUpEditStore.ValueMember = nameof(DcCurrAcc.CurrAccCode);
            // 
            // colIsEnabled
            // 
            colIsEnabled.Caption = Resources.Common_IsEnabled;
            colIsEnabled.ColumnEdit = repositoryItemCheckEdit;
            colIsEnabled.FieldName = "IsEnabled";
            colIsEnabled.Name = "colIsEnabled";
            colIsEnabled.Visible = true;
            colIsEnabled.VisibleIndex = 7;
            colIsEnabled.Width = 80;
            // 
            // repositoryItemCheckEdit
            // 
            repositoryItemCheckEdit.AutoHeight = false;
            repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            // 
            // colThrottleMinutes
            // 
            colThrottleMinutes.Caption = Resources.Entity_NotificationRule_ThrottleMinutes;
            colThrottleMinutes.ColumnEdit = repositoryItemSpinEditThrottleMinutes;
            colThrottleMinutes.FieldName = "ThrottleMinutes";
            colThrottleMinutes.Name = "colThrottleMinutes";
            colThrottleMinutes.Visible = true;
            colThrottleMinutes.VisibleIndex = 8;
            colThrottleMinutes.Width = 110;
            // 
            // repositoryItemSpinEditThrottleMinutes
            // 
            repositoryItemSpinEditThrottleMinutes.AutoHeight = false;
            repositoryItemSpinEditThrottleMinutes.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemSpinEditThrottleMinutes.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            repositoryItemSpinEditThrottleMinutes.IsFloatValue = false;
            repositoryItemSpinEditThrottleMinutes.MaskSettings.Set("mask", "N00");
            repositoryItemSpinEditThrottleMinutes.MaxValue = new decimal(new int[] { 10080, 0, 0, 0 });
            repositoryItemSpinEditThrottleMinutes.Name = "repositoryItemSpinEditThrottleMinutes";
            // 
            // colChannelCodes
            // 
            colChannelCodes.Caption = Resources.Entity_NotificationRule_ChannelCodes;
            colChannelCodes.ColumnEdit = repositoryItemCheckedComboBoxEditChannels;
            colChannelCodes.FieldName = "ChannelCodes";
            colChannelCodes.Name = "colChannelCodes";
            colChannelCodes.Visible = true;
            colChannelCodes.VisibleIndex = 9;
            colChannelCodes.Width = 170;
            // 
            // repositoryItemCheckedComboBoxEditChannels
            // 
            repositoryItemCheckedComboBoxEditChannels.AutoHeight = false;
            repositoryItemCheckedComboBoxEditChannels.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemCheckedComboBoxEditChannels.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem(NotificationChannels.InApp, Resources.Form_NotificationRule_Channel_InApp), new CheckedListBoxItem(NotificationChannels.Popup, Resources.Form_NotificationRule_Channel_Popup), new CheckedListBoxItem(NotificationChannels.Sms, Resources.Form_NotificationRule_Channel_SMS), new CheckedListBoxItem(NotificationChannels.Email, Resources.Form_NotificationRule_Channel_Email), new CheckedListBoxItem(NotificationChannels.WhatsApp, Resources.Form_NotificationRule_Channel_WhatsApp) });
            repositoryItemCheckedComboBoxEditChannels.Name = "repositoryItemCheckedComboBoxEditChannels";
            repositoryItemCheckedComboBoxEditChannels.SelectAllItemVisible = false;
            repositoryItemCheckedComboBoxEditChannels.SeparatorChar = ',';
            // 
            // colPopupMinSeverity
            // 
            colPopupMinSeverity.Caption = Resources.Entity_NotificationRule_PopupMinSeverity;
            colPopupMinSeverity.ColumnEdit = repositoryItemImageComboBoxSeverity;
            colPopupMinSeverity.FieldName = "PopupMinSeverity";
            colPopupMinSeverity.Name = "colPopupMinSeverity";
            colPopupMinSeverity.Visible = true;
            colPopupMinSeverity.VisibleIndex = 10;
            colPopupMinSeverity.Width = 130;
            // 
            // repositoryItemImageComboBoxSeverity
            // 
            repositoryItemImageComboBoxSeverity.AutoHeight = false;
            repositoryItemImageComboBoxSeverity.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemImageComboBoxSeverity.Items.AddRange(new ImageComboBoxItem[] { new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Info, NotificationSeverities.Info), new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Warning, NotificationSeverities.Warning), new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_High, NotificationSeverities.High), new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Critical, NotificationSeverities.Critical) });
            repositoryItemImageComboBoxSeverity.Name = "repositoryItemImageComboBoxSeverity";
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.OptionsColumn.AllowEdit = false;
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 11;
            colCreatedDate.Width = 120;
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.Caption = Resources.Entity_Base_LastUpdatedDate;
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            colLastUpdatedDate.OptionsColumn.AllowEdit = false;
            colLastUpdatedDate.Visible = true;
            colLastUpdatedDate.VisibleIndex = 12;
            colLastUpdatedDate.Width = 120;
            // 
            // FormNotificationRule
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 700);
            Controls.Add(gC_NotificationRules);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormNotificationRule";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_NotificationRule;
            FormClosed += FormNotificationRule_FormClosed;
            Load += FormNotificationRule_Load;
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)gC_NotificationRules).EndInit();
            ((ISupportInitialize)notificationRuleBindingSource).EndInit();
            ((ISupportInitialize)gV_NotificationRules).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).EndInit();
            ((ISupportInitialize)repositoryItemCheckEdit).EndInit();
            ((ISupportInitialize)repositoryItemSpinEditThrottleMinutes).EndInit();
            ((ISupportInitialize)repositoryItemCheckedComboBoxEditChannels).EndInit();
            ((ISupportInitialize)repositoryItemImageComboBoxSeverity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_New;
        private DevExpress.XtraBars.BarButtonItem bBI_Save;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_Cancel;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupRules;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private MyGridControl gC_NotificationRules;
        private MyGridView gV_NotificationRules;
        private BindingSource notificationRuleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationRuleId;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleName;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowPopup;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colThrottleMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn colChannelCodes;
        private DevExpress.XtraGrid.Columns.GridColumn colPopupMinSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNotificationType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditThrottleMinutes;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEditChannels;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxSeverity;
    }
}
