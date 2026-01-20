// File: Models/DcPosition.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(PositionCode), IsUnique = true)]
    public class DcPosition
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string PositionCode { get; set; } = null!;

        [Required, StringLength(150)]
        public string PositionName { get; set; } = null!;

        [Required]
        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public DcDepartment Department { get; set; } = null!;

        public bool IsManagerial { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<TrEmployeePosition> EmployeePositions { get; set; } = new HashSet<TrEmployeePosition>();
    }
}
