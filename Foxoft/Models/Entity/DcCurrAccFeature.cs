using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccFeature), ResourceType = typeof(Resources))]
    public partial class DcCurrAccFeature
    {
        public DcCurrAccFeature()
        {
            TrCurrAccFeatures = new HashSet<TrCurrAccFeature>();
        }

        [Key, Column(Order = 0)]
        [Display(Name = nameof(Resources.Entity_CurrAccFeature_Code), ResourceType = typeof(Resources))]
        public string CurrAccFeatureCode { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = nameof(Resources.Entity_CurrAccFeature_TypeId), ResourceType = typeof(Resources))]
        public int CurrAccFeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccFeature_Desc), ResourceType = typeof(Resources))]
        public string? FeatureDesc { get; set; }

        [ForeignKey(nameof(CurrAccFeatureTypeId))]
        public virtual DcCurrAccFeatureType DcCurrAccFeatureType { get; set; }

        public virtual ICollection<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
    }
}
