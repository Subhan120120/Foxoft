using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("HrLeaveRequestDays")]
    public class HrLeaveRequestDay
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LeaveRequestId { get; set; }

        [ForeignKey(nameof(LeaveRequestId))]
        public virtual HrLeaveRequest LeaveRequest { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Saatlıq icazə üçün başlanğıc saat (məs. 14:00)
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Saatlıq icazə üçün bitmə saatı (məs. 16:00)
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DurationHours { get; set; } = 8.0m;

        public bool IsHalfDay { get; set; } = false;

        public bool IsPaid { get; set; } = true;
    }
}
