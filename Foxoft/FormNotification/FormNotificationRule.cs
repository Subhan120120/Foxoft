using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            NotificationChannels.WhatsApp,
            NotificationChannels.Email
        };

        private subContext? dbContext;
        private List<DcNotificationType> notificationTypes = new();
        private List<DcRole> roles = new();
        private List<DcNotificationTemplate> allTemplates = new();
        private List<DcNotificationRecipientRule> allRecipientRules = new();
        private bool isSyncingParameters;
        private bool isSyncingTemplateEditor;
        private bool layoutLoaded;

        private static readonly Dictionary<string, (string DisplayName, string[] Placeholders)> CommonTypePlaceholders = new(StringComparer.OrdinalIgnoreCase)
        {
            [NotificationTypeCodes.ProductStockWarning] = ("Məhsul Qalığı Xəbərdarlığı", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{AvailableQty}", "{WarningQty}", "{StoreDesc}" }),
            [NotificationTypeCodes.ProductOutOfStock] = ("Məhsul Bitib", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{StoreDesc}" }),
            [NotificationTypeCodes.NegativeStock] = ("Mənfi Qalıq", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{AvailableQty}", "{StoreDesc}" }),
            [NotificationTypeCodes.OverStock] = ("Artıq Qalıq", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{AvailableQty}", "{StoreDesc}" }),
            [NotificationTypeCodes.ExpiredProduct] = ("Müddəti Bitmiş Məhsul", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{StoreDesc}" }),
            [NotificationTypeCodes.ProductExpireSoon] = ("Müddəti Bitmək Üzrə", new[] { "{ProductCode}", "{ProductDesc}", "{WarehouseDesc}", "{StoreDesc}" }),
            [NotificationTypeCodes.InstallmentDueSoon] = ("Taksit Xatırlatması", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{day}", "{DueDate}", "{MonthlyPayment}", "{RemainingBalance}", "{DocumentNumber}" }),
            [NotificationTypeCodes.InstallmentDueToday] = ("Taksit Ödəniş Günü", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{DueDate}", "{MonthlyPayment}", "{RemainingBalance}", "{DocumentNumber}" }),
            [NotificationTypeCodes.InstallmentOverdue] = ("Gecikmiş Taksit", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{DueDate}", "{MonthlyPayment}", "{RemainingBalance}", "{DocumentNumber}" }),
            [NotificationTypeCodes.InstallmentPaid] = ("Taksit Ödəndi", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{paid}", "{debit}", "{DocumentNumber}" }),
            [NotificationTypeCodes.CreditClosed] = ("Kredit Bağlandı", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{DocumentNumber}" }),
            [NotificationTypeCodes.ProductPurchase] = ("Məhsul Satışı", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{InvoiceNo}", "{TotalAmount}" }),
            [NotificationTypeCodes.CustomerBirthday] = ("Müştəri Ad Günü", new[] { "{CustomerName}", "{StoreDesc}", "{StorePhone}" }),
            [NotificationTypeCodes.LargeSaleCreated] = ("Böyük Satış", new[] { "{CustomerName}", "{StoreDesc}", "{InvoiceNo}", "{TotalAmount}" }),
            [NotificationTypeCodes.CustomerCreditLimitExceeded] = ("Limit Aşıldı", new[] { "{CustomerName}", "{StoreDesc}", "{CurrentBalance}", "{CreditLimit}" }),
            [NotificationTypeCodes.BackupFailed] = ("Nüsxələmə Uğursuz", new[] { "{ErrorMessage}", "{DatabaseName}", "{Date}" }),
            [NotificationTypeCodes.IntegrationFailed] = ("İnteqrasiya Uğursuz", new[] { "{ErrorMessage}", "{Date}" }),
            [NotificationTypeCodes.SyncFailed] = ("Sinxronizasiya Xətası", new[] { "{ErrorMessage}", "{Date}" }),
            [NotificationTypeCodes.LicenseExpireSoon] = ("Lisenziya Bitir", new[] { "{Date}", "{DaysLeft}" })
        };

        private static readonly string[] GenericPlaceholders =
        {
            "{CustomerName}", "{StoreDesc}", "{StorePhone}", "{Amount}", "{DueDate}", "{Date}"
        };

        public FormNotificationRule()
        {
            InitializeComponent();
            DesignComponentNames();
        }

        public void SelectTemplatesTab()
        {
            if (tabDetailControl != null && tabTemplates != null)
                tabDetailControl.SelectedTabPage = tabTemplates;
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationRule_Title;
            ribbonPage1.Text = Resources.Form_NotificationRule_Title;
            ribbonPageGroupOperations.Text = Resources.Form_NotificationRule_Data;
            ribbonPageGroupRules.Text = Resources.Form_NotificationRule_Rules;
            ribbonPageGroupTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            ribbonPageGroupRecipients.Text = Resources.Form_NotificationRecipientRule_Rules;
            ribbonPageGroupExport.Text = Resources.Common_Export;
            groupControlRules.Text = Resources.Form_NotificationRule_Rules;
            tabParameters.Text = Resources.Form_NotificationRule_Parameters;
            tabTemplates.Text = Resources.Form_NotificationTemplate_Templates;
            tabRecipients.Text = Resources.Form_NotificationRecipientRule_Rules;
            groupControlTemplateEditor.Text = Resources.Form_NotificationRule_TemplateEditor;
            groupControlParameters.Text = Resources.Form_NotificationRule_Parameters;
            chkFilterSelectedTypeOnly.Text = Resources.Form_NotificationRule_FilterCurrentOnly;
            lblPlaceholdersTitle.Text = Resources.Form_NotificationRule_Placeholders;
            repositoryItemLookUpEditRecipientStore.NullText = Resources.Form_NotificationRecipientRule_AllStores;
            lueParamStore.Properties.NullText = Resources.Form_NotificationRule_AllStores;

            chkParamInApp.Text = Resources.Form_NotificationRule_Channel_InApp;
            chkParamPopup.Text = Resources.Form_NotificationRule_Channel_Popup;
            chkParamSms.Text = Resources.Form_NotificationRule_Channel_SMS;
            chkParamWhatsApp.Text = Resources.Form_NotificationRule_Channel_WhatsApp;
            chkParamEmail.Text = Resources.Form_NotificationRule_Channel_Email;

            cboParamSeverity.Properties.Items.Clear();
            cboParamSeverity.Properties.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem(NotificationLocalizer.GetSeverityName(NotificationSeverities.Info), NotificationSeverities.Info),
                new ImageComboBoxItem(NotificationLocalizer.GetSeverityName(NotificationSeverities.Warning), NotificationSeverities.Warning),
                new ImageComboBoxItem(NotificationLocalizer.GetSeverityName(NotificationSeverities.High), NotificationSeverities.High),
                new ImageComboBoxItem(NotificationLocalizer.GetSeverityName(NotificationSeverities.Critical), NotificationSeverities.Critical)
            });
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

            notificationTypes = await dbContext.DcNotificationTypes
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

            lueParamNotificationType.Properties.DataSource = notificationTypes;
            lueParamNotificationType.Properties.DisplayMember = nameof(DcNotificationType.LocalizedDescription);
            lueParamNotificationType.Properties.ValueMember = nameof(DcNotificationType.NotificationTypeCode);
            lueParamNotificationType.Properties.Columns.Clear();
            lueParamNotificationType.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcNotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedCategory), Resources.Entity_NotificationType_CategoryCode),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedDescription), Resources.Entity_NotificationType_Desc)
            });

            repositoryItemLookUpEditNotificationType.DataSource = notificationTypes;
            repositoryItemLookUpEditNotificationType.DisplayMember = nameof(DcNotificationType.LocalizedDescription);
            repositoryItemLookUpEditNotificationType.ValueMember = nameof(DcNotificationType.NotificationTypeCode);
            repositoryItemLookUpEditNotificationType.Columns.Clear();
            repositoryItemLookUpEditNotificationType.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcNotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedCategory), Resources.Entity_NotificationType_CategoryCode),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedDescription), Resources.Entity_NotificationType_Desc)
            });

            repositoryItemLookUpEditRecipientNotificationType.DataSource = notificationTypes;
            repositoryItemLookUpEditRecipientNotificationType.DisplayMember = nameof(DcNotificationType.LocalizedDescription);
            repositoryItemLookUpEditRecipientNotificationType.ValueMember = nameof(DcNotificationType.NotificationTypeCode);
            repositoryItemLookUpEditRecipientNotificationType.Columns.Clear();
            repositoryItemLookUpEditRecipientNotificationType.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcNotificationType.NotificationTypeCode), Resources.Entity_NotificationType_Code),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedCategory), Resources.Entity_NotificationType_CategoryCode),
                new LookUpColumnInfo(nameof(DcNotificationType.LocalizedDescription), Resources.Entity_NotificationType_Desc)
            });
            repositoryItemLookUpEditRole.DataSource = roles;
            repositoryItemLookUpEditRecipientStore.DataSource = stores;

            lueParamStore.Properties.DataSource = stores;
            lueParamStore.Properties.DisplayMember = nameof(DcCurrAcc.CurrAccDesc);
            lueParamStore.Properties.ValueMember = nameof(DcCurrAcc.CurrAccCode);
            lueParamStore.Properties.Columns.Clear();
            lueParamStore.Properties.Columns.AddRange(new LookUpColumnInfo[] {
                new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccCode), Resources.Entity_CurrAcc_Code),
                new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccDesc), Resources.Entity_CurrAcc_Desc)
            });

            var languages = new[]
            {
                new { Code = "az", Name = "Azərbaycan" },
                new { Code = "en", Name = "English" },
                new { Code = "ru", Name = "Русский" }
            };
            repositoryItemLookUpEditLanguage.DataSource = languages;
            repositoryItemLookUpEditLanguage.DisplayMember = "Name";
            repositoryItemLookUpEditLanguage.ValueMember = "Code";

            await dbContext.DcNotificationRules
                .Include(x => x.DcNotificationType)
                .Include(x => x.DcStore)
                .OrderBy(x => x.DcNotificationType.CategoryCode)
                .ThenBy(x => x.DcNotificationType.DisplayOrder)
                .ThenBy(x => x.StoreCode)
                .LoadAsync();

            notificationRuleBindingSource.DataSource = dbContext.DcNotificationRules.Local.ToBindingList();

            allTemplates = await dbContext.DcNotificationTemplates
                .Include(x => x.DcNotificationType)
                .OrderBy(x => x.NotificationTypeCode)
                .ThenBy(x => x.LanguageCode)
                .ToListAsync();

            allRecipientRules = await dbContext.DcNotificationRecipientRules
                .Include(x => x.DcNotificationType)
                .Include(x => x.DcRole)
                .Include(x => x.DcStore)
                .OrderBy(x => x.DcNotificationType.CategoryCode)
                .ThenBy(x => x.DcNotificationType.DisplayOrder)
                .ThenBy(x => x.RoleCode)
                .ThenBy(x => x.StoreCode)
                .ToListAsync();

            SyncFocusedRuleDetails();

            if (!layoutLoaded)
            {
                gV_NotificationRules.BestFitColumns();
                gV_Templates.BestFitColumns();
                gV_RecipientRules.BestFitColumns();
            }
        }

        #region Selected Rule Details Synchronization

        private void SyncFocusedRuleDetails()
        {
            DcNotificationRule? rule = FocusedRule();
            UpdateHeaderBanner(rule);
            RefreshTemplatesGrid();
            RefreshRecipientGrid();
            SyncRuleParametersToForm(rule);
        }

        private void UpdateHeaderBanner(DcNotificationRule? rule)
        {
            if (rule != null)
            {
                string typeDesc = NotificationLocalizer.GetTypeDescription(rule.NotificationTypeCode, rule.DcNotificationType?.NotificationTypeDesc);
                string category = NotificationLocalizer.GetCategoryName(rule.DcNotificationType?.CategoryCode);
                string store = string.IsNullOrWhiteSpace(rule.StoreCode) ? Resources.Form_NotificationRule_AllStores : (rule.DcStore?.CurrAccDesc ?? rule.StoreCode);
                string channels = NotificationLocalizer.GetLocalizedChannelsString(rule.ChannelCodes);

                lblSelectedRuleTitle.Text = $"{rule.RuleName} ({typeDesc})";
                lblSelectedRuleSubtitle.Text = $"Kateqoriya: {category} | Filial: {store} | Kanallar: {channels}";
            }
            else
            {
                lblSelectedRuleTitle.Text = Resources.Form_NotificationRule;
                lblSelectedRuleSubtitle.Text = string.Empty;
            }
        }

        private void RefreshTemplatesGrid()
        {
            DcNotificationRule? rule = FocusedRule();
            string? typeCode = rule?.NotificationTypeCode;

            if (chkFilterSelectedTypeOnly.Checked && !string.IsNullOrWhiteSpace(typeCode))
            {
                templateBindingSource.DataSource = allTemplates
                    .Where(x => string.Equals(x.NotificationTypeCode, typeCode, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                colTemplateNotificationTypeCode.Visible = false;
            }
            else
            {
                templateBindingSource.DataSource = allTemplates;
                colTemplateNotificationTypeCode.Visible = true;
            }

            SyncTemplateEditorToFocused();
        }

        private void RefreshRecipientGrid()
        {
            DcNotificationRule? rule = FocusedRule();
            string? typeCode = rule?.NotificationTypeCode;

            if (!string.IsNullOrWhiteSpace(typeCode))
            {
                recipientRuleBindingSource.DataSource = allRecipientRules
                    .Where(x => string.Equals(x.NotificationTypeCode, typeCode, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                colRecipientNotificationTypeCode.Visible = false;
            }
            else
            {
                recipientRuleBindingSource.DataSource = allRecipientRules;
                colRecipientNotificationTypeCode.Visible = true;
            }
        }

        private void SyncRuleParametersToForm(DcNotificationRule? rule)
        {
            isSyncingParameters = true;
            try
            {
                if (rule == null)
                {
                    txtParamRuleName.Text = string.Empty;
                    lueParamNotificationType.EditValue = null;
                    lueParamStore.EditValue = null;
                    chkParamInApp.Checked = false;
                    chkParamPopup.Checked = false;
                    chkParamSms.Checked = false;
                    chkParamWhatsApp.Checked = false;
                    chkParamEmail.Checked = false;
                    seParamThrottle.Value = 60;
                    cboParamSeverity.EditValue = NotificationSeverities.Info;
                    chkParamIsEnabled.Checked = false;
                    groupControlParameters.Enabled = false;
                    return;
                }

                groupControlParameters.Enabled = true;
                txtParamRuleName.Text = rule.RuleName;
                lueParamNotificationType.EditValue = rule.NotificationTypeCode;
                lueParamStore.EditValue = rule.StoreCode;

                HashSet<string> channels = (rule.ChannelCodes ?? string.Empty)
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                chkParamInApp.Checked = channels.Contains(NotificationChannels.InApp);
                chkParamPopup.Checked = channels.Contains(NotificationChannels.Popup);
                chkParamSms.Checked = channels.Contains(NotificationChannels.Sms);
                chkParamWhatsApp.Checked = channels.Contains(NotificationChannels.WhatsApp);
                chkParamEmail.Checked = channels.Contains(NotificationChannels.Email);

                seParamThrottle.Value = rule.ThrottleMinutes;
                cboParamSeverity.EditValue = string.IsNullOrWhiteSpace(rule.PopupMinSeverity) ? NotificationSeverities.High : rule.PopupMinSeverity;
                chkParamIsEnabled.Checked = rule.IsEnabled;
            }
            finally
            {
                isSyncingParameters = false;
            }
        }

        private void SyncTemplateEditorToFocused()
        {
            isSyncingTemplateEditor = true;
            try
            {
                DcNotificationTemplate? template = FocusedTemplate();
                if (template == null)
                {
                    cboTemplateLanguage.EditValue = null;
                    chkTemplateIsEnabled.Checked = false;
                    txtTemplateTitle.Text = string.Empty;
                    meTemplateBody.Text = string.Empty;
                    lblCharCount.Text = "0 simvol | 0 SMS";
                    groupControlTemplateEditor.Enabled = false;
                    UpdatePlaceholdersPanel(null);
                    return;
                }

                groupControlTemplateEditor.Enabled = true;
                cboTemplateLanguage.EditValue = template.LanguageCode;
                chkTemplateIsEnabled.Checked = template.IsEnabled;
                txtTemplateTitle.Text = template.TitleTemplate;
                meTemplateBody.Text = template.BodyTemplate;
                UpdateCharCount(template.BodyTemplate);
                UpdatePlaceholdersPanel(template.NotificationTypeCode);
            }
            finally
            {
                isSyncingTemplateEditor = false;
            }
        }

        private void UpdatePlaceholdersPanel(string? notificationTypeCode)
        {
            panelPlaceholders.SuspendLayout();
            panelPlaceholders.Controls.Clear();

            string[] placeholders = GenericPlaceholders;
            if (!string.IsNullOrWhiteSpace(notificationTypeCode) &&
                CommonTypePlaceholders.TryGetValue(notificationTypeCode, out var info))
            {
                placeholders = info.Placeholders;
            }

            foreach (string tag in placeholders)
            {
                SimpleButton btn = new()
                {
                    Text = tag,
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(2, 2, 4, 2)
                };
                btn.Click += (s, e) => InsertPlaceholderIntoBody(tag);
                panelPlaceholders.Controls.Add(btn);
            }

            panelPlaceholders.ResumeLayout();
        }

        private void InsertPlaceholderIntoBody(string tag)
        {
            int selectionStart = meTemplateBody.SelectionStart;
            string currentText = meTemplateBody.Text ?? string.Empty;
            string newText = currentText.Insert(selectionStart, tag);
            meTemplateBody.Text = newText;
            meTemplateBody.SelectionStart = selectionStart + tag.Length;
            meTemplateBody.Focus();
        }

        private void UpdateCharCount(string? text)
        {
            int length = text?.Length ?? 0;
            if (length == 0)
            {
                lblCharCount.Text = "0 simvol | 0 SMS";
                return;
            }

            bool isUnicode = text!.Any(c => c > 127);
            int partSize = isUnicode ? (length <= 70 ? 70 : 67) : (length <= 160 ? 160 : 153);
            int smsCount = (int)Math.Ceiling((double)length / partSize);
            lblCharCount.Text = $"{length} simvol | {smsCount} SMS";
        }

        #endregion

        #region Helpers & Row Getters

        private DcNotificationRule? FocusedRule()
        {
            return gV_NotificationRules.GetFocusedRow() as DcNotificationRule;
        }

        private DcNotificationTemplate? FocusedTemplate()
        {
            return gV_Templates.GetFocusedRow() as DcNotificationTemplate;
        }

        private DcNotificationRecipientRule? FocusedRecipientRule()
        {
            return gV_RecipientRules.GetFocusedRow() as DcNotificationRecipientRule;
        }

        #endregion

        #region CRUD: NotificationRule

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            DcNotificationType? selectedType = FocusedRule()?.DcNotificationType ?? notificationTypes.FirstOrDefault();
            string defaultRuleName = selectedType?.LocalizedDescription ?? string.Empty;

            DcNotificationRule rule = new()
            {
                RuleName = defaultRuleName,
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

            dbContext.DcNotificationRules.Add(rule);
            notificationRuleBindingSource.MoveLast();
            SyncFocusedRuleDetails();

            tabDetailControl.SelectedTabPage = tabParameters;
            txtParamRuleName.Focus();
            txtParamRuleName.SelectAll();
        }

        private async void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dbContext == null)
                return;

            DcNotificationRule? rule = FocusedRule();
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

            dbContext.DcNotificationRules.Remove(rule);
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();
        }

        #endregion

        #region CRUD: NotificationTemplate

        private void bBI_NewTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddNewTemplate();
        }

        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            AddNewTemplate();
        }

        private void AddNewTemplate()
        {
            if (dbContext == null)
                return;

            DcNotificationRule? rule = FocusedRule();
            string notificationTypeCode = rule?.NotificationTypeCode ?? notificationTypes.FirstOrDefault()?.NotificationTypeCode ?? string.Empty;

            var existingLangs = allTemplates
                .Where(x => string.Equals(x.NotificationTypeCode, notificationTypeCode, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.LanguageCode)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            string defaultLang = "az";
            if (existingLangs.Contains("az"))
            {
                if (!existingLangs.Contains("ru")) defaultLang = "ru";
                else if (!existingLangs.Contains("en")) defaultLang = "en";
            }

            string defaultTitle = rule?.RuleName ?? NotificationLocalizer.GetTypeDescription(notificationTypeCode, rule?.DcNotificationType?.NotificationTypeDesc);

            DcNotificationTemplate template = new()
            {
                NotificationTypeCode = notificationTypeCode,
                LanguageCode = defaultLang,
                TitleTemplate = defaultTitle,
                BodyTemplate = string.Empty,
                IsEnabled = true,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode,
                LastUpdatedUserName = Authorization.CurrAccCode
            };

            dbContext.DcNotificationTemplates.Add(template);
            allTemplates.Add(template);
            RefreshTemplatesGrid();
            templateBindingSource.MoveLast();
            tabDetailControl.SelectedTabPage = tabTemplates;
            txtTemplateTitle.Focus();
        }

        private async void bBI_DeleteTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            await DeleteSelectedTemplateAsync();
        }

        private async void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            await DeleteSelectedTemplateAsync();
        }

        private async Task DeleteSelectedTemplateAsync()
        {
            if (dbContext == null)
                return;

            DcNotificationTemplate? template = FocusedTemplate();
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

            dbContext.DcNotificationTemplates.Remove(template);
            allTemplates.Remove(template);
            await dbContext.SaveChangesAsync();
            RefreshTemplatesGrid();
        }

        #endregion

        #region CRUD: NotificationRecipientRule

        private void bBI_NewRecipient_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddNewRecipient();
        }

        private void btnNewRecipient_Click(object sender, EventArgs e)
        {
            AddNewRecipient();
        }

        private void AddNewRecipient()
        {
            if (dbContext == null)
                return;

            DcNotificationRule? selectedRule = FocusedRule();
            string notificationTypeCode = selectedRule?.NotificationTypeCode ?? notificationTypes.FirstOrDefault()?.NotificationTypeCode ?? string.Empty;
            DcRole? defaultRole = roles.FirstOrDefault(x => x.RoleCode == "Admin") ?? roles.FirstOrDefault();

            DcNotificationRecipientRule recipientRule = new()
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

            dbContext.DcNotificationRecipientRules.Add(recipientRule);
            allRecipientRules.Add(recipientRule);
            RefreshRecipientGrid();
            recipientRuleBindingSource.MoveLast();
            tabDetailControl.SelectedTabPage = tabRecipients;
            gV_RecipientRules.FocusedColumn = colRecipientRoleCode;
            gV_RecipientRules.ShowEditor();
        }

        private async void bBI_DeleteRecipient_ItemClick(object sender, ItemClickEventArgs e)
        {
            await DeleteSelectedRecipientAsync();
        }

        private async void btnDeleteRecipient_Click(object sender, EventArgs e)
        {
            await DeleteSelectedRecipientAsync();
        }

        private async Task DeleteSelectedRecipientAsync()
        {
            if (dbContext == null)
                return;

            DcNotificationRecipientRule? recipientRule = FocusedRecipientRule();
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

            dbContext.DcNotificationRecipientRules.Remove(recipientRule);
            allRecipientRules.Remove(recipientRule);
            await dbContext.SaveChangesAsync();
            RefreshRecipientGrid();
        }

        #endregion

        #region Save & Validation

        private async void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            if (dbContext == null)
                return;

            gV_Templates.PostEditor();
            gV_Templates.UpdateCurrentRow();
            gV_RecipientRules.PostEditor();
            gV_RecipientRules.UpdateCurrentRow();

            if (!ValidateRules())
                return;

            if (!ValidateTemplates())
                return;

            if (!ValidateRecipientRules())
                return;

            PrepareAuditFields();
            await dbContext.SaveChangesAsync();
            await LoadDataAsync();

            XtraMessageBox.Show(
                Resources.Common_SavedSuccessfully,
                Resources.Form_NotificationRule_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PrepareAuditFields()
        {
            if (dbContext == null)
                return;

            DateTime now = DateTime.Now;
            foreach (var entry in dbContext.ChangeTracker.Entries<DcNotificationRule>())
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
                    entry.Entity.StoreCode = string.IsNullOrWhiteSpace(entry.Entity.StoreCode) ? null : entry.Entity.StoreCode.Trim();
                    entry.Entity.PopupMinSeverity = string.IsNullOrWhiteSpace(entry.Entity.PopupMinSeverity) ? NotificationSeverities.High : entry.Entity.PopupMinSeverity.Trim();
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }

            foreach (var entry in dbContext.ChangeTracker.Entries<DcNotificationTemplate>())
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
                    entry.Entity.BodyTemplate = entry.Entity.BodyTemplate?.Trim() ?? string.Empty;
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }

            foreach (var entry in dbContext.ChangeTracker.Entries<DcNotificationRecipientRule>())
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
                    entry.Entity.StoreCode = string.IsNullOrWhiteSpace(entry.Entity.StoreCode) ? null : entry.Entity.StoreCode.Trim();
                    entry.Entity.LastUpdatedDate = now;
                    entry.Entity.LastUpdatedUserName = Authorization.CurrAccCode;
                }
            }
        }

        private bool ValidateRules()
        {
            if (dbContext == null)
                return false;

            List<DcNotificationRule> rules = dbContext.ChangeTracker
                .Entries<DcNotificationRule>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (DcNotificationRule rule in rules)
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
                .GroupBy(x => new
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

        private bool ValidateTemplates()
        {
            if (dbContext == null)
                return false;

            List<DcNotificationTemplate> templates = dbContext.ChangeTracker
                .Entries<DcNotificationTemplate>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (DcNotificationTemplate template in templates)
            {
                if (string.IsNullOrWhiteSpace(template.NotificationTypeCode) ||
                    string.IsNullOrWhiteSpace(template.LanguageCode) ||
                    string.IsNullOrWhiteSpace(template.TitleTemplate))
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = templates
                .GroupBy(x => new
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

        private bool ValidateRecipientRules()
        {
            if (dbContext == null)
                return false;

            List<DcNotificationRecipientRule> recipientRules = dbContext.ChangeTracker
                .Entries<DcNotificationRecipientRule>()
                .Where(x => x.State != EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            foreach (DcNotificationRecipientRule rule in recipientRules)
            {
                if (string.IsNullOrWhiteSpace(rule.NotificationTypeCode)
                    || string.IsNullOrWhiteSpace(rule.RoleCode))
                {
                    XtraMessageBox.Show(Resources.Validation_Required, Resources.Common_Attention);
                    return false;
                }
            }

            bool hasDuplicate = recipientRules
                .GroupBy(x => new
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

        #endregion

        #region Event Handlers: Rules Grid

        private void gV_NotificationRules_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SyncFocusedRuleDetails();
        }

        private void gV_NotificationRules_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (gV_NotificationRules.GetRow(e.RowHandle) is DcNotificationRule rule && !rule.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_NotificationRules_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colNotificationCategoryCode)
            {
                e.DisplayText = NotificationLocalizer.GetCategoryName(e.Value?.ToString());
            }
            else if (e.Column == colNotificationTypeCode)
            {
                e.DisplayText = NotificationLocalizer.GetTypeDescription(e.Value?.ToString());
            }
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

        private void gV_NotificationRules_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                if (e.Menu is GridViewColumnMenu menu && menu.Column != null)
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));
            }
        }

        #endregion

        #region Event Handlers: Parameters Tab

        private void txtParamRuleName_TextChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                rule.RuleName = txtParamRuleName.Text;
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
                UpdateHeaderBanner(rule);
            }
        }

        private void lueParamNotificationType_EditValueChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                string newTypeCode = lueParamNotificationType.EditValue?.ToString() ?? string.Empty;
                rule.NotificationTypeCode = newTypeCode;
                rule.DcNotificationType = notificationTypes.FirstOrDefault(x => x.NotificationTypeCode == newTypeCode)!;

                if (string.IsNullOrWhiteSpace(txtParamRuleName.Text) && rule.DcNotificationType != null)
                {
                    txtParamRuleName.Text = rule.DcNotificationType.LocalizedDescription;
                    rule.RuleName = rule.DcNotificationType.LocalizedDescription;
                }

                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
                UpdateHeaderBanner(rule);
                RefreshTemplatesGrid();
                RefreshRecipientGrid();
            }
        }

        private void lueParamStore_EditValueChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                rule.StoreCode = lueParamStore.EditValue?.ToString();
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
                UpdateHeaderBanner(rule);
            }
        }

        private void chkParamChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                List<string> selected = new();
                if (chkParamInApp.Checked) selected.Add(NotificationChannels.InApp);
                if (chkParamPopup.Checked) selected.Add(NotificationChannels.Popup);
                if (chkParamSms.Checked) selected.Add(NotificationChannels.Sms);
                if (chkParamWhatsApp.Checked) selected.Add(NotificationChannels.WhatsApp);
                if (chkParamEmail.Checked) selected.Add(NotificationChannels.Email);

                rule.ChannelCodes = string.Join(",", selected);
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
                UpdateHeaderBanner(rule);
            }
        }

        private void seParamThrottle_ValueChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                rule.ThrottleMinutes = (int)seParamThrottle.Value;
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
            }
        }

        private void cboParamSeverity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                rule.PopupMinSeverity = cboParamSeverity.EditValue?.ToString() ?? NotificationSeverities.High;
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
            }
        }

        private void chkParamIsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (isSyncingParameters) return;
            DcNotificationRule? rule = FocusedRule();
            if (rule != null)
            {
                rule.IsEnabled = chkParamIsEnabled.Checked;
                gV_NotificationRules.RefreshRow(gV_NotificationRules.FocusedRowHandle);
            }
        }

        #endregion

        #region Event Handlers: Templates Tab & Editor

        private void chkFilterSelectedTypeOnly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTemplatesGrid();
        }

        private void gV_Templates_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SyncTemplateEditorToFocused();
        }

        private void gV_Templates_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SyncTemplateEditorToFocused();
        }

        private void gV_Templates_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (gV_Templates.GetRow(e.RowHandle) is DcNotificationTemplate template && !template.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private async void gC_Templates_ProcessGridKey(object sender, KeyEventArgs e)
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

        private void cboTemplateLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSyncingTemplateEditor)
                return;

            DcNotificationTemplate? template = FocusedTemplate();
            if (template != null)
            {
                template.LanguageCode = cboTemplateLanguage.EditValue?.ToString() ?? "az";
                gV_Templates.RefreshRow(gV_Templates.FocusedRowHandle);
            }
        }

        private void chkTemplateIsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (isSyncingTemplateEditor)
                return;

            DcNotificationTemplate? template = FocusedTemplate();
            if (template != null)
            {
                template.IsEnabled = chkTemplateIsEnabled.Checked;
                gV_Templates.RefreshRow(gV_Templates.FocusedRowHandle);
            }
        }

        private void txtTemplateTitle_TextChanged(object sender, EventArgs e)
        {
            if (isSyncingTemplateEditor)
                return;

            DcNotificationTemplate? template = FocusedTemplate();
            if (template != null)
            {
                template.TitleTemplate = txtTemplateTitle.Text;
                gV_Templates.RefreshRow(gV_Templates.FocusedRowHandle);
            }
        }

        private void meTemplateBody_TextChanged(object sender, EventArgs e)
        {
            UpdateCharCount(meTemplateBody.Text);

            if (isSyncingTemplateEditor)
                return;

            DcNotificationTemplate? template = FocusedTemplate();
            if (template != null)
            {
                template.BodyTemplate = meTemplateBody.Text;
                gV_Templates.RefreshRow(gV_Templates.FocusedRowHandle);
            }
        }

        #endregion

        #region Event Handlers: Recipients Tab

        private void gV_RecipientRules_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (gV_RecipientRules.GetRow(e.RowHandle) is DcNotificationRecipientRule rule && !rule.IsEnabled)
                e.Appearance.ForeColor = Color.Gray;
        }

        private void gV_RecipientRules_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (e.Row is not DcNotificationRecipientRule rule)
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

        #region Common & Layout

        private async void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabDetailControl.SelectedTabPage == tabTemplates)
                CustomExtensions.ExportToExcel(this, Resources.Form_NotificationTemplate, gC_Templates);
            else if (tabDetailControl.SelectedTabPage == tabRecipients)
                CustomExtensions.ExportToExcel(this, Resources.Form_NotificationRecipientRule, gC_RecipientRules);
            else
                CustomExtensions.ExportToExcel(this, Resources.Form_NotificationRule, gC_NotificationRules);
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
