using System;
using System.IO;
using System.Text.Json;

namespace Foxoft.BackupWorker
{
    public sealed class BackupWorkerOptions
    {
        public const string SectionName = "BackupWorker";

        public int CheckIntervalSeconds { get; set; } = 30;
        public bool RunOnce { get; set; }
        public int? JobId { get; set; }
        public string? ConnectionString { get; set; }

        public static BackupWorkerOptions Load(string[] args)
        {
            BackupWorkerOptions options = LoadFromJson();
            ApplyArgs(options, args);
            return options;
        }

        private static BackupWorkerOptions LoadFromJson()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (!File.Exists(path))
                path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            if (!File.Exists(path))
                return new BackupWorkerOptions();

            try
            {
                string json = File.ReadAllText(path);
                using JsonDocument document = JsonDocument.Parse(json);

                if (!document.RootElement.TryGetProperty(SectionName, out JsonElement section))
                    return new BackupWorkerOptions();

                BackupWorkerOptions? options = JsonSerializer.Deserialize<BackupWorkerOptions>(
                    section.GetRawText(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return options ?? new BackupWorkerOptions();
            }
            catch
            {
                return new BackupWorkerOptions();
            }
        }

        private static void ApplyArgs(BackupWorkerOptions options, string[] args)
        {
            for (int index = 0; index < args.Length; index++)
            {
                string arg = args[index];
                string key = arg.TrimStart('-', '/');

                if (string.Equals(key, "runonce", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "run-once", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "once", StringComparison.OrdinalIgnoreCase))
                {
                    options.RunOnce = true;
                    continue;
                }

                string? value = null;
                int eqIndex = arg.IndexOf('=');
                if (eqIndex >= 0)
                {
                    key = arg[..eqIndex].TrimStart('-', '/');
                    value = arg[(eqIndex + 1)..].Trim('"', '\'');
                }
                else if (index + 1 < args.Length && !args[index + 1].StartsWith("-") && !args[index + 1].StartsWith("/"))
                {
                    value = args[++index].Trim('"', '\'');
                }

                if (string.IsNullOrWhiteSpace(value))
                    continue;

                if (string.Equals(key, "connection", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "connectionstring", StringComparison.OrdinalIgnoreCase))
                {
                    options.ConnectionString = value;
                }
                else if (string.Equals(key, "check-interval", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(key, "interval", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(value, out int parsedVal))
                        options.CheckIntervalSeconds = parsedVal;
                }
                else if (string.Equals(key, "job-id", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(key, "jobid", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(key, "job", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(value, out int parsedId))
                        options.JobId = parsedId;
                }
            }
        }
    }
}
