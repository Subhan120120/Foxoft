using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service
{
    public sealed class NotificationOutboxService
    {
        private readonly subContext _db;

        public NotificationOutboxService(subContext db)
        {
            _db = db;
        }

        public async Task<(int Sent, int Failed)> ProcessPendingAsync(int take = 50, CancellationToken ct = default)
        {
            // If internet is not available, do not burn retry counts!
            bool isOnline = await NetworkConnectivityHelper.IsInternetAvailableAsync(ct);
            if (!isOnline)
            {
                return (0, 0);
            }

            int sent = 0;
            int failed = 0;

            List<TrNotificationChannelOutbox> outboxes = await _db.TrNotificationChannelOutboxes
                .Include(x => x.TrNotification)
                .Where(x => x.Status == NotificationOutboxStatuses.Pending)
                .OrderBy(x => x.CreatedDate)
                .Take(take)
                .ToListAsync(ct);

            for (int i = 0; i < outboxes.Count; i++)
            {
                TrNotificationChannelOutbox outbox = outboxes[i];

                if (ct.IsCancellationRequested)
                    break;

                if (outbox.TrNotification.Status != NotificationStatuses.Active
                    || !await IsEffectiveRuleEnabledAsync(outbox.TrNotification, ct))
                {
                    outbox.Status = NotificationOutboxStatuses.Cancelled;
                    outbox.LastTryDate = DateTime.Now;
                    AddAudit(outbox, NotificationActionTypes.Cancelled, null);
                    continue;
                }

                outbox.TryCount++;
                outbox.LastTryDate = DateTime.Now;

                try
                {
                    await SendAsync(outbox, ct);
                    outbox.Status = NotificationOutboxStatuses.Sent;
                    outbox.LastError = null;
                    AddAudit(outbox, NotificationActionTypes.ChannelSent, null);
                    sent++;
                }
                catch (Exception ex)
                {
                    bool isPermanent = IsPermanentFailure(ex) || outbox.TryCount >= 5;
                    outbox.Status = isPermanent
                        ? NotificationOutboxStatuses.Failed
                        : NotificationOutboxStatuses.Pending;
                    outbox.LastError = ex.Message;
                    AddAudit(outbox, NotificationActionTypes.ChannelFailed, ex.Message);

                    // Only record in TrMessageLog if permanently failed to prevent duplicate logs/retries
                    if (isPermanent)
                    {
                        LogFailedMessage(outbox, ex.Message);
                    }

                    NotifyFailureIfInUi(outbox.ChannelCode, outbox.Receiver, ex.Message);

                    failed++;
                }
                finally
                {
                    // If more than 1 message, send sequentially: 1 message per second
                    if (outboxes.Count > 1 && i < outboxes.Count - 1 && !ct.IsCancellationRequested)
                    {
                        await Task.Delay(1000, ct);
                    }
                }
            }

            await _db.SaveChangesAsync(ct);
            return (sent, failed);
        }

        private async Task<bool> IsEffectiveRuleEnabledAsync(TrNotification notification, CancellationToken ct)
        {
            DcNotificationRule? storeRule = null;
            if (!string.IsNullOrWhiteSpace(notification.StoreCode))
            {
                storeRule = await _db.DcNotificationRules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.NotificationTypeCode == notification.NotificationTypeCode
                                           && x.StoreCode == notification.StoreCode, ct);
            }

            DcNotificationRule? rule = storeRule ?? await _db.DcNotificationRules
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == notification.NotificationTypeCode
                                       && x.StoreCode == null, ct);

            return rule?.IsEnabled == true;
        }

        private async Task SendAsync(TrNotificationChannelOutbox outbox, CancellationToken ct)
        {
            if (outbox.ChannelCode.Equals(NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase))
            {
                DcWhatsAppProviderSetting? apiSetting = await _db.DcWhatsAppProviderSettings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == 1, ct);

                if (apiSetting == null ||
                    string.IsNullOrWhiteSpace(apiSetting.ServerUrl) ||
                    string.IsNullOrWhiteSpace(apiSetting.InstanceName) ||
                    string.IsNullOrWhiteSpace(apiSetting.ApiKey))
                    throw new InvalidOperationException(Resources.Payment_ApiSettingsIncomplete);

                if (!WhatsAppCreditService.HasEnoughBalance(_db))
                    throw new InvalidOperationException(Resources.Common_InsufficientBalance);

                string message = ExtractMessage(outbox.Payload);
                string normalizedReceiver = NormalizeReceiver(outbox.Receiver);

                using EvolutionApiClient client = new(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);
                await client.SendTextAsync(normalizedReceiver, message, ct);

                _db.TrCredits.Add(WhatsAppCreditService.CreateUsage(outbox.TrNotification.NotificationTypeCode, normalizedReceiver));

                Guid? documentHeaderId = null;
                if (outbox.TrNotification.EntityType == NotificationEntityTypes.Invoice &&
                    Guid.TryParse(outbox.TrNotification.EntityKey, out Guid parsedId))
                {
                    documentHeaderId = parsedId;
                }

                _db.TrMessageLogs.Add(new TrMessageLog
                {
                    MessageLogId = Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = normalizedReceiver,
                    ChannelCode = NotificationChannels.WhatsApp,
                    MessageType = outbox.TrNotification.NotificationTypeCode,
                    Message = message,
                    IsSuccessful = true,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = outbox.TrNotification.EntityType == NotificationEntityTypes.Customer ? outbox.TrNotification.EntityKey : null,
                    TryCount = outbox.TryCount,
                    LastTryDate = DateTime.Now
                });

                return;
            }
            else if (outbox.ChannelCode.Equals(NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase))
            {
                DcSmsProviderSetting? smsSetting = await _db.DcSmsProviderSettings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == 1, ct);

                if (smsSetting == null || !smsSetting.IsEnabled)
                    throw new InvalidOperationException("SMS provayder tənzimləmələri aktiv deyil və ya daxil edilməyib.");

                string message = ExtractMessage(outbox.Payload);
                using SmsClient client = new(smsSetting);
                await client.SendSmsAsync(outbox.Receiver, message, ct);

                Guid? documentHeaderId = null;
                if (outbox.TrNotification.EntityType == NotificationEntityTypes.Invoice &&
                    Guid.TryParse(outbox.TrNotification.EntityKey, out Guid parsedId))
                {
                    documentHeaderId = parsedId;
                }

                _db.TrMessageLogs.Add(new TrMessageLog
                {
                    MessageLogId = Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = outbox.Receiver,
                    ChannelCode = NotificationChannels.Sms,
                    MessageType = outbox.TrNotification.NotificationTypeCode,
                    Message = message,
                    IsSuccessful = true,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = outbox.TrNotification.EntityType == NotificationEntityTypes.Customer ? outbox.TrNotification.EntityKey : null,
                    TryCount = outbox.TryCount,
                    LastTryDate = DateTime.Now
                });

                return;
            }

            throw new NotSupportedException(outbox.ChannelCode);
        }

        private void LogFailedMessage(TrNotificationChannelOutbox outbox, string errorMessage)
        {
            try
            {
                Guid? documentHeaderId = null;
                if (outbox.TrNotification.EntityType == NotificationEntityTypes.Invoice &&
                    Guid.TryParse(outbox.TrNotification.EntityKey, out Guid parsedId))
                {
                    documentHeaderId = parsedId;
                }

                string normalizedReceiver = NormalizeReceiver(outbox.Receiver);
                string message = ExtractMessage(outbox.Payload);

                _db.TrMessageLogs.Add(new TrMessageLog
                {
                    MessageLogId = Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = normalizedReceiver,
                    ChannelCode = outbox.ChannelCode,
                    MessageType = outbox.TrNotification.NotificationTypeCode,
                    Message = message,
                    IsSuccessful = false,
                    LastError = errorMessage,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = outbox.TrNotification.EntityType == NotificationEntityTypes.Customer ? outbox.TrNotification.EntityKey : null,
                    TryCount = outbox.TryCount,
                    LastTryDate = DateTime.Now
                });
            }
            catch
            {
            }
        }

        private static void NotifyFailureIfInUi(string channel, string receiver, string errorMessage)
        {
            try
            {
                MessageToastService.ShowUnsentToast(channel, receiver, errorMessage);
            }
            catch
            {
            }
        }

        private static string ExtractMessage(string payload)
        {
            using JsonDocument document = JsonDocument.Parse(payload);
            JsonElement root = document.RootElement;

            string title = root.TryGetProperty("Title", out JsonElement titleEl) ? titleEl.GetString() ?? string.Empty : string.Empty;
            string body = root.TryGetProperty("Body", out JsonElement bodyEl) ? bodyEl.GetString() ?? string.Empty : string.Empty;
            bool bodyOnly = root.TryGetProperty("BodyOnly", out JsonElement bodyOnlyEl) && bodyOnlyEl.GetBoolean();

            if (bodyOnly)
                return body;

            return string.IsNullOrWhiteSpace(title)
                ? body
                : title + Environment.NewLine + body;
        }

        private static string NormalizeReceiver(string receiver)
            => receiver.Trim().Replace("+", string.Empty).Replace(" ", string.Empty);

        private static bool IsPermanentFailure(Exception ex)
        {
            return ex is NotSupportedException
                || ex is InvalidOperationException
                || ex is ArgumentException;
        }

        private void AddAudit(TrNotificationChannelOutbox outbox, string actionType, string? note)
        {
            _db.TrNotificationAudits.Add(new TrNotificationAudit
            {
                NotificationId = outbox.NotificationId,
                ActionType = actionType,
                ChannelCode = outbox.ChannelCode,
                ActionDate = DateTime.Now,
                Note = note
            });
        }
    }
}
