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
    public partial class FormNotificationRecipientRule : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly EfMethods efMethods = new();

        private subContext? dbContext;
        private List<NotificationType> notificationTypes = new();
        private List<DcRole> roles = new();
        private bool layoutLoaded;

        public FormNotificationRecipientRule()
        {
            InitializeComponent();
            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationRecipientRule;
            ribbonPage1.Text = Resources.Form_NotificationRecipientRule;
            ribbonPageGroupRules.Text = Resources.Form_NotificationRecipientRule_Rules;
            ribbonPageGroupData.Text = Resources.Form_NotificationRecipientRule_Data;
            repositoryItemLookUpEditStore.NullText = Resources.Form_NotificationRecipientRule_AllStores;
        }

        private async void FormNotificationRecipientRule_Load(object sender, EventArgs e)
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

            repositoryItemLookUpEditNotificationType.DataSource = notificationTypes;
            repositoryItemLookUpEditRole.DataSource = roles;
            repositoryItemLookUpEditStore.DataSource = efMethods.SelectStoresIncludeDisabled();

            await dbContext.NotificationRecipientRules
                .Include(x => x.NotificationType)
                .Include(x => x.DcRole)
                .Include(x => x.DcStore)
                .OrderBy(x => x.NotificationType.CategoryCode)
                .ThenBy(x => x.NotificationType.DisplayOrder)
                .ThenBy(x => x.RoleCode)
                .ThenBy(x => x.StoreCode)
                .LoadAsync();

            recipientRuleBindingSource.DataSource = dbContext.NotificationRecipientRules.Local.ToBindingList();

            if (!layoutLoaded)
                gV_RecipientRules.BestFitColumns();
        }

        private NotificationRecipientRule? FocusedRule()
        {
            return gV_RecipientRules.GetFocusedRow() as NotificationRecipientRule;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationType? selectedType = FocusedRule()?.NotificationType ?? notificationTypes.FirstOrDefault();
            DcRole? selectedRole = roles.FirstOrDefault(x => x.RoleCode == "Admin") ?? roles.FirstOrDefault();

            NotificationRecipientRule rule = new()
            {
                NotificationTypeCode = selectedType?.NotificationTypeCode ?? string.Empty,
                RoleCode = selectedRole?.RoleCode ?? string.Empty,
                StoreCode = null,
                IsEnabled = true,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode,
                LastUpdatedUserName = Authorization.CurrAccCode
            };

            dbContext.NotificationRecipientRules.Add(rule);
            recipientRuleBindingSource.MoveLast();
            gV_RecipientRules.FocusedColumn = colRoleCode;
            gV_RecipientRules.ShowEditor();
        }

        private async void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            if (dbContext == null)
                return;

            gV_RecipientRules.PostEditor();
            gV_RecipientRules.UpdateCurrentRow();

            if (!ValidateRules())
                return;

            PrepareAuditFields();
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();

            XtraMessageBox.Show(
                Resources.Common_SavedSuccessfully,
                Resources.Form_NotificationRecipientRule,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PrepareAuditFields()
        {
            if (dbContext == null)
                return;

            DateTime now = DateTime.Now;
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

            List<NotificationRecipientRule> rules = dbContext.ChangeTracker
                .Entries<NotificationRecipientRule>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (NotificationRecipientRule rule in rules)
            {
                if (string.IsNullOrWhiteSpace(rule.NotificationTypeCode)
                    || string.IsNullOrWhiteSpace(rule.RoleCode))
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = rules
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

        private async void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationRecipientRule? rule = FocusedRule();
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

            dbContext.NotificationRecipientRules.Remove(rule);
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();
        }

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
            CustomExtensions.ExportToExcel(this, Resources.Form_NotificationRecipientRule, gC_RecipientRules);
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
                gV_RecipientRules.SetColumnError(colNotificationTypeCode, Resources.Validation_Required);
            }

            if (string.IsNullOrWhiteSpace(rule.RoleCode))
            {
                e.Valid = false;
                gV_RecipientRules.SetColumnError(colRoleCode, Resources.Validation_Required);
            }
        }

        private void gV_RecipientRules_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gV_RecipientRules_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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
            string fileName = "FormNotificationRecipientRuleLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_RecipientRules.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormNotificationRecipientRuleLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_RecipientRules.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private void FormNotificationRecipientRule_FormClosed(object sender, FormClosedEventArgs e)
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
