using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Alerter;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft.AppCode.Service
{
    public static class MessageToastService
    {
        private static readonly ConcurrentDictionary<(Guid LogId, bool IsSuccessful), byte> _shownLogCache = new();
        private static DateTime _lastCheckedTime = DateTime.Now.AddSeconds(-5);
        private static readonly SemaphoreSlim _checkLock = new(1, 1);
        private static AlertControl? _alertControl;

        private static SvgImage? _whatsAppSvg;
        private static SvgImage? _smsSvg;
        private static SvgImage? _printSvg;
        private static Image? _whatsAppIcon;
        private static Image? _smsIcon;
        private static Image? _printIcon;
        private static readonly object _iconLock = new();

        public static bool IsInCache(Guid messageLogId, bool isSuccessful) =>
            _shownLogCache.ContainsKey((messageLogId, isSuccessful));

        public static Image? GetWhatsAppIcon()
        {
            if (_whatsAppIcon == null)
            {
                lock (_iconLock)
                {
                    if (_whatsAppIcon == null)
                    {
                        _whatsAppSvg ??= LoadSvg("WhatsApp.svg");
                        _whatsAppIcon = RenderSvgToImage(_whatsAppSvg, 36, 36);
                    }
                }
            }
            return _whatsAppIcon != null ? (Image)_whatsAppIcon.Clone() : null;
        }

        public static Image? GetSmsIcon()
        {
            if (_smsIcon == null)
            {
                lock (_iconLock)
                {
                    if (_smsIcon == null)
                    {
                        _smsSvg ??= LoadSvg("SMS.svg");
                        _smsIcon = RenderSvgToImage(_smsSvg, 36, 36);
                    }
                }
            }
            return _smsIcon != null ? (Image)_smsIcon.Clone() : null;
        }

        public static Image? GetPrintIcon()
        {
            if (_printIcon == null)
            {
                lock (_iconLock)
                {
                    if (_printIcon == null)
                    {
                        _printSvg ??= LoadSvg("Print.svg");
                        _printIcon = RenderSvgToImage(_printSvg, 36, 36);
                    }
                }
            }
            return _printIcon != null ? (Image)_printIcon.Clone() : null;
        }

        public static Image? GetChannelOrProviderIcon(string? channel, string? provider = null)
        {
            string target = $"{channel} {provider}".Trim();

            if (string.IsNullOrWhiteSpace(target))
                return GetWhatsAppIcon();

            if (target.IndexOf("sms", StringComparison.OrdinalIgnoreCase) >= 0)
                return GetSmsIcon();

            if (target.IndexOf("whatsapp", StringComparison.OrdinalIgnoreCase) >= 0)
                return GetWhatsAppIcon();

            return GetWhatsAppIcon();
        }

        private static SvgImage? LoadSvg(string fileName)
        {
            try
            {
                string[] candidateDirs = new[]
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources"),
                    Path.Combine(Application.StartupPath, "Resources"),
                    Path.Combine(AppContext.BaseDirectory, "Resources"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Foxoft", "Resources"),
                    AppDomain.CurrentDomain.BaseDirectory
                };

                foreach (string dir in candidateDirs)
                {
                    try
                    {
                        string fullPath = Path.Combine(dir, fileName);
                        if (File.Exists(fullPath))
                        {
                            return SvgImage.FromFile(fullPath);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            try
            {
                var assembly = typeof(MessageToastService).Assembly;
                string resName = $"Foxoft.Resources.{fileName}";
                using Stream? stream = assembly.GetManifestResourceStream(resName);
                if (stream != null)
                {
                    return SvgImage.FromStream(stream);
                }
            }
            catch
            {
            }

            return null;
        }

        private static Image? RenderSvgToImage(SvgImage? svg, int width = 36, int height = 36)
        {
            if (svg == null)
                return null;

            try
            {
                SvgBitmap bitmap = new(svg);
                return bitmap.Render(new Size(width, height), null);
            }
            catch
            {
                return null;
            }
        }

        private static AlertControl GetAlertControl()
        {
            if (_alertControl == null)
            {
                _alertControl = new AlertControl
                {
                    AutoFormDelay = 6000,
                    FormDisplaySpeed = AlertFormDisplaySpeed.Fast,
                    ShowPinButton = false,
                    AllowHtmlText = true
                };

                _alertControl.AlertClick += (sender, args) =>
                {
                    try
                    {
                        var mainForm = Application.OpenForms.OfType<FormERP>().FirstOrDefault();
                        if (mainForm != null && mainForm.IsHandleCreated)
                        {
                            mainForm.BeginInvoke((Action)(() =>
                            {
                                mainForm.Activate();
                                mainForm.ShowExistForm<FormMessageLog>();
                            }));
                        }
                    }
                    catch
                    {
                    }
                };
            }

            return _alertControl;
        }

        public static void ShowSentToast(string channel, string receiver, string? detail = null, Guid? messageLogId = null, string? provider = null)
        {
            if (messageLogId.HasValue)
            {
                _shownLogCache.TryAdd((messageLogId.Value, true), 0);
            }

            string caption = $"<b>✓ {channel} - {Resources.Common_Toast_MessageSent}</b>";
            string text = string.Format(Resources.Common_Toast_Receiver, receiver);
            if (!string.IsNullOrWhiteSpace(detail))
            {
                text += $"\n{detail}";
            }

            Image? icon = GetChannelOrProviderIcon(channel, provider);
            ShowToastInternal(caption, text, icon);
        }

        public static void ShowUnsentToast(string channel, string receiver, string? errorMessage = null, Guid? messageLogId = null, string? provider = null)
        {
            if (messageLogId.HasValue)
            {
                _shownLogCache.TryAdd((messageLogId.Value, false), 0);
            }

            string caption = $"<b><color=red>⚠ {channel} - {Resources.Common_Toast_MessageUnsent}</color></b>";
            string text = string.Format(Resources.Common_Toast_Receiver, receiver);
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                text += $"\n{string.Format(Resources.Common_Toast_Error, errorMessage)}";
            }

            Image? icon = GetChannelOrProviderIcon(channel, provider);
            ShowToastInternal(caption, text, icon);
        }

        public static string ResolvePrinterName(string? printerName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(printerName)
                    && PrinterSettings.InstalledPrinters
                        .Cast<string>()
                        .Any(installedPrinter => string.Equals(installedPrinter, printerName, StringComparison.OrdinalIgnoreCase)))
                {
                    return printerName;
                }

                string defaultPrinter = new PrinterSettings().PrinterName;
                if (!string.IsNullOrWhiteSpace(defaultPrinter))
                    return defaultPrinter;
            }
            catch
            {
            }

            return printerName ?? string.Empty;
        }

        public static void ShowPrintSuccess(Control? owner, string printerName, AlertControl? alertControl = null)
        {
            ShowPrintNotification(owner, printerName, isSuccess: true, errorMessage: null, alertControl);
        }

        public static void ShowPrintFailed(Control? owner, string printerName, string? errorMessage = null, AlertControl? alertControl = null)
        {
            ShowPrintNotification(owner, printerName, isSuccess: false, errorMessage, alertControl);
        }

        public static void ShowPrintResult(Control? owner, string printerName, bool isSuccess, string? errorMessage = null, AlertControl? alertControl = null)
        {
            ShowPrintNotification(owner, printerName, isSuccess, errorMessage, alertControl);
        }

        [Obsolete("Print notification now appears only once upon completion showing success or failure.")]
        public static void ShowPrintSending(Control? owner, string printerName, AlertControl? alertControl = null)
        {
            // Intentionally no-op: notifications should only appear once showing success or failure.
        }

        public static void ShowPrintSent(Control? owner, string printerName, AlertControl? alertControl = null)
        {
            ShowPrintSuccess(owner, printerName, alertControl);
        }

        private static void ShowPrintNotification(Control? owner, string printerName, bool isSuccess, string? errorMessage = null, AlertControl? alertControl = null)
        {
            try
            {
                Form? form = (owner as Form) ?? owner?.FindForm() ?? Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.IsHandleCreated);
                if (form == null) return;

                void ShowAction()
                {
                    try
                    {
                        AlertControl ac = alertControl ?? GetAlertControl();
                        ac.AllowHtmlText = true;

                        string caption = isSuccess
                            ? $"<b><color=green>✓</color> {Resources.Common_PrintSent}</b>"
                            : $"<b><color=red>⚠ {Resources.Common_PrintFailed}</color></b>";

                        string resolvedPrinter = ResolvePrinterName(printerName);
                        string displayPrinter = !string.IsNullOrWhiteSpace(resolvedPrinter) ? resolvedPrinter : "-";
                        string text = string.Format(Resources.Common_PrinterLabel, displayPrinter);

                        if (!isSuccess && !string.IsNullOrWhiteSpace(errorMessage))
                        {
                            text += $"\n{string.Format(Resources.Common_Toast_Error, errorMessage)}";
                        }

                        ac.Show(form, caption, text, string.Empty, GetPrintIcon(), null);
                    }
                    catch
                    {
                    }
                }

                if (form.InvokeRequired)
                {
                    form.BeginInvoke((Action)ShowAction);
                }
                else
                {
                    ShowAction();
                }
            }
            catch
            {
            }
        }

        public static async Task CheckRecentMessageLogsAsync(Form? owner = null, string? currAccCode = null, CancellationToken ct = default)
        {
            string? currentUser = currAccCode ?? Authorization.CurrAccCode;
            if (string.IsNullOrWhiteSpace(currentUser))
                return;

            if (!_checkLock.Wait(0))
                return;

            try
            {
                DateTime checkThreshold = _lastCheckedTime.AddSeconds(-2);
                using var db = new subContext();

                var recentLogs = await db.TrMessageLogs
                    .AsNoTracking()
                    .Where(x => ((x.LastTryDate != null && x.LastTryDate > checkThreshold) ||
                                 (x.LastTryDate == null && x.CreatedDate > checkThreshold)) &&
                                (x.Sender == currentUser || x.CreatedUserName == currentUser))
                    .OrderBy(x => x.LastTryDate ?? x.CreatedDate)
                    .Take(10)
                    .ToListAsync(ct);

                if (recentLogs.Count == 0)
                {
                    DateTime safeThreshold = DateTime.Now.AddSeconds(-5);
                    if (safeThreshold > _lastCheckedTime)
                        _lastCheckedTime = safeThreshold;
                    return;
                }

                DateTime maxTime = _lastCheckedTime;
                foreach (TrMessageLog log in recentLogs)
                {
                    DateTime logTime = log.LastTryDate ?? log.CreatedDate;
                    if (logTime > maxTime)
                        maxTime = logTime;

                    if (!_shownLogCache.TryAdd((log.MessageLogId, log.IsSuccessful), 0))
                        continue;

                    string channel = string.IsNullOrWhiteSpace(log.ChannelCode) ? "WhatsApp" : log.ChannelCode;
                    string phone = log.ReceiverPhoneNumber ?? string.Empty;

                    if (log.IsSuccessful)
                    {
                        string detail = !string.IsNullOrWhiteSpace(log.Message)
                            ? log.Message
                            : (!string.IsNullOrWhiteSpace(log.MessageType) ? log.MessageType : string.Empty);
                        if (detail.Length > 80)
                            detail = detail.Substring(0, 77) + "...";

                        ShowSentToast(channel, phone, detail, log.MessageLogId);
                    }
                    else
                    {
                        ShowUnsentToast(channel, phone, log.LastError, log.MessageLogId);
                    }
                }

                _lastCheckedTime = maxTime;

                // Prevent unbounded growth of memory cache
                if (_shownLogCache.Count > 2000)
                {
                    _shownLogCache.Clear();
                }
            }
            catch
            {
                // Suppress background query exceptions
            }
            finally
            {
                _checkLock.Release();
            }
        }

        private static void ShowToastInternal(string caption, string text, Image? icon = null)
        {
            try
            {
                var mainForm = Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.IsHandleCreated);
                if (mainForm == null)
                    return;

                mainForm.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        AlertControl ac = GetAlertControl();
                        var info = new AlertInfo(caption, text, icon);
                        ac.Show(mainForm, info);
                    }
                    catch
                    {
                    }
                }));
            }
            catch
            {
            }
        }
    }
}