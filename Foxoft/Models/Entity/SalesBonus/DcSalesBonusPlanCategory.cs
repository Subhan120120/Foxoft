using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Bonus planının məhsul kateqoriyası (DcHierarchy) filtri. Alt kateqoriyalar avtomatik daxil edilir.
    /// RateOverride göstərilərsə kateqoriyadakı məhsullar üçün planın ümumi dərəcəsi əvəzinə bu dərəcə tətbiq olunur.
    /// </summary>
    [Index(nameof(SalesBonusPlanId), nameof(HierarchyCode), IsUnique = true)]
    public partial class DcSalesBonusPlanCategory
    {
        [Key]
        public Guid SalesBonusPlanCategoryId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(DcSalesBonusPlan))]
        public Guid SalesBonusPlanId { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Code), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcHierarchy))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string HierarchyCode { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_RateOverride), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,4)")]
        public decimal? RateOverride { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual DcSalesBonusPlan DcSalesBonusPlan { get; set; } = null!;

        public virtual DcHierarchy DcHierarchy { get; set; } = null!;
    }
}
