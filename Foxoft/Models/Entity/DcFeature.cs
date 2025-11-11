using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Feature), ResourceType = typeof(Resources))]
    public partial class DcFeature
    {
        public DcFeature()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
        }

        [Key, Column(Order = 0)]
        [Display(Name = nameof(Resources.Entity_Feature_Code), ResourceType = typeof(Resources))]
        public string FeatureCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcFeatureType))]
        [Display(Name = nameof(Resources.Entity_Feature_TypeId), ResourceType = typeof(Resources))]
        public int FeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_Feature_Desc), ResourceType = typeof(Resources))]
        public string? FeatureDesc { get; set; }

        [ForeignKey(nameof(FeatureTypeId))]
        public virtual DcFeatureType DcFeatureType { get; set; }

        [JsonIgnore]
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
