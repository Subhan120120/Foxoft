using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccFeatureType), ResourceType = typeof(Resources))]
    public partial class DcCurrAccFeatureType
    {
        public DcCurrAccFeatureType()
        {
            TrCurrAccFeatures = new HashSet<TrCurrAccFeature>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccFeatureType_Id), ResourceType = typeof(Resources))]
        public int CurrAccFeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccFeatureType_Name), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string FeatureTypeName { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccFeatureType_Order), ResourceType = typeof(Resources))]
        public int Order { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccFeatureType_Filterable), ResourceType = typeof(Resources))]
        public bool Filterable { get; set; }


        //[JsonIgnore]
        public virtual ICollection<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
    }
}
