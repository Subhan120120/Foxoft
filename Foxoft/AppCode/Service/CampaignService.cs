using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service
{
    public class CampaignService
    {
        public CampaignApplyResult Apply(
                    Guid invoiceHeaderId,
                    string currAccCode,
                    IEnumerable<int>? paymentMethodIds = null,
                    string? promoCode = null,
                    IEnumerable<Guid>? approvedCampaignIds = null)
        {
            using var db = new subContext();

            TrInvoiceHeader? invoiceHeader = db.TrInvoiceHeaders
                .AsNoTracking()
                .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

            if (invoiceHeader is null)
                return CampaignApplyResult.Empty;

            SaveCampaignHeader(db, invoiceHeaderId, promoCode, currAccCode);

            List<int> resolvedPaymentMethodIds = ResolvePaymentMethodIds(db, invoiceHeaderId, paymentMethodIds);

            List<TrInvoiceLine> invoiceLines = db.TrInvoiceLines
                .Include(x => x.DcProduct)
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            ResetInvoiceCampaigns(db, invoiceHeaderId);

            if (invoiceLines.Count == 0)
            {
                db.SaveChanges(currAccCode);
                return CampaignApplyResult.Empty;
            }

            List<CampaignCandidate> candidates = GetCampaignCandidates(
                db,
                invoiceHeader,
                invoiceLines,
                resolvedPaymentMethodIds,
                promoCode,
                approvedCampaignIds,
                true);

            if (candidates.Count == 0)
            {
                db.SaveChanges(currAccCode);
                return CampaignApplyResult.Empty;
            }

            List<CampaignCandidate> selected = SelectCampaigns(candidates);

            Dictionary<Guid, TrInvoiceLine> trackedLines = db.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToDictionary(x => x.InvoiceLineId);

            Dictionary<Guid, decimal> currentLineDiscounts = trackedLines.Values
                .ToDictionary(x => x.InvoiceLineId, x => 0m);

            decimal totalDiscount = 0;

            foreach (CampaignCandidate selectedCampaign in selected)
            {
                foreach (CampaignLineDiscount lineDiscount in selectedCampaign.LineDiscounts)
                {
                    if (!trackedLines.TryGetValue(lineDiscount.InvoiceLineId, out TrInvoiceLine? trackedLine))
                        continue;

                    decimal remainBase = Math.Max(0, trackedLine.NetAmountBeforeCampaign - currentLineDiscounts[trackedLine.InvoiceLineId]);
                    if (remainBase <= 0)
                        continue;

                    decimal appliedDiscount = Math.Min(remainBase, lineDiscount.DiscountAmount);
                    if (appliedDiscount <= 0)
                        continue;

                    currentLineDiscounts[trackedLine.InvoiceLineId] += appliedDiscount;
                    trackedLine.DiscountCampaign = currentLineDiscounts[trackedLine.InvoiceLineId];
                    totalDiscount += appliedDiscount;

                    db.TrInvoiceCampaignLogs.Add(new TrInvoiceCampaignLog
                    {
                        InvoiceCampaignLogId = Guid.NewGuid(),
                        InvoiceHeaderId = invoiceHeaderId,
                        InvoiceLineId = trackedLine.InvoiceLineId,
                        CampaignId = selectedCampaign.Campaign.CampaignId,
                        CampaignCode = selectedCampaign.Campaign.CampaignCode,
                        CampaignDesc = selectedCampaign.Campaign.CampaignDesc,
                        PromoCode = string.IsNullOrWhiteSpace(promoCode) ? null : promoCode.Trim(),
                        PaymentMethodId = selectedCampaign.Campaign.TrCampaignPaymentMethods
                            .Select(x => (int?)x.PaymentMethodId)
                            .FirstOrDefault(),
                        Priority = selectedCampaign.Campaign.Priority,
                        IsCombinable = selectedCampaign.Campaign.IsCombinable,
                        BaseAmount = lineDiscount.BaseAmount,
                        BaseAmountLoc = lineDiscount.BaseAmount,
                        DiscountAmount = appliedDiscount,
                        DiscountAmountLoc = appliedDiscount,
                        DiscountPercent = lineDiscount.DiscountPercent,
                        Note = lineDiscount.Note
                    });
                }
            }

            db.SaveChanges(currAccCode);

            return new CampaignApplyResult
            {
                AppliedCampaignIds = selected.Select(x => x.Campaign.CampaignId).Distinct().ToList(),
                AppliedCampaignCodes = selected.Select(x => x.Campaign.CampaignCode).Distinct().ToList(),
                TotalDiscount = totalDiscount
            };
        }

        private List<CampaignCandidate> GetCampaignCandidates(
            subContext db,
            TrInvoiceHeader invoiceHeader,
            List<TrInvoiceLine> invoiceLines,
            List<int> resolvedPaymentMethodIds,
            string? promoCode,
            IEnumerable<Guid>? approvedCampaignIds,
            bool enforcePassword)
        {
            List<CampaignCandidate> candidates = new();

            if (invoiceLines.Count == 0)
                return candidates;

            string? promoCodeValue = string.IsNullOrWhiteSpace(promoCode) ? null : promoCode.Trim();

            HashSet<Guid> approvedIdSet = approvedCampaignIds is null
                ? new HashSet<Guid>()
                : new HashSet<Guid>(approvedCampaignIds);

            List<DcCampaign> campaigns = db.DcCampaigns
                .Include(x => x.TrCampaignProducts)
                .Include(x => x.TrCampaignCategories)
                .Include(x => x.TrCampaignCustomers)
                .Include(x => x.TrCampaignStores)
                .Include(x => x.TrCampaignWarehouses)
                .Include(x => x.TrCampaignPaymentMethods)
                .Where(x => x.IsActive)
                .Where(x => x.StartDate <= invoiceHeader.DocumentDate && x.EndDate >= invoiceHeader.DocumentDate)
                .AsNoTracking()
                .ToList();

            decimal invoiceNetAmount = invoiceLines.Sum(x => Math.Max(0, x.NetAmountBeforeCampaign));

            foreach (DcCampaign campaign in campaigns)
            {
                if (!MatchesHeaderScope(campaign, invoiceHeader, resolvedPaymentMethodIds, promoCodeValue))
                    continue;

                if (campaign.MinInvoiceAmount > 0 && invoiceNetAmount < campaign.MinInvoiceAmount)
                    continue;

                if (enforcePassword
                    && !string.IsNullOrWhiteSpace(campaign.CampaignPassword)
                    && !approvedIdSet.Contains(campaign.CampaignId))
                    continue;

                List<TrInvoiceLine> matchedLines = invoiceLines
                    .Where(x => MatchesLineScope(campaign, x))
                    .ToList();

                if (matchedLines.Count == 0)
                    continue;

                List<CampaignLineDiscount> lineDiscounts = BuildLineDiscounts(campaign, matchedLines);
                if (lineDiscounts.Count == 0)
                    continue;

                candidates.Add(new CampaignCandidate
                {
                    Campaign = campaign,
                    LineDiscounts = lineDiscounts
                });
            }

            return candidates;
        }


        public sealed class CampaignPasswordCandidate
        {
            public Guid CampaignId { get; set; }
            public string CampaignCode { get; set; }
            public string CampaignDesc { get; set; }
        }



        private static void SaveCampaignHeader(subContext db, Guid invoiceHeaderId, string? promoCode, string currAccCode)
        {
            TrInvoiceCampaignHeader? header = db.TrInvoiceCampaignHeaders
                .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

            if (header is null)
            {
                header = new TrInvoiceCampaignHeader
                {
                    InvoiceCampaignHeaderId = Guid.NewGuid(),
                    InvoiceHeaderId = invoiceHeaderId,
                    PromoCode = string.IsNullOrWhiteSpace(promoCode) ? null : promoCode.Trim()
                };

                db.TrInvoiceCampaignHeaders.Add(header);
            }
            else
            {
                header.PromoCode = string.IsNullOrWhiteSpace(promoCode) ? null : promoCode.Trim();
            }
        }

        private static void ResetInvoiceCampaigns(subContext db, Guid invoiceHeaderId)
        {
            List<TrInvoiceLine> trackedLines = db.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            foreach (TrInvoiceLine trackedLine in trackedLines)
                trackedLine.DiscountCampaign = 0;

            List<TrInvoiceCampaignLog> oldLogs = db.TrInvoiceCampaignLogs
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            if (oldLogs.Count > 0)
                db.TrInvoiceCampaignLogs.RemoveRange(oldLogs);
        }

        private static List<int> ResolvePaymentMethodIds(subContext db, Guid invoiceHeaderId, IEnumerable<int>? paymentMethodIds)
        {
            List<int> resolved = paymentMethodIds?
                .Where(x => x > 0)
                .Distinct()
                .ToList()
                ?? new List<int>();

            if (resolved.Count > 0)
                return resolved;

            List<Guid> paymentHeaderIds = db.TrPaymentHeaders
                .AsNoTracking()
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .Select(x => x.PaymentHeaderId)
                .ToList();

            if (paymentHeaderIds.Count == 0)
                return resolved;

            return db.TrPaymentLines
                .AsNoTracking()
                .Where(x => paymentHeaderIds.Contains(x.PaymentHeaderId))
                .Select(x => x.PaymentMethodId)
                .Distinct()
                .ToList();
        }

        private static bool MatchesHeaderScope(DcCampaign campaign, TrInvoiceHeader invoiceHeader, List<int> paymentMethodIds, string? promoCode)
        {
            if (!string.IsNullOrWhiteSpace(campaign.PromoCode) &&
                !string.Equals(campaign.PromoCode.Trim(), promoCode?.Trim(), StringComparison.OrdinalIgnoreCase))
                return false;

            if (campaign.TrCampaignCustomers.Any() &&
                !campaign.TrCampaignCustomers.Any(x => x.CurrAccCode == invoiceHeader.CurrAccCode))
                return false;

            if (campaign.TrCampaignStores.Any() &&
                !campaign.TrCampaignStores.Any(x => x.StoreCode == invoiceHeader.StoreCode))
                return false;

            if (campaign.TrCampaignWarehouses.Any() &&
                !campaign.TrCampaignWarehouses.Any(x => x.WarehouseCode == invoiceHeader.WarehouseCode))
                return false;

            if (campaign.TrCampaignPaymentMethods.Any())
            {
                if (paymentMethodIds.Count == 0)
                    return false;

                if (!campaign.TrCampaignPaymentMethods.Any(x => paymentMethodIds.Contains(x.PaymentMethodId)))
                    return false;
            }

            return true;
        }

        private static bool MatchesLineScope(DcCampaign campaign, TrInvoiceLine line)
        {
            bool hasProducts = campaign.TrCampaignProducts.Any();
            bool hasCategories = campaign.TrCampaignCategories.Any();

            if (!hasProducts && !hasCategories)
                return true;

            bool productMatch = hasProducts && campaign.TrCampaignProducts.Any(x => x.ProductCode == line.ProductCode);

            string? hierarchyCode = line.DcProduct?.HierarchyCode;
            bool categoryMatch = hasCategories &&
                                 !string.IsNullOrWhiteSpace(hierarchyCode) &&
                                 campaign.TrCampaignCategories.Any(x => x.HierarchyCode == hierarchyCode);

            return productMatch || categoryMatch;
        }

        private static List<CampaignCandidate> SelectCampaigns(List<CampaignCandidate> candidates)
        {
            List<CampaignCandidate> ordered = candidates
                .OrderByDescending(x => x.Campaign.Priority)
                .ThenByDescending(x => x.TotalDiscountAmount)
                .ThenBy(x => x.Campaign.CampaignCode)
                .ToList();

            if (ordered.Count == 0)
                return new List<CampaignCandidate>();

            CampaignCandidate top = ordered.First();

            if (!top.Campaign.IsCombinable)
                return new List<CampaignCandidate> { top };

            return ordered
                .Where(x => x.Campaign.IsCombinable)
                .ToList();
        }

        private static List<CampaignLineDiscount> BuildLineDiscounts(DcCampaign campaign, List<TrInvoiceLine> lines)
        {
            List<CampaignLineDiscount> result = new();

            decimal totalBase = lines.Sum(x => Math.Max(0, x.NetAmountBeforeCampaign));
            if (totalBase <= 0)
                return result;

            if (campaign.DiscountTypeCode == DiscountTypeCode.Percent)
            {
                foreach (TrInvoiceLine line in lines)
                {
                    decimal lineBase = Math.Max(0, line.NetAmountBeforeCampaign);
                    if (lineBase <= 0)
                        continue;

                    decimal discount = Math.Round(lineBase * campaign.DiscountValue / 100m, 4);
                    result.Add(new CampaignLineDiscount
                    {
                        InvoiceLineId = line.InvoiceLineId,
                        BaseAmount = lineBase,
                        DiscountAmount = Math.Min(lineBase, discount),
                        DiscountPercent = campaign.DiscountValue
                    });
                }
            }
            else
            {
                decimal remaining = campaign.DiscountValue;

                foreach (TrInvoiceLine line in lines.OrderByDescending(x => x.NetAmountBeforeCampaign))
                {
                    decimal lineBase = Math.Max(0, line.NetAmountBeforeCampaign);
                    if (lineBase <= 0 || remaining <= 0)
                        continue;

                    decimal proportional = Math.Round(campaign.DiscountValue * (lineBase / totalBase), 4);
                    decimal discount = Math.Min(lineBase, proportional);
                    discount = Math.Min(discount, remaining);

                    remaining -= discount;

                    result.Add(new CampaignLineDiscount
                    {
                        InvoiceLineId = line.InvoiceLineId,
                        BaseAmount = lineBase,
                        DiscountAmount = discount,
                        DiscountPercent = 0
                    });
                }
            }

            if (campaign.MaxDiscountAmount > 0)
            {
                decimal totalDiscount = result.Sum(x => x.DiscountAmount);
                if (totalDiscount > campaign.MaxDiscountAmount)
                {
                    decimal ratio = campaign.MaxDiscountAmount / totalDiscount;
                    foreach (CampaignLineDiscount row in result)
                        row.DiscountAmount = Math.Round(row.DiscountAmount * ratio, 4);
                }
            }

            return result
                .Where(x => x.DiscountAmount > 0)
                .ToList();
        }

        private sealed class CampaignCandidate
        {
            public DcCampaign Campaign { get; set; }
            public List<CampaignLineDiscount> LineDiscounts { get; set; } = new();
            public decimal TotalDiscountAmount => LineDiscounts.Sum(x => x.DiscountAmount);
        }

        private sealed class CampaignLineDiscount
        {
            public Guid InvoiceLineId { get; set; }
            public decimal BaseAmount { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal DiscountPercent { get; set; }
            public string? Note { get; set; }
        }

        public List<CampaignPasswordCandidate> GetPasswordProtectedCampaigns(Guid invoiceHeaderId, IEnumerable<int>? paymentMethodIds = null, string? promoCode = null)
        {
            using var db = new subContext();

            TrInvoiceHeader? invoiceHeader = db.TrInvoiceHeaders
                .AsNoTracking()
                .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);

            if (invoiceHeader is null)
                return new List<CampaignPasswordCandidate>();

            List<int> resolvedPaymentMethodIds = ResolvePaymentMethodIds(db, invoiceHeaderId, paymentMethodIds);

            List<TrInvoiceLine> invoiceLines = db.TrInvoiceLines
                .Include(x => x.DcProduct)
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .ToList();

            List<CampaignCandidate> candidates = GetCampaignCandidates(
                db,
                invoiceHeader,
                invoiceLines,
                resolvedPaymentMethodIds,
                promoCode,
                null,
                false);

            return candidates
                .Where(x => !string.IsNullOrWhiteSpace(x.Campaign.CampaignPassword))
                .GroupBy(x => x.Campaign.CampaignId)
                .Select(x => new CampaignPasswordCandidate
                {
                    CampaignId = x.Key,
                    CampaignCode = x.First().Campaign.CampaignCode,
                    CampaignDesc = x.First().Campaign.CampaignDesc
                })
                .OrderBy(x => x.CampaignCode)
                .ToList();
        }

        public bool ValidateCampaignPassword(Guid campaignId, string? campaignPassword)
        {
            using var db = new subContext();

            string? currentPassword = db.DcCampaigns
                .AsNoTracking()
                .Where(x => x.CampaignId == campaignId)
                .Select(x => x.CampaignPassword)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(currentPassword))
                return true;

            return string.Equals(currentPassword.Trim(), campaignPassword?.Trim(), StringComparison.Ordinal);
        }
    }
    public sealed class CampaignApplyResult
    {
        public static CampaignApplyResult Empty => new();

        public List<Guid> AppliedCampaignIds { get; set; } = new();
        public List<string> AppliedCampaignCodes { get; set; } = new();
        public decimal TotalDiscount { get; set; }
    }


}