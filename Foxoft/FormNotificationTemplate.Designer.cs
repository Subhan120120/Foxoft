using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormNotificationTemplate
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
            ribbonPageGroupTemplates = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            gC_NotificationTemplates = new MyGridControl();
            notificationTemplateBindingSource = new BindingSource(components);
            gV_NotificationTemplates = new MyGridView();
            colNotificationTemplateId = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotificationTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditNotificationType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colNotificationCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colLanguageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTitleTemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            colBodyTemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemMemoExEditBody = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)gC_NotificationTemplates).BeginInit();
            ((ISupportInitialize)notificationTemplateBindingSource).BeginInit();
            ((ISupportInitialize)gV_NotificationTemplates).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).BeginInit();
            ((ISupportInitialize)repositoryItemMemoExEditBody).BeginInit();
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
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupTemplates, ribbonPageGroupData, ribbonPageGroupExport });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_NotificationTemplate;
            // 
            // ribbonPageGroupTemplates
            // 
            ribbonPageGroupTemplates.ItemLinks.Add(bBI_New);
            ribbonPageGroupTemplates.ItemLinks.Add(bBI_Save);
            ribbonPageGroupTemplates.ItemLinks.Add(bBI_Delete);
            ribbonPageGroupTemplates.Name = "ribbonPageGroupTemplates";
            ribbonPageGroupTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            // 
            // ribbonPageGroupData
            // 
            ribbonPageGroupData.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupData.ItemLinks.Add(bBI_Cancel);
            ribbonPageGroupData.Name = "ribbonPageGroupData";
            ribbonPageGroupData.Text = Resources.Form_NotificationTemplate_Data;
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
            // gC_NotificationTemplates
            // 
            gC_NotificationTemplates.DataSource = notificationTemplateBindingSource;
            gC_NotificationTemplates.Dock = DockStyle.Fill;
            gC_NotificationTemplates.Location = new Point(0, 158);
            gC_NotificationTemplates.MainView = gV_NotificationTemplates;
            gC_NotificationTemplates.MenuManager = ribbonControl1;
            gC_NotificationTemplates.Name = "gC_NotificationTemplates";
            gC_NotificationTemplates.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEditNotificationType, repositoryItemCheckEdit, repositoryItemMemoExEditBody });
            gC_NotificationTemplates.Size = new Size(1180, 518);
            gC_NotificationTemplates.TabIndex = 0;
            gC_NotificationTemplates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_NotificationTemplates });
            gC_NotificationTemplates.ProcessGridKey += gC_NotificationTemplates_ProcessGridKey;
            // 
            // notificationTemplateBindingSource
            // 
            notificationTemplateBindingSource.DataSource = typeof(NotificationTemplate);
            // 
            // gV_NotificationTemplates
            // 
            gV_NotificationTemplates.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNotificationTemplateId, colNotificationTypeCode, colNotificationCategoryCode, colLanguageCode, colTitleTemplate, colBodyTemplate, colIsEnabled, colCreatedDate, colLastUpdatedDate });
            gV_NotificationTemplates.GridControl = gC_NotificationTemplates;
            gV_NotificationTemplates.Name = "gV_NotificationTemplates";
            gV_NotificationTemplates.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_NotificationTemplates.OptionsFind.FindDelay = 100;
            gV_NotificationTemplates.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gV_NotificationTemplates.OptionsView.ShowAutoFilterRow = true;
            gV_NotificationTemplates.OptionsView.ShowFooter = true;
            gV_NotificationTemplates.OptionsView.ShowGroupPanel = false;
            gV_NotificationTemplates.RowCellStyle += gV_NotificationTemplates_RowCellStyle;
            gV_NotificationTemplates.ValidateRow += gV_NotificationTemplates_ValidateRow;
            gV_NotificationTemplates.InvalidRowException += gV_NotificationTemplates_InvalidRowException;
            gV_NotificationTemplates.PopupMenuShowing += gV_NotificationTemplates_PopupMenuShowing;
            // 
            // colNotificationTemplateId
            // 
            colNotificationTemplateId.Caption = Resources.Entity_NotificationTemplate_Id;
            colNotificationTemplateId.FieldName = "NotificationTemplateId";
            colNotificationTemplateId.Name = "colNotificationTemplateId";
            colNotificationTemplateId.OptionsColumn.AllowEdit = false;
            colNotificationTemplateId.Visible = true;
            colNotificationTemplateId.VisibleIndex = 0;
            colNotificationTemplateId.Width = 80;
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
            // colLanguageCode
            // 
            colLanguageCode.Caption = Resources.Entity_NotificationTemplate_LanguageCode;
            colLanguageCode.FieldName = "LanguageCode";
            colLanguageCode.Name = "colLanguageCode";
            colLanguageCode.Visible = true;
            colLanguageCode.VisibleIndex = 3;
            colLanguageCode.Width = 80;
            // 
            // colTitleTemplate
            // 
            colTitleTemplate.Caption = Resources.Entity_NotificationTemplate_TitleTemplate;
            colTitleTemplate.FieldName = "TitleTemplate";
            colTitleTemplate.Name = "colTitleTemplate";
            colTitleTemplate.Visible = true;
            colTitleTemplate.VisibleIndex = 4;
            colTitleTemplate.Width = 250;
            // 
            // colBodyTemplate
            // 
            colBodyTemplate.Caption = Resources.Entity_NotificationTemplate_BodyTemplate;
            colBodyTemplate.ColumnEdit = repositoryItemMemoExEditBody;
            colBodyTemplate.FieldName = "BodyTemplate";
            colBodyTemplate.Name = "colBodyTemplate";
            colBodyTemplate.Visible = true;
            colBodyTemplate.VisibleIndex = 5;
            colBodyTemplate.Width = 300;
            // 
            // repositoryItemMemoExEditBody
            // 
            repositoryItemMemoExEditBody.AutoHeight = false;
            repositoryItemMemoExEditBody.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemMemoExEditBody.Name = "repositoryItemMemoExEditBody";
            repositoryItemMemoExEditBody.ShowIcon = false;
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
            // FormNotificationTemplate
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 700);
            Controls.Add(gC_NotificationTemplates);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormNotificationTemplate";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_NotificationTemplate;
            FormClosed += FormNotificationTemplate_FormClosed;
            Load += FormNotificationTemplate_Load;
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)gC_NotificationTemplates).EndInit();
            ((ISupportInitialize)notificationTemplateBindingSource).EndInit();
            ((ISupportInitialize)gV_NotificationTemplates).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditNotificationType).EndInit();
            ((ISupportInitialize)repositoryItemMemoExEditBody).EndInit();
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTemplates;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private MyGridControl gC_NotificationTemplates;
        private MyGridView gV_NotificationTemplates;
        private BindingSource notificationTemplateBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationTemplateId;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLanguageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTitleTemplate;
        private DevExpress.XtraGrid.Columns.GridColumn colBodyTemplate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNotificationType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEditBody;
    }
}
