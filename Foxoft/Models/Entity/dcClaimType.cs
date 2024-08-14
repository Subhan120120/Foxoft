using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Display(Name = "Yetki Tipi")]
    public partial class DcClaimType
    {
        public DcClaimType()
        {
            //DcClaims = new HashSet<DcClaim>();
           // TrRoleClaims = new HashSet<TrRoleClaim>();
        }

        [Key]
        [Display(Name = "Səlahiyyət Tip Id")]
        public byte ClaimTypeId { get; set; }

        [Display(Name = "Səlahiyyət Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ClaimTypeDesc { get; set; }


        public virtual ICollection<DcClaim> DcClaims { get; set; }
        //public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }

    }
}
