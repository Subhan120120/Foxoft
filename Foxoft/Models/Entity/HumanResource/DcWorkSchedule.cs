using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(ScheduleCode), IsUnique = true)]
    [Table("DcWorkSchedules")]
    public class DcWorkSchedule
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string ScheduleCode { get; set; } = null!;

        [Required, StringLength(150)]
        public string ScheduleName { get; set; } = null!;

        public WorkScheduleType ScheduleType { get; set; } = WorkScheduleType.Standard5Days;

        [Column(TypeName = "decimal(5,2)")]
        public decimal WeeklyHours { get; set; } = 40.00m;

        public bool IsActive { get; set; } = true;

        [StringLength(250)]
        public string? Description { get; set; }

        public virtual ICollection<DcWorkScheduleDay> Days { get; set; } = new HashSet<DcWorkScheduleDay>();
        public virtual ICollection<TrEmployeeWorkSchedule> EmployeeWorkSchedules { get; set; } = new HashSet<TrEmployeeWorkSchedule>();
        public virtual ICollection<TrAttendance> Attendances { get; set; } = new HashSet<TrAttendance>();
    }
}
