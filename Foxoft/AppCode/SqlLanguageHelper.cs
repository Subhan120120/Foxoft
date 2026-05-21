using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Foxoft.AppCode
{
    public static class SqlLanguageHelper
    {
        public static string GetLocalizedConnectionString(string baseConnectionString)
        {
            if (string.IsNullOrWhiteSpace(baseConnectionString))
                return baseConnectionString;

            var builder = new SqlConnectionStringBuilder(baseConnectionString);
            
            string currentLang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            
            builder.CurrentLanguage = currentLang switch
            {
                "tr" => "Turkish",
                "az" => "Turkish", 
                "ru" => "Russian",
                "en" => "English",
                _ => "English"
            };

            return builder.ConnectionString;
        }
    }
}
