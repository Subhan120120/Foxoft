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
    public partial class TrCurrAccRole : BaseEntity
    {
        [Key]
        [DisplayName("Cari Hesab Rol Id")]
        public int CurrAccRoleId { get; set; }

        [ForeignKey("DcCurrAcc")]
        [DisplayName("Cari Hesab")]
        public string CurrAccCode { get; set; }

        [DisplayName("Rol")]
        [ForeignKey("DcRole")]
        public string RoleCode { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }

        public virtual DcRole DcRole { get; set; }
    }
}
