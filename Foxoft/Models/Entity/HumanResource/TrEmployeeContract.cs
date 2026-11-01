// File: Models/TrEmployeeContract.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Foxoft.Models
{
    public class TrEmployeeContract
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string? ContractNumber { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public Guid EmploymentTypeId { get; set; }

        [ForeignKey(nameof(EmploymentTypeId))]
        public DcEmploymentType EmploymentType { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<TrEmployeeContractAddendum> Addenda { get; set; } = new HashSet<TrEmployeeContractAddendum>();

        [NotMapped]
        public decimal BaseSalary => Addenda
            .OrderByDescending(a => a.StartDate)
            .Select(a => a.BaseSalary)
            .FirstOrDefault();

        [NotMapped]
        public string? CurrencyCode => Addenda
            .OrderByDescending(a => a.StartDate)
            .Select(a => a.CurrencyCode)
            .FirstOrDefault();
    }
}
