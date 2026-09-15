using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service.Backup
{
    /// <summary>
    /// Thread-safe queue manager that ensures only one backup task executes against SQL Server at any given time.
    /// Prevents CPU, memory, and disk I/O contention.
    /// </summary>
    public sealed class BackupQueueManager
    {
        private static readonly Lazy<BackupQueueManager> _instance = new(() => new BackupQueueManager());
        public static BackupQueueManager Instance => _instance.Value;

        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private int _waitingCount = 0;

        public int WaitingCount => _waitingCount;
        public bool IsRunning => _semaphore.CurrentCount == 0;

        public async Task<T> ExecuteSequentialAsync<T>(Func<Task<T>> action, CancellationToken ct = default)
        {
            Interlocked.Increment(ref _waitingCount);
            try
            {
                await _semaphore.WaitAsync(ct);
                try
                {
                    return await action();
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            finally
            {
                Interlocked.Decrement(ref _waitingCount);
            }
        }

        public async Task ExecuteSequentialAsync(Func<Task> action, CancellationToken ct = default)
        {
            Interlocked.Increment(ref _waitingCount);
            try
            {
                await _semaphore.WaitAsync(ct);
                try
                {
                    await action();
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            finally
            {
                Interlocked.Decrement(ref _waitingCount);
            }
        }
    }
}
