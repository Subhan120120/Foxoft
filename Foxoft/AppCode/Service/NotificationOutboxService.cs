using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
                    throw new InvalidOperationException(Properties.Resources.Payment_ApiSettingsIncomplete);

                string message = ExtractMessage(outbox.Payload);
                using EvolutionApiClient client = new(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);
                await client.SendTextAsync(NormalizeReceiver(outbox.Receiver), message, ct);
                return;
            }

            throw new NotSupportedException(outbox.ChannelCode);
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
