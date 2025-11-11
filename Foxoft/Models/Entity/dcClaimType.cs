using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ClaimType), ResourceType = typeof(Resources))]
    public partial class DcClaimType
    {
        public DcClaimType()
        {
            DcClaims = new HashSet<DcClaim>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_ClaimType_Id), ResourceType = typeof(Resources))]
        public byte ClaimTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_ClaimType_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(50,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string ClaimTypeDesc { get; set; }

        public virtual ICollection<DcClaim> DcClaims { get; set; }
    }
}
