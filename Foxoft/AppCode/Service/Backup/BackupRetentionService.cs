using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.Models;

namespace Foxoft.AppCode.Service.Backup
{
    public static class BackupRetentionService
    {
        /// <summary>
        /// Applies retention policy to both local disk and Google Drive for the given backup job.
        /// </summary>
        public static async Task<int> ApplyRetentionAsync(
            DcBackupJob job,
            GoogleDriveBackupService? driveService = null,
            CancellationToken ct = default)
        {
            if (job.RetentionDays <= 0)
                return 0;

            int deletedTotal = 0;

            // 1. Local retention cleanup
            if (!string.IsNullOrWhiteSpace(job.LocalPath) && Directory.Exists(job.LocalPath))
            {
                DateTime cutoffDate = DateTime.Now.AddDays(-job.RetentionDays);
                string[] validExtensions = new[] { ".bak", ".zip", ".rar" };

                try
                {
                    DirectoryInfo dir = new(job.LocalPath);
                    var files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                        .Where(f => validExtensions.Contains(f.Extension.ToLowerInvariant()) && f.CreationTime < cutoffDate);

                    foreach (var file in files)
                    {
                        try
                        {
                            file.Delete();
                            deletedTotal++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Köhnə lokal backup faylını silərkən xəta ({file.FullName}): {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lokal retention tətbiq edilərkən xəta: {ex.Message}");
                }
            }

            // 2. Cloud retention cleanup
            if (job.UploadToCloud && driveService != null)
            {
                try
                {
                    int cloudDeleted = await driveService.CleanupExpiredBackupsAsync(
                        job.CloudFolderId ?? job.JobName,
                        job.RetentionDays,
                        ct);
                    deletedTotal += cloudDeleted;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bulud retention tətbiq edilərkən xəta: {ex.Message}");
                }
            }

            return deletedTotal;
        }
    }
}
