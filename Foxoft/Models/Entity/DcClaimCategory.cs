using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Kateqoriya İyerarxiyası")]
    public partial class DcClaimCategory : BaseEntity
    {
        public DcClaimCategory()
        {
            DcClaims = new HashSet<DcClaim>();
        }

        [Key]
        [Display(Name = "Kateqoriya Id")]
        public int CategoryId { get; set; }

        [Display(Name = "Kateqoriya Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CategoryDesc { get; set; }

        [Display(Name = "Kateqoriya Səviyyəsi")]
        public int CategoryLevel { get; set; }

        [Display(Name = "Ana Kateqoriya Kodu")]
        public int? CategoryParentId { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }



        public virtual ICollection<DcClaim> DcClaims { get; set; }
    }
}
