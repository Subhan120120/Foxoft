// File: Models/DcEmployee.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class DcEmployee
    {
        [Key]
        [ForeignKey(nameof(DcCurrAcc))]
        public string CurrAccCode { get; set; } = null!;

        [Required, StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(100)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string? FatherName { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; } = Gender.Unknown;

        [Required]
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.Unknown;

        [StringLength(30)]
        public string? NationalId { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigations
        [ForeignKey(nameof(CurrAccCode))]
        public DcCurrAcc DcCurrAcc { get; set; }
        public ICollection<TrEmployeePosition> EmployeePositions { get; set; } = new HashSet<TrEmployeePosition>();
        public ICollection<TrEmployeeContract> Contracts { get; set; } = new HashSet<TrEmployeeContract>();
        public ICollection<TrAttendance> Attendances { get; set; } = new HashSet<TrAttendance>();

        [InverseProperty(nameof(TrLeave.Employee))]
        public ICollection<TrLeave> Leaves { get; set; } = new HashSet<TrLeave>();
        public ICollection<TrPayrollHeader> PayrollHeaders { get; set; } = new HashSet<TrPayrollHeader>();
        public ICollection<TrEmployeeEducation> Educations { get; set; } = new HashSet<TrEmployeeEducation>();

        // Approval navigation (inverse)
        [InverseProperty(nameof(TrLeave.ApprovedByEmployee))]
        public ICollection<TrLeave> ApprovedLeaves { get; set; } = new HashSet<TrLeave>();
    }
}
