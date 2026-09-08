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

        public static async Task<(int Sent, int Failed)> ProcessUnsentMessagesAsync(
            subContext db,
            int batchSize = 50,
            int maxRetries = 5,
            CancellationToken ct = default)
        {
            // Check internet connectivity first. If no internet, do not burn retry attempts!
            bool isOnline = await NetworkConnectivityHelper.IsInternetAvailableAsync(ct);
            if (!isOnline)
            {
                return (0, 0);
            }

            int sentCount = 0;
            int failedCount = 0;

            List<TrMessageLog> unsentLogs = await db.TrMessageLogs
                .Where(x => !x.IsSuccessful && x.TryCount < maxRetries)
                .OrderBy(x => x.CreatedDate)
                .Take(batchSize)
                .ToListAsync(ct);

            if (unsentLogs.Count == 0)
                return (0, 0);

            DcWhatsAppProviderSetting? waSetting = await db.DcWhatsAppProviderSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 1, ct);

            DcSmsProviderSetting? smsSetting = await db.DcSmsProviderSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 1, ct);

            foreach (TrMessageLog log in unsentLogs)
            {
                if (ct.IsCancellationRequested)
                    break;

                log.TryCount += 1;
                log.LastTryDate = DateTime.Now;

                try
                {
                    if (string.Equals(log.ChannelCode, NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase) ||
                        string.IsNullOrEmpty(log.ChannelCode))
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
                    else if (string.Equals(log.ChannelCode, NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase))
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
                    await Task.Delay(500, ct);
                }
                catch (Exception ex)
                {
                    log.LastError = ex.Message;
                    log.LastUpdatedDate = DateTime.Now;
                    failedCount++;
                }
            }

            await db.SaveChangesAsync(ct);
            return (sentCount, failedCount);
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
