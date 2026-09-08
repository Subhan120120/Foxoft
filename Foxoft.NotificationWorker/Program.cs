using Foxoft.AppCode;
using Foxoft.NotificationWorker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

if (args.Length > 0)
{
    string firstArg = args[0].TrimStart('-', '/').ToLowerInvariant();
    if (firstArg == "install")
    {
        InstallService();
        return;
    }
    if (firstArg == "uninstall")
    {
        UninstallService();
        return;
    }
}

NotificationWorkerOptions options = NotificationWorkerOptions.Load(args);

// If running as a Windows Service or with --service flag
if (!Environment.UserInteractive || args.Any(a => a.Equals("--service", StringComparison.OrdinalIgnoreCase)))
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddWindowsService(serviceOptions =>
    {
        serviceOptions.ServiceName = NotificationWorkerManager.ServiceName;
    });

    builder.Services.AddSingleton(options);
    builder.Services.AddHostedService<WindowsWorkerBridge>();

    IHost host = builder.Build();
    await host.RunAsync();
    return;
}

// Otherwise run interactive / background process
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

static void InstallService()
{
    string exePath = Process.GetCurrentProcess().MainModule?.FileName ?? Path.Combine(AppContext.BaseDirectory, "Foxoft.NotificationWorker.exe");
    Console.WriteLine($"Installing {NotificationWorkerManager.ServiceName} pointing to: {exePath}");

    var psi = new ProcessStartInfo
    {
        FileName = "sc.exe",
        Arguments = $"create {NotificationWorkerManager.ServiceName} binPath= \"\\\"{exePath}\\\" --service\" start= auto DisplayName= \"Foxoft Notification & Auto-Retry Service\"",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };

    using var proc = Process.Start(psi);
    proc?.WaitForExit();
    Console.WriteLine(proc?.StandardOutput.ReadToEnd());
}

static void UninstallService()
{
    Console.WriteLine($"Uninstalling {NotificationWorkerManager.ServiceName}...");
    var psi = new ProcessStartInfo
    {
        FileName = "sc.exe",
        Arguments = $"delete {NotificationWorkerManager.ServiceName}",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };

    using var proc = Process.Start(psi);
    proc?.WaitForExit();
    Console.WriteLine(proc?.StandardOutput.ReadToEnd());
}

public class WindowsWorkerBridge : BackgroundService
{
    private readonly NotificationWorkerOptions _options;

    public WindowsWorkerBridge(NotificationWorkerOptions options)
    {
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        NotificationBackgroundWorker worker = new(_options);
        await worker.RunAsync(stoppingToken);
    }
}
