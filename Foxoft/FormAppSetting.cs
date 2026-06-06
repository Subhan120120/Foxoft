using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.IO;


namespace Foxoft
{
    public partial class FormAppSetting : XtraForm
    {
        subContext dbContext = new();
        AppSetting AppSetting;
        AdoMethods adoMethods = new();
        public class FindBy
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public FormAppSetting()
        {
            InitializeComponent();
            BindCheckedCombo();
        }

        private void FormAppSetting_Load(object sender, EventArgs e)
        {
            FillDataLayout();
        }


        private void BindCheckedCombo()
        {
            List<FindBy> list = new()
            {
                new() { Id = 1, Name = Resources.Entity_ProductBarcode_ProductCode },
                new() { Id = 2, Name = Resources.Common_Barcode },
                new() { Id = 3, Name = Resources.Entity_SerialNumber }
            };

            POSFindProductByCheckedComboBoxEdit.Properties.DataSource = list;
            POSFindProductByCheckedComboBoxEdit.Properties.ValueMember = nameof(FindBy.Id);
            POSFindProductByCheckedComboBoxEdit.Properties.DisplayMember = nameof(FindBy.Name);

            // Important for correct "value-based" operations
            POSFindProductByCheckedComboBoxEdit.Properties.SeparatorChar = ',';
        }

        private void SetSelectedIdsManual(string selectedIds)
        {
            POSFindProductByCheckedComboBoxEdit.Properties.Items.BeginUpdate();
            try
            {
                // Uncheck all first
                for (int i = 0; i < POSFindProductByCheckedComboBoxEdit.Properties.Items.Count; i++)
                    POSFindProductByCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Unchecked;

                if (string.IsNullOrWhiteSpace(selectedIds))
                    return;

                var set = selectedIds
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < POSFindProductByCheckedComboBoxEdit.Properties.Items.Count; i++)
                {
                    var val = POSFindProductByCheckedComboBoxEdit.Properties.Items[i].Value?.ToString();
                    if (val != null && set.Contains(val))
                        POSFindProductByCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Checked;
                }
            }
            finally
            {
                POSFindProductByCheckedComboBoxEdit.Properties.Items.EndUpdate();
            }
        }

        private DcWhatsAppProviderSetting WhatsAppProviderSetting;

