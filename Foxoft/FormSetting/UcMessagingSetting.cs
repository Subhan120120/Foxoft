using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Drawing;
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

            lblAutoSend.Text = Resources.Form_MessagingSettings_AutoSendToggle;
            lblAutoSendInterval.Text = Resources.Form_MessagingSettings_IntervalSeconds;
            lblAutoSendMaxRetries.Text = Resources.Form_MessagingSettings_MaxRetries;
            lblServiceStatusTitle.Text = Resources.Form_MessagingSettings_ServiceStatus;
            btnStartService.Text = Resources.Form_MessagingSettings_ServiceStart;
            btnStopService.Text = Resources.Form_MessagingSettings_ServiceStop;

            lblSmsSectionTitle.Text = Resources.Form_MessagingSettings_SmsSection;
            lblSmsServerUrl.Text = Resources.Form_MessagingSettings_SmsServerUrl;
            lblSmsApiKey.Text = Resources.Form_MessagingSettings_SmsApiKey;
            lblSmsSenderTitle.Text = Resources.Form_MessagingSettings_SmsSenderTitle;

            btnSaveMessaging.Text = Resources.Form_MessagingSettings_Save;
            btnSendNow.Text = Resources.Form_MessagingSettings_SendNow;
        }

        public void LoadMessagingSettings()
        {
            using var db = new subContext();
            var settings = db.DcMessagingSettings.ToList();

            var reminder = settings.FirstOrDefault(s => s.MessagingType == "InstallmentReminder");
            if (reminder != null)
            {
                toggleReminder.IsOn = reminder.IsEnabled;
                spinDaysBefore.Value = reminder.DaysBefore ?? 2;
                memoReminder.Text = reminder.MessageTemplate ?? "";
            }

            var dueDay = settings.FirstOrDefault(s => s.MessagingType == "InstallmentDueDay");
            if (dueDay != null)
            {
                toggleDueDay.IsOn = dueDay.IsEnabled;
                memoDueDay.Text = dueDay.MessageTemplate ?? "";
            }

            var purchase = settings.FirstOrDefault(s => s.MessagingType == "ProductPurchase");
            if (purchase != null)
            {
                togglePurchase.IsOn = purchase.IsEnabled;
                memoPurchase.Text = purchase.MessageTemplate ?? "";
            }

            var closed = settings.FirstOrDefault(s => s.MessagingType == "CreditClosed");
            if (closed != null)
            {
                toggleClosed.IsOn = closed.IsEnabled;
                memoClosed.Text = closed.MessageTemplate ?? "";
            }

            var payment = settings.FirstOrDefault(s => s.MessagingType == "CreditPayment");
            if (payment != null)
            {
                togglePayment.IsOn = payment.IsEnabled;
                memoPayment.Text = payment.MessageTemplate ?? "";
            }

            var birthday = settings.FirstOrDefault(s => s.MessagingType == "Birthday");
            if (birthday != null)
            {
                toggleBirthday.IsOn = birthday.IsEnabled;
                memoBirthday.Text = birthday.MessageTemplate ?? "";
            }

            // Load Auto-Send AppSetting
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
            if (appSetting != null)
            {
                toggleAutoSend.IsOn = appSetting.AutoSendUnsentMessages;
                spinAutoSendInterval.Value = appSetting.AutoSendIntervalSeconds > 0 ? appSetting.AutoSendIntervalSeconds : 30;
                spinAutoSendMaxRetries.Value = appSetting.AutoSendMaxRetries > 0 ? appSetting.AutoSendMaxRetries : 5;
            }

            // Load SMS Provider Setting
            var smsSetting = db.DcSmsProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (smsSetting != null)
            {
                toggleSmsEnabled.IsOn = smsSetting.IsEnabled;
                txtSmsServerUrl.Text = smsSetting.ServerUrl ?? "";
                txtSmsApiKey.Text = smsSetting.ApiKey ?? "";
                txtSmsSenderTitle.Text = smsSetting.SenderTitle ?? "";
            }

            UpdateServiceStatusDisplay();
        }

        private void UpdateServiceStatusDisplay()
        {
            var status = NotificationWorkerManager.GetStatus();
            bool isRunning = status == NotificationWorkerStatus.RunningAsService || status == NotificationWorkerStatus.RunningAsProcess;

            if (isRunning)
            {
                lblServiceStatus.Text = Resources.Form_MessagingSettings_ServiceRunning;
                lblServiceStatus.ForeColor = Color.Green;
                btnStartService.Enabled = false;
                btnStopService.Enabled = true;
            }
            else
            {
                lblServiceStatus.Text = Resources.Form_MessagingSettings_ServiceStopped;
                lblServiceStatus.ForeColor = Color.DarkOrange;
                btnStartService.Enabled = true;
                btnStopService.Enabled = false;
            }
        }

        public void SaveMessagingSettings()
        {
            using var db = new subContext();
            var settings = db.DcMessagingSettings.ToList();

            UpdateMessagingSetting(settings, "InstallmentReminder", toggleReminder.IsOn, memoReminder.Text, (int)spinDaysBefore.Value);
            UpdateMessagingSetting(settings, "InstallmentDueDay", toggleDueDay.IsOn, memoDueDay.Text, null);
            UpdateMessagingSetting(settings, "ProductPurchase", togglePurchase.IsOn, memoPurchase.Text, null);
            UpdateMessagingSetting(settings, "CreditClosed", toggleClosed.IsOn, memoClosed.Text, null);
            UpdateMessagingSetting(settings, "CreditPayment", togglePayment.IsOn, memoPayment.Text, null);
            UpdateMessagingSetting(settings, "Birthday", toggleBirthday.IsOn, memoBirthday.Text, null);

            // Save Auto-Send AppSetting
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
            if (appSetting == null)
            {
                appSetting = new AppSetting { Id = 1 };
                db.AppSettings.Add(appSetting);
            }

            appSetting.AutoSendUnsentMessages = toggleAutoSend.IsOn;
            appSetting.AutoSendIntervalSeconds = (int)spinAutoSendInterval.Value;
            appSetting.AutoSendMaxRetries = (int)spinAutoSendMaxRetries.Value;

            Settings.Default.AppSetting = appSetting;
            Settings.Default.Save();

            // Save SMS Provider Setting
            var smsSetting = db.DcSmsProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (smsSetting == null)
            {
                smsSetting = new DcSmsProviderSetting { Id = 1, ProviderType = "GenericHttp" };
                db.DcSmsProviderSettings.Add(smsSetting);
            }

            smsSetting.IsEnabled = toggleSmsEnabled.IsOn;
            smsSetting.ServerUrl = txtSmsServerUrl.Text.Trim();
            smsSetting.ApiKey = txtSmsApiKey.Text.Trim();
            smsSetting.SenderTitle = txtSmsSenderTitle.Text.Trim();

            db.SaveChanges();
        }

        private void UpdateMessagingSetting(System.Collections.Generic.List<DcMessagingSetting> settings,
            string type, bool isEnabled, string messageTemplate, int? daysBefore)
        {
            var setting = settings.FirstOrDefault(s => s.MessagingType == type);
            if (setting != null)
            {
                setting.IsEnabled = isEnabled;
                setting.MessageTemplate = messageTemplate;
                if (daysBefore.HasValue)
                    setting.DaysBefore = daysBefore.Value;
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
                var service = new MessagingService();
                var result = await service.SendScheduledMessagesAsync();

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

        private void btnStartService_Click(object sender, EventArgs e)
        {
            bool started = NotificationWorkerManager.Start();
            System.Threading.Thread.Sleep(500);
            UpdateServiceStatusDisplay();

            if (started)
            {
                XtraMessageBox.Show("Xidmət uğurla başladıldı.", Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Xidmət başladıla bilmədi. İcra faylının mövcudluğunu yoxlayın.", Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            bool stopped = NotificationWorkerManager.Stop();
            System.Threading.Thread.Sleep(500);
            UpdateServiceStatusDisplay();

            if (stopped)
            {
                XtraMessageBox.Show("Xidmət dayandırıldı.", Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
