using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Services
{
    /// <summary>
    /// Kampaniya tətbiqinin nəticəsini saxlayır.
    /// Rollback üçün original endirim dəyərləri burada tutulur.
    /// </summary>
    public class CampaignApplyResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        /// <summary>DB-yə yazılmış log ID-ləri — rollback zamanı silinir.</summary>
        public List<Guid> AppliedLogIds { get; set; } = new();

        /// <summary>Hər sətrin əvvəlki DiscountCampaign dəyəri: InvoiceLineId → dəyər</summary>
        public Dictionary<Guid, decimal> OriginalLineDiscounts { get; set; } = new();

        public Guid CampaignId { get; set; }
        public string CampaignDesc { get; set; } = string.Empty;
    }

    public class CampaignService
    {
        private readonly subContext _db;
        private readonly EfMethods _ef;

        public CampaignService(subContext db, EfMethods ef)
        {
            _db = db;
            _ef = ef;
        }

        // ──────────────────────────────────────────────────────────
        // SORĞU METODLARİ
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// Fakturaya uyğun bütün aktiv kampaniyaları qaytarır.
        /// promoCode göndərilirsə yalnız o promo koda uyğun kampaniyalar qaytarılır.
        /// </summary>
        public List<DcCampaign> GetApplicableCampaigns(
            TrInvoiceHeader header,
            IList<TrInvoiceLine> lines,
            string? promoCode = null)
        {
            var today = header.DocumentDate.Date;

            var query = _db.DcCampaigns
                .Include(c => c.TrCampaignProducts)
                .Include(c => c.TrCampaignCategories)
                .Include(c => c.TrCampaignCustomers)
                .Include(c => c.TrCampaignStores)
                .Include(c => c.TrCampaignWarehouses)
                .Where(c => c.IsActive
                         && c.StartDate.Date <= today
                         && c.EndDate.Date >= today
                         && (c.ProcessCode == header.ProcessCode))
                .AsEnumerable(); // client-side üçün

            if (!string.IsNullOrWhiteSpace(promoCode))
                query = query.Where(c =>
                    string.Equals(c.PromoCode, promoCode, StringComparison.OrdinalIgnoreCase));

            return query.Where(c => IsCampaignApplicable(c, header, lines)).ToList();
        }

        /// <summary>Yalnız IsCashOnly=true olan kampaniyalar.</summary>
        public List<DcCampaign> GetApplicableCashOnlyCampaigns(
            TrInvoiceHeader header,
            IList<TrInvoiceLine> lines)
            => GetApplicableCampaigns(header, lines).Where(c => c.IsCashOnly).ToList();

        // ──────────────────────────────────────────────────────────
        // TƏTBİQ
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// Kampaniyanı sətirə tətbiq edir, DiscountCampaign güncəlləyir
        /// və TrInvoiceCampaignLog yazır.
        /// </summary>
        public CampaignApplyResult ApplyCampaign(
            DcCampaign campaign,
            TrInvoiceHeader header,
            IList<TrInvoiceLine> lines)
        {
            var result = new CampaignApplyResult
            {
                CampaignId = campaign.CampaignId,
                CampaignDesc = campaign.CampaignDesc
            };

            var applicableLines = lines
                .Where(l => IsLineApplicable(campaign, l) && l.NetAmountBeforeCampaign > 0)
                .ToList();

            if (!applicableLines.Any())
            {
                result.Success = false;
                result.Message = $"'{campaign.CampaignDesc}' kampaniyası üçün uyğun sətir tapılmadı.";
                return result;
            }

            decimal totalBase = applicableLines.Sum(l => l.NetAmountBeforeCampaign);
            decimal remainingMaxDiscount = campaign.MaxDiscountAmount > 0
                ? campaign.MaxDiscountAmount
                : decimal.MaxValue;

            foreach (var line in applicableLines)
            {
                // Original dəyəri yadda saxla (rollback üçün)
                result.OriginalLineDiscounts[line.InvoiceLineId] = line.DiscountCampaign;

                decimal lineDiscount = campaign.DiscountTypeCode == DiscountTypeCode.Percent
                    ? line.NetAmountBeforeCampaign * campaign.DiscountValue / 100m
                    : (totalBase > 0
                        ? campaign.DiscountValue * (line.NetAmountBeforeCampaign / totalBase)
                        : 0m);

                // MaxDiscountAmount kap
                if (campaign.MaxDiscountAmount > 0)
                {
                    lineDiscount = Math.Min(lineDiscount, remainingMaxDiscount);
                    remainingMaxDiscount -= lineDiscount;
                }

                lineDiscount = Math.Round(lineDiscount, 4);
                line.DiscountCampaign = Math.Round(line.DiscountCampaign + lineDiscount, 4);

                // Log yaz
                decimal exRate = line.ExchangeRate == 0 ? 1m : (decimal)line.ExchangeRate;

                var log = new TrInvoiceCampaignLog
                {
                    InvoiceCampaignLogId = Guid.NewGuid(),
                    InvoiceHeaderId = header.InvoiceHeaderId,
                    InvoiceLineId = line.InvoiceLineId,
                    CampaignId = campaign.CampaignId,
                    CampaignCode = campaign.CampaignCode,
                    CampaignDesc = campaign.CampaignDesc,
                    PromoCode = campaign.PromoCode,
                    Priority = campaign.Priority,
                    IsCombinable = campaign.IsCombinable,
                    BaseAmount = line.NetAmountBeforeCampaign,
                    BaseAmountLoc = line.NetAmountLocBeforeCampaign,
                    DiscountAmount = lineDiscount,
                    DiscountAmountLoc = Math.Round(lineDiscount / exRate, 4),
                    DiscountPercent = campaign.DiscountTypeCode == DiscountTypeCode.Percent
                        ? campaign.DiscountValue
                        : (totalBase > 0 ? Math.Round(lineDiscount / line.NetAmountBeforeCampaign * 100, 4) : 0m)
                };

                _db.TrInvoiceCampaignLogs.Add(log);
                result.AppliedLogIds.Add(log.InvoiceCampaignLogId);
            }

            _db.SaveChanges();

            decimal totalApplied = applicableLines.Sum(l =>
                l.DiscountCampaign - (result.OriginalLineDiscounts.ContainsKey(l.InvoiceLineId)
                    ? result.OriginalLineDiscounts[l.InvoiceLineId]
                    : 0m));

            result.Success = true;
            result.Message = $"Kampaniya tətbiq edildi: {campaign.CampaignDesc}\n" +
                             $"Ümumi endirim: {totalApplied:n2}";
            return result;
        }

        // ──────────────────────────────────────────────────────────
        // ROLLBACK
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// ApplyCampaign nəticəsini tam geri alır:
        /// sətirlərin DiscountCampaign əvvəlki dəyərə qayıdır,
        /// log qeydləri silinir.
        /// </summary>
        public void RollbackCampaign(
            CampaignApplyResult applyResult,
            IList<TrInvoiceLine> lines)
        {
            // Sətirləri bərpa et
            foreach (var (lineId, originalDiscount) in applyResult.OriginalLineDiscounts)
            {
                var line = lines.FirstOrDefault(l => l.InvoiceLineId == lineId);
                if (line != null)
                    line.DiscountCampaign = originalDiscount;
            }

            // DB-dən logları sil
            if (applyResult.AppliedLogIds.Any())
            {
                var logsToRemove = _db.TrInvoiceCampaignLogs
                    .Where(l => applyResult.AppliedLogIds.Contains(l.InvoiceCampaignLogId))
                    .ToList();

                _db.TrInvoiceCampaignLogs.RemoveRange(logsToRemove);
            }

            _db.SaveChanges();
        }

        // ──────────────────────────────────────────────────────────
        // KÖMƏKÇI METODLARİ
        // ──────────────────────────────────────────────────────────

        private bool IsCampaignApplicable(
            DcCampaign campaign,
            TrInvoiceHeader header,
            IList<TrInvoiceLine> lines)
        {
            // Mağaza yoxlanması
            if (campaign.TrCampaignStores.Any() &&
                !campaign.TrCampaignStores.Any(s => s.StoreCode == header.StoreCode))
                return false;

            // Anbar yoxlanması
            if (campaign.TrCampaignWarehouses.Any() &&
                !campaign.TrCampaignWarehouses.Any(w => w.WarehouseCode == header.WarehouseCode))
                return false;

            // Müştəri yoxlanması
            if (campaign.TrCampaignCustomers.Any() &&
                !campaign.TrCampaignCustomers.Any(c => c.CurrAccCode == header.CurrAccCode))
                return false;

            // MinInvoiceAmount yoxlanması
            decimal totalNet = lines.Sum(l => l.NetAmountBeforeCampaign);
            if (campaign.MinInvoiceAmount > 0 && totalNet < campaign.MinInvoiceAmount)
                return false;

            // Məhsul / kateqoriya yoxlanması
            if (campaign.TrCampaignProducts.Any() || campaign.TrCampaignCategories.Any())
                if (!lines.Any(l => IsLineApplicable(campaign, l)))
                    return false;

            return true;
        }

        private bool IsLineApplicable(DcCampaign campaign, TrInvoiceLine line)
        {
            // Heç bir məhsul/kateqoriya məhdudiyyəti yoxdursa — bütün sətirlərdə keçərlidir
            if (!campaign.TrCampaignProducts.Any() && !campaign.TrCampaignCategories.Any())
                return true;

            // Məhsul üzrə
            if (campaign.TrCampaignProducts.Any(p => p.ProductCode == line.ProductCode))
                return true;

            // Kateqoriya üzrə
            if (campaign.TrCampaignCategories.Any())
            {
                var product = _db.DcProducts.Find(line.ProductCode);
                if (product != null &&
                    campaign.TrCampaignCategories.Any(c => c.HierarchyCode == product.HierarchyCode))
                    return true;
            }

            return false;
        }
    }
}
