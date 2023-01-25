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
using System.IO;
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

         SplashScreenManager.ShowForm(this, typeof(SplashScreenStartup), true, true, true);

         using (subContext db = new())
         {
            db.Database.EnsureCreated();
            //db.Database.Migrate();

            //string sql = db.Database.GenerateCreateScript();

            //IRelationalDatabaseCreator databaseCreator = db.GetService<IRelationalDatabaseCreator>();
            //databaseCreator.CreateTables();

            CreateViews(new DatabaseFacade(db));
         }

         AppSetting appSetting = efMethods.SelectAppSetting();
         Settings.Default.AppSetting = appSetting;
         Settings.Default.Save();

         AcceptButton = btn_ERP;

         InitializeComponent();

         txtEdit_UserName.Text = Settings.Default.LoginName;
         txtEdit_Password.Text = Settings.Default.LoginPassword;
         checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;


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