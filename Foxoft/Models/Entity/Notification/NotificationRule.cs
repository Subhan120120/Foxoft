using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationRule), ResourceType = typeof(Resources))]
    public class NotificationRule : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationRule_Id), ResourceType = typeof(Resources))]
        public int NotificationRuleId { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = nameof(Resources.Entity_NotificationRule_Name), ResourceType = typeof(Resources))]
        public string RuleName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [ForeignKey(nameof(NotificationType))]
        [Display(Name = nameof(Resources.Entity_NotificationType_Code), ResourceType = typeof(Resources))]
        public string NotificationTypeCode { get; set; } = string.Empty;

        [StringLength(30)]
        [ForeignKey(nameof(DcStore))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_StoreCode), ResourceType = typeof(Resources))]
        public string? StoreCode { get; set; }

        [DefaultValue(true)]
        [Display(Name = nameof(Resources.Common_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; } = true;

        [DefaultValue(60)]
        [Display(Name = nameof(Resources.Entity_NotificationRule_ThrottleMinutes), ResourceType = typeof(Resources))]
        public int ThrottleMinutes { get; set; } = 60;

        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_NotificationRule_ChannelCodes), ResourceType = typeof(Resources))]
        public string ChannelCodes { get; set; } = NotificationChannels.InApp;

        [StringLength(20)]
        [Display(Name = nameof(Resources.Entity_NotificationRule_PopupMinSeverity), ResourceType = typeof(Resources))]
        public string PopupMinSeverity { get; set; } = NotificationSeverities.High;

        public virtual NotificationType NotificationType { get; set; } = null!;
        public virtual DcCurrAcc? DcStore { get; set; }
    }
}
