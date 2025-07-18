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
    [Display(Name = "Faktura Detalı")]
    public partial class TrInvoiceLine : BaseEntity
    {
        private decimal ConvertToBasicUOM(decimal qty)
        {
            decimal multiplier = 1;
            DcUnitOfMeasure currentUOM = this.DcUnitOfMeasure;

            while (currentUOM != null && !currentUOM.IsBasic)
            {
                multiplier *= currentUOM.ConversionRate;
                currentUOM = currentUOM.ParentUnitOfMeasure;
            }

            return qty * multiplier;
        }

        private decimal ConvertFromBasicUOM(decimal qtyIn)
        {
            decimal divider = 1;
            DcUnitOfMeasure currentUOM = this.DcUnitOfMeasure;

            while (currentUOM != null && !currentUOM.IsBasic)
            {
                divider *= currentUOM.ConversionRate;
                currentUOM = currentUOM.ParentUnitOfMeasure;
            }

            return divider == 0 ? qtyIn : qtyIn / divider;
        }


        [Key]
        public Guid InvoiceLineId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        public Guid InvoiceHeaderId { get; set; }

        [ForeignKey("RelatedLine")]
        public Guid? RelatedLineId { get; set; }

        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductCode { get; set; }

        [NotMapped]
        [Display(Name = "Say")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.##}")]
        public decimal Qty
        {
            get
            {
                if (TrInvoiceHeader == null)
                    return 0;

                bool isIn = (bool)CustomExtensions.DirectionIsIn(TrInvoiceHeader.ProcessCode);
                bool isReturn = TrInvoiceHeader.IsReturn;

                decimal qty = isIn
                    ? (isReturn ? -QtyIn : QtyIn)
                    : (isReturn ? -QtyOut : QtyOut);

                return ConvertFromBasicUOM(qty);
            }
            set
            {
                if (TrInvoiceHeader == null)
                    return;

                bool isIn = (bool)CustomExtensions.DirectionIsIn(TrInvoiceHeader.ProcessCode);
                bool isReturn = TrInvoiceHeader.IsReturn;

                decimal basicUOMQty = ConvertToBasicUOM(value);

                if (isIn)
                    QtyIn = isReturn ? -basicUOMQty : basicUOMQty;
                else
                    QtyOut = isReturn ? -basicUOMQty : basicUOMQty;
            }
        }

        [DefaultValue("0")]
        [Display(Name = "Say Giriş")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public decimal QtyIn { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Say Çıxış")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public decimal QtyOut { get; set; }

        //[DefaultValue(1)]
        [Display(Name = "Ölçü Vahidi")]
        [ForeignKey("DcUnitOfMeasure")]
        public int? UnitOfMeasureId { get; set; }

        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Price { get; set; }

        [Display(Name = "Valyuta")]
        [ForeignKey("DcCurrency")]
        public string CurrencyCode { get; set; } = Properties.Settings.Default.AppSetting.LocalCurrencyCode;

        [DefaultValue("1")]
        [Display(Name = "Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; } = 1;

        [Display(Name = "Qiymət (YPV)")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal PriceLoc { get { return Math.Round(Price / (decimal)ExchangeRate, 4); } set { } }

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
        public decimal NetAmount { get { return (QtyIn + QtyOut) * Price * (1 - PosDiscount / 100); } set { } }

        [Column(TypeName = "money")]
        [Display(Name = "Net Tutar (YPV)")]
        public decimal NetAmountLoc { get { return (QtyIn + QtyOut) * PriceLoc * (1 - PosDiscount / 100); } set { } }

        [DefaultValue("0")]
        [Column(TypeName = "money")]
        [Display(Name = "Kampaniya Endirimi")]
        public decimal DiscountCampaign { get; set; }

        [DefaultValue("0")]
        [Display(Name = "ƏDV")]
        public float VatRate { get; set; }

        [Display(Name = "Sətir Açıqlaması")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string? LineDescription { get; set; }

        [ForeignKey("DcSerialNumber")]
        [Display(Name = "Seria Nömrəsi")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string? SerialNumberCode { get; set; }

        [Display(Name = "Satıcı")]
        [ForeignKey("DcCurrAcc")]
        public string? SalesPersonCode { get; set; }

        [Display(Name = "Usta")]
        public string? WorkerCode { get; set; }

        [Display(Name = "Maya Dəyəri")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ProductCost { get; set; }

        [Display(Name = "Mənfəət")]
        public decimal? Benefit => PriceLoc * (1 - PosDiscount / 100) - ProductCost;

        [Display(Name = "Toplam Mənfəət")]
        public decimal? TotalBenefit => NetAmountLoc - ((QtyIn + QtyOut) * ProductCost);

        [NotMapped]
        [Display(Name = "Qalıq")]
        public decimal Balance { get; set; }

        [NotMapped]
        public decimal ReturnQty { get; set; }

        [NotMapped]
        public decimal RemainingQty { get; set; }

        [NotMapped]
        [Display(Name = "Məhsul Adı")]
        public string ProductDesc { get; set; }

        //public string ProductDesc { get { if (!Object.ReferenceEquals(DcProduct, null)) return DcProduct.ProductDesc; else return ""; } set { } }  // gridview da set{} iwlemir

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
        public virtual DcSerialNumber DcSerialNumber { get; set; }
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual trInvoiceLineExt TrInvoiceLineExt { get; set; }

        public virtual TrInvoiceLine RelatedLine { get; set; } // Navigation property to the related line
        public virtual ICollection<TrInvoiceLine> InverseRelatedLines { get; set; } // Navigation property for the inverse relationship

    }
}
