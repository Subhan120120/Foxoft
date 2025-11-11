using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Terminal), ResourceType = typeof(Resources))]
    public partial class DcTerminal : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Terminal_Id), ResourceType = typeof(Resources))]
        public int TerminalId { get; set; }

        [Display(Name = nameof(Resources.Entity_Terminal_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string TerminalDesc { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Common_RowGuid), ResourceType = typeof(Resources))]
        public Guid? RowGuid { get; set; }

        [Display(Name = nameof(Resources.Entity_Terminal_TouchUIMode), ResourceType = typeof(Resources))]
        public bool TouchUIMode { get; set; }

        [Display(Name = nameof(Resources.Entity_Terminal_TouchScaleFactor), ResourceType = typeof(Resources))]
        public int TouchScaleFactor { get; set; }
    }
}
