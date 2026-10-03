using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models.Entity.RoleClaim
{
    [Display(Name = nameof(Resources.Entity_CurrAccRole), ResourceType = typeof(Resources))]
    public partial class TrCurrAccRole : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccRole_Id), ResourceType = typeof(Resources))]
        public int CurrAccRoleId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRole_CurrAccCode), ResourceType = typeof(Resources))]
        [StringLength(30)]
        public string CurrAccCode { get; set; }

        [NotMapped]
        public string UserName { get => CurrAccCode; set => CurrAccCode = value; }

        [Display(Name = nameof(Resources.Entity_CurrAccRole_RoleCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcRole))]
        public string RoleCode { get; set; }

        public virtual DcRole DcRole { get; set; }
    }
}
