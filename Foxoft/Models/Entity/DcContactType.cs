using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Display(Name = "Əlaqə Məlumatları Tipi")]
    public partial class DcContactType
    {
        public DcContactType()
        {
            DcContactDetails = new HashSet<DcCurrAccContactDetail>();
        }

        [Key]
        [Display(Name = "Əlaqə Məlumatları Tipi İd")]
        public byte Id { get; set; }


        [Display(Name = "Əlaqə Məlumatları Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ContactTypeDesc { get; set; }

        [Display(Name = "Telefon Nömrəsi formatı")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? PhoneNumberFormat { get; set; }

        [Display(Name = "Default Dəyər")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? DefaultValue { get; set; }

        public virtual ICollection<DcCurrAccContactDetail> DcContactDetails { get; set; }
    }
}
