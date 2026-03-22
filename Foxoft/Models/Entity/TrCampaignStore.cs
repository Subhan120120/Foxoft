using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(StoreCode), IsUnique = true)]
    public partial class TrCampaignStore : BaseEntity
    {
        [Key]
        public Guid CampaignStoreId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Store")]
        public string StoreCode { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcCurrAcc? DcStore { get; set; }
    }
}