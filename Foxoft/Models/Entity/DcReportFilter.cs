using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class DcReportFilter
    {
        public DcReportFilter()
        {
        }

        [Key]
        [DisplayName("Filter ID")]
        public int FilterId { get; set; }

        [DisplayName("Filter String")]
        [ForeignKey("DcReport")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int ReportId { get; set; }

        [DisplayName("Property")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterProperty { get; set; }

        [DisplayName("Value")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterValue { get; set; }

        [DisplayName("Filter String")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterOperatorType { get; set; }

        [DisplayName("Filter Təmsilci")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Representative { get; set; }

        public virtual DcReport DcReport { get; set; }

    }
}
