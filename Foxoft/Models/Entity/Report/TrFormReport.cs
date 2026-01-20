using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

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


        [ForeignKey("FormCode")]
        public virtual DcForm DcForm { get; set; }

        [ForeignKey("ReportId")]
        public virtual DcReport DcReport { get; set; }
    }
}
