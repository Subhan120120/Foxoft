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

        // + Earn, - Redeem, Reverse/Adjust/Expire d? +/- ola bil?r
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime DocumentDate { get; set; } = DateTime.Now;

        // Qazanilan bonusun yanma tarixi (Earn üçün)
        public DateTime? ExpireAt { get; set; }

        // M?nb? s?n?dl?r (s?nd? bu entity-l?r var dey? yalniz FK saxlayiriq)
        public Guid? InvoiceHeaderId { get; set; }

        public Guid? PaymentLineId { get; set; }

        // Reverse ?m?liyyatlar üçün ?laq? (m?s: hansi txn-i geri çevirdi)
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

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual TrPaymentLine TrPaymentLine { get; set; }

        [ForeignKey(nameof(InvoiceHeaderId))]

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}
