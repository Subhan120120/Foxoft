using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Index(nameof(ProductTypeCode))]
    [Display(Name = "Məhsul")]
    public partial class DcProduct : BaseEntity
    {
        public DcProduct()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrStaticPrices = new HashSet<DcProductStaticPrice>();
            TrProductFeatures = new HashSet<TrProductFeature>();
            TrProductDiscounts = new HashSet<TrProductDiscount>();
            TrPriceListLines = new HashSet<TrPriceListLine>();
        }

        [Key]
        [Display(Name = "Məhsul Kodu")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductCode { get; set; }

        [Display(Name = "Umico Kodu")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? ProductCode2 { get; set; }

        [Display(Name = "Məhsul Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductDesc { get; set; }

        [Display(Name = "Məhsul Özəlliyi")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? ProductFeature { get; set; }

        [Display(Name = "Məhsul Tipi")]
        [ForeignKey("DcProductType")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} boş buraxila bilmez \n")]
        public byte ProductTypeCode { get; set; }

        [Display(Name = "İyerarxiya Kodu")]
        [ForeignKey("DcHierarchy")]
        public string? HierarchyCode { get; set; }

        [DefaultValue("1")]
        [Display(Name = "POSda İstifadə Et")]
        public bool UsePos { get; set; }

        [Display(Name = "Tanıtım")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? PromotionCode { get; set; }

        [Display(Name = "Tanıtım2")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? PromotionCode2 { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Vergi Dərəcəsi")]
        public double TaxRate { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Pos Endirimi")]
        public double PosDiscount { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }


        const string qiymetler = "Qiymətlər";
        [DefaultValue("0")]
        [Display(Name = "Alış Qiyməti", GroupName = qiymetler, Order = 0)]
        public decimal PurchasePrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Topdan Satış Qiy.", GroupName = qiymetler, Order = 1)]
        //[DisplayName("Toptan Satış Qiyməti")]
        public decimal WholesalePrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Satış Qiyməti", GroupName = qiymetler, Order = 2)]
        public decimal RetailPrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = "İnternetdə İstifadə Et")]
        public bool UseInternet { get; set; }

        [Display(Name = "Şəkil")]
        [StringLength(300, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? ImagePath { get; set; }


        [ForeignKey("DcUnitOfMeasure")]
        [Display(Name = "Default Ölçü Vahidi")]
        public int DefaultUnitOfMeasureId { get; set; }




        [NotMapped]
        [Display(Name = "Qalıq")]
        public int Balance { get; set; }

        [NotMapped]
        [Display(Name = "Maya Dəyəri.")]
        public decimal? ProductCost { get; set; }

        [NotMapped]
        [Display(Name = "Son Satış Qiy.")]
        public decimal? LastSalePrice { get; set; }

        public virtual DcProductType DcProductType { get; set; }

        public virtual SiteProduct SiteProduct { get; set; }
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }
        public virtual DcHierarchy DcHierarchy { get; set; }
        public virtual ProductBalance ProductBalance { get; set; }
        public virtual ICollection<DcSerialNumber> DcSerialNumbers { get; set; }
        public virtual ICollection<DcProductStaticPrice> TrStaticPrices { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
        public virtual ICollection<TrProductDiscount> TrProductDiscounts { get; set; }
        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
        public virtual ICollection<TrProductBarcode> TrProductBarcodes { get; set; }
    }
}
