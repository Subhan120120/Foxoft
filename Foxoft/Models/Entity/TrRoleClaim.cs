using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    [Display(Name = "Rol Yetkisi")]
    public partial class TrRoleClaim : BaseEntity
    {
        [Key]
        [Display(Name = "Rol Yetki Id")]
        public int RoleClaimId { get; set; }

        [Required]
        [ForeignKey("DcRole")]
        [Display(Name = "Rol Kodu")]
        public string RoleCode { get; set; }

        [Required]
        [ForeignKey("DcClaim")]
        [Display(Name = "Yetki Kodu")]
        public string ClaimCode { get; set; }


        public virtual DcRole DcRole { get; set; }
        public virtual DcClaim DcClaim { get; set; }
    }
}
