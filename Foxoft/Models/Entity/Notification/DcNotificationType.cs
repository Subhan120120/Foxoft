using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationType), ResourceType = typeof(Resources))]
    public class DcNotificationType : BaseEntity
    {
        public DcNotificationType()
        {
            DcNotificationRules = new HashSet<DcNotificationRule>();
            DcNotificationTemplates = new HashSet<DcNotificationTemplate>();
            DcNotificationRecipientRules = new HashSet<DcNotificationRecipientRule>();
            TrNotifications = new HashSet<TrNotification>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = nameof(Resources.Entity_NotificationType_Code), ResourceType = typeof(Resources))]
        public string NotificationTypeCode { get; set; } = string.Empty;

        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_NotificationType_CategoryCode), ResourceType = typeof(Resources))]
        public string CategoryCode { get; set; } = string.Empty;

        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_NotificationType_Desc), ResourceType = typeof(Resources))]
        public string NotificationTypeDesc { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = nameof(Resources.Entity_NotificationType_DefaultSeverity), ResourceType = typeof(Resources))]
        public string DefaultSeverity { get; set; } = NotificationSeverities.Info;

        [DefaultValue(false)]
        [Display(Name = nameof(Resources.Entity_NotificationType_AllowPopup), ResourceType = typeof(Resources))]
        public bool AllowPopup { get; set; }

        [DefaultValue(true)]
        [Display(Name = nameof(Resources.Common_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; } = true;

        [Display(Name = nameof(Resources.Common_Order), ResourceType = typeof(Resources))]
        public int DisplayOrder { get; set; }

        public virtual ICollection<DcNotificationRule> DcNotificationRules { get; set; }
        public virtual ICollection<DcNotificationTemplate> DcNotificationTemplates { get; set; }
        public virtual ICollection<DcNotificationRecipientRule> DcNotificationRecipientRules { get; set; }
        public virtual ICollection<TrNotification> TrNotifications { get; set; }
    }
}
