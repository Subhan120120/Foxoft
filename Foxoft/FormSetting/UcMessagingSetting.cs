using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            // SMS
            layoutControlGroupSms.Text = Resources.Form_MessagingSettings_SmsSection;
            ItemForSmsEnabled.Text = Resources.Form_MessagingSettings_SmsEnabled;
            ItemForSmsServerUrl.Text = Resources.Form_MessagingSettings_SmsServerUrl;
            ItemForSmsApiKey.Text = Resources.Form_MessagingSettings_SmsApiKey;
            ItemForSmsSenderTitle.Text = Resources.Form_MessagingSettings_SmsSenderTitle;

            // Auto-send & Service
            layoutControlGroupAutoSend.Text = Resources.Form_MessagingSettings_AutoSendSection;
            ItemForAutoSend.Text = Resources.Form_MessagingSettings_AutoSendToggle;
            ItemForAutoSendInterval.Text = Resources.Form_MessagingSettings_IntervalSeconds;
            ItemForAutoSendMaxRetries.Text = Resources.Form_MessagingSettings_MaxRetries;
            ItemForServiceStatus.Text = Resources.Form_MessagingSettings_ServiceStatus;
            btnStartService.Text = Resources.Form_MessagingSettings_ServiceStart;
            btnStopService.Text = Resources.Form_MessagingSettings_ServiceStop;

            // WhatsApp
            layoutControlGroupWhatsApp.Text = Resources.Form_AppSetting_Group_WhatsApp;
            ItemForUseWhatsApp.Text = Resources.Entity_AppSetting_UseWhatsApp;
            ItemForWhatsAppProvider.Text = Resources.Entity_AppSetting_WhatsAppProvider;
            ItemForWhatsappChromeProfileName.Text = Resources.Entity_AppSetting_WhatsappChromeProfileName;
            ItemForWhatsAppServerUrl.Text = Resources.Entity_DcWhatsAppProviderSetting_ServerUrl;
            ItemForWhatsAppInstanceName.Text = Resources.Entity_DcWhatsAppProviderSetting_InstanceName;
            ItemForWhatsAppApiKey.Text = Resources.Entity_DcWhatsAppProviderSetting_ApiKey;
            btnWhatsAppQrCode.Text = Resources.Form_AppSetting_WhatsAppGetQrCode;
            btnWhatsAppLogout.Text = Resources.Form_AppSetting_WhatsAppLogout;

            // Bottom panel
            btnSaveMessaging.Text = Resources.Form_MessagingSettings_Save;
            btnSendNow.Text = Resources.Form_MessagingSettings_SendNow;
        }

        public void LoadMessagingSettings()
        {
            using var db = new subContext();
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);

            // Load Auto-Send and WhatsApp AppSetting
            if (appSetting != null)
            {
                toggleAutoSend.IsOn = appSetting.AutoSendUnsentMessages;
                spinAutoSendInterval.Value = appSetting.AutoSendIntervalSeconds > 0 ? appSetting.AutoSendIntervalSeconds : 30;
                spinAutoSendMaxRetries.Value = appSetting.AutoSendMaxRetries > 0 ? appSetting.AutoSendMaxRetries : 5;

                toggleUseWhatsApp.IsOn = appSetting.UseWhatsApp;
                cmbWhatsAppProvider.EditValue = appSetting.WhatsAppProvider;
                txtWhatsappChromeProfileName.Text = appSetting.WhatsappChromeProfileName ?? "";
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

            // Load WhatsApp Provider Setting
            var whatsAppSetting = db.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (whatsAppSetting != null)
            {
                txtWhatsAppServerUrl.Text = whatsAppSetting.ServerUrl ?? "";
                txtWhatsAppInstanceName.Text = whatsAppSetting.InstanceName ?? "";
                txtWhatsAppApiKey.Text = whatsAppSetting.ApiKey ?? "";
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
            var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);

            if (appSetting == null)
            {
                appSetting = new AppSetting { Id = 1 };
                db.AppSettings.Add(appSetting);
            }

            // Auto-send
            appSetting.AutoSendUnsentMessages = toggleAutoSend.IsOn;
            appSetting.AutoSendIntervalSeconds = (int)spinAutoSendInterval.Value;
            appSetting.AutoSendMaxRetries = (int)spinAutoSendMaxRetries.Value;

            // WhatsApp on AppSetting
            appSetting.UseWhatsApp = toggleUseWhatsApp.IsOn;
            if (cmbWhatsAppProvider.EditValue is WhatsAppProvider provider)
                appSetting.WhatsAppProvider = provider;
            else if (cmbWhatsAppProvider.EditValue is byte providerByte)
                appSetting.WhatsAppProvider = (WhatsAppProvider)providerByte;
            else if (cmbWhatsAppProvider.EditValue is int providerInt)
                appSetting.WhatsAppProvider = (WhatsAppProvider)providerInt;
            appSetting.WhatsappChromeProfileName = txtWhatsappChromeProfileName.Text.Trim();

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

            // Save WhatsApp Provider Setting
            var whatsAppSetting = db.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (whatsAppSetting == null)
            {
                whatsAppSetting = new DcWhatsAppProviderSetting { Id = 1 };
                db.DcWhatsAppProviderSettings.Add(whatsAppSetting);
            }

            whatsAppSetting.ServerUrl = txtWhatsAppServerUrl.Text.Trim();
            whatsAppSetting.InstanceName = txtWhatsAppInstanceName.Text.Trim();
            whatsAppSetting.ApiKey = txtWhatsAppApiKey.Text.Trim();

            db.SaveChanges();

            NotificationWorkerManager.EnsureRunning(toggleAutoSend.IsOn);
            UpdateServiceStatusDisplay();
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
                var appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
                int daysBefore = appSetting?.InstallmentReminderDaysBefore ?? 2;

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

        private System.Windows.Forms.Timer? statusTimer;

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                UpdateServiceStatusDisplay();
                StartStatusTimer();
            }
            else
            {
                StopStatusTimer();
            }
        }

        private void StartStatusTimer()
        {
            if (statusTimer == null)
            {
                statusTimer = new System.Windows.Forms.Timer { Interval = 3000 };
                statusTimer.Tick += (s, ev) => UpdateServiceStatusDisplay();
            }
            statusTimer.Start();
        }

        private void StopStatusTimer()
        {
            statusTimer?.Stop();
        }

        private async void btnStartService_Click(object sender, EventArgs e)
        {
            btnStartService.Enabled = false;
            try
            {
                bool started = NotificationWorkerManager.Start();
                await Task.Delay(800);
                UpdateServiceStatusDisplay();

                if (started)
                {
                    XtraMessageBox.Show(Resources.Form_MessagingSettings_ServiceStartSuccess, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(Resources.Form_MessagingSettings_ServiceStartFailed, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                UpdateServiceStatusDisplay();
            }
        }

        private async void btnStopService_Click(object sender, EventArgs e)
        {
            btnStopService.Enabled = false;
            try
            {
                bool stopped = NotificationWorkerManager.Stop();
                await Task.Delay(800);
                UpdateServiceStatusDisplay();

                if (stopped)
                {
                    XtraMessageBox.Show(Resources.Form_MessagingSettings_ServiceStopSuccess, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                UpdateServiceStatusDisplay();
            }
        }

        private async void btnWhatsAppQrCode_Click(object sender, EventArgs e)
        {
            string serverUrl = txtWhatsAppServerUrl.Text.Trim();
            string instanceName = txtWhatsAppInstanceName.Text.Trim();
            string apiKey = txtWhatsAppApiKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(serverUrl) || string.IsNullOrWhiteSpace(instanceName) || string.IsNullOrWhiteSpace(apiKey))
            {
                XtraMessageBox.Show(Resources.Message_WhatsAppQrCodeSettingsRequired, Resources.Common_Attention);
                return;
            }

            btnWhatsAppQrCode.Enabled = false;
            try
            {
                using EvolutionApiClient client = new(serverUrl, instanceName, apiKey);
                EvolutionQrCodeResult qrCode = await client.GetConnectionQrCodeAsync();
                ShowWhatsAppQrCode(qrCode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Attention);
            }
            finally
            {
                btnWhatsAppQrCode.Enabled = true;
            }
        }

        private async void btnWhatsAppLogout_Click(object sender, EventArgs e)
        {
            string serverUrl = txtWhatsAppServerUrl.Text.Trim();
            string instanceName = txtWhatsAppInstanceName.Text.Trim();
            string apiKey = txtWhatsAppApiKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(serverUrl) || string.IsNullOrWhiteSpace(instanceName) || string.IsNullOrWhiteSpace(apiKey))
            {
                XtraMessageBox.Show(Resources.Message_WhatsAppLogoutSettingsRequired, Resources.Common_Attention);
                return;
            }

            DialogResult result = XtraMessageBox.Show(
                Resources.Message_WhatsAppLogoutConfirm,
                Resources.Common_Confirm,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            btnWhatsAppLogout.Enabled = false;
            try
            {
                using EvolutionApiClient client = new(serverUrl, instanceName, apiKey);
                await client.LogoutAsync();
                ClearWhatsAppQrCode();
                XtraMessageBox.Show(Resources.Message_WhatsAppLogoutSucceeded, Resources.Common_Attention);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Attention);
            }
            finally
            {
                btnWhatsAppLogout.Enabled = true;
            }
        }

        private void ShowWhatsAppQrCode(EvolutionQrCodeResult qrCode)
        {
            if (qrCode.IsConnected)
            {
                ClearWhatsAppQrCode();
                XtraMessageBox.Show(
                    Resources.Common_WhatsAppAlreadyConnected,
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!qrCode.HasQrCode)
            {
                XtraMessageBox.Show(string.Format(Resources.Message_WhatsAppQrCodeNotFound, qrCode.Body), Resources.Common_Attention);
                return;
            }

            if (!string.IsNullOrWhiteSpace(qrCode.Base64) && TryShowWhatsAppQrCodeImage(qrCode.Base64))
                return;

            if (string.IsNullOrWhiteSpace(qrCode.Code))
            {
                XtraMessageBox.Show(string.Format(Resources.Message_WhatsAppQrCodeNotFound, qrCode.Body), Resources.Common_Attention);
                return;
            }

            barcodeWhatsAppQrCode.Text = qrCode.Code ?? "";
            picWhatsAppQrCode.Visible = false;
            barcodeWhatsAppQrCode.Visible = true;
        }

        private void ClearWhatsAppQrCode()
        {
            Image? oldImage = picWhatsAppQrCode.Image;
            picWhatsAppQrCode.Image = null;
            oldImage?.Dispose();
            picWhatsAppQrCode.Visible = false;
            barcodeWhatsAppQrCode.Text = "";
            barcodeWhatsAppQrCode.Visible = false;
        }

        private bool TryShowWhatsAppQrCodeImage(string base64)
        {
            try
            {
                Image image = CreateImageFromBase64(base64);
                Image? oldImage = picWhatsAppQrCode.Image;
                picWhatsAppQrCode.Image = image;
                oldImage?.Dispose();
                barcodeWhatsAppQrCode.Visible = false;
                picWhatsAppQrCode.Visible = true;

                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static Image CreateImageFromBase64(string base64)
        {
            string imageBase64 = base64.Trim();
            int commaIndex = imageBase64.IndexOf(',');
            if (commaIndex >= 0)
                imageBase64 = imageBase64[(commaIndex + 1)..];

            byte[] bytes = Convert.FromBase64String(imageBase64);
            using MemoryStream stream = new(bytes);
            using Image image = Image.FromStream(stream);

            return new Bitmap(image);
        }
    }
}
