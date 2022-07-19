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

      [DisplayName("Məhsul Adı")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ProductDesc { get; set; }

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


      const string qiymetler = "Qiymətlər";
      [Display(Name = "Alış Qiyməti", GroupName = qiymetler, Order = 0)]
      [DisplayName("Alış Qiyməti")]
      public decimal PurchasePrice { get; set; }

      [Display(Name = "Topdan Satış Qiy.", GroupName = qiymetler, Order = 1)]
      [DisplayName("Toptan Satış Qiyməti")]
      public decimal WholesalePrice { get; set; }

      [Display(Name = "Satış Qiyməti", GroupName = qiymetler, Order = 2)]
      public decimal RetailPrice { get; set; }


      [DisplayName("İnternetdə İstifadə Et")]
      public bool UseInternet { get; set; }

      //[NotMapped]
      //[DisplayName("Qalıq")]

      [NotMapped]
      [DisplayName("Qalıq")]
      public int Balance { get; set; }
      //public int Balance { get { return TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut); } set { } }

      [NotMapped]
      [DisplayName("Son Alış Qiy.")]
      public decimal? LastPurchasePrice { get; set; }

      [NotMapped]
      [DisplayName("Son Satış Qiy.")]
      public decimal? LastSalePrice { get; set; }

      public virtual DcProductType DcProductType { get; set; }
      public virtual ICollection<TrPrice> TrPrices { get; set; }
      public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
      public virtual ICollection<TrFeature> TrFeature { get; set; }
   }
}
