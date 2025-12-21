using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models.ViewModel
{
    public class CountingVM
    {
        public CountingVM()
        {

        }
        public CountingVM(List<TrInvoiceLine> TrInvoiceLines)
        {
        }

        [Key]
        public Guid InvoiceLineId { get; set; }

        public Guid InvoiceHeaderId { get; set; }

        public Guid? RelatedLineId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_ProductCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_Qty), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.##}")]
        public decimal Qty { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_QtyIn), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public decimal QtyIn { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_QtyOut), ResourceType = typeof(Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public decimal QtyOut { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_UnitOfMeasureId), ResourceType = typeof(Resources))]
        public int? UnitOfMeasureId { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_InvoiceLine_Price), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal Price { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_CurrencyCode), ResourceType = typeof(Resources))]
        public string CurrencyCode { get; set; } = Settings.Default.AppSetting.LocalCurrencyCode;

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

        [Display(Name = nameof(Resources.Entity_InvoiceLine_SerialNumberCode), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? SerialNumberCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLine_WorkerCode), ResourceType = typeof(Resources))]
        public string? WorkerCode { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Common_Balance), ResourceType = typeof(Resources))]
        public decimal Balance { get; set; }

        [Display(Name = nameof(Resources.Entity_CountingVM_Difference), ResourceType = typeof(Resources))]
        public decimal Difference { get; set; }

    }
}
