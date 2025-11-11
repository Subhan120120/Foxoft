using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ReportVariableType), ResourceType = typeof(Resources))]
    public partial class DcReportVariableType
    {
        public DcReportVariableType() { DcReportVariables = new HashSet<DcReportVariable>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_ReportVariableType_Id), ResourceType = typeof(Resources))]
        public byte VariableTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariableType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string VariableTypeDesc { get; set; }

        public virtual ICollection<DcReportVariable> DcReportVariables { get; set; }
    }
}
