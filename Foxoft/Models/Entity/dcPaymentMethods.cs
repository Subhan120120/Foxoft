using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentMethod), ResourceType = typeof(Resources))]
    public partial class DcPaymentMethod
    {
        public DcPaymentMethod()
        {
            TrPaymentLines = new HashSet<TrPaymentLine>();
            TrPaymentMethodDiscounts = new HashSet<TrPaymentMethodDiscount>();
            DcPaymentPlans = new HashSet<DcPaymentPlan>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_PaymentMethod_Id), ResourceType = typeof(Resources))]
        public int PaymentMethodId { get; set; }

        [ForeignKey(nameof(DcPaymentType))]
        [Display(Name = nameof(Resources.Entity_PaymentMethod_TypeCode), ResourceType = typeof(Resources))]
        public byte PaymentTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentMethod_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PaymentMethodDesc { get; set; }

        [ForeignKey(nameof(DcCashReg))]
        [Display(Name = nameof(Resources.Entity_PaymentMethod_DefaultCashReg), ResourceType = typeof(Resources))]
        public string? DefaultCashRegCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentMethod_IsRedirected), ResourceType = typeof(Resources))]
        public bool IsRedirected { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_PaymentMethod_RedirectedCurrAcc), ResourceType = typeof(Resources))]
        public string? RedirectedCurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentMethod_IsDefault), ResourceType = typeof(Resources))]
        public bool IsDefault { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [ForeignKey(nameof(DefaultCashRegCode))] public virtual DcCurrAcc DcCashReg { get; set; }
        [ForeignKey(nameof(RedirectedCurrAccCode))] public virtual DcCurrAcc DcCurrAcc { get; set; }
        [ForeignKey(nameof(PaymentTypeCode))] public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public virtual ICollection<DcPaymentPlan> DcPaymentPlans { get; set; }
    }
}
