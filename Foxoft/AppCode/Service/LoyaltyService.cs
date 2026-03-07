using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service
{
    public sealed record LoyaltySyncResult(
        decimal EarnAmount,
        bool EarnTxnExists,
        string? Note
    );

    public sealed class LoyaltyService
    {
        private readonly subContext _db;
        private readonly EfMethods _efMethods = new EfMethods();

        private static readonly DateTime SqlMin = new(1753, 1, 1);
        private static readonly DateTime DefaultSqlDate = new(1901, 1, 1);

        public LoyaltyService(subContext db)
        {
            _db = db;
        }

        private static DateTime FixSqlDate(DateTime dt)
            => dt < SqlMin ? DefaultSqlDate : dt;

        public void AttachCard(TrInvoiceHeader invoice, DcLoyaltyCard loyaltyCard)
        {
            if (invoice is null)
                throw new InvalidOperationException("Invoice not found.");

            if (loyaltyCard is null)
                throw new InvalidOperationException("Card not found.");

            invoice.CurrAccCode = loyaltyCard.CurrAccCode;
            invoice.LoyaltyCardId = loyaltyCard.LoyaltyCardId;
        }

        public (bool Success, string Message) DetachCard(TrInvoiceHeader invoice)
        {
            if (invoice is null)
                return (false, "Invoice not found.");

            using var db = new subContext();

            bool hasBonusPayment = db.TrPaymentLines
                .Include(x => x.TrPaymentHeader)
                .Any(x =>
                    x.TrPaymentHeader.InvoiceHeaderId == invoice.InvoiceHeaderId &&
                    x.PaymentTypeCode == PaymentType.Bonus);

            if (hasBonusPayment)
                return (false, "Bu sənəddə Bonus ödənişi var. Bonus ödənişi silinmədən kart ləğv edilə bilməz.");

            invoice.LoyaltyCardId = null;
            invoice.CurrAccCode = null; // lazımdırsa saxlayın, yoxdursa silin

            var txns = db.TrLoyaltyTxns
                .Where(x => x.InvoiceHeaderId == invoice.InvoiceHeaderId)
                .ToList();

            if (txns.Count > 0)
                db.TrLoyaltyTxns.RemoveRange(txns);

            db.SaveChanges();

            return (true, "Bonus kart ləğv olundu.");
        }

        public void RemoveAllInvoiceLoyaltyLinks(Guid invoiceHeaderId)
        {
            var txns = _db.TrLoyaltyTxns
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            if (txns.Count > 0)
                _db.TrLoyaltyTxns.RemoveRange(txns);
        }

        public LoyaltySyncResult SyncInvoiceEarn(TrInvoiceHeader invoice)
        {
            subContext db = new();

            if (invoice is null || invoice.InvoiceHeaderId == Guid.Empty)
                return new LoyaltySyncResult(0m, false, "Invoice not found.");

            var earnTxn = db.TrLoyaltyTxns
                .FirstOrDefault(x =>
                    x.InvoiceHeaderId == invoice.InvoiceHeaderId &&
                    x.TxnType == LoyaltyTxnType.Earn);

            if (invoice.LoyaltyCardId is null)
            {
                if (earnTxn != null)
                    db.TrLoyaltyTxns.Remove(earnTxn);

                db.SaveChanges();

                return new LoyaltySyncResult(0m, false, "No card attached; Earn removed.");
            }

            var card = db.DcLoyaltyCards
                .AsNoTracking()
                .FirstOrDefault(x => x.LoyaltyCardId == invoice.LoyaltyCardId.Value);

            if (card is null)
            {
                if (earnTxn != null)
                    db.TrLoyaltyTxns.Remove(earnTxn);

                db.SaveChanges();

                return new LoyaltySyncResult(0m, false, "Card not found; Earn removed.");
            }

            decimal earnPercent = db.DcLoyaltyPrograms
                .Where(p => p.LoyaltyProgramId == card.LoyaltyProgramId)
                .Select(p => (decimal?)p.EarnPercent)
                .FirstOrDefault() ?? 0m;

            if (earnPercent <= 0m)
            {
                if (earnTxn != null)
                    db.TrLoyaltyTxns.Remove(earnTxn);

                db.SaveChanges();

                return new LoyaltySyncResult(0m, false, "EarnPercent is 0; Earn removed.");
            }

            decimal netLoc = db.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == invoice.InvoiceHeaderId)
                .Sum(x => (decimal?)x.NetAmountLoc) ?? 0m;

            if (invoice.IsReturn)
                netLoc = -Math.Abs(netLoc);

            decimal amount = Math.Round(netLoc * earnPercent / 100m, 2);

            if (amount == 0m)
            {
                if (earnTxn != null)
                    db.TrLoyaltyTxns.Remove(earnTxn);

                db.SaveChanges();

                return new LoyaltySyncResult(0m, false, "Earn is 0; Earn removed.");
            }

            if (earnTxn == null)
            {
                earnTxn = new TrLoyaltyTxn
                {
                    LoyaltyTxnId = Guid.NewGuid(),
                    InvoiceHeaderId = invoice.InvoiceHeaderId,
                    LoyaltyCardId = card.LoyaltyCardId,
                    CurrAccCode = invoice.CurrAccCode,
                    DocumentDate = FixSqlDate(invoice.DocumentDate),
                    TxnType = LoyaltyTxnType.Earn,
                    Amount = amount,
                    CreatedUserName = Authorization.CurrAccCode,
                    Note = $"Invoice: {invoice.DocumentNumber}"
                };

                db.TrLoyaltyTxns.Add(earnTxn);
            }
            else
            {
                earnTxn.LoyaltyCardId = card.LoyaltyCardId;
                earnTxn.CurrAccCode = invoice.CurrAccCode;
                earnTxn.DocumentDate = FixSqlDate(invoice.DocumentDate);
                earnTxn.Amount = amount;
                earnTxn.Note = $"Invoice: {invoice.DocumentNumber}";
            }

            db.SaveChanges();

            return new LoyaltySyncResult(amount, true, null);
        }

        public (bool TxnExists, string? Note) SyncBonusSpend(
            TrInvoiceHeader invoice,
            TrPaymentLine bonusLine,
            bool isRefund)
        {
            subContext db = new();

            if (invoice is null || invoice.InvoiceHeaderId == Guid.Empty)
                return (false, "Invoice not found.");

            if (invoice.LoyaltyCardId is null)
                return (false, "No loyalty card attached.");

            if (bonusLine is null || bonusLine.PaymentLineId == Guid.Empty)
                return (false, "Bonus payment line not found.");

            decimal bonusLoc = Math.Round(Math.Abs(bonusLine.PaymentLoc), 2);

            var existing = db.TrLoyaltyTxns
                .FirstOrDefault(x =>
                    x.PaymentLineId == bonusLine.PaymentLineId &&
                    x.LoyaltyCardId == invoice.LoyaltyCardId.Value &&
                    (x.TxnType == LoyaltyTxnType.Redeem || x.TxnType == LoyaltyTxnType.Refund));

            if (bonusLoc <= 0m)
            {
                if (existing != null)
                    db.TrLoyaltyTxns.Remove(existing);

                db.SaveChanges();

                return (false, "Bonus is 0; txn removed.");
            }

            var txnType = isRefund ? LoyaltyTxnType.Refund : LoyaltyTxnType.Redeem;
            var amount = isRefund ? bonusLoc : -bonusLoc;

            if (existing == null)
            {
                existing = new TrLoyaltyTxn
                {
                    LoyaltyTxnId = Guid.NewGuid(),
                    LoyaltyCardId = invoice.LoyaltyCardId.Value,
                    CurrAccCode = invoice.CurrAccCode,
                    InvoiceHeaderId = invoice.InvoiceHeaderId,
                    PaymentLineId = bonusLine.PaymentLineId,
                    CreatedUserName = Authorization.CurrAccCode,
                    Amount = amount,
                    DocumentDate = FixSqlDate(DateTime.Now),
                    TxnType = txnType,
                    Note = $"Payment (Bonus) for Invoice: {invoice.DocumentNumber}"
                };

                db.TrLoyaltyTxns.Add(existing);
            }
            else
            {
                existing.LoyaltyCardId = invoice.LoyaltyCardId.Value;
                existing.CurrAccCode = invoice.CurrAccCode;
                existing.InvoiceHeaderId = invoice.InvoiceHeaderId;
                existing.PaymentLineId = bonusLine.PaymentLineId;
                existing.Amount = amount;
                existing.TxnType = txnType;
                existing.DocumentDate = FixSqlDate(DateTime.Now);
                existing.Note = $"Payment (Bonus) for Invoice: {invoice.DocumentNumber}";
            }

            db.SaveChanges();

            return (true, null);
        }

        public decimal GetInvoiceEarnAmount(Guid invoiceHeaderId)
        {
            return _efMethods.SelectLoyalityTxnAmount(invoiceHeaderId);
        }
    }
}