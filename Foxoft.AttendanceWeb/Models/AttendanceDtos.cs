using System;
using System.Collections.Generic;
using Foxoft.Models;

namespace Foxoft.AttendanceWeb.Models
{
    public class PunchRequest
    {
        public string CurrAccCode { get; set; } = string.Empty;
        public PunchType PunchType { get; set; } = PunchType.AutoDetect;
        public string QrToken { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string? DeviceName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Accuracy { get; set; }
    }

    public class PunchResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? PunchType { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public string? StoreCode { get; set; }
        public string? StoreName { get; set; }
        public double? DistanceMeters { get; set; }
        public string? ClientIp { get; set; }
    }

    public class LoginRequest
    {
        public string CurrAccCode { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string? DeviceName { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? CurrAccCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? StoreCode { get; set; }
        public string? StoreName { get; set; }
        public bool IsDeviceLocked { get; set; }
        public bool DeviceBoundToCurrent { get; set; }
    }

    public class KioskQrResponse
    {
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string QrToken { get; set; } = string.Empty;
        public string QrBase64 { get; set; } = string.Empty;
        public DateTime ExpiresAtUtc { get; set; }
        public int ValiditySeconds { get; set; }
    }

    public class TodayLogDto
    {
        public Guid Id { get; set; }
        public DateTime LogDateTime { get; set; }
        public string PunchTypeDesc { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? DeviceCode { get; set; }
        public bool IsIgnored { get; set; }
    }
}
