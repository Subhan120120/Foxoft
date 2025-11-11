using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentType), ResourceType = typeof(Resources))]
    public partial class DcPaymentType
    {
        public DcPaymentType()
        {
            DcPaymentMethods = new HashSet<DcPaymentMethod>();
            TrPaymentLines = new HashSet<TrPaymentLine>();
            DcCurrAccs = new HashSet<DcCurrAcc>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_PaymentType_Code), ResourceType = typeof(Resources))]
        public byte PaymentTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PaymentTypeDesc { get; set; }

        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
        public virtual ICollection<DcPaymentMethod> DcPaymentMethods { get; set; }
    }
}
