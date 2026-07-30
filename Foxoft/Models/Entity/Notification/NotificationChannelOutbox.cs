using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox), ResourceType = typeof(Resources))]
    public class NotificationChannelOutbox
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_Id), ResourceType = typeof(Resources))]
        public long OutboxId { get; set; }

        [ForeignKey(nameof(Notification))]
        [Display(Name = nameof(Resources.Entity_Notification_Id), ResourceType = typeof(Resources))]
        public long NotificationId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_ChannelCode), ResourceType = typeof(Resources))]
        public string ChannelCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_Receiver), ResourceType = typeof(Resources))]
        public string Receiver { get; set; } = string.Empty;

        [Required]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_Payload), ResourceType = typeof(Resources))]
        public string Payload { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [DefaultValue(NotificationOutboxStatuses.Pending)]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_Status), ResourceType = typeof(Resources))]
        public string Status { get; set; } = NotificationOutboxStatuses.Pending;

        [DefaultValue(0)]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_TryCount), ResourceType = typeof(Resources))]
        public int TryCount { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_LastTryDate), ResourceType = typeof(Resources))]
        public DateTime? LastTryDate { get; set; }

        [Display(Name = nameof(Resources.Entity_NotificationChannelOutbox_LastError), ResourceType = typeof(Resources))]
        public string? LastError { get; set; }

        [Column(TypeName = "datetime2")]
        [DefaultValueSql("sysdatetime()")]
        [Display(Name = nameof(Resources.Entity_Base_CreatedDate), ResourceType = typeof(Resources))]
        public DateTime CreatedDate { get; set; }

        public virtual Notification Notification { get; set; } = null!;
    }
}
