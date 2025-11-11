using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ReportSubQuery), ResourceType = typeof(Resources))]
    public partial class TrReportSubQuery
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ReportSubQuery_Id), ResourceType = typeof(Resources))]
        public int SubQueryId { get; set; }

        [ForeignKey(nameof(DcReport))]
        [Display(Name = nameof(Resources.Entity_ReportSubQuery_ReportId), ResourceType = typeof(Resources))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportSubQuery_Name), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string SubQueryName { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportSubQuery_Text), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string SubQueryText { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual ICollection<TrReportSubQueryRelationColumn> TrReportSubQueryRelationColumns { get; set; }
    }
}
