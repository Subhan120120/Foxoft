using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text.Json;

namespace Foxoft.AppCode
{
    public enum BackupWorkerStatus
    {
        RunningAsService,
        RunningAsProcess,
        Stopped,
        NotInstalled
    }

    public static class BackupWorkerManager
    {
        public const string ServiceName = "FoxoftBackupWorker";
        public const string ProcessName = "Foxoft.BackupWorker";

        public static string GetHeartbeatFilePath()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return Path.Combine(dir, "BackupWorkerHeartbeat.json");
        }

        public static BackupWorkerStatus GetStatus()
        {
            try
            {
                using var sc = new ServiceController(ServiceName);
                if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                    return BackupWorkerStatus.RunningAsService;

                if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
                    return BackupWorkerStatus.Stopped;
            }
            catch (InvalidOperationException)
            {
                // Service not registered
            }
            catch
            {
                // Ignore service query errors
            }

            // Check if running as background process
            var processes = Process.GetProcessesByName(ProcessName);
            if (processes.Length > 0)
                return BackupWorkerStatus.RunningAsProcess;

            // Check heartbeat freshness (within last 2 minutes)
            if (IsHeartbeatFresh(TimeSpan.FromMinutes(2)))
                return BackupWorkerStatus.RunningAsProcess;

            return BackupWorkerStatus.Stopped;
        }

        public static bool IsHeartbeatFresh(TimeSpan maxAge)
        {
            try
            {
                string path = GetHeartbeatFilePath();
                if (!File.Exists(path))
                    return false;

                string json = File.ReadAllText(path);
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("Timestamp", out var tsEl) &&
                    tsEl.TryGetDateTime(out var dt))
                {
                    return DateTime.UtcNow - dt < maxAge;
                }
            }
            catch
            {
                // Ignore parsing errors
            }
            return false;
        }

        public static void WriteHeartbeat(int processId)
        {
            try
            {
                string path = GetHeartbeatFilePath();
                var data = new
                {
                    ProcessId = processId,
                    Timestamp = DateTime.UtcNow
                };
                File.WriteAllText(path, JsonSerializer.Serialize(data));
            }
            catch
            {
                // Ignore heartbeat write errors
            }
        }

        public static string? FindWorkerExecutable()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Check same directory
            string sameDirExe = Path.Combine(baseDir, "Foxoft.BackupWorker.exe");
            if (File.Exists(sameDirExe))
                return sameDirExe;

            // Check sibling project bin directory
            string siblingPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "Foxoft.BackupWorker", "bin", "Debug", "net8.0-windows", "Foxoft.BackupWorker.exe"));
            if (File.Exists(siblingPath))
                return siblingPath;

            string siblingRelease = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "Foxoft.BackupWorker", "bin", "Release", "net8.0-windows", "Foxoft.BackupWorker.exe"));
            if (File.Exists(siblingRelease))
                return siblingRelease;

            return null;
        }

        public static bool IsRunning()
        {
            var status = GetStatus();
            return status == BackupWorkerStatus.RunningAsService || status == BackupWorkerStatus.RunningAsProcess;
        }

        public static void EnsureRunning(bool autoBackupEnabled)
        {
            try
            {
                if (autoBackupEnabled)
                {
                    if (!IsRunning())
                    {
                        Start();
                    }
                }
                else
                {
                    if (IsRunning())
                    {
                        Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BackupWorkerManager.EnsureRunning error: {ex.Message}");
            }
        }

        public static bool Start()
        {
            try
            {
                // Try starting as Windows service first
                using var sc = new ServiceController(ServiceName);
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    return true;
                }
                else if (sc.Status == ServiceControllerStatus.Running)
                {
                    return true;
                }
            }
            catch
            {
                // If service is not registered, fall back to background process
            }

            if (Process.GetProcessesByName(ProcessName).Length > 0)
                return true;

            string? exePath = FindWorkerExecutable();
            if (string.IsNullOrEmpty(exePath) || !File.Exists(exePath))
                return false;

            string conn = Properties.Settings.Default.SubConnString;
            if (string.IsNullOrWhiteSpace(conn))
            {
                try
                {
                    using var tempCtx = new Models.subContext();
                    conn = Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.GetConnectionString(tempCtx.Database) ?? string.Empty;
                }
                catch
                {
                }
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = !string.IsNullOrWhiteSpace(conn) ? $"--connection \"{conn}\"" : string.Empty,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Path.GetDirectoryName(exePath)
            };

            Process.Start(startInfo);
            return true;
        }

        public static bool Stop()
        {
            bool stoppedAny = false;

            try
            {
                using var sc = new ServiceController(ServiceName);
                if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.Paused)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    stoppedAny = true;
                }
            }
            catch
            {
                // Ignore service errors
            }

            var processes = Process.GetProcessesByName(ProcessName);
            foreach (var p in processes)
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(3000);
                    stoppedAny = true;
                }
                catch
                {
                    // Ignore kill errors
                }
            }

            return stoppedAny;
        }

        public static (bool success, string output) InstallService()
        {
            string? exePath = FindWorkerExecutable();
            if (string.IsNullOrEmpty(exePath) || !File.Exists(exePath))
                return (false, "Foxoft.BackupWorker.exe faylı tapılmadı.");

            var psi = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = $"create {ServiceName} binPath= \"\\\"{exePath}\\\" --service\" start= auto DisplayName= \"Foxoft Automated Backup Service\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using var proc = Process.Start(psi);
            proc?.WaitForExit();
            string output = proc?.StandardOutput.ReadToEnd() ?? string.Empty;
            return (proc?.ExitCode == 0, output);
        }

        public static (bool success, string output) UninstallService()
        {
            Stop();

            var psi = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = $"delete {ServiceName}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using var proc = Process.Start(psi);
            proc?.WaitForExit();
            string output = proc?.StandardOutput.ReadToEnd() ?? string.Empty;
            return (proc?.ExitCode == 0, output);
        }
    }
}
