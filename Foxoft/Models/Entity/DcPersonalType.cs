using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PersonalType), ResourceType = typeof(Resources))]
    public partial class DcPersonalType
    {
        public DcPersonalType() { DcCurrAccs = new HashSet<DcCurrAcc>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_PersonalType_Code), ResourceType = typeof(Resources))]
        public byte PersonalTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PersonalType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string PersonalTypeDesc { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
