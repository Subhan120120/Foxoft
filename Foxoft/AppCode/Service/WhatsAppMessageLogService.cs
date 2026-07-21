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
    public static class WhatsAppMessageLogService
    {
        public static async Task ResendAsync(Guid whatsAppMessageLogId, CancellationToken ct = default)
        {
            using var db = new subContext();

            TrWhatsAppMessageLog? log = await db.TrWhatsAppMessageLogs
                .FirstOrDefaultAsync(x => x.WhatsAppMessageLogId == whatsAppMessageLogId, ct);

            if (log == null)
                throw new InvalidOperationException(Resources.Form_WhatsAppMessageLog_NotFound);

            if (log.IsSuccessful)
                throw new InvalidOperationException(Resources.Form_WhatsAppMessageLog_AlreadySent);

            DcWhatsAppProviderSetting? apiSetting = await db.DcWhatsAppProviderSettings
                .FirstOrDefaultAsync(x => x.Id == 1, ct);

            ValidateApiSettings(apiSetting);

            if (!WhatsAppCreditService.HasEnoughBalance(db))
                throw new InvalidOperationException(Resources.Common_InsufficientBalance);

            await SendLoggedMessageAsync(apiSetting!, log, ct);

            log.IsSuccessful = true;
            log.Sender = Authorization.CurrAccCode;
            log.LastUpdatedUserName = Authorization.CurrAccCode;
            log.LastUpdatedDate = DateTime.Now;

            db.TrCredits.Add(WhatsAppCreditService.CreateUsage(log.MessageType ?? string.Empty, log.ReceiverPhoneNumber!));

            await db.SaveChangesAsync(ct);
        }

        public static async Task SendLoggedMessageAsync(DcWhatsAppProviderSetting apiSetting, TrWhatsAppMessageLog log,
            CancellationToken ct = default)
        {
            ValidateApiSettings(apiSetting);

            if (string.IsNullOrWhiteSpace(log.ReceiverPhoneNumber))
                throw new InvalidOperationException(Resources.Form_WhatsAppMessageLog_PhoneRequired);

            using var client = new EvolutionApiClient(apiSetting.ServerUrl!, apiSetting.InstanceName!, apiSetting.ApiKey!);

            if (!string.IsNullOrWhiteSpace(log.ImageFileName))
            {
                EfMethods efMethods = new();
                SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                string whatsAppFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "WhatsApp");
                string fullPath = Path.Combine(whatsAppFolder ?? string.Empty, log.ImageFileName);

                if (!File.Exists(fullPath))
                    throw new FileNotFoundException(Resources.Form_WhatsAppMessageLog_ImageFileNotFound, fullPath);

                using FileStream stream = new(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await client.SendImageBase64Async(log.ReceiverPhoneNumber, stream, caption: log.Message, ct: ct);
                return;
            }

            if (string.IsNullOrWhiteSpace(log.Message))
                throw new InvalidOperationException(Resources.Form_WhatsAppMessageLog_MessageRequired);

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
