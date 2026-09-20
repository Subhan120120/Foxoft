using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
            svgImageCollection1 = new SvgImageCollection(components);
            ribbonControl1 = new RibbonControl();
            bBI_Save = new BarButtonItem();
            bBI_Refresh = new BarButtonItem();
            bBI_New = new BarButtonItem();
            bBI_Delete = new BarButtonItem();
            bBI_NewTemplate = new BarButtonItem();
            bBI_DeleteTemplate = new BarButtonItem();
            bBI_NewRecipient = new BarButtonItem();
            bBI_DeleteRecipient = new BarButtonItem();
            bBI_ExportXlsx = new BarButtonItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroupOperations = new RibbonPageGroup();
            ribbonPageGroupRules = new RibbonPageGroup();
            ribbonPageGroupTemplates = new RibbonPageGroup();
            ribbonPageGroupRecipients = new RibbonPageGroup();
            ribbonPageGroupExport = new RibbonPageGroup();
            ribbonStatusBar1 = new RibbonStatusBar();
            splitContainerMain = new SplitContainerControl();
            groupControlRules = new GroupControl();
            gC_NotificationRules = new MyGridControl();
            notificationRuleBindingSource = new BindingSource(components);
            gV_NotificationRules = new MyGridView();
            colNotificationRuleId = new GridColumn();
            colIsEnabled = new GridColumn();
            repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colRuleName = new GridColumn();
            colNotificationCategoryCode = new GridColumn();
            colNotificationTypeCode = new GridColumn();
            colStoreCode = new GridColumn();
            colChannelCodes = new GridColumn();
            colThrottleMinutes = new GridColumn();
            colPopupMinSeverity = new GridColumn();
            panelHeader = new PanelControl();
            lblSelectedRuleSubtitle = new LabelControl();
            lblSelectedRuleTitle = new LabelControl();
            tabDetailControl = new XtraTabControl();
            tabParameters = new XtraTabPage();
            groupControlParameters = new GroupControl();
            groupControlChannels = new GroupControl();
            chkParamEmail = new CheckEdit();
            chkParamWhatsApp = new CheckEdit();
            chkParamSms = new CheckEdit();
            chkParamPopup = new CheckEdit();
            chkParamInApp = new CheckEdit();
            chkParamIsEnabled = new CheckEdit();
            cboParamSeverity = new ImageComboBoxEdit();
            lblParamSeverity = new LabelControl();
            seParamThrottle = new SpinEdit();
            lblParamThrottle = new LabelControl();
            lueParamStore = new LookUpEdit();
            lblParamStore = new LabelControl();
            lueParamNotificationType = new LookUpEdit();
            lblParamNotificationType = new LabelControl();
            txtParamRuleName = new TextEdit();
            lblParamRuleName = new LabelControl();
            tabTemplates = new XtraTabPage();
            splitContainerTemplates = new SplitContainerControl();
            gC_Templates = new MyGridControl();
            templateBindingSource = new BindingSource(components);
            gV_Templates = new MyGridView();
            colTemplateIsEnabled = new GridColumn();
            colTemplateLanguageCode = new GridColumn();
            repositoryItemLookUpEditLanguage = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colTemplateNotificationTypeCode = new GridColumn();
            repositoryItemLookUpEditNotificationType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colTemplateTitle = new GridColumn();
            colTemplateBody = new GridColumn();
            panelTemplateTop = new PanelControl();
            btnDeleteTemplate = new SimpleButton();
            btnNewTemplate = new SimpleButton();
            chkFilterSelectedTypeOnly = new CheckEdit();
            groupControlTemplateEditor = new GroupControl();
            panelPlaceholders = new FlowLayoutPanel();
            lblPlaceholdersTitle = new LabelControl();
            meTemplateBody = new MemoEdit();
            lblTemplateBody = new LabelControl();
            txtTemplateTitle = new TextEdit();
            lblTemplateTitle = new LabelControl();
            lblCharCount = new LabelControl();
            chkTemplateIsEnabled = new CheckEdit();
            cboTemplateLanguage = new ComboBoxEdit();
            lblTemplateLanguage = new LabelControl();
            tabRecipients = new XtraTabPage();
            gC_RecipientRules = new MyGridControl();
            recipientRuleBindingSource = new BindingSource(components);
            gV_RecipientRules = new MyGridView();
            colRecipientIsEnabled = new GridColumn();
            repositoryItemCheckEditRecipient = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colRecipientRoleCode = new GridColumn();
            repositoryItemLookUpEditRole = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colRecipientStoreCode = new GridColumn();
            repositoryItemLookUpEditRecipientStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colRecipientNotificationTypeCode = new GridColumn();
            repositoryItemLookUpEditRecipientNotificationType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            panelRecipientTop = new PanelControl();
            btnDeleteRecipient = new SimpleButton();
            btnNewRecipient = new SimpleButton();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)splitContainerMain).BeginInit();
            ((ISupportInitialize)splitContainerMain.Panel1).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            ((ISupportInitialize)splitContainerMain.Panel2).BeginInit();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((ISupportInitialize)groupControlRules).BeginInit();
            groupControlRules.SuspendLayout();
            ((ISupportInitialize)gC_NotificationRules).BeginInit();
            ((ISupportInitialize)notificationRuleBindingSource).BeginInit();
            ((ISupportInitialize)gV_NotificationRules).BeginInit();
            ((ISupportInitialize)repositoryItemCheckEdit).BeginInit();
            ((ISupportInitialize)panelHeader).BeginInit();
            panelHeader.SuspendLayout();
            ((ISupportInitialize)tabDetailControl).BeginInit();
            tabDetailControl.SuspendLayout();
            tabParameters.SuspendLayout();
            ((ISupportInitialize)groupControlParameters).BeginInit();
            groupControlParameters.SuspendLayout();
            ((ISupportInitialize)groupControlChannels).BeginInit();
            groupControlChannels.SuspendLayout();
            ((ISupportInitialize)chkParamEmail.Properties).BeginInit();
            ((ISupportInitialize)chkParamWhatsApp.Properties).BeginInit();
            ((ISupportInitialize)chkParamSms.Properties).BeginInit();
            ((ISupportInitialize)chkParamPopup.Properties).BeginInit();
            ((ISupportInitialize)chkParamInApp.Properties).BeginInit();
            ((ISupportInitialize)chkParamIsEnabled.Properties).BeginInit();
            ((ISupportInitialize)cboParamSeverity.Properties).BeginInit();
            ((ISupportInitialize)seParamThrottle.Properties).BeginInit();
            ((ISupportInitialize)lueParamStore.Properties).BeginInit();
            ((ISupportInitialize)lueParamNotificationType.Properties).BeginInit();
            ((ISupportInitialize)txtParamRuleName.Properties).BeginInit();
            tabTemplates.SuspendLayout();
            ((ISupportInitialize)splitContainerTemplates).BeginInit();
            splitContainerTemplates.Panel1.SuspendLayout();
            splitContainerTemplates.Panel2.SuspendLayout();
            splitContainerTemplates.SuspendLayout();
            ((ISupportInitialize)gC_Templates).BeginInit();
            ((ISupportInitialize)templateBindingSource).BeginInit();
            ((ISupportInitialize)gV_Templates).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditLanguage).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).BeginInit();
            ((ISupportInitialize)panelTemplateTop).BeginInit();
            panelTemplateTop.SuspendLayout();
            ((ISupportInitialize)chkFilterSelectedTypeOnly.Properties).BeginInit();
            ((ISupportInitialize)groupControlTemplateEditor).BeginInit();
            groupControlTemplateEditor.SuspendLayout();
            ((ISupportInitialize)meTemplateBody.Properties).BeginInit();
            ((ISupportInitialize)txtTemplateTitle.Properties).BeginInit();
            ((ISupportInitialize)chkTemplateIsEnabled.Properties).BeginInit();
            ((ISupportInitialize)cboTemplateLanguage.Properties).BeginInit();
            tabRecipients.SuspendLayout();
            ((ISupportInitialize)gC_RecipientRules).BeginInit();
            ((ISupportInitialize)recipientRuleBindingSource).BeginInit();
            ((ISupportInitialize)gV_RecipientRules).BeginInit();
            ((ISupportInitialize)repositoryItemCheckEditRecipient).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditRole).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditRecipientStore).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditRecipientNotificationType).BeginInit();
            ((ISupportInitialize)panelRecipientTop).BeginInit();
            panelRecipientTop.SuspendLayout();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("save", "image://svgimages/save/save.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("new", "image://svgimages/actions/add.svg");
            svgImageCollection1.Add("delete", "image://svgimages/actions/remove.svg");
            svgImageCollection1.Add("settings", "image://svgimages/dashboards/managedatasource.svg");
            svgImageCollection1.Add("template", "image://svgimages/richedit/inserttablecells.svg");
            svgImageCollection1.Add("recipients", "image://svgimages/icon builder/actions_user.svg");
            svgImageCollection1.Add("export", "image://svgimages/export/exporttoxlsx.svg");
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] {
                ribbonControl1.ExpandCollapseItem,
                bBI_Save,
                bBI_Refresh,
                bBI_New,
                bBI_Delete,
                bBI_NewTemplate,
                bBI_DeleteTemplate,
                bBI_NewRecipient,
                bBI_DeleteRecipient,
                bBI_ExportXlsx
            });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 10;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1260, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_Save
            // 
            bBI_Save.Caption = Resources.Common_Save;
            bBI_Save.Id = 1;
            bBI_Save.ImageOptions.SvgImage = svgImageCollection1["save"];
            bBI_Save.ItemShortcut = new BarShortcut(Keys.Control | Keys.S);
            bBI_Save.Name = "bBI_Save";
            bBI_Save.ItemClick += bBI_Save_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 2;
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
            bBI_Refresh.ItemShortcut = new BarShortcut(Keys.F5);
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_New
            // 
            bBI_New.Caption = Resources.Common_New;
            bBI_New.Id = 3;
            bBI_New.ImageOptions.SvgImage = svgImageCollection1["new"];
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_Delete
            // 
            bBI_Delete.Caption = Resources.Common_Delete;
            bBI_Delete.Id = 4;
            bBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_Delete.Name = "bBI_Delete";
            bBI_Delete.ItemClick += bBI_Delete_ItemClick;
            // 
            // bBI_NewTemplate
            // 
            bBI_NewTemplate.Caption = Resources.Common_New;
            bBI_NewTemplate.Id = 5;
            bBI_NewTemplate.ImageOptions.SvgImage = svgImageCollection1["new"];
            bBI_NewTemplate.Name = "bBI_NewTemplate";
            bBI_NewTemplate.ItemClick += bBI_NewTemplate_ItemClick;
            // 
            // bBI_DeleteTemplate
            // 
            bBI_DeleteTemplate.Caption = Resources.Common_Delete;
            bBI_DeleteTemplate.Id = 6;
            bBI_DeleteTemplate.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_DeleteTemplate.Name = "bBI_DeleteTemplate";
            bBI_DeleteTemplate.ItemClick += bBI_DeleteTemplate_ItemClick;
            // 
            // bBI_NewRecipient
            // 
            bBI_NewRecipient.Caption = Resources.Common_New;
            bBI_NewRecipient.Id = 7;
            bBI_NewRecipient.ImageOptions.SvgImage = svgImageCollection1["new"];
            bBI_NewRecipient.Name = "bBI_NewRecipient";
            bBI_NewRecipient.ItemClick += bBI_NewRecipient_ItemClick;
            // 
            // bBI_DeleteRecipient
            // 
            bBI_DeleteRecipient.Caption = Resources.Common_Delete;
            bBI_DeleteRecipient.Id = 8;
            bBI_DeleteRecipient.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_DeleteRecipient.Name = "bBI_DeleteRecipient";
            bBI_DeleteRecipient.ItemClick += bBI_DeleteRecipient_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_Export;
            bBI_ExportXlsx.Id = 9;
            bBI_ExportXlsx.ImageOptions.SvgImage = svgImageCollection1["export"];
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] {
                ribbonPageGroupOperations,
                ribbonPageGroupRules,
                ribbonPageGroupTemplates,
                ribbonPageGroupRecipients,
                ribbonPageGroupExport
            });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_NotificationRule_Title;
            // 
            // ribbonPageGroupOperations
            // 
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Save);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupOperations.Name = "ribbonPageGroupOperations";
            ribbonPageGroupOperations.Text = Resources.Form_NotificationRule_Data;
            // 
            // ribbonPageGroupRules
            // 
            ribbonPageGroupRules.ItemLinks.Add(bBI_New);
            ribbonPageGroupRules.ItemLinks.Add(bBI_Delete);
            ribbonPageGroupRules.Name = "ribbonPageGroupRules";
            ribbonPageGroupRules.Text = Resources.Form_NotificationRule_Rules;
            // 
            // ribbonPageGroupTemplates
            // 
            ribbonPageGroupTemplates.ItemLinks.Add(bBI_NewTemplate);
            ribbonPageGroupTemplates.ItemLinks.Add(bBI_DeleteTemplate);
            ribbonPageGroupTemplates.Name = "ribbonPageGroupTemplates";
            ribbonPageGroupTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            // 
            // ribbonPageGroupRecipients
            // 
            ribbonPageGroupRecipients.ItemLinks.Add(bBI_NewRecipient);
            ribbonPageGroupRecipients.ItemLinks.Add(bBI_DeleteRecipient);
            ribbonPageGroupRecipients.Name = "ribbonPageGroupRecipients";
            ribbonPageGroupRecipients.Text = Resources.Form_NotificationRecipientRule_Rules;
            // 
            // ribbonPageGroupExport
            // 
            ribbonPageGroupExport.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroupExport.Name = "ribbonPageGroupExport";
            ribbonPageGroupExport.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 716);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1260, 24);
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 158);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(groupControlRules);
            splitContainerMain.Panel1.Text = "Panel1";
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(tabDetailControl);
            splitContainerMain.Panel2.Controls.Add(panelHeader);
            splitContainerMain.Panel2.Text = "Panel2";
            splitContainerMain.Size = new Size(1260, 558);
            splitContainerMain.SplitterPosition = 360;
            splitContainerMain.TabIndex = 2;
            // 
            // groupControlRules
            // 
            groupControlRules.Controls.Add(gC_NotificationRules);
            groupControlRules.Dock = DockStyle.Fill;
            groupControlRules.Location = new Point(0, 0);
            groupControlRules.Name = "groupControlRules";
            groupControlRules.Size = new Size(360, 558);
            groupControlRules.TabIndex = 0;
            groupControlRules.Text = Resources.Form_NotificationRule_Rules;
            // 
            // gC_NotificationRules
            // 
            gC_NotificationRules.DataSource = notificationRuleBindingSource;
            gC_NotificationRules.Dock = DockStyle.Fill;
            gC_NotificationRules.MainView = gV_NotificationRules;
            gC_NotificationRules.MenuManager = ribbonControl1;
            gC_NotificationRules.Name = "gC_NotificationRules";
            gC_NotificationRules.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repositoryItemCheckEdit
            });
            gC_NotificationRules.Size = new Size(356, 532);
            gC_NotificationRules.TabIndex = 0;
            gC_NotificationRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_NotificationRules });
            gC_NotificationRules.ProcessGridKey += gC_NotificationRules_ProcessGridKey;
            // 
            // notificationRuleBindingSource
            // 
            notificationRuleBindingSource.DataSource = typeof(DcNotificationRule);
            // 
            // gV_NotificationRules
            // 
            gV_NotificationRules.Columns.AddRange(new GridColumn[] {
                colNotificationRuleId,
                colIsEnabled,
                colRuleName,
                colNotificationCategoryCode,
                colNotificationTypeCode,
                colStoreCode,
                colChannelCodes,
                colThrottleMinutes,
                colPopupMinSeverity
            });
            gV_NotificationRules.GridControl = gC_NotificationRules;
            gV_NotificationRules.Name = "gV_NotificationRules";
            gV_NotificationRules.OptionsBehavior.Editable = false;
            gV_NotificationRules.OptionsFind.AlwaysVisible = true;
            gV_NotificationRules.OptionsFind.FindDelay = 100;
            gV_NotificationRules.OptionsView.ShowAutoFilterRow = true;
            gV_NotificationRules.OptionsView.ShowFooter = true;
            gV_NotificationRules.OptionsView.ShowGroupPanel = true;
            gV_NotificationRules.FocusedRowChanged += gV_NotificationRules_FocusedRowChanged;
            gV_NotificationRules.RowCellStyle += gV_NotificationRules_RowCellStyle;
            gV_NotificationRules.PopupMenuShowing += gV_NotificationRules_PopupMenuShowing;
            gV_NotificationRules.CustomColumnDisplayText += gV_NotificationRules_CustomColumnDisplayText;
            // 
            // colNotificationRuleId
            // 
            colNotificationRuleId.Caption = Resources.Entity_NotificationRule_Id;
            colNotificationRuleId.FieldName = "NotificationRuleId";
            colNotificationRuleId.Name = "colNotificationRuleId";
            colNotificationRuleId.OptionsColumn.AllowEdit = false;
            colNotificationRuleId.Width = 60;
            // 
            // colIsEnabled
            // 
            colIsEnabled.Caption = Resources.Common_IsEnabled;
            colIsEnabled.ColumnEdit = repositoryItemCheckEdit;
            colIsEnabled.FieldName = "IsEnabled";
            colIsEnabled.Name = "colIsEnabled";
            colIsEnabled.OptionsColumn.AllowEdit = false;
            colIsEnabled.Visible = true;
            colIsEnabled.VisibleIndex = 0;
            colIsEnabled.Width = 50;
            // 
            // repositoryItemCheckEdit
            // 
            repositoryItemCheckEdit.AutoHeight = false;
            repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            // 
            // colRuleName
            // 
            colRuleName.Caption = Resources.Entity_NotificationRule_Name;
            colRuleName.FieldName = "RuleName";
            colRuleName.Name = "colRuleName";
            colRuleName.OptionsColumn.AllowEdit = false;
            colRuleName.Visible = true;
            colRuleName.VisibleIndex = 1;
            colRuleName.Width = 240;
            // 
            // colNotificationCategoryCode
            // 
            colNotificationCategoryCode.Caption = Resources.Entity_NotificationType_CategoryCode;
            colNotificationCategoryCode.FieldName = "DcNotificationType.CategoryCode";
            colNotificationCategoryCode.GroupIndex = 0;
            colNotificationCategoryCode.Name = "colNotificationCategoryCode";
            colNotificationCategoryCode.OptionsColumn.AllowEdit = false;
            colNotificationCategoryCode.Visible = true;
            colNotificationCategoryCode.VisibleIndex = 2;
            colNotificationCategoryCode.Width = 90;
            // 
            // colNotificationTypeCode
            // 
            colNotificationTypeCode.Caption = Resources.Entity_NotificationType;
            colNotificationTypeCode.FieldName = "NotificationTypeCode";
            colNotificationTypeCode.Name = "colNotificationTypeCode";
            colNotificationTypeCode.OptionsColumn.AllowEdit = false;
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.OptionsColumn.AllowEdit = false;
            // 
            // colChannelCodes
            // 
            colChannelCodes.Caption = Resources.Entity_NotificationRule_ChannelCodes;
            colChannelCodes.FieldName = "ChannelCodes";
            colChannelCodes.Name = "colChannelCodes";
            colChannelCodes.OptionsColumn.AllowEdit = false;
            // 
            // colThrottleMinutes
            // 
            colThrottleMinutes.Caption = Resources.Entity_NotificationRule_ThrottleMinutes;
            colThrottleMinutes.FieldName = "ThrottleMinutes";
            colThrottleMinutes.Name = "colThrottleMinutes";
            colThrottleMinutes.OptionsColumn.AllowEdit = false;
            // 
            // colPopupMinSeverity
            // 
            colPopupMinSeverity.Caption = Resources.Entity_NotificationRule_PopupMinSeverity;
            colPopupMinSeverity.FieldName = "PopupMinSeverity";
            colPopupMinSeverity.Name = "colPopupMinSeverity";
            colPopupMinSeverity.OptionsColumn.AllowEdit = false;
            // 
            // panelHeader
            // 
            panelHeader.BorderStyle = BorderStyles.NoBorder;
            panelHeader.Controls.Add(lblSelectedRuleSubtitle);
            panelHeader.Controls.Add(lblSelectedRuleTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(12, 8, 12, 6);
            panelHeader.Size = new Size(890, 52);
            panelHeader.TabIndex = 0;
            // 
            // lblSelectedRuleSubtitle
            // 
            lblSelectedRuleSubtitle.Appearance.ForeColor = Color.Gray;
            lblSelectedRuleSubtitle.Appearance.Options.UseForeColor = true;
            lblSelectedRuleSubtitle.Dock = DockStyle.Top;
            lblSelectedRuleSubtitle.Location = new Point(12, 28);
            lblSelectedRuleSubtitle.Name = "lblSelectedRuleSubtitle";
            lblSelectedRuleSubtitle.Size = new Size(0, 13);
            lblSelectedRuleSubtitle.TabIndex = 1;
            // 
            // lblSelectedRuleTitle
            // 
            lblSelectedRuleTitle.Appearance.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSelectedRuleTitle.Appearance.Options.UseFont = true;
            lblSelectedRuleTitle.Dock = DockStyle.Top;
            lblSelectedRuleTitle.Location = new Point(12, 8);
            lblSelectedRuleTitle.Name = "lblSelectedRuleTitle";
            lblSelectedRuleTitle.Size = new Size(180, 20);
            lblSelectedRuleTitle.TabIndex = 0;
            lblSelectedRuleTitle.Text = Resources.Form_NotificationRule;
            // 
            // tabDetailControl
            // 
            tabDetailControl.Dock = DockStyle.Fill;
            tabDetailControl.Location = new Point(0, 52);
            tabDetailControl.Name = "tabDetailControl";
            tabDetailControl.SelectedTabPage = tabParameters;
            tabDetailControl.Size = new Size(890, 506);
            tabDetailControl.TabPages.AddRange(new XtraTabPage[] {
                tabParameters,
                tabTemplates,
                tabRecipients
            });
            tabDetailControl.TabIndex = 1;
            // 
            // tabParameters
            // 
            tabParameters.Controls.Add(groupControlParameters);
            tabParameters.ImageOptions.SvgImage = svgImageCollection1["settings"];
            tabParameters.Name = "tabParameters";
            tabParameters.Size = new Size(888, 478);
            tabParameters.Text = Resources.Form_NotificationRule_Parameters;
            // 
            // groupControlParameters
            // 
            groupControlParameters.Controls.Add(groupControlChannels);
            groupControlParameters.Controls.Add(chkParamIsEnabled);
            groupControlParameters.Controls.Add(cboParamSeverity);
            groupControlParameters.Controls.Add(lblParamSeverity);
            groupControlParameters.Controls.Add(seParamThrottle);
            groupControlParameters.Controls.Add(lblParamThrottle);
            groupControlParameters.Controls.Add(lueParamStore);
            groupControlParameters.Controls.Add(lblParamStore);
            groupControlParameters.Controls.Add(lueParamNotificationType);
            groupControlParameters.Controls.Add(lblParamNotificationType);
            groupControlParameters.Controls.Add(txtParamRuleName);
            groupControlParameters.Controls.Add(lblParamRuleName);
            groupControlParameters.Dock = DockStyle.Fill;
            groupControlParameters.Location = new Point(0, 0);
            groupControlParameters.Name = "groupControlParameters";
            groupControlParameters.Padding = new Padding(16);
            groupControlParameters.Size = new Size(888, 478);
            groupControlParameters.TabIndex = 0;
            groupControlParameters.Text = Resources.Form_NotificationRule_Parameters;
            // 
            // groupControlChannels
            // 
            groupControlChannels.Controls.Add(chkParamEmail);
            groupControlChannels.Controls.Add(chkParamWhatsApp);
            groupControlChannels.Controls.Add(chkParamSms);
            groupControlChannels.Controls.Add(chkParamPopup);
            groupControlChannels.Controls.Add(chkParamInApp);
            groupControlChannels.Location = new Point(24, 150);
            groupControlChannels.Name = "groupControlChannels";
            groupControlChannels.Size = new Size(620, 75);
            groupControlChannels.TabIndex = 8;
            groupControlChannels.Text = Resources.Entity_NotificationRule_ChannelCodes;
            // 
            // chkParamEmail
            // 
            chkParamEmail.Location = new Point(480, 36);
            chkParamEmail.Name = "chkParamEmail";
            chkParamEmail.Properties.Caption = Resources.Form_NotificationRule_Channel_Email;
            chkParamEmail.Size = new Size(85, 20);
            chkParamEmail.TabIndex = 4;
            chkParamEmail.CheckedChanged += chkParamChannel_CheckedChanged;
            // 
            // chkParamWhatsApp
            // 
            chkParamWhatsApp.Location = new Point(365, 36);
            chkParamWhatsApp.Name = "chkParamWhatsApp";
            chkParamWhatsApp.Properties.Caption = Resources.Form_NotificationRule_Channel_WhatsApp;
            chkParamWhatsApp.Size = new Size(95, 20);
            chkParamWhatsApp.TabIndex = 3;
            chkParamWhatsApp.CheckedChanged += chkParamChannel_CheckedChanged;
            // 
            // chkParamSms
            // 
            chkParamSms.Location = new Point(275, 36);
            chkParamSms.Name = "chkParamSms";
            chkParamSms.Properties.Caption = Resources.Form_NotificationRule_Channel_SMS;
            chkParamSms.Size = new Size(75, 20);
            chkParamSms.TabIndex = 2;
            chkParamSms.CheckedChanged += chkParamChannel_CheckedChanged;
            // 
            // chkParamPopup
            // 
            chkParamPopup.Location = new Point(160, 36);
            chkParamPopup.Name = "chkParamPopup";
            chkParamPopup.Properties.Caption = Resources.Form_NotificationRule_Channel_Popup;
            chkParamPopup.Size = new Size(95, 20);
            chkParamPopup.TabIndex = 1;
            chkParamPopup.CheckedChanged += chkParamChannel_CheckedChanged;
            // 
            // chkParamInApp
            // 
            chkParamInApp.Location = new Point(20, 36);
            chkParamInApp.Name = "chkParamInApp";
            chkParamInApp.Properties.Caption = Resources.Form_NotificationRule_Channel_InApp;
            chkParamInApp.Size = new Size(125, 20);
            chkParamInApp.TabIndex = 0;
            chkParamInApp.CheckedChanged += chkParamChannel_CheckedChanged;
            // 
            // chkParamIsEnabled
            // 
            chkParamIsEnabled.Location = new Point(490, 105);
            chkParamIsEnabled.Name = "chkParamIsEnabled";
            chkParamIsEnabled.Properties.Caption = Resources.Common_IsEnabled;
            chkParamIsEnabled.Size = new Size(150, 20);
            chkParamIsEnabled.TabIndex = 7;
            chkParamIsEnabled.CheckedChanged += chkParamIsEnabled_CheckedChanged;
            // 
            // cboParamSeverity
            // 
            cboParamSeverity.Location = new Point(330, 255);
            cboParamSeverity.Name = "cboParamSeverity";
            cboParamSeverity.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            cboParamSeverity.Properties.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Info, NotificationSeverities.Info),
                new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Warning, NotificationSeverities.Warning),
                new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_High, NotificationSeverities.High),
                new ImageComboBoxItem(Resources.Form_NotificationRule_Severity_Critical, NotificationSeverities.Critical)
            });
            cboParamSeverity.Size = new Size(314, 20);
            cboParamSeverity.TabIndex = 12;
            cboParamSeverity.SelectedIndexChanged += cboParamSeverity_SelectedIndexChanged;
            // 
            // lblParamSeverity
            // 
            lblParamSeverity.Location = new Point(330, 237);
            lblParamSeverity.Name = "lblParamSeverity";
            lblParamSeverity.Size = new Size(130, 13);
            lblParamSeverity.TabIndex = 11;
            lblParamSeverity.Text = Resources.Entity_NotificationRule_PopupMinSeverity;
            // 
            // seParamThrottle
            // 
            seParamThrottle.EditValue = new decimal(new int[] { 60, 0, 0, 0 });
            seParamThrottle.Location = new Point(24, 255);
            seParamThrottle.Name = "seParamThrottle";
            seParamThrottle.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            seParamThrottle.Properties.IsFloatValue = false;
            seParamThrottle.Properties.MaskSettings.Set("mask", "N0");
            seParamThrottle.Properties.MaxValue = new decimal(new int[] { 525600, 0, 0, 0 });
            seParamThrottle.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            seParamThrottle.Size = new Size(270, 20);
            seParamThrottle.TabIndex = 10;
            seParamThrottle.ValueChanged += seParamThrottle_ValueChanged;
            // 
            // lblParamThrottle
            // 
            lblParamThrottle.Location = new Point(24, 237);
            lblParamThrottle.Name = "lblParamThrottle";
            lblParamThrottle.Size = new Size(125, 13);
            lblParamThrottle.TabIndex = 9;
            lblParamThrottle.Text = Resources.Entity_NotificationRule_ThrottleMinutes;
            // 
            // lueParamStore
            // 
            lueParamStore.Location = new Point(24, 105);
            lueParamStore.Name = "lueParamStore";
            lueParamStore.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            lueParamStore.Properties.NullText = Resources.Form_NotificationRule_AllStores;
            lueParamStore.Size = new Size(430, 20);
            lueParamStore.TabIndex = 6;
            lueParamStore.EditValueChanged += lueParamStore_EditValueChanged;
            // 
            // lblParamStore
            // 
            lblParamStore.Location = new Point(24, 87);
            lblParamStore.Name = "lblParamStore";
            lblParamStore.Size = new Size(69, 13);
            lblParamStore.TabIndex = 5;
            lblParamStore.Text = Resources.Entity_CurrAcc_StoreCode;
            // 
            // lueParamNotificationType
            // 
            lueParamNotificationType.Location = new Point(350, 52);
            lueParamNotificationType.Name = "lueParamNotificationType";
            lueParamNotificationType.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            lueParamNotificationType.Properties.NullText = "";
            lueParamNotificationType.Properties.SearchMode = SearchMode.AutoSearch;
            lueParamNotificationType.Size = new Size(294, 20);
            lueParamNotificationType.TabIndex = 3;
            lueParamNotificationType.EditValueChanged += lueParamNotificationType_EditValueChanged;
            // 
            // lblParamNotificationType
            // 
            lblParamNotificationType.Location = new Point(350, 34);
            lblParamNotificationType.Name = "lblParamNotificationType";
            lblParamNotificationType.Size = new Size(59, 13);
            lblParamNotificationType.TabIndex = 2;
            lblParamNotificationType.Text = Resources.Entity_NotificationType;
            // 
            // txtParamRuleName
            // 
            txtParamRuleName.Location = new Point(24, 52);
            txtParamRuleName.Name = "txtParamRuleName";
            txtParamRuleName.Size = new Size(300, 20);
            txtParamRuleName.TabIndex = 1;
            txtParamRuleName.TextChanged += txtParamRuleName_TextChanged;
            // 
            // lblParamRuleName
            // 
            lblParamRuleName.Location = new Point(24, 34);
            lblParamRuleName.Name = "lblParamRuleName";
            lblParamRuleName.Size = new Size(67, 13);
            lblParamRuleName.TabIndex = 0;
            lblParamRuleName.Text = Resources.Entity_NotificationRule_Name;
            // 
            // tabTemplates
            // 
            tabTemplates.Controls.Add(splitContainerTemplates);
            tabTemplates.ImageOptions.SvgImage = svgImageCollection1["template"];
            tabTemplates.Name = "tabTemplates";
            tabTemplates.Size = new Size(888, 478);
            tabTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            // 
            // splitContainerTemplates
            // 
            splitContainerTemplates.Dock = DockStyle.Fill;
            splitContainerTemplates.Horizontal = false;
            splitContainerTemplates.Location = new Point(0, 0);
            splitContainerTemplates.Name = "splitContainerTemplates";
            // 
            // splitContainerTemplates.Panel1
            // 
            splitContainerTemplates.Panel1.Controls.Add(gC_Templates);
            splitContainerTemplates.Panel1.Controls.Add(panelTemplateTop);
            splitContainerTemplates.Panel1.Text = "Panel1";
            // 
            // splitContainerTemplates.Panel2
            // 
            splitContainerTemplates.Panel2.Controls.Add(groupControlTemplateEditor);
            splitContainerTemplates.Panel2.Text = "Panel2";
            splitContainerTemplates.Size = new Size(888, 478);
            splitContainerTemplates.SplitterPosition = 200;
            splitContainerTemplates.TabIndex = 0;
            // 
            // gC_Templates
            // 
            gC_Templates.DataSource = templateBindingSource;
            gC_Templates.Dock = DockStyle.Fill;
            gC_Templates.MainView = gV_Templates;
            gC_Templates.MenuManager = ribbonControl1;
            gC_Templates.Name = "gC_Templates";
            gC_Templates.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repositoryItemCheckEdit,
                repositoryItemLookUpEditLanguage,
                repositoryItemLookUpEditNotificationType
            });
            gC_Templates.Size = new Size(888, 164);
            gC_Templates.TabIndex = 1;
            gC_Templates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Templates });
            gC_Templates.ProcessGridKey += gC_Templates_ProcessGridKey;
            // 
            // templateBindingSource
            // 
            templateBindingSource.DataSource = typeof(DcNotificationTemplate);
            // 
            // gV_Templates
            // 
            gV_Templates.Columns.AddRange(new GridColumn[] {
                colTemplateIsEnabled,
                colTemplateLanguageCode,
                colTemplateNotificationTypeCode,
                colTemplateTitle,
                colTemplateBody
            });
            gV_Templates.GridControl = gC_Templates;
            gV_Templates.Name = "gV_Templates";
            gV_Templates.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
            gV_Templates.OptionsView.ShowAutoFilterRow = true;
            gV_Templates.OptionsView.ShowGroupPanel = false;
            gV_Templates.FocusedRowChanged += gV_Templates_FocusedRowChanged;
            gV_Templates.CellValueChanged += gV_Templates_CellValueChanged;
            gV_Templates.RowCellStyle += gV_Templates_RowCellStyle;
            // 
            // colTemplateIsEnabled
            // 
            colTemplateIsEnabled.Caption = Resources.Common_IsEnabled;
            colTemplateIsEnabled.ColumnEdit = repositoryItemCheckEdit;
            colTemplateIsEnabled.FieldName = "IsEnabled";
            colTemplateIsEnabled.Name = "colTemplateIsEnabled";
            colTemplateIsEnabled.Visible = true;
            colTemplateIsEnabled.VisibleIndex = 0;
            colTemplateIsEnabled.Width = 45;
            // 
            // colTemplateLanguageCode
            // 
            colTemplateLanguageCode.Caption = Resources.Entity_NotificationTemplate_LanguageCode;
            colTemplateLanguageCode.ColumnEdit = repositoryItemLookUpEditLanguage;
            colTemplateLanguageCode.FieldName = "LanguageCode";
            colTemplateLanguageCode.Name = "colTemplateLanguageCode";
            colTemplateLanguageCode.Visible = true;
            colTemplateLanguageCode.VisibleIndex = 1;
            colTemplateLanguageCode.Width = 70;
            // 
            // repositoryItemLookUpEditLanguage
            // 
            repositoryItemLookUpEditLanguage.AutoHeight = false;
            repositoryItemLookUpEditLanguage.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditLanguage.Name = "repositoryItemLookUpEditLanguage";
            repositoryItemLookUpEditLanguage.NullText = "";
            // 
            // colTemplateNotificationTypeCode
            // 
            colTemplateNotificationTypeCode.Caption = Resources.Entity_NotificationType;
            colTemplateNotificationTypeCode.ColumnEdit = repositoryItemLookUpEditNotificationType;
            colTemplateNotificationTypeCode.FieldName = "NotificationTypeCode";
            colTemplateNotificationTypeCode.Name = "colTemplateNotificationTypeCode";
            colTemplateNotificationTypeCode.Visible = true;
            colTemplateNotificationTypeCode.VisibleIndex = 2;
            colTemplateNotificationTypeCode.Width = 120;
            // 
            // repositoryItemLookUpEditNotificationType
            // 
            repositoryItemLookUpEditNotificationType.AutoHeight = false;
            repositoryItemLookUpEditNotificationType.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditNotificationType.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcNotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedCategory), Resources.Entity_NotificationType_CategoryCode),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedDescription), Resources.Entity_NotificationType_Desc)
            });
            repositoryItemLookUpEditNotificationType.DisplayMember = nameof(DcNotificationType.LocalizedDescription);
            repositoryItemLookUpEditNotificationType.Name = "repositoryItemLookUpEditNotificationType";
            repositoryItemLookUpEditNotificationType.NullText = "";
            repositoryItemLookUpEditNotificationType.SearchMode = SearchMode.AutoSearch;
            repositoryItemLookUpEditNotificationType.ValueMember = nameof(DcNotificationType.NotificationTypeCode);
            // 
            // colTemplateTitle
            // 
            colTemplateTitle.Caption = Resources.Entity_NotificationTemplate_TitleTemplate;
            colTemplateTitle.FieldName = "TitleTemplate";
            colTemplateTitle.Name = "colTemplateTitle";
            colTemplateTitle.Visible = true;
            colTemplateTitle.VisibleIndex = 3;
            colTemplateTitle.Width = 180;
            // 
            // colTemplateBody
            // 
            colTemplateBody.Caption = Resources.Entity_NotificationTemplate_BodyTemplate;
            colTemplateBody.FieldName = "BodyTemplate";
            colTemplateBody.Name = "colTemplateBody";
            colTemplateBody.Visible = true;
            colTemplateBody.VisibleIndex = 4;
            colTemplateBody.Width = 300;
            // 
            // panelTemplateTop
            // 
            panelTemplateTop.BorderStyle = BorderStyles.NoBorder;
            panelTemplateTop.Controls.Add(btnDeleteTemplate);
            panelTemplateTop.Controls.Add(btnNewTemplate);
            panelTemplateTop.Controls.Add(chkFilterSelectedTypeOnly);
            panelTemplateTop.Dock = DockStyle.Top;
            panelTemplateTop.Location = new Point(0, 0);
            panelTemplateTop.Name = "panelTemplateTop";
            panelTemplateTop.Padding = new Padding(6, 4, 6, 4);
            panelTemplateTop.Size = new Size(888, 36);
            panelTemplateTop.TabIndex = 0;
            // 
            // btnDeleteTemplate
            // 
            btnDeleteTemplate.Dock = DockStyle.Right;
            btnDeleteTemplate.ImageOptions.SvgImage = svgImageCollection1["delete"];
            btnDeleteTemplate.ImageOptions.SvgImageSize = new Size(16, 16);
            btnDeleteTemplate.Location = new Point(788, 4);
            btnDeleteTemplate.Name = "btnDeleteTemplate";
            btnDeleteTemplate.Size = new Size(94, 28);
            btnDeleteTemplate.TabIndex = 2;
            btnDeleteTemplate.Text = Resources.Common_Delete;
            btnDeleteTemplate.Click += btnDeleteTemplate_Click;
            // 
            // btnNewTemplate
            // 
            btnNewTemplate.Dock = DockStyle.Right;
            btnNewTemplate.ImageOptions.SvgImage = svgImageCollection1["new"];
            btnNewTemplate.ImageOptions.SvgImageSize = new Size(16, 16);
            btnNewTemplate.Location = new Point(694, 4);
            btnNewTemplate.Name = "btnNewTemplate";
            btnNewTemplate.Size = new Size(94, 28);
            btnNewTemplate.TabIndex = 1;
            btnNewTemplate.Text = Resources.Common_New;
            btnNewTemplate.Click += btnNewTemplate_Click;
            // 
            // chkFilterSelectedTypeOnly
            // 
            chkFilterSelectedTypeOnly.Dock = DockStyle.Left;
            chkFilterSelectedTypeOnly.EditValue = true;
            chkFilterSelectedTypeOnly.Location = new Point(6, 4);
            chkFilterSelectedTypeOnly.Name = "chkFilterSelectedTypeOnly";
            chkFilterSelectedTypeOnly.Properties.Caption = Resources.Form_NotificationRule_FilterCurrentOnly;
            chkFilterSelectedTypeOnly.Size = new Size(260, 28);
            chkFilterSelectedTypeOnly.TabIndex = 0;
            chkFilterSelectedTypeOnly.CheckedChanged += chkFilterSelectedTypeOnly_CheckedChanged;
            // 
            // groupControlTemplateEditor
            // 
            groupControlTemplateEditor.Controls.Add(panelPlaceholders);
            groupControlTemplateEditor.Controls.Add(lblPlaceholdersTitle);
            groupControlTemplateEditor.Controls.Add(meTemplateBody);
            groupControlTemplateEditor.Controls.Add(lblTemplateBody);
            groupControlTemplateEditor.Controls.Add(txtTemplateTitle);
            groupControlTemplateEditor.Controls.Add(lblTemplateTitle);
            groupControlTemplateEditor.Controls.Add(lblCharCount);
            groupControlTemplateEditor.Controls.Add(chkTemplateIsEnabled);
            groupControlTemplateEditor.Controls.Add(cboTemplateLanguage);
            groupControlTemplateEditor.Controls.Add(lblTemplateLanguage);
            groupControlTemplateEditor.Dock = DockStyle.Fill;
            groupControlTemplateEditor.Location = new Point(0, 0);
            groupControlTemplateEditor.Name = "groupControlTemplateEditor";
            groupControlTemplateEditor.Padding = new Padding(8);
            groupControlTemplateEditor.Size = new Size(888, 268);
            groupControlTemplateEditor.TabIndex = 0;
            groupControlTemplateEditor.Text = Resources.Form_NotificationRule_TemplateEditor;
            // 
            // panelPlaceholders
            // 
            panelPlaceholders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPlaceholders.AutoScroll = true;
            panelPlaceholders.Location = new Point(14, 218);
            panelPlaceholders.Name = "panelPlaceholders";
            panelPlaceholders.Size = new Size(860, 42);
            panelPlaceholders.TabIndex = 9;
            // 
            // lblPlaceholdersTitle
            // 
            lblPlaceholdersTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPlaceholdersTitle.Appearance.ForeColor = Color.Gray;
            lblPlaceholdersTitle.Appearance.Options.UseForeColor = true;
            lblPlaceholdersTitle.Location = new Point(14, 202);
            lblPlaceholdersTitle.Name = "lblPlaceholdersTitle";
            lblPlaceholdersTitle.Size = new Size(210, 13);
            lblPlaceholdersTitle.TabIndex = 8;
            lblPlaceholdersTitle.Text = Resources.Form_NotificationRule_Placeholders;
            // 
            // meTemplateBody
            // 
            meTemplateBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            meTemplateBody.Location = new Point(14, 114);
            meTemplateBody.Name = "meTemplateBody";
            meTemplateBody.Properties.ScrollBars = ScrollBars.Vertical;
            meTemplateBody.Size = new Size(860, 84);
            meTemplateBody.TabIndex = 7;
            meTemplateBody.TextChanged += meTemplateBody_TextChanged;
            // 
            // lblTemplateBody
            // 
            lblTemplateBody.Location = new Point(14, 96);
            lblTemplateBody.Name = "lblTemplateBody";
            lblTemplateBody.Size = new Size(62, 13);
            lblTemplateBody.TabIndex = 6;
            lblTemplateBody.Text = Resources.Entity_NotificationTemplate_BodyTemplate;
            // 
            // txtTemplateTitle
            // 
            txtTemplateTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTemplateTitle.Location = new Point(14, 70);
            txtTemplateTitle.Name = "txtTemplateTitle";
            txtTemplateTitle.Size = new Size(860, 20);
            txtTemplateTitle.TabIndex = 5;
            txtTemplateTitle.TextChanged += txtTemplateTitle_TextChanged;
            // 
            // lblTemplateTitle
            // 
            lblTemplateTitle.Location = new Point(14, 52);
            lblTemplateTitle.Name = "lblTemplateTitle";
            lblTemplateTitle.Size = new Size(67, 13);
            lblTemplateTitle.TabIndex = 4;
            lblTemplateTitle.Text = Resources.Entity_NotificationTemplate_TitleTemplate;
            // 
            // lblCharCount
            // 
            lblCharCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCharCount.Appearance.ForeColor = Color.DimGray;
            lblCharCount.Appearance.Options.UseForeColor = true;
            lblCharCount.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            lblCharCount.AutoSizeMode = LabelAutoSizeMode.None;
            lblCharCount.Location = new Point(674, 29);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Size = new Size(200, 18);
            lblCharCount.TabIndex = 3;
            lblCharCount.Text = "0 simvol | 0 SMS";
            // 
            // chkTemplateIsEnabled
            // 
            chkTemplateIsEnabled.Location = new Point(164, 27);
            chkTemplateIsEnabled.Name = "chkTemplateIsEnabled";
            chkTemplateIsEnabled.Properties.Caption = Resources.Common_IsEnabled;
            chkTemplateIsEnabled.Size = new Size(90, 20);
            chkTemplateIsEnabled.TabIndex = 2;
            chkTemplateIsEnabled.CheckedChanged += chkTemplateIsEnabled_CheckedChanged;
            // 
            // cboTemplateLanguage
            // 
            cboTemplateLanguage.Location = new Point(48, 27);
            cboTemplateLanguage.Name = "cboTemplateLanguage";
            cboTemplateLanguage.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            cboTemplateLanguage.Properties.Items.AddRange(new object[] { "az", "en", "ru" });
            cboTemplateLanguage.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboTemplateLanguage.Size = new Size(95, 20);
            cboTemplateLanguage.TabIndex = 1;
            cboTemplateLanguage.SelectedIndexChanged += cboTemplateLanguage_SelectedIndexChanged;
            // 
            // lblTemplateLanguage
            // 
            lblTemplateLanguage.Location = new Point(14, 30);
            lblTemplateLanguage.Name = "lblTemplateLanguage";
            lblTemplateLanguage.Size = new Size(18, 13);
            lblTemplateLanguage.TabIndex = 0;
            lblTemplateLanguage.Text = Resources.Entity_NotificationTemplate_LanguageCode;
            // 
            // tabRecipients
            // 
            tabRecipients.Controls.Add(gC_RecipientRules);
            tabRecipients.Controls.Add(panelRecipientTop);
            tabRecipients.ImageOptions.SvgImage = svgImageCollection1["recipients"];
            tabRecipients.Name = "tabRecipients";
            tabRecipients.Size = new Size(888, 478);
            tabRecipients.Text = Resources.Form_NotificationRecipientRule_Rules;
            // 
            // gC_RecipientRules
            // 
            gC_RecipientRules.DataSource = recipientRuleBindingSource;
            gC_RecipientRules.Dock = DockStyle.Fill;
            gC_RecipientRules.MainView = gV_RecipientRules;
            gC_RecipientRules.MenuManager = ribbonControl1;
            gC_RecipientRules.Name = "gC_RecipientRules";
            gC_RecipientRules.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repositoryItemCheckEditRecipient,
                repositoryItemLookUpEditRole,
                repositoryItemLookUpEditRecipientStore,
                repositoryItemLookUpEditRecipientNotificationType
            });
            gC_RecipientRules.Size = new Size(888, 442);
            gC_RecipientRules.TabIndex = 1;
            gC_RecipientRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_RecipientRules });
            gC_RecipientRules.ProcessGridKey += gC_RecipientRules_ProcessGridKey;
            // 
            // recipientRuleBindingSource
            // 
            recipientRuleBindingSource.DataSource = typeof(DcNotificationRecipientRule);
            // 
            // gV_RecipientRules
            // 
            gV_RecipientRules.Columns.AddRange(new GridColumn[] {
                colRecipientIsEnabled,
                colRecipientRoleCode,
                colRecipientStoreCode,
                colRecipientNotificationTypeCode
            });
            gV_RecipientRules.GridControl = gC_RecipientRules;
            gV_RecipientRules.Name = "gV_RecipientRules";
            gV_RecipientRules.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
            gV_RecipientRules.OptionsView.ShowAutoFilterRow = true;
            gV_RecipientRules.OptionsView.ShowGroupPanel = false;
            gV_RecipientRules.RowCellStyle += gV_RecipientRules_RowCellStyle;
            gV_RecipientRules.ValidateRow += gV_RecipientRules_ValidateRow;
            gV_RecipientRules.InvalidRowException += gV_RecipientRules_InvalidRowException;
            // 
            // colRecipientIsEnabled
            // 
            colRecipientIsEnabled.Caption = Resources.Common_IsEnabled;
            colRecipientIsEnabled.ColumnEdit = repositoryItemCheckEditRecipient;
            colRecipientIsEnabled.FieldName = "IsEnabled";
            colRecipientIsEnabled.Name = "colRecipientIsEnabled";
            colRecipientIsEnabled.Visible = true;
            colRecipientIsEnabled.VisibleIndex = 0;
            colRecipientIsEnabled.Width = 50;
            // 
            // repositoryItemCheckEditRecipient
            // 
            repositoryItemCheckEditRecipient.AutoHeight = false;
            repositoryItemCheckEditRecipient.Name = "repositoryItemCheckEditRecipient";
            // 
            // colRecipientRoleCode
            // 
            colRecipientRoleCode.Caption = Resources.Entity_Role;
            colRecipientRoleCode.ColumnEdit = repositoryItemLookUpEditRole;
            colRecipientRoleCode.FieldName = "RoleCode";
            colRecipientRoleCode.Name = "colRecipientRoleCode";
            colRecipientRoleCode.Visible = true;
            colRecipientRoleCode.VisibleIndex = 1;
            colRecipientRoleCode.Width = 150;
            // 
            // repositoryItemLookUpEditRole
            // 
            repositoryItemLookUpEditRole.AutoHeight = false;
            repositoryItemLookUpEditRole.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditRole.Name = "repositoryItemLookUpEditRole";
            repositoryItemLookUpEditRole.NullText = "";
            repositoryItemLookUpEditRole.SearchMode = SearchMode.AutoSearch;
            // 
            // colRecipientStoreCode
            // 
            colRecipientStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colRecipientStoreCode.ColumnEdit = repositoryItemLookUpEditRecipientStore;
            colRecipientStoreCode.FieldName = "StoreCode";
            colRecipientStoreCode.Name = "colRecipientStoreCode";
            colRecipientStoreCode.Visible = true;
            colRecipientStoreCode.VisibleIndex = 2;
            colRecipientStoreCode.Width = 150;
            // 
            // repositoryItemLookUpEditRecipientStore
            // 
            repositoryItemLookUpEditRecipientStore.AutoHeight = false;
            repositoryItemLookUpEditRecipientStore.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditRecipientStore.Name = "repositoryItemLookUpEditRecipientStore";
            repositoryItemLookUpEditRecipientStore.NullText = Resources.Form_NotificationRecipientRule_AllStores;
            repositoryItemLookUpEditRecipientStore.SearchMode = SearchMode.AutoSearch;
            // 
            // colRecipientNotificationTypeCode
            // 
            colRecipientNotificationTypeCode.Caption = Resources.Entity_NotificationType;
            colRecipientNotificationTypeCode.ColumnEdit = repositoryItemLookUpEditRecipientNotificationType;
            colRecipientNotificationTypeCode.FieldName = "NotificationTypeCode";
            colRecipientNotificationTypeCode.Name = "colRecipientNotificationTypeCode";
            colRecipientNotificationTypeCode.Visible = true;
            colRecipientNotificationTypeCode.VisibleIndex = 3;
            colRecipientNotificationTypeCode.Width = 150;
            // 
            // repositoryItemLookUpEditRecipientNotificationType
            // 
            repositoryItemLookUpEditRecipientNotificationType.AutoHeight = false;
            repositoryItemLookUpEditRecipientNotificationType.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemLookUpEditRecipientNotificationType.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcNotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedCategory), Resources.Entity_NotificationType_CategoryCode),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedDescription), Resources.Entity_NotificationType_Desc)
            });
            repositoryItemLookUpEditRecipientNotificationType.DisplayMember = nameof(DcNotificationType.LocalizedDescription);
            repositoryItemLookUpEditRecipientNotificationType.Name = "repositoryItemLookUpEditRecipientNotificationType";
            repositoryItemLookUpEditRecipientNotificationType.NullText = "";
            repositoryItemLookUpEditRecipientNotificationType.SearchMode = SearchMode.AutoSearch;
            repositoryItemLookUpEditRecipientNotificationType.ValueMember = nameof(DcNotificationType.NotificationTypeCode);
            // 
            // panelRecipientTop
            // 
            panelRecipientTop.BorderStyle = BorderStyles.NoBorder;
            panelRecipientTop.Controls.Add(btnDeleteRecipient);
            panelRecipientTop.Controls.Add(btnNewRecipient);
            panelRecipientTop.Dock = DockStyle.Top;
            panelRecipientTop.Location = new Point(0, 0);
            panelRecipientTop.Name = "panelRecipientTop";
            panelRecipientTop.Padding = new Padding(6, 4, 6, 4);
            panelRecipientTop.Size = new Size(888, 36);
            panelRecipientTop.TabIndex = 0;
            // 
            // btnDeleteRecipient
            // 
            btnDeleteRecipient.Dock = DockStyle.Right;
            btnDeleteRecipient.ImageOptions.SvgImage = svgImageCollection1["delete"];
            btnDeleteRecipient.ImageOptions.SvgImageSize = new Size(16, 16);
            btnDeleteRecipient.Location = new Point(788, 4);
            btnDeleteRecipient.Name = "btnDeleteRecipient";
            btnDeleteRecipient.Size = new Size(94, 28);
            btnDeleteRecipient.TabIndex = 1;
            btnDeleteRecipient.Text = Resources.Common_Delete;
            btnDeleteRecipient.Click += btnDeleteRecipient_Click;
            // 
            // btnNewRecipient
            // 
            btnNewRecipient.Dock = DockStyle.Right;
            btnNewRecipient.ImageOptions.SvgImage = svgImageCollection1["new"];
            btnNewRecipient.ImageOptions.SvgImageSize = new Size(16, 16);
            btnNewRecipient.Location = new Point(694, 4);
            btnNewRecipient.Name = "btnNewRecipient";
            btnNewRecipient.Size = new Size(94, 28);
            btnNewRecipient.TabIndex = 0;
            btnNewRecipient.Text = Resources.Common_New;
            btnNewRecipient.Click += btnNewRecipient_Click;
            // 
            // FormNotificationRule
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 740);
            Controls.Add(splitContainerMain);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormNotificationRule";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_NotificationRule_Title;
            FormClosed += FormNotificationRule_FormClosed;
            Load += FormNotificationRule_Load;
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)splitContainerMain.Panel1).EndInit();
            splitContainerMain.Panel1.ResumeLayout(false);
            ((ISupportInitialize)splitContainerMain.Panel2).EndInit();
            splitContainerMain.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((ISupportInitialize)groupControlRules).EndInit();
            groupControlRules.ResumeLayout(false);
            ((ISupportInitialize)gC_NotificationRules).EndInit();
            ((ISupportInitialize)notificationRuleBindingSource).EndInit();
            ((ISupportInitialize)gV_NotificationRules).EndInit();
            ((ISupportInitialize)repositoryItemCheckEdit).EndInit();
            ((ISupportInitialize)panelHeader).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((ISupportInitialize)tabDetailControl).EndInit();
            tabDetailControl.ResumeLayout(false);
            tabParameters.ResumeLayout(false);
            ((ISupportInitialize)groupControlParameters).EndInit();
            groupControlParameters.ResumeLayout(false);
            groupControlParameters.PerformLayout();
            ((ISupportInitialize)groupControlChannels).EndInit();
            groupControlChannels.ResumeLayout(false);
            ((ISupportInitialize)chkParamEmail.Properties).EndInit();
            ((ISupportInitialize)chkParamWhatsApp.Properties).EndInit();
            ((ISupportInitialize)chkParamSms.Properties).EndInit();
            ((ISupportInitialize)chkParamPopup.Properties).EndInit();
            ((ISupportInitialize)chkParamInApp.Properties).EndInit();
            ((ISupportInitialize)chkParamIsEnabled.Properties).EndInit();
            ((ISupportInitialize)cboParamSeverity.Properties).EndInit();
            ((ISupportInitialize)seParamThrottle.Properties).EndInit();
            ((ISupportInitialize)lueParamStore.Properties).EndInit();
            ((ISupportInitialize)lueParamNotificationType.Properties).EndInit();
            ((ISupportInitialize)txtParamRuleName.Properties).EndInit();
            tabTemplates.ResumeLayout(false);
            ((ISupportInitialize)splitContainerTemplates.Panel1).EndInit();
            splitContainerTemplates.Panel1.ResumeLayout(false);
            ((ISupportInitialize)splitContainerTemplates.Panel2).EndInit();
            splitContainerTemplates.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainerTemplates).EndInit();
            splitContainerTemplates.ResumeLayout(false);
            ((ISupportInitialize)gC_Templates).EndInit();
            ((ISupportInitialize)templateBindingSource).EndInit();
            ((ISupportInitialize)gV_Templates).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditLanguage).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).EndInit();
            ((ISupportInitialize)panelTemplateTop).EndInit();
            panelTemplateTop.ResumeLayout(false);
            ((ISupportInitialize)chkFilterSelectedTypeOnly.Properties).EndInit();
            ((ISupportInitialize)groupControlTemplateEditor).EndInit();
            groupControlTemplateEditor.ResumeLayout(false);
            groupControlTemplateEditor.PerformLayout();
            ((ISupportInitialize)meTemplateBody.Properties).EndInit();
            ((ISupportInitialize)txtTemplateTitle.Properties).EndInit();
            ((ISupportInitialize)chkTemplateIsEnabled.Properties).EndInit();
            ((ISupportInitialize)cboTemplateLanguage.Properties).EndInit();
            tabRecipients.ResumeLayout(false);
            ((ISupportInitialize)gC_RecipientRules).EndInit();
            ((ISupportInitialize)recipientRuleBindingSource).EndInit();
            ((ISupportInitialize)gV_RecipientRules).EndInit();
            ((ISupportInitialize)repositoryItemCheckEditRecipient).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditRole).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditRecipientStore).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditRecipientNotificationType).EndInit();
            ((ISupportInitialize)panelRecipientTop).EndInit();
            panelRecipientTop.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SvgImageCollection svgImageCollection1;
        private RibbonControl ribbonControl1;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroupOperations;
        private RibbonPageGroup ribbonPageGroupRules;
        private RibbonPageGroup ribbonPageGroupTemplates;
        private RibbonPageGroup ribbonPageGroupRecipients;
        private RibbonPageGroup ribbonPageGroupExport;
        private RibbonStatusBar ribbonStatusBar1;
        private BarButtonItem bBI_Save;
        private BarButtonItem bBI_Refresh;
        private BarButtonItem bBI_New;
        private BarButtonItem bBI_Delete;
        private BarButtonItem bBI_NewTemplate;
        private BarButtonItem bBI_DeleteTemplate;
        private BarButtonItem bBI_NewRecipient;
        private BarButtonItem bBI_DeleteRecipient;
        private BarButtonItem bBI_ExportXlsx;
        private SplitContainerControl splitContainerMain;
        private GroupControl groupControlRules;
        private MyGridControl gC_NotificationRules;
        private MyGridView gV_NotificationRules;
        private BindingSource notificationRuleBindingSource;
        private GridColumn colNotificationRuleId;
        private GridColumn colIsEnabled;
        private GridColumn colRuleName;
        private GridColumn colNotificationCategoryCode;
        private GridColumn colNotificationTypeCode;
        private GridColumn colStoreCode;
        private GridColumn colChannelCodes;
        private GridColumn colThrottleMinutes;
        private GridColumn colPopupMinSeverity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        private PanelControl panelHeader;
        private LabelControl lblSelectedRuleTitle;
        private LabelControl lblSelectedRuleSubtitle;
        private XtraTabControl tabDetailControl;
        private XtraTabPage tabParameters;
        private XtraTabPage tabTemplates;
        private XtraTabPage tabRecipients;
        private GroupControl groupControlParameters;
        private LabelControl lblParamRuleName;
        private TextEdit txtParamRuleName;
        private LabelControl lblParamNotificationType;
        private LookUpEdit lueParamNotificationType;
        private LabelControl lblParamStore;
        private LookUpEdit lueParamStore;
        private GroupControl groupControlChannels;
        private CheckEdit chkParamInApp;
        private CheckEdit chkParamPopup;
        private CheckEdit chkParamSms;
        private CheckEdit chkParamWhatsApp;
        private CheckEdit chkParamEmail;
        private LabelControl lblParamThrottle;
        private SpinEdit seParamThrottle;
        private LabelControl lblParamSeverity;
        private ImageComboBoxEdit cboParamSeverity;
        private CheckEdit chkParamIsEnabled;
        private SplitContainerControl splitContainerTemplates;
        private PanelControl panelTemplateTop;
        private CheckEdit chkFilterSelectedTypeOnly;
        private SimpleButton btnNewTemplate;
        private SimpleButton btnDeleteTemplate;
        private MyGridControl gC_Templates;
        private MyGridView gV_Templates;
        private BindingSource templateBindingSource;
        private GridColumn colTemplateIsEnabled;
        private GridColumn colTemplateLanguageCode;
        private GridColumn colTemplateNotificationTypeCode;
        private GridColumn colTemplateTitle;
        private GridColumn colTemplateBody;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNotificationType;
        private GroupControl groupControlTemplateEditor;
        private LabelControl lblTemplateLanguage;
        private ComboBoxEdit cboTemplateLanguage;
        private CheckEdit chkTemplateIsEnabled;
        private LabelControl lblCharCount;
        private LabelControl lblTemplateTitle;
        private TextEdit txtTemplateTitle;
        private LabelControl lblTemplateBody;
        private MemoEdit meTemplateBody;
        private LabelControl lblPlaceholdersTitle;
        private FlowLayoutPanel panelPlaceholders;
        private MyGridControl gC_RecipientRules;
        private MyGridView gV_RecipientRules;
        private BindingSource recipientRuleBindingSource;
        private GridColumn colRecipientIsEnabled;
        private GridColumn colRecipientRoleCode;
        private GridColumn colRecipientStoreCode;
        private GridColumn colRecipientNotificationTypeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditRecipient;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRecipientStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRecipientNotificationType;
        private PanelControl panelRecipientTop;
        private SimpleButton btnNewRecipient;
        private SimpleButton btnDeleteRecipient;
    }
}
