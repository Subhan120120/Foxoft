using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class DcClaim
    {
        public DcClaim()
        {
            TrRoleClaims = new HashSet<TrRoleClaim>();
        }

        [Key]
        public string ClaimCode { get; set; }

        [Required]
        public string ClaimDesc { get; set; }


        public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }
    }
}
