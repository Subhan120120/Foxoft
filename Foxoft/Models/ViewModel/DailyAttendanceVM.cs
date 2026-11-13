using Foxoft.Models;
using System;
using System.ComponentModel;

namespace Foxoft.Models.ViewModel
{
    public class DailyAttendanceVM : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string CurrAccCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string? StoreCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? PositionName { get; set; }
        public string? ScheduleName { get; set; }

        public DateTime? PlannedCheckInTime { get; set; }
        public DateTime? PlannedCheckOutTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime? EffectiveStartTime { get; set; }

        public int BreakMinutes { get; set; }
        public int WorkedMinutes { get; set; }
        public decimal WorkedHours => Math.Round((decimal)WorkedMinutes / 60.0m, 2);

        public int LateMinutes { get; set; }
        public int EarlyExitMinutes { get; set; }
        public int OvertimeMinutes { get; set; }
        public int ApprovedOvertimeMinutes { get; set; }

        public AttendanceStatus AttendanceStatus { get; set; }
        public string StatusDesc => AttendanceStatus.ToString();

        public Guid? LeaveRequestId { get; set; }
        public string? LeaveTypeName { get; set; }

        public bool IsManualOverride { get; set; }
        public string? Notes { get; set; }

        // Scheduler Properties
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllDay { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int LabelId { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class AttendanceResourceVM
    {
        public string CurrAccCode { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string? StoreCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? PositionName { get; set; }
    }
}
