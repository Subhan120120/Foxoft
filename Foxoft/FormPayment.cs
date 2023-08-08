﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
        private TrPaymentLine trPaymentLine = new();
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
            decimal mustPaid = Math.Round(invoiceSumLoc - prePaid, 2);

            if (mustPaid < 0)
                isNegativ = true;

            decimal mustPaidABS = Math.Abs(mustPaid);

            trPaymentLine.Payment = mustPaidABS;
        }

        public FormPayment(byte paymentType, decimal invoiceSumLoc, TrInvoiceHeader trInvoiceHeader, bool autoMakePayment)
           : this(paymentType, invoiceSumLoc, trInvoiceHeader)
        {
            if (trPaymentLine.Payment > 0)
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

            trPaymentLine.PaymentHeaderId = PaymentHeaderId;
            trPaymentLine.PaymentTypeCode = paymentType;
            trPaymentLine.PaymentMethodId = 1;
            trPaymentLine.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLine.ExchangeRate = 1;

            string cashReg = efMethods.SelectDefaultCashRegister(Authorization.StoreCode);
            if (!String.IsNullOrEmpty(cashReg))
                trPaymentLine.CashRegisterCode = cashReg;
            trPaymentLine.CreatedUserName = Authorization.CurrAccCode;
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

        private void dateEdit_Date_EditValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateEdit_Date.EditValue);
            trPaymentHeader.OperationDate = date;
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCash = Convert.ToDecimal(txtEdit_Cash.EditValue);
            trPaymentLine.Payment = txtCash;
            txtEdit_Cash.DoValidate();
        }

        private void txtEdit_Cash_Validating(object sender, CancelEventArgs e)
        {
            if (!(trPaymentLine.Payment > 0))
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
            trPaymentLine.CurrencyCode = lUE_cashCurrency.EditValue.ToString();
            trPaymentLine.ExchangeRate = (float)editor.GetColumnValue("ExchangeRate");
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
                    trPaymentLine.CashRegisterCode = form.dcCurrAcc.CurrAccCode;
                }
            }
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

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SavePayment(false);
        }

        private void SavePayment(bool autoPayment)
        {
            if (trPaymentLine.PaymentLoc > 0)
            {
                EfMethods efMethods = new();
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
                trPaymentHeader.DocumentNumber = NewDocNum;

                if (autoPayment)
                {
                    efMethods.DeletePaymentsByInvoice(trInvoiceHeader.InvoiceHeaderId);

                    efMethods.InsertPaymentHeader(trPaymentHeader);

                    List<TrInvoiceLine> trInvoiceLines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
                    foreach (TrInvoiceLine il in trInvoiceLines)
                    {
                        trPaymentLine.PaymentLineId = Guid.NewGuid();
                        trPaymentLine.Payment = isNegativ ? il.NetAmount * (-1) : il.NetAmount;
                        trPaymentLine.CurrencyCode = il.CurrencyCode;
                        trPaymentLine.ExchangeRate = il.ExchangeRate;
                        trPaymentLine.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;

                        efMethods.InsertPaymentLine(trPaymentLine);
                    }
                }
                else
                {
                    efMethods.InsertPaymentHeader(trPaymentHeader);

                    trPaymentLine.PaymentLineId = Guid.NewGuid();
                    trPaymentLine.Payment = isNegativ ? trPaymentLine.Payment * (-1) : trPaymentLine.Payment;

                    efMethods.InsertPaymentLine(trPaymentLine);
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
                    trPaymentLine.CashRegisterCode = eValue.ToString();
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
            object value = editor.GetColumnValue("DefaultCashRegCode");
            btnEdit_BankAccout.EditValue = value;
        }
    }
}