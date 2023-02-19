using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
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
   [Microsoft.EntityFrameworkCore.Index(nameof(InvoiceHeaderId), nameof(ProductCode))]
   public partial class TrInvoiceLine : BaseEntity
   {
      [Key]
      public Guid InvoiceLineId { get; set; }

      [ForeignKey("TrInvoiceHeader")]
      public Guid InvoiceHeaderId { get; set; }

      public Guid? RelatedLineId { get; set; }


      [Display(Name = "Məhsul")]
      [ForeignKey("DcProduct")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ProductCode { get; set; }

      [NotMapped]
      [Display(Name = "Say")]
      [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
      public int Qty
      {
         get
         {
            if (TrInvoiceHeader is not null)
            {
               if (CustomExtensions.ProcessDir(TrInvoiceHeader.ProcessCode) == "In")
                  if (TrInvoiceHeader.IsReturn)
                     return QtyIn * (-1);
                  else return QtyIn;

               else if (CustomExtensions.ProcessDir(TrInvoiceHeader.ProcessCode) == "Out")
                  if (TrInvoiceHeader.IsReturn)
                     return QtyOut * (-1);
                  else return QtyOut;

               else
                  return 0;
            }
            else
               return 0;
         }
         set
         {
            if (TrInvoiceHeader is not null)
            {
               if (CustomExtensions.ProcessDir(TrInvoiceHeader.ProcessCode) == "In")
                  if (TrInvoiceHeader.IsReturn)
                     QtyIn = value * (-1);
                  else QtyIn = value;

               else if (CustomExtensions.ProcessDir(TrInvoiceHeader.ProcessCode) == "Out")
                  if (TrInvoiceHeader.IsReturn)
                     QtyOut = value * (-1);
                  else QtyOut = value;
            }
         }
      }

      [DefaultValue("0")]
      [Display(Name = "Say Giriş")]
      [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
      public int QtyIn { get; set; }

      [DefaultValue("0")]
      [Display(Name = "Say Çıxış")]
      [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
      public int QtyOut { get; set; }

      [Display(Name = "Qiymət")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public decimal Price { get; set; }

      [Display(Name = "Valyuta")]
      [ForeignKey("DcCurrency")]
      public string CurrencyCode { get; set; } = Settings.Default.AppSetting.LocalCurrencyCode;

      [DefaultValue("1")]
      [Display(Name = "Valyuta Kursu")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public float ExchangeRate { get; set; } = 1;

      [Display(Name = "Qiymət (YPV)")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public decimal PriceLoc { get { return Math.Round(Price / (decimal)ExchangeRate, 2); } set { } }

      [Column(TypeName = "money")]
      [Display(Name = "Tutar")]
      public decimal Amount { get { return (QtyIn + QtyOut) * Price; } set { } }

      [Column(TypeName = "money")]
      [Display(Name = "Tutar (YPV)")]
      public decimal AmountLoc { get { return (QtyIn + QtyOut) * PriceLoc; } set { } }

      [DefaultValue("0")]
      [Display(Name = "Endirim")]
      [Column(TypeName = "money")]
      public decimal PosDiscount { get; set; }

      [Column(TypeName = "money")]
      [Display(Name = "Net Tutar")]
      public decimal NetAmount { get { return (QtyIn + QtyOut) * (Price - (Price * PosDiscount / 100)); } set { } }

      [Column(TypeName = "money")]
      [Display(Name = "Net Tutar (YPV)")]
      public decimal NetAmountLoc { get { return (QtyIn + QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)); } set { } }

      [DefaultValue("0")]
      [Column(TypeName = "money")]
      [Display(Name = "Kampaniya Endirimi")]
      public decimal DiscountCampaign { get; set; }

      [DefaultValue("0")]
      [Display(Name = "ƏDV")]
      public float VatRate { get; set; }

      [Display(Name = "Açıqlama")]
      [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
      public string LineDescription { get; set; }

      [Display(Name = "Satıcı")]
      [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
      public string SalesPersonCode { get; set; }

      [Display(Name = "Son Alış Qiy.")]
      public decimal? LastPurchasePrice { get; set; }

      [Display(Name = "Mənfəət")]
      public decimal? Benefit { get { return (decimal?)PriceLoc - LastPurchasePrice; } }

      [NotMapped]
      [Display(Name = "Qalıq")]
      public int Balance { get; set; }


      [NotMapped]
      public int ReturnQty { get; set; }

      [NotMapped]
      public int RemainingQty { get; set; }

      [NotMapped]
      [Display(Name = "Məhsul Adı")]
      public string ProductDesc { get; set; }

      //public string ProductDesc { get { if (!Object.ReferenceEquals(DcProduct, null)) return DcProduct.ProductDesc; else return ""; } set { } }  // gridview da set{} iwlemir

      public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
      public virtual DcProduct DcProduct { get; set; }
      public virtual DcCurrency DcCurrency { get; set; }
   }
}
