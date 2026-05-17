using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormTransferApproval : RibbonForm
    {
        private readonly EfMethods efMethods = new();

        public FormTransferApproval()
        {
            InitializeComponent();
            LoadPendingTransfers();
        }

        private void LoadPendingTransfers()
        {
            using var db = new subContext();

            var pendingTransfers = db.TrInvoiceHeaders
                .AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Where(x => x.ProcessCode == "IT")
                .Where(x => x.IsMainTF == true)
                .Where(x => x.TransferApprovalStatus == TransferApprovalStatus.Pending)
                .OrderByDescending(x => x.DocumentDate)
                .ThenByDescending(x => x.DocumentTime)
                .Select(x => new
                {
                    x.InvoiceHeaderId,
                    x.DocumentNumber,
                    x.DocumentDate,
                    x.DocumentTime,
                    CurrAccDesc = x.DcCurrAcc != null ? x.DcCurrAcc.CurrAccDesc : x.CurrAccCode,
                    x.WarehouseCode,
                    x.ToWarehouseCode,
                    x.StoreCode,
                    x.CreatedUserName,
                    x.CreatedDate,
                    x.TransferApprovalStatus
                })
                .ToList();

            gridControl1.DataSource = pendingTransfers;

            if (gridView1.Columns["InvoiceHeaderId"] != null)
                gridView1.Columns["InvoiceHeaderId"].Visible = false;

            if (gridView1.Columns["TransferApprovalStatus"] != null)
                gridView1.Columns["TransferApprovalStatus"].Visible = false;

            if (gridView1.Columns["DocumentNumber"] != null)
                gridView1.Columns["DocumentNumber"].Caption = Resources.Entity_InvoiceHeader_DocumentNumber;

            if (gridView1.Columns["DocumentDate"] != null)
                gridView1.Columns["DocumentDate"].Caption = Resources.Entity_InvoiceHeader_DocumentDate;

            if (gridView1.Columns["DocumentTime"] != null)
                gridView1.Columns["DocumentTime"].Caption = Resources.Entity_InvoiceHeader_DocumentTime;

            if (gridView1.Columns["CurrAccDesc"] != null)
                gridView1.Columns["CurrAccDesc"].Caption = Resources.Entity_InvoiceHeader_CurrAccDesc;

            if (gridView1.Columns["WarehouseCode"] != null)
                gridView1.Columns["WarehouseCode"].Caption = Resources.Entity_InvoiceHeader_WarehouseCode;

            if (gridView1.Columns["ToWarehouseCode"] != null)
                gridView1.Columns["ToWarehouseCode"].Caption = Resources.Entity_InvoiceHeader_ToWarehouseCode;

            if (gridView1.Columns["StoreCode"] != null)
                gridView1.Columns["StoreCode"].Caption = Resources.Entity_InvoiceHeader_StoreCode;

            if (gridView1.Columns["CreatedUserName"] != null)
                gridView1.Columns["CreatedUserName"].Caption = Resources.Entity_Base_CreatedUserName;

            if (gridView1.Columns["CreatedDate"] != null)
                gridView1.Columns["CreatedDate"].Caption = Resources.Entity_Base_CreatedDate;

            gridView1.BestFitColumns();
        }

        private void BBI_Approve_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show(Resources.Form_TransferApproval_NoSelection);
                return;
            }

            Guid invoiceHeaderId = (Guid)gridView1.GetFocusedRowCellValue("InvoiceHeaderId");

            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "TransferApproval");
            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            if (XtraMessageBox.Show(
                    Resources.Form_TransferApproval_ApproveConfirm,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                ApproveTransfer(invoiceHeaderId);
                XtraMessageBox.Show(Resources.Form_TransferApproval_Success);
                LoadPendingTransfers();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApproveTransfer(Guid invoiceHeaderId)
        {
            using var db = new subContext();

            TrInvoiceHeader sourceHeader = db.TrInvoiceHeaders
                .Include(x => x.TrInvoiceLines)
                .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

            if (sourceHeader == null)
                throw new InvalidOperationException("Transfer header not found.");

            // Generate the destination header ID using the same logic as InitilizeTransfer
            string invoHeadStr = sourceHeader.InvoiceHeaderId.ToString();
            Guid destHeaderId = Guid.Parse(invoHeadStr.Replace(invoHeadStr.Substring(0, 8), "00000000"));

            // Check if destination already exists
            if (db.TrInvoiceHeaders.Any(x => x.InvoiceHeaderId == destHeaderId))
                throw new InvalidOperationException("Destination transfer record already exists.");

            var newWarehouseCode = sourceHeader.ToWarehouseCode ?? sourceHeader.WarehouseCode;
            var newToWarehouseCode = sourceHeader.WarehouseCode ?? sourceHeader.ToWarehouseCode;

            // Create destination header
            TrInvoiceHeader destHeader = new()
            {
                InvoiceHeaderId = destHeaderId,
                RelatedInvoiceId = sourceHeader.RelatedInvoiceId,
                ProcessCode = sourceHeader.ProcessCode,
                DocumentNumber = sourceHeader.DocumentNumber,
                IsReturn = sourceHeader.IsReturn,
                DocumentDate = sourceHeader.DocumentDate,
                DocumentTime = sourceHeader.DocumentTime,
                OperationDate = sourceHeader.OperationDate,
                OperationTime = sourceHeader.OperationTime,
                Description = sourceHeader.Description,
                CurrAccCode = sourceHeader.CurrAccCode,
                OfficeCode = sourceHeader.OfficeCode,
                StoreCode = sourceHeader.CurrAccCode ?? sourceHeader.StoreCode,
                WarehouseCode = newWarehouseCode,
                ToWarehouseCode = newToWarehouseCode,
                CustomsDocumentNumber = sourceHeader.CustomsDocumentNumber,
                TerminalId = sourceHeader.TerminalId,
                LoyaltyCardId = sourceHeader.LoyaltyCardId,
                IsMainTF = false,
                TransferApprovalStatus = TransferApprovalStatus.Approved,
                IsCompleted = sourceHeader.IsCompleted,
                CreatedUserName = Authorization.CurrAccCode
            };

            db.TrInvoiceHeaders.Add(destHeader);

            // Create destination lines
            foreach (var sourceLine in sourceHeader.TrInvoiceLines)
            {
                string invoLineStr = sourceLine.InvoiceLineId.ToString();
                Guid destLineId = Guid.Parse(invoLineStr.Replace(invoLineStr.Substring(0, 8), "00000000"));

                TrInvoiceLine destLine = new()
                {
                    InvoiceLineId = destLineId,
                    InvoiceHeaderId = destHeaderId,
                    ProductCode = sourceLine.ProductCode,
                    QtyIn = sourceLine.QtyOut,
                    QtyOut = 0,
                    Price = sourceLine.Price,
                    PosDiscount = sourceLine.PosDiscount,
                    Amount = sourceLine.Amount,
                    NetAmount = sourceLine.NetAmount,
                    NetAmountLoc = sourceLine.NetAmountLoc,
                    CurrencyCode = sourceLine.CurrencyCode,
                    ExchangeRate = sourceLine.ExchangeRate,
                    SalesPersonCode = sourceLine.SalesPersonCode,
                    LineDescription = sourceLine.LineDescription,
                    SerialNumberCode = sourceLine.SerialNumberCode,
                    RelatedLineId = sourceLine.RelatedLineId,
                    CreatedUserName = Authorization.CurrAccCode
                };

                db.TrInvoiceLines.Add(destLine);
            }

            // Update source header status
            sourceHeader.TransferApprovalStatus = TransferApprovalStatus.Approved;

            db.SaveChanges(Authorization.CurrAccCode);
        }

        private void BBI_Reject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show(Resources.Form_TransferApproval_NoSelection);
                return;
            }

            Guid invoiceHeaderId = (Guid)gridView1.GetFocusedRowCellValue("InvoiceHeaderId");

            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "TransferApproval");
            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            if (XtraMessageBox.Show(
                    Resources.Form_TransferApproval_RejectConfirm,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                using var db = new subContext();
                TrInvoiceHeader header = db.TrInvoiceHeaders
                    .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

                if (header != null)
                {
                    header.TransferApprovalStatus = TransferApprovalStatus.Rejected;
                    db.SaveChanges(Authorization.CurrAccCode);
                }

                XtraMessageBox.Show(Resources.Form_TransferApproval_RejectedSuccess);
                LoadPendingTransfers();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadPendingTransfers();
        }
    }
}
