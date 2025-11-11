using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentPlan), ResourceType = typeof(Resources))]
    public partial class DcPaymentPlan
    {
        public DcPaymentPlan() { }

        [Key]
        [Display(Name = nameof(Resources.Entity_PaymentPlan_Code), ResourceType = typeof(Resources))]
        public string PaymentPlanCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentPlan_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PaymentPlanDesc { get; set; }

        [ForeignKey(nameof(DcPaymentMethod))]
        [Display(Name = nameof(Resources.Entity_PaymentPlan_MethodId), ResourceType = typeof(Resources))]
        public int PaymentMethodId { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentPlan_DurationInMonths), ResourceType = typeof(Resources))]
        public int DurationInMonths { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentPlan_CommissionRate), ResourceType = typeof(Resources))]
        public float CommissionRate { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentPlan_IsDefault), ResourceType = typeof(Resources))]
        public bool IsDefault { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
    }
}
