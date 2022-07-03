using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayment : XtraForm
    {
        private Guid PaymentHeaderId;

        private TrInvoiceHeader trInvoiceHeader { get; set; }
        private TrPaymentLine trPaymentLine = new TrPaymentLine();
        private EfMethods efMethods = new EfMethods();

        private bool isNegativ = false;

        public FormPayment(byte paymentType, decimal invoiceSumLoc, TrInvoiceHeader trInvoiceHeader)
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            lUE_cashCurrency.Properties.DataSource = efMethods.SelectCurrencies();
            lUE_CashlessCurrency.Properties.DataSource = efMethods.SelectCurrencies();

            PaymentHeaderId = Guid.NewGuid();

            trPaymentLine.PaymentHeaderId = PaymentHeaderId;
            trPaymentLine.PaymentLineId = Guid.NewGuid();
            trPaymentLine.PaymentTypeCode = paymentType;
            trPaymentLine.CurrencyCode = "USD";
            trPaymentLine.ExchangeRate = 1.703f;
            trPaymentLine.CashRegisterCode = "kassa01";

            this.trInvoiceHeader = trInvoiceHeader;

            if (CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In")
                invoiceSumLoc *= (-1);

            if (trInvoiceHeader.IsReturn)
                invoiceSumLoc *= (-1);

            decimal prePaid = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId);
            decimal mustPaid = Math.Round(invoiceSumLoc - prePaid, 2);

            if (mustPaid < 0)
                isNegativ = true;

            trPaymentLine.PaymentLoc = Math.Abs(mustPaid);
            trPaymentLine.Payment = Math.Abs(Math.Round(trPaymentLine.PaymentLoc / (decimal)trPaymentLine.ExchangeRate, 2));
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void FillControls()
        {
            switch (trPaymentLine.PaymentTypeCode)
            {
                case 1: txtEdit_Cash.EditValue = trPaymentLine.Payment; break;
                default: txtEdit_Cash.EditValue = trPaymentLine.Payment; break;
            }

            dateEdit_Date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            btnEdit_CashRegister.EditValue = trPaymentLine.CashRegisterCode;
            lUE_cashCurrency.EditValue = trPaymentLine.CurrencyCode;
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCash = Convert.ToDecimal(txtEdit_Cash.EditValue);
            trPaymentLine.Payment = txtCash;
            trPaymentLine.PaymentLoc = txtCash * (decimal)trPaymentLine.ExchangeRate;
            txtEdit_Cash.DoValidate();
        }

        private void txtEdit_Cash_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLine.Payment < 0)
                e.Cancel = true;
        }

        private void textEditCash_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 dan az olmamalıdır";
        }

        private void btnEdit_CashRegister_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAcc(sender);
        }
        private void lUE_cashCurrency_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            trPaymentLine.CurrencyCode = lUE_cashCurrency.EditValue.ToString();
            trPaymentLine.ExchangeRate = (float)editor.GetColumnValue("ExchangeRate");
            trPaymentLine.PaymentLoc = Math.Round(trPaymentLine.Payment * (decimal)trPaymentLine.ExchangeRate, 2);
            FillControls();
        }

        private void SelectCurrAcc(object sender)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCurrAccList form = new FormCurrAccList(0))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                    trPaymentLine.CashRegisterCode = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void btnEdit_BankAccout_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void simpleButtonUpdateCash_Click(object sender, EventArgs e)
        {
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
        }

        private void simpleButtonUpdateCashless_Click(object sender, EventArgs e)
        {
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
        }

        private void simpleButtonUpdateBonus_Click(object sender, EventArgs e)
        {
        }

        private void lUE_CashlessCurrency_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btn_Num_Click(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Text;

            switch (key)
            {
                case "←": SendKeys.Send("{BACKSPACE}"); break;
                case "C": SendKeys.Send("^A"); SendKeys.Send("{BACKSPACE}"); break;
                case "↵": btn_Ok.PerformClick(); break;
                default: SendKeys.Send(key); break;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            EfMethods efMethods = new EfMethods();

            decimal cash = trPaymentLine.PaymentLoc;

            string NewDocNum = efMethods.GetNextDocNum("PA", "DocumentNumber", "TrPaymentHeaders");

            string operType = "invoice";
            if (trInvoiceHeader.InvoiceHeaderId == Guid.Empty || trInvoiceHeader == null)
                operType = "payment";

            if (cash > 0)
            {
                TrPaymentHeader trPayment = new TrPaymentHeader();

                trPayment.PaymentHeaderId = PaymentHeaderId;
                trPayment.DocumentNumber = NewDocNum;
                trPayment.CurrAccCode = trInvoiceHeader.CurrAccCode;
                trPayment.CreatedUserName = Authorization.CurrAccCode;
                trPayment.OfficeCode = trInvoiceHeader.OfficeCode;
                trPayment.StoreCode = trInvoiceHeader.StoreCode;
                trPayment.DocumentDate = trInvoiceHeader.DocumentDate;
                trPayment.DocumentTime = trInvoiceHeader.DocumentTime;
                if (trInvoiceHeader.InvoiceHeaderId != Guid.Empty)
                    trPayment.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
                trPayment.OperationType = operType;
                trPayment.OperationDate = DateTime.Parse(dateEdit_Date.EditValue.ToString());
                efMethods.InsertPaymentHeader(trPayment);

                trPaymentLine.Payment = isNegativ ? trPaymentLine.Payment * (-1) : trPaymentLine.Payment;
                trPaymentLine.PaymentLoc = isNegativ ? trPaymentLine.PaymentLoc * (-1) : trPaymentLine.PaymentLoc;
                trPaymentLine.CreatedUserName = Authorization.CurrAccCode;
                efMethods.InsertPaymentLine(trPaymentLine);

                DialogResult = DialogResult.OK;
            }
        }

    }
}