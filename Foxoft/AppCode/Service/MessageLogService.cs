using Foxoft.Models;
using Foxoft.Properties;
using Foxoft;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service
{
    public static class MessageLogService
    {
        public static async Task ResendAsync(Guid messageLogId, CancellationToken ct = default)
        {
            using var db = new subContext();

            TrMessageLog? log = await db.TrMessageLogs
                .FirstOrDefaultAsync(x => x.MessageLogId == messageLogId, ct);

            if (log == null)
                throw new InvalidOperationException(Resources.Form_MessageLog_NotFound);

            if (log.IsSuccessful)
                throw new InvalidOperationException(Resources.Form_MessageLog_AlreadySent);

            log.TryCount += 1;
            log.LastTryDate = DateTime.Now;

            try
            {
                if (string.Equals(log.ChannelCode, NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(log.ChannelCode))
                {
                    DcWhatsAppProviderSetting? apiSetting = await db.DcWhatsAppProviderSettings
                        .FirstOrDefaultAsync(x => x.Id == 1, ct);

                    ValidateApiSettings(apiSetting);

                    if (!WhatsAppCreditService.HasEnoughBalance(db))
                        throw new InvalidOperationException(Resources.Common_InsufficientBalance);

                    await SendLoggedWhatsAppMessageAsync(apiSetting!, log, ct);

                    log.IsSuccessful = true;
                    log.LastError = null;
                    log.Sender = Authorization.CurrAccCode ?? log.Sender;
                    log.LastUpdatedUserName = Authorization.CurrAccCode ?? log.Sender;
                    log.LastUpdatedDate = DateTime.Now;

                    db.TrCredits.Add(WhatsAppCreditService.CreateUsage(log.MessageType ?? string.Empty, log.ReceiverPhoneNumber!));

                    await db.SaveChangesAsync(ct);
                }
                else if (string.Equals(log.ChannelCode, NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase))
                {
                    DcSmsProviderSetting? smsSetting = await db.DcSmsProviderSettings
                        .FirstOrDefaultAsync(x => x.Id == 1, ct);

                    if (smsSetting == null || !smsSetting.IsEnabled)
                        throw new InvalidOperationException("SMS provayder tənzimləmələri aktiv deyil və ya daxil edilməyib.");

                    if (string.IsNullOrWhiteSpace(log.ReceiverPhoneNumber))
                        throw new InvalidOperationException(Resources.Form_MessageLog_PhoneRequired);

                    if (string.IsNullOrWhiteSpace(log.Message))
                        throw new InvalidOperationException(Resources.Form_MessageLog_MessageRequired);

                    using var smsClient = new SmsClient(smsSetting);
                    await smsClient.SendSmsAsync(log.ReceiverPhoneNumber, log.Message, ct);

                    log.IsSuccessful = true;
                    log.LastError = null;
                    log.Sender = Authorization.CurrAccCode ?? log.Sender;
                    log.LastUpdatedUserName = Authorization.CurrAccCode ?? log.Sender;
                    log.LastUpdatedDate = DateTime.Now;

                    await db.SaveChangesAsync(ct);
                }
                else
                {
                    throw new NotSupportedException($"Dəstəklənməyən mesaj kanalı: {log.ChannelCode}");
                }
            }
            catch (Exception ex)
            {
                log.LastError = ex.Message;
                log.LastUpdatedUserName = Authorization.CurrAccCode ?? log.Sender;
                log.LastUpdatedDate = DateTime.Now;
                await db.SaveChangesAsync(ct);
                throw;
            }
        }

        public static int GetRequiredBackoffSeconds(int tryCount)
        {
            return tryCount switch
            {
                0 => 0,
                1 => 30,       // 30 sec
                2 => 120,      // 2 min
                3 => 300,      // 5 min
                4 => 900,      // 15 min
                _ => 1800      // 30 min
            };
        }

        public static async Task<(int Sent, int Failed)> ProcessUnsentMessagesAsync(
            subContext db,
            int batchSize = 50,
            int maxRetries = 5,
            CancellationToken ct = default)
        {
            // Check internet connectivity first. If no internet, do not attempt or burn retry attempts!
            bool isOnline = await NetworkConnectivityHelper.IsInternetAvailableAsync(ct);
            if (!isOnline)
            {
                return (0, 0);
            }

            int sentCount = 0;
            int failedCount = 0;
            DateTime now = DateTime.Now;

            // Load candidate unsent logs ordered by creation date
            List<TrMessageLog> candidateLogs = await db.TrMessageLogs
                .Where(x => !x.IsSuccessful && x.TryCount < maxRetries)
                .OrderBy(x => x.CreatedDate)
                .Take(batchSize * 2)
                .ToListAsync(ct);

            if (candidateLogs.Count == 0)
                return (0, 0);

            // Filter by exponential backoff delay so we don't spam failing messages
            List<TrMessageLog> eligibleLogs = candidateLogs
                .Where(x => x.LastTryDate == null || (now - x.LastTryDate.Value).TotalSeconds >= GetRequiredBackoffSeconds(x.TryCount))
                .Take(batchSize)
                .ToList();

            if (eligibleLogs.Count == 0)
                return (0, 0);

            DcWhatsAppProviderSetting? waSetting = await db.DcWhatsAppProviderSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 1, ct);

            DcSmsProviderSetting? smsSetting = await db.DcSmsProviderSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 1, ct);

            // Pre-check provider reachability to avoid burning attempts when provider container/server is down
            bool isWaReachable = waSetting != null && await NetworkConnectivityHelper.IsProviderReachableAsync(waSetting.ServerUrl, ct);
            bool isSmsReachable = smsSetting != null && smsSetting.IsEnabled && await NetworkConnectivityHelper.IsProviderReachableAsync(smsSetting.ServerUrl, ct);

            foreach (TrMessageLog log in eligibleLogs)
            {
                if (ct.IsCancellationRequested)
                    break;

                bool isWhatsApp = string.Equals(log.ChannelCode, NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase)
                    || string.IsNullOrEmpty(log.ChannelCode);
                bool isSms = string.Equals(log.ChannelCode, NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase);

                // If the specific provider server is down, skip and don't burn retry counts
                if (isWhatsApp && !isWaReachable)
                {
                    log.LastError = "WhatsApp serverinə qoşulmaq mümkün olmadı (Server əlçatan deyil).";
                    log.LastTryDate = DateTime.Now;
                    continue;
                }

                if (isSms && !isSmsReachable)
                {
                    log.LastError = "SMS serverinə qoşulmaq mümkün olmadı (Server əlçatan deyil).";
                    log.LastTryDate = DateTime.Now;
                    continue;
                }

                log.LastTryDate = DateTime.Now;

                try
                {
                    if (isWhatsApp)
                    {
                        ValidateApiSettings(waSetting);

                        if (!WhatsAppCreditService.HasEnoughBalance(db))
                        {
                            log.LastError = Resources.Common_InsufficientBalance;
                            failedCount++;
                            continue;
                        }

                        await SendLoggedWhatsAppMessageAsync(waSetting!, log, ct);

                        log.IsSuccessful = true;
                        log.LastError = null;
                        log.LastUpdatedDate = DateTime.Now;

                        db.TrCredits.Add(WhatsAppCreditService.CreateUsage(log.MessageType ?? string.Empty, log.ReceiverPhoneNumber!));
                        sentCount++;
                    }
                    else if (isSms)
                    {
                        if (smsSetting == null || !smsSetting.IsEnabled)
                        {
                            log.LastError = "SMS provayder tənzimləmələri aktiv deyil və ya daxil edilməyib.";
                            failedCount++;
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(log.ReceiverPhoneNumber) || string.IsNullOrWhiteSpace(log.Message))
                        {
                            log.LastError = "Nömrə və ya mesaj mətni boşdur.";
                            log.TryCount = maxRetries; // Permanent failure
                            failedCount++;
                            continue;
                        }

                        using var smsClient = new SmsClient(smsSetting);
                        await smsClient.SendSmsAsync(log.ReceiverPhoneNumber, log.Message, ct);

                        log.IsSuccessful = true;
                        log.LastError = null;
                        log.LastUpdatedDate = DateTime.Now;
                        sentCount++;
                    }

                    // Rate-limiting delay to avoid flooding provider
                    await Task.Delay(1000, ct);
                }
                catch (Exception ex)
                {
                    log.LastError = ex.Message;
                    log.LastUpdatedDate = DateTime.Now;

                    if (IsPermanentDataError(ex))
                    {
                        // Permanent error (e.g. image file missing, invalid number): mark max retries to stop looping
                        log.TryCount = maxRetries;
                        failedCount++;
                    }
                    else if (IsTransientNetworkError(ex))
                    {
                        // Network/outage error: don't exhaust retry limits immediately; break batch loop
                        failedCount++;
                        break;
                    }
                    else
                    {
                        log.TryCount += 1;
                        failedCount++;
                    }
                }
            }

            await db.SaveChangesAsync(ct);
            return (sentCount, failedCount);
        }

        private static bool IsTransientNetworkError(Exception ex)
        {
            return ex is System.Net.Http.HttpRequestException
                || ex is System.Net.Sockets.SocketException
                || ex is TimeoutException
                || ex is TaskCanceledException
                || (ex.InnerException != null && IsTransientNetworkError(ex.InnerException));
        }

        private static bool IsPermanentDataError(Exception ex)
        {
            return ex is FileNotFoundException
                || ex is ArgumentException
                || ex is FormatException;
        }

        public static async Task SendLoggedWhatsAppMessageAsync(
            DcWhatsAppProviderSetting apiSetting,
            TrMessageLog log,
            CancellationToken ct = default)
        {
            ValidateApiSettings(apiSetting);

            if (string.IsNullOrWhiteSpace(log.ReceiverPhoneNumber))
                throw new InvalidOperationException(Resources.Form_MessageLog_PhoneRequired);

            using var client = new EvolutionApiClient(apiSetting.ServerUrl!, apiSetting.InstanceName!, apiSetting.ApiKey!);

            if (!string.IsNullOrWhiteSpace(log.ImageFileName))
            {
                string? storeCode = Authorization.StoreCode;
                string? imageFolder = null;

                if (!string.IsNullOrWhiteSpace(storeCode))
                {
                    EfMethods efMethods = new();
                    SettingStore settingStore = efMethods.SelectSettingStore(storeCode);
                    imageFolder = settingStore?.ImageFolder;
                }

                if (string.IsNullOrWhiteSpace(imageFolder))
                {
                    using var tempDb = new subContext();
                    var defaultStoreSetting = tempDb.SettingStores.FirstOrDefault();
                    imageFolder = defaultStoreSetting?.ImageFolder;
                }

                string whatsAppFolder = CustomExtensions.CombinePath(imageFolder, "WhatsApp");
                string fullPath = Path.Combine(whatsAppFolder ?? string.Empty, log.ImageFileName);

                if (!File.Exists(fullPath))
                    throw new FileNotFoundException(Resources.Form_MessageLog_ImageFileNotFound, fullPath);

                using FileStream stream = new(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await client.SendImageBase64Async(log.ReceiverPhoneNumber, stream, caption: log.Message, ct: ct);
                return;
            }

            if (string.IsNullOrWhiteSpace(log.Message))
                throw new InvalidOperationException(Resources.Form_MessageLog_MessageRequired);

            await client.SendTextAsync(log.ReceiverPhoneNumber, log.Message, ct);
        }

        private static void ValidateApiSettings(DcWhatsAppProviderSetting? apiSetting)
        {
            if (apiSetting == null ||
                string.IsNullOrWhiteSpace(apiSetting.ServerUrl) ||
                string.IsNullOrWhiteSpace(apiSetting.InstanceName) ||
                string.IsNullOrWhiteSpace(apiSetting.ApiKey))
                throw new InvalidOperationException(Resources.Payment_ApiSettingsIncomplete);
        }
    }
}
