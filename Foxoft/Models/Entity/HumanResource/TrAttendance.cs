// File: Models/TrAttendance.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrAttendance
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public DateTime WorkDate { get; set; } // store date (time ignored)

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public int WorkedMinutes { get; set; }
    }
}
