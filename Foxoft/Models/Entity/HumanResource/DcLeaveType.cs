// File: Models/DcLeaveType.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(LeaveCode), IsUnique = true)]
    public class DcLeaveType
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string LeaveCode { get; set; } = null!;

        [Required, StringLength(120)]
        public string LeaveName { get; set; } = null!;

        public bool IsPaid { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<TrLeave> Leaves { get; set; } = new HashSet<TrLeave>();
    }
}
