using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInput : XtraForm
    {
        public decimal maxInput { get; set; }
        public decimal input { get; set; }

        public FormInput()
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            txtEdit_Input.Properties.Mask.Culture = customCulture;
        }

        public FormInput(decimal maxInput)
            : this()
        {
            this.maxInput = maxInput;
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            txtEdit_Input.EditValue = maxInput;
        }

        private void textEditInput_EditValueChanged(object sender, EventArgs e)
        {
            input = Convert.ToDecimal(txtEdit_Input.EditValue.ToString(), CultureInfo.InvariantCulture);
            txtEdit_Input.DoValidate();
        }

        private void simpleButtonNum_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "↵":
                    btn_Ok.PerformClick();
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textEditInput_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val <= 0)
                e.Cancel = true;
            else if (val > maxInput && maxInput != 0)
                e.Cancel = true;
            else
                label_Message.Text = "";
        }

        private void textEditInput_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 ilə " + maxInput.ToString() + " arasında olmalıdır";
            label_Message.Text = e.ErrorText;
        }
    }
}