using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class TrRoleClaim : BaseEntity
    {
        [Key]
        public int RoleClaimId { get; set; }

        [Required]
        [ForeignKey("DcRole")]
        public string RoleCode { get; set; }

        [Required]
        [ForeignKey("DcClaim")]
        public string ClaimCode { get; set; }


        public virtual DcClaim DcClaim { get; set; }
        public virtual DcRole DcRole { get; set; }
    }
}
