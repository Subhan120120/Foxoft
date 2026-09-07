using Foxoft.Models;
using Foxoft.Properties;
using Foxoft;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
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
                    log.Sender = Authorization.CurrAccCode;
                    log.LastUpdatedUserName = Authorization.CurrAccCode;
                    log.LastUpdatedDate = DateTime.Now;

                    db.TrCredits.Add(WhatsAppCreditService.CreateUsage(log.MessageType ?? string.Empty, log.ReceiverPhoneNumber!));

                    await db.SaveChangesAsync(ct);
                }
                else if (string.Equals(log.ChannelCode, NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase))
                {
                    throw new NotSupportedException("SMS resend is not yet configured with an active provider.");
                }
            }
            catch (Exception ex)
            {
                log.LastError = ex.Message;
                log.LastUpdatedUserName = Authorization.CurrAccCode;
                log.LastUpdatedDate = DateTime.Now;
                await db.SaveChangesAsync(ct);
                throw;
            }
        }

        public static async Task SendLoggedWhatsAppMessageAsync(DcWhatsAppProviderSetting apiSetting, TrMessageLog log,
            CancellationToken ct = default)
        {
            ValidateApiSettings(apiSetting);

            if (string.IsNullOrWhiteSpace(log.ReceiverPhoneNumber))
                throw new InvalidOperationException(Resources.Form_MessageLog_PhoneRequired);

            using var client = new EvolutionApiClient(apiSetting.ServerUrl!, apiSetting.InstanceName!, apiSetting.ApiKey!);

            if (!string.IsNullOrWhiteSpace(log.ImageFileName))
            {
                EfMethods efMethods = new();
                SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                string whatsAppFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "WhatsApp");
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
