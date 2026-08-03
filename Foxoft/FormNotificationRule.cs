using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormNotificationRule : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private readonly string[] validChannels =
        {
            NotificationChannels.InApp,
            NotificationChannels.Popup,
            NotificationChannels.Sms,
            NotificationChannels.Email,
            NotificationChannels.WhatsApp
        };

        private subContext? dbContext;
        private List<NotificationType> notificationTypes = new();
        private List<DcRole> roles = new();
        private List<NotificationRecipientRule> allRecipientRules = new();
        private bool layoutLoaded;

        public FormNotificationRule()
        {
            InitializeComponent();
            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationRule;
            ribbonPage1.Text = Resources.Form_NotificationRule;
            ribbonPageGroupRules.Text = Resources.Form_NotificationRule_Rules;
            ribbonPageGroupRecipients.Text = Resources.Form_NotificationRecipientRule_Rules;
            ribbonPageGroupData.Text = Resources.Form_NotificationRule_Data;
            repositoryItemLookUpEditStore.NullText = Resources.Form_NotificationRule_AllStores;
            repositoryItemLookUpEditRecipientStore.NullText = Resources.Form_NotificationRecipientRule_AllStores;
        }

        private async void FormNotificationRule_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            LoadLayout();
        }

        private async Task LoadDataAsync()
        {
            dbContext?.Dispose();
            dbContext = new subContext();

            notificationTypes = await dbContext.NotificationTypes
                .AsNoTracking()
                .Where(x => x.IsEnabled)
                .OrderBy(x => x.CategoryCode)
                .ThenBy(x => x.DisplayOrder)
                .ToListAsync();

            roles = await dbContext.DcRoles
                .AsNoTracking()
                .OrderBy(x => x.RoleCode)
                .ToListAsync();

            List<DcCurrAcc> stores = efMethods.SelectStoresIncludeDisabled();

            repositoryItemLookUpEditNotificationType.DataSource = notificationTypes;
            repositoryItemLookUpEditStore.DataSource = stores;
            repositoryItemLookUpEditRecipientNotificationType.DataSource = notificationTypes;
            repositoryItemLookUpEditRole.DataSource = roles;
            repositoryItemLookUpEditRecipientStore.DataSource = stores;

            await dbContext.NotificationRules
                .Include(x => x.NotificationType)
                .Include(x => x.DcStore)
                .OrderBy(x => x.NotificationType.CategoryCode)
                .ThenBy(x => x.NotificationType.DisplayOrder)
                .ThenBy(x => x.StoreCode)
                .LoadAsync();

            notificationRuleBindingSource.DataSource = dbContext.NotificationRules.Local.ToBindingList();

            allRecipientRules = await dbContext.NotificationRecipientRules
                .Include(x => x.NotificationType)
                .Include(x => x.DcRole)
                .Include(x => x.DcStore)
                .OrderBy(x => x.NotificationType.CategoryCode)
                .ThenBy(x => x.NotificationType.DisplayOrder)
                .ThenBy(x => x.RoleCode)
                .ThenBy(x => x.StoreCode)
                .ToListAsync();

            RefreshRecipientGrid();

            if (!layoutLoaded)
            {
                gV_NotificationRules.BestFitColumns();
                gV_RecipientRules.BestFitColumns();
            }
        }

        private void RefreshRecipientGrid()
        {
            NotificationRule? rule = FocusedRule();
            if (rule != null && !string.IsNullOrWhiteSpace(rule.NotificationTypeCode))
            {
                recipientRuleBindingSource.DataSource = allRecipientRules
                    .Where(x => x.NotificationTypeCode == rule.NotificationTypeCode)
                    .ToList();
            }
            else
            {
                recipientRuleBindingSource.DataSource = allRecipientRules;
            }
        }

        private NotificationRule? FocusedRule()
        {
            return gV_NotificationRules.GetFocusedRow() as NotificationRule;
        }

        private NotificationRecipientRule? FocusedRecipientRule()
        {
            return gV_RecipientRules.GetFocusedRow() as NotificationRecipientRule;
        }

        #region NotificationRule CRUD

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationType? selectedType = FocusedRule()?.NotificationType ?? notificationTypes.FirstOrDefault();
            NotificationRule rule = new()
            {
                RuleName = selectedType?.NotificationTypeDesc ?? string.Empty,
                NotificationTypeCode = selectedType?.NotificationTypeCode ?? string.Empty,
                StoreCode = null,
                IsEnabled = true,
                ThrottleMinutes = 60,
                ChannelCodes = NotificationChannels.InApp,
                PopupMinSeverity = NotificationSeverities.High,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode,
                LastUpdatedUserName = Authorization.CurrAccCode
            };

            dbContext.NotificationRules.Add(rule);
            notificationRuleBindingSource.MoveLast();
            gV_NotificationRules.FocusedColumn = colStoreCode;
            gV_NotificationRules.ShowEditor();
        }

        private async void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            if (dbContext == null)
                return;

            gV_NotificationRules.PostEditor();
            gV_NotificationRules.UpdateCurrentRow();
            gV_RecipientRules.PostEditor();
            gV_RecipientRules.UpdateCurrentRow();

            if (!ValidateRules())
                return;

            if (!ValidateRecipientRules())
                return;

            PrepareAuditFields();
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();

            XtraMessageBox.Show(
                Resources.Common_SavedSuccessfully,
                Resources.Form_NotificationRule,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PrepareAuditFields()
        {
            if (dbContext == null)
                return;

            DateTime now = DateTime.Now;
            foreach (var entry in dbContext.ChangeTracker.Entries<NotificationRule>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = now;
                    entry.Entity.CreatedUserName = Authorization.CurrAccCode;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.ChannelCodes = NormalizeChannelCodes(entry.Entity.ChannelCodes);
                    entry.Entity.RuleName = entry.Entity.RuleName.Trim();
                    entry.Entity.NotificationTypeCode = entry.Entity.NotificationTypeCode.Trim();
                    entry.Entity.StoreCode = string.IsNullOrWhiteSpace(entry.Entity.StoreCode)
                        ? null
                        : entry.Entity.StoreCode.Trim();
                    entry.Entity.PopupMinSeverity = string.IsNullOrWhiteSpace(entry.Entity.PopupMinSeverity)
                        ? NotificationSeverities.High
                        : entry.Entity.PopupMinSeverity.Trim();
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }

            foreach (var entry in dbContext.ChangeTracker.Entries<NotificationRecipientRule>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = now;
                    entry.Entity.CreatedUserName = Authorization.CurrAccCode;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.NotificationTypeCode = entry.Entity.NotificationTypeCode.Trim();
                    entry.Entity.RoleCode = entry.Entity.RoleCode.Trim();
                    entry.Entity.StoreCode = string.IsNullOrWhiteSpace(entry.Entity.StoreCode)
                        ? null
                        : entry.Entity.StoreCode.Trim();
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }
        }

        private bool ValidateRules()
        {
            if (dbContext == null)
                return false;

            List<NotificationRule> rules = dbContext.ChangeTracker
                .Entries<NotificationRule>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (NotificationRule rule in rules)
            {
                if (string.IsNullOrWhiteSpace(rule.RuleName)
                    || string.IsNullOrWhiteSpace(rule.NotificationTypeCode)
                    || rule.ThrottleMinutes < 0)
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(NormalizeChannelCodes(rule.ChannelCodes)))
                {
                    XtraMessageBox.Show(Resources.Form_NotificationRule_InvalidChannel, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = rules
                .GroupBy(
                    x => new
                    {
                        NotificationTypeCode = x.NotificationTypeCode.Trim().ToUpperInvariant(),
                        StoreCode = string.IsNullOrWhiteSpace(x.StoreCode) ? string.Empty : x.StoreCode.Trim().ToUpperInvariant()
                    })
                .Any(x => x.Count() > 1);

            if (hasDuplicate)
            {
                XtraMessageBox.Show(Resources.Form_NotificationRule_DuplicateRule, Resources.Common_Attention);
                return false;
            }

            return true;
        }

        private string NormalizeChannelCodes(string? channelCodes)
        {
            if (string.IsNullOrWhiteSpace(channelCodes))
                return string.Empty;

            HashSet<string> selected = channelCodes
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(x => validChannels.Contains(x, StringComparer.OrdinalIgnoreCase))
                .Select(x => validChannels.First(validChannel => string.Equals(validChannel, x, StringComparison.OrdinalIgnoreCase)))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return string.Join(",", validChannels.Where(selected.Contains));
        }

        private async void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationRule? rule = FocusedRule();
            if (rule == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            if (XtraMessageBox.Show(
                    Resources.Common_DeleteConfirm,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            dbContext.NotificationRules.Remove(rule);
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();
        }

        #endregion

        #region NotificationRecipientRule CRUD

        private void bBI_NewRecipient_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationRule? selectedRule = FocusedRule();
            string notificationTypeCode = selectedRule?.NotificationTypeCode ?? notificationTypes.FirstOrDefault()?.NotificationTypeCode ?? string.Empty;
            DcRole? defaultRole = roles.FirstOrDefault(x => x.RoleCode == "Admin") ?? roles.FirstOrDefault();

            NotificationRecipientRule recipientRule = new()
            {
                NotificationTypeCode = notificationTypeCode,
                RoleCode = defaultRole?.RoleCode ?? string.Empty,
                StoreCode = null,
                IsEnabled = true,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode,
                LastUpdatedUserName = Authorization.CurrAccCode
            };

            dbContext.NotificationRecipientRules.Add(recipientRule);
            allRecipientRules.Add(recipientRule);
            RefreshRecipientGrid();
            recipientRuleBindingSource.MoveLast();
            gV_RecipientRules.FocusedColumn = colRecipientRoleCode;
            gV_RecipientRules.ShowEditor();
        }

        private async void bBI_DeleteRecipient_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationRecipientRule? recipientRule = FocusedRecipientRule();
            if (recipientRule == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            if (XtraMessageBox.Show(
                    Resources.Common_DeleteConfirm,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            dbContext.NotificationRecipientRules.Remove(recipientRule);
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();
        }

        private bool ValidateRecipientRules()
        {
            if (dbContext == null)
                return false;

            List<NotificationRecipientRule> recipientRules = dbContext.ChangeTracker
                .Entries<NotificationRecipientRule>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (NotificationRecipientRule rule in recipientRules)
            {
                if (string.IsNullOrWhiteSpace(rule.NotificationTypeCode)
                    || string.IsNullOrWhiteSpace(rule.RoleCode))
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = recipientRules
                .GroupBy(
                    x => new
                    {
                        NotificationTypeCode = x.NotificationTypeCode.Trim().ToUpperInvariant(),
                        RoleCode = x.RoleCode.Trim().ToUpperInvariant(),
                        StoreCode = string.IsNullOrWhiteSpace(x.StoreCode) ? string.Empty : x.StoreCode.Trim().ToUpperInvariant()
                    })
                .Any(x => x.Count() > 1);

            if (hasDuplicate)
            {
                XtraMessageBox.Show(Resources.Form_NotificationRecipientRule_DuplicateRule, Resources.Common_Attention);
                return false;
            }

            return true;
        }

        private void gV_RecipientRules_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            NotificationRecipientRule? rule = gV_RecipientRules.GetRow(e.RowHandle) as NotificationRecipientRule;
            if (rule == null)
                return;

            if (!rule.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_RecipientRules_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            NotificationRecipientRule? rule = e.Row as NotificationRecipientRule;
            if (rule == null)
                return;

            if (string.IsNullOrWhiteSpace(rule.NotificationTypeCode))
            {
                e.Valid = false;
                gV_RecipientRules.SetColumnError(colRecipientNotificationTypeCode, Resources.Validation_Required);
            }

            if (string.IsNullOrWhiteSpace(rule.RoleCode))
            {
                e.Valid = false;
                gV_RecipientRules.SetColumnError(colRecipientRoleCode, Resources.Validation_Required);
            }
        }

        private void gV_RecipientRules_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private async void gC_RecipientRules_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                await LoadDataAsync();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.S && e.Control)
            {
                await SaveAsync();
                e.Handled = true;
            }
        }

        #endregion

        #region NotificationRule Grid Events

        private async void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void bBI_Cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Resources.Form_NotificationRule, gC_NotificationRules);
        }

        private async void gC_NotificationRules_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                await LoadDataAsync();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.S && e.Control)
            {
                await SaveAsync();
                e.Handled = true;
            }
        }

        private void gV_NotificationRules_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colNotificationTypeCode)
                return;

            NotificationRule? rule = gV_NotificationRules.GetRow(e.RowHandle) as NotificationRule;
            if (rule == null || !string.IsNullOrWhiteSpace(rule.RuleName))
                return;

            NotificationType? notificationType = notificationTypes.FirstOrDefault(x => x.NotificationTypeCode == rule.NotificationTypeCode);
            if (notificationType != null)
                rule.RuleName = notificationType.NotificationTypeDesc;
        }

        private void gV_NotificationRules_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            RefreshRecipientGrid();
        }

        private void gV_NotificationRules_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            NotificationRule? rule = gV_NotificationRules.GetRow(e.RowHandle) as NotificationRule;
            if (rule == null)
                return;

            if (!rule.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_NotificationRules_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            NotificationRule? rule = e.Row as NotificationRule;
            if (rule == null)
                return;

            if (string.IsNullOrWhiteSpace(rule.RuleName))
            {
                e.Valid = false;
                gV_NotificationRules.SetColumnError(colRuleName, Resources.Validation_Required);
            }

            if (string.IsNullOrWhiteSpace(rule.NotificationTypeCode))
            {
                e.Valid = false;
                gV_NotificationRules.SetColumnError(colNotificationTypeCode, Resources.Validation_Required);
            }

            if (rule.ThrottleMinutes < 0)
            {
                e.Valid = false;
                gV_NotificationRules.SetColumnError(colThrottleMinutes, Resources.Common_InvalidNumber);
            }

            if (string.IsNullOrWhiteSpace(NormalizeChannelCodes(rule.ChannelCodes)))
            {
                e.Valid = false;
                gV_NotificationRules.SetColumnError(colChannelCodes, Resources.Form_NotificationRule_InvalidChannel);
            }
        }

        private void gV_NotificationRules_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gV_NotificationRules_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu? menu = e.Menu as GridViewColumnMenu;
                if (menu?.Column != null)
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));
            }
        }

        #endregion

        #region Layout & Helpers

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
            string fileName = "FormNotificationRuleLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_NotificationRules.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormNotificationRuleLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_NotificationRules.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private void FormNotificationRule_FormClosed(object sender, FormClosedEventArgs e)
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

        #endregion
    }
}
