using System;

namespace Foxoft.Models.ViewModel
{
    public class WorkScheduleDayVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DayOfWeek DayOfWeek { get; set; }
        public string DayName => DayOfWeek.ToString();
        public bool IsWorkDay { get; set; } = true;
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 0, 0);
        public TimeSpan? BreakStartTime { get; set; } = new TimeSpan(13, 0, 0);
        public TimeSpan? BreakEndTime { get; set; } = new TimeSpan(14, 0, 0);
        public int BreakDurationMinutes { get; set; } = 60;
        public int PlannedWorkMinutes { get; set; } = 480;
    }
}
