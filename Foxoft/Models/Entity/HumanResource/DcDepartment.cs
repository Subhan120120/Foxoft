// File: Models/DcDepartment.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(DepartmentCode), IsUnique = true)]
    public class DcDepartment
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string DepartmentCode { get; set; } = null!;

        [Required, StringLength(150)]
        public string DepartmentName { get; set; } = null!;

        public Guid? ParentDepartmentId { get; set; }

        [ForeignKey(nameof(ParentDepartmentId))]
        [InverseProperty(nameof(ChildDepartments))]
        public DcDepartment? ParentDepartment { get; set; }

        public bool IsActive { get; set; } = true;

        [InverseProperty(nameof(ParentDepartment))]
        public ICollection<DcDepartment> ChildDepartments { get; set; } = new HashSet<DcDepartment>();
        public ICollection<DcPosition> Positions { get; set; } = new HashSet<DcPosition>();
    }
}
