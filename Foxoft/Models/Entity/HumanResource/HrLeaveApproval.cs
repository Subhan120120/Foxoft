using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("HrLeaveApprovals")]
    public class HrLeaveApproval
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LeaveRequestId { get; set; }

        [ForeignKey(nameof(LeaveRequestId))]
        public virtual HrLeaveRequest LeaveRequest { get; set; } = null!;

        [StringLength(30)]
        public string? ApproverCurrAccCode { get; set; }

        [ForeignKey(nameof(ApproverCurrAccCode))]
        public virtual DcCurrAcc? ApproverCurrAcc { get; set; }

        public DateTime ApprovalDate { get; set; } = DateTime.Now;

        public LeaveStatus Status { get; set; } = LeaveStatus.Approved;

        [StringLength(500)]
        public string? Comment { get; set; }
    }
}
