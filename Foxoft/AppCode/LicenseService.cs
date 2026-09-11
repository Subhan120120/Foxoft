using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Foxoft.AppCode
{
    public enum LicenseStatus
    {
        Valid,
        CompanyNotSelected,
        EmptyLicense,
        CorruptedLicense,
        InvalidFormat,
        CompanyMismatch,
        HardwareMismatch,
        Expired,
        DatabaseConnectionError
    }

    public class LicenseValidationResult
    {
        public bool IsValid { get; set; }
        public LicenseStatus Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? CompanyCode { get; set; }
        public string? HardwareId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? RemainingDays { get; set; }
        public bool IsExpiringSoon => IsValid && RemainingDays.HasValue && RemainingDays.Value <= 14;
    }

    public class LicenseData
    {
        public string CompanyCode { get; set; } = string.Empty;
        public string HardwareId { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }

    public static class LicenseService
    {
        private const string AesKey = "FoxoftIsTheBestP";
        private const string AesIv = "ThisIsAnInitVect";

        /// <summary>
        /// Seçilmiş şirkət və ya databazaya (companyCode) əsasən lisenziyanı hərtərəfli yoxlayır.
        /// </summary>
        /// <param name="companyCode">Seçilən şirkət kodu (Initial Catalog)</param>
        /// <param name="customConnString">İstəyə bağlı fərdi connection string</param>
        /// <returns>Ətraflı LicenseValidationResult</returns>
        public static LicenseValidationResult ValidateLicense(string? companyCode, string? customConnString = null)
        {
            if (string.IsNullOrWhiteSpace(companyCode))
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.CompanyNotSelected,
                    Message = Resources.Form_Login_CompanyRequired
                };
            }

            string baseConnString = customConnString ?? Settings.Default.SubConnString;
            if (string.IsNullOrWhiteSpace(baseConnString))
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.DatabaseConnectionError,
                    CompanyCode = companyCode,
                    Message = string.Format(Resources.Form_Login_DatabaseConnectionFailed, companyCode)
                };
            }

            try
            {
                SqlConnectionStringBuilder builder = new(baseConnString)
                {
                    InitialCatalog = companyCode
                };

                string targetConnString = SqlLanguageHelper.GetLocalizedConnectionString(builder.ConnectionString);

                DbContextOptionsBuilder<subContext> optionsBuilder = new();
                optionsBuilder.UseSqlServer(targetConnString);

                using var db = new subContext(optionsBuilder.Options);
                if (!db.Database.CanConnect())
                {
                    return new LicenseValidationResult
                    {
                        IsValid = false,
                        Status = LicenseStatus.DatabaseConnectionError,
                        CompanyCode = companyCode,
                        Message = string.Format(Resources.Form_Login_DatabaseConnectionFailed, companyCode)
                    };
                }

                AppSetting? appSetting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
                string? licenseCipher = appSetting?.License;

                string actualDbName = db.Database.GetDbConnection().Database;
                return ValidateLicenseString(licenseCipher, companyCode, actualDbName);
            }
            catch (Exception ex)
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.DatabaseConnectionError,
                    CompanyCode = companyCode,
                    Message = string.Format(Resources.Form_Login_DatabaseConnectionFailed, ex.Message)
                };
            }
        }

        /// <summary>
        /// Şifrələnmiş lisenziya mətnini verilmiş şirkət kodu və baza adı ilə yoxlayır.
        /// </summary>
        public static LicenseValidationResult ValidateLicenseString(string? cipherText, string selectedCompanyCode, string? databaseName = null)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.EmptyLicense,
                    CompanyCode = selectedCompanyCode,
                    Message = Resources.Form_Login_LicenseNotFound
                };
            }

            LicenseData? licenseData;
            try
            {
                licenseData = DecryptLicense(cipherText);
            }
            catch (Exception)
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.CorruptedLicense,
                    CompanyCode = selectedCompanyCode,
                    Message = Resources.Form_Login_LicenseCorrupted
                };
            }

            if (licenseData == null)
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.InvalidFormat,
                    CompanyCode = selectedCompanyCode,
                    Message = Resources.Form_Login_LicenseCorrupted
                };
            }

            // 1. Şirkət kodu və Baza uyğunluğu yoxlanışı (case-insensitive)
            bool companyMatches = string.Equals(licenseData.CompanyCode, selectedCompanyCode, StringComparison.OrdinalIgnoreCase);
            bool dbMatches = string.IsNullOrEmpty(databaseName) || string.Equals(licenseData.CompanyCode, databaseName, StringComparison.OrdinalIgnoreCase);

            if (!companyMatches || !dbMatches)
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.CompanyMismatch,
                    CompanyCode = licenseData.CompanyCode,
                    HardwareId = licenseData.HardwareId,
                    ExpirationDate = licenseData.DueDate,
                    Message = string.Format(Resources.Form_Login_LicenseCompanyMismatch, selectedCompanyCode)
                };
            }

            // 2. Kompüter/Aparat uyğunluğu yoxlanışı
            if (!IsHardwareMatching(licenseData.HardwareId))
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.HardwareMismatch,
                    CompanyCode = licenseData.CompanyCode,
                    HardwareId = licenseData.HardwareId,
                    ExpirationDate = licenseData.DueDate,
                    Message = Resources.Form_Login_LicenseHardwareMismatch
                };
            }

            // 3. Tarix və bitmə vaxtı yoxlanışı (günün sonuna qədər etibarlı: Date >= Today)
            int remainingDays = (licenseData.DueDate.Date - DateTime.Today).Days;
            if (remainingDays < 0)
            {
                return new LicenseValidationResult
                {
                    IsValid = false,
                    Status = LicenseStatus.Expired,
                    CompanyCode = licenseData.CompanyCode,
                    HardwareId = licenseData.HardwareId,
                    ExpirationDate = licenseData.DueDate,
                    RemainingDays = remainingDays,
                    Message = string.Format(Resources.Form_Login_LicenseExpired, licenseData.DueDate.ToString("dd.MM.yyyy"))
                };
            }

            // Uğurlu lisenziya
            string warningMessage = remainingDays <= 14
                ? string.Format(Resources.Form_Login_LicenseExpiringSoon, remainingDays, licenseData.DueDate.ToString("dd.MM.yyyy"))
                : string.Empty;

            return new LicenseValidationResult
            {
                IsValid = true,
                Status = LicenseStatus.Valid,
                CompanyCode = licenseData.CompanyCode,
                HardwareId = licenseData.HardwareId,
                ExpirationDate = licenseData.DueDate,
                RemainingDays = remainingDays,
                Message = warningMessage
            };
        }

        /// <summary>
        /// Lisenziya mətnini AES ilə şifrələyir.
        /// Format: companyCode+hardwareId+yyyyMMdd
        /// </summary>
        public static string EncryptLicense(string companyCode, string hardwareId, DateTime dueDate)
        {
            string plainText = $"{companyCode.Trim()}+{hardwareId.Trim()}+{dueDate:yyyyMMdd}";
            return EncryptString(plainText, AesKey, AesIv);
        }

        /// <summary>
        /// Şifrələnmiş mətni açır və LicenseData obyektinə çevirir.
        /// </summary>
        public static LicenseData? DecryptLicense(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                return null;

            string decrypted = DecryptString(cipherText, AesKey, AesIv);
            string[] parts = decrypted.Split('+', 3);

            if (parts.Length < 3)
                return null;

            string companyCode = parts[0].Trim();
            string hardwareId = parts[1].Trim();
            string dateStr = parts[2].Trim();

            if (!DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
                return null;

            return new LicenseData
            {
                CompanyCode = companyCode,
                HardwareId = hardwareId,
                DueDate = dueDate
            };
        }

        /// <summary>
        /// Cari kompüterin ilkin aparat açarını qaytarır (Açarı götür / Get Key üçün).
        /// Mövcud sistemlə 100% geriyə uyğunluğu qoruyur.
        /// </summary>
        public static string GetHardwareId()
        {
            string legacyId = GetLegacyPhysicalAddress();
            if (!string.IsNullOrEmpty(legacyId))
                return legacyId;

            // Fallback: birinci aktiv Ethernet və ya Wi-Fi fiziki adapteri
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                    nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    continue;

                PhysicalAddress pa = nic.GetPhysicalAddress();
                string mac = pa.ToString();
                if (!string.IsNullOrEmpty(mac) && mac != "000000000000")
                {
                    return nic.Id + mac;
                }
            }

            return Environment.MachineName;
        }

        /// <summary>
        /// Verilmiş lisenziya aparat açarının cari kompüterlə uyğun gəlib-gəlmədiyini yoxlayır.
        /// Bütün namizəd adapter açarlarını yoxladığı üçün adapter sırasının dəyişməsi lisenziyanı qırmır.
        /// </summary>
        public static bool IsHardwareMatching(string licenseHardwareId)
        {
            if (string.IsNullOrWhiteSpace(licenseHardwareId))
                return false;

            HashSet<string> candidates = GetCandidateHardwareIds();
            return candidates.Contains(licenseHardwareId.Trim());
        }

        /// <summary>
        /// Cari kompüterin bütün potensial aparat açarlarını toplayır.
        /// </summary>
        public static HashSet<string> GetCandidateHardwareIds()
        {
            HashSet<string> candidates = new(StringComparer.OrdinalIgnoreCase);

            string legacy = GetLegacyPhysicalAddress();
            if (!string.IsNullOrEmpty(legacy))
                candidates.Add(legacy.Trim());

            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                        nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                        continue;

                    PhysicalAddress pa = nic.GetPhysicalAddress();
                    string mac = pa.ToString();

                    if (!string.IsNullOrEmpty(mac) && mac != "000000000000")
                    {
                        candidates.Add((nic.Id + mac).Trim());
                        candidates.Add(mac.Trim());
                    }
                }
            }
            catch
            {
                // Şəbəkə adapterlərini oxumaqda xəta baş verərsə davam et
            }

            return candidates;
        }

        private static string GetLegacyPhysicalAddress()
        {
            string fiscal = string.Empty;
            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.Name.StartsWith("Ethernet", StringComparison.OrdinalIgnoreCase))
                        fiscal = nic.Id + pInterfaceProperties;
                    else if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && nic.Name.StartsWith("Wi-Fi", StringComparison.OrdinalIgnoreCase))
                        fiscal = nic.Id + pInterfaceProperties;
                }
            }
            catch
            {
                // Ignore
            }

            return fiscal;
        }

        public static string EncryptString(string plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = keyBytes;
            aesAlg.IV = ivBytes;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new(csEncrypt, Encoding.UTF8))
                {
                    swEncrypt.Write(plainText);
                }
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string DecryptString(string cipherText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = keyBytes;
            aesAlg.IV = ivBytes;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipherTextBytes);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt, Encoding.UTF8);

            return srDecrypt.ReadToEnd();
        }

        /// <summary>
        /// Lisenziyanın bitməsinə az qaldıqda (IsExpiringSoon) bildirişi mərkəzləşdirilmiş bildiriş sisteminə ötürür.
        /// </summary>
        public static async Task PublishExpiringSoonNotificationAsync(
            string companyCode,
            LicenseValidationResult licenseResult,
            string? actorCurrAccCode = null,
            CancellationToken ct = default)
        {
            if (!licenseResult.IsExpiringSoon || licenseResult.ExpirationDate == null)
                return;

            try
            {
                string baseConnString = Settings.Default.SubConnString;
                if (string.IsNullOrWhiteSpace(baseConnString))
                    return;

                SqlConnectionStringBuilder builder = new(baseConnString)
                {
                    InitialCatalog = companyCode
                };
                string targetConnString = SqlLanguageHelper.GetLocalizedConnectionString(builder.ConnectionString);

                DbContextOptionsBuilder<subContext> optionsBuilder = new();
                optionsBuilder.UseSqlServer(targetConnString);

                using var db = new subContext(optionsBuilder.Options);
                if (!db.Database.CanConnect())
                    return;

                NotificationService notificationService = new(db);

                string notificationKey = $"LicenseExpireSoon_{companyCode}_{licenseResult.ExpirationDate.Value:yyyyMMdd}";
                int remainingDays = licenseResult.RemainingDays ?? 0;
                string expDateStr = licenseResult.ExpirationDate.Value.ToString("dd.MM.yyyy");

                Dictionary<string, string> placeholders = new(StringComparer.OrdinalIgnoreCase)
                {
                    ["CompanyCode"] = companyCode,
                    ["RemainingDays"] = remainingDays.ToString(),
                    ["ExpirationDate"] = expDateStr
                };

                string title = Resources.Notification_LicenseExpireSoon_Title;
                string body = !string.IsNullOrEmpty(licenseResult.Message)
                    ? licenseResult.Message
                    : string.Format(Resources.Form_Login_LicenseExpiringSoon, remainingDays, expDateStr);

                var notification = await notificationService.CreateOrUpdateAsync(new NotificationCreateRequest(
                    NotificationTypeCode: NotificationTypeCodes.LicenseExpireSoon,
                    NotificationKey: notificationKey,
                    Severity: NotificationSeverities.Warning,
                    Title: title,
                    Body: body,
                    EntityType: "License",
                    EntityKey: companyCode,
                    StoreCode: null,
                    Placeholders: placeholders,
                    ExpireDate: licenseResult.ExpirationDate.Value.AddDays(1)
                ), ct);

                if (notification != null)
                {
                    bool hasRecipients = await db.TrNotificationRecipients
                        .AnyAsync(r => r.NotificationId == notification.NotificationId, ct);

                    if (!hasRecipients)
                    {
                        HashSet<string> targetUsers = new(StringComparer.OrdinalIgnoreCase);

                        if (!string.IsNullOrWhiteSpace(actorCurrAccCode))
                            targetUsers.Add(actorCurrAccCode);

                        List<string> adminUsers = await db.TrCurrAccRoles
                            .Where(x => x.RoleCode == "Admin")
                            .Select(x => x.CurrAccCode)
                            .ToListAsync(ct);

                        foreach (string admin in adminUsers)
                            targetUsers.Add(admin);

                        if (targetUsers.Count == 0)
                        {
                            List<string> anyPersonnel = await db.DcCurrAccs
                                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel && !x.IsDisabled)
                                .Select(x => x.CurrAccCode)
                                .Take(5)
                                .ToListAsync(ct);

                            foreach (string p in anyPersonnel)
                                targetUsers.Add(p);
                        }

                        foreach (string user in targetUsers)
                        {
                            db.TrNotificationRecipients.Add(new TrNotificationRecipient
                            {
                                NotificationId = notification.NotificationId,
                                CurrAccCode = user,
                                Status = NotificationRecipientStatuses.Unread
                            });
                        }

                        await db.SaveChangesAsync(ct);
                    }
                }
            }
            catch
            {
                // Bildiriş xətası login prosesinə mane olmamalıdır
            }
        }
    }
}
