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
    public partial class DcQueryParam
    {
        public DcQueryParam()
        {
        }

        [Key]
        [Display(Name = "Parametr Id")]
        public int ParameterId { get; set; }

        [Display(Name = "Sorğu Id")]
        [ForeignKey("DcReportQuery")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int QueryId { get; set; }

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ColumnName { get; set; }

        [Display(Name = "Ana Kolon Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ParentColumnName { get; set; }

        //[Display(Name = "Dəyəri")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        //[StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        //public string ParameterValue { get; set; }

        public virtual DcReportSubQuery DcReportSubQuery { get; set; }

    }
}