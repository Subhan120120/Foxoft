using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ReportSubQueryRelationColumn), ResourceType = typeof(Resources))]
    public partial class TrReportSubQueryRelationColumn : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ReportSubQueryRelationColumn_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportSubQueryRelationColumn_ParentColumnName), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string ParentColumnName { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportSubQueryRelationColumn_SubColumnName), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string SubColumnName { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportSubQueryRelationColumn_SubQueryId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(TrReportSubQuery))]
        public int SubQueryId { get; set; }

        public virtual TrReportSubQuery TrReportSubQuery { get; set; }
    }
}
