using DevExpress.XtraEditors;
using Foxoft.Properties;

namespace Foxoft
{
    public partial class FormCurrAccPassword : XtraForm
    {
        private readonly string _currAccCode;
        private readonly EfMethods _efMethods = new();

        public FormCurrAccPassword(string currAccCode, string? currAccDesc)
        {
            InitializeComponent();

            _currAccCode = currAccCode;
            txtEdit_CurrAcc.Text = string.IsNullOrWhiteSpace(currAccDesc)
                ? currAccCode
                : $"{currAccCode} - {currAccDesc}";

            AcceptButton = btn_Save;
            CancelButton = btn_Cancel;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = chkShowPassword.Checked;
            txtEdit_NewPassword.Properties.UseSystemPasswordChar = !showPassword;
            txtEdit_ConfirmPassword.Properties.UseSystemPasswordChar = !showPassword;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();

            string newPassword = txtEdit_NewPassword.Text ?? string.Empty;
            string confirmPassword = txtEdit_ConfirmPassword.Text ?? string.Empty;

            if (string.IsNullOrEmpty(newPassword))
            {
                dxErrorProvider1.SetError(txtEdit_NewPassword, Resources.Form_CurrAccPassword_Empty);
                txtEdit_NewPassword.Focus();
                return;
            }

            if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                dxErrorProvider1.SetError(txtEdit_ConfirmPassword, Resources.Common_Validation_PasswordConfirmMismatch);
                txtEdit_ConfirmPassword.Focus();
                return;
            }

            _efMethods.UpdateCurrAccPassword(_currAccCode, newPassword);
            XtraMessageBox.Show(Resources.Form_CurrAccPassword_Success, Resources.Common_Info);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
