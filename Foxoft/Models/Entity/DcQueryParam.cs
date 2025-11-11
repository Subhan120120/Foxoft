using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_QueryParam), ResourceType = typeof(Resources))]
    public partial class DcQueryParam
    {
        public DcQueryParam()
        { }
        [Key]
        [Display(Name = nameof(Resources.Entity_QueryParam_Id), ResourceType = typeof(Resources))]
        public int ParameterId { get; set; }

        [Display(Name = nameof(Resources.Entity_QueryParam_ReportId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReport))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_QueryParam_Name), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ParameterName { get; set; }

        [Display(Name = nameof(Resources.Entity_QueryParam_Type), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ParameterType { get; set; }

        [Display(Name = nameof(Resources.Entity_QueryParam_Value), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ParameterValue { get; set; }

        public virtual DcReport DcReport { get; set; }
    }
}
