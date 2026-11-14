using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Foxoft.Models;

namespace Foxoft.AppCode.Service
{
    public interface IAttendanceConfigStore
    {
        StoreAttendanceRule GetStoreRule(string storeCode, string? fallbackStoreName = null);
        List<StoreAttendanceRule> GetAllStoreRules();
        void SaveStoreRule(StoreAttendanceRule rule);

        List<EmployeeDeviceLock> GetAllDeviceLocks();
        EmployeeDeviceLock? GetDeviceLockByEmployee(string currAccCode);
        EmployeeDeviceLock? GetDeviceLockByDevice(string deviceId);
        void SaveDeviceLock(EmployeeDeviceLock deviceLock);
        bool UnlockDevice(string currAccCode);
    }

    public class AttendanceConfigFileModel
    {
        public List<StoreAttendanceRule> StoreRules { get; set; } = new();
        public List<EmployeeDeviceLock> DeviceLocks { get; set; } = new();
    }

    public class AttendanceConfigStore : IAttendanceConfigStore
    {
        private static readonly object _lockObj = new();
        private static string? _resolvedPath;
        private AttendanceConfigFileModel _cache = new();

        public AttendanceConfigStore(string? explicitPath = null)
        {
            if (!string.IsNullOrWhiteSpace(explicitPath))
            {
                _resolvedPath = explicitPath;
            }
            else if (_resolvedPath == null)
            {
                _resolvedPath = ResolveConfigFilePath();
            }

            LoadFromDisk();
        }

        public static string ResolveConfigFilePath()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var dir = new DirectoryInfo(baseDir);
                while (dir != null)
                {
                    string candidate = Path.Combine(dir.FullName, "Foxoft.AttendanceWeb", "App_Data");
                    if (Directory.Exists(candidate))
                        return Path.Combine(candidate, "attendance_config.json");

                    dir = dir.Parent;
                }
            }
            catch
            {
                // Fallback
            }

            string fallbackDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            if (!Directory.Exists(fallbackDir))
                Directory.CreateDirectory(fallbackDir);

            return Path.Combine(fallbackDir, "attendance_config.json");
        }

        private void LoadFromDisk()
        {
            lock (_lockObj)
            {
                string path = _resolvedPath ?? ResolveConfigFilePath();
                if (File.Exists(path))
                {
                    try
                    {
                        string json = File.ReadAllText(path);
                        var data = JsonSerializer.Deserialize<AttendanceConfigFileModel>(json);
                        if (data != null)
                        {
                            _cache = data;
                            return;
                        }
                    }
                    catch
                    {
                        // Fayl oxunmadıqda yeni boş data yaradılır
                    }
                }

                _cache = new AttendanceConfigFileModel();
                SaveToDisk();
            }
        }

        private void SaveToDisk()
        {
            lock (_lockObj)
            {
                string path = _resolvedPath ?? ResolveConfigFilePath();
                string? dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(_cache, options);
                File.WriteAllText(path, json);
            }
        }

        public StoreAttendanceRule GetStoreRule(string storeCode, string? fallbackStoreName = null)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                var rule = _cache.StoreRules.FirstOrDefault(x => string.Equals(x.StoreCode, storeCode, StringComparison.OrdinalIgnoreCase));
                if (rule == null)
                {
                    rule = new StoreAttendanceRule
                    {
                        StoreCode = storeCode,
                        StoreName = fallbackStoreName ?? storeCode,
                        Latitude = 40.4093,
                        Longitude = 49.8671,
                        AllowedRadiusMeters = 100.0,
                        AllowedWifiIps = new List<string> { "127.0.0.1", "::1" },
                        EnforceWifiIp = false,
                        EnforceGps = true,
                        EnforceQr = true,
                        EnforceDeviceLock = true
                    };
                    _cache.StoreRules.Add(rule);
                    SaveToDisk();
                }
                return rule;
            }
        }

        public List<StoreAttendanceRule> GetAllStoreRules()
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                return _cache.StoreRules.ToList();
            }
        }

        public void SaveStoreRule(StoreAttendanceRule rule)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                int index = _cache.StoreRules.FindIndex(x => string.Equals(x.StoreCode, rule.StoreCode, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    _cache.StoreRules[index] = rule;
                }
                else
                {
                    _cache.StoreRules.Add(rule);
                }
                SaveToDisk();
            }
        }

        public List<EmployeeDeviceLock> GetAllDeviceLocks()
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                return _cache.DeviceLocks.ToList();
            }
        }

        public EmployeeDeviceLock? GetDeviceLockByEmployee(string currAccCode)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                return _cache.DeviceLocks.FirstOrDefault(x => string.Equals(x.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase));
            }
        }

        public EmployeeDeviceLock? GetDeviceLockByDevice(string deviceId)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                return _cache.DeviceLocks.FirstOrDefault(x => string.Equals(x.DeviceId, deviceId, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void SaveDeviceLock(EmployeeDeviceLock deviceLock)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                int index = _cache.DeviceLocks.FindIndex(x => string.Equals(x.CurrAccCode, deviceLock.CurrAccCode, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    _cache.DeviceLocks[index] = deviceLock;
                }
                else
                {
                    _cache.DeviceLocks.Add(deviceLock);
                }
                SaveToDisk();
            }
        }

        public bool UnlockDevice(string currAccCode)
        {
            lock (_lockObj)
            {
                LoadFromDisk();
                int removed = _cache.DeviceLocks.RemoveAll(x => string.Equals(x.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase));
                if (removed > 0)
                {
                    SaveToDisk();
                    return true;
                }
                return false;
            }
        }
    }
}
