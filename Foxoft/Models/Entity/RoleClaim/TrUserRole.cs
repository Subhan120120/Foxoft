using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models.Entity.RoleClaim
{
    [Table("TrUserRoles")]
    [Display(Name = nameof(Resources.Entity_UserRole), ResourceType = typeof(Resources))]
    public partial class TrUserRole : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = nameof(Resources.Entity_UserRole_Id), ResourceType = typeof(Resources))]
        public int UserRoleId { get; set; }

        [Display(Name = nameof(Resources.Entity_UserRole_UserName), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string UserName { get; set; } = null!;

        [Display(Name = nameof(Resources.Entity_UserRole_RoleCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcRole))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string RoleCode { get; set; } = null!;

        public virtual DcRole DcRole { get; set; } = null!;
    }
}
