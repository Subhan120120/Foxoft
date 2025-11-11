using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductFeatureLink), ResourceType = typeof(Resources))]
    public partial class TrProductFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(DcProduct))]
        [Display(Name = nameof(Resources.Entity_ProductFeature_ProductCode), ResourceType = typeof(Resources))]
        public string ProductCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcFeatureType))]
        [Display(Name = nameof(Resources.Entity_ProductFeature_FeatureTypeId), ResourceType = typeof(Resources))]
        public int FeatureTypeId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey(nameof(DcFeature))]
        [Display(Name = nameof(Resources.Entity_ProductFeature_FeatureCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string FeatureCode { get; set; }

        [Display(Name = nameof(Resources.Common_Identity), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdentityColumn { get; set; }

        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
        [ForeignKey("FeatureTypeId")]
        public virtual DcFeatureType DcFeatureType { get; set; }
        [ForeignKey("FeatureCode")]
        public virtual DcFeature DcFeature { get; set; }
    }
}
