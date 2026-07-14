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
        /// Tracks all currently active forms.
        /// </summary>
        private static readonly HashSet<Form> _trackedForms = new();

        /// <summary>
        /// Flag to prevent updating state during application/parent shutdown.
        /// When the MDI parent begins closing, child forms are internally
        /// un-maximized by WinForms before their own FormClosing fires.
        /// We snapshot all states up-front and ignore subsequent transitions.
        /// </summary>
        private static bool _isShuttingDown;

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
                    // In MDI, if any sibling child is maximized then all children
                    // share maximized layout — respect that regardless of cache.
                    if (info.State == FormWindowState.Maximized || AnySiblingMaximized(form))
                    {
                        form.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.Size = new Size(info.Width, info.Height);
                    }
                }
                // If there is no cache entry, don't touch the form's current state.
                // ShowNewForm already sets Maximized before calling Track.
            }
        }

        /// <summary>
        /// Returns true if the form is an MDI child and any of its sibling
        /// children is currently maximized.  In standard MDI, all children
        /// share the same maximized layout, so a "Normal" state on a
        /// background child is only an internal artefact of WinForms.
        /// </summary>
        private static bool AnySiblingMaximized(Form form)
        {
            if (form.MdiParent == null) return false;

            foreach (Form child in form.MdiParent.MdiChildren)
            {
                if (child != form && child.WindowState == FormWindowState.Maximized)
                    return true;
            }
            return false;
        }

        private static void OnFormResizeEnd(object sender, EventArgs e)
        {
            if (_isShuttingDown) return;

            if (sender is Form form && form.WindowState == FormWindowState.Normal)
            {
                lock (_lock)
                {
                    SaveSizeInternal(form);
                    PersistInternal();
                }
            }
        }

        /// <summary>
        /// Detects Maximize / Restore via WindowState change.
        /// Skips Minimized transitions and MDI phantom Normal transitions
        /// where WinForms internally sets a background child to Normal while
        /// a sibling is maximized.
        /// </summary>
        private static void OnFormResize(object sender, EventArgs e)
        {
            if (_isShuttingDown) return;

            if (sender is Form form)
            {
                // Ignore minimize — nothing to save
                if (form.WindowState == FormWindowState.Minimized) return;

                // Ignore phantom Normal transitions caused by MDI internal re-layout.
                // When one MDI child is maximized, WinForms internally un-maximizes
                // background children. This is not a real user action.
                if (form.WindowState == FormWindowState.Normal && AnySiblingMaximized(form))
                    return;

                lock (_lock)
                {
                    SaveSizeInternal(form);
                    PersistInternal();
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

        /// <summary>
        /// Fires when the MDI parent begins closing. At this point the child
        /// forms have not yet been un-maximized, so we can snapshot the true
        /// user-visible state.
        ///
        /// Note: WinForms fires children's FormClosing events BEFORE the
        /// parent's FormClosing.  However, by that time MDI has already
        /// started its internal cleanup and some children may appear Normal.
        /// We handle that via AnySiblingMaximized in SaveSizeInternal.
        /// </summary>
        private static void OnMdiParentClosing(object sender, FormClosingEventArgs e)
        {
            lock (_lock)
            {
                if (_isShuttingDown) return;
                _isShuttingDown = true;

                foreach (Form form in _trackedForms)
                {
                    SaveSizeInternal(form);
                }
                PersistInternal();
            }
        }

        private static void SaveSizeInternal(Form form)
        {
            string key = GetKey(form);
            if (string.IsNullOrEmpty(key)) return;

            // Determine the real state.
            // In MDI, background children report Normal even when the user
            // sees them as maximized (because a sibling is maximized).
            FormWindowState stateToSave;
            if (form.WindowState == FormWindowState.Maximized || AnySiblingMaximized(form))
            {
                stateToSave = FormWindowState.Maximized;
            }
            else if (form.WindowState == FormWindowState.Minimized)
            {
                // Minimized → keep whatever was previously in the cache, or
                // fall back to Normal so we never persist Minimized.
                if (_cache.TryGetValue(key, out FormSizeInfo existing))
                    stateToSave = existing.State;
                else
                    stateToSave = FormWindowState.Normal;
            }
            else
            {
                stateToSave = FormWindowState.Normal;
            }

            // Get the Normal-mode size (used when restoring as Normal).
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

            // Fallback for invalid sizes
            if (width <= 0 || height <= 0)
            {
                if (_cache.TryGetValue(key, out FormSizeInfo prev) && prev.Width > 0 && prev.Height > 0)
                {
                    width = prev.Width;
                    height = prev.Height;
                }
                else
                {
                    width = 800;
                    height = 600;
                }
            }

            _cache[key] = new FormSizeInfo
            {
                Width = width,
                Height = height,
                State = stateToSave
            };
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
