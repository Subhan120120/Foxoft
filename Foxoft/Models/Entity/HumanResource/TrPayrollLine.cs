// File: Models/TrPayrollLine.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrPayrollLine
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PayrollHeaderId { get; set; }

        [ForeignKey(nameof(PayrollHeaderId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public TrPayrollHeader PayrollHeader { get; set; } = null!;

        [Required]
        public PayrollItemType PayrollItemType { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(10)]
        [ForeignKey(nameof(DcCurrency))]
        public string CurrencyCode { get; set; } = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

        public float ExchangeRate { get; set; } = 1;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountLoc { get; set; }

        public virtual DcCurrency? DcCurrency { get; set; }
    }
}
