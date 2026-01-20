// File: Models/TrLeave.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrLeave
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        [InverseProperty(nameof(DcEmployee.Leaves))]
        public DcEmployee Employee { get; set; } = null!;

        [Required]
        public Guid LeaveTypeId { get; set; }

        [ForeignKey(nameof(LeaveTypeId))]
        public DcLeaveType LeaveType { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string? ApprovedByCurrAccCode { get; set; }

        [ForeignKey(nameof(ApprovedByCurrAccCode))]
        [InverseProperty(nameof(DcEmployee.ApprovedLeaves))]
        public DcEmployee? ApprovedByEmployee { get; set; }

        [Required]
        public LeaveStatus Status { get; set; } = LeaveStatus.Draft;

        [StringLength(500)]
        public string? Note { get; set; }
    }
}
