using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Foxoft.AppCode.Service
{
    public sealed record NotificationCreateRequest(
        string NotificationTypeCode,
        string NotificationKey,
        string? Severity = null,
        string? Title = null,
        string? Body = null,
        string? EntityType = null,
        string? EntityKey = null,
        string? StoreCode = null,
        Dictionary<string, string>? Placeholders = null,
        string? LanguageCode = null,
        DateTime? ExpireDate = null,
        IReadOnlyCollection<NotificationChannelReceiver>? ChannelReceivers = null);

    public sealed record NotificationChannelReceiver(
        string ChannelCode,
        string Receiver,
        bool BodyOnly = false);

    public sealed class NotificationInboxFilter
    {
        public string? Preset { get; set; }
        public string? CategoryCode { get; set; }
        public string? StoreCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    public sealed class NotificationService
    {
        private readonly subContext _db;

        public NotificationService(subContext db)
        {
            _db = db;
        }

        public async Task<TrNotification?> CreateOrUpdateAsync(NotificationCreateRequest request, CancellationToken ct = default)
        {
            DcNotificationType? notificationType = await _db.DcNotificationTypes
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == request.NotificationTypeCode && x.IsEnabled, ct);

            if (notificationType == null)
            {
                await CancelActiveByKeyAsync(request.NotificationKey, ct);
                return null;
            }

            DcNotificationRule? rule = await ResolveRuleAsync(request.NotificationTypeCode, request.StoreCode, ct);
            if (rule == null || !rule.IsEnabled)
            {
                await CancelActiveByKeyAsync(request.NotificationKey, ct);
                return null;
            }

            DateTime now = DateTime.Now;
            string severity = request.Severity ?? notificationType.DefaultSeverity;
            (string title, string body) = await ResolveTextAsync(notificationType.NotificationTypeCode, request, ct);
            bool shouldCreateOutbox = false;

            TrNotification? notification = await _db.TrNotifications
                .Include(x => x.TrNotificationRecipients)
                .FirstOrDefaultAsync(x => x.NotificationKey == request.NotificationKey
                                       && x.Status == NotificationStatuses.Active, ct);

            if (notification != null)
            {
                notification.Status = NotificationStatuses.Active;
                notification.ResolvedDate = null;

                bool isThrottled = rule.ThrottleMinutes > 0 && notification.LastRaisedDate.AddMinutes(rule.ThrottleMinutes) > now;
                if (!isThrottled)
                {
                    notification.Severity = severity;
                    notification.Title = title;
                    notification.Body = body;
                    notification.EntityType = request.EntityType;
                    notification.EntityKey = request.EntityKey;
                    notification.StoreCode = request.StoreCode;
                    notification.ExpireDate = request.ExpireDate;
                    notification.LastRaisedDate = now;
                    notification.LastUpdatedDate = now;

                    AddAudit(notification.NotificationId, null, NotificationActionTypes.RaisedAgain, null, null, null);
                    shouldCreateOutbox = true;
                }
            }
            else
            {
                notification = new TrNotification
                {
                    NotificationKey = request.NotificationKey,
                    NotificationTypeCode = notificationType.NotificationTypeCode,
                    Severity = severity,
                    Title = title,
                    Body = body,
                    EntityType = request.EntityType,
                    EntityKey = request.EntityKey,
                    StoreCode = request.StoreCode,
                    Status = NotificationStatuses.Active,
                    ResolvedDate = null,
                    LastRaisedDate = now,
                    ExpireDate = request.ExpireDate
                };

                _db.TrNotifications.Add(notification);
                await _db.SaveChangesAsync(ct);

                AddAudit(notification.NotificationId, null, NotificationActionTypes.Created, null, null, null);
                shouldCreateOutbox = true;
            }

            await EnsureRecipientsAsync(notification, rule, ct);

            if (shouldCreateOutbox)
                await EnsureOutboxAsync(notification, rule, request, ct);

            await _db.SaveChangesAsync(ct);
            return notification;
        }

        public async Task<List<NotificationInboxItem>> GetInboxAsync(string currAccCode, NotificationInboxFilter filter, CancellationToken ct = default)
        {
            DateTime now = DateTime.Now;

            IQueryable<TrNotificationRecipient> query = _db.TrNotificationRecipients
                .AsNoTracking()
                .Include(x => x.TrNotification)
                    .ThenInclude(x => x.DcNotificationType)
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.TrNotification.DcNotificationType.IsEnabled)
                .Where(x => x.TrNotification.Status == NotificationStatuses.Active
                         || x.TrNotification.Status == NotificationStatuses.Resolved)
                .Where(x => x.Status != NotificationRecipientStatuses.Dismissed)
                .Where(x => x.Status != NotificationRecipientStatuses.Snoozed || x.SnoozedUntil <= now);

            query = WhereEffectiveRuleIsEnabled(query);

            if (filter.DateFrom.HasValue)
                query = query.Where(x => x.TrNotification.CreatedDate >= filter.DateFrom.Value.Date);

            if (filter.DateTo.HasValue)
            {
                DateTime dateTo = filter.DateTo.Value.Date.AddDays(1);
                query = query.Where(x => x.TrNotification.CreatedDate < dateTo);
            }

            if (!string.IsNullOrWhiteSpace(filter.StoreCode))
                query = query.Where(x => x.TrNotification.StoreCode == filter.StoreCode);

            if (!string.IsNullOrWhiteSpace(filter.CategoryCode))
                query = query.Where(x => x.TrNotification.DcNotificationType.CategoryCode == filter.CategoryCode);

            switch (filter.Preset)
            {
                case "Unread":
                    query = query.Where(x => x.TrNotification.Status == NotificationStatuses.Active
                                          && x.Status == NotificationRecipientStatuses.Unread);
                    break;
                case "Critical":
                    query = query.Where(x => x.TrNotification.Status == NotificationStatuses.Active
                                          && x.TrNotification.Severity == NotificationSeverities.Critical);
                    break;
                case "Today":
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);
                    query = query.Where(x => x.TrNotification.CreatedDate >= today && x.TrNotification.CreatedDate < tomorrow);
                    break;
            }

            return await query
                .OrderByDescending(x => x.TrNotification.CreatedDate)
                .Select(x => new NotificationInboxItem
                {
                    NotificationId = x.NotificationId,
                    NotificationRecipientId = x.NotificationRecipientId,
                    CreatedDate = x.TrNotification.CreatedDate,
                    NotificationTypeCode = x.TrNotification.NotificationTypeCode,
                    NotificationTypeDesc = x.TrNotification.DcNotificationType.NotificationTypeDesc,
                    CategoryCode = x.TrNotification.DcNotificationType.CategoryCode,
                    Severity = x.TrNotification.Severity,
                    StoreCode = x.TrNotification.StoreCode,
                    Title = x.TrNotification.Title,
                    Body = x.TrNotification.Body,
                    NotificationStatus = x.TrNotification.Status,
                    RecipientStatus = x.Status,
                    EntityType = x.TrNotification.EntityType,
                    EntityKey = x.TrNotification.EntityKey,
                    SnoozedUntil = x.SnoozedUntil,
                    LastRaisedDate = x.TrNotification.LastRaisedDate
                })
                .ToListAsync(ct);
        }

        public Task<int> GetUnreadCountAsync(string currAccCode, CancellationToken ct = default)
        {
            DateTime now = DateTime.Now;
            IQueryable<TrNotificationRecipient> query = _db.TrNotificationRecipients
                .AsNoTracking()
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.TrNotification.DcNotificationType.IsEnabled)
                .Where(x => x.TrNotification.Status == NotificationStatuses.Active)
                .Where(x => x.Status == NotificationRecipientStatuses.Unread)
                .Where(x => x.SnoozedUntil == null || x.SnoozedUntil <= now);

            return WhereEffectiveRuleIsEnabled(query).CountAsync(ct);
        }

        public Task<List<NotificationInboxItem>> GetPopupCandidatesAsync(string currAccCode, CancellationToken ct = default)
        {
            DateTime now = DateTime.Now;
            IQueryable<TrNotificationRecipient> query = _db.TrNotificationRecipients
                .AsNoTracking()
                .Include(x => x.TrNotification)
                    .ThenInclude(x => x.DcNotificationType)
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.Status == NotificationRecipientStatuses.Unread)
                .Where(x => x.TrNotification.DcNotificationType.IsEnabled)
                .Where(x => x.TrNotification.Status == NotificationStatuses.Active)
                .Where(x => x.TrNotification.DcNotificationType.AllowPopup)
                .Where(x => x.LastPopupShownDate == null || x.LastPopupShownDate.Value.AddMinutes(30) <= now)
                .Where(x => x.SnoozedUntil == null || x.SnoozedUntil <= now)
                .Where(x => x.TrNotification.Severity == NotificationSeverities.High
                         || x.TrNotification.Severity == NotificationSeverities.Critical);

            return WhereEffectiveRuleIsEnabled(query)
                .OrderByDescending(x => x.TrNotification.Severity == NotificationSeverities.Critical)
                .ThenByDescending(x => x.TrNotification.CreatedDate)
                .Take(5)
                .Select(x => new NotificationInboxItem
                {
                    NotificationId = x.NotificationId,
                    NotificationRecipientId = x.NotificationRecipientId,
                    CreatedDate = x.TrNotification.CreatedDate,
                    NotificationTypeCode = x.TrNotification.NotificationTypeCode,
                    NotificationTypeDesc = x.TrNotification.DcNotificationType.NotificationTypeDesc,
                    CategoryCode = x.TrNotification.DcNotificationType.CategoryCode,
                    Severity = x.TrNotification.Severity,
                    StoreCode = x.TrNotification.StoreCode,
                    Title = x.TrNotification.Title,
                    Body = x.TrNotification.Body,
                    NotificationStatus = x.TrNotification.Status,
                    RecipientStatus = x.Status,
                    EntityType = x.TrNotification.EntityType,
                    EntityKey = x.TrNotification.EntityKey,
                    SnoozedUntil = x.SnoozedUntil,
                    LastRaisedDate = x.TrNotification.LastRaisedDate
                })
                .ToListAsync(ct);
        }

        public async Task MarkPopupShownAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            TrNotificationRecipient? recipient = await _db.TrNotificationRecipients
                .FirstOrDefaultAsync(x => x.NotificationRecipientId == notificationRecipientId, ct);

            if (recipient == null)
                return;

            recipient.LastPopupShownDate = DateTime.Now;
            AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.PopupShown, actorCurrAccCode, null, null);
            await _db.SaveChangesAsync(ct);
        }

        public async Task MarkReadAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            TrNotificationRecipient? recipient = await _db.TrNotificationRecipients
                .FirstOrDefaultAsync(x => x.NotificationRecipientId == notificationRecipientId, ct);

            if (recipient == null)
                return;

            recipient.Status = NotificationRecipientStatuses.Read;
            recipient.ReadDate = DateTime.Now;
            recipient.SnoozedUntil = null;
            AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.Read, actorCurrAccCode, null, null);
            await _db.SaveChangesAsync(ct);
        }

        public async Task MarkAllReadAsync(string currAccCode, CancellationToken ct = default)
        {
            List<TrNotificationRecipient> recipients = await _db.TrNotificationRecipients
                .Where(x => x.CurrAccCode == currAccCode
                         && x.TrNotification.Status == NotificationStatuses.Active
                         && x.Status == NotificationRecipientStatuses.Unread)
                .ToListAsync(ct);

            DateTime now = DateTime.Now;
            foreach (TrNotificationRecipient recipient in recipients)
            {
                recipient.Status = NotificationRecipientStatuses.Read;
                recipient.ReadDate = now;
                AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.Read, currAccCode, null, null);
            }

            await _db.SaveChangesAsync(ct);
        }

        public async Task DismissAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            TrNotificationRecipient? recipient = await _db.TrNotificationRecipients
                .FirstOrDefaultAsync(x => x.NotificationRecipientId == notificationRecipientId, ct);

            if (recipient == null)
                return;

            recipient.Status = NotificationRecipientStatuses.Dismissed;
            recipient.DismissedDate = DateTime.Now;
            recipient.SnoozedUntil = null;
            AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.Dismissed, actorCurrAccCode, null, null);
            await _db.SaveChangesAsync(ct);
        }

        public async Task SnoozeAsync(long notificationRecipientId, string actorCurrAccCode, DateTime snoozedUntil, CancellationToken ct = default)
        {
            TrNotificationRecipient? recipient = await _db.TrNotificationRecipients
                .FirstOrDefaultAsync(x => x.NotificationRecipientId == notificationRecipientId, ct);

            if (recipient == null)
                return;

            recipient.Status = NotificationRecipientStatuses.Snoozed;
            recipient.SnoozedUntil = snoozedUntil;
            AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.Snoozed, actorCurrAccCode, null, snoozedUntil.ToString("s"));
            await _db.SaveChangesAsync(ct);
        }

        public async Task ResolveAsync(long notificationId, string actorCurrAccCode, CancellationToken ct = default)
        {
            TrNotification? notification = await _db.TrNotifications
                .FirstOrDefaultAsync(x => x.NotificationId == notificationId, ct);

            if (notification == null || notification.Status != NotificationStatuses.Active)
                return;

            notification.Status = NotificationStatuses.Resolved;
            notification.ResolvedDate = DateTime.Now;
            AddAudit(notification.NotificationId, null, NotificationActionTypes.Resolved, actorCurrAccCode, null, null);
            await _db.SaveChangesAsync(ct);
        }

        public async Task ResolveInactiveKeysAsync(
            IEnumerable<string> activeKeys,
            IReadOnlyCollection<string> notificationTypeCodes,
            string? actorCurrAccCode,
            CancellationToken ct = default,
            IEnumerable<string>? scopeKeys = null,
            DateTime? maxLastRaisedDate = null)
        {
            HashSet<string> keySet = activeKeys.ToHashSet(StringComparer.OrdinalIgnoreCase);
            IQueryable<TrNotification> query = _db.TrNotifications
                .Where(x => notificationTypeCodes.Contains(x.NotificationTypeCode)
                         && x.Status == NotificationStatuses.Active);

            if (maxLastRaisedDate.HasValue)
                query = query.Where(x => x.LastRaisedDate <= maxLastRaisedDate.Value);

            if (scopeKeys != null)
            {
                List<string> scopedKeyList = scopeKeys
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                if (scopedKeyList.Count == 0)
                    return;

                query = query.Where(x => scopedKeyList.Contains(x.NotificationKey));
            }

            List<TrNotification> notifications = await query.ToListAsync(ct);

            DateTime now = DateTime.Now;
            foreach (TrNotification notification in notifications)
            {
                if (keySet.Contains(notification.NotificationKey))
                    continue;

                notification.Status = NotificationStatuses.Resolved;
                notification.ResolvedDate = now;
                AddAudit(notification.NotificationId, null, NotificationActionTypes.Resolved, actorCurrAccCode, null, null);
            }

            await _db.SaveChangesAsync(ct);
        }

        private async Task<DcNotificationRule?> ResolveRuleAsync(string notificationTypeCode, string? storeCode, CancellationToken ct)
        {
            DcNotificationRule? storeRule = null;
            if (!string.IsNullOrWhiteSpace(storeCode))
            {
                storeRule = await _db.DcNotificationRules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.NotificationTypeCode == notificationTypeCode
                                           && x.StoreCode == storeCode, ct);
            }

            return storeRule ?? await _db.DcNotificationRules
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == notificationTypeCode
                                       && x.StoreCode == null, ct);
        }

        private IQueryable<TrNotificationRecipient> WhereEffectiveRuleIsEnabled(IQueryable<TrNotificationRecipient> query)
        {
            return query.Where(recipient =>
                _db.DcNotificationRules.Any(rule =>
                    rule.NotificationTypeCode == recipient.TrNotification.NotificationTypeCode
                    && rule.IsEnabled
                    && ((rule.StoreCode == null && recipient.TrNotification.StoreCode == null)
                        || rule.StoreCode == recipient.TrNotification.StoreCode))
                || (!_db.DcNotificationRules.Any(rule =>
                        rule.NotificationTypeCode == recipient.TrNotification.NotificationTypeCode
                        && ((rule.StoreCode == null && recipient.TrNotification.StoreCode == null)
                            || rule.StoreCode == recipient.TrNotification.StoreCode))
                    && _db.DcNotificationRules.Any(rule =>
                        rule.NotificationTypeCode == recipient.TrNotification.NotificationTypeCode
                        && rule.StoreCode == null
                        && rule.IsEnabled)));
        }

        private async Task CancelActiveByKeyAsync(string notificationKey, CancellationToken ct)
        {
            TrNotification? notification = await _db.TrNotifications
                .FirstOrDefaultAsync(x => x.NotificationKey == notificationKey
                                       && x.Status == NotificationStatuses.Active, ct);

            if (notification == null)
                return;

            DateTime now = DateTime.Now;
            notification.Status = NotificationStatuses.Cancelled;
            notification.LastUpdatedDate = now;

            List<TrNotificationChannelOutbox> pendingOutboxes = await _db.TrNotificationChannelOutboxes
                .Where(x => x.NotificationId == notification.NotificationId
                         && x.Status == NotificationOutboxStatuses.Pending)
                .ToListAsync(ct);

            foreach (TrNotificationChannelOutbox outbox in pendingOutboxes)
            {
                outbox.Status = NotificationOutboxStatuses.Cancelled;
                outbox.LastTryDate = now;
            }

            AddAudit(notification.NotificationId, null, NotificationActionTypes.Cancelled, null, null, null);
            await _db.SaveChangesAsync(ct);
        }

        private async Task<(string Title, string Body)> ResolveTextAsync(string notificationTypeCode, NotificationCreateRequest request, CancellationToken ct)
        {
            Dictionary<string, string> placeholders = request.Placeholders ?? new Dictionary<string, string>();
            string languageCode = request.LanguageCode
                ?? Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            DcNotificationTemplate? template = await _db.DcNotificationTemplates
                .AsNoTracking()
                .Where(x => x.NotificationTypeCode == notificationTypeCode && x.IsEnabled)
                .OrderByDescending(x => x.LanguageCode == languageCode)
                .ThenByDescending(x => x.LanguageCode == "az")
                .ThenBy(x => x.NotificationTemplateId)
                .FirstOrDefaultAsync(ct);

            string title = request.Title ?? template?.TitleTemplate ?? notificationTypeCode;
            string body = request.Body ?? template?.BodyTemplate ?? notificationTypeCode;

            return (ApplyPlaceholders(title, placeholders), ApplyPlaceholders(body, placeholders));
        }

        private async Task EnsureRecipientsAsync(TrNotification notification, DcNotificationRule rule, CancellationToken ct)
        {
            HashSet<string> existingRecipients = notification.TrNotificationRecipients
                .Select(x => x.CurrAccCode)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            List<DcCurrAcc> recipients = await ResolveRecipientsAsync(notification.NotificationTypeCode, notification.StoreCode, ct);

            foreach (DcCurrAcc currAcc in recipients)
            {
                if (existingRecipients.Contains(currAcc.CurrAccCode))
                    continue;

                TrNotificationRecipient recipient = new()
                {
                    NotificationId = notification.NotificationId,
                    CurrAccCode = currAcc.CurrAccCode,
                    Status = NotificationRecipientStatuses.Unread
                };

                _db.TrNotificationRecipients.Add(recipient);
                AddAudit(notification.NotificationId, null, NotificationActionTypes.Assigned, currAcc.CurrAccCode, null, null);
            }
        }

        private async Task<List<DcCurrAcc>> ResolveRecipientsAsync(string notificationTypeCode, string? storeCode, CancellationToken ct)
        {
            List<DcNotificationRecipientRule> rules = await _db.DcNotificationRecipientRules
                .AsNoTracking()
                .Where(x => x.NotificationTypeCode == notificationTypeCode && x.IsEnabled)
                .Where(x => x.StoreCode == null || x.StoreCode == storeCode)
                .ToListAsync(ct);

            Dictionary<string, DcCurrAcc> users = new(StringComparer.OrdinalIgnoreCase);

            foreach (DcNotificationRecipientRule rule in rules)
            {
                IQueryable<DcCurrAcc> query = _db.TrCurrAccRoles
                    .AsNoTracking()
                    .Where(x => x.RoleCode == rule.RoleCode)
                    .Select(x => x.DcCurrAcc)
                    .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel && !x.IsDisabled);

                if (!string.IsNullOrWhiteSpace(rule.StoreCode))
                    query = query.Where(x => x.StoreCode == rule.StoreCode);

                List<DcCurrAcc> ruleUsers = await query.ToListAsync(ct);

                foreach (DcCurrAcc user in ruleUsers)
                    users.TryAdd(user.CurrAccCode, user);
            }

            return users.Values.ToList();
        }

        private async Task EnsureOutboxAsync(TrNotification notification, DcNotificationRule rule, NotificationCreateRequest request, CancellationToken ct)
        {
            string[] channels = rule.ChannelCodes
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (channels.Length == 0)
                return;

            List<string> deliveryChannels = channels
                .Where(x => !x.Equals(NotificationChannels.InApp, StringComparison.OrdinalIgnoreCase))
                .Where(x => !x.Equals(NotificationChannels.Popup, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (deliveryChannels.Count == 0)
                return;

            bool hasDirectReceivers = request.ChannelReceivers?.Any() == true;
            if (!hasDirectReceivers)
            {
                List<TrNotificationRecipient> recipients = await _db.TrNotificationRecipients
                    .Include(x => x.DcCurrAcc)
                        .ThenInclude(x => x.DcCurrAccContactDetails)
                    .Where(x => x.NotificationId == notification.NotificationId)
                    .ToListAsync(ct);

                foreach (string channel in deliveryChannels)
                {
                    foreach (TrNotificationRecipient recipient in recipients)
                    {
                        string? receiver = ResolveReceiver(recipient.DcCurrAcc, channel);
                        if (string.IsNullOrWhiteSpace(receiver))
                            continue;

                        await QueueOutboxAsync(
                            notification,
                            channel,
                            receiver,
                            BuildPayload(notification),
                            recipient.NotificationRecipientId,
                            recipient.CurrAccCode,
                            ct);
                    }
                }
            }

            if (request.ChannelReceivers == null)
                return;

            foreach (NotificationChannelReceiver receiver in request.ChannelReceivers)
            {
                string? channel = deliveryChannels.FirstOrDefault(x => x.Equals(receiver.ChannelCode, StringComparison.OrdinalIgnoreCase));
                if (string.IsNullOrWhiteSpace(channel) || string.IsNullOrWhiteSpace(receiver.Receiver))
                    continue;

                await QueueOutboxAsync(
                    notification,
                    channel,
                    receiver.Receiver,
                    BuildPayload(notification, receiver.BodyOnly),
                    null,
                    null,
                    ct);
            }
        }

        private async Task QueueOutboxAsync(
            TrNotification notification,
            string channel,
            string receiver,
            string payload,
            long? notificationRecipientId,
            string? actorCurrAccCode,
            CancellationToken ct)
        {
            bool alreadyQueued = await _db.TrNotificationChannelOutboxes
                .AnyAsync(x => x.NotificationId == notification.NotificationId
                            && x.ChannelCode == channel
                            && x.Receiver == receiver
                            && x.Status == NotificationOutboxStatuses.Pending, ct);

            if (alreadyQueued)
                return;

            _db.TrNotificationChannelOutboxes.Add(new TrNotificationChannelOutbox
            {
                NotificationId = notification.NotificationId,
                ChannelCode = channel,
                Receiver = receiver,
                Payload = payload
            });

            AddAudit(notification.NotificationId, notificationRecipientId, NotificationActionTypes.OutboxCreated, actorCurrAccCode, channel, null);
        }

        private static string? ResolveReceiver(DcCurrAcc user, string channel)
        {
            if (channel.Equals(NotificationChannels.Sms, StringComparison.OrdinalIgnoreCase)
                || channel.Equals(NotificationChannels.WhatsApp, StringComparison.OrdinalIgnoreCase))
                return user.PhoneNum;

            if (channel.Equals(NotificationChannels.Email, StringComparison.OrdinalIgnoreCase))
                return user.DcCurrAccContactDetails?
                    .FirstOrDefault(x => x.ContactTypeId == ContactType.Email)
                    ?.ContactDesc;

            return null;
        }

        private static string BuildPayload(TrNotification notification, bool bodyOnly = false)
        {
            return JsonSerializer.Serialize(new
            {
                notification.NotificationId,
                notification.NotificationTypeCode,
                notification.Severity,
                notification.Title,
                notification.Body,
                notification.EntityType,
                notification.EntityKey,
                notification.StoreCode,
                BodyOnly = bodyOnly
            });
        }

        private static string ApplyPlaceholders(string template, Dictionary<string, string> placeholders)
        {
            string result = template;
            foreach (KeyValuePair<string, string> item in placeholders)
                result = result.Replace("{" + item.Key + "}", item.Value ?? string.Empty);

            return result;
        }

        private void AddAudit(long? notificationId, long? notificationRecipientId, string actionType, string? actorCurrAccCode, string? channelCode, string? note)
        {
            _db.TrNotificationAudits.Add(new TrNotificationAudit
            {
                NotificationId = notificationId,
                NotificationRecipientId = notificationRecipientId,
                ActionType = actionType,
                ActorCurrAccCode = actorCurrAccCode,
                ChannelCode = channelCode,
                ActionDate = DateTime.Now,
                Note = note
            });
        }
    }
}
