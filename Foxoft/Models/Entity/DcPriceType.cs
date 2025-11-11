using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PriceType), ResourceType = typeof(Resources))]
    public partial class DcPriceType
    {
        public DcPriceType()
        {
            TrPriceListHeaders = new HashSet<TrPriceListHeader>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_PriceType_Code), ResourceType = typeof(Resources))]
        public string PriceTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PriceTypeDesc { get; set; }

        public virtual ICollection<TrPriceListHeader> TrPriceListHeaders { get; set; }
        public virtual ICollection<DcProductStaticPrice> TrStaticPrices { get; set; }
    }
}
