using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.NotificationWorker
{
    public sealed class NotificationBackgroundWorker
    {
        private readonly NotificationWorkerOptions _options;
        private bool _wasOffline = false;

        public NotificationBackgroundWorker(NotificationWorkerOptions options)
        {
            _options = options;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Foxoft notification worker started.");
            NotificationWorkerManager.WriteHeartbeat(Environment.ProcessId);

            if (_options.RunOnce)
            {
                await RunEnabledJobsAsync(stoppingToken);
                Console.WriteLine("Foxoft notification worker finished (run-once).");
                return;
            }

            Task messageRetryTask = RunLoopAsync(
                "message retry (SMS & WhatsApp)",
                () => IsAutoSendEnabled(),
                () => TimeSpan.FromSeconds(Math.Max(5, GetAutoSendIntervalSeconds())),
                RunMessageRetryAsync,
                stoppingToken);

            Task outboxTask = RunLoopAsync(
                "outbox",
                () => _options.EnableOutbox && IsAutoSendEnabled(),
                () => TimeSpan.FromSeconds(Math.Max(10, _options.OutboxIntervalSeconds)),
                RunOutboxAsync,
                stoppingToken);

            Task installmentTask = RunLoopAsync(
                "installment checks",
                () => _options.EnableInstallmentChecks,
                () => TimeSpan.FromSeconds(Math.Max(60, _options.InstallmentCheckIntervalSeconds)),
                RunInstallmentChecksAsync,
                stoppingToken);

            await Task.WhenAll(messageRetryTask, outboxTask, installmentTask);
            Console.WriteLine("Foxoft notification worker stopped.");
        }

        private async Task RunEnabledJobsAsync(CancellationToken ct)
        {
            try
            {
                if (IsAutoSendEnabled())
                {
                    await RunMessageRetryAsync(ct);

                    if (_options.EnableOutbox)
                        await RunOutboxAsync(ct);
                }

                if (_options.EnableInstallmentChecks)
                    await RunInstallmentChecksAsync(ct);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[{DateTime.Now:HH:mm:ss}] Job execution failed: {ex.Message}");
            }
        }

        private async Task RunLoopAsync(
            string workerName,
            Func<bool> isEnabled,
            Func<TimeSpan> getInterval,
            Func<CancellationToken, Task> work,
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                NotificationWorkerManager.WriteHeartbeat(Environment.ProcessId);

                try
                {
                    if (isEnabled())
                    {
                        // Check internet before attempting network tasks
                        bool isOnline = await NetworkConnectivityHelper.IsInternetAvailableAsync(stoppingToken);
                        if (!isOnline)
                        {
                            if (!_wasOffline)
                            {
                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] İnternet bağlantısı yoxdur. {workerName} gözləmə rejiminə keçir...");
                                _wasOffline = true;
                            }
                            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                            continue;
                        }
                        else if (_wasOffline)
                        {
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] İnternet bağlantısı bərpa olundu! {workerName} işə salınır...");
                            _wasOffline = false;
                        }

                        await work(stoppingToken);
                    }
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[{DateTime.Now:HH:mm:ss}] Notification {workerName} failed: {ex.Message}");
                }

                TimeSpan interval = getInterval();
                try
                {
                    await Task.Delay(interval, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private async Task RunMessageRetryAsync(CancellationToken ct)
        {
            await using subContext db = CreateDbContext();

            int maxRetries = GetAutoSendMaxRetries();
            (int sent, int failed) = await MessageLogService.ProcessUnsentMessagesAsync(
                db,
                batchSize: Math.Max(1, _options.OutboxBatchSize),
                maxRetries: maxRetries,
                ct: ct);

            if (sent > 0 || failed > 0)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Kəsilmiş/Göndərilməyən mesajlar emal edildi. Göndərildi: {sent}. Xəta: {failed}.");
            }
        }

        private async Task RunOutboxAsync(CancellationToken ct)
        {
            await using subContext db = CreateDbContext();

            NotificationOutboxService outboxService = new(db);
            (int sent, int failed) = await outboxService.ProcessPendingAsync(
                Math.Max(1, _options.OutboxBatchSize),
                ct);

            if (sent > 0 || failed > 0)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Bildiriş outbox emal edildi. Göndərildi: {sent}. Xəta: {failed}.");
            }
        }

        private async Task RunInstallmentChecksAsync(CancellationToken ct)
        {
            await using subContext db = CreateDbContext();
            NotificationInstallmentCheckerService installmentChecker = new(db);
            int affectedCount = await installmentChecker.ScanInstallmentPaymentNotificationsAsync(
                Math.Max(0, _options.InstallmentReminderDaysBefore),
                _options.ActorCurrAccCode,
                ct);

            if (affectedCount > 0)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Kredit/Nisyə bildirişləri yoxlandı. Aktiv bildirişlər: {affectedCount}.");
            }
        }

        private bool IsAutoSendEnabled()
        {
            try
            {
                using subContext db = CreateDbContext();
                var setting = db.AppSettings.AsNoTracking().FirstOrDefault(x => x.Id == 1);
                if (setting != null)
                    return setting.AutoSendUnsentMessages;
            }
            catch
            {
                // Fallback to options if DB query fails temporarily
            }

            return _options.EnableWhatsAppRetry || _options.EnableOutbox;
        }

        private int GetAutoSendIntervalSeconds()
        {
            try
            {
                using subContext db = CreateDbContext();
                var setting = db.AppSettings.AsNoTracking().FirstOrDefault(x => x.Id == 1);
                if (setting != null && setting.AutoSendIntervalSeconds > 0)
                    return setting.AutoSendIntervalSeconds;
            }
            catch
            {
                // Fallback
            }

            return _options.WhatsAppRetryIntervalSeconds > 0 ? _options.WhatsAppRetryIntervalSeconds : 30;
        }

        private int GetAutoSendMaxRetries()
        {
            try
            {
                using subContext db = CreateDbContext();
                var setting = db.AppSettings.AsNoTracking().FirstOrDefault(x => x.Id == 1);
                if (setting != null && setting.AutoSendMaxRetries > 0)
                    return setting.AutoSendMaxRetries;
            }
            catch
            {
                // Fallback
            }

            return _options.WhatsAppMaxRetries > 0 ? _options.WhatsAppMaxRetries : 5;
        }

        private subContext CreateDbContext()
        {
            if (string.IsNullOrWhiteSpace(_options.ConnectionString))
                return new subContext();

            DbContextOptionsBuilder<subContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(
                SqlLanguageHelper.GetLocalizedConnectionString(_options.ConnectionString),
                sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: new[] { 233 }));
            return new subContext(optionsBuilder.Options);
        }
    }
}
