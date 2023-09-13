using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace Foxoft
{
    public partial class FormLogin : ToolbarForm
    {
        EfMethods efMethods = new();
        public FormLogin()
        {
            // SplashScreenManager sSM = new(this, typeof(SplashScreenStartup), true, true,500);

            Trace.Write("\n FormLogin Started. \n SplashScreenStartup Starting... ");

            SplashScreenManager.ShowForm(this, typeof(SplashScreenStartup), true, true, true);

            Trace.Write("\n SplashScreenStartup Started. \n tring db.CanConnect... ");

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

                Trace.Write("\n db.Database.CanConnect() = " + db.Database.CanConnect().ToString() + " \n InitializeComponent starting... ");

                EfMethods efMethods = new();
                AppSetting appSetting = efMethods.SelectAppSetting();
                Trace.Write("\n AppSetting appSetting = " + appSetting.Id.ToString() + " \n InitializeComponent starting... ");
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
            FormTreeView frm = new();
            frm.Show();
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Form1 formPriceListHeaderList = new Form1("PL");
            //formPriceListHeaderList.Show();

        }

        private bool CheckHasLicense()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                var pInterfaceProperties = nic.GetPhysicalAddress();

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
                var pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    if (nic.Name == "Ethernet")
                        Clipboard.SetText(nic.Id + pInterfaceProperties);
            }
        }
    }
}