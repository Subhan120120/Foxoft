using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("HrLeaveRequests")]
    public class HrLeaveRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string RequestNumber { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public Guid LeaveTypeId { get; set; }

        [ForeignKey(nameof(LeaveTypeId))]
        public virtual HrLeaveType LeaveType { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalDays { get; set; } = 1.0m;

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalHours { get; set; } = 8.0m;

        [StringLength(500)]
        public string? Reason { get; set; }

        public LeaveStatus Status { get; set; } = LeaveStatus.Draft;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? CreatedUserName { get; set; }

        public virtual ICollection<HrLeaveRequestDay> RequestDays { get; set; } = new HashSet<HrLeaveRequestDay>();
        public virtual ICollection<HrLeaveApproval> Approvals { get; set; } = new HashSet<HrLeaveApproval>();
        public virtual ICollection<TrAttendance> Attendances { get; set; } = new HashSet<TrAttendance>();
    }
}
