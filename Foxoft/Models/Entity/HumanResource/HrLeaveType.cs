using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(TypeCode), IsUnique = true)]
    [Table("HrLeaveTypes")]
    public class HrLeaveType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(50)]
        public string TypeCode { get; set; } = null!; // AnnualLeave, SickLeave, UnpaidLeave, PersonalPermission, BusinessTrip, DayOff

        [Required, StringLength(100)]
        public string TypeName { get; set; } = null!;

        public bool IsPaid { get; set; } = true;

        public bool AffectAttendance { get; set; } = true;

        public bool RequiresApproval { get; set; } = true;

        public bool IsHourly { get; set; } = false;

        public int DefaultDaysPerYear { get; set; } = 21;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<HrLeaveRequest> LeaveRequests { get; set; } = new HashSet<HrLeaveRequest>();
        public virtual ICollection<HrEmployeeLeaveBalance> Balances { get; set; } = new HashSet<HrEmployeeLeaveBalance>();
    }
}
