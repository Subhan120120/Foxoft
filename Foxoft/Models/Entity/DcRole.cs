using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Role), ResourceType = typeof(Resources))]
    public partial class DcRole : BaseEntity
    {
        public DcRole() { TrRoleClaims = new HashSet<TrRoleClaim>(); TrCurrAccRoles = new HashSet<TrCurrAccRole>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_Role_Code), ResourceType = typeof(Resources))]
        public string RoleCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Role_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string RoleDesc { get; set; }

        public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }
        public virtual ICollection<TrCurrAccRole> TrCurrAccRoles { get; set; }
    }
}
