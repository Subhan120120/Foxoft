namespace Foxoft.NotificationWorker
{
    public sealed class NotificationWorkerOptions
    {
        public const string SectionName = "NotificationWorker";

        public bool EnableOutbox { get; set; } = true;
        public bool EnableInstallmentChecks { get; set; } = true;
        public bool RunOnce { get; set; }
        public int OutboxIntervalSeconds { get; set; } = 60;
        public int OutboxBatchSize { get; set; } = 50;
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
            using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty(SectionName, out System.Text.Json.JsonElement section))
                return new NotificationWorkerOptions();

            NotificationWorkerOptions? options = System.Text.Json.JsonSerializer.Deserialize<NotificationWorkerOptions>(
                section.GetRawText(),
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return options ?? new NotificationWorkerOptions();
        }

        private static void ApplyArgs(NotificationWorkerOptions options, string[] args)
        {
            for (int index = 0; index < args.Length; index++)
            {
                string key = args[index].TrimStart('-', '/');
                string? value = index + 1 < args.Length ? args[index + 1] : null;

                if (string.IsNullOrWhiteSpace(value) || value.StartsWith("--") || value.StartsWith('/'))
                    continue;

                switch (key.ToLowerInvariant())
                {
                    case "connection":
                    case "connectionstring":
                        options.ConnectionString = value;
                        index++;
                        break;
                    case "outboxintervalseconds":
                        if (int.TryParse(value, out int outboxInterval))
                            options.OutboxIntervalSeconds = outboxInterval;
                        index++;
                        break;
                    case "outboxbatchsize":
                        if (int.TryParse(value, out int batchSize))
                            options.OutboxBatchSize = batchSize;
                        index++;
                        break;
                    case "enableoutbox":
                        if (bool.TryParse(value, out bool enableOutbox))
                            options.EnableOutbox = enableOutbox;
                        index++;
                        break;
                    case "enableinstallmentchecks":
                        if (bool.TryParse(value, out bool enableInstallmentChecks))
                            options.EnableInstallmentChecks = enableInstallmentChecks;
                        index++;
                        break;
                    case "installmentcheckintervalseconds":
                        if (int.TryParse(value, out int installmentCheckInterval))
                            options.InstallmentCheckIntervalSeconds = installmentCheckInterval;
                        index++;
                        break;
                    case "installmentreminderdaysbefore":
                        if (int.TryParse(value, out int installmentReminderDaysBefore))
                            options.InstallmentReminderDaysBefore = installmentReminderDaysBefore;
                        index++;
                        break;
                    case "runonce":
                        if (bool.TryParse(value, out bool runOnce))
                            options.RunOnce = runOnce;
                        index++;
                        break;
                    case "actor":
                    case "actorcurracccode":
                        options.ActorCurrAccCode = value;
                        index++;
                        break;
                }
            }
        }
    }
}
