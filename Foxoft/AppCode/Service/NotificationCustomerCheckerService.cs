using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service
{
    public sealed class NotificationCustomerCheckerService
    {
        private static readonly string[] CustomerBirthdayTypeCodes =
        {
            NotificationTypeCodes.CustomerBirthday
        };

        private readonly subContext _db;

        public NotificationCustomerCheckerService(subContext db)
        {
            _db = db;
        }

        public async Task<int> ScanBirthdayNotificationsAsync(
            string? actorCurrAccCode = null,
            CancellationToken ct = default)
        {
            DateTime scanStartedAt = DateTime.Now;
            DateTime today = DateTime.Today;

            var customers = await _db.DcCurrAccs
                .AsNoTracking()
                .Where(c => c.BirthDate.HasValue
                         && c.BirthDate.Value.Month == today.Month
                         && c.BirthDate.Value.Day == today.Day
                         && !string.IsNullOrEmpty(c.PhoneNum)
                         && !c.IsDisabled)
                .ToListAsync(ct);

            if (customers.Count == 0)
                return 0;

            NotificationService notificationService = new(_db);
            HashSet<string> activeKeys = new(StringComparer.OrdinalIgnoreCase);
            int affectedCount = 0;

            foreach (var customer in customers)
            {
                var store = await _db.DcCurrAccs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CurrAccCode == customer.StoreCode, ct)
                    ?? await _db.DcCurrAccs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CurrAccCode == Authorization.StoreCode, ct);

                string notificationKey = $"{NotificationTypeCodes.CustomerBirthday}:Customer:{customer.CurrAccCode}:{today:yyyyMMdd}";
                var placeholders = new Dictionary<string, string>
                {
                    ["CurrAccCode"] = customer.CurrAccCode,
                    ["CurrAccDesc"] = customer.CurrAccDesc ?? string.Empty,
                    ["PhoneNum"] = customer.PhoneNum ?? string.Empty,
                    ["StoreCode"] = customer.StoreCode ?? string.Empty,
                    ["StoreDesc"] = store?.CurrAccDesc ?? string.Empty,
                    ["StorePhone"] = store?.PhoneNum ?? string.Empty
                };

                var channelReceivers = new[]
                {
                    new NotificationChannelReceiver(NotificationChannels.WhatsApp, customer.PhoneNum, BodyOnly: true)
                };

                TrNotification? notification = await notificationService.CreateOrUpdateAsync(
                    new NotificationCreateRequest(
                        NotificationTypeCode: NotificationTypeCodes.CustomerBirthday,
                        NotificationKey: notificationKey,
                        Severity: NotificationSeverities.Info,
                        EntityType: NotificationEntityTypes.Customer,
                        EntityKey: customer.CurrAccCode,
                        StoreCode: customer.StoreCode,
                        Placeholders: placeholders,
                        ExpireDate: today.AddDays(1),
                        ChannelReceivers: channelReceivers),
                    ct);

                if (notification != null)
                {
                    activeKeys.Add(notificationKey);
                    affectedCount++;
                }
            }

            await notificationService.ResolveInactiveKeysAsync(
                activeKeys,
                CustomerBirthdayTypeCodes,
                actorCurrAccCode,
                ct,
                maxLastRaisedDate: scanStartedAt);

            return affectedCount;
        }
    }
}
