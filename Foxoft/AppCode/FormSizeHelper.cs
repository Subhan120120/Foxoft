using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Foxoft.AppCode
{
    /// <summary>
    /// Saves and restores child form window sizes to a local JSON file.
    /// Each form is identified by its <see cref="Form.Name"/> property (the formKey).
    /// </summary>
    public static class FormSizeHelper
    {
        private static readonly string FilePath;
        private static Dictionary<string, FormSizeInfo> _cache;
        private static readonly object _lock = new();

        static FormSizeHelper()
        {
            string appDataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Foxoft");

            Directory.CreateDirectory(appDataDir);
            FilePath = Path.Combine(appDataDir, "FormSizes.json");
            _cache = Load();
        }

        /// <summary>
        /// Attaches resize/move tracking to the form and restores its last saved size.
        /// Call this right after showing the MDI child form.
        /// </summary>
        public static void Track(Form form)
        {
            if (form == null) return;

            RestoreSize(form);

            form.ResizeEnd += OnFormResizeEnd;
            form.FormClosed += OnFormClosed;
        }

        private static void RestoreSize(Form form)
        {
            string key = GetKey(form);
            if (string.IsNullOrEmpty(key)) return;

            lock (_lock)
            {
                if (_cache.TryGetValue(key, out FormSizeInfo info))
                {
                    if (info.State == FormWindowState.Maximized)
                    {
                        form.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.Size = new Size(info.Width, info.Height);
                    }
                }
            }
        }

        private static void OnFormResizeEnd(object sender, EventArgs e)
        {
            if (sender is Form form)
                SaveSize(form);
        }

        private static void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
            {
                SaveSize(form);
                form.ResizeEnd -= OnFormResizeEnd;
                form.FormClosed -= OnFormClosed;
            }
        }

        private static void SaveSize(Form form)
        {
            string key = GetKey(form);
            if (string.IsNullOrEmpty(key)) return;

            FormSizeInfo info = new()
            {
                Width = form.WindowState == FormWindowState.Normal ? form.Width : form.RestoreBounds.Width,
                Height = form.WindowState == FormWindowState.Normal ? form.Height : form.RestoreBounds.Height,
                State = form.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : form.WindowState
            };

            lock (_lock)
            {
                _cache[key] = info;
                Persist();
            }
        }

        private static string GetKey(Form form)
        {
            // Use the form's Name (which is the formKey set by ShowNewForm/ShowExistForm)
            // Fall back to type name if Name is empty
            return !string.IsNullOrEmpty(form.Name) ? form.Name : form.GetType().Name;
        }

        private static Dictionary<string, FormSizeInfo> Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath, Encoding.UTF8);
                    return JsonSerializer.Deserialize<Dictionary<string, FormSizeInfo>>(json)
                           ?? new Dictionary<string, FormSizeInfo>();
                }
            }
            catch
            {
                // If the file is corrupted, start fresh
            }

            return new Dictionary<string, FormSizeInfo>();
        }

        private static void Persist()
        {
            try
            {
                JsonSerializerOptions options = new() { WriteIndented = true };
                string json = JsonSerializer.Serialize(_cache, options);
                File.WriteAllText(FilePath, json, Encoding.UTF8);
            }
            catch
            {
                // Silently ignore write failures (e.g., disk full)
            }
        }
    }

    public class FormSizeInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public FormWindowState State { get; set; }
    }
}
