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
    public partial class DcReportVariable
    {
        public DcReportVariable()
        {
        }

        [Key]
        [Display(Name = "Dəyişən ID")]
        public int VariableId { get; set; }

        [Display(Name = "Hesabat İD")]
        [ForeignKey("DcReport")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public int ReportId { get; set; }

        [Display(Name = "Dəyişən tipi İD")]
        [ForeignKey("DcReportVariableType")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public byte VariableTypeId { get; set; }

        [Display(Name = "Dəyişən Propertisi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableProperty { get; set; }

        [Display(Name = "Dəyişən Dəyəri")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableValue { get; set; }

        [Display(Name = "Əməliyat")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableOperator { get; set; }

        [Display(Name = "Dəyər Tipi")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableValueType { get; set; }

        [Display(Name = "Dəyişən Təmsilci")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Representative { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual DcReportVariableType DcReportVariableType { get; set; }

    }
}
