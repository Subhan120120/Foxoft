using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Hesabat")]
    public partial class DcReport : BaseEntity
    {
        public DcReport()
        {
            DcReportVariables = new HashSet<DcReportVariable>();
            TrClaimReports = new HashSet<TrClaimReport>();
            TrFormReports = new HashSet<TrFormReport>();
            //DcQueryParams = new HashSet<DcQueryParam>();
            TrReportSubQueries = new HashSet<TrReportSubQuery>();
        }

        [Key]
        [Display(Name = "Hesabat Id")]
        public int ReportId { get; set; }

        [Display(Name = "Hesabat Adı")]
        public string? ReportName { get; set; }

        [Display(Name = "Hesabat Sorğusu")]
        public string? ReportQuery { get; set; }

        [Display(Name = "Hesabat Tipi")]
        [ForeignKey("DcReportType")]
        public byte ReportTypeId { get; set; }

        [Display(Name = "Hesabat Dizaynı")]
        public string? ReportLayout { get; set; }

        [Display(Name = "Xarici Filter")]
        public string? ReportFilter { get; set; }

        public virtual DcReportType DcReportType { get; set; }
        //public virtual ICollection<DcQueryParam> DcQueryParams { get; set; }
        public virtual ICollection<DcReportVariable> DcReportVariables { get; set; }
        public virtual ICollection<TrClaimReport> TrClaimReports { get; set; }
        public virtual ICollection<TrFormReport> TrFormReports { get; set; }
        public virtual ICollection<TrReportSubQuery> TrReportSubQueries { get; set; }

    }
}
