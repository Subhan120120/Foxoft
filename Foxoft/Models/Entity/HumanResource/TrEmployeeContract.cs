// File: Models/TrEmployeeContract.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseSalary { get; set; }

        [StringLength(3)]
        public string? CurrencyCode { get; set; } // AZN, USD, ...

        public virtual ICollection<TrEmployeeContractAddendum> Addenda { get; set; } = new HashSet<TrEmployeeContractAddendum>();
    }
}
