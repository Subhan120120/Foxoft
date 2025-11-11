using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InstallmentPlan), ResourceType = typeof(Resources))]
    public partial class DcInstallmentPlan
    {
        public DcInstallmentPlan() { }

        [Key]
        [Display(Name = nameof(Resources.Entity_InstallmentPlan_Code), ResourceType = typeof(Resources))]
        public string InstallmentPlanCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InstallmentPlan_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string InstallmentPlanDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_InstallmentPlan_DurationInMonths), ResourceType = typeof(Resources))]
        public int DurationInMonths { get; set; }

        [Display(Name = nameof(Resources.Entity_InstallmentPlan_InterestRate), ResourceType = typeof(Resources))]
        public float InterestRate { get; set; }

        [Display(Name = nameof(Resources.Entity_InstallmentPlan_IsDefault), ResourceType = typeof(Resources))]
        public bool IsDefault { get; set; }

        public virtual ICollection<TrInstallment> TrInstallments { get; set; }
    }
}
