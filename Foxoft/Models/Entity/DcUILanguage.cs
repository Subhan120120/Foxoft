using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_UILanguage), ResourceType = typeof(Resources))]
    public partial class DcUILanguage
    {
        public DcUILanguage() { DcCurrAccs = new HashSet<DcCurrAcc>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_UILanguage_Code), ResourceType = typeof(Resources))]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string LanguageCode { get; set; }

        [Display(Name = nameof(Resources.Entity_UILanguage_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string LanguageDesc { get; set; }

        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
