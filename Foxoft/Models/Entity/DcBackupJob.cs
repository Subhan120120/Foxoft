using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public enum BackupType : byte
    {
        Full = 0,
        Differential = 1
    }

    public enum BackupCompressionType : byte
    {
        None = 0,
        Zip = 1,
        Rar = 2
    }

    public enum BackupScheduleType : byte
    {
        IntervalMinutes = 0,
        DailyAtTime = 1
    }

    [Table("DcBackupJobs")]
    public class DcBackupJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BackupJobId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobName { get; set; } = string.Empty;

        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Comma-separated list of database names or "*" for all online databases.
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string DatabaseNames { get; set; } = "*";

        public BackupType BackupType { get; set; } = BackupType.Full;

        public BackupCompressionType CompressionType { get; set; } = BackupCompressionType.Zip;

        [Required]
        [StringLength(500)]
        public string LocalPath { get; set; } = string.Empty;

        public bool UploadToCloud { get; set; } = false;

        [StringLength(50)]
        public string CloudProvider { get; set; } = "GoogleDrive";

        [StringLength(200)]
        public string? CloudFolderId { get; set; }

        /// <summary>
        /// Retention duration in days. 0 = keep indefinitely.
        /// </summary>
        public int RetentionDays { get; set; } = 7;

        public BackupScheduleType ScheduleType { get; set; } = BackupScheduleType.DailyAtTime;

        /// <summary>
        /// Used when ScheduleType is IntervalMinutes. E.g. 60 = every 60 minutes.
        /// </summary>
        public int IntervalMinutes { get; set; } = 60;

        /// <summary>
        /// Interval daily start time (e.g. 09:00:00).
        /// </summary>
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);

        /// <summary>
        /// Interval daily end time (e.g. 18:00:00).
        /// </summary>
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 0, 0);

        /// <summary>
        /// Daily run time when ScheduleType is DailyAtTime (e.g. 23:00:00).
        /// </summary>
        public TimeSpan DailyTime { get; set; } = new TimeSpan(23, 0, 0);

        /// <summary>
        /// Comma-separated days of week: 1=Monday, 2=Tuesday, ..., 7=Sunday.
        /// </summary>
        [StringLength(50)]
        public string SelectedDaysOfWeek { get; set; } = "1,2,3,4,5,6,7";

        public DateTime? LastRunTime { get; set; }

        public DateTime? NextRunTime { get; set; }

        [StringLength(50)]
        public string LastStatus { get; set; } = "Pending";

        [StringLength(2000)]
        public string? LastErrorMessage { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<TrBackupLog> BackupLogs { get; set; } = new List<TrBackupLog>();
    }
}
