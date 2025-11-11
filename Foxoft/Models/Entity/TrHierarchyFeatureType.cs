using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_HierarchyFeatureType), ResourceType = typeof(Resources))]
    public partial class TrHierarchyFeatureType
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(DcHierarchy))]
        [Display(Name = nameof(Resources.Entity_Hierarchy_Code), ResourceType = typeof(Resources))]
        public string HierarchyCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcFeatureType))]
        [Display(Name = nameof(Resources.Entity_FeatureType_Id), ResourceType = typeof(Resources))]
        public int FeatureTypeId { get; set; }

        [ForeignKey(nameof(HierarchyCode))]
        public virtual DcHierarchy DcHierarchy { get; set; }
        [ForeignKey(nameof(FeatureTypeId))]
        public virtual DcFeatureType DcFeatureType { get; set; }
    }
}
