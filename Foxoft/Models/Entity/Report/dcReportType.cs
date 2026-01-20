using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models.Entity.Report
{
    [Display(Name = nameof(Resources.Entity_ReportType), ResourceType = typeof(Resources))]
    public partial class DcReportType
    {
        public DcReportType() { DcReports = new HashSet<DcReport>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_ReportType_Id), ResourceType = typeof(Resources))]
        public byte ReportTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_ReportType_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ReportTypeDesc { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Common_RowGuid), ResourceType = typeof(Resources))]
        public Guid RowGuid { get; set; }

        public virtual ICollection<DcReport> DcReports { get; set; }
    }
}
