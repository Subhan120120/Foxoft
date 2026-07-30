using Foxoft.NotificationWorker;

NotificationWorkerOptions options = NotificationWorkerOptions.Load(args);

CancellationTokenSource cancellationTokenSource = new();
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

AppDomain.CurrentDomain.ProcessExit += (_, _) =>
{
    if (!cancellationTokenSource.IsCancellationRequested)
        cancellationTokenSource.Cancel();
};

NotificationBackgroundWorker worker = new(options);
await worker.RunAsync(cancellationTokenSource.Token);
