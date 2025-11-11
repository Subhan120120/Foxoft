using Foxoft.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Foxoft
{
    public static class ReflectionExt
    {
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


        public static void SetCaptionName(DataTable dt)
        {
            using subContext db = new();

            foreach (DataColumn column in dt.Columns)
            {
                foreach (IEntityType entityType in db.Model.GetEntityTypes())
                {
                    var efProp = entityType.FindProperty(column.ColumnName);
                    var pi = efProp?.PropertyInfo;
                    if (pi is null) continue;

                    var attName = pi.GetAttribute<DisplayAttribute>(false);
                    if (attName is null) continue;

                    var display = attName.GetName(); // <-- əsas düzəliş
                    if (!string.IsNullOrEmpty(display))
                    {
                        column.Caption = display;
                        break; // uyğunluq tapıldısa, digər entity-lərə baxmağa ehtiyac yoxdur
                    }
                }
            }
        }

    }
}
