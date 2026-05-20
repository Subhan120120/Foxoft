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
        public DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public LeaveType LeaveType { get; set; }

        [Required]
        public LeaveStatus LeaveStatus { get; set; }

        [StringLength(500)]
        public string? Reason { get; set; }
    }
}
