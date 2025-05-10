using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormQty : XtraForm
    {
        public decimal maxQty { get; set; }
        public decimal qty { get; set; }

        public FormQty()
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            txtEdit_Qty.Properties.Mask.Culture = customCulture;
        }

        public FormQty(decimal maxQty)
            : this()
        {
            this.maxQty = maxQty;
        }

        private void FormQty_Load(object sender, EventArgs e)
        {
            txtEdit_Qty.EditValue = maxQty;
        }

        private void textEditQty_EditValueChanged(object sender, EventArgs e)
        {
            qty = Convert.ToDecimal(txtEdit_Qty.EditValue);
            txtEdit_Qty.DoValidate();
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

        private void textEditQty_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val <= 0)
                e.Cancel = true;
            else if (val > maxQty && maxQty != 0)
                e.Cancel = true;
            else
                label_Message.Text = "";
        }

        private void textEditQty_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 ilə "+ maxQty.ToString() + " arasında olmalıdır";
            label_Message.Text = e.ErrorText;
        }
    }
}