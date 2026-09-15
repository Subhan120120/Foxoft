using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service.Backup
{
    public sealed record JobExecutionSummary(
        int BackupJobId,
        string JobName,
        int ProcessedCount,
        int SuccessCount,
        int FailureCount,
        List<string> Errors);

    public static class BackupExecutionEngine
    {
        public static async Task<JobExecutionSummary> ExecuteJobAsync(
            int backupJobId,
            string connectionString,
            string? configuredRarPath = null,
            CancellationToken ct = default)
        {
            return await BackupQueueManager.Instance.ExecuteSequentialAsync(async () =>
            {
                using subContext db = CreateDbContext(connectionString);

                DcBackupJob? job = await db.DcBackupJobs.FirstOrDefaultAsync(x => x.BackupJobId == backupJobId, ct);
                if (job == null)
                    throw new InvalidOperationException($"Backup tapşırığı tapılmadı (ID: {backupJobId})");

                job.LastStatus = "Running";
                job.LastErrorMessage = null;
                await db.SaveChangesAsync(ct);

                List<string> errors = new();
                int successCount = 0;
                int processedCount = 0;

                GoogleDriveBackupService? driveService = null;
                if (job.UploadToCloud)
                {
                    try
                    {
                        driveService = new GoogleDriveBackupService();
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Google Drive xidmətini başladarkən xəta: {ex.Message}");
                    }
                }

                try
                {
                    // Ensure local directory exists
                    if (string.IsNullOrWhiteSpace(job.LocalPath))
                        throw new InvalidOperationException("Backup üçün yerli qovluq təyin edilməyib.");

                    if (!Directory.Exists(job.LocalPath))
                        Directory.CreateDirectory(job.LocalPath);

                    // Resolve target databases
                    List<string> databases = await BackupDatabaseScanner.ResolveDatabasesForJobAsync(
                        job.DatabaseNames,
                        connectionString,
                        ct);

                    if (databases.Count == 0)
                        throw new InvalidOperationException($"Tapşırıq üçün heç bir onlayn baza tapılmadı ({job.DatabaseNames})");

                    foreach (string dbName in databases)
                    {
                        ct.ThrowIfCancellationRequested();
                        processedCount++;

                        DateTime dbStartTime = DateTime.Now;
                        TrBackupLog log = new()
                        {
                            BackupJobId = job.BackupJobId,
                            JobName = job.JobName,
                            DatabaseName = dbName,
                            BackupType = job.BackupType == BackupType.Differential ? "Differential" : "Full",
                            StartTime = dbStartTime
                        };

                        try
                        {
                            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                            string typePrefix = job.BackupType == BackupType.Differential ? "Diff" : "Full";
                            string bakFileName = $"{dbName}_{typePrefix}_{timeStamp}.bak";
                            string bakFilePath = Path.Combine(job.LocalPath, bakFileName);

                            // 1. Execute SQL Backup
                            await ExecuteSqlBackupAsync(connectionString, dbName, bakFilePath, job.BackupType, ct);

                            if (!File.Exists(bakFilePath))
                                throw new FileNotFoundException("SQL Server backup faylını yaratmadı: " + bakFilePath);

                            FileInfo bakInfo = new(bakFilePath);
                            log.FileSizeBytes = bakInfo.Length;
                            log.BackupFileName = bakFileName;
                            log.BackupFilePath = bakFilePath;

                            // 2. Compress
                            ArchiveResult archiveResult = await BackupArchiveService.CompressBackupAsync(
                                bakFilePath,
                                job.CompressionType,
                                configuredRarPath,
                                deleteOriginalBak: true,
                                ct: ct);

                            log.BackupFileName = Path.GetFileName(archiveResult.ArchiveFilePath);
                            log.BackupFilePath = archiveResult.ArchiveFilePath;
                            log.CompressedSizeBytes = archiveResult.CompressedSizeBytes;

                            // 3. Upload to Google Drive if enabled
                            if (job.UploadToCloud && driveService != null)
                            {
                                string targetFolder = !string.IsNullOrWhiteSpace(job.CloudFolderId)
                                    ? job.CloudFolderId
                                    : (string.IsNullOrWhiteSpace(job.JobName) ? "FoxoftBackups" : $"FoxoftBackups/{job.JobName}");

                                string cloudFileId = await driveService.UploadFileAsync(archiveResult.ArchiveFilePath, targetFolder, ct);
                                log.IsUploadedToCloud = true;
                                log.CloudFileId = cloudFileId;
                            }

                            log.IsSuccess = true;
                            log.EndTime = DateTime.Now;
                            log.DurationSeconds = (log.EndTime - log.StartTime).TotalSeconds;
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            string err = $"[{dbName}] {ex.Message}";
                            errors.Add(err);

                            log.IsSuccess = false;
                            log.ErrorMessage = ex.ToString();
                            log.EndTime = DateTime.Now;
                            log.DurationSeconds = (log.EndTime - log.StartTime).TotalSeconds;

                            // Trigger central notification
                            await SendBackupFailedNotificationAsync(connectionString, job, dbName, ex.Message, ct);
                        }
                        finally
                        {
                            await SaveBackupLogAsync(connectionString, log, ct);
                        }
                    }

                    // 4. Apply Retention Policy
                    await BackupRetentionService.ApplyRetentionAsync(job, driveService, ct);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                    await SendBackupFailedNotificationAsync(connectionString, job, job.DatabaseNames, ex.Message, ct);
                }
                finally
                {
                    driveService?.Dispose();

                    // Update job status
                    DateTime now = DateTime.Now;
                    job.LastRunTime = now;
                    job.NextRunTime = BackupScheduleEvaluator.CalculateNextRunTime(job, now);
                    job.ModifiedDate = now;

                    if (errors.Count == 0)
                    {
                        job.LastStatus = "Success";
                        job.LastErrorMessage = null;
                    }
                    else
                    {
                        job.LastStatus = "Failed";
                        job.LastErrorMessage = string.Join(" | ", errors);
                    }

                    await db.SaveChangesAsync(ct);
                }

                return new JobExecutionSummary(
                    backupJobId,
                    job.JobName,
                    processedCount,
                    successCount,
                    errors.Count,
                    errors);
            }, ct);
        }

        private static async Task ExecuteSqlBackupAsync(
            string connectionString,
            string dbName,
            string bakFilePath,
            BackupType backupType,
            CancellationToken ct)
        {
            SqlConnectionStringBuilder cb = new(connectionString)
            {
                InitialCatalog = "master",
                ConnectTimeout = 30
            };

            string diffClause = backupType == BackupType.Differential ? "DIFFERENTIAL, " : "";
            string sql = $@"
BACKUP DATABASE [{dbName.Replace("]", "]]")}]
TO DISK = @bakPath
WITH COMPRESSION, {diffClause}FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

            string sqlWithoutCompression = $@"
BACKUP DATABASE [{dbName.Replace("]", "]]")}]
TO DISK = @bakPath
WITH {diffClause}FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

            await using SqlConnection conn = new(cb.ConnectionString);
            await conn.OpenAsync(ct);

            try
            {
                await using SqlCommand cmd = new(sql, conn)
                {
                    CommandTimeout = 0 // Unlimited timeout for long backups
                };
                cmd.Parameters.AddWithValue("@bakPath", bakFilePath);
                await cmd.ExecuteNonQueryAsync(ct);
            }
            catch (SqlException ex) when (ex.Number == 3060 || ex.Message.Contains("COMPRESSION", StringComparison.OrdinalIgnoreCase))
            {
                // Fallback if SQL Server edition does not support native backup compression
                if (File.Exists(bakFilePath))
                {
                    try { File.Delete(bakFilePath); } catch { }
                }

                await using SqlCommand cmdFallback = new(sqlWithoutCompression, conn)
                {
                    CommandTimeout = 0
                };
                cmdFallback.Parameters.AddWithValue("@bakPath", bakFilePath);
                await cmdFallback.ExecuteNonQueryAsync(ct);
            }
        }

        private static async Task SaveBackupLogAsync(string connectionString, TrBackupLog log, CancellationToken ct)
        {
            try
            {
                await using subContext logDb = CreateDbContext(connectionString);
                logDb.TrBackupLogs.Add(log);
                await logDb.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Backup jurnalını yazarkən xəta: {ex.Message}");
            }
        }

        private static async Task SendBackupFailedNotificationAsync(
            string connectionString,
            DcBackupJob job,
            string databaseName,
            string errorMessage,
            CancellationToken ct)
        {
            try
            {
                await using subContext notifDb = CreateDbContext(connectionString);
                NotificationService notificationService = new(notifDb);
                string key = $"BackupFailed_{job.BackupJobId}_{databaseName}_{DateTime.Today:yyyyMMdd}";

                await notificationService.CreateOrUpdateAsync(new NotificationCreateRequest(
                    NotificationTypeCode: NotificationTypeCodes.BackupFailed,
                    NotificationKey: key,
                    Severity: NotificationSeverities.Critical,
                    Title: "Baza Nüsxələnməsi Uğursuz Oldu",
                    Body: $"'{job.JobName}' tapşırığı çərçivəsində '{databaseName}' bazasının nüsxəsi alına bilmədi: {errorMessage}",
                    EntityType: "BackupJob",
                    EntityKey: job.BackupJobId.ToString(),
                    StoreCode: null
                ), ct);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Bildiriş göndərilərkən xəta: {ex.Message}");
            }
        }

        private static subContext CreateDbContext(string connectionString)
        {
            string conn = !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : "Data Source=.\\SUBSQL;Initial Catalog=Tokla;Persist Security Info=True;TrustServerCertificate=True;MultipleActiveResultSets=True;User ID=sa;Password=sql123_;Encrypt=False;";

            DbContextOptionsBuilder<subContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(
                SqlLanguageHelper.GetLocalizedConnectionString(conn),
                sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: new[] { 233 }));
            return new subContext(optionsBuilder.Options);
        }
    }
}
