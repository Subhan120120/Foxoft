using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties; // Resources üçün

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ContactType), ResourceType = typeof(Resources))]
    public partial class DcContactType
    {
        public DcContactType()
        {
            DcContactDetails = new HashSet<DcCurrAccContactDetail>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_ContactType_Id), ResourceType = typeof(Resources))]
        public byte Id { get; set; }

        [Display(Name = nameof(Resources.Entity_ContactType_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string ContactTypeDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_ContactType_PhoneNumberFormat), ResourceType = typeof(Resources))]
        [StringLength(200,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string? PhoneNumberFormat { get; set; }

        [Display(Name = nameof(Resources.Entity_ContactType_DefaultValue), ResourceType = typeof(Resources))]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string? DefaultValue { get; set; }

        public virtual ICollection<DcCurrAccContactDetail> DcContactDetails { get; set; }
    }
}
