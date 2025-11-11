using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentKind), ResourceType = typeof(Resources))]
    public partial class DcPaymentKind
    {
        public DcPaymentKind()
        {
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_PaymentKind_Id), ResourceType = typeof(Resources))]
        public byte PaymentKindId { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentKind_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PaymentKindDesc { get; set; }

        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
    }
}
