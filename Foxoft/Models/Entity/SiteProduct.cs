using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_SiteProduct), ResourceType = typeof(Resources))]
    public partial class SiteProduct : BaseEntity
    {
        [Display(Name = nameof(Resources.Entity_SiteProduct_ProductId), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Key]
        [Display(Name = nameof(Resources.Entity_SiteProduct_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        public string ProductCode { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_Desc), ResourceType = typeof(Resources))]
        [StringLength(50,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Desc { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_Price), ResourceType = typeof(Resources))]
        public decimal Price { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_Rating), ResourceType = typeof(Resources))]
        public int? Rating { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_CategoryId), ResourceType = typeof(Resources))]
        public int CategoryId { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_Slug), ResourceType = typeof(Resources))]
        [StringLength(150,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Slug { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_ViewCount), ResourceType = typeof(Resources))]
        public int ViewCount { get; set; }

        [Display(Name = nameof(Resources.Entity_SiteProduct_UseInSite), ResourceType = typeof(Resources))]
        public bool UseInSite { get; set; }

        [ForeignKey(nameof(ProductCode))]
        public virtual DcProduct DcProduct { get; set; }
    }
}
