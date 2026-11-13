using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("TrEmployeeWorkSchedules")]
    public class TrEmployeeWorkSchedule
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public Guid WorkScheduleId { get; set; }

        [ForeignKey(nameof(WorkScheduleId))]
        public virtual DcWorkSchedule WorkSchedule { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        public string? Notes { get; set; }
    }
}
