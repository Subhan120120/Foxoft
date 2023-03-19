using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcReport : BaseEntity
    {
        public DcReport()
        {
            DcReportFilters = new HashSet<DcReportFilter>();
        }

        [Key]
        [Display(Name = "Report ID")]
        public int ReportId { get; set; }

        [Display(Name = "Hesabat Adı")]
        public string ReportName { get; set; }

        [Display(Name = "Hesabat Sorğusu")]
        public string ReportQuery { get; set; }

        [Display(Name = "Hesabat Tipi")]
        [ForeignKey("DcReportType")]
        public byte ReportTypeId { get; set; }

        [Display(Name = "Hesabat Dizaynı")]
        public string ReportLayout { get; set; }

        [Display(Name = "Xarici Filter")]
        public string ReportFilter { get; set; }

        public virtual ICollection<DcReportFilter> DcReportFilters { get; set; }
        public virtual DcReportType DcReportType { get; set; }

    }
}
