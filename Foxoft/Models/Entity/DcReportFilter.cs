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
        [Display(Name = "Filter ID")]
        public int FilterId { get; set; }

        [Display(Name = "Filter String")]
        [ForeignKey("DcReport")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int ReportId { get; set; }

        [Display(Name = "Property")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterProperty { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterValue { get; set; }

        [Display(Name = "Filter String")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FilterOperatorType { get; set; }

        [Display(Name = "Filter Təmsilci")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Representative { get; set; }

        public virtual DcReport DcReport { get; set; }

    }
}
