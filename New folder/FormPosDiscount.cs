using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPosDiscount : XtraForm
    {
        decimal Amount = 0; // Amount come from parent form
        public decimal PosDiscount = 0; // PosDiscount come from parent form

        public FormPosDiscount(decimal PosDiscount, decimal Amount)
        {
            this.Amount = Amount;
            this.PosDiscount = PosDiscount;

            InitializeComponent();
        }

        private void FormPosDiscount_Load(object sender, EventArgs e)
        {
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            textEditDiscountRate.EditValue = Math.Round(PosDiscount / Amount * 100, 2);
            textEditNetAmount.EditValue = Amount - PosDiscount;
        }

        private void textEditDiscountRate_EditValueChanged(object sender, EventArgs e)
        {
            PosDiscount = Convert.ToDecimal(textEditDiscountRate.EditValue) * Amount / 100;

            textEditNetAmount.EditValueChanged -= new EventHandler(textEditNetAmount_EditValueChanged);
            textEditNetAmount.EditValue = Amount - PosDiscount;
            textEditNetAmount.EditValueChanged += new EventHandler(textEditNetAmount_EditValueChanged);

            textEditDiscountRate.DoValidate();
        }

        private void textEditNetAmount_EditValueChanged(object sender, EventArgs e)
        {
            PosDiscount = Amount - Convert.ToDecimal(textEditNetAmount.EditValue);

            textEditDiscountRate.EditValueChanged -= new EventHandler(textEditDiscountRate_EditValueChanged);
            textEditDiscountRate.EditValue = Math.Round(PosDiscount / Amount * 100, 2);
            textEditDiscountRate.EditValueChanged += new EventHandler(textEditDiscountRate_EditValueChanged);

            textEditNetAmount.DoValidate();
        }

        private void textEditDiscountRate_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val < 0)
                e.Cancel = true;

            else if (val > 100)
                e.Cancel = true;
        }

        private void textEditDiscountRate_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 ilə 100 arasında olmalıdır";
        }

        private void textEditNetAmount_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val < 0)
                e.Cancel = true;

            else if (val > Amount)
                e.Cancel = true;
        }

        private void textEditNetAmount_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 ilə " + Amount.ToString() + " arasında olmalıdır";
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

    }
}
