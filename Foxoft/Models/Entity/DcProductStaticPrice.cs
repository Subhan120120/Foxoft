using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductStaticPrice), ResourceType = typeof(Resources))]
    public partial class DcProductStaticPrice : BaseEntity
    {
        [Key, Column(Order = 0)]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [ForeignKey(nameof(DcProduct))]
        public string ProductCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcPriceType))]
        [Display(Name = nameof(Resources.Entity_ProductStaticPrice_PriceTypeCode), ResourceType = typeof(Resources))]
        public string PriceTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductStaticPrice_Price), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal Price { get; set; }

        [ForeignKey(nameof(PriceTypeCode))]
        public virtual DcPriceType DcPriceType { get; set; }
        [ForeignKey(nameof(ProductCode))]
        public virtual DcProduct DcProduct { get; set; }
    }
}
