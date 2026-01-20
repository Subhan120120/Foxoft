// File: Models/TrEmployeeEducation.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrEmployeeEducation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public DcEmployee Employee { get; set; } = null!;

        [Required, StringLength(200)]
        public string SchoolName { get; set; } = null!;

        [StringLength(150)]
        public string? Degree { get; set; }

        [Range(1900, 2100)]
        public int? StartYear { get; set; }

        [Range(1900, 2100)]
        public int? EndYear { get; set; }
    }
}
