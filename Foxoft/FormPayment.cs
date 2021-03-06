using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using System;
using System.ComponentModel;
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

      public FormPayment()
      {
         InitializeComponent();
         AcceptButton = btn_Ok;
         CancelButton = btn_Cancel;

         lUE_cashCurrency.Properties.DataSource = efMethods.SelectCurrencies();
         lUE_CashlessCurrency.Properties.DataSource = efMethods.SelectCurrencies();
      }

      public FormPayment(byte paymentType, decimal invoiceSumLoc, TrInvoiceHeader trInvoiceHeader)
         : this()
      {
         PaymentHeaderId = Guid.NewGuid();

         trPaymentLine.PaymentHeaderId = PaymentHeaderId;
         trPaymentLine.PaymentLineId = Guid.NewGuid();
         trPaymentLine.PaymentTypeCode = paymentType;
         trPaymentLine.CurrencyCode = "USD";
         trPaymentLine.ExchangeRate = 1f;
         trPaymentLine.CashRegisterCode = "kassa01";
         trPaymentLine.CreatedUserName = Authorization.CurrAccCode;

         this.trInvoiceHeader = trInvoiceHeader;

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
         //if (invoiceSumLoc > 0)
         //   if (autoMakePayment)
         //      SavePayment();
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
         SelectCurrAcc(sender);
      }

      private void lUE_cashCurrency_EditValueChanged(object sender, EventArgs e)
      {
         LookUpEdit editor = sender as LookUpEdit;
         trPaymentLine.CurrencyCode = lUE_cashCurrency.EditValue.ToString();
         trPaymentLine.ExchangeRate = (float)editor.GetColumnValue("ExchangeRate");
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

      private void btn_Ok_Click(object sender, EventArgs e)
      {
         SavePayment();
      }

      private void SavePayment()
      {
         EfMethods efMethods = new EfMethods();

         decimal cash = trPaymentLine.PaymentLoc;

         string NewDocNum = efMethods.GetNextDocNum("PA", "DocumentNumber", "TrPaymentHeaders", 6);

         bool invoiceExist = trInvoiceHeader.InvoiceHeaderId != Guid.Empty && trInvoiceHeader != null;

         string operType = "payment";
         if (invoiceExist)
            operType = "invoice";

         if (cash > 0)
         {
            TrPaymentHeader trPaymentHead = new TrPaymentHeader();

            trPaymentHead.PaymentHeaderId = PaymentHeaderId;
            trPaymentHead.DocumentNumber = NewDocNum;
            trPaymentHead.CurrAccCode = trInvoiceHeader.CurrAccCode;
            trPaymentHead.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHead.OfficeCode = Authorization.OfficeCode;
            trPaymentHead.StoreCode = Authorization.StoreCode;
            trPaymentHead.DocumentDate = trInvoiceHeader.DocumentDate;
            trPaymentHead.DocumentTime = trInvoiceHeader.DocumentTime;
            if (invoiceExist)
               trPaymentHead.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
            trPaymentHead.OperationType = operType;
            trPaymentHead.OperationDate = DateTime.Parse(dateEdit_Date.EditValue.ToString());
            efMethods.InsertPaymentHeader(trPaymentHead);

            trPaymentLine.Payment = isNegativ ? trPaymentLine.Payment * (-1) : trPaymentLine.Payment;
            efMethods.InsertPaymentLine(trPaymentLine);

            DialogResult = DialogResult.OK;
         }
      }
   }
}