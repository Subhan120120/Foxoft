using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductScale), ResourceType = typeof(Resources))]
    [Index(nameof(ProductCode), IsUnique = true)]
    [Index(nameof(ScaleProductNumber), IsUnique = true)]
    public partial class DcProductScale
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ProductScale_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductScale_ProductCode), ResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources),
                                    ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductScale_ScaleProductDesc), ResourceType = typeof(Resources))]
        public string? ScaleProductDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductScale_ScaleProductNumber), ResourceType = typeof(Resources))]
        public int? ScaleProductNumber { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductScale_UseInScale), ResourceType = typeof(Resources))]
        public bool UseInScale { get; set; }

        [ForeignKey(nameof(ProductCode))]
        public virtual DcProduct DcProduct { get; set; }
    }
}
