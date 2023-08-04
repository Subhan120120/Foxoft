using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcReturn : UserControl
    {
        public Guid returnInvoiceHeaderId;
        public TrInvoiceHeader trInvoiceHeader;
        public TrInvoiceHeader returnInvoHeader;
        public Guid invoiceLineID;
        public string processCode;

        EfMethods efMethods = new();

        public UcReturn()
        {
            InitializeComponent();
        }

        public UcReturn(string processCode)
           : this()
        {
            this.processCode = processCode;
        }

        private void UcReturn_Load(object sender, EventArgs e)
        {
            ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                efMethods.DeleteInvoice(returnInvoiceHeaderId);
        }

        private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using (FormInvoiceLineList form = new(processCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Guid invoiceHeaderId = form.trInvoiceLine.InvoiceHeaderId;

                    trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                    btnEdit_InvoiceHeader.EditValue = trInvoiceHeader.DocumentNumber;

                    if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                        efMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete previous invoice
                    returnInvoiceHeaderId = Guid.NewGuid();                             // create next invoice

                    LoadInvoice(trInvoiceHeader);
                }
            }
        }

        private void LoadInvoice(TrInvoiceHeader invoiceHeader)
        {
            gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeader.InvoiceHeaderId);
            gC_PaymentLine.DataSource = efMethods.SelectPaymentLinesByInvoice(invoiceHeader.InvoiceHeaderId);
            gC_ReturnInvoiceLine.DataSource = null;

            if (invoiceHeader.DcCurrAcc is not null)
                txt_CurrAccDesc.Text = invoiceHeader.DcCurrAcc.CurrAccDesc;

            CalcPaidAmount();
        }
        private void CalcPaidAmount()
        {
            //decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            //lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " USD";
        }

        private void repobtn_ReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //ButtonEdit editor = (ButtonEdit)sender;
            //int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            //if (buttonIndex == 0)
            //{

            Guid invoiceLineID = (Guid)gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId);
            int maxReturn = Convert.ToInt32(gV_InvoiceLine.GetFocusedRowCellValue(col_RemainingQty));

            if (maxReturn > 0)
            {
                using (FormQty formQty = new(maxReturn))
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {

                        if (!efMethods.InvoiceHeaderExist(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                        {
                            string NewDocNum = efMethods.GetNextDocNum(true, processCode, "DocumentNumber", "TrInvoiceHeaders", 6);

                            returnInvoHeader = new();

                            returnInvoHeader.InvoiceHeaderId = returnInvoiceHeaderId;
                            returnInvoHeader.DocumentNumber = NewDocNum;
                            returnInvoHeader.ProcessCode = trInvoiceHeader.ProcessCode;
                            returnInvoHeader.IsReturn = true;
                            returnInvoHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;

                            returnInvoHeader.OfficeCode = Authorization.OfficeCode;
                            returnInvoHeader.StoreCode = Authorization.StoreCode;
                            returnInvoHeader.CreatedUserName = Authorization.CurrAccCode;
                            returnInvoHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
                            returnInvoHeader.IsMainTF = true;

                            efMethods.InsertInvoiceHeader(returnInvoHeader);
                        }

                        if (!efMethods.InvoiceLineExistByRelatedLine(returnInvoiceHeaderId, invoiceLineID))
                        {
                            TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);

                            TrInvoiceLine returnInvoiceLine = new();

                            //returnInvoiceLine.TrInvoiceHeader = returnInvoHeader;

                            returnInvoiceLine.InvoiceLineId = Guid.NewGuid();
                            returnInvoiceLine.InvoiceHeaderId = returnInvoiceHeaderId;
                            returnInvoiceLine.RelatedLineId = invoiceLineID;
                            returnInvoiceLine.ProductCode = invoiceLine.ProductCode;

                            if (CustomExtensions.ProcessDir(processCode) == "In")
                                returnInvoiceLine.QtyIn = formQty.qty * (-1);
                            else if (CustomExtensions.ProcessDir(processCode) == "Out")
                                returnInvoiceLine.QtyOut = formQty.qty * (-1);

                            returnInvoiceLine.Price = invoiceLine.Price;
                            returnInvoiceLine.PriceLoc = invoiceLine.PriceLoc;
                            returnInvoiceLine.CurrencyCode = invoiceLine.CurrencyCode;
                            returnInvoiceLine.Amount = Convert.ToDecimal(formQty.qty * invoiceLine.Price * (-1));
                            returnInvoiceLine.AmountLoc = Convert.ToDecimal(formQty.qty * invoiceLine.Price * (-1));
                            returnInvoiceLine.PosDiscount = invoiceLine.PosDiscount;
                            returnInvoiceLine.ExchangeRate = invoiceLine.ExchangeRate;
                            returnInvoiceLine.VatRate = invoiceLine.VatRate;
                            returnInvoiceLine.NetAmount = formQty.qty * invoiceLine.NetAmount / invoiceLine.Qty * (-1);
                            returnInvoiceLine.NetAmountLoc = formQty.qty * invoiceLine.NetAmountLoc / invoiceLine.Qty * (-1);
                            returnInvoiceLine.CreatedUserName = Authorization.CurrAccCode;

                            efMethods.InsertInvoiceLine(returnInvoiceLine);

                            List<TrInvoiceLine> asdas = efMethods.SelectInvoiceLines(returnInvoiceHeaderId);
                            gC_ReturnInvoiceLine.DataSource = asdas;
                        }
                        else
                            efMethods.UpdateInvoiceLineQtyOut(returnInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
                    }
                }
            }
            else
                XtraMessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            decimal sumNetAmount = efMethods.SelectInvoiceNetAmount(returnInvoiceHeaderId);

            if (sumNetAmount != 0)
            {
                //SimpleButton simpleButton = sender as SimpleButton;

                //byte paymentType = simpleButton.Name switch
                //{
                //   "simpleButtonCash" => 1,
                //   "simpleButtonCashless" => 2,
                //   "simpleButtonCustomerBonus" => 3,
                //   _ => 0
                //};

                //using FormPayment formPayment = new(paymentType, sumNetAmount, new TrInvoiceHeader() { });

                //if (formPayment.ShowDialog(this) == DialogResult.OK)
                //{

                returnInvoiceHeaderId = Guid.NewGuid();
                efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

                MakePayment(sumNetAmount, false);

                trInvoiceHeader = null;
                gC_InvoiceLine.DataSource = null;
                gC_PaymentLine.DataSource = null;
                gC_ReturnInvoiceLine.DataSource = null;
                btnEdit_InvoiceHeader.EditValue = null;
                txt_CurrAccDesc.Text = null;
            }
            else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void MakePayment(decimal summaryInvoice, bool autoPayment)
        {
            using FormPayment formPayment = new(1, summaryInvoice, returnInvoHeader, autoPayment);

            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }
            else
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK) { }
            }
        }

        private void gV_ReturnInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            //string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]));
            decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]));
            decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]));
            string strVatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);
            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SalesPersonCode"]);
            float VatRate = float.Parse(strVatRate);

            e.PreviewText = CustomExtensions.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, String.Empty, SalesPersonCode);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Geri Qaytarma Ləğv Edilsin?", "Təsdiqlə", MessageBoxButtons.YesNo) == DialogResult.Yes)
                efMethods.DeleteInvoice(returnInvoiceHeaderId);
        }
    }
}
