using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("HrEmployeeLeaveBalances")]
    public class HrEmployeeLeaveBalance
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public Guid LeaveTypeId { get; set; }

        [ForeignKey(nameof(LeaveTypeId))]
        public virtual HrLeaveType LeaveType { get; set; } = null!;

        public int Year { get; set; } = DateTime.Today.Year;

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalEntitledDays { get; set; } = 21.0m;

        [Column(TypeName = "decimal(6,2)")]
        public decimal UsedDays { get; set; } = 0.0m;

        [Column(TypeName = "decimal(6,2)")]
        public decimal RemainingDays { get; set; } = 21.0m;
    }
}
