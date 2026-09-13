using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.AppCode;
using Foxoft.AppCode.Service.Backup;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.BackupWorker
{
    public sealed class BackupBackgroundWorker
    {
        private readonly BackupWorkerOptions _options;

        public BackupBackgroundWorker(BackupWorkerOptions options)
        {
            _options = options;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Foxoft Backup Worker başladı.");
            BackupWorkerManager.WriteHeartbeat(Environment.ProcessId);

            if (_options.RunOnce)
            {
                await RunOnceAsync(stoppingToken);
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Foxoft Backup Worker tamamlandı (run-once).");
                return;
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                BackupWorkerManager.WriteHeartbeat(Environment.ProcessId);

                try
                {
                    await CheckAndExecuteScheduledJobsAsync(stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[{DateTime.Now:HH:mm:ss}] Backup worker dövründə xəta: {ex.Message}");
                }

                int interval = Math.Max(10, _options.CheckIntervalSeconds);
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(interval), stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
            }

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Foxoft Backup Worker dayandırıldı.");
        }

        private async Task RunOnceAsync(CancellationToken ct)
        {
            if (_options.JobId.HasValue)
            {
                await ExecuteSpecificJobAsync(_options.JobId.Value, ct);
            }
            else
            {
                await CheckAndExecuteScheduledJobsAsync(ct);
            }
        }

        private async Task CheckAndExecuteScheduledJobsAsync(CancellationToken ct)
        {
            await using subContext db = CreateDbContext();

            // Check if global auto backup is enabled
            var setting = await db.AppSettings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 1, ct);
            if (setting != null && !setting.AutoBackupEnabled)
            {
                return;
            }

            string? rarPath = setting?.RarExePath;
            string connStr = GetEffectiveConnectionString();

            var activeJobs = await db.DcBackupJobs
                .Where(x => x.IsEnabled)
                .AsNoTracking()
                .ToListAsync(ct);

            DateTime now = DateTime.Now;

            foreach (var job in activeJobs)
            {
                ct.ThrowIfCancellationRequested();

                if (BackupScheduleEvaluator.IsJobDue(job, now))
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Tapşırıq cədvələ uyğun olaraq icraya göndərilir: '{job.JobName}' (ID: {job.BackupJobId})");

                    try
                    {
                        var summary = await BackupExecutionEngine.ExecuteJobAsync(job.BackupJobId, connStr, rarPath, ct);
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] '{job.JobName}' tamamlandı. Uğurlu: {summary.SuccessCount}/{summary.ProcessedCount}. Xətalar: {summary.FailureCount}");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"[{DateTime.Now:HH:mm:ss}] '{job.JobName}' icra edilərkən kritik xəta: {ex.Message}");
                    }
                }
            }
        }

        private async Task ExecuteSpecificJobAsync(int jobId, CancellationToken ct)
        {
            await using subContext db = CreateDbContext();
            var setting = await db.AppSettings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 1, ct);
            string? rarPath = setting?.RarExePath;
            string connStr = GetEffectiveConnectionString();

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Xüsusi tapşırıq işə salınır (ID: {jobId})...");
            var summary = await BackupExecutionEngine.ExecuteJobAsync(jobId, connStr, rarPath, ct);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Tapşırıq tamamlandı. Uğurlu: {summary.SuccessCount}/{summary.ProcessedCount}.");
        }

        private string GetEffectiveConnectionString()
        {
            if (!string.IsNullOrWhiteSpace(_options.ConnectionString))
                return _options.ConnectionString;

            try
            {
                using subContext db = new();
                string? conn = Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.GetConnectionString(db.Database);
                if (!string.IsNullOrWhiteSpace(conn))
                    return conn;
            }
            catch
            {
                // Fall back to default local SQL
            }

            return "Data Source=.\\SUBSQL;Initial Catalog=Tokla;Persist Security Info=True;TrustServerCertificate=True;MultipleActiveResultSets=True;User ID=sa;Password=sql123_;Encrypt=False;";
        }

        private subContext CreateDbContext()
        {
            string conn = GetEffectiveConnectionString();

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
