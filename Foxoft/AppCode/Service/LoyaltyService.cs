using Foxoft;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

public sealed record LoyaltySyncResult(
    decimal EarnAmount,
    bool EarnTxnExists,
    string? Note
);

public sealed class LoyaltyService
{

    private static readonly DateTime SqlMin = new(1753, 1, 1);
    private static readonly DateTime DefaultSqlDate = new(1901, 1, 1);

    public LoyaltyService(subContext db) { }

    public async Task AttachCardAsync(TrInvoiceHeader trInvoiceHeader, DcLoyaltyCard loyaltyCard, CancellationToken ct = default)
    {
        using var db = new subContext();

        if (trInvoiceHeader is null) throw new InvalidOperationException("Invoice not found.");
        if (loyaltyCard is null) throw new InvalidOperationException("Card not found.");

        trInvoiceHeader.LoyaltyCardId = loyaltyCard.LoyaltyCardId;
        await db.SaveChangesAsync(ct);
    }

    public async Task DetachCardAsync(TrInvoiceHeader trInvoiceHeader, CancellationToken ct = default)
    {
        using var db = new subContext();

        if (trInvoiceHeader is null) throw new InvalidOperationException("Invoice not found.");

        trInvoiceHeader.LoyaltyCardId = null;

        var txns = await db.TrLoyaltyTxns
            .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
            .ToListAsync(ct);

        if (txns.Count > 0)
            db.TrLoyaltyTxns.RemoveRange(txns);

        await db.SaveChangesAsync(ct);
    }

    private static DateTime FixSqlDate(DateTime dt)
        => dt < SqlMin ? DefaultSqlDate : dt;

    public async Task<LoyaltySyncResult> SyncInvoiceAsync(TrInvoiceHeader trInvoiceHeader, CancellationToken ct = default)
    {
        using var db = new subContext();

        if (trInvoiceHeader is null)
            return new LoyaltySyncResult(0m, false, "Invoice not found.");

        // Eyni context-də həmin invoice-u tracked vəziyyətə gətir
        var invoice = await db.TrInvoiceHeaders
            .FirstOrDefaultAsync(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId, ct);

        if (invoice is null)
            return new LoyaltySyncResult(0m, false, "Invoice not found in current context.");

        var earnTxn = await db.TrLoyaltyTxns
            .FirstOrDefaultAsync(x =>
                x.InvoiceHeaderId == invoice.InvoiceHeaderId &&
                x.TxnType == LoyaltyTxnType.Earn, ct);

        if (invoice.LoyaltyCardId is null)
        {
            if (earnTxn != null) db.TrLoyaltyTxns.Remove(earnTxn);
            await db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "No card attached; Earn removed.");
        }

        var card = await db.DcLoyaltyCards
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.LoyaltyCardId == invoice.LoyaltyCardId.Value, ct);

        if (card is null)
        {
            if (earnTxn != null) db.TrLoyaltyTxns.Remove(earnTxn);
            await db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "Card not found; Earn removed.");
        }

        decimal earnPercent = await db.DcLoyaltyPrograms
            .Where(p => p.LoyaltyProgramId == card.LoyaltyProgramId)
            .Select(p => (decimal?)p.EarnPercent)
            .FirstOrDefaultAsync(ct) ?? 0m;

        if (earnPercent <= 0m)
        {
            if (earnTxn != null) db.TrLoyaltyTxns.Remove(earnTxn);
            await db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "EarnPercent is 0; Earn removed.");
        }

        decimal netLoc = await db.TrInvoiceLines
            .Where(x => x.InvoiceHeaderId == invoice.InvoiceHeaderId)
            .SumAsync(x => (decimal?)x.NetAmountLoc, ct) ?? 0m;

        if (invoice.IsReturn)
            netLoc = -Math.Abs(netLoc);

        decimal amount = Math.Round(netLoc * earnPercent / 100m, 2);

        if (amount == 0m)
        {
            if (earnTxn != null) db.TrLoyaltyTxns.Remove(earnTxn);
            await db.SaveChangesAsync(ct);
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

        await db.SaveChangesAsync(ct);
        return new LoyaltySyncResult(amount, true, null);
    }


    public async Task<(bool TxnExists, string? Note)> SyncBonusSpendAsync(TrInvoiceHeader trInvoiceHeader, TrPaymentLine bonusLine, bool isRefund, CancellationToken ct = default)
    {
        using var db = new subContext();

        if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty)
            return (false, "Invoice not found.");

        // invoice tracked olsun (eyni context)
        var invoice = await db.TrInvoiceHeaders
            .FirstOrDefaultAsync(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId, ct);

        if (invoice is null)
            return (false, "Invoice not found in current context.");

        if (invoice.LoyaltyCardId is null)
            return (false, "No loyalty card attached.");

        if (bonusLine is null || bonusLine.PaymentLineId == Guid.Empty)
            return (false, "Bonus payment line not found.");

        // bonus loc (pozitiv) -> Redeem üçün mənfi amount, Refund üçün pozitiv amount
        var bonusLoc = Math.Round(Math.Abs(bonusLine.PaymentLoc), 2);

        // bonus 0-dırsa txn silək
        var existing = await db.TrLoyaltyTxns
            .FirstOrDefaultAsync(x =>
                x.PaymentLineId == bonusLine.PaymentLineId &&
                x.LoyaltyCardId == invoice.LoyaltyCardId.Value &&
                (x.TxnType == LoyaltyTxnType.Redeem || x.TxnType == LoyaltyTxnType.Refund), ct);

        if (bonusLoc <= 0m)
        {
            if (existing != null) db.TrLoyaltyTxns.Remove(existing);
            await db.SaveChangesAsync(ct);
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

        await db.SaveChangesAsync(ct);
        return (true, null);
    }
}