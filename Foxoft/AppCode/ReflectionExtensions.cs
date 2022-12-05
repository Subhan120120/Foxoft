using Foxoft.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Foxoft
{
   public static class ReflectionExtensions
   {
      public static T GetAttribute<T>(this MemberInfo member, bool isRequired)
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

      public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> expression)
      {
         var memberInfo = GetPropertyInformation(expression.Body);
         if (memberInfo == null)
         {
            throw new ArgumentException(
                "No property reference expression was found.",
                "propertyExpression");
         }

         var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
         if (attr == null)
         {
            return memberInfo.Name;
         }

         return attr.DisplayName;
      }

      public static MemberInfo GetPropertyInformation(Expression expression)
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


      public static void GetCaptionName(DataTable dt)
      {
         subContext db = new();
         foreach (DataColumn column in dt.Columns)
         {
            foreach (IEntityType entityType in db.Model.GetEntityTypes())
            {
               //PropertyInfo myPropInfo = typeof(TrInvoiceHeader).GetProperty("MyProperty");
               IProperty myPropInfo = entityType.FindProperty(column.ColumnName);

               if (myPropInfo is not null)
               {
                  DisplayNameAttribute attName = myPropInfo.PropertyInfo.GetAttribute<DisplayNameAttribute>(false);

                  if (attName is not null)
                     column.Caption = attName.DisplayName;
               }
            }
         }
      }
   }
}
