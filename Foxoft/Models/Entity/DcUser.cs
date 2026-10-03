using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_User), ResourceType = typeof(Resources))]
    public partial class DcUser
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_User_UserName), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string UserName { get; set; } = null!;

        [Display(Name = nameof(Resources.Entity_User_Password), ResourceType = typeof(Resources))]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string? Password { get; set; }

        [Display(Name = nameof(Resources.Entity_User_UserDesc), ResourceType = typeof(Resources))]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string? UserDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_User_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Entity_User_RowGuid), ResourceType = typeof(Resources))]
        public Guid RowGuid { get; set; }

        public string? Theme { get; set; }

        public virtual ICollection<TrUserCompany> TrUserCompanies { get; set; } = new List<TrUserCompany>();
    }
}
