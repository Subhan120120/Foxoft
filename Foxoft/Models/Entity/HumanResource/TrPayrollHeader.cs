// File: Models/TrPayrollHeader.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrPayrollHeader
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public DcEmployee Employee { get; set; } = null!;

        [Required]
        public Guid PayrollPeriodId { get; set; }

        [ForeignKey(nameof(PayrollPeriodId))]
        public DcPayrollPeriod PayrollPeriod { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }

        public ICollection<TrPayrollLine> Lines { get; set; } = new HashSet<TrPayrollLine>();
    }
}
