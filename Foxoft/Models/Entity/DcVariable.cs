using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Variable), ResourceType = typeof(Resources))]
    public partial class DcVariable
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Variable_Code), ResourceType = typeof(Resources))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string VariableCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Variable_Desc), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? VariableDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Variable_LastNumber), ResourceType = typeof(Resources))]
        public int? LastNumber { get; set; }
    }
}
