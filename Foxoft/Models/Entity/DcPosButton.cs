using Foxoft.Properties;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PosButton), ResourceType = typeof(Resources))]
    public class DcPosButton
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_PosButton_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = nameof(Resources.Entity_PosButton_ButtonName), ResourceType = typeof(Resources))]
        public string ButtonName { get; set; }

        [StringLength(200)]
        [Display(Name = nameof(Resources.Entity_PosButton_ButtonDescription), ResourceType = typeof(Resources))]
        public string? ButtonDescription { get; set; }

        [Display(Name = nameof(Resources.Entity_PosButton_IsVisible), ResourceType = typeof(Resources))]
        public bool IsVisible { get; set; } = true;

        [Display(Name = nameof(Resources.Entity_PosButton_SortOrder), ResourceType = typeof(Resources))]
        public int SortOrder { get; set; }

        [Display(Name = nameof(Resources.Entity_PosButton_BackColor), ResourceType = typeof(Resources))]
        public int? BackColorArgb { get; set; }

        [Display(Name = nameof(Resources.Entity_PosButton_ForeColor), ResourceType = typeof(Resources))]
        public int? ForeColorArgb { get; set; }
    }
}
