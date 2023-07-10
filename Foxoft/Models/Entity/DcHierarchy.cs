using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcHierarchy
    {
        public DcHierarchy()
        {
            TrProductHierarchies = new HashSet<TrProductHierarchy>();
            TrHierarchyFeatures = new HashSet<TrHierarchyFeature>();
            DcProducts = new HashSet<DcProduct>();
        }

        [Key]
        [Display(Name = "İyerarxiya Kodu")]
        public string HierarchyCode { get; set; }

        [Display(Name = "İyerarxiya Açıqlaması")]
        public string HierarchyDesc { get; set; }

        [Display(Name = "İyerarxiya Səviyyəsi")]
        public int HierarchyLevel { get; set; }

        [Display(Name = "Üst İyerarxiya Kodu")]
        public string HierarchyParentCode { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }


        public virtual ICollection<TrProductHierarchy> TrProductHierarchies { get; set; }
        public virtual ICollection<TrHierarchyFeature> TrHierarchyFeatures { get; set; }
        public virtual ICollection<DcProduct> DcProducts { get; set; }
    }
}
