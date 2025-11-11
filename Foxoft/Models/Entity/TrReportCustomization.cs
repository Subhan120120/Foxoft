using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ReportCustomization), ResourceType = typeof(Resources))]
    public partial class TrReportCustomization : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ReportCustomization_Id), ResourceType = typeof(Resources))]
        public int ReportCustomizationId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportCustomization_Desc), ResourceType = typeof(Resources))]
        public string ReportCustomizationDesc { get; set; }

        [ForeignKey(nameof(DcReport))]
        [Display(Name = nameof(Resources.Entity_ReportCustomization_ReportId), ResourceType = typeof(Resources))]
        public int ReportId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportCustomization_DesignFileName), ResourceType = typeof(Resources))]
        public string? ReportDesignFileName { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportCustomization_Filter), ResourceType = typeof(Resources))]
        public string? ReportFilter { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_ReportCustomization_CurrAccCode), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}
