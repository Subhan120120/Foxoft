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
using System.Net.NetworkInformation;

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
                    FormPOS formPos = new();
                    Hide();
                    formPos.ShowDialog();
                    Close();
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

        private void bbi_test_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormHandOver deliveryBrowser = new("WO");
            deliveryBrowser.ShowDialog();
        }

        private static async Task TestWhatsapp()
        {
            var TOKEN = "EAAWMnYx6BxYBPa19qH7uteeer8zFHrwagkVtCLtd7NhFpjCSHdYL52O8zlB0m23N68VXm7qpa4xMYefYY8uLTe6bXXmCIRVXEQoTHJQmKouCcq1hjrrB8Ogf0NtAoHKUZCh50Rln8aRw0xffrZAnHkT1aYhQcsF26fVVt2gVL68k5o0mQEDMy3c7ivsP5oCUOePkziqloxpxnHCo7QKCMfpWt7ZC5BoZC53jXl4cNfTiFSu3nQveA6rmrOZCL6wZDZD";
            var PHONEID = "792567567267494";
            var TO = "994519678909";

            var filePath = @"C:\Users\Subhan\Downloads\as.jpg";

            using var wa = new WhatsAppClient(TOKEN, PHONEID);

            using var ms = new MemoryStream(File.ReadAllBytes(filePath));
            var messageId = await wa.UploadAndSendImageAsync(TO, ms, caption: "From MemoryStream", fileName: "pic.jpg", contentType: "image/jpeg");
            Console.WriteLine($"Sent: {messageId}");
        }
    }
}
