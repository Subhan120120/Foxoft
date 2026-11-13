// File: Models/TrAttendance.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("TrAttendances")]
    public class TrAttendance
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public DateTime WorkDate { get; set; } // store date (time ignored)

        public Guid? WorkScheduleId { get; set; }

        [ForeignKey(nameof(WorkScheduleId))]
        public virtual DcWorkSchedule? WorkSchedule { get; set; }

        public DateTime? PlannedCheckInTime { get; set; }
        public DateTime? PlannedCheckOutTime { get; set; }
        public int PlannedWorkMinutes { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public DateTime? EffectiveStartTime { get; set; }

        public int BreakMinutes { get; set; } = 60;
        public int WorkedMinutes { get; set; }

        public int LateMinutes { get; set; }
        public int EarlyExitMinutes { get; set; }
        public int OvertimeMinutes { get; set; }
        public int ApprovedOvertimeMinutes { get; set; }

        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Present;

        public Guid? LeaveRequestId { get; set; }

        [ForeignKey(nameof(LeaveRequestId))]
        public virtual HrLeaveRequest? LeaveRequest { get; set; }

        public bool IsManualOverride { get; set; } = false;

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime? CalculatedAt { get; set; }
    }
}
