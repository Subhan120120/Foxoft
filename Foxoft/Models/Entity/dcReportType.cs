using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class DcReportType
    {
        public DcReportType()
        {
            DcReports = new HashSet<DcReport>();
        }

        [Key]
        [Display(Name = "Hesabat Tipi Id")]
        public byte ReportTypeId { get; set; }

        [Display(Name = "Hesabat Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ReportTypeDesc { get; set; }

        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Guid Id")]
        public Guid RowGuid { get; set; }

        public virtual ICollection<DcReport> DcReports { get; set; }
    }
}
