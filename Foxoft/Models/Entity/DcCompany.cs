using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Company), ResourceType = typeof(Resources))]
    public partial class DcCompany
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Company_Code), ResourceType = typeof(Resources))]
        public string CompanyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Company_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(150,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string CompanyDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Company_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Entity_Company_RowGuid), ResourceType = typeof(Resources))]
        public Guid RowGuid { get; set; }
    }
}
