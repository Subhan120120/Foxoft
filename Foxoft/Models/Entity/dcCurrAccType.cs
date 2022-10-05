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
    public partial class DcCurrAccType
    {
        public DcCurrAccType()
        {
            DcCurrAccs = new HashSet<DcCurrAcc>();
        }

        [Key]
        [DisplayName("Cari Hesab Tipi Kodu")]
        public byte CurrAccTypeCode { get; set; }


        [DisplayName("Cari Hesab Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrAccTypeDesc { get; set; }

        [DisplayName("Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [DisplayName("Guid Id")]
        public Guid RowGuid { get; set; }

        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
