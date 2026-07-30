using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_NotificationTemplate), ResourceType = typeof(Resources))]
    public class NotificationTemplate : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_NotificationTemplate_Id), ResourceType = typeof(Resources))]
        public int NotificationTemplateId { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey(nameof(NotificationType))]
        [Display(Name = nameof(Resources.Entity_NotificationType_Code), ResourceType = typeof(Resources))]
        public string NotificationTypeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        [Display(Name = nameof(Resources.Entity_NotificationTemplate_LanguageCode), ResourceType = typeof(Resources))]
        public string LanguageCode { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        [Display(Name = nameof(Resources.Entity_NotificationTemplate_TitleTemplate), ResourceType = typeof(Resources))]
        public string TitleTemplate { get; set; } = string.Empty;

        [Required]
        [Display(Name = nameof(Resources.Entity_NotificationTemplate_BodyTemplate), ResourceType = typeof(Resources))]
        public string BodyTemplate { get; set; } = string.Empty;

        [DefaultValue(true)]
        [Display(Name = nameof(Resources.Common_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; } = true;

        public virtual NotificationType NotificationType { get; set; } = null!;
    }
}
