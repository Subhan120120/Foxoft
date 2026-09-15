using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Foxoft.AppCode.Service.Backup
{
    public static class BackupDatabaseScanner
    {
        private static readonly HashSet<string> SystemDatabases = new(StringComparer.OrdinalIgnoreCase)
        {
            "master",
            "model",
            "msdb",
            "tempdb"
        };

        /// <summary>
        /// Scans all online databases from the SQL Server instance.
        /// </summary>
        public static async Task<List<string>> GetOnlineDatabasesAsync(
            string connectionString,
            bool includeSystemDatabases = false,
            CancellationToken ct = default)
        {
            List<string> databases = new();

            // Use master database for instance-wide database queries
            SqlConnectionStringBuilder cb = new(connectionString)
            {
                InitialCatalog = "master",
                ConnectTimeout = 15
            };

            string query = @"
SELECT [name] = d.name
FROM sys.databases AS d
WHERE d.state_desc = 'ONLINE'
  AND d.name NOT IN ('tempdb')
ORDER BY d.name;";

            await using SqlConnection conn = new(cb.ConnectionString);
            await conn.OpenAsync(ct);

            await using SqlCommand cmd = new(query, conn);
            await using SqlDataReader reader = await cmd.ExecuteReaderAsync(ct);

            while (await reader.ReadAsync(ct))
            {
                string dbName = reader.GetString(0);
                if (!includeSystemDatabases && SystemDatabases.Contains(dbName))
                    continue;

                databases.Add(dbName);
            }

            return databases;
        }

        /// <summary>
        /// Resolves the concrete database list for a job at runtime.
        /// If DatabaseNames is '*' or empty, all current online user databases are returned dynamically.
        /// </summary>
        public static async Task<List<string>> ResolveDatabasesForJobAsync(
            string targetDatabasesConfig,
            string connectionString,
            CancellationToken ct = default)
        {
            List<string> allOnlineDbs = await GetOnlineDatabasesAsync(connectionString, false, ct);

            if (string.IsNullOrWhiteSpace(targetDatabasesConfig) || targetDatabasesConfig.Trim() == "*")
            {
                return allOnlineDbs;
            }

            string[] requestedDbs = targetDatabasesConfig
                .Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            // Return requested databases that are currently online
            HashSet<string> onlineSet = new(allOnlineDbs, StringComparer.OrdinalIgnoreCase);
            List<string> result = new();

            foreach (string db in requestedDbs)
            {
                if (onlineSet.Contains(db))
                    result.Add(db);
            }

            return result;
        }
    }
}
