using DevExpress.CodeParser;
using DevExpress.Office.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using static Foxoft.Program;

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
            LUE_Company.EditValue = Settings.Default.CompanyCode;

            AcceptButton = btn_ERP;

            LoadDataByDatabase();
        }

        private void LoadDataByDatabase()
        {
            AppSetting appSetting = efMethods.SelectAppSetting();
            Settings.Default.AppSetting = appSetting;
            Settings.Default.Save();
            LUE_Terminal.Properties.DataSource = efMethods.SelectTerminals();

            LUE_Terminal.EditValue = Settings.Default.TerminalId;
            txtEdit_UserName.Text = Settings.Default.LoginName;
            txtEdit_Password.Text = Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            TouchUIMode(Settings.Default.TerminalId);
        }

        private void TouchUIMode(int terminalId)
        {
            DcTerminal dcTerminal = efMethods.SelectTerminal(terminalId);

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
                XtraMessageBox.Show("Yerli Pul Vahidi Təyin olunmayıb");

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
                XtraMessageBox.Show("Lisenziya Aktiv Deyil!");

        }

        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AppSetting.LocalCurrencyCode is null)
                XtraMessageBox.Show("Yerli Pul Vahidi Təyin olunmayıb");

            if (CheckLicense())
            {
                if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
                {
                    SessionSave(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked, Convert.ToInt32(LUE_Terminal.EditValue), LUE_Company.EditValue?.ToString());

                    if (Convert.ToInt32(LUE_Terminal.EditValue) != 0)
                    {
                        FormERP formERP = new();
                        Hide();
                        formERP.ShowDialog();
                        Close();
                    }
                    else
                        XtraMessageBox.Show("Terminal boş buraxıla bilməz!");
                }
            }
            else
                XtraMessageBox.Show(new subContext().Database.GetDbConnection().Database + " Lisenziya Aktiv Deyil!");
        }

        private bool CheckLicense()
        {
            string encrypt = efMethods.SelectAppSetting().License;

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
                        localAddress == GetPhiscalAdress() &&
                        dateTime > DateTime.Now;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
        string GetPhiscalAdress()
        {
            string fiscal = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.Name.StartsWith("Ethernet"))
                    fiscal = nic.Id + pInterfaceProperties;
            }

            return fiscal;
        }



        private static void SessionSave(string user, string password, bool Checked, int terminalId, string companyCode)
        {
            Settings.Default.TerminalId = terminalId;
            Settings.Default.CompanyCode = companyCode;

            if (Checked)
            {
                Settings.Default.LoginName = user;
                Settings.Default.LoginPassword = password;
                Settings.Default.LoginChecked = Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.LoginName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.LoginChecked = false;
                Settings.Default.Save();
            }
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string nameConStr = "Foxoft.Properties.Settings.SubConnString";


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FormUser asd = new();
            //asd.Show();
        }

        private void BBI_GetKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.Name.StartsWith("Ethernet"))
                {
                    PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();
                    System.Windows.Clipboard.SetText(nic.Id + pInterfaceProperties);
                }
            }
        }

        private void LUE_Terminal_EditValueChanged(object sender, EventArgs e)
        {
            TouchUIMode(Convert.ToInt32(LUE_Terminal.EditValue));
        }

        private void LUE_Company_EditValueChanging(object sender, ChangingEventArgs e)
        {
            DcCompany company = efMethods.SelectCompany(e.NewValue?.ToString());

            if (!String.IsNullOrWhiteSpace(Settings.Default.SubConnString) && !String.IsNullOrEmpty(company?.CompanyCode))
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
                        XtraMessageBox.Show("Databaza mövcud deyil.");
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

            //config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = Settings.Default.SubConnString;
            //config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
            //config.Save(ConfigurationSaveMode.Modified); // Save permenantly
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
    }
}