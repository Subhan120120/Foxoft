using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Planı")]
    public partial class TrInstallment
    {
        public TrInstallment() { }

        [Key]
        [Display(Name = "Ödəmə Planı İd")]
        public int InstallmentId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        [Display(Name = "Faktura İd")]
        public Guid InvoiceHeaderId { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = "Faktura Tarixi")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Ödəmə Planı Kodu")]
        [ForeignKey("DcPaymentPlan")]
        public string PaymentPlanCode { get; set; }

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; } // Interest rate associated with the plan, if applicable 

        [Display(Name = "Ümumi Məbləğ")]
        public decimal Amount { get; set; }

        [Display(Name = "Ümumi Məbləğ (YPV)")]
        public decimal AmountLoc { get { return Math.Round(Amount / (decimal)ExchangeRate, 4); } set { } }

        [ForeignKey("DcCurrency")]
        [Display(Name = "Valyuta")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; }



        [NotMapped]
        [Display(Name = "Cari Hesab")]
        public string? CurrAccCode { get; set; }

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




        public virtual DcCurrency DcCurrency { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcPaymentPlan DcPaymentPlan { get; set; }

    }
}
