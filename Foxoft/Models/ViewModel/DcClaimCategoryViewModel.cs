using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "İyerarxiya Kateqoriyası")]
    public partial class DcClaimCategoryViewModel : BaseEntity
    {

        [Key]
        [Display(Name = "Kateqoriya Id")]
        public int CategoryId { get; set; }

        [Display(Name = "Kateqoriya Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CategoryDesc { get; set; }

        [Display(Name = "Kateqoriya Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string ClaimDesc { get; set; }

        [Display(Name = "Kateqoriya Səviyyəsi")]
        public int CategoryLevel { get; set; }

        [Display(Name = "Ana Kateqoriya Kodu")]
        public int? CategoryParentId { get; set; }

        [Display(Name = "Secilendir")]
        public bool IsSelected { get; set; }

        [Display(Name = "Kategoriadır")]
        public bool IsCategory { get; set; }

        [Display(Name = "Role Kodu")]
        public string ClaimCode { get; set; }

    }
}
