using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties; // Resources namespace

namespace Foxoft // remove Dc/Tr prefixes from entity names in keys (not applicable here)
{
    public partial class BaseEntity
    {
        [Display(Name = nameof(Resources.Entity_Base_CreatedUserName), ResourceType = typeof(Resources))]
        [StringLength(20,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [DefaultValue(@"substring(suser_name(),patindex('%\%',suser_name())+(1),(20))")]
        public string? CreatedUserName { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "datetime")]
        [Display(Name = nameof(Resources.Entity_Base_CreatedDate), ResourceType = typeof(Resources))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = nameof(Resources.Entity_Base_LastUpdatedUserName), ResourceType = typeof(Resources))]
        [StringLength(20,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [DefaultValue(@"substring(suser_name(),patindex('%\%',suser_name())+(1),(20))")]
        public string? LastUpdatedUserName { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "datetime")]
        [Display(Name = nameof(Resources.Entity_Base_LastUpdatedDate), ResourceType = typeof(Resources))]
        public DateTime LastUpdatedDate { get; set; }
    }
}
