using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public static class ReflectionExt
    {
        private static readonly ConcurrentDictionary<string, Func<string>> _captionResolverCache = new(StringComparer.OrdinalIgnoreCase);
        private static readonly object _initLock = new();
        private static bool _isMetadataInitialized = false;

        private static T GetAttribute<T>(this MemberInfo member, bool isRequired)
        where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }

            return (T)attribute;
        }

        public static string GetDisplayName<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            MemberInfo memberInfo = GetPropertyInformation(expression.Body)
                ?? throw new ArgumentException("No property reference expression was found.", nameof(expression));

            var attr = memberInfo.GetAttribute<DisplayAttribute>(false);
            if (attr != null)
            {
                var localized = attr.GetName();
                if (!string.IsNullOrWhiteSpace(localized))
                    return localized;
            }

            return memberInfo.Name;
        }

        private static MemberInfo GetPropertyInformation(Expression expression)
        {
            Debug.Assert(expression != null, "propertyExpression != null");
            MemberExpression memberExpr = expression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = expression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }

        /// <summary>
        /// Metadata xəritəsini (ReportCustomColumns və EF Core Entity-lərini) bir dəfə keşləyir.
        /// </summary>
        private static void EnsureMetadataInitialized()
        {
            if (_isMetadataInitialized) return;

            lock (_initLock)
            {
                if (_isMetadataInitialized) return;

                // 1. Hesabatların xüsusi/hesablanan sütunlar kataloqu (GrossProfit, NetProfit və s.)
                RegisterTypeProperties(typeof(ReportCustomColumns));

                // 2. EF Core Entity-ləri (yalnız 1 dəfə oxunur)
                try
                {
                    using subContext db = new();
                    foreach (IEntityType entityType in db.Model.GetEntityTypes())
                    {
                        foreach (var prop in entityType.GetProperties())
                        {
                            var pi = prop.PropertyInfo;
                            if (pi is null) continue;

                            var displayAttr = pi.GetCustomAttribute<DisplayAttribute>();
                            if (displayAttr is not null && !_captionResolverCache.ContainsKey(prop.Name))
                            {
                                _captionResolverCache[prop.Name] = () => displayAttr.GetName() ?? prop.Name;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Metadata initialization error: {ex.Message}");
                }

                _isMetadataInitialized = true;
            }
        }

        /// <summary>
        /// Xüsusi DTO və ya ViewModel sinfindəki [Display] atributlu xassələri keşə əlavə edir.
        /// </summary>
        public static void RegisterTypeProperties(Type type)
        {
            if (type == null) return;

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                if (displayAttr is not null)
                {
                    _captionResolverCache[prop.Name] = () => displayAttr.GetName() ?? prop.Name;
                }
            }
        }

        public static void SetCaptionName(DataTable dt)
        {
            SetCaptionName(dt, customModelType: null, reportContext: null);
        }

        public static void SetCaptionName(DataTable dt, string? reportContext)
        {
            SetCaptionName(dt, customModelType: null, reportContext: reportContext);
        }

        public static void SetCaptionName<TModel>(DataTable dt, string? reportContext = null)
        {
            SetCaptionName(dt, customModelType: typeof(TModel), reportContext: reportContext);
        }

        /// <summary>
        /// DataTable sütun başlıqlarını (Caption) Laylı Hiyerarxiya (Multi-Tier) vasitəsilə tərcümə edir.
        /// </summary>
        /// <param name="dt">Məlumat cədvəli</param>
        /// <param name="customModelType">Xüsusi hesabat və ya sorğu üçün DTO/Model tipi</param>
        /// <param name="reportContext">Hesabat adı və ya konteksti (məsələn, dcReport.ReportName)</param>
        public static void SetCaptionName(DataTable dt, Type? customModelType, string? reportContext = null)
        {
            if (dt == null || dt.Columns.Count == 0) return;

            EnsureMetadataInitialized();

            // Pillə 1: Query-ə xüsusi DTO/Model verilmişdirsə
            Dictionary<string, Func<string>>? customModelCaptions = null;
            if (customModelType != null)
            {
                customModelCaptions = new(StringComparer.OrdinalIgnoreCase);
                foreach (var prop in customModelType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttr != null)
                    {
                        customModelCaptions[prop.Name] = () => displayAttr.GetName() ?? prop.Name;
                    }
                }
            }

            string? cleanReportContext = !string.IsNullOrWhiteSpace(reportContext)
                ? Regex.Replace(reportContext.Trim(), @"[^\w]", "_")
                : null;

            foreach (DataColumn column in dt.Columns)
            {
                string colName = column.ColumnName;

                // Pillə 1: Xüsusi Model / DTO atributu
                if (customModelCaptions != null && customModelCaptions.TryGetValue(colName, out var customResolver))
                {
                    string resolved = customResolver();
                    if (!string.IsNullOrEmpty(resolved))
                    {
                        column.Caption = resolved;
                        continue;
                    }
                }

                // Pillə 2: Xüsusi hesabat kontekstinə aid resurs (Report_{ReportName}_{ColName} və ya Report_{ColName})
                if (!string.IsNullOrEmpty(cleanReportContext))
                {
                    string? repContextCol = Resources.ResourceManager.GetString($"Report_{cleanReportContext}_{colName}")
                                         ?? Resources.ResourceManager.GetString($"Report_{colName}");
                    if (!string.IsNullOrEmpty(repContextCol))
                    {
                        column.Caption = repContextCol;
                        continue;
                    }
                }

                // Pillə 3: Keşlənmiş Metadata (ReportCustomColumns kataloqu + EF Core Entity-ləri)
                if (_captionResolverCache.TryGetValue(colName, out var cachedResolver))
                {
                    string resolved = cachedResolver();
                    if (!string.IsNullOrEmpty(resolved))
                    {
                        column.Caption = resolved;
                        continue;
                    }
                }

                // Pillə 4: Resurs Konvensiyası (Fallback)
                string? fallback = Resources.ResourceManager.GetString("Report_" + colName)
                                ?? Resources.ResourceManager.GetString("Common_" + colName)
                                ?? Resources.ResourceManager.GetString("Entity_" + colName)
                                ?? Resources.ResourceManager.GetString(colName);

                if (!string.IsNullOrEmpty(fallback))
                {
                    column.Caption = fallback;
                }
            }
        }
    }
}
