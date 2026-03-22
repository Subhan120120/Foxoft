using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(WarehouseCode), IsUnique = true)]
    public partial class TrCampaignWarehouse : BaseEntity
    {
        [Key]
        public Guid CampaignWarehouseId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [ForeignKey(nameof(DcWarehouse))]
        [Required]
        [Display(Name = "Depo")]
        public string WarehouseCode { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcWarehouse DcWarehouse { get; set; }
    }
}