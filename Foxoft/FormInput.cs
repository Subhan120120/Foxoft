using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Properties;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInput : XtraForm
    {
        public decimal defaultValue { get; set; } = 0;
        public decimal maxInput { get; set; } = 999999999;
        public decimal input { get; set; }

        public FormInput()
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormInput(decimal defaultValue, decimal? maxInput = null)
            : this()
        {
            this.defaultValue = defaultValue;
            this.maxInput = maxInput ?? 999999999;
        }


        private void FormInput_Load(object sender, EventArgs e)
        {
            txtEdit_Input.EditValue = defaultValue;
        }

        private void textEditInput_EditValueChanged(object sender, EventArgs e)
        {
            input = Convert.ToDecimal(txtEdit_Input.EditValue, CultureInfo.InvariantCulture);

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
            else if (val > maxInput)
                e.Cancel = true;
            else
                label_Message.Text = "";
        }

        private void textEditInput_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = Resources.Common_Attention;
            e.ErrorText = string.Format(Resources.Common_Validation_InputRange, maxInput);
            label_Message.Text = e.ErrorText;
        }
    }
}
