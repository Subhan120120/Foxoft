using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(CampaignId), nameof(PaymentMethodId), IsUnique = true)]
    public partial class TrCampaignPaymentMethod : BaseEntity
    {
        [Key]
        public Guid CampaignPaymentMethodId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [ForeignKey(nameof(DcPaymentMethod))]
        [Display(Name = "Ödəmə üsulu")]
        public int PaymentMethodId { get; set; }

        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
    }
}