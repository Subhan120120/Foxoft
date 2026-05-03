using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Kredit Əməliyyatları")]
    public class TrCredit : BaseEntity
    {
        [Key]
        [Display(Name = "Kredit Id")]
        public Guid CreditId { get; set; }

        [Column(TypeName = "tinyint")]
        [Display(Name = "Əməliyyat Növü")]
        public CreditTransactionType TransactionType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Məbləğ")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        [Display(Name = "Xidmət Növü")]
        public string? ServiceType { get; set; }

        [StringLength(500)]
        [Display(Name = "Açıqlama")]
        public string? Description { get; set; }

        [StringLength(64)]
        [Display(Name = "API Key Hash")]
        public string? ApiKeyHash { get; set; }
    }
}
