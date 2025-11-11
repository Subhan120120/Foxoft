using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccType), ResourceType = typeof(Resources))]
    public partial class DcCurrAccType
    {
        public DcCurrAccType()
        {
            DcCurrAccs = new HashSet<DcCurrAcc>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccType_Code), ResourceType = typeof(Resources))]
        public byte CurrAccTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccType_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string CurrAccTypeDesc { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        public virtual ICollection<DcCurrAcc> DcCurrAccs { get; set; }
    }
}
