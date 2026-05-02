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
            if (Settings.Default.AppSetting.LocalCurrencyCode is null)
                XtraMessageBox.Show(Resources.Form_Login_LocalCurrencyNotSet);

            if (CheckLicense())
            {
                if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
                {
                    SessionSave(
                        txtEdit_UserName.Text,
                        txtEdit_Password.Text,
                        checkEdit_RemindMe.Checked,
                        Convert.ToInt32(LUE_Terminal.EditValue),
                        LUE_Company.EditValue?.ToString(),
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
            else
                XtraMessageBox.Show(Resources.Form_Login_LicenseInactive);

        }

        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AppSetting.LocalCurrencyCode is null)
                XtraMessageBox.Show(Resources.Form_Login_LocalCurrencyNotSet);

            if (CheckLicense())
            {
                if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
                {
                    SessionSave(
                        txtEdit_UserName.Text,
                        txtEdit_Password.Text,
                        checkEdit_RemindMe.Checked,
                        Convert.ToInt32(LUE_Terminal.EditValue),
                        LUE_Company.EditValue?.ToString(),
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
            else
            {
                using subContext db = new();
                string databaseName = db.Database.GetDbConnection().Database;
                XtraMessageBox.Show(string.Format(Resources.Form_Login_LicenseInactiveDb, databaseName));
            }
        }

        private bool CheckLicense()
        {
            string encrypt = efMethods.SelectEntityById<AppSetting>(1).License;

            if (string.IsNullOrEmpty(encrypt))
                return false;
            else
            {
                try
                {
                    string key = "FoxoftIsTheBestP";
                    string iv = "ThisIsAnInitVect";

                    CustomMethods cM = new();
                    string decrypted = cM.DecryptString(encrypt, key, iv);
                    string databaseName = decrypted.Split('+')[0];
                    string localAddress = decrypted.Split('+')[1];
                    string date = decrypted.Split('+')[2];
                    DateTime dateTime = DateTime.ParseExact(date, "yyyyMMdd", null);

                    subContext db = new();
                    return databaseName == db.Database.GetDbConnection().Database &&
                        localAddress == CustomExtensions.GetPhiscalAdress() &&
                        dateTime > DateTime.Now;
                }
                catch (FormatException ex)
                {
                    XtraMessageBox.Show(string.Format(Resources.Form_Login_LicenseDateInvalid, ex.Message));
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
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

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string nameConStr = "Foxoft.Properties.Settings.SubConnString";

        private void BBI_GetKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            string localAddress = CustomExtensions.GetPhiscalAdress();
            System.Windows.Clipboard.SetText(localAddress);
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
                optionsBuilder.UseSqlServer(builder.ConnectionString);

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
                LoadDataByDatabase();
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
            //lC_Root.RegisterUserCustomizationForm(typeof(Form1));
        }

        private async void bbi_test_ItemClick(object sender, EventArgs e)
        {
            await SendWhatsappMessageAsync("994773628800", "Salam, test mesajıdır.");
        }

        private async Task SendWhatsappMessageAsync(string phoneNumber, string message)
        {
            string serverUrl = "https://evolution.tokla.az"; // məsələn: https://wa.mysite.com
            string instanceName = "tokla";
            string apiKey = "2fdqo0JtF6dnG23N7JbnZ9wMoVMRvRkh";

            string url = $"{serverUrl}/message/sendText/{instanceName}";

            var body = new
            {
                number = phoneNumber,
                text = message,
                delay = 1000,
                linkPreview = false
            };

            string json = JsonSerializer.Serialize(body);

            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("apikey", apiKey);

            using StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xəta: " + result);
                return;
            }

            MessageBox.Show("Mesaj göndərildi: " + result);
        }
    }
}
