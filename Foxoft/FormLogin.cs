using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Foxoft.Properties;
using System;

namespace Foxoft
{
    public partial class FormLogin : ToolbarForm
    {
        EfMethods efMethods = new EfMethods();

        public FormLogin()
        {
            InitializeComponent();
            SplashScreenManager sSM = new SplashScreenManager(this, typeof(global::Foxoft.SplashScreenStartup), true, true);
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
            DefaultControls defaultControls = new DefaultControls();
            defaultControls.Show();
        }
    }
}