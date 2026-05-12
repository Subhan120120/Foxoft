using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormNotificationSettings : XtraForm
    {
        public FormNotificationSettings()
        {
            InitializeComponent();
            DesignComponentNames();
            LoadSettings();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_NotificationSettings;

            // Row labels
            lblReminder.Text = Resources.Form_NotificationSettings_InstallmentReminder;
            lblDueDay.Text = Resources.Form_NotificationSettings_InstallmentDueDay;
            lblPurchase.Text = Resources.Form_NotificationSettings_ProductPurchase;
            lblClosed.Text = Resources.Form_NotificationSettings_CreditClosed;
            lblPayment.Text = Resources.Form_NotificationSettings_CreditPayment;
            lblBirthday.Text = Resources.Form_NotificationSettings_Birthday;

            // Days before label
            lblDaysBefore.Text = Resources.Form_NotificationSettings_DaysBefore;

            // SMS labels
            string smsLabel = Resources.Form_NotificationSettings_MessageTemplate;
            lblSmsReminder.Text = smsLabel;
            lblSmsDueDay.Text = smsLabel;
            lblSmsPurchase.Text = smsLabel;
            lblSmsClosed.Text = smsLabel;
            lblSmsPayment.Text = smsLabel;
            lblSmsBirthday.Text = smsLabel;

            // Buttons
            btnSave.Text = Resources.Form_NotificationSettings_Save;
            btnSendNow.Text = Resources.Form_NotificationSettings_SendNow;
        }

        private void LoadSettings()
        {
            using var db = new subContext();
            var settings = db.DcNotificationSettings.ToList();

            var reminder = settings.FirstOrDefault(s => s.NotificationType == "InstallmentReminder");
            if (reminder != null)
            {
                toggleReminder.IsOn = reminder.IsEnabled;
                spinDaysBefore.Value = reminder.DaysBefore ?? 2;
                memoReminder.Text = reminder.MessageTemplate ?? "";
            }

            var dueDay = settings.FirstOrDefault(s => s.NotificationType == "InstallmentDueDay");
            if (dueDay != null)
            {
                toggleDueDay.IsOn = dueDay.IsEnabled;
                memoDueDay.Text = dueDay.MessageTemplate ?? "";
            }

            var purchase = settings.FirstOrDefault(s => s.NotificationType == "ProductPurchase");
            if (purchase != null)
            {
                togglePurchase.IsOn = purchase.IsEnabled;
                memoPurchase.Text = purchase.MessageTemplate ?? "";
            }

            var closed = settings.FirstOrDefault(s => s.NotificationType == "CreditClosed");
            if (closed != null)
            {
                toggleClosed.IsOn = closed.IsEnabled;
                memoClosed.Text = closed.MessageTemplate ?? "";
            }

            var payment = settings.FirstOrDefault(s => s.NotificationType == "CreditPayment");
            if (payment != null)
            {
                togglePayment.IsOn = payment.IsEnabled;
                memoPayment.Text = payment.MessageTemplate ?? "";
            }

            var birthday = settings.FirstOrDefault(s => s.NotificationType == "Birthday");
            if (birthday != null)
            {
                toggleBirthday.IsOn = birthday.IsEnabled;
                memoBirthday.Text = birthday.MessageTemplate ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            XtraMessageBox.Show(Resources.Common_Save, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveSettings()
        {
            using var db = new subContext();
            var settings = db.DcNotificationSettings.ToList();

            UpdateSetting(settings, "InstallmentReminder", toggleReminder.IsOn, memoReminder.Text, (int)spinDaysBefore.Value);
            UpdateSetting(settings, "InstallmentDueDay", toggleDueDay.IsOn, memoDueDay.Text, null);
            UpdateSetting(settings, "ProductPurchase", togglePurchase.IsOn, memoPurchase.Text, null);
            UpdateSetting(settings, "CreditClosed", toggleClosed.IsOn, memoClosed.Text, null);
            UpdateSetting(settings, "CreditPayment", togglePayment.IsOn, memoPayment.Text, null);
            UpdateSetting(settings, "Birthday", toggleBirthday.IsOn, memoBirthday.Text, null);

            db.SaveChanges();
        }

        private void UpdateSetting(System.Collections.Generic.List<DcNotificationSetting> settings,
            string type, bool isEnabled, string messageTemplate, int? daysBefore)
        {
            var setting = settings.FirstOrDefault(s => s.NotificationType == type);
            if (setting != null)
            {
                setting.IsEnabled = isEnabled;
                setting.MessageTemplate = messageTemplate;
                if (daysBefore.HasValue)
                    setting.DaysBefore = daysBefore.Value;
            }
        }

        private async void btnSendNow_Click(object sender, EventArgs e)
        {
            SaveSettings();

            btnSendNow.Enabled = false;
            btnSendNow.Text = Resources.Form_NotificationSettings_Sending;

            try
            {
                var service = new NotificationService();
                var result = await service.SendScheduledNotificationsAsync();

                string message = string.Format(Resources.Form_NotificationSettings_SendResult, result.Sent, result.Failed);
                XtraMessageBox.Show(message, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string message = string.Format(Resources.Form_NotificationSettings_SendFailed, ex.Message);
                XtraMessageBox.Show(message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendNow.Enabled = true;
                btnSendNow.Text = Resources.Form_NotificationSettings_SendNow;
            }
        }
    }
}
