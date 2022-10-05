using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcReport : BaseEntity
    {
        public DcReport()
        {
            DcReportFilters = new HashSet<DcReportFilter>();
        }

        [Key]
        [DisplayName("Report ID")]
        public int ReportId { get; set; }

        [DisplayName("Hesabat Adı")]
        public string ReportName { get; set; }

        [DisplayName("Hesabat Sorğusu")]
        public string ReportQuery { get; set; }

        [DisplayName("Hesabat Dizaynı")]
        public string ReportLayout { get; set; }

        [DisplayName("Xarici Filter")]
        public string ReportFilter { get; set; }

        public virtual ICollection<DcReportFilter> DcReportFilters { get; set; }

    }
}
