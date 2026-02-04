// File: Models/Dc/DcLoyaltyCard.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Index(nameof(CardNumber), IsUnique = true)]
    [Index(nameof(CurrAccCode))]
    public class DcLoyaltyCard : BaseEntity
    {
        [Key]
        public Guid LoyaltyCardId { get; set; } = Guid.NewGuid();

        [Required, StringLength(32)]
        public string CardNumber { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        public Guid? LoyaltyProgramId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [StringLength(200)]
        public string Note { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        [ForeignKey(nameof(LoyaltyProgramId))]
        public virtual DcLoyaltyProgram DcLoyaltyProgram { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; }

        public virtual ICollection<TrLoyaltyTxn> TrLoyaltyTxns { get; set; } = new HashSet<TrLoyaltyTxn>();
    }
}
