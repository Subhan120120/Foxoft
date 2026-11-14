using System;
using System.Collections.Generic;
using Foxoft.AttendanceWeb.Models;
using Foxoft.Models;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IDeviceLockService
    {
        bool ValidateOrBindDevice(string currAccCode, string employeeName, string deviceId, string? deviceName, out string? errorMessage);
        List<EmployeeDeviceLock> GetAllLocks();
        bool UnlockEmployeeDevice(string currAccCode);
    }

    public class DeviceLockService : IDeviceLockService
    {
        private readonly IAttendanceConfigStore _store;

        public DeviceLockService(IAttendanceConfigStore store)
        {
            _store = store;
        }

        public bool ValidateOrBindDevice(string currAccCode, string employeeName, string deviceId, string? deviceName, out string? errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(currAccCode))
            {
                errorMessage = "İşçi kodu təyin edilməyib.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(deviceId))
            {
                errorMessage = "Cihaz identifikatoru (Device ID) tapılmadı.";
                return false;
            }

            // Qayda 1: Bu cihaz başqa bir işçiyə bağlanıbmı?
            var existingDeviceOwner = _store.GetDeviceLockByDevice(deviceId);
            if (existingDeviceOwner != null && !string.Equals(existingDeviceOwner.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = $"Bu telefon artıq başqa bir işçiyə ({existingDeviceOwner.EmployeeName}) kilidlənib! Bir telefondan yalnız bir profil istifadə edə bilər.";
                return false;
            }

            // Qayda 2: Bu işçi artıq başqa bir cihaza bağlanıbmı?
            var existingEmployeeLock = _store.GetDeviceLockByEmployee(currAccCode);
            if (existingEmployeeLock != null)
            {
                if (!string.Equals(existingEmployeeLock.DeviceId, deviceId, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "Sizin profiliniz başqa bir telefona kilidlənib. Yalnız öz təsdiqlənmiş telefonunuzdan istifadə edə bilərsiniz. Cihazı dəyişmək üçün rəhbərliyə müraciət edin.";
                    return false;
                }

                // Eyni cihazdır, son istifadə vaxtını yeniləyirik
                existingEmployeeLock.LastUsedAt = DateTime.UtcNow;
                if (!string.IsNullOrWhiteSpace(deviceName))
                    existingEmployeeLock.DeviceName = deviceName;

                _store.SaveDeviceLock(existingEmployeeLock);
                return true;
            }

            // Qayda 3: Hələ heç kimə bağlanmayıb — bu cihazı ilk dəfə işçiyə bağlayırıq (Device Lock Aktivləşdirilir)
            var newLock = new EmployeeDeviceLock
            {
                CurrAccCode = currAccCode,
                EmployeeName = employeeName,
                DeviceId = deviceId,
                DeviceName = deviceName ?? "Mobile Browser",
                RegisteredAt = DateTime.UtcNow,
                LastUsedAt = DateTime.UtcNow,
                IsLocked = true
            };

            _store.SaveDeviceLock(newLock);
            return true;
        }

        public List<EmployeeDeviceLock> GetAllLocks()
        {
            return _store.GetAllDeviceLocks();
        }

        public bool UnlockEmployeeDevice(string currAccCode)
        {
            return _store.UnlockDevice(currAccCode);
        }
    }
}
