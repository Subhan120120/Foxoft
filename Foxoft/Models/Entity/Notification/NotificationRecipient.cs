using Foxoft.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationRecipient), ResourceType = typeof(Resources))]
    public class NotificationRecipient : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_Id), ResourceType = typeof(Resources))]
        public long NotificationRecipientId { get; set; }

        [ForeignKey(nameof(Notification))]
        [Display(Name = nameof(Resources.Entity_Notification_Id), ResourceType = typeof(Resources))]
        public long NotificationId { get; set; }

        [Required]
        [StringLength(30)]
        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_Status), ResourceType = typeof(Resources))]
        public string Status { get; set; } = NotificationRecipientStatuses.Unread;

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_ReadDate), ResourceType = typeof(Resources))]
        public DateTime? ReadDate { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_DismissedDate), ResourceType = typeof(Resources))]
        public DateTime? DismissedDate { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_SnoozedUntil), ResourceType = typeof(Resources))]
        public DateTime? SnoozedUntil { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = nameof(Resources.Entity_NotificationRecipient_LastPopupShownDate), ResourceType = typeof(Resources))]
        public DateTime? LastPopupShownDate { get; set; }

        public virtual Notification Notification { get; set; } = null!;
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;
    }
}
