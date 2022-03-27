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
    public partial class DcProduct : BaseEntity
    {
        public DcProduct()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrPrices = new HashSet<TrPrice>();
        }

        [Key]
        [DisplayName("Məhsul Kodu")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductCode { get; set; }

        [DisplayName("Barkod")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Barcode { get; set; }

        [DisplayName("Məhsul Tipi")]
        [ForeignKey("DcProductType")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public byte ProductTypeCode { get; set; }

        [DisplayName("POSda İstifadə Et")]
        public bool UsePos { get; set; }

        [DisplayName("Tanıtım")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PromotionCode { get; set; }

        [DisplayName("Tanıtım2")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PromotionCode2 { get; set; }

        [DisplayName("Vergi Dərəcəsi")]
        public double TaxRate { get; set; }

        [DisplayName("Pos Endirimi")]
        public double PosDiscount { get; set; }

        [DisplayName("Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [DisplayName("Satış Qiyməti")]
        public double RetailPrice { get; set; }

        [DisplayName("Alış Qiyməti")]
        public double PurchasePrice { get; set; }

        [DisplayName("Toptan Satış Qiyməti")]
        public double WholesalePrice { get; set; }

        [DisplayName("İnternetdə İstifadə Et")]
        public bool UseInternet { get; set; }

        [DisplayName("Məhsul Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductDescription { get; set; }

        public virtual DcProductType DcProductType { get; set; }
        public virtual ICollection<TrPrice> TrPrices { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrFeature> TrFeature { get; set; }
    }
}
