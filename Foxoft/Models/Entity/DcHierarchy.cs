using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcHierarchy
    {
        public DcHierarchy()
        {
        }

        [Key]
        [Display(Name = "Hierarchy Id")]
        public int HierarchyId { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode01 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode02 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode03 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode04 { get; set; }

        [DefaultValue("0")]
        public int HierarchyLevelCode05 { get; set; }

        //[ForeignKey("FeatureTypeId")]
        //public virtual DcFeatureType DcFeatureType { get; set; }
        //public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
