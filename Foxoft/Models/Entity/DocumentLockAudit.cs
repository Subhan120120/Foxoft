
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models.Entity
{
    [Index(nameof(DocumentType), nameof(DocumentId), nameof(ActionAtUtc))]
    public sealed class DocumentLockAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AuditId { get; set; }

        [Required, MaxLength(50)]
        public string DocumentType { get; set; } = null!;

        [Required]
        public Guid DocumentId { get; set; }

        [Required, MaxLength(50)]
        public string Action { get; set; } = null!; // LOCK, UNLOCK, TAKEOVER, FORCE_UNLOCK

        public string? UserId { get; set; }

        [MaxLength(200)]
        public string? UserName { get; set; }

        [MaxLength(128)]
        public string? MachineName { get; set; }

        [Required]
        public DateTime ActionAtUtc { get; set; }

        public string? Note { get; set; } // istəsən [MaxLength(400)] verə bilərsən
    }

}
