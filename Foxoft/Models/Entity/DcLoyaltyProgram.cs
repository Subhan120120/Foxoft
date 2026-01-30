// File: Models/Dc/DcLoyaltyProgram.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class DcLoyaltyProgram
    {
        [Key]
        public Guid LoyaltyProgramId { get; set; } = Guid.NewGuid();

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal EarnPercent { get; set; } = 0m; // Məs: 5.00 = 5%

        public int? ExpireDays { get; set; } // Bonusun “yanma” müddəti (gün)

        [Column(TypeName = "decimal(9,2)")]
        public decimal? MaxRedeemPercent { get; set; } // Qayda: bonusla maksimum neçə faiz ödənə bilər (opsional)

        [Required]
        public bool IsActive { get; set; } = true;

        [StringLength(200)]
        public string Note { get; set; }

        public virtual ICollection<DcLoyaltyCard> Cards { get; set; } = new HashSet<DcLoyaltyCard>();
    }
}
