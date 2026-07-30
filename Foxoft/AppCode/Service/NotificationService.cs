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

        public async Task<Notification?> CreateOrUpdateAsync(NotificationCreateRequest request, CancellationToken ct = default)
        {
            NotificationType? notificationType = await _db.NotificationTypes
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == request.NotificationTypeCode && x.IsEnabled, ct);

            if (notificationType == null)
            {
                await CancelActiveByKeyAsync(request.NotificationKey, ct);
                return null;
            }

            NotificationRule? rule = await ResolveRuleAsync(request.NotificationTypeCode, request.StoreCode, ct);
            if (rule == null || !rule.IsEnabled)
            {
                await CancelActiveByKeyAsync(request.NotificationKey, ct);
                return null;
            }

            DateTime now = DateTime.Now;
            string severity = request.Severity ?? notificationType.DefaultSeverity;
            (string title, string body) = await ResolveTextAsync(notificationType.NotificationTypeCode, request, ct);
            bool shouldCreateOutbox = false;

            Notification? notification = await _db.Notifications
                .Include(x => x.NotificationRecipients)
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
                notification = new Notification
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

                _db.Notifications.Add(notification);
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

            IQueryable<NotificationRecipient> query = _db.NotificationRecipients
                .AsNoTracking()
                .Include(x => x.Notification)
                    .ThenInclude(x => x.NotificationType)
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.Notification.NotificationType.IsEnabled)
                .Where(x => x.Notification.Status == NotificationStatuses.Active
                         || x.Notification.Status == NotificationStatuses.Resolved)
                .Where(x => x.Status != NotificationRecipientStatuses.Dismissed)
                .Where(x => x.Status != NotificationRecipientStatuses.Snoozed || x.SnoozedUntil <= now);

            query = WhereEffectiveRuleIsEnabled(query);

            if (filter.DateFrom.HasValue)
                query = query.Where(x => x.Notification.CreatedDate >= filter.DateFrom.Value.Date);

            if (filter.DateTo.HasValue)
            {
                DateTime dateTo = filter.DateTo.Value.Date.AddDays(1);
                query = query.Where(x => x.Notification.CreatedDate < dateTo);
            }

            if (!string.IsNullOrWhiteSpace(filter.StoreCode))
                query = query.Where(x => x.Notification.StoreCode == filter.StoreCode);

            if (!string.IsNullOrWhiteSpace(filter.CategoryCode))
                query = query.Where(x => x.Notification.NotificationType.CategoryCode == filter.CategoryCode);

            switch (filter.Preset)
            {
                case "Unread":
                    query = query.Where(x => x.Notification.Status == NotificationStatuses.Active
                                          && x.Status == NotificationRecipientStatuses.Unread);
                    break;
                case "Critical":
                    query = query.Where(x => x.Notification.Status == NotificationStatuses.Active
                                          && x.Notification.Severity == NotificationSeverities.Critical);
                    break;
                case "Today":
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);
                    query = query.Where(x => x.Notification.CreatedDate >= today && x.Notification.CreatedDate < tomorrow);
                    break;
            }

            return await query
                .OrderByDescending(x => x.Notification.CreatedDate)
                .Select(x => new NotificationInboxItem
                {
                    NotificationId = x.NotificationId,
                    NotificationRecipientId = x.NotificationRecipientId,
                    CreatedDate = x.Notification.CreatedDate,
                    NotificationTypeCode = x.Notification.NotificationTypeCode,
                    NotificationTypeDesc = x.Notification.NotificationType.NotificationTypeDesc,
                    CategoryCode = x.Notification.NotificationType.CategoryCode,
                    Severity = x.Notification.Severity,
                    StoreCode = x.Notification.StoreCode,
                    Title = x.Notification.Title,
                    Body = x.Notification.Body,
                    NotificationStatus = x.Notification.Status,
                    RecipientStatus = x.Status,
                    EntityType = x.Notification.EntityType,
                    EntityKey = x.Notification.EntityKey,
                    SnoozedUntil = x.SnoozedUntil,
                    LastRaisedDate = x.Notification.LastRaisedDate
                })
                .ToListAsync(ct);
        }

        public Task<int> GetUnreadCountAsync(string currAccCode, CancellationToken ct = default)
        {
            DateTime now = DateTime.Now;
            IQueryable<NotificationRecipient> query = _db.NotificationRecipients
                .AsNoTracking()
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.Notification.NotificationType.IsEnabled)
                .Where(x => x.Notification.Status == NotificationStatuses.Active)
                .Where(x => x.Status == NotificationRecipientStatuses.Unread)
                .Where(x => x.SnoozedUntil == null || x.SnoozedUntil <= now);

            return WhereEffectiveRuleIsEnabled(query).CountAsync(ct);
        }

        public Task<List<NotificationInboxItem>> GetPopupCandidatesAsync(string currAccCode, CancellationToken ct = default)
        {
            DateTime now = DateTime.Now;
            IQueryable<NotificationRecipient> query = _db.NotificationRecipients
                .AsNoTracking()
                .Include(x => x.Notification)
                    .ThenInclude(x => x.NotificationType)
                .Where(x => x.CurrAccCode == currAccCode)
                .Where(x => x.Status == NotificationRecipientStatuses.Unread)
                .Where(x => x.Notification.NotificationType.IsEnabled)
                .Where(x => x.Notification.Status == NotificationStatuses.Active)
                .Where(x => x.Notification.NotificationType.AllowPopup)
                .Where(x => x.LastPopupShownDate == null || x.LastPopupShownDate.Value.AddMinutes(30) <= now)
                .Where(x => x.SnoozedUntil == null || x.SnoozedUntil <= now)
                .Where(x => x.Notification.Severity == NotificationSeverities.High
                         || x.Notification.Severity == NotificationSeverities.Critical);

            return WhereEffectiveRuleIsEnabled(query)
                .OrderByDescending(x => x.Notification.Severity == NotificationSeverities.Critical)
                .ThenByDescending(x => x.Notification.CreatedDate)
                .Take(5)
                .Select(x => new NotificationInboxItem
                {
                    NotificationId = x.NotificationId,
                    NotificationRecipientId = x.NotificationRecipientId,
                    CreatedDate = x.Notification.CreatedDate,
                    NotificationTypeCode = x.Notification.NotificationTypeCode,
                    NotificationTypeDesc = x.Notification.NotificationType.NotificationTypeDesc,
                    CategoryCode = x.Notification.NotificationType.CategoryCode,
                    Severity = x.Notification.Severity,
                    StoreCode = x.Notification.StoreCode,
                    Title = x.Notification.Title,
                    Body = x.Notification.Body,
                    NotificationStatus = x.Notification.Status,
                    RecipientStatus = x.Status,
                    EntityType = x.Notification.EntityType,
                    EntityKey = x.Notification.EntityKey,
                    SnoozedUntil = x.SnoozedUntil,
                    LastRaisedDate = x.Notification.LastRaisedDate
                })
                .ToListAsync(ct);
        }

        public async Task MarkPopupShownAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            NotificationRecipient? recipient = await _db.NotificationRecipients
                .FirstOrDefaultAsync(x => x.NotificationRecipientId == notificationRecipientId, ct);

            if (recipient == null)
                return;

            recipient.LastPopupShownDate = DateTime.Now;
            AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.PopupShown, actorCurrAccCode, null, null);
            await _db.SaveChangesAsync(ct);
        }

        public async Task MarkReadAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            NotificationRecipient? recipient = await _db.NotificationRecipients
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
            List<NotificationRecipient> recipients = await _db.NotificationRecipients
                .Where(x => x.CurrAccCode == currAccCode
                         && x.Notification.Status == NotificationStatuses.Active
                         && x.Status == NotificationRecipientStatuses.Unread)
                .ToListAsync(ct);

            DateTime now = DateTime.Now;
            foreach (NotificationRecipient recipient in recipients)
            {
                recipient.Status = NotificationRecipientStatuses.Read;
                recipient.ReadDate = now;
                AddAudit(recipient.NotificationId, recipient.NotificationRecipientId, NotificationActionTypes.Read, currAccCode, null, null);
            }

            await _db.SaveChangesAsync(ct);
        }

        public async Task DismissAsync(long notificationRecipientId, string actorCurrAccCode, CancellationToken ct = default)
        {
            NotificationRecipient? recipient = await _db.NotificationRecipients
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
            NotificationRecipient? recipient = await _db.NotificationRecipients
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
            Notification? notification = await _db.Notifications
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
            IQueryable<Notification> query = _db.Notifications
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

            List<Notification> notifications = await query.ToListAsync(ct);

            DateTime now = DateTime.Now;
            foreach (Notification notification in notifications)
            {
                if (keySet.Contains(notification.NotificationKey))
                    continue;

                notification.Status = NotificationStatuses.Resolved;
                notification.ResolvedDate = now;
                AddAudit(notification.NotificationId, null, NotificationActionTypes.Resolved, actorCurrAccCode, null, null);
            }

            await _db.SaveChangesAsync(ct);
        }

        private async Task<NotificationRule?> ResolveRuleAsync(string notificationTypeCode, string? storeCode, CancellationToken ct)
        {
            NotificationRule? storeRule = null;
            if (!string.IsNullOrWhiteSpace(storeCode))
            {
                storeRule = await _db.NotificationRules
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.NotificationTypeCode == notificationTypeCode
                                           && x.StoreCode == storeCode, ct);
            }

            return storeRule ?? await _db.NotificationRules
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.NotificationTypeCode == notificationTypeCode
                                       && x.StoreCode == null, ct);
        }

        private IQueryable<NotificationRecipient> WhereEffectiveRuleIsEnabled(IQueryable<NotificationRecipient> query)
        {
            return query.Where(recipient =>
                _db.NotificationRules.Any(rule =>
                    rule.NotificationTypeCode == recipient.Notification.NotificationTypeCode
                    && rule.IsEnabled
                    && ((rule.StoreCode == null && recipient.Notification.StoreCode == null)
                        || rule.StoreCode == recipient.Notification.StoreCode))
                || (!_db.NotificationRules.Any(rule =>
                        rule.NotificationTypeCode == recipient.Notification.NotificationTypeCode
                        && ((rule.StoreCode == null && recipient.Notification.StoreCode == null)
                            || rule.StoreCode == recipient.Notification.StoreCode))
                    && _db.NotificationRules.Any(rule =>
                        rule.NotificationTypeCode == recipient.Notification.NotificationTypeCode
                        && rule.StoreCode == null
                        && rule.IsEnabled)));
        }

        private async Task CancelActiveByKeyAsync(string notificationKey, CancellationToken ct)
        {
            Notification? notification = await _db.Notifications
                .FirstOrDefaultAsync(x => x.NotificationKey == notificationKey
                                       && x.Status == NotificationStatuses.Active, ct);

            if (notification == null)
                return;

            DateTime now = DateTime.Now;
            notification.Status = NotificationStatuses.Cancelled;
            notification.LastUpdatedDate = now;

            List<NotificationChannelOutbox> pendingOutboxes = await _db.NotificationChannelOutboxes
                .Where(x => x.NotificationId == notification.NotificationId
                         && x.Status == NotificationOutboxStatuses.Pending)
                .ToListAsync(ct);

            foreach (NotificationChannelOutbox outbox in pendingOutboxes)
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

            NotificationTemplate? template = await _db.NotificationTemplates
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

        private async Task EnsureRecipientsAsync(Notification notification, NotificationRule rule, CancellationToken ct)
        {
            HashSet<string> existingRecipients = notification.NotificationRecipients
                .Select(x => x.CurrAccCode)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            List<DcCurrAcc> recipients = await ResolveRecipientsAsync(notification.NotificationTypeCode, notification.StoreCode, ct);

            foreach (DcCurrAcc currAcc in recipients)
            {
                if (existingRecipients.Contains(currAcc.CurrAccCode))
                    continue;

                NotificationRecipient recipient = new()
                {
                    NotificationId = notification.NotificationId,
                    CurrAccCode = currAcc.CurrAccCode,
                    Status = NotificationRecipientStatuses.Unread
                };

                _db.NotificationRecipients.Add(recipient);
                AddAudit(notification.NotificationId, null, NotificationActionTypes.Assigned, currAcc.CurrAccCode, null, null);
            }
        }

        private async Task<List<DcCurrAcc>> ResolveRecipientsAsync(string notificationTypeCode, string? storeCode, CancellationToken ct)
        {
            List<NotificationRecipientRule> rules = await _db.NotificationRecipientRules
                .AsNoTracking()
                .Where(x => x.NotificationTypeCode == notificationTypeCode && x.IsEnabled)
                .Where(x => x.StoreCode == null || x.StoreCode == storeCode)
                .ToListAsync(ct);

            Dictionary<string, DcCurrAcc> users = new(StringComparer.OrdinalIgnoreCase);

            foreach (NotificationRecipientRule rule in rules)
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

        private async Task EnsureOutboxAsync(Notification notification, NotificationRule rule, NotificationCreateRequest request, CancellationToken ct)
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
                List<NotificationRecipient> recipients = await _db.NotificationRecipients
                    .Include(x => x.DcCurrAcc)
                        .ThenInclude(x => x.DcCurrAccContactDetails)
                    .Where(x => x.NotificationId == notification.NotificationId)
                    .ToListAsync(ct);

                foreach (string channel in deliveryChannels)
                {
                    foreach (NotificationRecipient recipient in recipients)
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
            Notification notification,
            string channel,
            string receiver,
            string payload,
            long? notificationRecipientId,
            string? actorCurrAccCode,
            CancellationToken ct)
        {
            bool alreadyQueued = await _db.NotificationChannelOutboxes
                .AnyAsync(x => x.NotificationId == notification.NotificationId
                            && x.ChannelCode == channel
                            && x.Receiver == receiver
                            && x.Status == NotificationOutboxStatuses.Pending, ct);

            if (alreadyQueued)
                return;

            _db.NotificationChannelOutboxes.Add(new NotificationChannelOutbox
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

        private static string BuildPayload(Notification notification, bool bodyOnly = false)
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
            _db.NotificationAudits.Add(new NotificationAudit
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
