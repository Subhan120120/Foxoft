using DevExpress.DirectX.Common;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraSpreadsheet.Import.Xls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows;

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

                AppSetting appSetting = efMethods.SelectAppSetting();
                Settings.Default.AppSetting = appSetting;
                Settings.Default.Save();
            }

            AcceptButton = btn_ERP;

            InitializeComponent();

            txtEdit_UserName.Text = Settings.Default.LoginName;
            txtEdit_Password.Text = Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            Trace.Write("\n InitializeComponent Finished. \n SplashScreenStartup closing... ");
            Trace.Flush();

            SplashScreenManager.CloseForm();

            if (Settings.Default.AppSetting.LocalCurrencyCode is null)
                MessageBox.Show("Yerli Pul Vahidi Təyin olunmayıb");
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
            if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
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
            if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
            {
                if (CheckHasLicense())
                {
                    FormERP formERP = new();
                    //SaveNewConStr();
                    Hide();
                    formERP.ShowDialog();
                    Close();
                }
                else
                    XtraMessageBox.Show("Lisenziya Aktiv Deyil!");
            }
            else
                XtraMessageBox.Show("İstifadəçi və ya şifrə yanlışdır");
        }

        public bool Login(string user, string password)
        {
            EfMethods efMethods = new();
            if (efMethods.Login(user, password))
            {
                SessionSave();
                return true;
            }
            else
                return false;
        }

        private void SessionSave()
        {
            EfMethods efMethods = new();

            if (checkEdit_RemindMe.Checked)
            {
                Settings.Default.LoginName = txtEdit_UserName.Text;
                Settings.Default.LoginPassword = txtEdit_Password.Text;
                Settings.Default.LoginChecked = checkEdit_RemindMe.Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.LoginName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.LoginChecked = false;
                Settings.Default.Save();
            }

            Authorization.CurrAccCode = txtEdit_UserName.Text;
            Authorization.DcRoles = efMethods.SelectRoles(txtEdit_UserName.Text);
            Authorization.StoreCode = efMethods.SelectStoreCode(txtEdit_UserName.Text);
            Authorization.OfficeCode = efMethods.SelectOfficeCode(txtEdit_UserName.Text);
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

        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("myurl");

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Stream resStream = response.GetResponseStream();
            //string tempString = null;
            //int count = 0;

            //do
            //{
            //    // fill the buffer with data
            //    count = resStream.Read(new byte[] { }, 0, buf.Length);

            //    // make sure we read some data
            //    if (count != 0)
            //    {
            //        // translate from bytes to ASCII text
            //        tempString = Encoding.ASCII.GetString(buf, 0, count);

            //        // continue building the string
            //        sb.Append(tempString);
            //    }
            //}
            //while (count > 0); // any more data to read?

            //// print out page source
            //Console.WriteLine(sb.ToString());

            string asd = "";
            string url = "https://www.tokla.az/txt.txt";

            using (var client = new HttpClient())
            using (var result = await client.GetAsync(url))
                asd = result.IsSuccessStatusCode ? await result.Content.ReadAsStringAsync() : null;

            string[] asdfghj = asd.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.None);


            for (int i = 0; i < asdfghj.Length; i = i + 2)
            {
                DateTime dateTime;

                if (asdfghj[i] == GetPhiscalAdress())
                {
                    string gfgfh = asdfghj[i + 1];
                    dateTime = DateTime.ParseExact(gfgfh, "yyyyMMdd", null);

                    //String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"txt.txt");

                }
            }
        }

        private static string GetPhiscalAdress()
        {
            string fiscal = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    if (nic.Name == "Ethernet")
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
                    if (nic.Name == "Ethernet")
                    {
                        PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();
                        Clipboard.SetText(nic.Id + pInterfaceProperties);
                    }
            }
        }
    }
}