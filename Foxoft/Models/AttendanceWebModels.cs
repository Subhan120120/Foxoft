using System;
using System.Collections.Generic;

namespace Foxoft.Models
{
    public class StoreAttendanceRule
    {
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public double Latitude { get; set; } = 40.4093; // Default Bakı mərkəz
        public double Longitude { get; set; } = 49.8671;
        public double AllowedRadiusMeters { get; set; } = 100.0;
        public List<string> AllowedWifiIps { get; set; } = new();
        public bool EnforceWifiIp { get; set; } = false;
        public bool EnforceGps { get; set; } = true;
        public bool EnforceQr { get; set; } = true;
        public bool EnforceDeviceLock { get; set; } = true;
    }

    public class EmployeeDeviceLock
    {
        public string CurrAccCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string? DeviceName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUsedAt { get; set; } = DateTime.UtcNow;
        public bool IsLocked { get; set; } = true;
        public string? Notes { get; set; }
    }
}
