using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Xml;

namespace Foxoft
{
    public partial class FormLogin : ToolbarForm
    {
        EfMethods efMethods = new();
        CustomMethods cM = new();

        public FormLogin()
        {
            // SplashScreenManager sSM = new(this, typeof(SplashScreenStartup), true, true,500);

            SplashScreenManager.ShowForm(this, typeof(SplashScreenStartup), true, true, true);

            InitializeComponent();

            using subContext db = new();

            if (!db.Database.CanConnect())
                if (MessageBoxResult.OK == MessageBox.Show("Databasa ilə əlaqə qurula bilmir. \n connection string: \n" + db.Database.GetConnectionString() + "\n" +
                "Yeni Database Yaratmaq isteyirsiz?", "Diqqət", MessageBoxButton.OKCancel))
                    db.Database.EnsureCreated();

            if (db.Database.CanConnect())
            {
                //db.Database.Migrate();

                //string sql = db.Database.GenerateCreateScript();

                //IRelationalDatabaseCreator databaseCreator = db.GetService<IRelationalDatabaseCreator>();
                //databaseCreator.CreateTables();

                CreateViews(db.Database);

                UpdateReportsLayout();

                UpdateDueDate();

                AppSetting appSetting = efMethods.SelectAppSetting();
                Settings.Default.AppSetting = appSetting;
                Settings.Default.Save();

                LUE_Terminal.Properties.DataSource = efMethods.SelectTerminals();
            }

            AcceptButton = btn_ERP;


            //string fileName = System.Security.Principal.WindowsIdentity.GetCurrent().Name + ".xml";
            //string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Terminals");
            //if (!Directory.Exists(layoutFileDir))
            //    Directory.CreateDirectory(layoutFileDir);
            //string fullPath = Path.Combine(layoutFileDir, fileName);

            LUE_Terminal.EditValue = Settings.Default.TerminalId;
            txtEdit_UserName.Text = Settings.Default.LoginName;
            txtEdit_Password.Text = Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            Trace.Write("\n InitializeComponent Finished. \n SplashScreenStartup closing... ");
            Trace.Flush();

            TouchUIMode(Settings.Default.TerminalId);

            SplashScreenManager.CloseForm();

            if (Settings.Default.AppSetting.LocalCurrencyCode is null)
                MessageBox.Show("Yerli Pul Vahidi Təyin olunmayıb");
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

        private void UpdateReportsLayout()
        {
            UpdateReportLayout(4, "Report_Grid_Expenses.xml");
            UpdateReportLayout(5, "Report_Grid_MoneyMovements.xml");
            UpdateReportLayout(6, "Report_Grid_MovementsWithAccounts.xml");
            UpdateReportLayout(7, "Report_Grid_ProductMovements.xml");
            UpdateReportLayout(8, "Report_Grid_Profit.xml");
            UpdateReportLayout(9, "Report_Grid_RecentGoods.xml");
            UpdateReportLayout(10, "Report_Grid_WarehouseBalance.xml");
        }

        private void UpdateReportLayout(int reportId, string fileName)
        {
            //bunu caliwdirmaq olmaz !!!
            //string layout = cM.GetDataFromFile("Foxoft.AppCode.Report." + fileName);
            //efMethods.UpdateReportLayout(reportId, layout);
        }

        private static void CreateViews(DatabaseFacade db)
        {
            InjectView(db, "View_RetailSales.sql", "RetailSales");
            InjectView(db, "View_AllPayments.sql", "AllPayments");
            InjectView(db, "View_Transactions.sql", "Transactions");
            InjectView(db, "View_ProductFeatures.sql", "ProductFeatures");
        }

        private static void InjectView(DatabaseFacade db, string sqlFileName, string viewName)
        {
            Assembly assembly = typeof(Program).Assembly;
            string assemblyName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(','));
            string path = assemblyName + ".AppCode.SqlQuery" + "." + sqlFileName;
            Stream stream = assembly.GetManifestResourceStream(path);
            string sqlQuery = new StreamReader(stream).ReadToEnd();

            string a1 = $"IF OBJECT_ID('{viewName}') IS NOT NULL BEGIN DROP VIEW {viewName} END";
            string a2 = $"CREATE VIEW {viewName} AS {sqlQuery}";

            db.ExecuteSqlRaw(a1);
            db.ExecuteSqlRaw(a2);
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
            {
                FormPOS formPos = new();
                //SaveNewConStr();
                Hide();
                formPos.ShowDialog();
                Close();
            }
        }

        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (Authorization.Login(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked))
            {
                SessionSave(txtEdit_UserName.Text, txtEdit_Password.Text, checkEdit_RemindMe.Checked, Convert.ToInt32(LUE_Terminal.EditValue));

                if (CheckDueDate())
                {
                    if (Convert.ToUInt32(LUE_Terminal.EditValue) != 0)
                    {

                        FormERP formERP = new();
                        //SaveNewConStr();
                        Hide();
                        formERP.ShowDialog();
                        Close();
                    }
                    else
                        XtraMessageBox.Show("Terminal boş buraxıla bilməz!");
                }
                else
                    XtraMessageBox.Show("Lisenziya Aktiv Deyil!");
            }
            else
                XtraMessageBox.Show("İstifadəçi və ya şifrə yanlışdır");
        }


