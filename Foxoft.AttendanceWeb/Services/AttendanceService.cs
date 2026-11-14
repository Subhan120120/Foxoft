using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxoft.AttendanceWeb.Models;
using Foxoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IAttendanceService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest request);
        Task<PunchResponse> ProcessPunchAsync(PunchRequest request, HttpContext httpContext);
        Task<List<TodayLogDto>> GetTodayLogsAsync(string currAccCode);
        Task<List<DcCurrAcc>> GetStoresAsync();
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly string _connectionString;
        private readonly IQrTokenService _qrService;
        private readonly IGeolocationService _geoService;
        private readonly IIpValidationService _ipService;
        private readonly IDeviceLockService _deviceLockService;
        private readonly IAttendanceConfigStore _configStore;

        public AttendanceService(
            IConfiguration configuration,
            IQrTokenService qrService,
            IGeolocationService geoService,
            IIpValidationService ipService,
            IDeviceLockService deviceLockService,
            IAttendanceConfigStore configStore)
        {
            _connectionString = configuration.GetConnectionString("SubConnString")
                ?? "Data Source=.\\SUBSQL;Initial Catalog=Tokla;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=sql123_;Encrypt=False;";

            _qrService = qrService;
            _geoService = geoService;
            _ipService = ipService;
            _deviceLockService = deviceLockService;
            _configStore = configStore;
        }

        private subContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<subContext>();
            optionsBuilder.UseSqlServer(_connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), new[] { 233 });
            });
            return new subContext(optionsBuilder.Options);
        }

        public async Task<List<DcCurrAcc>> GetStoresAsync()
        {
            await using var db = CreateDbContext();
            return await db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Store && !x.IsDisabled)
                .OrderBy(x => x.CurrAccDesc)
                .ToListAsync();
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CurrAccCode))
                return new LoginResponse { Success = false, Message = "İşçi kodu boş ola bilməz." };

            await using var db = CreateDbContext();

            string code = request.CurrAccCode.Trim();

            var employee = await db.DcCurrAccs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CurrAccCode == code && x.CurrAccTypeCode == CurrAccType.Personnel);

            if (employee == null)
            {
                return new LoginResponse { Success = false, Message = "Bu koda uyğun işçi tapılmadı." };
            }

            if (employee.IsDisabled)
            {
                return new LoginResponse { Success = false, Message = "İşçinin hesabı deaktiv edilib." };
            }

            // Şifrə yoxlanışı: Əgər işçidə şifrə təyin edilibsə yoxlayırıq, yoxdursa FİN kodla və ya şifrəsiz
            if (!string.IsNullOrWhiteSpace(employee.NewPassword))
            {
                if (string.IsNullOrWhiteSpace(request.Password) || employee.NewPassword.Trim() != request.Password.Trim())
                {
                    return new LoginResponse { Success = false, Message = "Şifrə yalnışdır." };
                }
            }
            else if (!string.IsNullOrWhiteSpace(employee.IdentityNum) && !string.IsNullOrWhiteSpace(request.Password))
            {
                if (employee.IdentityNum.Trim().ToUpperInvariant() != request.Password.Trim().ToUpperInvariant())
                {
                    return new LoginResponse { Success = false, Message = "Şifrə və ya FİN kod yalnışdır." };
                }
            }

            string empName = (!string.IsNullOrWhiteSpace(employee.CurrAccDesc)
                ? employee.CurrAccDesc
                : $"{employee.FirstName} {employee.LastName}").Trim();

            // Filial məlumatı
            string storeName = employee.StoreCode ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(employee.StoreCode))
            {
                var store = await db.DcCurrAccs.AsNoTracking().FirstOrDefaultAsync(x => x.CurrAccCode == employee.StoreCode);
                if (store != null)
                    storeName = store.CurrAccDesc ?? store.CurrAccCode;
            }

            // Cihaz Kilidi yoxlanışı
            bool isDeviceLocked = false;
            bool boundToCurrent = false;

            var existingLock = _configStore.GetDeviceLockByEmployee(employee.CurrAccCode);
            if (existingLock != null)
            {
                isDeviceLocked = true;
                boundToCurrent = string.Equals(existingLock.DeviceId, request.DeviceId, StringComparison.OrdinalIgnoreCase);
            }

            return new LoginResponse
            {
                Success = true,
                Message = "Giriş uğurludur.",
                CurrAccCode = employee.CurrAccCode,
                EmployeeName = empName,
                StoreCode = employee.StoreCode,
                StoreName = storeName,
                IsDeviceLocked = isDeviceLocked,
                DeviceBoundToCurrent = boundToCurrent
            };
        }

        public async Task<PunchResponse> ProcessPunchAsync(PunchRequest request, HttpContext httpContext)
        {
            if (string.IsNullOrWhiteSpace(request.CurrAccCode))
                return new PunchResponse { Success = false, Message = "İşçi kodu boş ola bilməz." };

            await using var db = CreateDbContext();

            string code = request.CurrAccCode.Trim();

            var employee = await db.DcCurrAccs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CurrAccCode == code && x.CurrAccTypeCode == CurrAccType.Personnel);

            if (employee == null)
                return new PunchResponse { Success = false, Message = "İşçi tapılmadı." };

            if (employee.IsDisabled)
                return new PunchResponse { Success = false, Message = "İşçi hesabı deaktivdir." };

            string empName = (!string.IsNullOrWhiteSpace(employee.CurrAccDesc)
                ? employee.CurrAccDesc
                : $"{employee.FirstName} {employee.LastName}").Trim();

            string clientIp = _ipService.GetClientIp(httpContext);

            // Qlobal ERP Tənzimləmələri (DcAttendanceSettings)
            bool globalRequireQr = true;
            bool globalRequireGps = true;
            bool globalRequireDeviceLock = true;

            try
            {
                var globalSetting = await db.DcAttendanceSettings.AsNoTracking().FirstOrDefaultAsync();
                if (globalSetting != null)
                {
                    globalRequireQr = globalSetting.RequireDynamicQrCode;
                    globalRequireGps = globalSetting.RequireGpsGeofencing;
                    globalRequireDeviceLock = globalSetting.RequireDeviceLock;
                }
            }
            catch
            {
                // Əgər bazada yeni sütunlar hələ yoxdursa default true saxlanılır
            }

            string targetStoreCode = employee.StoreCode ?? string.Empty;
            string targetStoreName = targetStoreCode;

            // ==========================================
            // TƏHLÜKƏSİZLİK QATI 1: DİNAMİK QR KOD
            // ==========================================
            bool shouldEnforceQr = globalRequireQr;

            if (!string.IsNullOrWhiteSpace(request.QrToken))
            {
                if (!_qrService.ValidateToken(request.QrToken, out var qrStoreCode, out var qrError))
                {
                    if (shouldEnforceQr)
                    {
                        return new PunchResponse
                        {
                            Success = false,
                            Message = $"Dinamik QR Kod xətası: {qrError}",
                            ClientIp = clientIp
                        };
                    }
                }
                else if (!string.IsNullOrWhiteSpace(qrStoreCode))
                {
                    targetStoreCode = qrStoreCode;
                }
            }
            else if (shouldEnforceQr)
            {
                return new PunchResponse
                {
                    Success = false,
                    Message = "Dinamik QR Kod məcburidir! Zəhmət olmasa ekrandakı QR Kodu oxudun.",
                    ClientIp = clientIp
                };
            }

            // Filial məlumatı və Qaydalar
            var storeObj = await db.DcCurrAccs.AsNoTracking().FirstOrDefaultAsync(x => x.CurrAccCode == targetStoreCode);
            if (storeObj != null)
                targetStoreName = storeObj.CurrAccDesc ?? storeObj.CurrAccCode;

            var storeRule = _configStore.GetStoreRule(targetStoreCode, targetStoreName);

            // ==========================================
            // TƏHLÜKƏSİZLİK QATI 2: STATİK WI-FI IP
            // ==========================================
            if (storeRule.EnforceWifiIp && storeRule.AllowedWifiIps.Count > 0)
            {
                bool isIpValid = _ipService.IsIpAllowed(clientIp, storeRule.AllowedWifiIps);
                if (!isIpValid)
                {
                    return new PunchResponse
                    {
                        Success = false,
                        Message = $"Təhlükəsizlik Xətası: Siz filialın icazəli Wi-Fi şəbəkəsinə qoşulmamısınız! (Cari IP: {clientIp})",
                        ClientIp = clientIp,
                        StoreCode = targetStoreCode,
                        StoreName = targetStoreName
                    };
                }
            }

            // ==========================================
            // TƏHLÜKƏSİZLİK QATI 3: GPS GEOFENCING
            // ==========================================
            double? calculatedDistance = null;
            bool shouldEnforceGps = globalRequireGps;

            if (shouldEnforceGps)
            {
                if (!request.Latitude.HasValue || !request.Longitude.HasValue)
                {
                    return new PunchResponse
                    {
                        Success = false,
                        Message = "GPS Xətası: Cihazınızın GPS koordinatları əldə edilmədi. Zəhmət olmasa brauzerdə məkana icazə verin.",
                        ClientIp = clientIp,
                        StoreCode = targetStoreCode,
                        StoreName = targetStoreName
                    };
                }

                bool isWithinRadius = _geoService.ValidateLocation(
                    request.Latitude.Value,
                    request.Longitude.Value,
                    storeRule.Latitude,
                    storeRule.Longitude,
                    storeRule.AllowedRadiusMeters,
                    out double dist);

                calculatedDistance = dist;

                if (!isWithinRadius)
                {
                    return new PunchResponse
                    {
                        Success = false,
                        Message = $"Məsafə Xətası: Siz filial ərazisində deyilsiniz! Məsafə: {dist:F0} metr (İcazə verilən radius: {storeRule.AllowedRadiusMeters:F0} metr).",
                        DistanceMeters = dist,
                        ClientIp = clientIp,
                        StoreCode = targetStoreCode,
                        StoreName = targetStoreName
                    };
                }
            }
            else if (request.Latitude.HasValue && request.Longitude.HasValue)
            {
                calculatedDistance = _geoService.CalculateDistanceMeters(
                    request.Latitude.Value, request.Longitude.Value, storeRule.Latitude, storeRule.Longitude);
            }

            // ==========================================
            // TƏHLÜKƏSİZLİK QATI 4: CİHAZ TOKENİ (DEVICE LOCK)
            // ==========================================
            bool shouldEnforceDeviceLock = globalRequireDeviceLock;

            if (shouldEnforceDeviceLock)
            {
                if (string.IsNullOrWhiteSpace(request.DeviceId))
                {
                    return new PunchResponse
                    {
                        Success = false,
                        Message = "Cihaz identifikatoru (Device Token) tələb olunur.",
                        ClientIp = clientIp
                    };
                }

                bool isDeviceValid = _deviceLockService.ValidateOrBindDevice(
                    employee.CurrAccCode,
                    empName,
                    request.DeviceId,
                    request.DeviceName,
                    out string? deviceError);

                if (!isDeviceValid)
                {
                    return new PunchResponse
                    {
                        Success = false,
                        Message = deviceError ?? "Cihaz təhlükəsizlik yoxlanışından keçmədi.",
                        ClientIp = clientIp,
                        StoreCode = targetStoreCode,
                        StoreName = targetStoreName
                    };
                }
            }

            // ==========================================
            // PUNCH TYPE (CheckIn / CheckOut) MÜƏYYƏNLƏŞDİRMƏ
            // ==========================================
            DateTime now = DateTime.Now;
            DateTime todayStart = now.Date;
            DateTime todayEnd = todayStart.AddDays(1);

            PunchType finalPunchType = request.PunchType;

            if (finalPunchType == PunchType.AutoDetect)
            {
                // İşçinin bugünkü son loguna baxırıq
                var lastLog = await db.TrAttendanceLogs.AsNoTracking()
                    .Where(x => x.CurrAccCode == employee.CurrAccCode && x.LogDateTime >= todayStart && x.LogDateTime < todayEnd)
                    .OrderByDescending(x => x.LogDateTime)
                    .FirstOrDefaultAsync();

                if (lastLog == null || lastLog.PunchType == PunchType.CheckOut)
                {
                    finalPunchType = PunchType.CheckIn;
                }
                else
                {
                    finalPunchType = PunchType.CheckOut;
                }
            }

            // ==========================================
            // TrAttendanceLogs CƏDVƏLİNƏ INSERT
            // ==========================================
            string locationText = $"{targetStoreName}";
            if (calculatedDistance.HasValue)
                locationText += $" (GPS: {request.Latitude:F4},{request.Longitude:F4}, ~{calculatedDistance:F0}m)";
            else
                locationText += $" (IP: {clientIp})";

            if (locationText.Length > 100)
                locationText = locationText[..100];

            string deviceCode = request.DeviceId.Length > 50 ? request.DeviceId[..50] : request.DeviceId;

            var logEntry = new TrAttendanceLog
            {
                Id = Guid.NewGuid(),
                CurrAccCode = employee.CurrAccCode,
                DeviceCode = deviceCode,
                LogDateTime = now,
                PunchType = finalPunchType,
                SourceMethod = PunchSourceMethod.MobileWeb,
                Location = locationText,
                IsIgnored = false,
                CreatedDate = now,
                CreatedUserName = "WebAttendance"
            };

            db.TrAttendanceLogs.Add(logEntry);
            await db.SaveChangesAsync();

            string punchDesc = finalPunchType == PunchType.CheckIn ? "İşə Giriş" :
                               finalPunchType == PunchType.CheckOut ? "İşdən Çıxış" : finalPunchType.ToString();

            return new PunchResponse
            {
                Success = true,
                Message = $"{punchDesc} uğurla qeydə alındı!",
                PunchType = punchDesc,
                Time = now.ToString("HH:mm:ss"),
                Location = locationText,
                StoreCode = targetStoreCode,
                StoreName = targetStoreName,
                DistanceMeters = calculatedDistance,
                ClientIp = clientIp
            };
        }

        public async Task<List<TodayLogDto>> GetTodayLogsAsync(string currAccCode)
        {
            if (string.IsNullOrWhiteSpace(currAccCode)) return new();

            await using var db = CreateDbContext();
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            var logs = await db.TrAttendanceLogs.AsNoTracking()
                .Where(x => x.CurrAccCode == currAccCode && x.LogDateTime >= today && x.LogDateTime < tomorrow)
                .OrderByDescending(x => x.LogDateTime)
                .Select(x => new TodayLogDto
                {
                    Id = x.Id,
                    LogDateTime = x.LogDateTime,
                    PunchTypeDesc = x.PunchType == PunchType.CheckIn ? "Giriş" :
                                    x.PunchType == PunchType.CheckOut ? "Çıxış" : x.PunchType.ToString(),
                    Location = x.Location,
                    DeviceCode = x.DeviceCode,
                    IsIgnored = x.IsIgnored
                })
                .ToListAsync();

            return logs;
        }
    }
}
