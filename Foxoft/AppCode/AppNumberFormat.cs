using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Foxoft.AppCode
{
    public static class AppNumberFormat
    {
        public const string DefaultSystemKey = "Default";
        public const string DefaultQuantityFormat = "#,##0.######";
        public const string DefaultQuantitySummaryFormat = "{0:#,##0.######}";

        private static readonly HashSet<string> QuantityFieldNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "Qty",
            "QtyIn",
            "QtyOut",
            "RemainQty",
            "Quantity",
            "Count",
            "ReturnedQty"
        };

        private static readonly HashSet<Type> NumericTypes = new()
        {
            typeof(decimal), typeof(decimal?),
            typeof(double), typeof(double?),
            typeof(float), typeof(float?),
            typeof(int), typeof(int?),
            typeof(long), typeof(long?),
            typeof(short), typeof(short?),
            typeof(byte), typeof(byte?),
            typeof(uint), typeof(uint?),
            typeof(ulong), typeof(ulong?),
            typeof(ushort), typeof(ushort?),
            typeof(sbyte), typeof(sbyte?)
        };

        public static string DecimalSeparator { get; private set; } = ".";
        public static string GroupSeparator { get; private set; } = ",";
        public static int DecimalDigits { get; private set; } = 2;
        public static int? QuantityDecimalDigits { get; private set; } = null;
        public static char ActiveDecimalSeparatorChar => string.IsNullOrEmpty(DecimalSeparator) ? '.' : DecimalSeparator[0];
        public static CultureInfo ActiveCulture { get; private set; } = CultureInfo.CurrentCulture;

        public static string AmountFormatString => $"n{DecimalDigits}";
        public static string QuantityFormatString => BuildQuantityFormatString(QuantityDecimalDigits);
        public static string QuantitySummaryFormatString => $"{{0:{QuantityFormatString}}}";

        public static string BuildQuantityFormatString(int? digits)
        {
            int maxDigits = digits.HasValue && digits.Value >= 0 ? Math.Clamp(digits.Value, 0, 10) : 3;
            if (maxDigits == 0)
                return "#,##0";
            return $"#,##0.{new string('#', maxDigits)}";
        }

        private static NumberInputMessageFilter? _messageFilter;
        private static readonly object _filterLock = new();

        public static void Apply(string? decimalSeparator = null, string? groupSeparator = null, int? decimalDigits = null, int? quantityDecimalDigits = null)
        {
            CultureInfo sysCulture = CultureInfo.InstalledUICulture ?? CultureInfo.CurrentCulture;
            string sysDecSep = sysCulture.NumberFormat.NumberDecimalSeparator;
            string sysGrpSep = sysCulture.NumberFormat.NumberGroupSeparator;
            int sysDigits = sysCulture.NumberFormat.NumberDecimalDigits;

            // 1. Decimal Separator
            if (string.IsNullOrWhiteSpace(decimalSeparator) ||
                string.Equals(decimalSeparator, DefaultSystemKey, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(decimalSeparator, "System", StringComparison.OrdinalIgnoreCase))
            {
                DecimalSeparator = sysDecSep;
            }
            else
            {
                DecimalSeparator = decimalSeparator.Trim();
            }

            // 2. Group Separator
            if (string.IsNullOrWhiteSpace(groupSeparator) ||
                string.Equals(groupSeparator, DefaultSystemKey, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(groupSeparator, "System", StringComparison.OrdinalIgnoreCase))
            {
                GroupSeparator = sysGrpSep;
            }
            else if (string.Equals(groupSeparator, "None", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(groupSeparator, "Yoxdur", StringComparison.OrdinalIgnoreCase))
            {
                GroupSeparator = string.Empty;
            }
            else if (string.Equals(groupSeparator, "Space", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(groupSeparator, "Boşluq", StringComparison.OrdinalIgnoreCase) ||
                     groupSeparator == " ")
            {
                GroupSeparator = " ";
            }
            else
            {
                GroupSeparator = groupSeparator;
            }

            // Conflict resolution: Decimal and Group separators cannot be identical in .NET
            if (DecimalSeparator == GroupSeparator && !string.IsNullOrEmpty(GroupSeparator))
            {
                GroupSeparator = DecimalSeparator == "." ? "," : ".";
            }

            // 3. Amount Decimal Digits
            if (!decimalDigits.HasValue || decimalDigits.Value < 0)
            {
                DecimalDigits = sysDigits >= 0 ? sysDigits : 2;
            }
            else
            {
                DecimalDigits = Math.Clamp(decimalDigits.Value, 0, 10);
            }

            // 4. Quantity Decimal Digits
            if (!quantityDecimalDigits.HasValue || quantityDecimalDigits.Value < 0)
            {
                QuantityDecimalDigits = null; // System / Default (up to 3 decimals)
            }
            else
            {
                QuantityDecimalDigits = Math.Clamp(quantityDecimalDigits.Value, 0, 10);
            }

            // 5. Configure culture
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = DecimalSeparator;
            culture.NumberFormat.NumberGroupSeparator = GroupSeparator;
            culture.NumberFormat.NumberDecimalDigits = DecimalDigits;
            culture.NumberFormat.CurrencyDecimalSeparator = DecimalSeparator;
            culture.NumberFormat.CurrencyGroupSeparator = GroupSeparator;
            culture.NumberFormat.CurrencyDecimalDigits = DecimalDigits;

            ActiveCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            EnsureMessageFilter();
        }

        public static void ApplyFromDatabase()
        {
            try
            {
                using subContext dbContext = new();
                var setting = dbContext.AppSettings
                    .AsNoTracking()
                    .Where(x => x.Id == 1)
                    .Select(x => new
                    {
                        x.NumberDecimalSeparator,
                        x.NumberGroupSeparator,
                        x.NumberDecimalDigits,
                        x.QuantityDecimalDigits
                    })
                    .FirstOrDefault();

                if (setting != null)
                {
                    Apply(setting.NumberDecimalSeparator, setting.NumberGroupSeparator, setting.NumberDecimalDigits, setting.QuantityDecimalDigits);
                    return;
                }
            }
            catch
            {
            }

            ApplyFromSettings();
        }

        public static void ApplyFromSettings()
        {
            var appSetting = Properties.Settings.Default.AppSetting;
            Apply(appSetting?.NumberDecimalSeparator, appSetting?.NumberGroupSeparator, appSetting?.NumberDecimalDigits, appSetting?.QuantityDecimalDigits);
        }

        public static string FormatAmount(decimal value)
        {
            return value.ToString(AmountFormatString, ActiveCulture);
        }

        public static string FormatQuantity(decimal value)
        {
            return value.ToString(QuantityFormatString, ActiveCulture);
        }

        public static string FormatQuantity(object? value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            if (value is decimal dec)
                return FormatQuantity(dec);

            if (decimal.TryParse(value.ToString(), NumberStyles.Any, ActiveCulture, out decimal parsed) ||
                decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out parsed))
            {
                return FormatQuantity(parsed);
            }

            return value.ToString() ?? string.Empty;
        }

        public static bool IsQuantityColumn(GridColumn? column)
        {
            if (column == null)
                return false;

            if (!string.IsNullOrEmpty(column.FieldName) && QuantityFieldNames.Contains(column.FieldName))
                return true;

            if (!string.IsNullOrEmpty(column.Name) && column.Name.StartsWith("colQty", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public static bool IsNumericColumn(GridColumn? column)
        {
            if (column == null)
                return false;

            if (IsQuantityColumn(column))
                return true;

            if (column.ColumnType != null && IsNumericType(column.ColumnType))
                return true;

            if (column.DisplayFormat.FormatType == FormatType.Numeric)
                return true;

            return false;
        }

        public static bool IsNumericType(Type? type)
        {
            if (type == null)
                return false;

            return NumericTypes.Contains(type);
        }

        public static bool IsNumericInputControl(Control? control)
        {
            if (control == null)
                return false;

            if (control is CalcEdit || control is SpinEdit || control is NumericUpDown)
                return true;

            BaseEdit? baseEdit = null;
            if (control is TextBoxMaskBox maskBox)
                baseEdit = maskBox.OwnerEdit ?? maskBox.Parent as BaseEdit;
            else if (control is BaseEdit be)
                baseEdit = be;

            if (baseEdit != null)
            {
                if (baseEdit is CalcEdit || baseEdit is SpinEdit)
                    return true;

                if (baseEdit is TextEdit textEdit)
                {
                    if (textEdit.Properties.Mask.MaskType == MaskType.Numeric)
                        return true;

                    if (textEdit.Properties.DisplayFormat.FormatType == FormatType.Numeric ||
                        textEdit.Properties.EditFormat.FormatType == FormatType.Numeric)
                        return true;

                    GridControl? grid = FindParentGridControl(textEdit);
                    if (grid?.FocusedView is GridView gv && gv.FocusedColumn != null)
                    {
                        if (IsNumericColumn(gv.FocusedColumn))
                            return true;
                    }
                }
            }

            return false;
        }

        private static GridControl? FindParentGridControl(Control? control)
        {
            Control? current = control;
            while (current != null)
            {
                if (current is GridControl gc)
                    return gc;
                current = current.Parent;
            }
            return null;
        }

        public static void ConfigureActiveEditor(GridView view)
        {
            if (view?.ActiveEditor is not TextEdit editor)
                return;

            GridColumn? col = view.FocusedColumn;
            if (col == null)
                return;

            if (IsQuantityColumn(col))
            {
                editor.Properties.Mask.MaskType = MaskType.Numeric;
                editor.Properties.Mask.EditMask = QuantityFormatString;
                editor.Properties.Mask.UseMaskAsDisplayFormat = false;
                editor.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                editor.Properties.DisplayFormat.FormatString = QuantityFormatString;
                editor.Properties.EditFormat.FormatType = FormatType.Numeric;
                editor.Properties.EditFormat.FormatString = QuantityFormatString;
            }

            if (IsNumericColumn(col) || editor is CalcEdit || editor is SpinEdit)
            {
                view.GridControl?.BeginInvoke(new Action(() => editor.SelectAll()));
            }
        }

        public static void EnsureMessageFilter()
        {
            if (_messageFilter == null)
            {
                lock (_filterLock)
                {
                    if (_messageFilter == null)
                    {
                        _messageFilter = new NumberInputMessageFilter();
                        Application.AddMessageFilter(_messageFilter);
                    }
                }
            }
        }

        private class NumberInputMessageFilter : IMessageFilter
        {
            private const int WM_CHAR = 0x0102;
            private static bool _suppressNext = false;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg != WM_CHAR)
                    return false;

                if (_suppressNext)
                {
                    _suppressNext = false;
                    return false;
                }

                char c = (char)m.WParam.ToInt32();
                if (c == '.' || c == ',')
                {
                    Control? ctrl = Control.FromHandle(m.HWnd);
                    if (IsNumericInputControl(ctrl))
                    {
                        char target = ActiveDecimalSeparatorChar;
                        if (c != target)
                        {
                            _suppressNext = true;
                            PostMessage(m.HWnd, WM_CHAR, (IntPtr)target, m.LParam);
                            return true; // suppress original char
                        }
                    }
                }

                return false;
            }
        }
    }
}
