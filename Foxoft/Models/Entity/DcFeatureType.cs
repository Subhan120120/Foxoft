using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_FeatureType), ResourceType = typeof(Resources))]
    public partial class DcFeatureType
    {
        public DcFeatureType()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
            TrHierarchyFeatureTypes = new HashSet<TrHierarchyFeatureType>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_FeatureType_Id), ResourceType = typeof(Resources))]
        public int FeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_FeatureType_Name), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string FeatureTypeName { get; set; }

        [Display(Name = nameof(Resources.Entity_FeatureType_Order), ResourceType = typeof(Resources))]
        public int Order { get; set; }

        [Display(Name = nameof(Resources.Entity_FeatureType_Filterable), ResourceType = typeof(Resources))]
        public bool Filterable { get; set; }


        //[JsonIgnore]
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
        //[JsonIgnore]
        public virtual ICollection<TrHierarchyFeatureType> TrHierarchyFeatureTypes { get; set; }
    }
}
