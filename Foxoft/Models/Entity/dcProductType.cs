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
    [Display(Name = "Məhsul Tipi")]
    public partial class DcProductType
    {
        public DcProductType()
        {
            DcProducts = new HashSet<DcProduct>();
        }

        [Key]
        [Display(Name = "Məhsul Tipi Kodu")]
        public byte ProductTypeCode { get; set; }

        [Display(Name = "Məhsul Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductTypeDesc { get; set; }

        public virtual ICollection<DcProduct> DcProducts { get; set; }

    }
}
