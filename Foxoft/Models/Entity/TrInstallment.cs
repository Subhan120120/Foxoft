using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Kredit")]
    public partial class TrInstallment
    {
        public TrInstallment()
        {
            TrInstallmentGuarantors = new HashSet<TrInstallmentGuarantor>();
        }

        [Key]
        [Display(Name = "Kredit İd")]
        public int InstallmentId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        [Display(Name = "Faktura İd")]
        public Guid InvoiceHeaderId { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = "Kredit Tarixi")]
        public DateTime InstallmentDate { get; set; }

        [Display(Name = "Ödəmə Planı Kodu")]
        [ForeignKey("DcInstallmentPlan")]
        public string InstallmentPlanCode { get; set; }

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; } // Interest rate associated with the plan, if applicable 

        [Display(Name = "Faiz Dərəcəsi (%)")]
        [Range(0, 100, ErrorMessage = "{0} 0 ilə 100 arasında olmalıdır \n")]
        public float InterestRate { get; set; }


        [NotMapped]
        [Display(Name = "Ödənişlərin Cəmi")]
        public decimal TotalPaid { get; set; }

        [NotMapped]
        [Display(Name = "Qalan Balans")]
        public decimal RemainingBalance { get; set; }

        [NotMapped]
        [Display(Name = "Aylıq Ödəniş")]
        public decimal MonthlyPayment { get; set; }

        [NotMapped]
        [Display(Name = "Ödənilməli")]
        public decimal DueAmount { get; set; }

        [NotMapped]
        [Display(Name = "Gecikən Günlər")]
        public int OverdueDays { get; set; }

        [NotMapped]
        [Display(Name = "Gecikmə Tarixi")]
        public DateTime? OverdueDate { get; set; } // İlk gecikmə tarixi olaraq "OverdueDate" istifadə edildi

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcInstallmentPlan DcInstallmentPlan { get; set; }
        public virtual ICollection<TrInstallmentGuarantor> TrInstallmentGuarantors { get; set; }
    }
}
