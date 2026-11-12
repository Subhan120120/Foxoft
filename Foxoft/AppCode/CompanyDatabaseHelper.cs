using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft.AppCode
{
    public class DatabaseHealthResult
    {
        public bool IsHealthy { get; set; }
        public string CompanyCode { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }
    }

    public static class CompanyDatabaseHelper
    {
        public static string BuildConnectionString(string? companyCode, int timeoutSeconds = 5)
        {
            string baseConn = Settings.Default.SubConnString;
            if (string.IsNullOrWhiteSpace(baseConn))
                baseConn = Settings.Default.MainConnString;

            SqlConnectionStringBuilder builder = new(baseConn);

            if (!string.IsNullOrWhiteSpace(companyCode))
                builder.InitialCatalog = companyCode.Trim();

            builder.ConnectTimeout = timeoutSeconds;

            return builder.ConnectionString;
        }

        public static DatabaseHealthResult TestCompanyDatabase(string? companyCode, int timeoutSeconds = 4)
        {
            if (string.IsNullOrWhiteSpace(companyCode))
            {
                return new DatabaseHealthResult
                {
                    IsHealthy = false,
                    CompanyCode = string.Empty,
                    ErrorMessage = Resources.Form_Login_CompanyRequired
                };
            }

            string cleanCompanyCode = companyCode.Trim();
            string connString = BuildConnectionString(cleanCompanyCode, timeoutSeconds);

            try
            {
                DbContextOptionsBuilder<subContext> optionsBuilder = new();
                optionsBuilder.UseSqlServer(SqlLanguageHelper.GetLocalizedConnectionString(connString));

                using subContext db = new(optionsBuilder.Options);

                if (!db.Database.CanConnect())
                {
                    return new DatabaseHealthResult
                    {
                        IsHealthy = false,
                        CompanyCode = cleanCompanyCode,
                        ConnectionString = connString,
                        ErrorMessage = Resources.Common_DatabaseNotFound
                    };
                }

                // Verify basic schema readiness by querying AppSettings table
                using var connection = db.Database.GetDbConnection();
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT TOP 1 Id FROM AppSettings";
                command.CommandTimeout = timeoutSeconds;
                command.ExecuteScalar();

                return new DatabaseHealthResult
                {
                    IsHealthy = true,
                    CompanyCode = cleanCompanyCode,
                    ConnectionString = connString
                };
            }
            catch (Exception ex)
            {
                return new DatabaseHealthResult
                {
                    IsHealthy = false,
                    CompanyCode = cleanCompanyCode,
                    ConnectionString = connString,
                    ErrorMessage = ex.Message,
                    Exception = ex
                };
            }
        }

        public static string? FindFirstHealthyCompany(IEnumerable<DcCompany>? companies, string? excludeCompanyCode = null)
        {
            if (companies == null)
                return null;

            foreach (var comp in companies)
            {
                if (comp.IsDisabled)
                    continue;

                if (!string.IsNullOrEmpty(excludeCompanyCode) &&
                    string.Equals(comp.CompanyCode, excludeCompanyCode, StringComparison.OrdinalIgnoreCase))
                    continue;

                var result = TestCompanyDatabase(comp.CompanyCode, timeoutSeconds: 3);
                if (result.IsHealthy)
                    return comp.CompanyCode;
            }

            return null;
        }
    }
}
