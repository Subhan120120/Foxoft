using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Foxoft
{
    public partial class UcReturn : UserControl
    {
        public Guid returnInvoiceHeaderId;
        public TrInvoiceHeader trInvoiceHeader;
        public TrInvoiceHeader returnInvoHeader;
        public Guid invoiceLineID;
        public string processCode;

        private readonly subContext _db = new();
        private readonly LoyaltyService _loyalty;
        private readonly DocumentLockService _lockService;

        subContext dbContext = new();

        EfMethods efMethods = new();

        public UcReturn()
        {
            InitializeComponent();

            _loyalty = new LoyaltyService(_db);
            _lockService = new DocumentLockService(_db);
        }

        public UcReturn(string processCode)
           : this()
        {
            this.processCode = processCode;
        }

        private void UcReturn_Load(object sender, EventArgs e)
        {
            ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (efMethods.EntityExists<TrInvoiceHeader>(returnInvoiceHeaderId))
                efMethods.DeleteInvoice(returnInvoiceHeaderId);
        }

        private bool TryActivateOpenInvoiceWindow(Guid invoiceHeaderId, FormERP formERP)
        {
            if (formERP == null)
                return false;

            foreach (Form child in formERP.MdiChildren)
            {
                if (child is FormInvoice frm &&
                    frm.trInvoiceHeader is not null &&
                    frm.trInvoiceHeader.InvoiceHeaderId == invoiceHeaderId)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.BringToFront();
                    frm.Activate();
                    return true;
                }
            }

            return false;
        }

        private bool TryAcquireInvoiceLockForEdit(Guid invoiceHeaderId, FormERP formERP, Guid formInstanceId)
        {
            if (formERP == null)
                return false;

            var res = _lockService.TryAcquireLock(
                documentType: "Invoice",
                documentId: invoiceHeaderId,
                userId: Authorization.CurrAccCode,
                machineName: Environment.MachineName,
                appInstanceId: formERP._appInstanceId,
                formInstanceId: formInstanceId,
                clientProcessId: Process.GetCurrentProcess().Id,
                timeout: TimeSpan.FromMinutes(10),
                reason: "Edit invoice");

            if (!res.Acquired)
            {
                if (res.LockedBy == Authorization.CurrAccCode &&
                    res.AppInstanceId == formERP._appInstanceId)
                {
                    if (TryActivateOpenInvoiceWindow(invoiceHeaderId, formERP))
                        return false;
                }

                DialogResult answer = XtraMessageBox.Show(
                    $"Faktura hazırda {res.LockedByName} tərəfindən redaktə olunur.\n" +
                    $"Machine: {res.MachineName}\n" +
                    $"LockedAt: {res.LockedAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n" +
                    $"Heartbeat: {res.LastHeartbeatAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n\n" +
                    $"Sənəd sahibinə bağlama sorğusu göndərilsin?",
                    "Sənəd lock olunub",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    _lockService.RequestOwnerToClose(
                        documentType: "Invoice",
                        documentId: invoiceHeaderId,
                        requestedByUserId: Authorization.CurrAccCode,
                        note: "Another user wants to edit this invoice.");
                }

                return false;
            }

            return true;
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
                            returnInvoHeader.LoyaltyCardId = trInvoiceHeader.LoyaltyCardId;
                            returnInvoHeader.TerminalId = Settings.Default.TerminalId;

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

                            trInvoiceLine.QtyOut -= formQty.input;

                            trInvoiceLine.Amount = (-1) * formQty.input * trInvoiceLine.Price;
                            trInvoiceLine.AmountLoc = (-1) * formQty.input * trInvoiceLine.PriceLoc;

                            trInvoiceLine.NetAmount = (-1) * formQty.input * trInvoiceLine.Price * (100m - trInvoiceLine.PosDiscount) / 100m;
                            trInvoiceLine.NetAmountLoc = (-1) * formQty.input * trInvoiceLine.PriceLoc * (100m - trInvoiceLine.PosDiscount) / 100m;

                            efMethods.UpdateEntity(trInvoiceLine);
                        }

                        SyncReturnInvoiceLoyaltyAsync();

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

        private void SyncReturnInvoiceLoyaltyAsync()
        {
            if (returnInvoHeader is null || returnInvoHeader.InvoiceHeaderId == Guid.Empty)
                return;

            // Loyalty txn-i return invoice-ın özünə görə hesabla (IsReturn=true => məbləğ mənfi olacaq)
            _loyalty.SyncInvoiceEarn(returnInvoHeader);
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            decimal sumNetAmount = efMethods.SelectInvoiceNetAmount(returnInvoiceHeaderId);

            if (sumNetAmount != 0)
            {
                efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

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

            if (trInvoiceHeader is null)
            {
                MessageBox.Show(Resources.Form_Return_Message_InvoiceNotFound);
                return;
            }

            string claim = CustomExtensions.GetClaim(trInvoiceHeader.ProcessCode);

            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
            if (!currAccHasClaims)
            {
                MessageBox.Show(Resources.Common_AccessDenied);
                return;
            }

            FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
            if (formERP == null)
                return;

            Guid formInstanceId = Guid.NewGuid();
            byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

            if (TryAcquireInvoiceLockForEdit(trInvoiceHeader.InvoiceHeaderId, formERP, formInstanceId))
            {
                FormInvoice frm = new(trInvoiceHeader.ProcessCode, null, bytes, null, trInvoiceHeader.InvoiceHeaderId);
                frm._formInstanceId = formInstanceId;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
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
    }
}
