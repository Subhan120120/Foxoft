using DevExpress.Office.NumberConverters;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;

namespace Foxoft
{
    public partial class FormLogin : ToolbarForm
    {
        EfMethods efMethods = new();
        CustomMethods cM = new();

        public FormLogin()
        {
            InitializeComponent();

            LUE_Company.Properties.DataSource = efMethods.SelectCompanies();
            LUE_Language.Properties.DataSource = efMethods.SelectEntities<DcUILanguage>();
            LUE_Company.EditValue = Settings.Default.CompanyCode;

            AcceptButton = btn_ERP;

            LoadDataByDatabase();
        }

        private void LoadDataByDatabase()
        {
            AppSetting appSetting = efMethods.SelectEntityById<AppSetting>(1);
            Settings.Default.AppSetting = appSetting;
            Settings.Default.Save();
            AppFontSettings.Apply(appSetting?.AppFontSize);
            LUE_Terminal.Properties.DataSource = efMethods.SelectEntities<DcTerminal>();

            LUE_Terminal.EditValue = Settings.Default.TerminalId;
            txtEdit_UserName.Text = Settings.Default.LoginName;
            txtEdit_Password.Text = Settings.Default.LoginPassword;
            LUE_Language.EditValue = Settings.Default.LanguageCode;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            TouchUIMode(Settings.Default.TerminalId);
        }

        private void TouchUIMode(int terminalId)
        {
            DcTerminal dcTerminal = efMethods.SelectEntityById<DcTerminal>(terminalId);

            if (dcTerminal != null)
            {
                if (dcTerminal.TouchUIMode == true)
                    WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;
                else
                    WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;

                WindowsFormsSettings.TouchScaleFactor = dcTerminal.TouchScaleFactor;
            }
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AppSetting?.LocalCurrencyCode is null)
                XtraMessageBox.Show(Resources.Form_Login_LocalCurrencyNotSet);

            string? selectedCompany = LUE_Company.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCompany))
            {
                XtraMessageBox.Show(Resources.Form_Login_CompanyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LicenseValidationResult licenseResult = CheckLicense(selectedCompany);
            if (!licenseResult.IsValid)
            {
                XtraMessageBox.Show(licenseResult.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (licenseResult.IsExpiringSoon)
            {
                _ = LicenseService.PublishExpiringSoonNotificationAsync(selectedCompany, licenseResult, txtEdit_UserName.Text.Trim());
            }

            if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
            {
                SessionSave(
                    txtEdit_UserName.Text,
                    txtEdit_Password.Text,
                    checkEdit_RemindMe.Checked,
                    Convert.ToInt32(LUE_Terminal.EditValue),
                    selectedCompany,
                    LUE_Language.EditValue?.ToString());

                CultureInfo culture = CultureInfo.CreateSpecificCulture(LUE_Language.EditValue?.ToString());
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                if (Convert.ToInt32(LUE_Terminal.EditValue) != 0)
                {
                    FormPOS formPos = new();
                    Hide();
                    formPos.ShowDialog();
                    Close();
                }
                else
                    XtraMessageBox.Show(Resources.Form_Login_TerminalRequired);
            }
        }

        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AppSetting?.LocalCurrencyCode is null)
                XtraMessageBox.Show(Resources.Form_Login_LocalCurrencyNotSet);

            string? selectedCompany = LUE_Company.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCompany))
            {
                XtraMessageBox.Show(Resources.Form_Login_CompanyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LicenseValidationResult licenseResult = CheckLicense(selectedCompany);
            if (!licenseResult.IsValid)
            {
                XtraMessageBox.Show(licenseResult.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (licenseResult.IsExpiringSoon)
            {
                _ = LicenseService.PublishExpiringSoonNotificationAsync(selectedCompany, licenseResult, txtEdit_UserName.Text.Trim());
            }

            if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
            {
                SessionSave(
                    txtEdit_UserName.Text,
                    txtEdit_Password.Text,
                    checkEdit_RemindMe.Checked,
                    Convert.ToInt32(LUE_Terminal.EditValue),
                    selectedCompany,
                    LUE_Language.EditValue?.ToString());

                CultureInfo culture = CultureInfo.CreateSpecificCulture(LUE_Language.EditValue?.ToString());
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                if (Convert.ToInt32(LUE_Terminal.EditValue) != 0)
                {
                    FormERP formERP = new();
                    Hide();
                    formERP.ShowDialog();
                    Close();
                }
                else
                    XtraMessageBox.Show(Resources.Form_Login_TerminalRequired);
            }
        }

        private LicenseValidationResult CheckLicense(string? companyCode)
        {
            return LicenseService.ValidateLicense(companyCode);
        }

        private static void SessionSave(string user, string password, bool Checked, int terminalId, string companyCode, string langCode)
        {
            Settings.Default.TerminalId = terminalId;
            Settings.Default.CompanyCode = companyCode;

            if (Checked)
            {
                Settings.Default.LoginName = user;
                Settings.Default.LoginPassword = password;
                Settings.Default.LanguageCode = langCode;
                Settings.Default.LoginChecked = Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.LoginName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.LanguageCode = "en";
                Settings.Default.LoginChecked = false;
                Settings.Default.Save();
            }
        }

        private void BBI_GetKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            string hardwareId = LicenseService.GetHardwareId();
            System.Windows.Clipboard.SetText(hardwareId);
            XtraMessageBox.Show(Resources.Form_Login_KeyCopiedToClipboard, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LUE_Terminal_EditValueChanged(object sender, EventArgs e)
        {
            TouchUIMode(Convert.ToInt32(LUE_Terminal.EditValue));
        }

        private void LUE_Company_EditValueChanging(object sender, ChangingEventArgs e)
        {
            DcCompany company = efMethods.SelectCompany(e.NewValue?.ToString());

            if (!string.IsNullOrWhiteSpace(Settings.Default.SubConnString) &&
                !string.IsNullOrEmpty(company?.CompanyCode))
            {
                var builder = new SqlConnectionStringBuilder(Settings.Default.SubConnString);
                builder.InitialCatalog = company.CompanyCode;

                var optionsBuilder = new DbContextOptionsBuilder<subContext>();
                optionsBuilder.UseSqlServer(SqlLanguageHelper.GetLocalizedConnectionString(builder.ConnectionString));

                using (var context = new subContext(optionsBuilder.Options))
                {
                    if (context.Database.CanConnect())
                    {
                        SaveConnectionString(builder.ConnectionString);
                    }
                    else
                    {
                        XtraMessageBox.Show(Resources.Common_DatabaseNotFound);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void LUE_Company_EditValueChanged(object sender, EventArgs e)
        {
            if (LUE_Company.EditValue is not null)
            {
                Settings.Default.CompanyCode = LUE_Company.EditValue.ToString();
                Settings.Default.Save();
                LoadDataByDatabase();
            }
        }

        private void SaveConnectionString(string constr)
        {
            Settings.Default.SubConnString = constr;
            Settings.Default.Save();
        }

        private void btn_ConStr(object sender, EventArgs e)
        {
            FormConnectionStringBuilder form = new(Settings.Default.SubConnString);
            form.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private async void bbi_test_ItemClick(object sender, EventArgs e)
        {
        }
    }
}
