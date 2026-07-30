using DevExpress.Utils.Svg;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormNotificationCenter
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
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_MarkRead = new DevExpress.XtraBars.BarButtonItem();
            bBI_MarkAllRead = new DevExpress.XtraBars.BarButtonItem();
            bBI_Dismiss = new DevExpress.XtraBars.BarButtonItem();
            bBI_Snooze = new DevExpress.XtraBars.BarButtonItem();
            bBI_Resolve = new DevExpress.XtraBars.BarButtonItem();
            bBI_OpenRelated = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterAll = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterUnread = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterCritical = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterToday = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterStock = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterPayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterCredit = new DevExpress.XtraBars.BarButtonItem();
            bBI_FilterSystem = new DevExpress.XtraBars.BarButtonItem();
            bEI_Store = new DevExpress.XtraBars.BarEditItem();
            repositoryItemLookUpEditStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            bEI_DateFrom = new DevExpress.XtraBars.BarEditItem();
            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            bEI_DateTo = new DevExpress.XtraBars.BarEditItem();
            bBI_ApplyFilter = new DevExpress.XtraBars.BarButtonItem();
            bBI_ClearFilter = new DevExpress.XtraBars.BarButtonItem();
            bSI_UnreadCount = new DevExpress.XtraBars.BarStaticItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupFilters = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupDateStore = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            gC_Notifications = new MyGridControl();
            notificationInboxItemBindingSource = new BindingSource(components);
            gV_Notifications = new MyGridView();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotificationTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colBody = new DevExpress.XtraGrid.Columns.GridColumn();
            colRecipientStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotificationStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colEntityType = new DevExpress.XtraGrid.Columns.GridColumn();
            colEntityKey = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastRaisedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).BeginInit();
            ((ISupportInitialize)repositoryItemDateEdit).BeginInit();
            ((ISupportInitialize)repositoryItemDateEdit.CalendarTimeProperties).BeginInit();
            ((ISupportInitialize)gC_Notifications).BeginInit();
            ((ISupportInitialize)notificationInboxItemBindingSource).BeginInit();
            ((ISupportInitialize)gV_Notifications).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("check", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("delete", "image://svgimages/scheduling/delete.svg");
            svgImageCollection1.Add("clock", "image://svgimages/scheduling/time.svg");
            svgImageCollection1.Add("open", "image://svgimages/outlook inspired/open.svg");
            svgImageCollection1.Add("export", "image://svgimages/export/exporttoxlsx.svg");
            svgImageCollection1.Add("filter", "image://svgimages/filter%20elements/filter.svg");
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_Refresh, bBI_MarkRead, bBI_MarkAllRead, bBI_Dismiss, bBI_Snooze, bBI_Resolve, bBI_OpenRelated, bBI_ExportXlsx, bBI_FilterAll, bBI_FilterUnread, bBI_FilterCritical, bBI_FilterToday, bBI_FilterStock, bBI_FilterPayment, bBI_FilterCredit, bBI_FilterSystem, bEI_Store, bEI_DateFrom, bEI_DateTo, bBI_ApplyFilter, bBI_ClearFilter, bSI_UnreadCount });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 24;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEditStore, repositoryItemDateEdit });
            ribbonControl1.Size = new Size(1180, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 1;
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_MarkRead
            // 
            bBI_MarkRead.Caption = Resources.Form_NotificationCenter_MarkRead;
            bBI_MarkRead.Id = 2;
            bBI_MarkRead.ImageOptions.SvgImage = svgImageCollection1["check"];
            bBI_MarkRead.Name = "bBI_MarkRead";
            bBI_MarkRead.ItemClick += bBI_MarkRead_ItemClick;
            // 
            // bBI_MarkAllRead
            // 
            bBI_MarkAllRead.Caption = Resources.Form_NotificationCenter_MarkAllRead;
            bBI_MarkAllRead.Id = 3;
            bBI_MarkAllRead.ImageOptions.SvgImage = svgImageCollection1["check"];
            bBI_MarkAllRead.Name = "bBI_MarkAllRead";
            bBI_MarkAllRead.ItemClick += bBI_MarkAllRead_ItemClick;
            // 
            // bBI_Dismiss
            // 
            bBI_Dismiss.Caption = Resources.Form_NotificationCenter_Dismiss;
            bBI_Dismiss.Id = 4;
            bBI_Dismiss.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_Dismiss.Name = "bBI_Dismiss";
            bBI_Dismiss.ItemClick += bBI_Dismiss_ItemClick;
            // 
            // bBI_Snooze
            // 
            bBI_Snooze.Caption = Resources.Form_NotificationCenter_Snooze;
            bBI_Snooze.Id = 5;
            bBI_Snooze.ImageOptions.SvgImage = svgImageCollection1["clock"];
            bBI_Snooze.Name = "bBI_Snooze";
            bBI_Snooze.ItemClick += bBI_Snooze_ItemClick;
            // 
            // bBI_Resolve
            // 
            bBI_Resolve.Caption = Resources.Form_NotificationCenter_Resolve;
            bBI_Resolve.Id = 6;
            bBI_Resolve.ImageOptions.SvgImage = svgImageCollection1["check"];
            bBI_Resolve.Name = "bBI_Resolve";
            bBI_Resolve.ItemClick += bBI_Resolve_ItemClick;
            // 
            // bBI_OpenRelated
            // 
            bBI_OpenRelated.Caption = Resources.Form_NotificationCenter_OpenRelated;
            bBI_OpenRelated.Id = 7;
            bBI_OpenRelated.ImageOptions.SvgImage = svgImageCollection1["open"];
            bBI_OpenRelated.Name = "bBI_OpenRelated";
            bBI_OpenRelated.ItemClick += bBI_OpenRelated_ItemClick;
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 9;
            bBI_ExportXlsx.ImageOptions.SvgImage = svgImageCollection1["export"];
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_FilterAll
            // 
            bBI_FilterAll.Id = 10;
            bBI_FilterAll.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterAll.Name = "bBI_FilterAll";
            bBI_FilterAll.ItemClick += bBI_FilterAll_ItemClick;
            // 
            // bBI_FilterUnread
            // 
            bBI_FilterUnread.Id = 11;
            bBI_FilterUnread.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterUnread.Name = "bBI_FilterUnread";
            bBI_FilterUnread.ItemClick += bBI_FilterUnread_ItemClick;
            // 
            // bBI_FilterCritical
            // 
            bBI_FilterCritical.Id = 12;
            bBI_FilterCritical.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterCritical.Name = "bBI_FilterCritical";
            bBI_FilterCritical.ItemClick += bBI_FilterCritical_ItemClick;
            // 
            // bBI_FilterToday
            // 
            bBI_FilterToday.Id = 13;
            bBI_FilterToday.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterToday.Name = "bBI_FilterToday";
            bBI_FilterToday.ItemClick += bBI_FilterToday_ItemClick;
            // 
            // bBI_FilterStock
            // 
            bBI_FilterStock.Id = 14;
            bBI_FilterStock.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterStock.Name = "bBI_FilterStock";
            bBI_FilterStock.ItemClick += bBI_FilterStock_ItemClick;
            // 
            // bBI_FilterPayment
            // 
            bBI_FilterPayment.Id = 15;
            bBI_FilterPayment.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterPayment.Name = "bBI_FilterPayment";
            bBI_FilterPayment.ItemClick += bBI_FilterPayment_ItemClick;
            // 
            // bBI_FilterCredit
            // 
            bBI_FilterCredit.Id = 16;
            bBI_FilterCredit.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterCredit.Name = "bBI_FilterCredit";
            bBI_FilterCredit.ItemClick += bBI_FilterCredit_ItemClick;
            // 
            // bBI_FilterSystem
            // 
            bBI_FilterSystem.Id = 17;
            bBI_FilterSystem.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_FilterSystem.Name = "bBI_FilterSystem";
            bBI_FilterSystem.ItemClick += bBI_FilterSystem_ItemClick;
            // 
            // bEI_Store
            // 
            bEI_Store.Caption = Resources.Form_NotificationCenter_Filter_Store;
            bEI_Store.Edit = repositoryItemLookUpEditStore;
            bEI_Store.EditWidth = 150;
            bEI_Store.Id = 18;
            bEI_Store.Name = "bEI_Store";
            // 
            // repositoryItemLookUpEditStore
            // 
            repositoryItemLookUpEditStore.AutoHeight = false;
            repositoryItemLookUpEditStore.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEditStore.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Foxoft.Models.DcCurrAcc.CurrAccCode), Resources.Entity_CurrAcc_Code), new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Foxoft.Models.DcCurrAcc.CurrAccDesc), Resources.Entity_CurrAcc_Desc) });
            repositoryItemLookUpEditStore.Name = "repositoryItemLookUpEditStore";
            // 
            // bEI_DateFrom
            // 
            bEI_DateFrom.Caption = Resources.Form_NotificationCenter_Filter_DateFrom;
            bEI_DateFrom.Edit = repositoryItemDateEdit;
            bEI_DateFrom.EditWidth = 100;
            bEI_DateFrom.Id = 19;
            bEI_DateFrom.Name = "bEI_DateFrom";
            // 
            // repositoryItemDateEdit
            // 
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit.Name = "repositoryItemDateEdit";
            // 
            // bEI_DateTo
            // 
            bEI_DateTo.Caption = Resources.Form_NotificationCenter_Filter_DateTo;
            bEI_DateTo.Edit = repositoryItemDateEdit;
            bEI_DateTo.EditWidth = 100;
            bEI_DateTo.Id = 20;
            bEI_DateTo.Name = "bEI_DateTo";
            // 
            // bBI_ApplyFilter
            // 
            bBI_ApplyFilter.Caption = Resources.Form_NotificationCenter_ApplyFilter;
            bBI_ApplyFilter.Id = 21;
            bBI_ApplyFilter.ImageOptions.SvgImage = svgImageCollection1["filter"];
            bBI_ApplyFilter.Name = "bBI_ApplyFilter";
            bBI_ApplyFilter.ItemClick += bBI_ApplyFilter_ItemClick;
            // 
            // bBI_ClearFilter
            // 
            bBI_ClearFilter.Caption = Resources.Form_NotificationCenter_ClearFilter;
            bBI_ClearFilter.Id = 22;
            bBI_ClearFilter.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_ClearFilter.Name = "bBI_ClearFilter";
            bBI_ClearFilter.ItemClick += bBI_ClearFilter_ItemClick;
            // 
            // bSI_UnreadCount
            // 
            bSI_UnreadCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            bSI_UnreadCount.Caption = string.Format(Resources.Form_NotificationCenter_UnreadCount, 0);
            bSI_UnreadCount.Id = 23;
            bSI_UnreadCount.Name = "bSI_UnreadCount";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupOperations, ribbonPageGroupFilters, ribbonPageGroupDateStore, ribbonPageGroupExport });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_NotificationCenter;
            // 
            // ribbonPageGroupOperations
            // 
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_MarkRead);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_MarkAllRead);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Dismiss);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Snooze);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_Resolve);
            ribbonPageGroupOperations.ItemLinks.Add(bBI_OpenRelated);
            ribbonPageGroupOperations.Name = "ribbonPageGroupOperations";
            ribbonPageGroupOperations.Text = Resources.Common_Operations;
            // 
            // ribbonPageGroupFilters
            // 
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterAll);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterUnread);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterCritical);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterToday);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterStock);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterPayment);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterCredit);
            ribbonPageGroupFilters.ItemLinks.Add(bBI_FilterSystem);
            ribbonPageGroupFilters.Name = "ribbonPageGroupFilters";
            ribbonPageGroupFilters.Text = Resources.Form_NotificationCenter_Filters;
            // 
            // ribbonPageGroupDateStore
            // 
            ribbonPageGroupDateStore.ItemLinks.Add(bEI_Store);
            ribbonPageGroupDateStore.ItemLinks.Add(bEI_DateFrom);
            ribbonPageGroupDateStore.ItemLinks.Add(bEI_DateTo);
            ribbonPageGroupDateStore.ItemLinks.Add(bBI_ApplyFilter);
            ribbonPageGroupDateStore.ItemLinks.Add(bBI_ClearFilter);
            ribbonPageGroupDateStore.Name = "ribbonPageGroupDateStore";
            ribbonPageGroupDateStore.Text = Resources.Form_NotificationCenter_AdvancedFilters;
            // 
            // ribbonPageGroupExport
            // 
            ribbonPageGroupExport.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroupExport.Name = "ribbonPageGroupExport";
            ribbonPageGroupExport.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.ItemLinks.Add(bSI_UnreadCount);
            ribbonStatusBar1.Location = new Point(0, 676);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1180, 24);
            // 
            // gC_Notifications
            // 
            gC_Notifications.DataSource = notificationInboxItemBindingSource;
            gC_Notifications.Dock = DockStyle.Fill;
            gC_Notifications.Location = new Point(0, 158);
            gC_Notifications.MainView = gV_Notifications;
            gC_Notifications.MenuManager = ribbonControl1;
            gC_Notifications.Name = "gC_Notifications";
            gC_Notifications.Size = new Size(1180, 518);
            gC_Notifications.TabIndex = 0;
            gC_Notifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Notifications });
            gC_Notifications.ProcessGridKey += gC_Notifications_ProcessGridKey;
            // 
            // notificationInboxItemBindingSource
            // 
            notificationInboxItemBindingSource.DataSource = typeof(NotificationInboxItem);
            // 
            // gV_Notifications
            // 
            gV_Notifications.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCreatedDate, colSeverity, colCategoryCode, colNotificationTypeDesc, colStoreCode, colTitle, colBody, colRecipientStatus, colNotificationStatus, colEntityType, colEntityKey, colLastRaisedDate });
            gV_Notifications.GridControl = gC_Notifications;
            gV_Notifications.Name = "gV_Notifications";
            gV_Notifications.OptionsBehavior.Editable = false;
            gV_Notifications.OptionsFind.FindDelay = 100;
            gV_Notifications.OptionsView.RowAutoHeight = true;
            gV_Notifications.OptionsView.ShowAutoFilterRow = true;
            gV_Notifications.OptionsView.ShowFooter = true;
            gV_Notifications.OptionsView.ShowGroupPanel = false;
            gV_Notifications.RowCellStyle += gV_Notifications_RowCellStyle;
            gV_Notifications.PopupMenuShowing += gV_Notifications_PopupMenuShowing;
            gV_Notifications.DoubleClick += gV_Notifications_DoubleClick;
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 0;
            // 
            // colSeverity
            // 
            colSeverity.Caption = Resources.Entity_Notification_Severity;
            colSeverity.FieldName = "Severity";
            colSeverity.Name = "colSeverity";
            colSeverity.Visible = true;
            colSeverity.VisibleIndex = 1;
            // 
            // colCategoryCode
            // 
            colCategoryCode.Caption = Resources.Entity_NotificationType_CategoryCode;
            colCategoryCode.FieldName = "CategoryCode";
            colCategoryCode.Name = "colCategoryCode";
            colCategoryCode.Visible = true;
            colCategoryCode.VisibleIndex = 2;
            // 
            // colNotificationTypeDesc
            // 
            colNotificationTypeDesc.Caption = Resources.Entity_NotificationType_Desc;
            colNotificationTypeDesc.FieldName = "NotificationTypeDesc";
            colNotificationTypeDesc.Name = "colNotificationTypeDesc";
            colNotificationTypeDesc.Visible = true;
            colNotificationTypeDesc.VisibleIndex = 3;
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.Visible = true;
            colStoreCode.VisibleIndex = 4;
            // 
            // colTitle
            // 
            colTitle.Caption = Resources.Entity_Notification_Title;
            colTitle.FieldName = "Title";
            colTitle.Name = "colTitle";
            colTitle.Visible = true;
            colTitle.VisibleIndex = 5;
            // 
            // colBody
            // 
            colBody.Caption = Resources.Entity_Notification_Body;
            colBody.FieldName = "Body";
            colBody.Name = "colBody";
            colBody.Visible = true;
            colBody.VisibleIndex = 6;
            // 
            // colRecipientStatus
            // 
            colRecipientStatus.Caption = Resources.Entity_NotificationRecipient_Status;
            colRecipientStatus.FieldName = "RecipientStatus";
            colRecipientStatus.Name = "colRecipientStatus";
            colRecipientStatus.Visible = true;
            colRecipientStatus.VisibleIndex = 7;
            // 
            // colNotificationStatus
            // 
            colNotificationStatus.Caption = Resources.Entity_Notification_Status;
            colNotificationStatus.FieldName = "NotificationStatus";
            colNotificationStatus.Name = "colNotificationStatus";
            colNotificationStatus.Visible = true;
            colNotificationStatus.VisibleIndex = 8;
            // 
            // colEntityType
            // 
            colEntityType.Caption = Resources.Entity_Notification_EntityType;
            colEntityType.FieldName = "EntityType";
            colEntityType.Name = "colEntityType";
            // 
            // colEntityKey
            // 
            colEntityKey.Caption = Resources.Entity_Notification_EntityKey;
            colEntityKey.FieldName = "EntityKey";
            colEntityKey.Name = "colEntityKey";
            // 
            // colLastRaisedDate
            // 
            colLastRaisedDate.Caption = Resources.Entity_Notification_LastRaisedDate;
            colLastRaisedDate.FieldName = "LastRaisedDate";
            colLastRaisedDate.Name = "colLastRaisedDate";
            colLastRaisedDate.Visible = true;
            colLastRaisedDate.VisibleIndex = 9;
            // 
            // FormNotificationCenter
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 700);
            Controls.Add(gC_Notifications);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormNotificationCenter";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_NotificationCenter;
            FormClosed += FormNotificationCenter_FormClosed;
            Load += FormNotificationCenter_Load;
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)repositoryItemLookUpEditStore).EndInit();
            ((ISupportInitialize)repositoryItemDateEdit.CalendarTimeProperties).EndInit();
            ((ISupportInitialize)repositoryItemDateEdit).EndInit();
            ((ISupportInitialize)gC_Notifications).EndInit();
            ((ISupportInitialize)notificationInboxItemBindingSource).EndInit();
            ((ISupportInitialize)gV_Notifications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOperations;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFilters;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDateStore;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_MarkRead;
        private DevExpress.XtraBars.BarButtonItem bBI_MarkAllRead;
        private DevExpress.XtraBars.BarButtonItem bBI_Dismiss;
        private DevExpress.XtraBars.BarButtonItem bBI_Snooze;
        private DevExpress.XtraBars.BarButtonItem bBI_Resolve;
        private DevExpress.XtraBars.BarButtonItem bBI_OpenRelated;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterAll;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterUnread;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterCritical;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterToday;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterStock;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterPayment;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterCredit;
        private DevExpress.XtraBars.BarButtonItem bBI_FilterSystem;
        private DevExpress.XtraBars.BarEditItem bEI_Store;
        private DevExpress.XtraBars.BarEditItem bEI_DateFrom;
        private DevExpress.XtraBars.BarEditItem bEI_DateTo;
        private DevExpress.XtraBars.BarButtonItem bBI_ApplyFilter;
        private DevExpress.XtraBars.BarButtonItem bBI_ClearFilter;
        private DevExpress.XtraBars.BarStaticItem bSI_UnreadCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private MyGridControl gC_Notifications;
        private MyGridView gV_Notifications;
        private BindingSource notificationInboxItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationTypeDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colBody;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipientStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colEntityType;
        private DevExpress.XtraGrid.Columns.GridColumn colEntityKey;
        private DevExpress.XtraGrid.Columns.GridColumn colLastRaisedDate;
    }
}
