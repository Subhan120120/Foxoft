using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Office), ResourceType = typeof(Resources))]
    public partial class DcOffice : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Office_Code), ResourceType = typeof(Resources))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Office_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Company), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [Column(TypeName = "numeric(4, 0)")]
        public decimal CompanyCode { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Common_RowGuid), ResourceType = typeof(Resources))]
        public Guid RowGuid { get; set; }
    }
}
