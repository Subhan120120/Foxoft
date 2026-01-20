using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models.Entity.Report
{
    [Display(Name = nameof(Resources.Entity_ReportCategory), ResourceType = typeof(Resources))]
    public partial class DcReportCategory : BaseEntity
    {
        public DcReportCategory() { DcReports = new HashSet<DcReport>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_ReportCategory_Id), ResourceType = typeof(Resources))]
        public int ReportCategoryId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportCategory_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string ReportCategoryDesc { get; set; }

        public virtual ICollection<DcReport> DcReports { get; set; }
    }
}
