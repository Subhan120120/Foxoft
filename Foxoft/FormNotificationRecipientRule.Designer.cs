using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormNotificationRecipientRule
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
            gC_RecipientRules = new MyGridControl();
            recipientRuleBindingSource = new BindingSource(components);
            gV_RecipientRules = new MyGridView();
            colNotificationRecipientRuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotificationTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditNotificationType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colNotificationCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDefaultSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            colRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditRole = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)gC_RecipientRules).BeginInit();
            ((ISupportInitialize)recipientRuleBindingSource).BeginInit();
            ((ISupportInitialize)gV_RecipientRules).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditRole).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).BeginInit();
            ((ISupportInitialize)repositoryItemCheckEdit).BeginInit();
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
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(1180, 158);
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
            ribbonPage1.Text = Resources.Form_NotificationRecipientRule;
            // 
            // ribbonPageGroupRules
            // 
            ribbonPageGroupRules.ItemLinks.Add(bBI_New);
            ribbonPageGroupRules.ItemLinks.Add(bBI_Save);
            ribbonPageGroupRules.ItemLinks.Add(bBI_Delete);
            ribbonPageGroupRules.Name = "ribbonPageGroupRules";
            ribbonPageGroupRules.Text = Resources.Form_NotificationRecipientRule_Rules;
            // 
            // ribbonPageGroupData
            // 
            ribbonPageGroupData.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupData.ItemLinks.Add(bBI_Cancel);
            ribbonPageGroupData.Name = "ribbonPageGroupData";
            ribbonPageGroupData.Text = Resources.Form_NotificationRecipientRule_Data;
            // 
            // ribbonPageGroupExport
            // 
            ribbonPageGroupExport.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroupExport.Name = "ribbonPageGroupExport";
            ribbonPageGroupExport.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 676);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(1180, 24);
            // 
            // gC_RecipientRules
            // 
            gC_RecipientRules.DataSource = recipientRuleBindingSource;
            gC_RecipientRules.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_RecipientRules.Location = new System.Drawing.Point(0, 158);
            gC_RecipientRules.MainView = gV_RecipientRules;
            gC_RecipientRules.MenuManager = ribbonControl1;
            gC_RecipientRules.Name = "gC_RecipientRules";
            gC_RecipientRules.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEditNotificationType, repositoryItemLookUpEditRole, repositoryItemLookUpEditStore, repositoryItemCheckEdit });
            gC_RecipientRules.Size = new System.Drawing.Size(1180, 518);
            gC_RecipientRules.TabIndex = 0;
            gC_RecipientRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_RecipientRules });
            gC_RecipientRules.ProcessGridKey += gC_RecipientRules_ProcessGridKey;
            // 
            // recipientRuleBindingSource
            // 
            recipientRuleBindingSource.DataSource = typeof(NotificationRecipientRule);
            // 
            // gV_RecipientRules
            // 
            gV_RecipientRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNotificationRecipientRuleId, colNotificationTypeCode, colNotificationCategoryCode, colDefaultSeverity, colRoleCode, colStoreCode, colIsEnabled, colCreatedDate, colLastUpdatedDate });
            gV_RecipientRules.GridControl = gC_RecipientRules;
            gV_RecipientRules.Name = "gV_RecipientRules";
            gV_RecipientRules.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_RecipientRules.OptionsFind.FindDelay = 100;
            gV_RecipientRules.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gV_RecipientRules.OptionsView.ShowAutoFilterRow = true;
            gV_RecipientRules.OptionsView.ShowFooter = true;
            gV_RecipientRules.OptionsView.ShowGroupPanel = false;
            gV_RecipientRules.RowCellStyle += gV_RecipientRules_RowCellStyle;
            gV_RecipientRules.ValidateRow += gV_RecipientRules_ValidateRow;
            gV_RecipientRules.InvalidRowException += gV_RecipientRules_InvalidRowException;
            gV_RecipientRules.PopupMenuShowing += gV_RecipientRules_PopupMenuShowing;
            // 
            // colNotificationRecipientRuleId
            // 
            colNotificationRecipientRuleId.Caption = Resources.Entity_NotificationRecipientRule_Id;
            colNotificationRecipientRuleId.FieldName = "NotificationRecipientRuleId";
            colNotificationRecipientRuleId.Name = "colNotificationRecipientRuleId";
            colNotificationRecipientRuleId.OptionsColumn.AllowEdit = false;
            colNotificationRecipientRuleId.Visible = true;
            colNotificationRecipientRuleId.VisibleIndex = 0;
            colNotificationRecipientRuleId.Width = 80;
            // 
            // colNotificationTypeCode
            // 
            colNotificationTypeCode.Caption = Resources.Entity_NotificationType;
            colNotificationTypeCode.ColumnEdit = repositoryItemLookUpEditNotificationType;
            colNotificationTypeCode.FieldName = "NotificationTypeCode";
            colNotificationTypeCode.Name = "colNotificationTypeCode";
            colNotificationTypeCode.Visible = true;
            colNotificationTypeCode.VisibleIndex = 1;
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
            colNotificationCategoryCode.VisibleIndex = 2;
            colNotificationCategoryCode.Width = 100;
            // 
            // colDefaultSeverity
            // 
            colDefaultSeverity.Caption = Resources.Entity_NotificationType_DefaultSeverity;
            colDefaultSeverity.FieldName = "NotificationType.DefaultSeverity";
            colDefaultSeverity.Name = "colDefaultSeverity";
            colDefaultSeverity.OptionsColumn.AllowEdit = false;
            colDefaultSeverity.Visible = true;
            colDefaultSeverity.VisibleIndex = 3;
            colDefaultSeverity.Width = 100;
            // 
            // colRoleCode
            // 
            colRoleCode.Caption = Resources.Entity_Role_Code;
            colRoleCode.ColumnEdit = repositoryItemLookUpEditRole;
            colRoleCode.FieldName = "RoleCode";
            colRoleCode.Name = "colRoleCode";
            colRoleCode.Visible = true;
            colRoleCode.VisibleIndex = 4;
            colRoleCode.Width = 180;
            // 
            // repositoryItemLookUpEditRole
            // 
            repositoryItemLookUpEditRole.AutoHeight = false;
            repositoryItemLookUpEditRole.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditRole.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo(nameof(DcRole.RoleCode), Resources.Entity_Role_Code), new LookUpColumnInfo(nameof(DcRole.RoleDesc), Resources.Entity_Role_Desc) });
            repositoryItemLookUpEditRole.DisplayMember = nameof(DcRole.RoleDesc);
            repositoryItemLookUpEditRole.Name = "repositoryItemLookUpEditRole";
            repositoryItemLookUpEditRole.NullText = "";
            repositoryItemLookUpEditRole.SearchMode = SearchMode.AutoSearch;
            repositoryItemLookUpEditRole.ValueMember = nameof(DcRole.RoleCode);
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colStoreCode.ColumnEdit = repositoryItemLookUpEditStore;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.Visible = true;
            colStoreCode.VisibleIndex = 5;
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
            repositoryItemLookUpEditStore.NullText = Resources.Form_NotificationRecipientRule_AllStores;
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
            colIsEnabled.VisibleIndex = 6;
            colIsEnabled.Width = 80;
            // 
            // repositoryItemCheckEdit
            // 
            repositoryItemCheckEdit.AutoHeight = false;
            repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.OptionsColumn.AllowEdit = false;
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 7;
            colCreatedDate.Width = 120;
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.Caption = Resources.Entity_Base_LastUpdatedDate;
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            colLastUpdatedDate.OptionsColumn.AllowEdit = false;
            colLastUpdatedDate.Visible = true;
            colLastUpdatedDate.VisibleIndex = 8;
            colLastUpdatedDate.Width = 120;
            // 
            // FormNotificationRecipientRule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1180, 700);
            Controls.Add(gC_RecipientRules);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormNotificationRecipientRule";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_NotificationRecipientRule;
            FormClosed += FormNotificationRecipientRule_FormClosed;
            Load += FormNotificationRecipientRule_Load;
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)gC_RecipientRules).EndInit();
            ((ISupportInitialize)recipientRuleBindingSource).EndInit();
            ((ISupportInitialize)gV_RecipientRules).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditRole).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).EndInit();
            ((ISupportInitialize)repositoryItemCheckEdit).EndInit();
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
        private MyGridControl gC_RecipientRules;
        private MyGridView gV_RecipientRules;
        private System.Windows.Forms.BindingSource recipientRuleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationRecipientRuleId;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNotificationType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
    }
}
