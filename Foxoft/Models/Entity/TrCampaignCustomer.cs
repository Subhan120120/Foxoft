using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(CurrAccCode), IsUnique = true)]
    public partial class TrCampaignCustomer : BaseEntity
    {
        [Key]
        public Guid CampaignCustomerId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Required]
        [Display(Name = "Müştəri")]
        public string CurrAccCode { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}