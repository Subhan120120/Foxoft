using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;

namespace Foxoft.Models.Entity.Report
{
    [Display(Name = nameof(Resources.Entity_Report), ResourceType = typeof(Resources))]
    public partial class DcReport : BaseEntity
    {
        public DcReport()
        {
            DcReportVariables = new HashSet<DcReportVariable>();
            TrClaimReports = new HashSet<TrClaimReport>();
            TrFormReports = new HashSet<TrFormReport>();
            TrReportCustomizations = new HashSet<TrReportCustomization>();
            TrReportSubQueries = new HashSet<TrReportSubQuery>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Report_Id), ResourceType = typeof(Resources))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_Name), ResourceType = typeof(Resources))]
        public string? ReportName { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_Query), ResourceType = typeof(Resources))]
        public string? ReportQuery { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_TypeId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReportType))]
        public byte ReportTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_Layout), ResourceType = typeof(Resources))]
        public string? ReportLayout { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_Filter), ResourceType = typeof(Resources))]
        public string? ReportFilter { get; set; }

        [Display(Name = nameof(Resources.Entity_Report_CategoryId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcReportCategory))]
        public int? ReportCategoryId { get; set; }

        public virtual DcReportType DcReportType { get; set; }
        public virtual DcReportCategory DcReportCategory { get; set; }
        public virtual ICollection<DcReportVariable> DcReportVariables { get; set; }
        public virtual ICollection<TrClaimReport> TrClaimReports { get; set; }
        public virtual ICollection<TrFormReport> TrFormReports { get; set; }
        public virtual ICollection<TrReportSubQuery> TrReportSubQueries { get; set; }
        public virtual ICollection<TrReportCustomization> TrReportCustomizations { get; set; }
    }
}
