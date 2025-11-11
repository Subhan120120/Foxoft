using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ClaimCategory), ResourceType = typeof(Resources))]
    public partial class DcClaimCategory : BaseEntity
    {
        public DcClaimCategory()
        {
            DcClaims = new HashSet<DcClaim>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_ClaimCategory_Id), ResourceType = typeof(Resources))]
        public int CategoryId { get; set; }

        [Display(Name = nameof(Resources.Entity_ClaimCategory_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string CategoryDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_ClaimCategory_Level), ResourceType = typeof(Resources))]
        public int CategoryLevel { get; set; }

        [Display(Name = nameof(Resources.Entity_ClaimCategory_ParentId), ResourceType = typeof(Resources))]
        public int? CategoryParentId { get; set; }

        [Display(Name = nameof(Resources.Entity_ClaimCategory_Order), ResourceType = typeof(Resources))]
        public int Order { get; set; }

        public virtual ICollection<DcClaim> DcClaims { get; set; }
    }
}
