// File: Models/DcEmploymentType.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(TypeCode), IsUnique = true)]
    public class DcEmploymentType
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string TypeCode { get; set; } = null!; // FullTime, PartTime, Contract

        [Required, StringLength(100)]
        public string TypeName { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public ICollection<TrEmployeeContract> Contracts { get; set; } = new HashSet<TrEmployeeContract>();
    }
}
