using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("TrOvertimeRequests")]
    public class TrOvertimeRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public DateTime WorkDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int OvertimeMinutes { get; set; }

        [StringLength(300)]
        public string? Reason { get; set; }

        public bool IsApproved { get; set; } = false;

        [StringLength(30)]
        public string? ApprovedByCurrAccCode { get; set; }

        [ForeignKey(nameof(ApprovedByCurrAccCode))]
        public virtual DcCurrAcc? ApprovedByCurrAcc { get; set; }

        public DateTime? ApprovedDate { get; set; }
    }
}
