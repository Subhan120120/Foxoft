using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Foxoft
{
    public static class MathExtensions
    {
        public static bool Between(this decimal num, decimal lower, decimal upper, bool inclusive = false)
        {
            if (lower > upper) // Swapping Values parametr lower and upper
            {
                decimal upper2 = upper;
                upper = lower;
                lower = upper2;
            }
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        public static bool IsNumeric(this object value)
        {
            if (value == null)
                return false;

            double number;
            return Double.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture)
                                  , NumberStyles.Any
                                  , NumberFormatInfo.InvariantInfo
                                  , out number);
        }

        //public static DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
