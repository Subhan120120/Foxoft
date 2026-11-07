using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Bonus planının məhsul filtri. Plan üçün heç bir məhsul/kateqoriya filtri yoxdursa bütün məhsullar bonusa daxildir.
    /// RateOverride göstərilərsə həmin məhsul üçün planın ümumi dərəcəsi əvəzinə bu dərəcə tətbiq olunur.
    /// </summary>
    [Index(nameof(SalesBonusPlanId), nameof(ProductCode), IsUnique = true)]
    public partial class DcSalesBonusPlanProduct
    {
        [Key]
        public Guid SalesBonusPlanProductId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(DcSalesBonusPlan))]
        public Guid SalesBonusPlanId { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_Code), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_RateOverride), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,4)")]
        public decimal? RateOverride { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual DcSalesBonusPlan DcSalesBonusPlan { get; set; } = null!;

        public virtual DcProduct DcProduct { get; set; } = null!;
    }
}
