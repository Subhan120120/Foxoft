using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcHierarchyName
    {
        public DcHierarchyName()
        {
        }

        [Key]
        [Display(Name = "Hierarchy Id")]
        public int HierarchyId { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode01 { get; set; }
        public string HierarchyLevelDesc01 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode02 { get; set; }
        public string HierarchyLevelDesc02 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode03 { get; set; }
        public string HierarchyLevelDesc03 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode04 { get; set; }
        public string HierarchyLevelDesc04 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode05 { get; set; }
        public string HierarchyLevelDesc05 { get; set; }

        //[ForeignKey("FeatureTypeId")]
        //public virtual DcFeatureType DcFeatureType { get; set; }
        //public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
