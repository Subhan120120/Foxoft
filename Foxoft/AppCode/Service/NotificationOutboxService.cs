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
            int sent = 0;
            int failed = 0;

            List<NotificationChannelOutbox> outboxes = await _db.NotificationChannelOutboxes
                .Include(x => x.Notification)
                .Where(x => x.Status == NotificationOutboxStatuses.Pending)
                .OrderBy(x => x.CreatedDate)
                .Take(take)
                .ToListAsync(ct);

            foreach (NotificationChannelOutbox outbox in outboxes)
            {
                if (outbox.Notification.Status != NotificationStatuses.Active
                    || !await IsEffectiveRuleEnabledAsync(outbox.Notification, ct))
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
                    outbox.Status = IsPermanentFailure(ex)
                        ? NotificationOutboxStatuses.Failed
                        : NotificationOutboxStatuses.Pending;
                    outbox.LastError = ex.Message;
                    AddAudit(outbox, NotificationActionTypes.ChannelFailed, ex.Message);

                    LogFailedMessage(outbox, ex.Message);
                    NotifyFailureIfInUi(ex.Message);

                    failed++;
                }
            }

            await _db.SaveChangesAsync(ct);
            return (sent, failed);
        }

        private async Task<bool> IsEffectiveRuleEnabledAsync(Notification notification, CancellationToken ct)
        {
            NotificationRule? storeRule = null;
            if (!string.IsNullOrWhiteSpace(notification.StoreCode))
            {
                storeRule = await _db.NotificationRules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.NotificationTypeCode == notification.NotificationTypeCode
                                           && x.StoreCode == notification.StoreCode, ct);
            }

            NotificationRule? rule = storeRule ?? await _db.NotificationRules
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == notification.NotificationTypeCode
                                       && x.StoreCode == null, ct);

            return rule?.IsEnabled == true;
        }

        private async Task SendAsync(NotificationChannelOutbox outbox, CancellationToken ct)
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

                _db.TrCredits.Add(WhatsAppCreditService.CreateUsage(outbox.Notification.NotificationTypeCode, normalizedReceiver));

                Guid? documentHeaderId = null;
                if (outbox.Notification.EntityType == NotificationEntityTypes.Invoice &&
                    Guid.TryParse(outbox.Notification.EntityKey, out Guid parsedId))
                {
                    documentHeaderId = parsedId;
                }

                _db.TrMessageLogs.Add(new TrMessageLog
                {
                    MessageLogId = Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = normalizedReceiver,
                    ChannelCode = NotificationChannels.WhatsApp,
                    MessageType = outbox.Notification.NotificationTypeCode,
                    Message = message,
                    IsSuccessful = true,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = outbox.Notification.EntityType == NotificationEntityTypes.Customer ? outbox.Notification.EntityKey : null,
                    TryCount = outbox.TryCount,
                    LastTryDate = DateTime.Now
                });

                return;
            }

            throw new NotSupportedException(outbox.ChannelCode);
        }

        private void LogFailedMessage(NotificationChannelOutbox outbox, string errorMessage)
        {
            try
            {
                Guid? documentHeaderId = null;
                if (outbox.Notification.EntityType == NotificationEntityTypes.Invoice &&
                    Guid.TryParse(outbox.Notification.EntityKey, out Guid parsedId))
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
                    MessageType = outbox.Notification.NotificationTypeCode,
                    Message = message,
                    IsSuccessful = false,
                    LastError = errorMessage,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = outbox.Notification.EntityType == NotificationEntityTypes.Customer ? outbox.Notification.EntityKey : null,
                    TryCount = outbox.TryCount,
                    LastTryDate = DateTime.Now
                });
            }
            catch
            {
            }
        }

        private static void NotifyFailureIfInUi(string errorMessage)
        {
            try
            {
                var mainForm = System.Windows.Forms.Application.OpenForms?.OfType<System.Windows.Forms.Form>().FirstOrDefault();
                if (mainForm != null && mainForm.IsHandleCreated)
                {
                    mainForm.BeginInvoke((Action)(() =>
                    {
                        var alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
                        alertControl.AutoFormDelay = 4000;
                        alertControl.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Fast;
                        alertControl.Show(mainForm, Resources.Common_ErrorTitle, string.Format(Resources.Common_WhatsAppSendError, errorMessage));
                    }));
                }
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

        private void AddAudit(NotificationChannelOutbox outbox, string actionType, string? note)
        {
            _db.NotificationAudits.Add(new NotificationAudit
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
