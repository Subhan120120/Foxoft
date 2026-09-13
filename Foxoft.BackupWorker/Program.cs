using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.AppCode;
using Foxoft.BackupWorker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

BackupWorkerOptions options = BackupWorkerOptions.Load(args);

const string MutexName = @"Global\Foxoft_BackupWorker_SingleInstance";
using var mutex = new Mutex(true, MutexName, out bool isNewInstance);
if (!isNewInstance && !options.RunOnce)
{
    Console.WriteLine("Foxoft Backup Worker artıq arxa fonda işləyir. Təkrar nüsxə bağlanır.");
    return;
}

// If running as a Windows Service or with --service flag
if (!Environment.UserInteractive || args.Any(a => a.Equals("--service", StringComparison.OrdinalIgnoreCase)))
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddWindowsService(serviceOptions =>
    {
        serviceOptions.ServiceName = BackupWorkerManager.ServiceName;
    });

    builder.Services.AddSingleton(options);
    builder.Services.AddHostedService<WindowsBackupWorkerBridge>();

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

BackupBackgroundWorker worker = new(options);
await worker.RunAsync(cancellationTokenSource.Token);

static void InstallService()
{
    string exePath = Process.GetCurrentProcess().MainModule?.FileName ?? Path.Combine(AppContext.BaseDirectory, "Foxoft.BackupWorker.exe");
    Console.WriteLine($"Quraşdırılır: {BackupWorkerManager.ServiceName} -> {exePath}");

    var psi = new ProcessStartInfo
    {
        FileName = "sc.exe",
        Arguments = $"create {BackupWorkerManager.ServiceName} binPath= \"\\\"{exePath}\\\" --service\" start= auto DisplayName= \"Foxoft Automated Backup Service\"",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };

    using var proc = Process.Start(psi);
    proc?.WaitForExit();
    Console.WriteLine(proc?.StandardOutput.ReadToEnd());
}

static void UninstallService()
{
    Console.WriteLine($"Silinir: {BackupWorkerManager.ServiceName}...");
    var psi = new ProcessStartInfo
    {
        FileName = "sc.exe",
        Arguments = $"delete {BackupWorkerManager.ServiceName}",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };

    using var proc = Process.Start(psi);
    proc?.WaitForExit();
    Console.WriteLine(proc?.StandardOutput.ReadToEnd());
}

public class WindowsBackupWorkerBridge : BackgroundService
{
    private readonly BackupWorkerOptions _options;

    public WindowsBackupWorkerBridge(BackupWorkerOptions options)
    {
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        BackupBackgroundWorker worker = new(_options);
        await worker.RunAsync(stoppingToken);
    }
}
