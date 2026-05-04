using Foxoft.Properties;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Shortcut), ResourceType = typeof(Resources))]
    public class DcShortcut
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Shortcut_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = nameof(Resources.Entity_Shortcut_FormName), ResourceType = typeof(Resources))]
        public string FormName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = nameof(Resources.Entity_Shortcut_ButtonName), ResourceType = typeof(Resources))]
        public string ButtonName { get; set; }

        [StringLength(100)]
        [Display(Name = nameof(Resources.Entity_Shortcut_ShortcutKeys), ResourceType = typeof(Resources))]
        public string? ShortcutKeys { get; set; }

        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_Shortcut_ButtonDescription), ResourceType = typeof(Resources))]
        public string? ButtonDescription { get; set; }
    }
}
