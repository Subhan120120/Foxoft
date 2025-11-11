using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PriceListLine), ResourceType = typeof(Resources))]
    public partial class TrPriceListLine : BaseEntity
    {
        [Key]
        public Guid PriceListLineId { get; set; }

        [ForeignKey(nameof(TrPriceListHeader))]
        public Guid PriceListHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListLine_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListLine_Price), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal Price { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListLine_CurrencyCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrency))]
        public string CurrencyCode { get; set; } = Properties.Settings.Default.AppSetting.LocalCurrencyCode;

        [Display(Name = nameof(Resources.Entity_PriceListLine_LineDescription), ResourceType = typeof(Resources))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string LineDescription { get; set; }

        public virtual TrPriceListHeader TrPriceListHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
