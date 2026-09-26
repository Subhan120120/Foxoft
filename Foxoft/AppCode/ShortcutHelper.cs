using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft.AppCode
{
    /// <summary>
    /// Verilənlər bazasından shortcut-ları yükləyib Keys enum-a çevirən helper sinif.
    /// </summary>
    public static class ShortcutHelper
    {
        /// <summary>
        /// Verilmiş form üçün shortcut-ları yükləyir.
        /// Key = ButtonName, Value = Keys enum
        /// </summary>
        public static Dictionary<string, Keys> LoadShortcuts(string formName)
        {
            var result = new Dictionary<string, Keys>(StringComparer.OrdinalIgnoreCase);
            try
            {
                using var ctx = new subContext();
                EnsureDefaultShortcuts(ctx);

                var shortcuts = ctx.DcShortcuts
                    .Where(s => s.FormName == formName && s.ShortcutKeys != null && s.ShortcutKeys != "")
                    .ToList();

                foreach (var sc in shortcuts)
                {
                    Keys parsed = ParseKeys(sc.ShortcutKeys);
                    if (parsed != Keys.None)
                        result[sc.ButtonName] = parsed;
                }
            }
            catch (Exception)
            {
                // DB əlçatan olmadıqda boş dictionary qaytarılır
            }
            return result;
        }

        /// <summary>
        /// Bazada mövcud olmayan standart shortcut qeydlərini avtomatik əlavə edir.
        /// </summary>
        public static void EnsureDefaultShortcuts(subContext? ctx = null)
        {
            bool dispose = false;
            if (ctx == null)
            {
                ctx = new subContext();
                dispose = true;
            }

            try
            {
                var defaults = new List<DcShortcut>
                {
                    new DcShortcut { FormName = "UcReturn", ButtonName = "btn_Ok",        ShortcutKeys = "F10", ButtonDescription = "Qaytarışı Təsdiq Et" },
                    new DcShortcut { FormName = "UcReturn", ButtonName = "btn_Cancel",    ShortcutKeys = "Esc", ButtonDescription = "Ləğv Et" },
                    new DcShortcut { FormName = "UcReturn", ButtonName = "btn_ReturnAll", ShortcutKeys = "",   ButtonDescription = "Hamısını Qaytar" },
                    new DcShortcut { FormName = "UcReturn", ButtonName = "btn_Clear",     ShortcutKeys = "",   ButtonDescription = "Səbəti Təmizlə" },
                };

                bool changed = false;
                foreach (var item in defaults)
                {
                    if (!ctx.DcShortcuts.Any(s => s.FormName == item.FormName && s.ButtonName == item.ButtonName))
                    {
                        ctx.DcShortcuts.Add(item);
                        changed = true;
                    }
                }

                if (changed)
                    ctx.SaveChanges();
            }
            catch (Exception)
            {
                // DB əlçatan olmadıqda və ya xəta baş verərsə səssiz ötür
            }
            finally
            {
                if (dispose)
                    ctx.Dispose();
            }
        }

        /// <summary>
        /// Keys enum-u oxunaqlı string-ə çevirir.  Məs: "Ctrl+F3", "Esc"
        /// </summary>
        public static string KeysToString(Keys keys)
        {
            if (keys == Keys.None) return "";

            var parts = new List<string>();
            if ((keys & Keys.Control) == Keys.Control) parts.Add("Ctrl");
            if ((keys & Keys.Shift) == Keys.Shift) parts.Add("Shift");
            if ((keys & Keys.Alt) == Keys.Alt) parts.Add("Alt");

            Keys keyCode = keys & Keys.KeyCode;
            if (keyCode != Keys.ControlKey && keyCode != Keys.ShiftKey && keyCode != Keys.Menu && keyCode != Keys.None)
            {
                if (keyCode == Keys.Escape)
                    parts.Add("Esc");
                else
                    parts.Add(keyCode.ToString());
            }

            return string.Join("+", parts);
        }

        /// <summary>
        /// String-i Keys enum-a parse edir. Məs: "Ctrl+F3" → Keys.Control | Keys.F3, "Esc" → Keys.Escape
        /// </summary>
        public static Keys ParseKeys(string keysStr)
        {
            if (string.IsNullOrWhiteSpace(keysStr)) return Keys.None;

            Keys result = Keys.None;
            string[] parts = keysStr.Split('+');

            foreach (string part in parts)
            {
                string trimmed = part.Trim();

                if (trimmed.Equals("Ctrl", StringComparison.OrdinalIgnoreCase))
                    result |= Keys.Control;
                else if (trimmed.Equals("Shift", StringComparison.OrdinalIgnoreCase))
                    result |= Keys.Shift;
                else if (trimmed.Equals("Alt", StringComparison.OrdinalIgnoreCase))
                    result |= Keys.Alt;
                else if (trimmed.Equals("Esc", StringComparison.OrdinalIgnoreCase))
                    result |= Keys.Escape;
                else if (Enum.TryParse(trimmed, true, out Keys k))
                    result |= k;
            }

            return result;
        }

        /// <summary>
        /// Button text-inin sonuna shortcut göstərir. Məs: "Nağd (F3)"
        /// </summary>
        public static string AppendShortcutToText(string baseText, Keys keys)
        {
            if (keys == Keys.None) return baseText;

            string shortcutStr = KeysToString(keys);
            if (string.IsNullOrEmpty(shortcutStr)) return baseText;

            // Əvvəlki shortcut mətni varsa sil
            int idx = baseText.IndexOf(" (");
            if (idx >= 0)
                baseText = baseText.Substring(0, idx);

            return $"{baseText} ({shortcutStr})";
        }
    }
}
