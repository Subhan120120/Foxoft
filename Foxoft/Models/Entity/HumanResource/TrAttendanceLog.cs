using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("TrAttendanceLogs")]
    public class TrAttendanceLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(30)]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [StringLength(50)]
        public string? DeviceCode { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }

        public PunchType PunchType { get; set; } = PunchType.AutoDetect;

        public PunchSourceMethod SourceMethod { get; set; } = PunchSourceMethod.Biometric;

        [StringLength(100)]
        public string? Location { get; set; }

        /// <summary>
        /// Anti-Double Punch (Debounce): Eyni cihazda müəyyən edilmiş dəqiqə ərzində təkrar oxunan loglar nəzərə alınmır.
        /// </summary>
        public bool IsIgnored { get; set; } = false;

        [StringLength(200)]
        public string? IgnoreReason { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? CreatedUserName { get; set; }
    }
}
