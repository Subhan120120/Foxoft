using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models.Entity
{

    [Index(nameof(DocumentType), nameof(DocumentId), IsUnique = true)]
    [Index(nameof(LastHeartbeatAtUtc))]
    public sealed class DocumentLock
    {
        [Key]
        public Guid LockId { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string DocumentType { get; set; } = null!;   // "Invoice"

        [Required]
        public Guid DocumentId { get; set; }                // InvoiceHeaderId

        [Required]
        public string LockedByUserId { get; set; }

        [Required]
        public DateTime LockedAtUtc { get; set; }

        [Required]
        public DateTime LastHeartbeatAtUtc { get; set; }

        [MaxLength(128)]
        public string? MachineName { get; set; }
        public string? ForceCloseReason { get; set; }

        public Guid FormInstanceId { get; set; }

        public int ClientProcessId { get; set; }
        public DateTime? ForceCloseRequestedAtUtc { get; set; }
        

        [Required]
        public Guid AppInstanceId { get; set; }

        public string? Reason { get; set; } // istəsən [MaxLength(200)] verə bilərsən
    }
}
