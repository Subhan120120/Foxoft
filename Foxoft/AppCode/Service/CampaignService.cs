using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Services
{
    /// <summary>
    /// Kampaniya tətbiqi nəticəsi
    /// </summary>
    public class CampaignApplyResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<TrInvoiceCampaignLog> AppliedLogs { get; set; } = new();
        public decimal TotalDiscount { get; set; }
        public int CampaignCount { get; set; }
    }

    /// <summary>
    /// Kampaniya seçim filteri
    /// </summary>
    public enum CampaignFilter
    {
        /// <summary>Yalnız IsCashOnly=false kampaniyalar</summary>
        RegularOnly,
        /// <summary>Yalnız IsCashOnly=true kampaniyalar</summary>
        CashOnlyOnly,
        /// <summary>Bütün kampaniyalar</summary>
        All
    }

    public class CampaignService
    {
        private readonly subContext _db;

        public CampaignService(subContext db)
        {
            _db = db;
        }

        // ─────────────────────────────────────────────────────────────────
        // PUBLIC: Eligibility
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Faktura üçün uyğun kampaniyaları qaytarır (priority desc sıralı)
        /// </summary>
        public List<DcCampaign> GetEligibleCampaigns(
            TrInvoiceHeader header,
            List<TrInvoiceLine> lines,
            string? promoCode = null,
            CampaignFilter filter = CampaignFilter.RegularOnly)
        {
            if (lines == null || !lines.Any()) return new List<DcCampaign>();

            var today = header.DocumentDate.Date;

            var campaigns = _db.DcCampaigns
                .Include(c => c.TrCampaignStores)
                .Include(c => c.TrCampaignWarehouses)
                .Include(c => c.TrCampaignCustomers)
                .Include(c => c.TrCampaignProducts)
                .Include(c => c.TrCampaignCategories)
                .Where(c =>
                    c.IsActive &&
                    c.StartDate.Date <= today &&
                    c.EndDate.Date >= today &&
                    c.ProcessCode == header.ProcessCode)
                .ToList();

            // IsCashOnly filteri
            campaigns = filter switch
            {
                CampaignFilter.RegularOnly => campaigns.Where(c => !c.IsCashOnly).ToList(),
                CampaignFilter.CashOnlyOnly => campaigns.Where(c => c.IsCashOnly).ToList(),
                _ => campaigns
            };

            // Promo kod filteri
            if (!string.IsNullOrWhiteSpace(promoCode))
                campaigns = campaigns
                    .Where(c => string.Equals(c.PromoCode, promoCode, StringComparison.OrdinalIgnoreCase)
                                || string.IsNullOrEmpty(c.PromoCode))
                    .ToList();
            else
                campaigns = campaigns.Where(c => string.IsNullOrEmpty(c.PromoCode)).ToList();

            // Mağaza filteri
            campaigns = campaigns.Where(c =>
                !c.TrCampaignStores.Any() ||
                c.TrCampaignStores.Any(s => s.StoreCode == header.StoreCode)).ToList();

            // Anbar filteri
            if (!string.IsNullOrEmpty(header.WarehouseCode))
                campaigns = campaigns.Where(c =>
                    !c.TrCampaignWarehouses.Any() ||
                    c.TrCampaignWarehouses.Any(w => w.WarehouseCode == header.WarehouseCode)).ToList();

            // Müştəri filteri
            if (!string.IsNullOrEmpty(header.CurrAccCode))
                campaigns = campaigns.Where(c =>
                    !c.TrCampaignCustomers.Any() ||
                    c.TrCampaignCustomers.Any(cu => cu.CurrAccCode == header.CurrAccCode)).ToList();
            else
                campaigns = campaigns.Where(c => !c.TrCampaignCustomers.Any()).ToList();

            // Min faktura məbləği filteri
            decimal invoiceTotal = lines.Sum(l => l.NetAmountBeforeCampaign);
            campaigns = campaigns.Where(c =>
                c.MinInvoiceAmount == 0 || invoiceTotal >= c.MinInvoiceAmount).ToList();

            // Məhsul / kateqoriya uyğunluğu
            campaigns = campaigns.Where(c => HasAnyMatchingLine(c, lines)).ToList();

            return campaigns.OrderByDescending(c => c.Priority).ToList();
        }

        // ─────────────────────────────────────────────────────────────────
        // PUBLIC: Apply
        // ─────────────────────────────────────────────────────────────────

        /// <summary>
        /// Kampaniyaları fakturaya tətbiq edir (mövcud logları silir, yenidən hesablayır)
        /// </summary>
        public CampaignApplyResult ApplyCampaigns(
            TrInvoiceHeader header,
            List<TrInvoiceLine> lines,
            string? promoCode = null,
            CampaignFilter filter = CampaignFilter.RegularOnly)
        {
            var result = new CampaignApplyResult();

            // Mövcud logları sil, DiscountCampaign sıfırla
            ClearCampaignLogs(header.InvoiceHeaderId, filter);
            ResetLineDiscounts(lines, filter);

            var eligible = GetEligibleCampaigns(header, lines, promoCode, filter);
            if (!eligible.Any())
            {
                result.Message = "Uyğun kampaniya tapılmadı.";
                return result;
            }

            bool nonCombinableDone = false;

            foreach (var campaign in eligible)
            {
                if (nonCombinableDone) break;

                var matchingLines = GetMatchingLines(campaign, lines);
                if (!matchingLines.Any()) continue;

                var logs = BuildCampaignLogs(campaign, header, matchingLines);
                if (!logs.Any()) continue;

                // DiscountCampaign-i artır
                foreach (var log in logs)
                {
                    var line = matchingLines.First(l => l.InvoiceLineId == log.InvoiceLineId);
                    line.DiscountCampaign += log.DiscountAmount;
                }

                result.AppliedLogs.AddRange(logs);
                result.TotalDiscount += logs.Sum(l => l.DiscountAmount);
                result.CampaignCount++;

                if (!campaign.IsCombinable) nonCombinableDone = true;
            }

            if (result.AppliedLogs.Any())
            {
                _db.TrInvoiceCampaignLogs.AddRange(result.AppliedLogs);
                result.Success = true;
                result.Message =
                    $"{result.CampaignCount} kampaniya tətbiq edildi. " +
                    $"Ümumi endirim: {result.TotalDiscount:n2}";
            }
            else
            {
                result.Message = "Uyğun kampaniya tapılmadı.";
            }

            return result;
        }

        /// <summary>
        /// Bütün kampaniya endirimlərini fakturadan silir
        /// </summary>
        public void RemoveAllCampaigns(TrInvoiceHeader header, List<TrInvoiceLine> lines)
        {
            ClearCampaignLogs(header.InvoiceHeaderId, CampaignFilter.All);
            foreach (var line in lines)
                line.DiscountCampaign = 0;
        }

        /// <summary>
        /// Mövcud tətbiq edilmiş kampaniyaları yenidən hesablayır.
        /// recalculateCashOnly=true olarsa IsCashOnly kampaniyaları da yenidən hesablanır.
        /// </summary>
        public CampaignApplyResult RecalculateCampaigns(
            TrInvoiceHeader header,
            List<TrInvoiceLine> lines,
            string? promoCode,
            bool recalculateCashOnly)
        {
            var regularResult = ApplyCampaigns(header, lines, promoCode, CampaignFilter.RegularOnly);

            if (!recalculateCashOnly) return regularResult;

            var cashResult = ApplyCampaigns(header, lines, null, CampaignFilter.CashOnlyOnly);

            return new CampaignApplyResult
            {
                Success = regularResult.Success || cashResult.Success,
                CampaignCount = regularResult.CampaignCount + cashResult.CampaignCount,
                TotalDiscount = regularResult.TotalDiscount + cashResult.TotalDiscount,
                AppliedLogs = regularResult.AppliedLogs.Concat(cashResult.AppliedLogs).ToList(),
                Message = $"{regularResult.CampaignCount + cashResult.CampaignCount} kampaniya yenidən hesablandı. " +
                                $"Endirim: {regularResult.TotalDiscount + cashResult.TotalDiscount:n2}"
            };
        }

        // ─────────────────────────────────────────────────────────────────
        // PUBLIC: Query helpers
        // ─────────────────────────────────────────────────────────────────

        public bool HasCampaignApplied(Guid invoiceHeaderId)
            => _db.TrInvoiceCampaignLogs.Any(l => l.InvoiceHeaderId == invoiceHeaderId);

        public bool HasCashOnlyCampaignApplied(Guid invoiceHeaderId)
            => _db.TrInvoiceCampaignLogs
                  .Include(l => l.DcCampaign)
                  .Any(l => l.InvoiceHeaderId == invoiceHeaderId && l.DcCampaign.IsCashOnly);

        public List<TrInvoiceCampaignLog> GetCampaignLogs(Guid invoiceHeaderId)
            => _db.TrInvoiceCampaignLogs
                  .Include(l => l.DcCampaign)
                  .Where(l => l.InvoiceHeaderId == invoiceHeaderId)
                  .OrderBy(l => l.DcCampaign.Priority)
                  .ToList();

        // ─────────────────────────────────────────────────────────────────
        // PRIVATE helpers
        // ─────────────────────────────────────────────────────────────────

        private bool HasAnyMatchingLine(DcCampaign campaign, List<TrInvoiceLine> lines)
        {
            if (!campaign.TrCampaignProducts.Any() && !campaign.TrCampaignCategories.Any())
                return true;

            var productCodes = campaign.TrCampaignProducts.Select(p => p.ProductCode).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var hierarchyCodes = campaign.TrCampaignCategories.Select(c => c.HierarchyCode).ToHashSet(StringComparer.OrdinalIgnoreCase);

            return lines.Any(l =>
                productCodes.Contains(l.ProductCode) ||
                (l.DcProduct?.HierarchyCode != null && hierarchyCodes.Contains(l.DcProduct.HierarchyCode)));
        }

        private List<TrInvoiceLine> GetMatchingLines(DcCampaign campaign, List<TrInvoiceLine> lines)
        {
            if (!campaign.TrCampaignProducts.Any() && !campaign.TrCampaignCategories.Any())
                return lines.Where(l => l.NetAmountBeforeCampaign > 0).ToList();

            var productCodes = campaign.TrCampaignProducts.Select(p => p.ProductCode).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var hierarchyCodes = campaign.TrCampaignCategories.Select(c => c.HierarchyCode).ToHashSet(StringComparer.OrdinalIgnoreCase);

            return lines.Where(l =>
                l.NetAmountBeforeCampaign > 0 &&
                (productCodes.Contains(l.ProductCode) ||
                 (l.DcProduct?.HierarchyCode != null && hierarchyCodes.Contains(l.DcProduct.HierarchyCode))))
                .ToList();
        }

        private List<TrInvoiceCampaignLog> BuildCampaignLogs(
            DcCampaign campaign,
            TrInvoiceHeader header,
            List<TrInvoiceLine> matchingLines)
        {
            var logs = new List<TrInvoiceCampaignLog>();
            decimal baseTotal = matchingLines.Sum(l => l.NetAmountBeforeCampaign);
            if (baseTotal <= 0) return logs;

            if (campaign.DiscountTypeCode == DiscountTypeCode.Percent)
            {
                foreach (var line in matchingLines)
                {
                    decimal lineDiscount = line.NetAmountBeforeCampaign * campaign.DiscountValue / 100;

                    if (campaign.MaxDiscountAmount > 0)
                    {
                        decimal maxForLine = campaign.MaxDiscountAmount * (line.NetAmountBeforeCampaign / baseTotal);
                        lineDiscount = Math.Min(lineDiscount, maxForLine);
                    }

                    lineDiscount = Math.Round(lineDiscount, 4);
                    if (lineDiscount <= 0) continue;

                    logs.Add(MakeLog(campaign, header, line, line.NetAmountBeforeCampaign, lineDiscount, campaign.DiscountValue));
                }
            }
            else // Amount
            {
                decimal totalAmount = campaign.DiscountValue;
                if (campaign.MaxDiscountAmount > 0)
                    totalAmount = Math.Min(totalAmount, campaign.MaxDiscountAmount);

                foreach (var line in matchingLines)
                {
                    decimal share = line.NetAmountBeforeCampaign / baseTotal;
                    decimal lineDiscount = Math.Round(totalAmount * share, 4);
                    if (lineDiscount <= 0) continue;

                    decimal pct = totalAmount / baseTotal * 100;
                    logs.Add(MakeLog(campaign, header, line, line.NetAmountBeforeCampaign, lineDiscount, pct));
                }
            }

            return logs;
        }

        private TrInvoiceCampaignLog MakeLog(
            DcCampaign campaign,
            TrInvoiceHeader header,
            TrInvoiceLine line,
            decimal baseAmount,
            decimal discountAmount,
            decimal discountPercent)
        {
            decimal exRate = line.ExchangeRate == 0 ? 1m : (decimal)line.ExchangeRate;
            return new TrInvoiceCampaignLog
            {
                InvoiceCampaignLogId = Guid.NewGuid(),
                InvoiceHeaderId = header.InvoiceHeaderId,
                InvoiceLineId = line.InvoiceLineId,
                CampaignId = campaign.CampaignId,
                CampaignCode = campaign.CampaignCode,
                CampaignDesc = campaign.CampaignDesc,
                Priority = campaign.Priority,
                IsCombinable = campaign.IsCombinable,
                BaseAmount = baseAmount,
                BaseAmountLoc = Math.Round(baseAmount / exRate, 4),
                DiscountAmount = discountAmount,
                DiscountAmountLoc = Math.Round(discountAmount / exRate, 4),
                DiscountPercent = discountPercent,
                CreatedDate = DateTime.Now,
                CreatedUserName = Authorization.CurrAccCode
            };
        }

        private void ClearCampaignLogs(Guid invoiceHeaderId, CampaignFilter filter)
        {
            var allLogs = _db.TrInvoiceCampaignLogs
                .Include(l => l.DcCampaign)
                .Where(l => l.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            var toRemove = filter switch
            {
                CampaignFilter.RegularOnly => allLogs.Where(l => !l.DcCampaign.IsCashOnly).ToList(),
                CampaignFilter.CashOnlyOnly => allLogs.Where(l => l.DcCampaign.IsCashOnly).ToList(),
                _ => allLogs
            };

            _db.TrInvoiceCampaignLogs.RemoveRange(toRemove);
        }

        /// <summary>
        /// Silinəcək filtrə görə sətir endirimlərini sıfırla, digər filtrə aid endirimi qoru.
        /// </summary>
        private void ResetLineDiscounts(List<TrInvoiceLine> lines, CampaignFilter filter)
        {
            if (filter == CampaignFilter.All)
            {
                foreach (var l in lines) l.DiscountCampaign = 0;
                return;
            }

            foreach (var line in lines)
            {
                // DB-dən silinməyəcək logların cəmini hesabla
                var remainingLogs = _db.TrInvoiceCampaignLogs
                    .Include(l => l.DcCampaign)
                    .Where(l => l.InvoiceLineId == line.InvoiceLineId)
                    .ToList();

                decimal keep = filter switch
                {
                    CampaignFilter.RegularOnly => remainingLogs.Where(l => l.DcCampaign.IsCashOnly).Sum(l => l.DiscountAmount),
                    CampaignFilter.CashOnlyOnly => remainingLogs.Where(l => !l.DcCampaign.IsCashOnly).Sum(l => l.DiscountAmount),
                    _ => 0m
                };

                line.DiscountCampaign = keep;
            }
        }
    }
}
