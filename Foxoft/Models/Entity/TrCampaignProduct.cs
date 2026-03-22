using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(ProductCode), IsUnique = true)]
    public partial class TrCampaignProduct : BaseEntity
    {
        [Key]
        public Guid CampaignProductId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [ForeignKey(nameof(DcProduct))]
        [Required]
        [Display(Name = "Məhsul")]
        public string ProductCode { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcProduct DcProduct { get; set; }
    }
}