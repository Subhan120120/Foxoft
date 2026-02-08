// File: Models/Tr/TrLoyaltyTxn.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(LoyaltyCardId), nameof(DocumentDate))]
    [Index(nameof(InvoiceHeaderId))]
    [Index(nameof(PaymentLineId))]
    public class TrLoyaltyTxn : BaseEntity
    {
        [Key]
        public Guid LoyaltyTxnId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LoyaltyCardId { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [Required]
        public LoyaltyTxnType TxnType { get; set; }

        // + Earn, - Redeem, Reverse/Adjust/Expire də +/- ola bilər
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime DocumentDate { get; set; } = DateTime.Now;

        // Qazanılan bonusun yanma tarixi (Earn üçün)
        public DateTime? ExpireAt { get; set; }

        // Mənbə sənədlər (səndə bu entity-lər var deyə yalnız FK saxlayırıq)
        public Guid? InvoiceHeaderId { get; set; }

        public Guid? PaymentLineId { get; set; }

        // Reverse əməliyyatlar üçün əlaqə (məs: hansı txn-i geri çevirdi)
        public Guid? RelatedLoyaltyTxnId { get; set; }

        [StringLength(200)]
        public string? Note { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        [ForeignKey(nameof(LoyaltyCardId))]
        public virtual DcLoyaltyCard DcLoyaltyCard { get; set; }

        [ForeignKey(nameof(RelatedLoyaltyTxnId))]
        public virtual TrLoyaltyTxn RelatedLoyaltyTxn { get; set; }

        [ForeignKey(nameof(PaymentLineId))]
        public virtual TrPaymentLine TrPaymentLine { get; set; }

        [ForeignKey(nameof(InvoiceHeaderId))]
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}
