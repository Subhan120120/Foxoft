using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft.AppCode.Service
{
    /// <summary>
    /// Satıcı bonusunun "təmiz" hesablama qaydaları (DB-dən asılı deyil).
    /// Bütün məbləğlər yerli valyutada, nəticələr 2 onluq rəqəmə yuvarlaqlaşdırılır.
    /// </summary>
    public static class SalesBonusCalculator
    {
        /// <summary>İnterval / hədəf bantı tərifi.</summary>
        public sealed record TierDef(decimal From, decimal? To, decimal Rate, decimal FixedAmount);

        /// <summary>Bir intervalın hesablama izi (audit üçün).</summary>
        public sealed record TierTrace(decimal From, decimal? To, decimal Rate, decimal FixedAmount, decimal Slice, decimal Amount);

        public static decimal Round2(decimal value) => Math.Round(value, 2, MidpointRounding.AwayFromZero);

        public static bool IsPeriodScoped(BonusCalcMethod method) =>
            method is BonusCalcMethod.TieredSalesPercent
                   or BonusCalcMethod.SalesTargetAchievement
                   or BonusCalcMethod.FixedAmount;

        /// <summary>
        /// Satış intervalına görə dəyişən faiz. İnterval: From &lt; məbləğ ≤ To (To boş = sonsuz).
        /// Progressive: hər interval öz faizi ilə; Retroactive: çatılmış son intervalın faizi bütün məbləğə.
        /// Mənfi və ya sıfır baza üçün bonus 0-dır.
        /// </summary>
        public static decimal CalcTiered(decimal baseAmount, IReadOnlyList<TierDef> tiers, BonusTierMode mode, List<TierTrace>? trace = null)
        {
            if (baseAmount <= 0 || tiers == null || tiers.Count == 0)
                return 0m;

            List<TierDef> ordered = tiers.OrderBy(t => t.From).ToList();
            decimal amount = 0m;

            if (mode == BonusTierMode.Retroactive)
            {
                TierDef tier = ordered.LastOrDefault(t => baseAmount > t.From) ?? ordered[0];
                amount = baseAmount * tier.Rate / 100m + tier.FixedAmount;
                trace?.Add(new TierTrace(tier.From, tier.To, tier.Rate, tier.FixedAmount, baseAmount, Round2(amount)));
                return Round2(amount);
            }

            foreach (TierDef tier in ordered)
            {
                if (baseAmount <= tier.From)
                    break;

                decimal upper = tier.To ?? decimal.MaxValue;
                decimal slice = Math.Min(baseAmount, upper) - tier.From;
                if (slice <= 0)
                    continue;

                decimal tierAmount = slice * tier.Rate / 100m + tier.FixedAmount;
                amount += tierAmount;
                trace?.Add(new TierTrace(tier.From, tier.To, tier.Rate, tier.FixedAmount, slice, Round2(tierAmount)));
            }

            return Round2(amount);
        }

        /// <summary>
        /// Satış planının yerinə yetirilməsinə görə bonus.
        /// Bantlar varsa: yerinə yetirmə faizi From ≤ % &lt; To olan bant seçilir → baza × bant.Rate% + bant.FixedAmount.
        /// Bant yoxdursa: yerinə yetirmə ≥ minAchievementPercent olduqda baza × rate% + fixedAmount.
        /// </summary>
        public static decimal CalcTarget(decimal baseAmount, decimal target, decimal minAchievementPercent, decimal rate, decimal fixedAmount,
                                         IReadOnlyList<TierDef> bands, out decimal achievementPercent, List<TierTrace>? trace = null)
        {
            achievementPercent = target > 0 ? Math.Round(baseAmount / target * 100m, 2) : 0m;

            if (target <= 0 || baseAmount <= 0)
                return 0m;

            if (bands != null && bands.Count > 0)
            {
                decimal pct = achievementPercent;
                TierDef? band = bands.OrderBy(b => b.From)
                                     .LastOrDefault(b => pct >= b.From && (b.To == null || pct < b.To.Value));
                if (band == null)
                    return 0m;

                decimal bandAmount = baseAmount * band.Rate / 100m + band.FixedAmount;
                trace?.Add(new TierTrace(band.From, band.To, band.Rate, band.FixedAmount, baseAmount, Round2(bandAmount)));
                return Round2(bandAmount);
            }

            if (achievementPercent < minAchievementPercent)
                return 0m;

            return Round2(baseAmount * rate / 100m + fixedAmount);
        }

        /// <summary>Sabit bonus: dövrdə ən azı bir uyğun satış sənədi varsa sabit məbləğ.</summary>
        public static decimal CalcFixed(decimal fixedAmount, int qualifyingDocumentCount)
            => qualifyingDocumentCount > 0 ? Round2(fixedAmount) : 0m;

        /// <summary>Limit (MaxBonusAmount) tətbiqi: |bonus| ≤ cap.</summary>
        public static decimal ApplyCap(decimal amount, decimal? cap)
        {
            if (!cap.HasValue || cap.Value <= 0)
                return amount;

            if (amount > cap.Value) return cap.Value;
            if (amount < -cap.Value) return -cap.Value;
            return amount;
        }

        /// <summary>Ödənilmiş hissənin nisbəti [0..1]. Xalis məbləğ ≤ 0 olduqda 1 (bonus bazası onsuz da 0-dır).</summary>
        public static decimal PaidRatio(decimal netAmount, decimal paidAmount)
        {
            if (netAmount <= 0)
                return 1m;

            decimal ratio = paidAmount / netAmount;
            if (ratio < 0) return 0m;
            if (ratio > 1) return 1m;
            return ratio;
        }

        /// <summary>Dövr nömrəsi: aylıq 1-12, rüblük 1-4, illik 1.</summary>
        public static (int Year, int No) PeriodOf(DateTime date, BonusPeriodType periodType) => periodType switch
        {
            BonusPeriodType.Quarterly => (date.Year, (date.Month - 1) / 3 + 1),
            BonusPeriodType.Yearly => (date.Year, 1),
            _ => (date.Year, date.Month)
        };

        /// <summary>Dövrün başlanğıc və son tarixləri (date hissəsi).</summary>
        public static (DateTime Start, DateTime End) PeriodRange(int year, int no, BonusPeriodType periodType)
        {
            switch (periodType)
            {
                case BonusPeriodType.Quarterly:
                    {
                        int startMonth = (no - 1) * 3 + 1;
                        DateTime start = new(year, startMonth, 1);
                        return (start, start.AddMonths(3).AddDays(-1));
                    }
                case BonusPeriodType.Yearly:
                    return (new DateTime(year, 1, 1), new DateTime(year, 12, 31));
                default:
                    {
                        DateTime start = new(year, no, 1);
                        return (start, start.AddMonths(1).AddDays(-1));
                    }
            }
        }

        public static string PeriodText(int year, int no, BonusPeriodType periodType) => periodType switch
        {
            BonusPeriodType.Quarterly => $"{year}-Q{no}",
            BonusPeriodType.Yearly => $"{year}",
            _ => $"{year}-{no:00}"
        };
    }
}
