using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Index(nameof(ShiftCode), IsUnique = true)]
    public class DcShift
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string ShiftCode { get; set; } = null!;

        [Required, StringLength(150)]
        public string ShiftName { get; set; } = null!;

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<TrEmployeeShift> EmployeeShifts { get; set; } = new HashSet<TrEmployeeShift>();
    }
}
