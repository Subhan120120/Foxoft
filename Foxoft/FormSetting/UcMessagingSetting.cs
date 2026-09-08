using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcMessagingSetting : XtraUserControl
    {
        public UcMessagingSetting()
        {
            InitializeComponent();
            DesignMessagingComponentNames();
        }

        private void UcMessagingSetting_Load(object sender, EventArgs e)
        {
            LoadMessagingSettings();
        }

        private void DesignMessagingComponentNames()
        {
            lblReminder.Text = Resources.Form_MessagingSettings_InstallmentReminder;
            lblDueDay.Text = Resources.Form_MessagingSettings_InstallmentDueDay;
            lblPurchase.Text = Resources.Form_MessagingSettings_ProductPurchase;
            lblClosed.Text = Resources.Form_MessagingSettings_CreditClosed;
            lblPayment.Text = Resources.Form_MessagingSettings_CreditPayment;
            lblBirthday.Text = Resources.Form_MessagingSettings_Birthday;

            lblDaysBefore.Text = Resources.Form_MessagingSettings_DaysBefore;

            string smsLabel = Resources.Form_MessagingSettings_MessageTemplate;
            lblSmsReminder.Text = smsLabel;
            lblSmsDueDay.Text = smsLabel;
            lblSmsPurchase.Text = smsLabel;
            lblSmsClosed.Text = smsLabel;
            lblSmsPayment.Text = smsLabel;
            lblSmsBirthday.Text = smsLabel;

            btnSaveMessaging.Text = Resources.Form_MessagingSettings_Save;
            btnSendNow.Text = Resources.Form_MessagingSettings_SendNow;
        }

        public void LoadMessagingSettings()
        {
            using var db = new subContext();
            var templates = db.NotificationTemplates.ToList();
            var rules = db.NotificationRules.Where(r => r.StoreCode == null).ToList();
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);

            spinDaysBefore.Value = appSetting?.InstallmentReminderDaysBefore ?? 2;

            LoadRow(templates, rules, NotificationTypeCodes.InstallmentDueSoon, toggleReminder, memoReminder);
            LoadRow(templates, rules, NotificationTypeCodes.InstallmentDueToday, toggleDueDay, memoDueDay);
            LoadRow(templates, rules, NotificationTypeCodes.ProductPurchase, togglePurchase, memoPurchase);
            LoadRow(templates, rules, NotificationTypeCodes.CreditClosed, toggleClosed, memoClosed);
            LoadRow(templates, rules, NotificationTypeCodes.InstallmentPaid, togglePayment, memoPayment);
            LoadRow(templates, rules, NotificationTypeCodes.CustomerBirthday, toggleBirthday, memoBirthday);
        }

        private void LoadRow(System.Collections.Generic.List<NotificationTemplate> templates,
            System.Collections.Generic.List<NotificationRule> rules,
            string typeCode, ToggleSwitch toggle, MemoEdit memo)
        {
            var template = templates.FirstOrDefault(t => t.NotificationTypeCode == typeCode && t.LanguageCode == "az")
                        ?? templates.FirstOrDefault(t => t.NotificationTypeCode == typeCode);
            var rule = rules.FirstOrDefault(r => r.NotificationTypeCode == typeCode);

            if (template != null)
            {
                memo.Text = template.BodyTemplate ?? string.Empty;
                toggle.IsOn = template.IsEnabled && (rule == null || rule.IsEnabled);
            }
            else if (rule != null)
            {
                toggle.IsOn = rule.IsEnabled;
            }
        }

        public void SaveMessagingSettings()
        {
            using var db = new subContext();
            var templates = db.NotificationTemplates.ToList();
            var rules = db.NotificationRules.Where(r => r.StoreCode == null).ToList();
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);

            if (appSetting != null)
            {
                appSetting.InstallmentReminderDaysBefore = (int)spinDaysBefore.Value;
            }

            SaveRow(db, templates, rules, NotificationTypeCodes.InstallmentDueSoon, toggleReminder.IsOn, memoReminder.Text, "Kredit ödənişinə xatırlatma");
            SaveRow(db, templates, rules, NotificationTypeCodes.InstallmentDueToday, toggleDueDay.IsOn, memoDueDay.Text, "Kredit ödəniş günü");
            SaveRow(db, templates, rules, NotificationTypeCodes.ProductPurchase, togglePurchase.IsOn, memoPurchase.Text, "Məhsul satışı");
            SaveRow(db, templates, rules, NotificationTypeCodes.CreditClosed, toggleClosed.IsOn, memoClosed.Text, "Kredit bağlandı");
            SaveRow(db, templates, rules, NotificationTypeCodes.InstallmentPaid, togglePayment.IsOn, memoPayment.Text, "Kredit ödənişi");
            SaveRow(db, templates, rules, NotificationTypeCodes.CustomerBirthday, toggleBirthday.IsOn, memoBirthday.Text, "Ad günü təbriki");

            db.SaveChanges();
        }

        private void SaveRow(subContext db,
            System.Collections.Generic.List<NotificationTemplate> templates,
            System.Collections.Generic.List<NotificationRule> rules,
            string typeCode, bool isEnabled, string bodyTemplate, string defaultTitle)
        {
            DateTime now = DateTime.Now;
            var template = templates.FirstOrDefault(t => t.NotificationTypeCode == typeCode && t.LanguageCode == "az");
            if (template != null)
            {
                template.BodyTemplate = bodyTemplate?.Trim() ?? string.Empty;
                template.IsEnabled = isEnabled;
                template.LastUpdatedDate = now;
                template.LastUpdatedUserName = Authorization.CurrAccCode;
            }
            else
            {
                template = new NotificationTemplate
                {
                    NotificationTypeCode = typeCode,
                    LanguageCode = "az",
                    TitleTemplate = defaultTitle,
                    BodyTemplate = bodyTemplate?.Trim() ?? string.Empty,
                    IsEnabled = isEnabled,
                    CreatedDate = now,
                    LastUpdatedDate = now,
                    CreatedUserName = Authorization.CurrAccCode,
                    LastUpdatedUserName = Authorization.CurrAccCode
                };
                db.NotificationTemplates.Add(template);
            }

            var rule = rules.FirstOrDefault(r => r.NotificationTypeCode == typeCode);
            if (rule != null)
            {
                rule.IsEnabled = isEnabled;
                if (!rule.ChannelCodes.Contains(NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase))
                {
                    rule.ChannelCodes = string.IsNullOrWhiteSpace(rule.ChannelCodes)
                        ? NotificationChannels.WhatsApp
                        : rule.ChannelCodes + "," + NotificationChannels.WhatsApp;
                }
                rule.LastUpdatedDate = now;
                rule.LastUpdatedUserName = Authorization.CurrAccCode;
            }
            else
            {
                var notifType = db.NotificationTypes.FirstOrDefault(x => x.NotificationTypeCode == typeCode);
                rule = new NotificationRule
                {
                    RuleName = notifType?.NotificationTypeDesc ?? typeCode,
                    NotificationTypeCode = typeCode,
                    StoreCode = null,
                    IsEnabled = isEnabled,
                    ThrottleMinutes = 1440,
                    ChannelCodes = NotificationChannels.InApp + "," + NotificationChannels.WhatsApp,
                    PopupMinSeverity = NotificationSeverities.High,
                    CreatedDate = now,
                    LastUpdatedDate = now,
                    CreatedUserName = Authorization.CurrAccCode,
                    LastUpdatedUserName = Authorization.CurrAccCode
                };
                db.NotificationRules.Add(rule);
            }
        }

        private void btnSaveMessaging_Click(object sender, EventArgs e)
        {
            SaveMessagingSettings();
            XtraMessageBox.Show(Resources.Common_Save, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSendNow_Click(object sender, EventArgs e)
        {
            SaveMessagingSettings();

            btnSendNow.Enabled = false;
            btnSendNow.Text = Resources.Form_MessagingSettings_Sending;

            try
            {
                using var db = new subContext();
                int daysBefore = (int)spinDaysBefore.Value;

                var installmentChecker = new NotificationInstallmentCheckerService(db);
                await installmentChecker.ScanInstallmentPaymentNotificationsAsync(daysBefore, Authorization.CurrAccCode);

                var customerChecker = new NotificationCustomerCheckerService(db);
                await customerChecker.ScanBirthdayNotificationsAsync(Authorization.CurrAccCode);

                var outboxService = new NotificationOutboxService(db);
                var result = await outboxService.ProcessPendingAsync();

                string message = string.Format(Resources.Form_MessagingSettings_SendResult, result.Sent, result.Failed);
                XtraMessageBox.Show(message, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string message = string.Format(Resources.Form_MessagingSettings_SendFailed, ex.Message);
                XtraMessageBox.Show(message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendNow.Enabled = true;
                btnSendNow.Text = Resources.Form_MessagingSettings_SendNow;
            }
        }
    }
}
