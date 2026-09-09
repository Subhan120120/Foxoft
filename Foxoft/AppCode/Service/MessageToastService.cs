using DevExpress.XtraBars.Alerter;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
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

        public static bool IsInCache(Guid messageLogId, bool isSuccessful) =>
            _shownLogCache.ContainsKey((messageLogId, isSuccessful));

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

        public static void ShowSentToast(string channel, string receiver, string? detail = null, Guid? messageLogId = null)
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

            ShowToastInternal(caption, text);
        }

        public static void ShowUnsentToast(string channel, string receiver, string? errorMessage = null, Guid? messageLogId = null)
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

            ShowToastInternal(caption, text);
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

        private static void ShowToastInternal(string caption, string text)
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
                        ac.Show(mainForm, new AlertInfo(caption, text));
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