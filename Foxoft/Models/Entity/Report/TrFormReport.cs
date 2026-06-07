using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models.Entity.Report
{
    [Display(Name = nameof(Resources.Entity_FormReport), ResourceType = typeof(Resources))]
    public partial class TrFormReport
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(DcForm))]
        [Display(Name = nameof(Resources.Entity_FormReport_FormCode), ResourceType = typeof(Resources))]
        public string FormCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcReport))]
        [Display(Name = nameof(Resources.Entity_FormReport_ReportId), ResourceType = typeof(Resources))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_FormReport_Shortcut), ResourceType = typeof(Resources))]
        public string? Shortcut { get; set; }

        [Display(Name = nameof(Resources.Entity_FormReport_UseReportAs), ResourceType = typeof(Resources))]
        [DefaultValue(UseReportAs.OpenPreview)]
        public UseReportAs UseReportAs { get; set; } = UseReportAs.OpenPreview;

        [ForeignKey("FormCode")]
        public virtual DcForm DcForm { get; set; }

        [ForeignKey("ReportId")]

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual DcReport DcReport { get; set; }
    }
}
