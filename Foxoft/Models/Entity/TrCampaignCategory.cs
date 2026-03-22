using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(HierarchyCode), IsUnique = true)]
    public partial class TrCampaignCategory : BaseEntity
    {
        [Key]
        public Guid CampaignCategoryId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [ForeignKey(nameof(DcHierarchy))]
        [Required]
        [Display(Name = "Kateqoriya")]
        public string HierarchyCode { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcHierarchy DcHierarchy { get; set; }
    }
}