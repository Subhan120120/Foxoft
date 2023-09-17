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
    [Display(Name = "Qiymət Tipləri")]
    public partial class DcPriceType
    {
        public DcPriceType()
        {
            TrPriceListHeaders = new HashSet<TrPriceListHeader>();
        }

        [Key]
        [Display(Name = "Qiymət Tipi Kodu")]
        public string PriceTypeCode { get; set; }

        [Display(Name = "Qiymət Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxıla bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PriceTypeDesc { get; set; }

        public virtual ICollection<TrPriceListHeader> TrPriceListHeaders { get; set; }

    }
}
