using Foxoft.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationAudit), ResourceType = typeof(Resources))]
    public class NotificationAudit
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationAudit_Id), ResourceType = typeof(Resources))]
        public long NotificationAuditId { get; set; }

        [ForeignKey(nameof(Notification))]
        [Display(Name = nameof(Resources.Entity_Notification_Id), ResourceType = typeof(Resources))]
        public long? NotificationId { get; set; }

        [ForeignKey(nameof(NotificationRecipient))]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_Id), ResourceType = typeof(Resources))]
        public long? NotificationRecipientId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_NotificationAudit_ActionType), ResourceType = typeof(Resources))]
        public string ActionType { get; set; } = string.Empty;

        [StringLength(30)]
        [ForeignKey(nameof(ActorCurrAcc))]
        [Display(Name = nameof(Resources.Entity_NotificationAudit_ActorCurrAccCode), ResourceType = typeof(Resources))]
        public string? ActorCurrAccCode { get; set; }

        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_ChannelCode), ResourceType = typeof(Resources))]
        public string? ChannelCode { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationAudit_ActionDate), ResourceType = typeof(Resources))]
        public DateTime ActionDate { get; set; } = DateTime.Now;

        [Display(Name = nameof(Resources.Entity_NotificationAudit_Note), ResourceType = typeof(Resources))]
        public string? Note { get; set; }

        public virtual Notification? Notification { get; set; }
        public virtual NotificationRecipient? NotificationRecipient { get; set; }
        public virtual DcCurrAcc? ActorCurrAcc { get; set; }
    }
}
