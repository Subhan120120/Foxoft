using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Satıcı bonus planı (konfiqurasiya). Hesablama metodu, tetikləmə növü, dərəcə, interval/hədəf parametrləri
    /// və məhsul/kateqoriya filtrləri burada saxlanılır.
    /// </summary>
    [Index(nameof(PlanName), IsUnique = true)]
    [Display(Name = nameof(Resources.Entity_SalesBonusPlan), ResourceType = typeof(Resources))]
    public partial class DcSalesBonusPlan : BaseEntity
    {
        public DcSalesBonusPlan()
        {
            Tiers = new HashSet<DcSalesBonusPlanTier>();
            Products = new HashSet<DcSalesBonusPlanProduct>();
            Categories = new HashSet<DcSalesBonusPlanCategory>();
            Assignments = new HashSet<TrSalesBonusAssignment>();
            Txns = new HashSet<TrSalesBonusTxn>();
        }

        [Key]
        public Guid SalesBonusPlanId { get; set; } = Guid.NewGuid();

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_PlanName), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PlanName { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_Description), ResourceType = typeof(Resources))]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Description { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_CalcMethod), ResourceType = typeof(Resources))]
        public BonusCalcMethod CalcMethod { get; set; } = BonusCalcMethod.SalesAmountPercent;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_TriggerType), ResourceType = typeof(Resources))]
        public BonusTriggerType TriggerType { get; set; } = BonusTriggerType.OnInvoiceConfirm;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_TierMode), ResourceType = typeof(Resources))]
        public BonusTierMode TierMode { get; set; } = BonusTierMode.Progressive;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_PeriodType), ResourceType = typeof(Resources))]
        public BonusPeriodType PeriodType { get; set; } = BonusPeriodType.Monthly;

        /// <summary>Faiz (SalesAmountPercent, GrossProfitPercent, CollectionPercent, Target) və ya vahid başına məbləğ (PerUnitSold).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_Rate), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,4)")]
        public decimal Rate { get; set; }

        /// <summary>Sabit bonus məbləği (FixedAmount metodu və ya hədəfə çatdıqda əlavə sabit məbləğ).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_FixedAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FixedAmount { get; set; }

        /// <summary>Dövr üzrə satış hədəfi (plan). Təyinatda fərdi hədəf göstərilərsə o üstünlük təşkil edir.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_TargetAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TargetAmount { get; set; }

        /// <summary>Hədəf metodunda bant yoxdursa bonusun verilməsi üçün minimum yerinə yetirmə faizi (məs. 100).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_TargetMinAchievementPercent), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,2)")]
        public decimal TargetMinAchievementPercent { get; set; } = 100m;

        /// <summary>Bonus qazanmaq üçün minimum baza məbləği (faktura və ya dövr üzrə). 0 = limit yoxdur.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_MinBaseAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinBaseAmount { get; set; }

        /// <summary>Bir faktura / dövr üzrə maksimum bonus (limit). Boş = limit yoxdur.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_MaxBonusAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxBonusAmount { get; set; }

        /// <summary>Bonusa daxil olan satış prosesləri (vergüllə): RS,WS,IS. Boş = bütün satış prosesləri.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_ProcessCodes), ResourceType = typeof(Resources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ProcessCodes { get; set; } = "RS,WS,IS";

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_IsActive), ResourceType = typeof(Resources))]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<DcSalesBonusPlanTier> Tiers { get; set; }
        public virtual ICollection<DcSalesBonusPlanProduct> Products { get; set; }
        public virtual ICollection<DcSalesBonusPlanCategory> Categories { get; set; }
        public virtual ICollection<TrSalesBonusAssignment> Assignments { get; set; }
        public virtual ICollection<TrSalesBonusTxn> Txns { get; set; }
    }
}
