using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormNotificationCenter : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private subContext? dbContext;
        private readonly NotificationInboxFilter filter = new();
        private bool layoutLoaded;

        public FormNotificationCenter()
        {
            InitializeComponent();
            DesignComponentNames();
            SetupStoreLookup();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationCenter;
            bBI_FilterAll.Caption = Resources.Form_NotificationCenter_Filter_All;
            bBI_FilterUnread.Caption = Resources.Form_NotificationCenter_Filter_Unread;
            bBI_FilterCritical.Caption = Resources.Form_NotificationCenter_Filter_Critical;
            bBI_FilterToday.Caption = Resources.Form_NotificationCenter_Filter_Today;
            bBI_FilterStock.Caption = Resources.Form_NotificationCenter_Filter_Stock;
            bBI_FilterPayment.Caption = Resources.Form_NotificationCenter_Filter_Payment;
            bBI_FilterCredit.Caption = Resources.Form_NotificationCenter_Filter_Credit;
            bBI_FilterSystem.Caption = Resources.Form_NotificationCenter_Filter_System;
        }

        private void SetupStoreLookup()
        {
            EfMethods efMethods = new();
            repositoryItemLookUpEditStore.DataSource = efMethods.SelectStoresIncludeDisabled();
            repositoryItemLookUpEditStore.DisplayMember = nameof(DcCurrAcc.CurrAccDesc);
            repositoryItemLookUpEditStore.ValueMember = nameof(DcCurrAcc.CurrAccCode);
            repositoryItemLookUpEditStore.NullText = Resources.Form_NotificationCenter_Filter_All;
        }

        private async void FormNotificationCenter_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            LoadLayout();
        }

        private async Task LoadDataAsync()
        {
            dbContext?.Dispose();
            dbContext = new subContext();
            NotificationService service = new(dbContext);

            ApplyEditorFilters();

            List<NotificationInboxItem> items = await service.GetInboxAsync(Authorization.CurrAccCode, filter);
            notificationInboxItemBindingSource.DataSource = items;

            if (!layoutLoaded)
                gV_Notifications.BestFitColumns();

            int unreadCount = await service.GetUnreadCountAsync(Authorization.CurrAccCode);
            bSI_UnreadCount.Caption = string.Format(Resources.Form_NotificationCenter_UnreadCount, unreadCount);
        }

        private void ApplyEditorFilters()
        {
            filter.StoreCode = bEI_Store.EditValue?.ToString();
            filter.DateFrom = bEI_DateFrom.EditValue is DateTime dateFrom ? dateFrom : null;
            filter.DateTo = bEI_DateTo.EditValue is DateTime dateTo ? dateTo : null;
        }

        private NotificationInboxItem? FocusedItem()
        {
            return gV_Notifications.GetFocusedRow() as NotificationInboxItem;
        }

        private async void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void bBI_ApplyFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void bBI_ClearFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = null;
            bEI_Store.EditValue = null;
            bEI_DateFrom.EditValue = null;
            bEI_DateTo.EditValue = null;
            await LoadDataAsync();
        }

        private async void bBI_FilterAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = null;
            await LoadDataAsync();
        }

        private async void bBI_FilterUnread_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = "Unread";
            filter.CategoryCode = null;
            await LoadDataAsync();
        }

        private async void bBI_FilterCritical_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = "Critical";
            filter.CategoryCode = null;
            await LoadDataAsync();
        }

        private async void bBI_FilterToday_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = "Today";
            filter.CategoryCode = null;
            await LoadDataAsync();
        }

        private async void bBI_FilterStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = NotificationCategories.Stock;
            await LoadDataAsync();
        }

        private async void bBI_FilterPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = NotificationCategories.Payment;
            await LoadDataAsync();
        }

        private async void bBI_FilterCredit_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = NotificationCategories.Installment;
            await LoadDataAsync();
        }

        private async void bBI_FilterSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            filter.Preset = null;
            filter.CategoryCode = NotificationCategories.System;
            await LoadDataAsync();
        }

        private async void bBI_MarkRead_ItemClick(object sender, ItemClickEventArgs e)
        {
            NotificationInboxItem? item = FocusedItem();
            if (item == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            await new NotificationService(dbContext!).MarkReadAsync(item.NotificationRecipientId, Authorization.CurrAccCode);
            await LoadDataAsync();
        }

        private async void bBI_MarkAllRead_ItemClick(object sender, ItemClickEventArgs e)
        {
            await new NotificationService(dbContext!).MarkAllReadAsync(Authorization.CurrAccCode);
            await LoadDataAsync();
        }

        private async void bBI_Dismiss_ItemClick(object sender, ItemClickEventArgs e)
        {
            NotificationInboxItem? item = FocusedItem();
            if (item == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            await new NotificationService(dbContext!).DismissAsync(item.NotificationRecipientId, Authorization.CurrAccCode);
            await LoadDataAsync();
        }

        private async void bBI_Snooze_ItemClick(object sender, ItemClickEventArgs e)
        {
            NotificationInboxItem? item = FocusedItem();
            if (item == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            await new NotificationService(dbContext!).SnoozeAsync(item.NotificationRecipientId, Authorization.CurrAccCode, DateTime.Now.AddHours(1));
            await LoadDataAsync();
        }

        private async void bBI_Resolve_ItemClick(object sender, ItemClickEventArgs e)
        {
            NotificationInboxItem? item = FocusedItem();
            if (item == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            await new NotificationService(dbContext!).ResolveAsync(item.NotificationId, Authorization.CurrAccCode);
            await LoadDataAsync();
        }

        private async void bBI_OpenRelated_ItemClick(object sender, ItemClickEventArgs e)
        {
            await OpenFocusedRelatedEntityAsync();
        }

        private async Task OpenFocusedRelatedEntityAsync()
        {
            NotificationInboxItem? item = FocusedItem();
            if (item == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            if (string.IsNullOrWhiteSpace(item.EntityType) || string.IsNullOrWhiteSpace(item.EntityKey))
            {
                XtraMessageBox.Show(Resources.Form_NotificationCenter_NoRelatedEntity, Resources.Common_Attention);
                return;
            }

            if (string.Equals(item.EntityType, NotificationEntityTypes.Product, StringComparison.OrdinalIgnoreCase))
            {
                FormERP? formERP = MdiParent as FormERP
                    ?? Application.OpenForms.OfType<FormERP>().FirstOrDefault();

                if (formERP != null)
                {
                    await formERP.OpenNotificationItemAsync(item);
                    await LoadDataAsync();
                }

                return;
            }

            Form? form = CreateRelatedForm(item);
            if (form == null)
            {
                XtraMessageBox.Show(Resources.Form_NotificationCenter_NoRelatedEntity, Resources.Common_Attention);
                return;
            }

            form.MdiParent = MdiParent;
            form.FormClosed += (s, args) => form.Dispose();
            form.Show();
            form.WindowState = FormWindowState.Maximized;
            FormSizeHelper.Track(form);
        }

        private Form? CreateRelatedForm(NotificationInboxItem item)
        {
            if (item.EntityType == NotificationEntityTypes.Customer)
                return new FormCurrAcc(item.EntityKey!);

            if (item.EntityType == NotificationEntityTypes.Invoice && Guid.TryParse(item.EntityKey, out Guid invoiceHeaderId))
            {
                TrInvoiceHeader? header = dbContext!.TrInvoiceHeaders
                    .AsNoTracking()
                    .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

                if (header == null)
                    return null;

                byte[] productTypes = header.ProcessCode == "EX" ? new byte[] { 2, 3 } : new byte[] { 1, 3 };
                return new FormInvoice(header.ProcessCode, header.IsReturn, productTypes, null, invoiceHeaderId);
            }

            return null;
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Resources.Form_NotificationCenter, gC_Notifications);
        }

        private async void gC_Notifications_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                await LoadDataAsync();
                e.Handled = true;
            }
        }

        private async void gV_Notifications_DoubleClick(object sender, EventArgs e)
        {
            await OpenFocusedRelatedEntityAsync();
        }

        private void gV_Notifications_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            NotificationInboxItem? item = gV_Notifications.GetRow(e.RowHandle) as NotificationInboxItem;
            if (item == null)
                return;

            bool isUnread = string.Equals(item.RecipientStatus, NotificationRecipientStatuses.Unread, StringComparison.OrdinalIgnoreCase);
            bool isRead = string.Equals(item.RecipientStatus, NotificationRecipientStatuses.Read, StringComparison.OrdinalIgnoreCase);

            if (isRead)
                e.Appearance.BackColor = Color.FromArgb(232, 245, 233);
            else if (item.Severity == NotificationSeverities.Critical)
                e.Appearance.BackColor = Color.MistyRose;
            else if (item.Severity == NotificationSeverities.High)
                e.Appearance.BackColor = Color.LemonChiffon;

            e.Appearance.FontStyleDelta = isUnread ? FontStyle.Bold : FontStyle.Regular;

            if (item.NotificationStatus == NotificationStatuses.Resolved)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_Notifications_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu? menu = e.Menu as GridViewColumnMenu;
                if (menu?.Column != null)
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));
            }
        }

        private DXMenuItem CreateItem(string caption, GridColumn column, Image? image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        private void DXMenuItem_Click(object? sender, EventArgs e)
        {
            SaveLayout();
        }

        private void LoadLayout()
        {
            string fileName = "FormNotificationCenterLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_Notifications.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormNotificationCenterLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_Notifications.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private void FormNotificationCenter_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext?.Dispose();
        }

        private class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                Column = column;
            }

            public GridColumn Column { get; }
        }
    }
}
