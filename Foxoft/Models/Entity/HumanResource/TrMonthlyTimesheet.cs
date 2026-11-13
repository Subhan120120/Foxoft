using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(CurrAccCode), nameof(Year), nameof(Month), IsUnique = true)]
    [Table("TrMonthlyTimesheets")]
    public class TrMonthlyTimesheet
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        public Guid? PayrollPeriodId { get; set; }

        [ForeignKey(nameof(PayrollPeriodId))]
        public virtual DcPayrollPeriod? PayrollPeriod { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int ScheduledDays { get; set; }

        public int WorkedDays { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal WorkedHours { get; set; }

        public int UnexcusedAbsenceDays { get; set; }

        public int ExcusedAbsenceDays { get; set; }

        public int LateMinutes { get; set; }

        public int EarlyExitMinutes { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalOvertimeHours { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal ApprovedOvertimeHours { get; set; }

        public int PaidLeaveDays { get; set; }

        public int UnpaidLeaveDays { get; set; }

        public int SickLeaveDays { get; set; }

        public bool IsLocked { get; set; } = false;

        public DateTime CalculatedDate { get; set; } = DateTime.Now;

        [StringLength(300)]
        public string? Notes { get; set; }
    }
}
