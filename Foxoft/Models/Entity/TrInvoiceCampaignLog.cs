using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Index(nameof(InvoiceHeaderId))]
    [Index(nameof(CampaignId))]
    [Index(nameof(InvoiceLineId))]
    public partial class TrInvoiceCampaignLog : BaseEntity
    {
        [Key]
        public Guid InvoiceCampaignLogId { get; set; }

        [ForeignKey(nameof(TrInvoiceHeader))]
        public Guid InvoiceHeaderId { get; set; }

        [ForeignKey(nameof(TrInvoiceLine))]
        public Guid? InvoiceLineId { get; set; }

        [ForeignKey(nameof(DcCampaign))]
        public Guid CampaignId { get; set; }

        [StringLength(30)]
        public string? CampaignCode { get; set; }

        [StringLength(100)]
        public string? CampaignDesc { get; set; }

        [StringLength(20)]
        public CampaignTypeCode? CampaignTypeCode { get; set; }

        [StringLength(50)]
        public string? PromoCode { get; set; }

        public int? PaymentMethodId { get; set; }

        [DefaultValueSql("0")]
        public int Priority { get; set; }

        [DefaultValueSql("0")]
        public bool IsCombinable { get; set; }

        [Column(TypeName = "money")]
        public decimal BaseAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal BaseAmountLoc { get; set; }

        [Column(TypeName = "money")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal DiscountAmountLoc { get; set; }

        [DefaultValueSql("0")]
        public decimal DiscountPercent { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual TrInvoiceLine? TrInvoiceLine { get; set; }
        public virtual DcCampaign DcCampaign { get; set; }
        public virtual DcPaymentMethod? DcPaymentMethod { get; set; }
    }
}