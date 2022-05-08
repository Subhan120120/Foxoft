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
    public partial class TrInvoiceLine : BaseEntity
    {
        [Key]
        public Guid InvoiceLineId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        public Guid InvoiceHeaderId { get; set; }

        public Guid? RelatedLineId { get; set; }


        [DisplayName("Məhsul")]
        [ForeignKey("DcProduct")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductCode { get; set; }

        [DisplayName("Say Giriş")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int QtyIn { get; set; }

        [DisplayName("Say Çıxış")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int QtyOut { get; set; }

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public double Price { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Tutar")]
        public decimal Amount { get; set; }

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Column(TypeName = "money")]
        public decimal PosDiscount { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Kampaniya Endirimi")]
        public decimal DiscountCampaign { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Net Tutar")]
        public decimal NetAmount { get; set; }

        [DisplayName("ƏDV")]
        public float VatRate { get; set; }

        [DisplayName("Açıqlama")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string LineDescription { get; set; }

        [DisplayName("Satıcı")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string SalesPersonCode { get; set; }

        [DisplayName("Valyuta")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string CurrencyCode { get; set; }

        [DisplayName("Valyuta kursu")]
        public double ExchangeRate { get; set; }

        [NotMapped]
        public int ReturnQty { get; set; }

        [NotMapped]
        public int RemainingQty { get; set; }

        [NotMapped]
        [DisplayName("Məhsul Adı")]
        public string ProductDescription { get; set; }


        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
    }
}
