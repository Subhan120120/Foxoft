using Foxoft.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Notification), ResourceType = typeof(Resources))]
    public class TrNotification : BaseEntity
    {
        public TrNotification()
        {
            TrNotificationRecipients = new HashSet<TrNotificationRecipient>();
            TrNotificationChannelOutboxes = new HashSet<TrNotificationChannelOutbox>();
            TrNotificationAudits = new HashSet<TrNotificationAudit>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Notification_Id), ResourceType = typeof(Resources))]
        public long NotificationId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_Notification_Key), ResourceType = typeof(Resources))]
        public string NotificationKey { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [ForeignKey(nameof(DcNotificationType))]
        [Display(Name = nameof(Resources.Entity_NotificationType_Code), ResourceType = typeof(Resources))]
        public string NotificationTypeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = nameof(Resources.Entity_Notification_Severity), ResourceType = typeof(Resources))]
        public string Severity { get; set; } = NotificationSeverities.Info;

        [Required]
        [StringLength(300)]
        [Display(Name = nameof(Resources.Entity_Notification_Title), ResourceType = typeof(Resources))]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = nameof(Resources.Entity_Notification_Body), ResourceType = typeof(Resources))]
        public string Body { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = nameof(Resources.Entity_Notification_EntityType), ResourceType = typeof(Resources))]
        public string? EntityType { get; set; }

        [StringLength(100)]
        [Display(Name = nameof(Resources.Entity_Notification_EntityKey), ResourceType = typeof(Resources))]
        public string? EntityKey { get; set; }

        [StringLength(30)]
        [ForeignKey(nameof(DcStore))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_StoreCode), ResourceType = typeof(Resources))]
        public string? StoreCode { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = nameof(Resources.Entity_Notification_Status), ResourceType = typeof(Resources))]
        public string Status { get; set; } = NotificationStatuses.Active;

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_Notification_LastRaisedDate), ResourceType = typeof(Resources))]
        public DateTime LastRaisedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_Notification_ResolvedDate), ResourceType = typeof(Resources))]
        public DateTime? ResolvedDate { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_Notification_ExpireDate), ResourceType = typeof(Resources))]
        public DateTime? ExpireDate { get; set; }

        public virtual DcNotificationType DcNotificationType { get; set; } = null!;
        public virtual DcCurrAcc? DcStore { get; set; }
        public virtual ICollection<TrNotificationRecipient> TrNotificationRecipients { get; set; }
        public virtual ICollection<TrNotificationChannelOutbox> TrNotificationChannelOutboxes { get; set; }
        public virtual ICollection<TrNotificationAudit> TrNotificationAudits { get; set; }
    }
}