        private void FillDataLayout()
        {
            dbContext = new subContext();

            WhatsAppProviderSetting = dbContext.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (WhatsAppProviderSetting == null)
            {
                WhatsAppProviderSetting = new DcWhatsAppProviderSetting { Id = 1 };
                dbContext.DcWhatsAppProviderSettings.Add(WhatsAppProviderSetting);
            }

            dcWhatsAppProviderSettingBindingSource.DataSource = WhatsAppProviderSetting;

            dbContext.AppSettings
                .Where(x => x.Id == 1)
                .LoadAsync()
                .ContinueWith(loadTask =>
                {
                    // If the load failed, throw so you see the real exception
                    if (loadTask.IsFaulted)
                        throw loadTask.Exception!;

                    // Bind source after load
                    appSettingBindingSource.DataSource = dbContext.AppSettings.Local.ToBindingList();

                    // Get the loaded entity (or create it if not exists)
                    AppSetting = dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1);
                    if (AppSetting is not null)
                        AppSetting.AppFontSize = AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize);

                    OverpaymentModeImageComboBoxEdit.EditValue = (int)AppSetting.OverpaymentMode;
                    // Now safe
                    SetSelectedIdsManual(AppSetting.POSFindProductBy);

                }, TaskScheduler.FromCurrentSynchronizationContext());

        }


        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // Ensure AppSetting is not null
            AppSetting ??= dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1)
                        ?? dbContext.AppSettings.FirstOrDefault(x => x.Id == 1);

            decimal previousFontSize = AppFontSettings.NormalizeFontSize(Settings.Default.AppSetting?.AppFontSize);

            appSettingBindingSource.EndEdit();
            AppSetting.POSFindProductBy = POSFindProductByCheckedComboBoxEdit.EditValue?.ToString()?.Trim() ?? "";
            AppSetting.AppFontSize = AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize);

            if (OverpaymentModeImageComboBoxEdit.EditValue is int modeVal)
                AppSetting.OverpaymentMode = (OverpaymentMode)modeVal;

            dcWhatsAppProviderSettingBindingSource.EndEdit();

            dbContext.SaveChanges();

            Settings.Default.AppSetting = AppSetting;
            Settings.Default.Save();

            if (AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize) != previousFontSize)
                XtraMessageBox.Show(Resources.Message_AppFontSizeRestartRequired, Resources.Common_Attention);
        }

        private void Btn_OptimizeDatabaseIndexes_Click(object sender, EventArgs e)
        {
            adoMethods.RebuldOrReorganizeDatabase();
            btn_OptimizeDatabaseIndexes.Text = string.Format(Resources.Entity_AppSetting_OptimizeDatabaseIndexes, adoMethods.DatabaseAVGFragmentationPercent());
        }

        private void Btn_ClearMemory_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async void Btn_WhatsAppQrCode_Click(object sender, EventArgs e)
        {
            if (!TryGetWhatsAppProviderSettings(out string serverUrl, out string instanceName, out string apiKey))
            {
                XtraMessageBox.Show(Resources.Message_WhatsAppQrCodeSettingsRequired, Resources.Common_Attention);
                return;
            }

            btn_WhatsAppQrCode.Enabled = false;
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
                btn_WhatsAppQrCode.Enabled = true;
            }
        }

        private async void Btn_WhatsAppLogout_Click(object sender, EventArgs e)
        {
            if (!TryGetWhatsAppProviderSettings(out string serverUrl, out string instanceName, out string apiKey))
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

            btn_WhatsAppLogout.Enabled = false;
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
                btn_WhatsAppLogout.Enabled = true;
            }
        }

        private bool TryGetWhatsAppProviderSettings(out string serverUrl, out string instanceName, out string apiKey)
        {
            dcWhatsAppProviderSettingBindingSource.EndEdit();

            serverUrl = ServerUrlTextEdit.EditValue?.ToString()?.Trim() ?? "";
            instanceName = InstanceNameTextEdit.EditValue?.ToString()?.Trim() ?? "";
            apiKey = ApiKeyTextEdit.EditValue?.ToString()?.Trim() ?? "";

            return !string.IsNullOrWhiteSpace(serverUrl) &&
                   !string.IsNullOrWhiteSpace(instanceName) &&
                   !string.IsNullOrWhiteSpace(apiKey);
        }

        private void ShowWhatsAppQrCode(EvolutionQrCodeResult qrCode)
        {
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

            WhatsAppQrCodeBarCodeControl.Text = qrCode.Code ?? "";
            WhatsAppQrCodePictureEdit.Visible = false;
            WhatsAppQrCodeBarCodeControl.Visible = true;
        }

        private void ClearWhatsAppQrCode()
        {
            Image? oldImage = WhatsAppQrCodePictureEdit.Image;
            WhatsAppQrCodePictureEdit.Image = null;
            oldImage?.Dispose();
            WhatsAppQrCodePictureEdit.Visible = false;
            WhatsAppQrCodeBarCodeControl.Text = "";
            WhatsAppQrCodeBarCodeControl.Visible = false;
        }

        private bool TryShowWhatsAppQrCodeImage(string base64)
        {
            try
            {
                Image image = CreateImageFromBase64(base64);
                Image? oldImage = WhatsAppQrCodePictureEdit.Image;
                WhatsAppQrCodePictureEdit.Image = image;
                oldImage?.Dispose();
                WhatsAppQrCodeBarCodeControl.Visible = false;
                WhatsAppQrCodePictureEdit.Visible = true;

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

        private void ServerUrlTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
