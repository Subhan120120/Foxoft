using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("TrBackupLogs")]
    public class TrBackupLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BackupLogId { get; set; }

        public int BackupJobId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobName { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string DatabaseName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string BackupType { get; set; } = "Full";

        [StringLength(260)]
        public string BackupFileName { get; set; } = string.Empty;

        [StringLength(500)]
        public string BackupFilePath { get; set; } = string.Empty;

        public long FileSizeBytes { get; set; }

        [NotMapped]
        public double FileSizeMb => Math.Round(FileSizeBytes / (1024.0 * 1024.0), 2);

        public long? CompressedSizeBytes { get; set; }

        [NotMapped]
        public double? CompressedSizeMb => CompressedSizeBytes.HasValue
            ? Math.Round(CompressedSizeBytes.Value / (1024.0 * 1024.0), 2)
            : null;

        public bool IsUploadedToCloud { get; set; }

        [StringLength(200)]
        public string? CloudFileId { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public DateTime EndTime { get; set; } = DateTime.Now;

        public double DurationSeconds { get; set; }

        public bool IsSuccess { get; set; }

        [StringLength(4000)]
        public string? ErrorMessage { get; set; }

        [ForeignKey(nameof(BackupJobId))]
        public virtual DcBackupJob? BackupJob { get; set; }
    }
}
