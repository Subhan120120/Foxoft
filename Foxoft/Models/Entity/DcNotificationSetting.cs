using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    public class DcNotificationSetting
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = nameof(Resources.Form_NotificationSettings_NotificationType), ResourceType = typeof(Resources))]
        public string NotificationType { get; set; }

        [Display(Name = nameof(Resources.Form_NotificationSettings_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; }

        [Display(Name = nameof(Resources.Form_NotificationSettings_DaysBefore), ResourceType = typeof(Resources))]
        public int? DaysBefore { get; set; }

        [StringLength(1000)]
        [Display(Name = nameof(Resources.Form_NotificationSettings_MessageTemplate), ResourceType = typeof(Resources))]
        public string? MessageTemplate { get; set; }
    }
}
