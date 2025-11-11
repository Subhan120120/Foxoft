using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccRole), ResourceType = typeof(Resources))]
    public partial class TrCurrAccRole : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccRole_Id), ResourceType = typeof(Resources))]
        public int CurrAccRoleId { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_CurrAccRole_CurrAccCode), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRole_RoleCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcRole))]
        public string RoleCode { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcRole DcRole { get; set; }
    }
}
