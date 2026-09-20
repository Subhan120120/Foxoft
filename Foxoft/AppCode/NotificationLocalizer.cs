using Foxoft.Models;
using Foxoft.Properties;
using System.Globalization;
using System.Threading;

namespace Foxoft.AppCode
{
    /// <summary>
    /// Centralized professional localization service for the Notification subsystem.
    /// Dynamically resolves localized names from resource files based on the active thread culture.
    /// </summary>
    public static class NotificationLocalizer
    {
        private static CultureInfo ActiveCulture => Thread.CurrentThread.CurrentUICulture ?? CultureInfo.CurrentUICulture;

        /// <summary>
        /// Gets the localized display name for a given notification type code.
        /// </summary>
        public static string GetTypeDescription(string? notificationTypeCode, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(notificationTypeCode))
                return fallback ?? string.Empty;

            string key = "NotificationType_" + notificationTypeCode.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : notificationTypeCode;
        }

        /// <summary>
        /// Gets the localized display name for a given notification category code.
        /// </summary>
        public static string GetCategoryName(string? categoryCode, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(categoryCode))
                return fallback ?? string.Empty;

            string key = "NotificationCategory_" + categoryCode.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : categoryCode;
        }

        /// <summary>
        /// Gets the localized display name for a given notification severity code.
        /// </summary>
        public static string GetSeverityName(string? severityCode, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(severityCode))
                return fallback ?? string.Empty;

            string key = "NotificationSeverity_" + severityCode.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : severityCode;
        }

        /// <summary>
        /// Gets the localized display name for a given notification channel code.
        /// </summary>
        public static string GetChannelName(string? channelCode, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(channelCode))
                return fallback ?? string.Empty;

            string key = "NotificationChannel_" + channelCode.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : channelCode;
        }

        /// <summary>
        /// Converts a comma-separated list of channel codes (e.g., "InApp,Popup,SMS") to localized names.
        /// </summary>
        public static string GetLocalizedChannelsString(string? channelCodesCsv)
        {
            if (string.IsNullOrWhiteSpace(channelCodesCsv))
                return string.Empty;

            string[] channels = channelCodesCsv.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (channels.Length == 0)
                return string.Empty;

            for (int i = 0; i < channels.Length; i++)
            {
                channels[i] = GetChannelName(channels[i]);
            }

            return string.Join(", ", channels);
        }

        /// <summary>
        /// Gets the localized display name for a recipient notification status.
        /// </summary>
        public static string GetRecipientStatusName(string? status, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(status))
                return fallback ?? string.Empty;

            string key = "NotificationRecipientStatus_" + status.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : status;
        }

        /// <summary>
        /// Gets the localized display name for a main notification status.
        /// </summary>
        public static string GetNotificationStatusName(string? status, string? fallback = null)
        {
            if (string.IsNullOrWhiteSpace(status))
                return fallback ?? string.Empty;

            string key = "NotificationStatus_" + status.Trim();
            string? localized = Resources.ResourceManager.GetString(key, ActiveCulture);

            if (!string.IsNullOrWhiteSpace(localized))
                return localized;

            return !string.IsNullOrWhiteSpace(fallback) ? fallback : status;
        }

        public static List<LocalizedLookupItem> GetCategoryItems()
        {
            return new List<LocalizedLookupItem>
            {
                new(NotificationCategories.Stock, GetCategoryName(NotificationCategories.Stock)),
                new(NotificationCategories.Sale, GetCategoryName(NotificationCategories.Sale)),
                new(NotificationCategories.Purchase, GetCategoryName(NotificationCategories.Purchase)),
                new(NotificationCategories.Payment, GetCategoryName(NotificationCategories.Payment)),
                new(NotificationCategories.Installment, GetCategoryName(NotificationCategories.Installment)),
                new(NotificationCategories.Customer, GetCategoryName(NotificationCategories.Customer)),
                new(NotificationCategories.System, GetCategoryName(NotificationCategories.System))
            };
        }

        public static List<LocalizedLookupItem> GetSeverityItems()
        {
            return new List<LocalizedLookupItem>
            {
                new(NotificationSeverities.Info, GetSeverityName(NotificationSeverities.Info)),
                new(NotificationSeverities.Warning, GetSeverityName(NotificationSeverities.Warning)),
                new(NotificationSeverities.High, GetSeverityName(NotificationSeverities.High)),
                new(NotificationSeverities.Critical, GetSeverityName(NotificationSeverities.Critical))
            };
        }

        public static List<LocalizedLookupItem> GetChannelItems()
        {
            return new List<LocalizedLookupItem>
            {
                new(NotificationChannels.InApp, GetChannelName(NotificationChannels.InApp)),
                new(NotificationChannels.Popup, GetChannelName(NotificationChannels.Popup)),
                new(NotificationChannels.Sms, GetChannelName(NotificationChannels.Sms)),
                new(NotificationChannels.WhatsApp, GetChannelName(NotificationChannels.WhatsApp)),
                new(NotificationChannels.Email, GetChannelName(NotificationChannels.Email))
            };
        }
    }

    public sealed record LocalizedLookupItem(string Code, string Name);
}
