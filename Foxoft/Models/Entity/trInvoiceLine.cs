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
    [Index(nameof(InvoiceHeaderId), nameof(ProductCode))]
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

        [NotMapped]
        [DisplayName("Say")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int Qty
        {
            get
            {
                if (!Object.ReferenceEquals(TrInvoiceHeader, null))
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
                        return 5041;
                }
                else
                    return 5042;
            }
            set
            {
                if (!Object.ReferenceEquals(TrInvoiceHeader, null))
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

        [DisplayName("Say Giriş")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int QtyIn { get; set; }

        [DisplayName("Say Çıxış")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int QtyOut { get; set; }

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public double Price { get; set; }

        [DisplayName("Valyuta")]
        [ForeignKey("DcCurrency")]
        public string CurrencyCode { get; set; } = "USD";

        [DefaultValue("1.703")]
        [DisplayName("Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; }

        [DisplayName("Qiymət (AZN)")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public double PriceLoc { get { return Price * ExchangeRate; } set { } }

        [Column(TypeName = "money")]
        [DisplayName("Tutar")]
        public decimal Amount { get { return (QtyIn + QtyOut) * (decimal)Price; } set { } }

        [Column(TypeName = "money")]
        [DisplayName("Tutar (AZN)")]
        public decimal AmountLoc { get { return (QtyIn + QtyOut) * (decimal)PriceLoc; } set { } }

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Column(TypeName = "money")]
        public decimal PosDiscount { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Net Tutar")]
        public decimal NetAmount { get { return (QtyIn + QtyOut) * (decimal)Price; } set { } }

        [Column(TypeName = "money")]
        [DisplayName("Net Tutar (AZN)")]
        public decimal NetAmountLoc { get { return (QtyIn + QtyOut) * (decimal)PriceLoc; } set { } }

        [Column(TypeName = "money")]
        [DisplayName("Kampaniya Endirimi")]
        public decimal DiscountCampaign { get; set; }

        [DisplayName("ƏDV")]
        public float VatRate { get; set; }

        [DisplayName("Açıqlama")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string LineDescription { get; set; }

        [DisplayName("Satıcı")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string SalesPersonCode { get; set; }



        [NotMapped]
        public int ReturnQty { get; set; }

        [NotMapped]
        public int RemainingQty { get; set; }

        [NotMapped]
        [DisplayName("Məhsul Adı")]
        public string ProductDesc { get; set; }

        //public string ProductDesc { get { if (!Object.ReferenceEquals(DcProduct, null)) return DcProduct.ProductDesc; else return ""; } set { } }  // gridview da set{} iwlemir

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
