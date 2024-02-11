using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcHierarchy : BaseEntity
    {
        public DcHierarchy()
        {
            TrProductHierarchies = new HashSet<TrProductHierarchy>();
            TrHierarchyFeatureTypes = new HashSet<TrHierarchyFeatureType>();
            DcProducts = new HashSet<DcProduct>();
        }

        [Key]
        [Display(Name = "İyerarxiya Kodu")]
        public string HierarchyCode { get; set; }

        [Display(Name = "İyerarxiya Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string HierarchyDesc { get; set; }

        [Display(Name = "İyerarxiya Səviyyəsi")]
        public int HierarchyLevel { get; set; }

        [Display(Name = "Üst İyerarxiya Kodu")]
        public string? HierarchyParentCode { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }

        [Display(Name = "İlbiz")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Slug { get; set; }

        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public virtual ICollection<TrProductHierarchy> TrProductHierarchies { get; set; }
        public virtual ICollection<TrHierarchyFeatureType> TrHierarchyFeatureTypes { get; set; }
        public virtual ICollection<DcProduct> DcProducts { get; set; }
    }
}
