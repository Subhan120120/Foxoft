using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Import.Html;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayment : XtraForm
    {
        private Guid PaymentHeaderId;
        //private bool autoMakePayment;
        private TrPaymentHeader trPaymentHeader = new();
        private TrInvoiceHeader trInvoiceHeader { get; set; }
        private TrPaymentLine trPaymentLineCash = new();
        private TrPaymentLine trPaymentLineCashless = new();
        private EfMethods efMethods = new();

        private bool isNegativ = false;

        public FormPayment()
        {
            InitializeComponent();

            Name = "PaymentDetail";

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            lUE_cashCurrency.Properties.DataSource = efMethods.SelectCurrencies();
            lUE_CashlessCurrency.Properties.DataSource = efMethods.SelectCurrencies();
            lUE_PaymentMethod.Properties.DataSource = efMethods.SelectPaymentMethods();
        }

        public FormPayment(byte paymentType, decimal invoiceSumLoc, TrInvoiceHeader trInvoiceHeader)
           : this()
        {
            this.trInvoiceHeader = trInvoiceHeader;

            PaymentDefaults(paymentType, trInvoiceHeader);

            if (CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In")
                invoiceSumLoc *= (-1);

            decimal prePaid = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId);
            decimal mustPaid = Math.Round(invoiceSumLoc - prePaid, 4);

            if (mustPaid < 0)
                isNegativ = true;

            decimal mustPaidABS = Math.Abs(mustPaid);

            trPaymentLineCash.Payment = mustPaidABS;
        }

        public FormPayment(byte paymentType, decimal invoiceSumLoc, TrInvoiceHeader trInvoiceHeader, bool autoMakePayment)
           : this(paymentType, invoiceSumLoc, trInvoiceHeader)
        {
            if (trPaymentLineCash.Payment > 0)
                if (autoMakePayment)
                    SavePayment(true);
        }

        private void PaymentDefaults(byte paymentType, TrInvoiceHeader trInvoiceHeader)
        {
            PaymentHeaderId = Guid.NewGuid();

            bool invoiceExist = trInvoiceHeader.InvoiceHeaderId != Guid.Empty && trInvoiceHeader != null;

            string operType = "payment";
            if (invoiceExist)
                operType = "invoice";

            trPaymentHeader.PaymentHeaderId = PaymentHeaderId;
            trPaymentHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
            trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHeader.OfficeCode = Authorization.OfficeCode;
            trPaymentHeader.StoreCode = Authorization.StoreCode;
            trPaymentHeader.ProcessCode = "PA";
            trPaymentHeader.DocumentDate = trInvoiceHeader.DocumentDate;
            trPaymentHeader.DocumentTime = trInvoiceHeader.DocumentTime;
            if (invoiceExist)
                trPaymentHeader.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
            trPaymentHeader.OperationType = operType;
            trPaymentHeader.OperationDate = DateTime.Now;
            trPaymentHeader.IsMainTF = true;

            trPaymentLineCash.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCash.PaymentTypeCode = 1;
            trPaymentLineCash.PaymentMethodId = 1;
            trPaymentLineCash.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCash.ExchangeRate = 1;
            trPaymentLineCash.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineCashless.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCashless.PaymentTypeCode = 2;
            trPaymentLineCashless.PaymentMethodId = 3;
            trPaymentLineCashless.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCashless.ExchangeRate = 1;
            trPaymentLineCashless.CreatedUserName = Authorization.CurrAccCode;

            string cashReg = efMethods.SelectDefaultCashRegister(Authorization.StoreCode);
            if (!String.IsNullOrEmpty(cashReg))
            {
                trPaymentLineCash.CashRegisterCode = cashReg;
                trPaymentLineCashless.CashRegisterCode = cashReg;
            }
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void FillControls()
        {
            txtEdit_Cash.EditValue = trPaymentLineCash.Payment;
            txtEdit_Cashless.EditValue = trPaymentLineCashless.Payment;

            dateEdit_Date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            btnEdit_CashRegister.EditValue = trPaymentLineCash.CashRegisterCode;
            btnEdit_BankAccout.EditValue = trPaymentLineCashless.CashRegisterCode;
            lUE_cashCurrency.EditValue = trPaymentLineCash.CurrencyCode;
            lUE_CashlessCurrency.EditValue = trPaymentLineCashless.CurrencyCode;
        }

        private void dateEdit_Date_EditValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateEdit_Date.EditValue);
            trPaymentHeader.OperationDate = date;
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCash = Convert.ToDecimal(txtEdit_Cash.EditValue);
            trPaymentLineCash.Payment = txtCash;
            txtEdit_Cash.DoValidate();
        }

        private void txtEdit_Cash_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLineCash.Payment < 0)
                e.Cancel = true;
        }

        private void textEditCash_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 dan böyük olmalıdır";
        }

        private void btnEdit_CashRegister_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCashRegister(sender, 1);
        }

        private void lUE_cashCurrency_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            trPaymentLineCash.CurrencyCode = lUE_cashCurrency.EditValue.ToString();
            trPaymentLineCash.ExchangeRate = (float)editor.GetColumnValue("ExchangeRate");
            FillControls();
        }

        private void SelectCashRegister(object sender, byte paymentTypeCode)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCurrAccList form = new(new byte[] { 5 }, trInvoiceHeader.CurrAccCode, paymentTypeCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void simpleButtonUpdateCash_Click(object sender, EventArgs e)
        {
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCashless = Convert.ToDecimal(txtEdit_Cashless.EditValue);
            trPaymentLineCashless.Payment = txtCashless;
            txtEdit_Cashless.DoValidate();
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLineCashless.Payment < 0)
                e.Cancel = true;
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
            LookUpEdit editor = sender as LookUpEdit;
            trPaymentLineCashless.CurrencyCode = lUE_CashlessCurrency.EditValue.ToString();
            trPaymentLineCashless.ExchangeRate = (float)editor.GetColumnValue("ExchangeRate");
            FillControls();
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

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SavePayment(false);
        }

        private void SavePayment(bool autoPayment)
        {
            if (trPaymentLineCashless.PaymentLoc > 0) // lUE_PaymentMethod Validation
                if (lUE_PaymentMethod.EditValue == null)
                {
                    dxErrorProvider1.SetError(this.lUE_PaymentMethod, "Boş buraxıla bilməz!");
                    return;
                }

            if (trPaymentLineCash.PaymentLoc > 0 || trPaymentLineCashless.PaymentLoc > 0)
            {
                EfMethods efMethods = new();
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
                trPaymentHeader.DocumentNumber = NewDocNum;

                if (autoPayment)
                {
                    efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);

                    efMethods.InsertPaymentHeader(trPaymentHeader);

                    List<TrInvoiceLine> trInvoiceLines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
                    foreach (TrInvoiceLine il in trInvoiceLines)
                    {
                        trPaymentLineCash.PaymentLineId = Guid.NewGuid();
                        trPaymentLineCash.Payment = isNegativ ? il.NetAmount * (-1) : il.NetAmount;
                        trPaymentLineCash.CurrencyCode = il.CurrencyCode;
                        trPaymentLineCash.ExchangeRate = il.ExchangeRate;
                        trPaymentLineCash.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;

                        efMethods.InsertPaymentLine(trPaymentLineCash);
                    }
                }
                else
                {
                    efMethods.InsertPaymentHeader(trPaymentHeader);

                    if (trPaymentLineCash.PaymentLoc > 0)
                    {
                        trPaymentLineCash.PaymentLineId = Guid.NewGuid();
                        trPaymentLineCash.Payment = isNegativ ? trPaymentLineCash.Payment * (-1) : trPaymentLineCash.Payment;
                        efMethods.InsertPaymentLine(trPaymentLineCash);
                    }

                    if (trPaymentLineCashless.PaymentLoc > 0)
                    {
                        trPaymentLineCashless.PaymentLineId = Guid.NewGuid();
                        trPaymentLineCashless.Payment = isNegativ ? trPaymentLineCashless.Payment * (-1) : trPaymentLineCashless.Payment;
                        efMethods.InsertPaymentLine(trPaymentLineCashless);
                    }
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnEdit_CashRegister_Validating(object sender, CancelEventArgs e)
        {
            object eValue = btnEdit_CashRegister.EditValue;

            if (eValue is not null)
            {
                DcCurrAcc curr = efMethods.SelectCurrAcc(eValue.ToString());

                if (curr is null)
                {
                    e.Cancel = true;
                }
                else
                {
                    trPaymentLineCash.CashRegisterCode = eValue.ToString();
                }
            }
        }

        private void btnEdit_CashRegister_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Belə bir kassa yoxdur";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void btnEdit_BankAccout_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            object row = lUE_PaymentMethod.Properties.GetDataSourceRowByKeyValue(lUE_PaymentMethod.EditValue);
            if (row is not null)
            {
                byte paymentTypeCode = ((DcPaymentMethod)row).PaymentTypeCode;
                SelectCashRegister(sender, paymentTypeCode);
            }
        }

        private void lUE_PaymentMethod_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            trPaymentLineCashless.PaymentMethodId = Convert.ToInt32(editor.EditValue);
            object value = editor.GetColumnValue("DefaultCashRegCode");
            btnEdit_BankAccout.EditValue = value;
        }

        private void btnEdit_CashRegister_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            trPaymentLineCash.CashRegisterCode = buttonEdit.EditValue.ToString();
        }

        private void btnEdit_BankAccout_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            trPaymentLineCashless.CashRegisterCode = buttonEdit.EditValue.ToString();
        }
    }
}