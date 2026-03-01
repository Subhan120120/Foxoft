using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

public sealed record LoyaltySyncResult(
    decimal EarnAmount,
    bool EarnTxnExists,
    string? Note
);

public sealed class LoyaltyService
{
    private readonly subContext _db;

    private static readonly DateTime SqlMin = new(1753, 1, 1);
    private static readonly DateTime DefaultSqlDate = new(1901, 1, 1);

    public LoyaltyService(subContext db) => _db = db;

    public async Task AttachCardAsync(TrInvoiceHeader trInvoiceHeader, DcLoyaltyCard loyaltyCard, string userName, CancellationToken ct = default)
    {
        if (trInvoiceHeader is null) throw new InvalidOperationException("Invoice not found.");
        if (loyaltyCard is null) throw new InvalidOperationException("Card not found.");

        trInvoiceHeader.LoyaltyCardId = loyaltyCard.LoyaltyCardId;
        await _db.SaveChangesAsync(ct);
    }

    public async Task DetachCardAsync(TrInvoiceHeader trInvoiceHeader, string userName, CancellationToken ct = default)
    {
        if (trInvoiceHeader is null) throw new InvalidOperationException("Invoice not found.");

        trInvoiceHeader.LoyaltyCardId = null;

        var txns = await _db.TrLoyaltyTxns
            .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
            .ToListAsync(ct);

        if (txns.Count > 0)
            _db.TrLoyaltyTxns.RemoveRange(txns);

        await _db.SaveChangesAsync(ct);
    }

    public async Task<LoyaltySyncResult> SyncInvoiceAsync(TrInvoiceHeader trInvoiceHeader, string userName, CancellationToken ct = default)
    {
        if (trInvoiceHeader is null)
            return new LoyaltySyncResult(0m, false, "Invoice not found.");

        // Eyni context-də həmin invoice-u tracked vəziyyətə gətir
        var invoice = await _db.TrInvoiceHeaders
            .FirstOrDefaultAsync(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId, ct);

        if (invoice is null)
            return new LoyaltySyncResult(0m, false, "Invoice not found in current context.");

        var earnTxn = await _db.TrLoyaltyTxns
            .FirstOrDefaultAsync(x =>
                x.InvoiceHeaderId == invoice.InvoiceHeaderId &&
                x.TxnType == LoyaltyTxnType.Earn, ct);

        if (invoice.LoyaltyCardId is null)
        {
            if (earnTxn != null) _db.TrLoyaltyTxns.Remove(earnTxn);
            await _db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "No card attached; Earn removed.");
        }

        var card = await _db.DcLoyaltyCards
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.LoyaltyCardId == invoice.LoyaltyCardId.Value, ct);

        if (card is null)
        {
            if (earnTxn != null) _db.TrLoyaltyTxns.Remove(earnTxn);
            await _db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "Card not found; Earn removed.");
        }

        decimal earnPercent = await _db.DcLoyaltyPrograms
            .Where(p => p.LoyaltyProgramId == card.LoyaltyProgramId)
            .Select(p => (decimal?)p.EarnPercent)
            .FirstOrDefaultAsync(ct) ?? 0m;

        if (earnPercent <= 0m)
        {
            if (earnTxn != null) _db.TrLoyaltyTxns.Remove(earnTxn);
            await _db.SaveChangesAsync(ct);
            return new LoyaltySyncResult(0m, false, "EarnPercent is 0; Earn removed.");
        }

        decimal netLoc = await _db.TrInvoiceLines
            .Where(x => x.InvoiceHeaderId == invoice.InvoiceHeaderId)
            .SumAsync(x => (decimal?)x.NetAmountLoc, ct) ?? 0m;

        if (invoice.IsReturn)
            netLoc = -Math.Abs(netLoc);

        decimal amount = Math.Round(netLoc * earnPercent / 100m, 2);

        if (amount == 0m)
        {
            if (earnTxn != null) _db.TrLoyaltyTxns.Remove(earnTxn);
            await _db.SaveChangesAsync(ct);
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
                CreatedUserName = userName,
                Note = $"Invoice: {invoice.DocumentNumber}"
            };
            _db.TrLoyaltyTxns.Add(earnTxn);
        }
        else
        {
            earnTxn.LoyaltyCardId = card.LoyaltyCardId;
            earnTxn.CurrAccCode = invoice.CurrAccCode;
            earnTxn.DocumentDate = FixSqlDate(invoice.DocumentDate);
            earnTxn.Amount = amount;
            earnTxn.Note = $"Invoice: {invoice.DocumentNumber}";
        }

        await _db.SaveChangesAsync(ct);
        return new LoyaltySyncResult(amount, true, null);
    }

    private static DateTime FixSqlDate(DateTime dt)
        => dt < SqlMin ? DefaultSqlDate : dt;
}