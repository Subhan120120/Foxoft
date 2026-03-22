using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(InvoiceHeaderId), IsUnique = true)]
    public partial class TrInvoiceCampaignHeader : BaseEntity
    {
        [Key]
        public Guid InvoiceCampaignHeaderId { get; set; }

        [ForeignKey(nameof(TrInvoiceHeader))]
        public Guid InvoiceHeaderId { get; set; }

        [StringLength(50)]
        [Display(Name = "Promo code")]
        public string? PromoCode { get; set; }

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
    }
}