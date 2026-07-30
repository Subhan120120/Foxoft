using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormNotificationTemplate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly EfMethods efMethods = new();

        private subContext? dbContext;
        private List<NotificationType> notificationTypes = new();
        private bool layoutLoaded;

        public FormNotificationTemplate()
        {
            InitializeComponent();
            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationTemplate;
            ribbonPage1.Text = Resources.Form_NotificationTemplate;
            ribbonPageGroupTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            ribbonPageGroupData.Text = Resources.Form_NotificationTemplate_Data;
        }

        private async void FormNotificationTemplate_Load(object sender, EventArgs e)
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

            repositoryItemLookUpEditNotificationType.DataSource = notificationTypes;

            await dbContext.NotificationTemplates
                .Include(x => x.NotificationType)
                .OrderBy(x => x.NotificationType.CategoryCode)
                .ThenBy(x => x.NotificationType.DisplayOrder)
                .ThenBy(x => x.LanguageCode)
                .LoadAsync();

            notificationTemplateBindingSource.DataSource = dbContext.NotificationTemplates.Local.ToBindingList();

            if (!layoutLoaded)
                gV_NotificationTemplates.BestFitColumns();
        }

        private NotificationTemplate? FocusedTemplate()
        {
            return gV_NotificationTemplates.GetFocusedRow() as NotificationTemplate;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationType? selectedType = FocusedTemplate()?.NotificationType ?? notificationTypes.FirstOrDefault();
            NotificationTemplate template = new()
            {
                NotificationTypeCode = selectedType?.NotificationTypeCode ?? string.Empty,
                LanguageCode = "az",
                TitleTemplate = string.Empty,
                BodyTemplate = string.Empty,
                IsEnabled = true,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode,
                LastUpdatedUserName = Authorization.CurrAccCode
            };

            dbContext.NotificationTemplates.Add(template);
            notificationTemplateBindingSource.MoveLast();
            gV_NotificationTemplates.FocusedColumn = colLanguageCode;
            gV_NotificationTemplates.ShowEditor();
        }

        private async void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            if (dbContext == null)
                return;

            gV_NotificationTemplates.PostEditor();
            gV_NotificationTemplates.UpdateCurrentRow();

            if (!ValidateTemplates())
                return;

            PrepareAuditFields();
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();

            XtraMessageBox.Show(
                Resources.Common_SavedSuccessfully,
                Resources.Form_NotificationTemplate,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PrepareAuditFields()
        {
            if (dbContext == null)
                return;

            DateTime now = DateTime.Now;
            foreach (var entry in dbContext.ChangeTracker.Entries<NotificationTemplate>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = now;
                    entry.Entity.CreatedUserName = Authorization.CurrAccCode;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.NotificationTypeCode = entry.Entity.NotificationTypeCode.Trim();
                    entry.Entity.LanguageCode = entry.Entity.LanguageCode.Trim();
                    entry.Entity.TitleTemplate = entry.Entity.TitleTemplate.Trim();
                    entry.Entity.BodyTemplate = entry.Entity.BodyTemplate.Trim();
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }
        }

        private bool ValidateTemplates()
        {
            if (dbContext == null)
                return false;

            List<NotificationTemplate> templates = dbContext.ChangeTracker
                .Entries<NotificationTemplate>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (NotificationTemplate template in templates)
            {
                if (string.IsNullOrWhiteSpace(template.NotificationTypeCode)
                    || string.IsNullOrWhiteSpace(template.LanguageCode)
                    || string.IsNullOrWhiteSpace(template.TitleTemplate))
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = templates
                .GroupBy(
                    x => new
                    {
                        NotificationTypeCode = x.NotificationTypeCode.Trim().ToUpperInvariant(),
                        LanguageCode = x.LanguageCode.Trim().ToUpperInvariant()
                    })
                .Any(x => x.Count() > 1);

            if (hasDuplicate)
            {
                XtraMessageBox.Show(Resources.Form_NotificationTemplate_DuplicateTemplate, Resources.Common_Attention);
                return false;
            }

            return true;
        }

        private async void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            NotificationTemplate? template = FocusedTemplate();
            if (template == null)
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

            dbContext.NotificationTemplates.Remove(template);
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
            CustomExtensions.ExportToExcel(this, Resources.Form_NotificationTemplate, gC_NotificationTemplates);
        }

        private async void gC_NotificationTemplates_ProcessGridKey(object sender, KeyEventArgs e)
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

        private void gV_NotificationTemplates_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            NotificationTemplate? template = gV_NotificationTemplates.GetRow(e.RowHandle) as NotificationTemplate;
            if (template == null)
                return;

            if (!template.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_NotificationTemplates_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            NotificationTemplate? template = e.Row as NotificationTemplate;
            if (template == null)
                return;

            if (string.IsNullOrWhiteSpace(template.NotificationTypeCode))
            {
                e.Valid = false;
                gV_NotificationTemplates.SetColumnError(colNotificationTypeCode, Resources.Validation_Required);
            }

            if (string.IsNullOrWhiteSpace(template.LanguageCode))
            {
                e.Valid = false;
                gV_NotificationTemplates.SetColumnError(colLanguageCode, Resources.Validation_Required);
            }

            if (string.IsNullOrWhiteSpace(template.TitleTemplate))
            {
                e.Valid = false;
                gV_NotificationTemplates.SetColumnError(colTitleTemplate, Resources.Validation_Required);
            }
        }

        private void gV_NotificationTemplates_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gV_NotificationTemplates_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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
            string fileName = "FormNotificationTemplateLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_NotificationTemplates.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormNotificationTemplateLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_NotificationTemplates.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private void FormNotificationTemplate_FormClosed(object sender, FormClosedEventArgs e)
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
