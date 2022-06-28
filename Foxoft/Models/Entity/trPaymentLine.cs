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

        [DisplayName("Ödəmə")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal PaymentLoc { get; set; }

        [DisplayName("Sətir Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LineDescription { get; set; }

        [DisplayName("Valyuta")]
        [ForeignKey("DcCurrency")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CurrencyCode { get; set; }

        [DisplayName("Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; }

        [DisplayName("Kassa")]
        [ForeignKey("DcCurrAcc")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CashRegisterCode { get; set; }

        public virtual TrPaymentHeader TrPaymentHeader { get; set; }
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
