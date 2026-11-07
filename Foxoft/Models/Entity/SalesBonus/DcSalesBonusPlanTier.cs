using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Bonus planının intervalı (TieredSalesPercent üçün satış intervalı: FromValue &lt; məbləğ ≤ ToValue)
    /// və ya hədəf bantı (SalesTargetAchievement üçün yerinə yetirmə faizi: FromValue ≤ % &lt; ToValue).
    /// ToValue boşdursa sonuncu (sonsuz) intervaldır.
    /// </summary>
    [Index(nameof(SalesBonusPlanId), nameof(FromValue))]
    [Display(Name = nameof(Resources.Entity_SalesBonusPlanTier), ResourceType = typeof(Resources))]
    public partial class DcSalesBonusPlanTier
    {
        [Key]
        public Guid SalesBonusPlanTierId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(DcSalesBonusPlan))]
        public Guid SalesBonusPlanId { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlanTier_FromValue), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FromValue { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlanTier_ToValue), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ToValue { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlanTier_Rate), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,4)")]
        public decimal Rate { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlanTier_FixedAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FixedAmount { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual DcSalesBonusPlan DcSalesBonusPlan { get; set; } = null!;
    }
}
