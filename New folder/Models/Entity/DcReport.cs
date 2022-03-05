using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcReport : BaseEntity
    {
        [Key]
        [DisplayName("Report ID")]
        public Guid Id { get; set; }

        [DisplayName("Hesabat Adı")]
        public string ReportName { get; set; }


        [DisplayName("Hesabat Sorğusu")]
        public string ReportQuery { get; set; }

        [DisplayName("Hesabat Dizaynı")]
        public string ReportLayout { get; set; }

        [DisplayName("Hesabat Filteri")]
        public string ReportFilter { get; set; }

    }
}
