using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Hesabat Kateqoriyası")]
    public partial class DcReportCategory : BaseEntity
    {
        public DcReportCategory()
        {
            DcReports = new HashSet<DcReport>();
        }

        [Key]
        [Display(Name = "Hesabat Kateqoriyası")]
        public int ReportCategoryId { get; set; }

        [Display(Name = "Hesabat Kateqoriya Adı")]
        [Required(ErrorMessage = "Hesabat Kateqoriya Adı tələb olunur.")]
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        public string ReportCategoryDesc { get; set; }

        public virtual ICollection<DcReport> DcReports { get; set; }
    }
}