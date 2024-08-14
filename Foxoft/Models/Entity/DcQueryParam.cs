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
    [Display(Name = "Sorğu Parametri")]
    public partial class DcQueryParam
    {
        public DcQueryParam()
        { }

        [Key]
        [Display(Name = "Parametr Id")]
        public int ParameterId { get; set; }

        [Display(Name = "Sorğu Id")]
        [ForeignKey("DcReport")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int ReportId { get; set; }

        [Display(Name = "Parametr Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ParameterName { get; set; }

        [Display(Name = "Parametr Tipi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ParameterType { get; set; }

        [Display(Name = "Parametr Dəyəri")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ParameterValue { get; set; }

        public virtual DcReport DcReport { get; set; }

    }
}