using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class DcRole : BaseEntity
    {
        public DcRole()
        {
            TrRoleClaims = new HashSet<TrRoleClaim>();
            TrCurrAccRoles = new HashSet<TrCurrAccRole>();
        }

        [Key]
        [Display(Name = "Rol Kodu")]
        public string RoleCode { get; set; }

        [Display(Name = "Rol Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string RoleDesc { get; set; }


        public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }
        public virtual ICollection<TrCurrAccRole> TrCurrAccRoles { get; set; }

    }
}
