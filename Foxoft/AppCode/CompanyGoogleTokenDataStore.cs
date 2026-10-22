using Google.Apis.Util.Store;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foxoft.AppCode
{
    public class CompanyGoogleTokenDataStore : IDataStore
    {
        private readonly string? _fallbackDirectory;

        public CompanyGoogleTokenDataStore(string? fallbackDirectory = null)
        {
            _fallbackDirectory = fallbackDirectory;
        }

        public Task StoreAsync<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key MUST have a value");

            string serialized = value is string str ? str : JsonConvert.SerializeObject(value);

            // 1. Save to database AppSettings
            try
            {
                using subContext db = new();
                var setting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
                if (setting != null)
                {
                    setting.GoogleToken = serialized;
                    db.SaveChanges();
                }

                if (Properties.Settings.Default.AppSetting != null)
                {
                    Properties.Settings.Default.AppSetting.GoogleToken = serialized;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CompanyGoogleTokenDataStore] Error saving token to DB: {ex.Message}");
            }

            // 2. Also save to local fallback if directory provided
            if (!string.IsNullOrEmpty(_fallbackDirectory))
            {
                try
                {
                    Directory.CreateDirectory(_fallbackDirectory);
                    string filePath = Path.Combine(_fallbackDirectory, GenerateStoredKey(key, typeof(T)));
                    File.WriteAllText(filePath, serialized);
                }
                catch
                {
                }
            }

            return Task.CompletedTask;
        }

        public Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key MUST have a value");

            string? tokenJson = null;

            // 1. Fetch from database AppSettings first
            try
            {
                using subContext db = new();
                tokenJson = db.AppSettings
                    .AsNoTracking()
                    .Where(x => x.Id == 1)
                    .Select(x => x.GoogleToken)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(tokenJson) && Properties.Settings.Default.AppSetting != null)
                {
                    Properties.Settings.Default.AppSetting.GoogleToken = tokenJson;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CompanyGoogleTokenDataStore] Error loading token from DB: {ex.Message}");
            }

            // 2. If not in DB, check in-memory AppSetting
            if (string.IsNullOrEmpty(tokenJson))
            {
                tokenJson = Properties.Settings.Default.AppSetting?.GoogleToken;
            }

            // 3. If still empty, check local fallback file (for automatic migration of already authenticated machines)
            if (string.IsNullOrEmpty(tokenJson) && !string.IsNullOrEmpty(_fallbackDirectory))
            {
                try
                {
                    string filePath = Path.Combine(_fallbackDirectory, GenerateStoredKey(key, typeof(T)));
                    if (File.Exists(filePath))
                    {
                        tokenJson = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(tokenJson))
                        {
                            _ = StoreAsync(key, tokenJson);
                        }
                    }
                }
                catch
                {
                }
            }

            if (string.IsNullOrEmpty(tokenJson))
            {
                return Task.FromResult(default(T)!);
            }

            try
            {
                if (typeof(T) == typeof(string))
                {
                    return Task.FromResult((T)(object)tokenJson);
                }

                T? result = JsonConvert.DeserializeObject<T>(tokenJson);
                return Task.FromResult(result ?? default(T)!);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CompanyGoogleTokenDataStore] Deserialization error: {ex.Message}");
                return Task.FromResult(default(T)!);
            }
        }

        public Task DeleteAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key MUST have a value");

            // 1. Clear in database
            try
            {
                using subContext db = new();
                var setting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
                if (setting != null)
                {
                    setting.GoogleToken = null;
                    db.SaveChanges();
                }

                if (Properties.Settings.Default.AppSetting != null)
                {
                    Properties.Settings.Default.AppSetting.GoogleToken = null;
                }
            }
            catch
            {
            }

            // 2. Clear local file
            if (!string.IsNullOrEmpty(_fallbackDirectory))
            {
                try
                {
                    string filePath = Path.Combine(_fallbackDirectory, GenerateStoredKey(key, typeof(T)));
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                catch
                {
                }
            }

            return Task.CompletedTask;
        }

        public Task ClearAsync()
        {
            // 1. Clear in database
            try
            {
                using subContext db = new();
                var setting = db.AppSettings.FirstOrDefault(x => x.Id == 1);
                if (setting != null)
                {
                    setting.GoogleToken = null;
                    db.SaveChanges();
                }

                if (Properties.Settings.Default.AppSetting != null)
                {
                    Properties.Settings.Default.AppSetting.GoogleToken = null;
                }
            }
            catch
            {
            }

            // 2. Clear local directory
            if (!string.IsNullOrEmpty(_fallbackDirectory) && Directory.Exists(_fallbackDirectory))
            {
                try
                {
                    Directory.Delete(_fallbackDirectory, true);
                }
                catch
                {
                }
            }

            return Task.CompletedTask;
        }

        private static string GenerateStoredKey(string key, Type type)
        {
            return $"{type.FullName}-{key}";
        }
    }
}
