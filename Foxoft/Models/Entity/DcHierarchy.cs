using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Hierarchy), ResourceType = typeof(Resources))]
    public partial class DcHierarchy : BaseEntity
    {
        public DcHierarchy()
        {
            TrHierarchyFeatureTypes = new HashSet<TrHierarchyFeatureType>();
            DcProducts = new HashSet<DcProduct>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Hierarchy_Code), ResourceType = typeof(Resources))]
        public string HierarchyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string HierarchyDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Level), ResourceType = typeof(Resources))]
        public int HierarchyLevel { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_ParentCode), ResourceType = typeof(Resources))]
        public string? HierarchyParentCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Order), ResourceType = typeof(Resources))]
        public int Order { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Slug), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Slug { get; set; }

        [Display(Name = nameof(Resources.Entity_Hierarchy_Id), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<TrHierarchyFeatureType> TrHierarchyFeatureTypes { get; set; }
        public virtual ICollection<DcProduct> DcProducts { get; set; }
    }
}
