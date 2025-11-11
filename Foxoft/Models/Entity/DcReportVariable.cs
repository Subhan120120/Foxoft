using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ReportVariable), ResourceType = typeof(Resources))]
    public partial class DcReportVariable
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ReportVariable_Id), ResourceType = typeof(Resources))]
        public int VariableId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_ReportId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReport))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_TypeId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReportVariableType))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public byte VariableTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_Property), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string VariableProperty { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_Value), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string VariableValue { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_Operator), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? VariableOperator { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_ValueType), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string VariableValueType { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportVariable_Representative), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string Representative { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual DcReportVariableType DcReportVariableType { get; set; }
    }
}
