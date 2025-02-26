using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Hesabat Kateqoriyası")]
    public partial class TrReportCustomization : BaseEntity
    {
        public TrReportCustomization()
        {
        }

        [Key]
        [Display(Name = "Hesabat Fərdiləşdirmə İd")]
        public int ReportCustomizationId { get; set; }

        [Display(Name = "Hesabat Fərdiləşdirmə Adı")]
        public string ReportCustomizationDesc { get; set; }

        [ForeignKey("DcReport")]
        [Display(Name = "Hesabat Id")]
        public int ReportId { get; set; }

        [Display(Name = "Hesabat Dizayn File Adı")]
        public string? ReportDesignFileName { get; set; }

        [Display(Name = "Xarici Filter")]
        public string? ReportFilter { get; set; }

        [ForeignKey("DcCurrAcc")]
        [Display(Name = "Cari Hesab")]
        public string CurrAccCode { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}