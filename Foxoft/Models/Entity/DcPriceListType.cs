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
    public partial class DcPriceListType
    {
        public DcPriceListType()
        {
            TrPriceListHeaders = new HashSet<TrPriceListHeader>();
        }

        [Key]
        [Display(Name = "Qiymət Siyahı Tipi Kodu")]
        public string PriceListTypeCode { get; set; }

        [Display(Name = "Qiymət Siyahı Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxıla bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PriceListTypeDesc { get; set; }

        public virtual ICollection<TrPriceListHeader> TrPriceListHeaders { get; set; }

    }
}
