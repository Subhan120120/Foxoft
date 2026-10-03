using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_UserCompany), ResourceType = typeof(Resources))]
    public partial class TrUserCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserCompanyId { get; set; }

        [Display(Name = nameof(Resources.Entity_UserCompany_UserName), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string UserName { get; set; } = null!;

        [Display(Name = nameof(Resources.Entity_UserCompany_CompanyCode), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string CompanyCode { get; set; } = null!;

        public virtual DcUser DcUser { get; set; } = null!;

        public virtual DcCompany DcCompany { get; set; } = null!;
    }
}
