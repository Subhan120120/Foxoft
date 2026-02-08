using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
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
        DcLoyaltyCard loyaltyCard;

        subContext dbContext = new();

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
            if (efMethods.EntityExists<TrInvoiceHeader>(returnInvoiceHeaderId))
                efMethods.DeleteInvoice(returnInvoiceHeaderId);
        }

        private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using (FormInvoiceLineList form = new(new string[] { processCode }))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    ClearControls();

                    if (efMethods.EntityExists<TrInvoiceHeader>(returnInvoiceHeaderId))
                        efMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete previous invoice

                    returnInvoiceHeaderId = Guid.NewGuid();                   // create next invoice

                    Guid invoiceHeaderId = form.trInvoiceLine.InvoiceHeaderId;

                    trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                    btnEdit_InvoiceHeader.EditValue = trInvoiceHeader.DocumentNumber;

                    LoadInvoice(trInvoiceHeader);
                }
            }
        }

        private void LoadInvoice(TrInvoiceHeader invoiceHeader)
        {
            gC_InvoiceLine.DataSource = efMethods.SelectReturnLineVMs(invoiceHeader.InvoiceHeaderId);
            gC_PaymentLine.DataSource = efMethods.SelectPaymentLinesByInvoice(invoiceHeader.InvoiceHeaderId);

            if (invoiceHeader.DcCurrAcc is not null)
                txt_CurrAccDesc.Text = invoiceHeader.DcCurrAcc.CurrAccDesc;

            CalcPaidAmount();

            Tag = invoiceHeader.DocumentNumber;
        }

        private void CalcPaidAmount()
        {
            //decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            //lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " USD";
        }

        private void repobtn_ReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Guid invoiceLineID = (Guid)gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId);
            decimal maxReturn = Convert.ToDecimal(gV_InvoiceLine.GetFocusedRowCellValue(col_RemainingQty));

            if (maxReturn > 0)
            {
                using (FormInput formQty = new(maxReturn, maxReturn))
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        if (!efMethods.EntityExists<TrInvoiceHeader>(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                        {
                            string newDocNum = efMethods.GetNextDocNum(
                                true,
                                processCode,
                                nameof(TrInvoiceHeader.DocumentNumber),
                                nameof(subContext.TrInvoiceHeaders),
                                6);

                            returnInvoHeader = new();
                            returnInvoHeader.InvoiceHeaderId = returnInvoiceHeaderId;
                            returnInvoHeader.RelatedInvoiceId = trInvoiceHeader.InvoiceHeaderId;
                            returnInvoHeader.DocumentNumber = newDocNum;
                            returnInvoHeader.ProcessCode = trInvoiceHeader.ProcessCode;
                            returnInvoHeader.IsReturn = true;
                            returnInvoHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
                            returnInvoHeader.OfficeCode = Authorization.OfficeCode;
                            returnInvoHeader.StoreCode = Authorization.StoreCode;
                            returnInvoHeader.CreatedUserName = Authorization.CurrAccCode;
                            returnInvoHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
                            returnInvoHeader.IsMainTF = true;
                            returnInvoHeader.IsCompleted = true;

                            efMethods.InsertEntity(returnInvoHeader);
                        }

                        if (!efMethods.ReturnExistByInvoiceLine(returnInvoiceHeaderId, invoiceLineID))
                        {
                            TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);

                            TrInvoiceLine returnInvoiceLine = new();

                            //returnInvoiceLine.TrInvoiceHeader = returnInvoHeader;

                            returnInvoiceLine.InvoiceLineId = Guid.NewGuid();
                            returnInvoiceLine.InvoiceHeaderId = returnInvoiceHeaderId;
                            returnInvoiceLine.RelatedLineId = invoiceLineID;
                            returnInvoiceLine.ProductCode = invoiceLine.ProductCode;
                            returnInvoiceLine.ProductCost = invoiceLine.ProductCost;

                            if ((bool)CustomExtensions.DirectionIsIn(processCode))
                                returnInvoiceLine.QtyIn = formQty.input * (-1);
                            else if (!(bool)CustomExtensions.DirectionIsIn(processCode))
                                returnInvoiceLine.QtyOut = formQty.input * (-1);

                            returnInvoiceLine.UnitOfMeasureId = invoiceLine.UnitOfMeasureId;
                            returnInvoiceLine.Price = invoiceLine.Price;
                            returnInvoiceLine.PriceLoc = invoiceLine.PriceLoc;
                            returnInvoiceLine.CurrencyCode = invoiceLine.CurrencyCode;
                            returnInvoiceLine.Amount = Convert.ToDecimal(formQty.input * invoiceLine.Price * (-1));
                            returnInvoiceLine.AmountLoc = Convert.ToDecimal(formQty.input * invoiceLine.Price * (-1));
                            returnInvoiceLine.PosDiscount = invoiceLine.PosDiscount;
                            returnInvoiceLine.ExchangeRate = invoiceLine.ExchangeRate;
                            returnInvoiceLine.VatRate = invoiceLine.VatRate;
                            returnInvoiceLine.SerialNumberCode = invoiceLine.SerialNumberCode;
                            returnInvoiceLine.NetAmount = formQty.input * invoiceLine.NetAmount / invoiceLine.Qty * (-1);
                            returnInvoiceLine.NetAmountLoc = formQty.input * invoiceLine.NetAmountLoc / invoiceLine.Qty * (-1);
                            returnInvoiceLine.CreatedUserName = Authorization.CurrAccCode;

                            efMethods.InsertEntity(returnInvoiceLine);
                        }
                        else
                        {
                            TrInvoiceLine trInvoiceLine = efMethods.SelectTrInvoiceLineByRelatedLineId(returnInvoiceHeaderId, invoiceLineID);

                            trInvoiceLine.Amount = (-1) * formQty.input * trInvoiceLine.Price;
                            trInvoiceLine.AmountLoc = (-1) * formQty.input * trInvoiceLine.PriceLoc;
                            trInvoiceLine.NetAmount = (-1) * formQty.input * trInvoiceLine.Price * (100 - trInvoiceLine.PosDiscount);
                            trInvoiceLine.NetAmountLoc = (-1) * formQty.input * trInvoiceLine.PriceLoc * (100 - trInvoiceLine.PosDiscount);
                            trInvoiceLine.QtyOut = formQty.input + trInvoiceLine.QtyOut;

                            efMethods.UpdateEntity(trInvoiceLine);
                        }

                        SyncLoyaltyEarn(trInvoiceHeader);


                        List<TrInvoiceLine> returnLines = efMethods.SelectInvoiceLines(returnInvoiceHeaderId);
                        gC_ReturnInvoiceLine.DataSource = returnLines;

                        gC_InvoiceLine.DataSource = efMethods.SelectReturnLineVMs(trInvoiceHeader.InvoiceHeaderId);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_Return_Message_NoQtyToReturn);
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            decimal sumNetAmount = efMethods.SelectInvoiceNetAmount(returnInvoiceHeaderId);

            if (sumNetAmount != 0)
            {
                efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

                //MakePayment(sumNetAmount, false);
                if (DialogResult.OK == XtraMessageBox.Show(
                        Resources.Form_Return_Message_OpenInvoiceQuestion,
                        Resources.Form_Return_Caption_OpenInvoice,
                        MessageBoxButtons.OKCancel))
                {
                    OpenFormInvoice(returnInvoHeader.DocumentNumber);
                }

                ClearControls();
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_Return_Message_PaymentIsZero);
            }
        }

        private void ClearControls()
        {
            returnInvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader = null;
            gC_InvoiceLine.DataSource = null;
            gC_PaymentLine.DataSource = null;
            gC_ReturnInvoiceLine.DataSource = null;
            btnEdit_InvoiceHeader.EditValue = null;
            txt_CurrAccDesc.Text = null;
        }

        private void OpenFormInvoice(string strDocNum)
        {
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeaderByDocNum(strDocNum);

            if (trInvoiceHeader is not null)
            {
                string claim = CustomExtensions.GetClaim(trInvoiceHeader.ProcessCode);

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show(Resources.Common_AccessDenied);
                    return;
                }

                byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

                FormInvoice frm = new(trInvoiceHeader.ProcessCode, null, bytes, null, trInvoiceHeader.InvoiceHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
            else
            {
                MessageBox.Show(Resources.Form_Return_Message_InvoiceNotFound);
            }
        }

        private void gV_ReturnInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            decimal posDiscount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.PosDiscount)]));

            decimal amount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.Amount)]));

            decimal netAmount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.NetAmount)]));

            string strVatRate = view.GetRowCellDisplayText(
                e.RowHandle, view.Columns[nameof(TrInvoiceLine.VatRate)]);

            string salesPersonCode = view.GetRowCellDisplayText(
                e.RowHandle, view.Columns[nameof(TrInvoiceLine.SalesPersonCode)]);

            float vatRate = float.Parse(strVatRate);

            e.PreviewText = CustomExtensions.GetPreviewText(
                posDiscount,
                amount,
                netAmount,
                vatRate,
                string.Empty,
                salesPersonCode);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Resources.Form_Return_Message_CancelReturnQuestion,
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (efMethods.EntityExists<TrInvoiceHeader>(returnInvoiceHeaderId))
                {
                    efMethods.DeleteInvoice(returnInvoiceHeaderId);

                    ClearControls();
                }
            }
        }

        private void SyncLoyaltyEarn(TrInvoiceHeader inv)
        {
            if (inv == null || inv.InvoiceHeaderId == Guid.Empty)
                return;

            loyaltyCard = dbContext.Set<TrLoyaltyTxn>()
                .AsNoTracking()
                .Include(x => x.DcLoyaltyCard)
                    .ThenInclude(c => c.DcLoyaltyProgram)
                .Where(x => x.InvoiceHeaderId == inv.InvoiceHeaderId
                         && x.TxnType == LoyaltyTxnType.Earn)
                .Select(x => x.DcLoyaltyCard)
                .FirstOrDefault();

            if (loyaltyCard == null)
            {
                //RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            var earnPercent = loyaltyCard.DcLoyaltyProgram?.EarnPercent ?? 0m;

            if (earnPercent <= 0m)
            {
                //RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            // NetAmountLoc-u grid-dən yox, context-dən götürmək daha sağlamdır
            decimal netLoc = dbContext.TrInvoiceLines
                .AsNoTracking()
                .Where(x => x.InvoiceHeaderId == returnInvoHeader.InvoiceHeaderId)
                .Sum(x => (decimal?)x.NetAmountLoc) ?? 0m;

            if (netLoc == 0m)
            {
                //RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            TrLoyaltyTxn txn = new TrLoyaltyTxn
            {
                LoyaltyTxnId = Guid.NewGuid(),
                InvoiceHeaderId = returnInvoHeader.InvoiceHeaderId,
                LoyaltyCardId = loyaltyCard.LoyaltyCardId,
                Amount = netLoc * loyaltyCard.DcLoyaltyProgram.EarnPercent / 100,
                CurrAccCode = inv.CurrAccCode,
                CreatedUserName = Authorization.CurrAccCode,
                DocumentDate = inv.DocumentDate,
                TxnType = LoyaltyTxnType.Reverse,
                Note = $"Invoice: {inv.DocumentNumber}"
            };
            dbContext.Set<TrLoyaltyTxn>().Add(txn);
            dbContext.SaveChanges();
        }

        private void RemoveEarnTxn(Guid invoiceHeaderId)
        {
            if (loyaltyCard == null) return;

            var txn = dbContext.Set<TrLoyaltyTxn>()
                .FirstOrDefault(x =>
                    x.InvoiceHeaderId == invoiceHeaderId &&
                    x.LoyaltyCardId == loyaltyCard.LoyaltyCardId &&
                    (x.TxnType == LoyaltyTxnType.Earn || x.TxnType == LoyaltyTxnType.Reverse));

            if (txn != null)
                dbContext.Set<TrLoyaltyTxn>().Remove(txn);
        }

    }
}
