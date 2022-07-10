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
    public partial class TrPaymentLine : BaseEntity
    {
        [Key]
        public Guid PaymentLineId { get; set; }

        [ForeignKey("TrPaymentHeader")]
        public Guid PaymentHeaderId { get; set; }

        [DisplayName("Ödəmə Tipi")]
        [ForeignKey("DcPaymentType")]
        public byte PaymentTypeCode { get; set; }

        [DisplayName("Ödəmə")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Payment { get; set; }

        [DisplayName("Ödəmə YPV")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal PaymentLoc { get { return Payment * (decimal)ExchangeRate; } set { } }

        [DisplayName("Sətir Açıqlaması")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LineDescription { get; set; }

        [DisplayName("Valyuta")]
        [ForeignKey("DcCurrency")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CurrencyCode { get; set; }

        [DisplayName("Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; } = 1;

        [DisplayName("Kassa")]
        [ForeignKey("DcCurrAcc")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CashRegisterCode { get; set; }


        [NotMapped]
        [DisplayName("Ödəniş Et")]
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
        [DisplayName("Ödəniş Al")]
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
        [DisplayName("Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [NotMapped]
        [DisplayName("Cari Hesab Adı")]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [DisplayName("Ödəmiş Nömrəsi")]
        public string DocumentNumber { get; set; }

        [NotMapped]
        [DisplayName("Faktura Nömrəsi")]
        public string InvoiceNumber { get; set; }

        [NotMapped]
        [DisplayName("Invoice Id")]
        public Guid? InvoiceHeaderId { get; set; }

        [NotMapped]
        [DisplayName("Ödəmə Tarixi")]
        public DateTime DocumentDate { get; set; }

        public virtual TrPaymentHeader TrPaymentHeader { get; set; }
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
