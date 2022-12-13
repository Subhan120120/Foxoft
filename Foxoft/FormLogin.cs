using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Foxoft
{
   public partial class FormLogin : ToolbarForm
   {
      EfMethods efMethods = new EfMethods();

      public FormLogin()
      {
         EfMethods efMethods = new EfMethods();
         AppSetting appSetting = efMethods.SelectAppSetting();
         Settings.Default.AppSetting = appSetting;
         Settings.Default.Save();
         AcceptButton = btn_ERP;

         InitializeComponent();
         SplashScreenManager sSM = new(this, typeof(SplashScreenStartup), true, true);
         sSM.ClosingDelay = 500;
         //System.Threading.Thread.Sleep(7000);

         txtEdit_UserName.Text = Settings.Default.LoginName;
         txtEdit_Password.Text = Settings.Default.LoginPassword;
         checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;
      }

      private void btn_POS_Click(object sender, EventArgs e)
      {
         if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
         {
            FormPOS formPos = new FormPOS();
            Hide();
            formPos.ShowDialog();
            Close();
         }
      }

      private void btn_ERP_Click(object sender, EventArgs e)
      {
         if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
         {
            FormERP formERP = new FormERP();
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
         txtEdit_conString.EditValue = config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString; ;
      }

      private void btn_ConStringSave_Click(object sender, EventArgs e)
      {
         config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = txtEdit_conString.EditValue.ToString();
         config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
         config.Save(ConfigurationSaveMode.Modified);

         string a1 = config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString;
         string a2 = Settings.Default.subConnString;

         var contextOptions = new DbContextOptionsBuilder<subContext>()
               .UseSqlServer(a1)
               .Options;

         using subContext context = new subContext(contextOptions);
         string a5 = context.Database.GetDbConnection().ConnectionString;
      }
   }
}