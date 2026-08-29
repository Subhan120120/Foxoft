using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.AppCode;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.NotificationWorker
{
    public sealed class NotificationBackgroundWorker
    {
        private readonly NotificationWorkerOptions _options;

        public NotificationBackgroundWorker(NotificationWorkerOptions options)
        {
            _options = options;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Foxoft notification worker started.");

            if (_options.RunOnce)
            {
                await RunEnabledJobsAsync(stoppingToken);
                Console.WriteLine("Foxoft notification worker stopped.");
                return;
            }

            Task outboxTask = RunLoopAsync(
                "outbox",
                () => _options.EnableOutbox,
                () => TimeSpan.FromSeconds(Math.Max(10, _options.OutboxIntervalSeconds)),
                RunOutboxAsync,
                stoppingToken);

            Task installmentTask = RunLoopAsync(
                "installment checks",
                () => _options.EnableInstallmentChecks,
                () => TimeSpan.FromSeconds(Math.Max(60, _options.InstallmentCheckIntervalSeconds)),
                RunInstallmentChecksAsync,
                stoppingToken);

            await Task.WhenAll(outboxTask, installmentTask);
            Console.WriteLine("Foxoft notification worker stopped.");
        }

        private async Task RunEnabledJobsAsync(CancellationToken ct)
        {
            if (_options.EnableOutbox)
                await RunOutboxAsync(ct);

            if (_options.EnableInstallmentChecks)
                await RunInstallmentChecksAsync(ct);
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
                try
                {
                    if (isEnabled())
                        await work(stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Notification {workerName} failed: {ex}");
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

        private async Task RunOutboxAsync(CancellationToken ct)
        {
            await using subContext db = CreateDbContext();
            NotificationOutboxService outboxService = new(db);
            (int sent, int failed) = await outboxService.ProcessPendingAsync(
                Math.Max(1, _options.OutboxBatchSize),
                ct);

            if (sent > 0 || failed > 0)
                Console.WriteLine($"Notification outbox processed. Sent: {sent}. Failed: {failed}.");
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
                Console.WriteLine($"Installment payment notifications checked. Active notifications: {affectedCount}.");
        }

        private subContext CreateDbContext()
        {
            if (string.IsNullOrWhiteSpace(_options.ConnectionString))
                return new subContext();

            DbContextOptionsBuilder<subContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(
                SqlLanguageHelper.GetLocalizedConnectionString(_options.ConnectionString),
                sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null));
            return new subContext(optionsBuilder.Options);
        }
    }
}
