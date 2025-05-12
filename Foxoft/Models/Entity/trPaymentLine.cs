using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Detalı")]
    public partial class TrPaymentLine : BaseEntity
    {
        [Key]
        public Guid PaymentLineId { get; set; }

        [ForeignKey("TrPaymentHeader")]
        public Guid PaymentHeaderId { get; set; }

        [Display(Name = "Ödəmə Tipi")]
        [ForeignKey("DcPaymentType")]
        public byte PaymentTypeCode { get; set; }

        [Display(Name = "Ödəmə")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Payment { get; set; }

        [Display(Name = "Ödəmə (YPV)")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal PaymentLoc { get { return Math.Round(Payment / (decimal)ExchangeRate, 4); } set { } }

        [Display(Name = "Sətir Açıqlaması")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? LineDescription { get; set; }

        [Display(Name = "Valyuta")]
        [ForeignKey("DcCurrency")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CurrencyCode { get; set; }

        [DefaultValue("1")]
        [Display(Name = "Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; } = 1;

        [Display(Name = "Kassa")]
        [ForeignKey("DcCurrAcc")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string? CashRegisterCode { get; set; }

        [Display(Name = "Ödəmə Metodu Kodu")]
        [ForeignKey("DcPaymentMethod")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int PaymentMethodId { get; set; }


        [NotMapped]
        [Display(Name = "Ödəniş Et")]
        public decimal MakePayment
        {
            get
            {
                if (Payment < 0)
                    return Payment * (-1);
                else return 0;
            }
            set => Payment = value * (-1);

        }

        [NotMapped]
        [Display(Name = "Ödəniş Al")]
        public decimal ReceivePayment
        {
            get
            {
                if (Payment > 0)
                    return Payment;
                else return 0;
            }
            set => Payment = value;
        }


        [NotMapped]
        [Display(Name = "Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [NotMapped]
        [Display(Name = "Cari Hesab Adı")]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [Display(Name = "Ödəmiş Nömrəsi")]
        public string DocumentNumber { get; set; }

        [NotMapped]
        [Display(Name = "Faktura Nömrəsi")]
        public string InvoiceNumber { get; set; }

        [NotMapped]
        [Display(Name = "Invoice Id")]
        public Guid? InvoiceHeaderId { get; set; }

        [NotMapped]
        [Display(Name = "Sənəd Tarixi")]
        public DateTime DocumentDate { get; set; }

        [NotMapped]
        [Display(Name = "Əvvəlki Borc")]
        public decimal BalanceBefor { get; set; }

        [NotMapped]
        [Display(Name = "Sonrakı Borc")]
        public decimal BalanceAfter { get; set; }

        public virtual TrPaymentHeader TrPaymentHeader { get; set; }
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
        //public virtual TrPaymentPlan TrPaymentPlan { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }

    }
}
