using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text.Json;

namespace Foxoft.AppCode
{
    public enum NotificationWorkerStatus
    {
        RunningAsService,
        RunningAsProcess,
        Stopped,
        NotInstalled
    }

    public static class NotificationWorkerManager
    {
        public const string ServiceName = "FoxoftNotificationWorker";
        public const string ProcessName = "Foxoft.NotificationWorker";

        public static string GetHeartbeatFilePath()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return Path.Combine(dir, "WorkerHeartbeat.json");
        }

        public static NotificationWorkerStatus GetStatus()
        {
            try
            {
                using var sc = new ServiceController(ServiceName);
                if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                    return NotificationWorkerStatus.RunningAsService;

                if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
                    return NotificationWorkerStatus.Stopped;
            }
            catch (InvalidOperationException)
            {
                // Service not installed, check process
            }
            catch
            {
                // Ignore service query errors
            }

            // Check if running as background process
            var processes = Process.GetProcessesByName(ProcessName);
            if (processes.Length > 0)
                return NotificationWorkerStatus.RunningAsProcess;

            // Check heartbeat freshness (within last 2 minutes)
            if (IsHeartbeatFresh(TimeSpan.FromMinutes(2)))
                return NotificationWorkerStatus.RunningAsProcess;

            return NotificationWorkerStatus.Stopped;
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
            string sameDirExe = Path.Combine(baseDir, "Foxoft.NotificationWorker.exe");
            if (File.Exists(sameDirExe))
                return sameDirExe;

            // Check sibling project bin directory
            string siblingPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "Foxoft.NotificationWorker", "bin", "Debug", "net8.0-windows", "Foxoft.NotificationWorker.exe"));
            if (File.Exists(siblingPath))
                return siblingPath;

            // Check release sibling
            string siblingRelease = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "Foxoft.NotificationWorker", "bin", "Release", "net8.0-windows", "Foxoft.NotificationWorker.exe"));
            if (File.Exists(siblingRelease))
                return siblingRelease;

            return null;
        }

        public static bool IsRunning()
        {
            var status = GetStatus();
            return status == NotificationWorkerStatus.RunningAsService || status == NotificationWorkerStatus.RunningAsProcess;
        }

        public static void EnsureRunning(bool autoSendEnabled)
        {
            try
            {
                if (autoSendEnabled)
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
                Debug.WriteLine($"NotificationWorkerManager.EnsureRunning error: {ex.Message}");
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
                // If service is not registered, start background process
            }

            string? exePath = FindWorkerExecutable();
            if (string.IsNullOrEmpty(exePath) || !File.Exists(exePath))
                return false;

            // If process is already running, return true
            if (Process.GetProcessesByName(ProcessName).Length > 0)
                return true;

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
    }
}
