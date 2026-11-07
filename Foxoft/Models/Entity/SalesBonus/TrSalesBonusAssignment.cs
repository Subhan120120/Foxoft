using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Bonus planının satıcıya (DcCurrAcc, Personnel) təyin edilməsi. Hər satıcıya fərqli plan(lar) və fərdi hədəf verilə bilər.
    /// </summary>
    [Index(nameof(SalesPersonCode), nameof(StartDate))]
    [Index(nameof(SalesBonusPlanId))]
    [Display(Name = nameof(Resources.Entity_SalesBonusAssignment), ResourceType = typeof(Resources))]
    public partial class TrSalesBonusAssignment : BaseEntity
    {
        public TrSalesBonusAssignment()
        {
            Txns = new HashSet<TrSalesBonusTxn>();
        }

        [Key]
        public Guid SalesBonusAssignmentId { get; set; } = Guid.NewGuid();

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_PlanId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcSalesBonusPlan))]
        public Guid SalesBonusPlanId { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_SalesPersonCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrAcc))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string SalesPersonCode { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_StartDate), ResourceType = typeof(Resources))]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_EndDate), ResourceType = typeof(Resources))]
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        /// <summary>Fərdi satış hədəfi; boşdursa planın hədəfi istifadə olunur.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_TargetAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TargetAmount { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_IsActive), ResourceType = typeof(Resources))]
        public bool IsActive { get; set; } = true;

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_Note), ResourceType = typeof(Resources))]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Note { get; set; }

        public virtual DcSalesBonusPlan DcSalesBonusPlan { get; set; } = null!;
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;
        public virtual ICollection<TrSalesBonusTxn> Txns { get; set; }
    }
}
