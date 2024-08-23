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
    [Display(Name = "Cari Hesab Alt Tipi")]
    public partial class DcPersonalType
    {
        public DcPersonalType()
        {
            DcCurrAccs = new HashSet<DcCurrAcc>();
        }

        [Key]
        [Display(Name = "Personal Tipi Kodu")]
        public byte PersonalTypeCode { get; set; }

        [Display(Name = "Personal Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PersonalTypeDesc { get; set; }

        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }



        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
