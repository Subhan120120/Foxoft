// File: Models/TrPayrollLine.cs
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
        public TrPayrollHeader PayrollHeader { get; set; } = null!;

        [Required]
        public PayrollItemType PayrollItemType { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