        private static void SessionSave(string user, string password, bool Checked, int terminalId)
        {
            Settings.Default.TerminalId = terminalId;

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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string nameConStr = "subConnString";

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //txtEdit_conString.EditValue = config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString;
            txtEdit_conString.EditValue = Settings.Default.subConnString;
        }

        private void SaveNewConStr()
        {
            Settings.Default.subConnString = txtEdit_conString.EditValue.ToString();
            Settings.Default.Save(); // Save for subcontext

            config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = Settings.Default.subConnString;
            config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified); // Save permenantly
        }

        private void btn_SaveConn_Click(object sender, EventArgs e)
        {
            SaveNewConStr();
        }

        private bool CheckDueDate()
        {
            string encrypt = efMethods.SelectAppSetting().DueDate;

            if (string.IsNullOrEmpty(encrypt))
                return false;
            else
            {
                byte[] decript = Convert.FromBase64String(encrypt);
                string someString = Encoding.ASCII.GetString(decript);
                DateTime dateTime = DateTime.ParseExact(someString, "yyyyMMdd", null);
                return dateTime > DateTime.Now;
            }
        }

        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private bool UpdateDueDate()
        {
            string url = "https://www.tokla.az/txt.txt";

            if (!CheckForInternetConnection(1000, url))
                return false;

            string result = "";
            using (HttpClient client = new() { Timeout = TimeSpan.FromMilliseconds(2000) })
            using (HttpResponseMessage response = client.GetAsync(url).Result)
                result = response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : null;

            string[] txtLisence = result.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (txtLisence is not null)
            {
                for (int i = 0; i < txtLisence.Length; i = i + 3)
                {
                    if (txtLisence[i + 1] == GetPhiscalAdress())
                    {
                        string date = txtLisence[i + 2];
                        byte[] bytes = Encoding.ASCII.GetBytes(date);
                        string encrypt = Convert.ToBase64String(bytes);
                        efMethods.UpdateAppSettingDueDate(encrypt);
                    }
                }

                return true;
            }
            else
                return false;
        }

        public bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetPhiscalAdress()
        {
            string fiscal = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                        fiscal = nic.Id + pInterfaceProperties;
            }

            return fiscal;
        }

        private bool CheckHasLicense()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    if (nic.Name == "Ethernet" && efMethods.CheckHasLicense(nic.Id + pInterfaceProperties))
                        return true;
            }
            return false;
        }

        private void BBI_GetKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();
                    Clipboard.SetText(nic.Id + pInterfaceProperties);
                }
            }
        }

        private void LUE_Terminal_EditValueChanged(object sender, EventArgs e)
        {
            TouchUIMode(Convert.ToInt32(LUE_Terminal.EditValue));
        }

        private void LUE_Terminal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void LUE_Terminal_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
        }
    }
}