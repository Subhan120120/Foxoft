// File: Models/Entity/HumanResource/TrEmployeeContractAddendum.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrEmployeeContractAddendum
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public virtual TrEmployeeContract Contract { get; set; } = null!;

        [StringLength(50)]
        public string? AddendumNumber { get; set; } // Saziş № / Əmr №

        [Required]
        public DateTime StartDate { get; set; } // Qüvvəyə minmə tarixi

        public DateTime? EndDate { get; set; } // Bitmə tarixi (istəyə bağlı)

        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseSalary { get; set; } // Yeni baza əməkhaqqı

        [StringLength(3)]
        public string? CurrencyCode { get; set; } // AZN, USD, ...

        [StringLength(250)]
        public string? Description { get; set; } // Dəyişikliyin əsası / səbəbi (məs: İllik maaş artımı, vəzifə dəyişikliyi)
    }
}
