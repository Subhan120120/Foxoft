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
        private int PaymentType { get; set; }
        private decimal bePaid { get; set; }
        private decimal summary { get; set; }
        private TrInvoiceHeader trInvoiceHeader { get; set; }
        private EfMethods efMethods = new EfMethods();

        private string defaultCurrency;
        private float exRate = 1;

        private bool isNegativ = false;

        private decimal cashLarge = 0;
        private decimal cashless = 0;
        private decimal bonus = 0;

        public FormPayment(int PaymentType, decimal invoiceSum, TrInvoiceHeader trInvoiceHeader)
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            lUE_cashCurrency.Properties.DataSource = efMethods.SelectCurrencies();

            if (CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In")
                invoiceSum *= (-1);

            if (trInvoiceHeader.IsReturn)
                invoiceSum *= (-1);

            decimal prePaid = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId);
            invoiceSum = Math.Round(invoiceSum - prePaid, 2);

            if (invoiceSum < 0)
                isNegativ = true;

            defaultCurrency = "USD";

            this.PaymentType = PaymentType;
            this.summary = Math.Abs(invoiceSum);
            this.PaymentHeaderId = Guid.NewGuid();
            this.trInvoiceHeader = trInvoiceHeader;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            //decimal prePaid = Math.Round(efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId), 2); //əvvəlcədən ödənilən

            FillControls();
        }

        private void FillControls()
        {
            switch (PaymentType)
            {
                case 1: txtEdit_Cash.EditValue = bePaid; break;
                case 2: txtEdit_Cashless.EditValue = bePaid; break;
                case 3: txtEdit_Bonus.EditValue = bePaid; break;
                default: txtEdit_Cash.EditValue = bePaid; break;
            }

            dateEdit_Date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            lUE_cashCurrency.EditValue = defaultCurrency;
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCash = Convert.ToDecimal(txtEdit_Cash.EditValue);
            cashLarge = txtCash;
            txtEdit_Cash.DoValidate();
        }

        private void textEditCash_Validating(object sender, CancelEventArgs e)
        {
            if (cashLarge < 0)
                e.Cancel = true;
        }

        private void textEditCash_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 dan az olmamalıdır";
        }

        private void simpleButtonUpdateCash_Click(object sender, EventArgs e)
        {
            decimal restAmount = bePaid - cashless + bonus;
            if (restAmount >= 0)
                txtEdit_Cash.EditValue = restAmount;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtCashless = Convert.ToDecimal(txtEdit_Cashless.EditValue);
            cashless = txtCashless;
            txtEdit_Cashless.DoValidate();
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            if (!cashless.Between(0, bePaid, true))
                e.Cancel = true;
        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən (" + bePaid + "'dan) çox olmamalıdır";
        }

        private void simpleButtonUpdateCashless_Click(object sender, EventArgs e)
        {
            decimal restAmount = bePaid - cashLarge + bonus;
            if (restAmount >= 0)
                txtEdit_Cashless.EditValue = restAmount;
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            decimal txtBonus = Convert.ToDecimal(txtEdit_Bonus.EditValue);
            bonus = txtBonus;
            txtEdit_Bonus.DoValidate();
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
            if (!cashless.Between(0, bePaid, true))
                e.Cancel = true;
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən " + bePaid + "dan çox olmamalıdır";
        }

        private void simpleButtonUpdateBonus_Click(object sender, EventArgs e)
        {
            decimal restAmount = bePaid - cashLarge + cashless;
            if (restAmount >= 0)
                txtEdit_Bonus.EditValue = restAmount;
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



            //if ((cashLarge + cashless + bonus) < bePaid)
            //    XtraMessageBox.Show("Ödəmə ödənilməli olan məbləğdən azdır");
            //else{

            decimal cash = bePaid - cashless - bonus;
            //if (cash > cashLarge)
            cash = cashLarge;

            //if (!efMethods.PaymentHeaderExist(InvoiceHeaderId))
            //{
            string NewDocNum = efMethods.GetNextDocNum("PA", "DocumentNumber", "TrPaymentHeaders");

            string operType = "invoice";
            if (trInvoiceHeader.InvoiceHeaderId == Guid.Empty || trInvoiceHeader == null)
                operType = "payment";


            if ((cash + cashless + bonus) > 0)
            {
                TrPaymentHeader trPayment = new TrPaymentHeader();

                trPayment.PaymentHeaderId = PaymentHeaderId;
                trPayment.DocumentNumber = NewDocNum;
                trPayment.CurrAccCode = trInvoiceHeader.CurrAccCode;
                trPayment.OfficeCode = trInvoiceHeader.OfficeCode;
                trPayment.StoreCode = trInvoiceHeader.StoreCode;
                trPayment.DocumentDate = trInvoiceHeader.DocumentDate;
                trPayment.DocumentTime = trInvoiceHeader.DocumentTime;
                if (trInvoiceHeader.InvoiceHeaderId != Guid.Empty)
                    trPayment.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
                trPayment.OperationType = operType;
                trPayment.OperationDate = DateTime.Parse(dateEdit_Date.EditValue.ToString());
                efMethods.InsertPaymentHeader(trPayment);


                TrPaymentLine TrPaymentLine = new TrPaymentLine()
                {
                    PaymentHeaderId = PaymentHeaderId
                };

                if (cash > 0)
                {
                    decimal cashLoc = cash * (decimal)exRate; //convert currency to local

                    TrPaymentLine.PaymentLineId = Guid.NewGuid();
                    TrPaymentLine.Payment = isNegativ ? cash * (-1) : cash;
                    TrPaymentLine.PaymentLoc = isNegativ ? cashLoc * (-1) : cashLoc;
                    TrPaymentLine.PaymentTypeCode = 1;
                    efMethods.InsertPaymentLine(TrPaymentLine);
                }

                if (cashless > 0)
                {
                    decimal cashlessLoc = cashless * (decimal)exRate; //convert currency to local

                    TrPaymentLine.PaymentLineId = Guid.NewGuid();
                    TrPaymentLine.Payment = isNegativ ? cashless * (-1) : cashless;
                    TrPaymentLine.PaymentLoc = isNegativ ? cashlessLoc * (-1) : cashlessLoc;
                    TrPaymentLine.PaymentTypeCode = 2;
                    efMethods.InsertPaymentLine(TrPaymentLine);
                }

                if (bonus > 0)
                {
                    decimal bonusLoc = bonus * (decimal)exRate; //convert currency to local

                    TrPaymentLine.PaymentLineId = Guid.NewGuid();
                    TrPaymentLine.Payment = isNegativ ? bonus * (-1) : bonus;
                    TrPaymentLine.PaymentLoc = isNegativ ? bonusLoc * (-1) : bonusLoc;
                    TrPaymentLine.PaymentTypeCode = 3;
                    efMethods.InsertPaymentLine(TrPaymentLine);
                }


                decimal change = cashLarge + cashless + bonus - bePaid;
                //if (change > 0)
                //{
                //    using (FormChange formChange = new FormChange(cashLarge, change))
                //    {
                //        formChange.ShowDialog(this);
                //    }
                //}
                //}
                //else
                //    XtraMessageBox.Show("Odenis Movcuddur");
                DialogResult = DialogResult.OK;
                //}
            }
        }

        private void lUE_cashCurrency_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            defaultCurrency = lUE_cashCurrency.EditValue.ToString();
            exRate = (float)editor.GetColumnValue("ExchangeRate");
            bePaid = Math.Round(summary / (decimal)exRate, 2);
            FillControls();
        }
    }
}