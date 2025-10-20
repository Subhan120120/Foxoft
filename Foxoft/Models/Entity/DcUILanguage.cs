using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Interface Dili")]
    public partial class DcUILanguage
    {
        public DcUILanguage()
        {
            DcCurrAccs = new HashSet<DcCurrAcc>();
        }

        [Key]
        [Display(Name = "Dil Kodu")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LanguageCode { get; set; }

        [Display(Name = "Dil Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string LanguageDesc { get; set; }


        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
