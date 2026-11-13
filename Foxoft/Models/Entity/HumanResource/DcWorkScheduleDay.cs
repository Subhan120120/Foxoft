using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("DcWorkScheduleDays")]
    public class DcWorkScheduleDay
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid WorkScheduleId { get; set; }

        [ForeignKey(nameof(WorkScheduleId))]
        public virtual DcWorkSchedule WorkSchedule { get; set; } = null!;

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        public bool IsWorkDay { get; set; } = true;

        [Required]
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);

        [Required]
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 0, 0);

        public TimeSpan? BreakStartTime { get; set; } = new TimeSpan(13, 0, 0);

        public TimeSpan? BreakEndTime { get; set; } = new TimeSpan(14, 0, 0);

        public int BreakDurationMinutes { get; set; } = 60;

        public int PlannedWorkMinutes { get; set; } = 480;
    }
}
