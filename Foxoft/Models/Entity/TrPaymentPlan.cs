using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Planı")]
    public partial class TrPaymentPlan
    {
        public TrPaymentPlan()
        {
        }

        [Key]
        [Display(Name = "Ödəmə Planı İd")]
        public int PaymentPlanId { get; set; }

        [Display(Name = "Ödəmə Detalı İd")]
        [ForeignKey("TrPaymentLine")]
        public Guid PaymentLineId { get; set; }

        [Display(Name = "Ödəmə Planı Kodu")]
        [ForeignKey("DcPaymentPlan")]
        public string PaymentPlanCode { get; set; }

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; }

        [Display(Name = "Aylıq Ödəniş")]
        public decimal MonthlyPayment { get; set; }



        public virtual TrPaymentLine TrPaymentLine { get; set; }
        public virtual DcPaymentPlan DcPaymentPlan { get; set; }

    }
}
