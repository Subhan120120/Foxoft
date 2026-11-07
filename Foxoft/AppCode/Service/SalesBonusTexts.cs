using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft.AppCode.Service
{
    /// <summary>LookUpEdit və grid-lərdə enum dəyərlərini lokallaşdırılmış mətnlə göstərmək üçün.</summary>
    public sealed class EnumLookupItem
    {
        public byte Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    /// <summary>Satıcı bonus modulunun enum-ları üçün lokallaşdırılmış mətnlər.</summary>
    public static class SalesBonusTexts
    {
        public static string Text(BonusCalcMethod method) => method switch
        {
            BonusCalcMethod.SalesAmountPercent => Resources.Enum_BonusCalcMethod_SalesAmountPercent,
            BonusCalcMethod.GrossProfitPercent => Resources.Enum_BonusCalcMethod_GrossProfitPercent,
            BonusCalcMethod.PerUnitSold => Resources.Enum_BonusCalcMethod_PerUnitSold,
            BonusCalcMethod.SalesTargetAchievement => Resources.Enum_BonusCalcMethod_SalesTargetAchievement,
            BonusCalcMethod.CollectionPercent => Resources.Enum_BonusCalcMethod_CollectionPercent,
            BonusCalcMethod.FixedAmount => Resources.Enum_BonusCalcMethod_FixedAmount,
            BonusCalcMethod.TieredSalesPercent => Resources.Enum_BonusCalcMethod_TieredSalesPercent,
            _ => method.ToString()
        };

        public static string Text(BonusTierMode mode) => mode switch
        {
            BonusTierMode.Progressive => Resources.Enum_BonusTierMode_Progressive,
            BonusTierMode.Retroactive => Resources.Enum_BonusTierMode_Retroactive,
            _ => mode.ToString()
        };

        public static string Text(BonusTriggerType trigger) => trigger switch
        {
            BonusTriggerType.OnInvoiceConfirm => Resources.Enum_BonusTriggerType_OnInvoiceConfirm,
            BonusTriggerType.OnCustomerPayment => Resources.Enum_BonusTriggerType_OnCustomerPayment,
            BonusTriggerType.Manual => Resources.Enum_BonusTriggerType_Manual,
            _ => trigger.ToString()
        };

        public static string Text(BonusPeriodType periodType) => periodType switch
        {
            BonusPeriodType.Monthly => Resources.Enum_BonusPeriodType_Monthly,
            BonusPeriodType.Quarterly => Resources.Enum_BonusPeriodType_Quarterly,
            BonusPeriodType.Yearly => Resources.Enum_BonusPeriodType_Yearly,
            _ => periodType.ToString()
        };

        public static string Text(BonusTxnType txnType) => txnType switch
        {
            BonusTxnType.Earn => Resources.Enum_BonusTxnType_Earn,
            BonusTxnType.Reverse => Resources.Enum_BonusTxnType_Reverse,
            BonusTxnType.Adjust => Resources.Enum_BonusTxnType_Adjust,
            _ => txnType.ToString()
        };

        public static List<EnumLookupItem> CalcMethods() => Enum.GetValues<BonusCalcMethod>()
            .Select(x => new EnumLookupItem { Value = (byte)x, Text = Text(x) }).ToList();

        public static List<EnumLookupItem> TierModes() => Enum.GetValues<BonusTierMode>()
            .Select(x => new EnumLookupItem { Value = (byte)x, Text = Text(x) }).ToList();

        public static List<EnumLookupItem> TriggerTypes() => Enum.GetValues<BonusTriggerType>()
            .Select(x => new EnumLookupItem { Value = (byte)x, Text = Text(x) }).ToList();

        public static List<EnumLookupItem> PeriodTypes() => Enum.GetValues<BonusPeriodType>()
            .Select(x => new EnumLookupItem { Value = (byte)x, Text = Text(x) }).ToList();

        public static List<EnumLookupItem> TxnTypes() => Enum.GetValues<BonusTxnType>()
            .Select(x => new EnumLookupItem { Value = (byte)x, Text = Text(x) }).ToList();
    }
}
