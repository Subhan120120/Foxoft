// File: Models/DcPayrollPeriod.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(PeriodYear), nameof(PeriodMonth), IsUnique = true)]
    public class DcPayrollPeriod
    {
        [Key]
        public Guid Id { get; set; }

        [Range(2000, 2100)]
        public int PeriodYear { get; set; }

        [Range(1, 12)]
        public int PeriodMonth { get; set; }

        public bool IsClosed { get; set; }

        public ICollection<TrPayrollHeader> PayrollHeaders { get; set; } = new HashSet<TrPayrollHeader>();
    }
}
