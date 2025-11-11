using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ClaimReport), ResourceType = typeof(Resources))]
    public partial class TrClaimReport : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ClaimReport_Id), ResourceType = typeof(Resources))]
        public int ClaimReportId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [Display(Name = nameof(Resources.Entity_ClaimReport_ClaimCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcClaim))]
        public string ClaimCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [Display(Name = nameof(Resources.Entity_ClaimReport_ReportId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReport))]
        public int ReportId { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual DcClaim DcClaim { get; set; }
    }
}
