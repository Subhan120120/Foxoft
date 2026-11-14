using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using QRCoder;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IQrTokenService
    {
        (string token, string qrBase64, DateTime expiresAtUtc, int validitySeconds) GenerateKioskQr(string storeCode);
        bool ValidateToken(string qrToken, out string? storeCode, out string? errorReason);
    }

    public class QrTokenService : IQrTokenService
    {
        private readonly byte[] _hmacKey;
        private readonly int _validitySeconds;
        private readonly IMemoryCache _memoryCache;

        public QrTokenService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            string keyStr = configuration["AttendanceSettings:SecretKey"] ?? "Foxoft_Default_Secret_Hmac_Attendance_2026";
            _hmacKey = Encoding.UTF8.GetBytes(keyStr);

            if (!int.TryParse(configuration["AttendanceSettings:QrValiditySeconds"], out _validitySeconds) || _validitySeconds <= 0)
            {
                _validitySeconds = 30;
            }
        }

        public (string token, string qrBase64, DateTime expiresAtUtc, int validitySeconds) GenerateKioskQr(string storeCode)
        {
            if (string.IsNullOrWhiteSpace(storeCode))
                throw new ArgumentException("Filial kodu boş ola bilməz.", nameof(storeCode));

            long nowSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string nonce = Guid.NewGuid().ToString("N")[..8];
            string payload = $"{storeCode}|{nowSeconds}|{nonce}";

            string signature;
            using (var hmac = new HMACSHA256(_hmacKey))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                signature = Convert.ToBase64String(hash)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .TrimEnd('=');
            }

            string token = $"FOXQR:1:{payload}:{signature}";
            DateTime expiresAtUtc = DateTimeOffset.FromUnixTimeSeconds(nowSeconds + _validitySeconds).UtcDateTime;

            string qrBase64 = GenerateQrCodeImage(token);

            return (token, qrBase64, expiresAtUtc, _validitySeconds);
        }

        public bool ValidateToken(string qrToken, out string? storeCode, out string? errorReason)
        {
            storeCode = null;
            errorReason = null;

            if (string.IsNullOrWhiteSpace(qrToken))
            {
                errorReason = "QR kod məlumatı boşdur.";
                return false;
            }

            // Replay protection: Token təkrar istifadə edilibmi?
            string cacheKey = $"used_qr_{qrToken}";
            if (_memoryCache.TryGetValue(cacheKey, out _))
            {
                errorReason = "Bu QR kod artıq istifadə edilib! Zəhmət olmasa ekrandakı yeni QR kodu oxudun.";
                return false;
            }

            string[] parts = qrToken.Split(':');
            if (parts.Length != 4 || parts[0] != "FOXQR" || parts[1] != "1")
            {
                errorReason = "QR kod formatı yolverilməzdir.";
                return false;
            }

            string payload = parts[2];
            string providedSig = parts[3];

            string[] payloadParts = payload.Split('|');
            if (payloadParts.Length != 3)
            {
                errorReason = "QR kod strukturu düzgün deyil.";
                return false;
            }

            string code = payloadParts[0];
            if (!long.TryParse(payloadParts[1], out long tokenSeconds))
            {
                errorReason = "QR kod vaxt damğası etibarsızdır.";
                return false;
            }

            // Vaxt yoxlanışı (Time check)
            long nowSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long ageSeconds = nowSeconds - tokenSeconds;

            if (ageSeconds > _validitySeconds)
            {
                errorReason = $"QR kodun vaxtı keçib ({ageSeconds} saniyə keçib, icazə: {_validitySeconds} san). Ekrandakı yeni QR kodu oxudun.";
                return false;
            }

            if (ageSeconds < -10)
            {
                errorReason = "Cihazınızın və ya serverin saatı düzgün deyil (QR gələcək vaxtdadır).";
                return false;
            }

            // Kriptoqrafik imza yoxlanışı (Signature check)
            string expectedSig;
            using (var hmac = new HMACSHA256(_hmacKey))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                expectedSig = Convert.ToBase64String(hash)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .TrimEnd('=');
            }

            if (!CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(providedSig),
                Encoding.UTF8.GetBytes(expectedSig)))
            {
                errorReason = "QR kodun təhlükəsizlik imzası saxtadır və ya etibarsızdır.";
                return false;
            }

            // Uğurlu olduqda tokeni keşdə saxlayırıq (qalan saniyələr qədər), təkrar istifadənin qarşısı alınır
            int remainingSeconds = Math.Max(5, (int)(_validitySeconds - ageSeconds + 5));
            _memoryCache.Set(cacheKey, true, TimeSpan.FromSeconds(remainingSeconds));

            storeCode = code;
            return true;
        }

        private static string GenerateQrCodeImage(string text)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.M);
            using var qrCode = new PngByteQRCode(qrData);
            byte[] qrBytes = qrCode.GetGraphic(20);
            return "data:image/png;base64," + Convert.ToBase64String(qrBytes);
        }
    }
}
