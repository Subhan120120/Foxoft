using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationRecipientRule), ResourceType = typeof(Resources))]
    public class NotificationRecipientRule : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationRecipientRule_Id), ResourceType = typeof(Resources))]
        public int NotificationRecipientRuleId { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey(nameof(NotificationType))]
        [Display(Name = nameof(Resources.Entity_NotificationType_Code), ResourceType = typeof(Resources))]
        public string NotificationTypeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(450)]
        [ForeignKey(nameof(DcRole))]
        [Display(Name = nameof(Resources.Entity_Role_Code), ResourceType = typeof(Resources))]
        public string RoleCode { get; set; } = string.Empty;

        [StringLength(30)]
        [ForeignKey(nameof(DcStore))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_StoreCode), ResourceType = typeof(Resources))]
        public string? StoreCode { get; set; }

        [DefaultValue(true)]
        [Display(Name = nameof(Resources.Common_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; } = true;

        public virtual NotificationType NotificationType { get; set; } = null!;
        public virtual DcRole DcRole { get; set; } = null!;
        public virtual DcCurrAcc? DcStore { get; set; }
    }
}
