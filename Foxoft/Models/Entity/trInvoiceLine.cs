using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Index(nameof(InvoiceHeaderId), nameof(ProductCode))]
    [Display(Name = nameof(Resources.Entity_InvoiceLine), ResourceType = typeof(Resources))]
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

        [ForeignKey(nameof(TrInvoiceHeader))]
        public Guid InvoiceHeaderId { get; set; }

        [ForeignKey(nameof(RelatedLine))]
        public Guid? RelatedLineId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_Qty), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
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
        [Display(Name = nameof(Resources.Entity_InvoiceLine_QtyIn), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public decimal QtyIn { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_QtyOut), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public decimal QtyOut { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_UnitOfMeasureId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcUnitOfMeasure))]
        public int? UnitOfMeasureId { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_Price), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal Price { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_CurrencyCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrency))]
        public string CurrencyCode { get; set; } = Properties.Settings.Default.AppSetting.LocalCurrencyCode;

        [DefaultValue("1")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_ExchangeRate), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public float ExchangeRate { get; set; } = 1;

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_PriceLoc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal PriceLoc { get { return Math.Round(Price / (decimal)ExchangeRate, 4); } set { } }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_Amount), ResourceType = typeof(Resources))]
        public decimal Amount { get { return (QtyIn + QtyOut) * Price; } set { } }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_AmountLoc), ResourceType = typeof(Resources))]
        public decimal AmountLoc { get { return (QtyIn + QtyOut) * PriceLoc; } set { } }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_PosDiscount), ResourceType = typeof(Resources))]
        public decimal PosDiscount { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_NetAmount), ResourceType = typeof(Resources))]
        public decimal NetAmount { get { return (QtyIn + QtyOut) * Price * (1 - PosDiscount / 100); } set { } }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_NetAmountLoc), ResourceType = typeof(Resources))]
        public decimal NetAmountLoc { get { return (QtyIn + QtyOut) * PriceLoc * (1 - PosDiscount / 100); } set { } }

        [DefaultValue("0")]
        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_DiscountCampaign), ResourceType = typeof(Resources))]
        public decimal DiscountCampaign { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_VatRate), ResourceType = typeof(Resources))]
        public float VatRate { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_LineDescription), ResourceType = typeof(Resources))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? LineDescription { get; set; }

        [ForeignKey(nameof(DcSerialNumber))]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_SerialNumberCode), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? SerialNumberCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_SalesPersonCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrAcc))]
        public string? SalesPersonCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_WorkerCode), ResourceType = typeof(Resources))]
        public string? WorkerCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_ProductCost), ResourceType = typeof(Resources))]
        public decimal? ProductCost { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_Benefit), ResourceType = typeof(Resources))]
        public decimal? Benefit => PriceLoc * (1 - PosDiscount / 100) - ProductCost;

        [Display(Name = nameof(Resources.Entity_InvoiceLine_TotalBenefit), ResourceType = typeof(Resources))]
        public decimal? TotalBenefit => NetAmountLoc - ((QtyIn + QtyOut) * ProductCost);

        [NotMapped]
        [Display(Name = nameof(Resources.Common_Balance), ResourceType = typeof(Resources))]
        public decimal Balance { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_ReturnQty), ResourceType = typeof(Resources))]
        public decimal ReturnQty { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_RemainingQty), ResourceType = typeof(Resources))]
        public decimal RemainingQty { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_ProductDesc), ResourceType = typeof(Resources))]
        public string ProductDesc { get; set; }

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
