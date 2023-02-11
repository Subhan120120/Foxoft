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
    public partial class DcOffice : BaseEntity
    {
        [Key]
        [Display(Name = "Ofis Kodu")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [Display(Name = "Ofis Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeDesc { get; set; }

        [Display(Name = "Şirkət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Column(TypeName = "numeric(4, 0)")]
        public decimal CompanyCode { get; set; }

        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Guid Id")]
        public Guid RowGuid { get; set; }
    }
}
