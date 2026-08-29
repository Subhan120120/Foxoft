using System;
using System.IO;
using System.Text.Json;

namespace Foxoft.NotificationWorker
{
    public sealed class NotificationWorkerOptions
    {
        public const string SectionName = "NotificationWorker";

        public bool EnableOutbox { get; set; } = true;
        public bool EnableWhatsAppRetry { get; set; } = true;
        public bool EnableScheduledMessaging { get; set; } = true;
        public bool EnableInstallmentChecks { get; set; } = true;
        public bool RunOnce { get; set; }

        public int OutboxIntervalSeconds { get; set; } = 30;
        public int OutboxBatchSize { get; set; } = 50;

        public int WhatsAppRetryIntervalSeconds { get; set; } = 30;
        public int WhatsAppMaxRetries { get; set; } = 5;

        public int ScheduledMessagingDailyHour { get; set; } = 9;

        public int InstallmentCheckIntervalSeconds { get; set; } = 3600;
        public int InstallmentReminderDaysBefore { get; set; } = 2;

        public string ActorCurrAccCode { get; set; } = "NotificationWorker";
        public string? ConnectionString { get; set; }

        public static NotificationWorkerOptions Load(string[] args)
        {
            NotificationWorkerOptions options = LoadFromJson();
            ApplyArgs(options, args);
            return options;
        }

        private static NotificationWorkerOptions LoadFromJson()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (!File.Exists(path))
                path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            if (!File.Exists(path))
                return new NotificationWorkerOptions();

            string json = File.ReadAllText(path);
            using JsonDocument document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty(SectionName, out JsonElement section))
                return new NotificationWorkerOptions();

            NotificationWorkerOptions? options = JsonSerializer.Deserialize<NotificationWorkerOptions>(
                section.GetRawText(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return options ?? new NotificationWorkerOptions();
        }

        private static void ApplyArgs(NotificationWorkerOptions options, string[] args)
        {
            for (int index = 0; index < args.Length; index++)
            {
                string arg = args[index];
                string key = arg.TrimStart('-', '/');

                // Check boolean flag with no value
                if (string.Equals(key, "runonce", StringComparison.OrdinalIgnoreCase))
                {
                    options.RunOnce = true;
                    continue;
                }

                string? value = index + 1 < args.Length && !args[index + 1].StartsWith("-") && !args[index + 1].StartsWith("/")
                    ? args[index + 1]
                    : null;

                switch (key.ToLowerInvariant())
                {
                    case "connection":
                    case "connectionstring":
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            options.ConnectionString = value;
                            index++;
                        }
                        break;
                    case "outboxintervalseconds":
                        if (int.TryParse(value, out int outboxInterval))
                        {
                            options.OutboxIntervalSeconds = outboxInterval;
                            index++;
                        }
                        break;
                    case "outboxbatchsize":
                        if (int.TryParse(value, out int batchSize))
                        {
                            options.OutboxBatchSize = batchSize;
                            index++;
                        }
                        break;
                    case "enableoutbox":
                        if (bool.TryParse(value, out bool enableOutbox))
                        {
                            options.EnableOutbox = enableOutbox;
                            index++;
                        }
                        else
                        {
                            options.EnableOutbox = true;
                        }
                        break;
                    case "enablewhatsappretry":
                        if (bool.TryParse(value, out bool enableWhatsAppRetry))
                        {
                            options.EnableWhatsAppRetry = enableWhatsAppRetry;
                            index++;
                        }
                        else
                        {
                            options.EnableWhatsAppRetry = true;
                        }
                        break;
                    case "whatsappretryintervalseconds":
                        if (int.TryParse(value, out int whatsAppRetryInterval))
                        {
                            options.WhatsAppRetryIntervalSeconds = whatsAppRetryInterval;
                            index++;
                        }
                        break;
                    case "whatsappmaxretries":
                        if (int.TryParse(value, out int maxRetries))
                        {
                            options.WhatsAppMaxRetries = maxRetries;
                            index++;
                        }
                        break;
                    case "enablescheduledmessaging":
                        if (bool.TryParse(value, out bool enableScheduled))
                        {
                            options.EnableScheduledMessaging = enableScheduled;
                            index++;
                        }
                        else
                        {
                            options.EnableScheduledMessaging = true;
                        }
                        break;
                    case "scheduledmessagingdailyhour":
                        if (int.TryParse(value, out int dailyHour))
                        {
                            options.ScheduledMessagingDailyHour = dailyHour;
                            index++;
                        }
                        break;
                    case "enableinstallmentchecks":
                        if (bool.TryParse(value, out bool enableInstallmentChecks))
                        {
                            options.EnableInstallmentChecks = enableInstallmentChecks;
                            index++;
                        }
                        else
                        {
                            options.EnableInstallmentChecks = true;
                        }
                        break;
                    case "installmentcheckintervalseconds":
                        if (int.TryParse(value, out int installmentCheckInterval))
                        {
                            options.InstallmentCheckIntervalSeconds = installmentCheckInterval;
                            index++;
                        }
                        break;
                    case "installmentreminderdaysbefore":
                        if (int.TryParse(value, out int installmentReminderDaysBefore))
                        {
                            options.InstallmentReminderDaysBefore = installmentReminderDaysBefore;
                            index++;
                        }
                        break;
                    case "actor":
                    case "actorcurracccode":
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            options.ActorCurrAccCode = value;
                            index++;
                        }
                        break;
                }
            }
        }
    }
}
