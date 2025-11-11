using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductType), ResourceType = typeof(Resources))]
    public partial class DcProductType
    {
        public DcProductType() { DcProducts = new HashSet<DcProduct>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_ProductType_Code), ResourceType = typeof(Resources))]
        public byte ProductTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductTypeDesc { get; set; }

        public virtual ICollection<DcProduct> DcProducts { get; set; }
    }
}
