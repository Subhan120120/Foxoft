using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Planı")]
    public partial class DcPaymentPlan
    {
        public DcPaymentPlan()
        {
        }

        [Key]
        [Display(Name = "Ödəmə Planı Kodu")]
        public string PaymentPlanCode { get; set; }

        [Display(Name = "Ödəmə Planı Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PaymentPlanDesc { get; set; }

        [ForeignKey("DcPaymentMethod")]
        [Display(Name = "Ödəmə Metodu İd")]
        public int PaymentMethodId { get; set; }

        [Display(Name = "Müddət Aylarla")]
        public int DurationInMonths { get; set; } // Duration of the payment plan in months

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; } // Interest rate associated with the plan, if applicable 





        [ForeignKey("PaymentMethodId")]
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
        public virtual ICollection<TrPaymentPlan> TrPaymentPlans { get; set; }
    }
}
