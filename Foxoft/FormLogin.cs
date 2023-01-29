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
using System.Reflection;
using System.Windows;

namespace Foxoft
{
   public partial class FormLogin : ToolbarForm
   {

      public FormLogin()
      {
         // SplashScreenManager sSM = new(this, typeof(SplashScreenStartup), true, true,500);

         Trace.Write("\n FormLogin Started. \n SplashScreenStartup Starting... ");

         SplashScreenManager.ShowForm(this, typeof(SplashScreenStartup), true, true, true);

         Trace.Write("\n SplashScreenStartup Started. \n tring db.CanConnect... ");

         using subContext db = new();

         if (db.Database.CanConnect())
         {
            db.Database.EnsureCreated();
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
         else MessageBox.Show("Databasa ilə əlaqə qurula bilmir. \n connection string: \n" + db.Database.GetConnectionString());

         AcceptButton = btn_ERP;

         InitializeComponent();

         txtEdit_UserName.Text = Settings.Default.LoginName;
         txtEdit_Password.Text = Settings.Default.LoginPassword;
         checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

         Trace.Write("\n InitializeComponent Finished. \n SplashScreenStartup closing... ");
         Trace.Flush();

         SplashScreenManager.CloseForm();
      }

      private static void CreateViews(DatabaseFacade db)
      {
         InjectView(db, "View_RetailSales.sql", "RetailSales");
         InjectView(db, "View_AllPayments.sql", "AllPayments");
         InjectView(db, "View_Transactions.sql", "Transactions");
      }

      private static void InjectView(DatabaseFacade db, string sqlFileName, string viewName)
      {
         Assembly assembly = typeof(Program).Assembly;
         string assemblyName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(','));
         string path = assemblyName + ".AppCode.SqlQuery" + "." + sqlFileName;
         Stream stream = assembly.GetManifestResourceStream(path);
         string sqlQuery = new StreamReader(stream).ReadToEnd();

         db.ExecuteSqlRaw($"IF OBJECT_ID('{viewName}') IS NOT NULL BEGIN DROP VIEW {viewName} END");
         db.ExecuteSqlRaw($"CREATE VIEW {viewName} AS {sqlQuery}");
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
            FormERP formERP = new();
            //SaveNewConStr();
            Hide();
            formERP.ShowDialog();
            Close();
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
         DefaultControls defaultControls = new();
         defaultControls.Show();
      }

      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      string nameConStr = "Foxoft.Properties.Settings.subConnString";

      private void FormLogin_Load(object sender, EventArgs e)
      {
         txtEdit_conString.EditValue = config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString;
      }

      private void SaveNewConStr()
      {
         config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = txtEdit_conString.EditValue.ToString();
         config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
         config.Save(ConfigurationSaveMode.Modified);

      }

      private void simpleButton2_Click(object sender, EventArgs e)
      {
         SaveNewConStr();
      }
   }
}