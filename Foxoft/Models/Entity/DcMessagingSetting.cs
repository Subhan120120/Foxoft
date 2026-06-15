using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    public class DcMessagingSetting
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = nameof(Resources.Form_MessagingSettings_MessagingType), ResourceType = typeof(Resources))]
        public string MessagingType { get; set; }

        [Display(Name = nameof(Resources.Form_MessagingSettings_IsEnabled), ResourceType = typeof(Resources))]
        public bool IsEnabled { get; set; }

        [Display(Name = nameof(Resources.Form_MessagingSettings_DaysBefore), ResourceType = typeof(Resources))]
        public int? DaysBefore { get; set; }

        [StringLength(1000)]
        [Display(Name = nameof(Resources.Form_MessagingSettings_MessageTemplate), ResourceType = typeof(Resources))]
        public string? MessageTemplate { get; set; }
    }
}
