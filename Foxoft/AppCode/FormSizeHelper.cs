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
        private static readonly Dictionary<string, FormSizeInfo> _cache;
        private static readonly object _lock = new();

        /// <summary>
        /// Tracks the previous non-minimized WindowState per form so we can detect
        /// Maximize / Restore transitions and save the correct state on close.
        /// </summary>
        private static readonly Dictionary<Form, FormWindowState> _previousStates = new();

        /// <summary>
        /// Tracks all currently active forms.
        /// </summary>
        private static readonly HashSet<Form> _trackedForms = new();

        /// <summary>
        /// Flag to prevent updating state during application/parent shutdown.
        /// </summary>
        private static bool _isShuttingDown = false;

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

            lock (_lock)
            {
                if (_trackedForms.Contains(form)) return;
                _trackedForms.Add(form);
            }

            RestoreSize(form);

            // Keep track of the last known stable state in memory (ignoring Minimized)
            FormWindowState initialState = form.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : form.WindowState;
            lock (_lock)
            {
                _previousStates[form] = initialState;
            }

            // ResizeEnd fires only on border drag — captures Normal size changes
            form.ResizeEnd += OnFormResizeEnd;

            // Resize fires on Maximize/Restore/Minimize button clicks
            form.Resize += OnFormResize;

            // Use FormClosing (not FormClosed) so we save BEFORE the Dispose() handler
            form.FormClosing += OnFormClosing;

            // Clean up on disposal to avoid memory leaks
            form.Disposed += OnFormDisposed;

            if (form.MdiParent != null)
            {
                form.MdiParent.FormClosing += OnMdiParentClosing;
            }
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
            if (_isShuttingDown) return;

            if (sender is Form form)
            {
                if (form.WindowState == FormWindowState.Normal)
                {
                    lock (_lock)
                    {
                        SaveSizeInternal(form);
                        PersistInternal();
                    }
                }
            }
        }

        /// <summary>
        /// Detects Maximize / Restore / Minimize via WindowState change.
        /// Only saves when the state actually changed to avoid redundant writes.
        /// </summary>
        private static void OnFormResize(object sender, EventArgs e)
        {
            if (_isShuttingDown) return;

            if (sender is Form form)
            {
                if (form.WindowState != FormWindowState.Minimized)
                {
                    lock (_lock)
                    {
                        _previousStates.TryGetValue(form, out FormWindowState previous);

                        if (form.WindowState != previous)
                        {
                            _previousStates[form] = form.WindowState;
                            SaveSizeInternal(form);
                            PersistInternal();
                        }
                    }
                }
            }
        }

        private static void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isShuttingDown) return;

            if (sender is Form form)
            {
                lock (_lock)
                {
                    SaveSizeInternal(form);
                    PersistInternal();
                    Cleanup(form);
                }
            }
        }

        private static void OnFormDisposed(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                Cleanup(form);
            }
        }

        private static void OnMdiParentClosing(object sender, FormClosingEventArgs e)
        {
            lock (_lock)
            {
                if (_isShuttingDown) return;
                _isShuttingDown = true;

                // Save all currently tracked active forms
                foreach (Form form in _trackedForms)
                {
                    SaveSizeInternal(form);
                }
                PersistInternal();
            }
        }

        private static FormWindowState GetStateToSave(Form form)
        {
            if (form.MdiParent != null)
            {
                Form activeChild = form.MdiParent.ActiveMdiChild;
                if (activeChild != null && activeChild != form)
                {
                    if (activeChild.WindowState == FormWindowState.Maximized)
                    {
                        return FormWindowState.Maximized;
                    }
                }
            }

            _previousStates.TryGetValue(form, out FormWindowState lastState);
            if (lastState == FormWindowState.Minimized)
            {
                lastState = FormWindowState.Normal;
            }
            return lastState;
        }

        private static void SaveSizeInternal(Form form)
        {
            string key = GetKey(form);
            if (string.IsNullOrEmpty(key)) return;

            FormWindowState stateToSave = GetStateToSave(form);

            int width;
            int height;

            if (form.WindowState == FormWindowState.Normal)
            {
                width = form.Width;
                height = form.Height;
            }
            else
            {
                width = form.RestoreBounds.Width;
                height = form.RestoreBounds.Height;
            }

            // Fallback if RestoreBounds or size is invalid (e.g., during startup/shutdown of minimized forms)
            if (width <= 0 || height <= 0)
            {
                width = form.Width > 0 ? form.Width : 800;
                height = form.Height > 0 ? form.Height : 600;
            }

            FormSizeInfo info = new()
            {
                Width = width,
                Height = height,
                State = stateToSave
            };

            _cache[key] = info;
        }

        private static void Cleanup(Form form)
        {
            lock (_lock)
            {
                if (!_trackedForms.Contains(form)) return;

                form.ResizeEnd -= OnFormResizeEnd;
                form.Resize -= OnFormResize;
                form.FormClosing -= OnFormClosing;
                form.Disposed -= OnFormDisposed;
                if (form.MdiParent != null)
                {
                    form.MdiParent.FormClosing -= OnMdiParentClosing;
                }
                _previousStates.Remove(form);
                _trackedForms.Remove(form);
            }
        }

        private static string GetKey(Form form)
        {
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

        private static void PersistInternal()
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
