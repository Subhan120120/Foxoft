using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models.Entity.RoleClaim
{
    [Display(Name = nameof(Resources.Entity_RoleClaim), ResourceType = typeof(Resources))]
    public partial class TrRoleClaim : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_RoleClaim_Id), ResourceType = typeof(Resources))]
        public int RoleClaimId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [ForeignKey(nameof(DcRole))]
        [Display(Name = nameof(Resources.Entity_RoleClaim_RoleCode), ResourceType = typeof(Resources))]
        public string RoleCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [ForeignKey(nameof(DcClaim))]
        [Display(Name = nameof(Resources.Entity_RoleClaim_ClaimCode), ResourceType = typeof(Resources))]
        public string ClaimCode { get; set; }

        public virtual DcRole DcRole { get; set; }
        public virtual DcClaim DcClaim { get; set; }
    }
}
