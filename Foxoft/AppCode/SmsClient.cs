using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode
{
    public sealed class SmsClient : IDisposable
    {
        private readonly HttpClient _http;
        private readonly DcSmsProviderSetting _setting;

        public SmsClient(DcSmsProviderSetting setting)
        {
            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _http = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15)
            };

            if (!string.IsNullOrWhiteSpace(_setting.ApiKey))
            {
                _http.DefaultRequestHeaders.Add("X-API-KEY", _setting.ApiKey);
            }
        }

        public async Task<string> SendSmsAsync(string receiver, string message, CancellationToken ct = default)
        {
            if (!_setting.IsEnabled)
                throw new InvalidOperationException("SMS provayder aktiv deyil.");

            if (string.IsNullOrWhiteSpace(_setting.ServerUrl))
                throw new InvalidOperationException("SMS provayder URL ünvanı təyin edilməyib.");

            if (string.IsNullOrWhiteSpace(receiver))
                throw new ArgumentException("Alıcı nömrəsi daxil edilməyib.", nameof(receiver));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Mesaj mətni daxil edilməyib.", nameof(message));

            string normalizedPhone = NormalizePhoneNumber(receiver);
            string url = _setting.ServerUrl.Trim();

            // Check if URL contains query placeholders: e.g. {phone}, {text}, {apikey}, {sender}
            if (url.Contains("{phone}") || url.Contains("{text}"))
            {
                string requestUrl = url
                    .Replace("{phone}", Uri.EscapeDataString(normalizedPhone))
                    .Replace("{text}", Uri.EscapeDataString(message))
                    .Replace("{apikey}", Uri.EscapeDataString(_setting.ApiKey ?? string.Empty))
                    .Replace("{sender}", Uri.EscapeDataString(_setting.SenderTitle ?? string.Empty));

                using var getResp = await _http.GetAsync(requestUrl, ct);
                string getBody = await getResp.Content.ReadAsStringAsync(ct);

                if (!getResp.IsSuccessStatusCode)
                    throw new HttpRequestException($"SMS göndərişi uğursuz oldu: HTTP {getResp.StatusCode} - {getBody}");

                return getBody;
            }

            // Default: Send JSON POST payload
            var payload = new Dictionary<string, object>
            {
                ["to"] = normalizedPhone,
                ["message"] = message,
                ["sender"] = _setting.SenderTitle ?? "Foxoft"
            };

            if (!string.IsNullOrWhiteSpace(_setting.ApiKey))
                payload["apiKey"] = _setting.ApiKey;

            if (!string.IsNullOrWhiteSpace(_setting.Username))
                payload["username"] = _setting.Username;

            if (!string.IsNullOrWhiteSpace(_setting.Password))
                payload["password"] = _setting.Password;

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            using var postResp = await _http.PostAsync(url, content, ct);
            string postBody = await postResp.Content.ReadAsStringAsync(ct);

            if (!postResp.IsSuccessStatusCode)
                throw new HttpRequestException($"SMS göndərişi uğursuz oldu: HTTP {postResp.StatusCode} - {postBody}");

            return postBody;
        }

        private static string NormalizePhoneNumber(string phone)
        {
            string clean = phone.Trim().Replace("+", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);
            if (clean.Length == 10 && clean.StartsWith("0"))
                clean = "994" + clean.Substring(1);
            else if (clean.Length == 9)
                clean = "994" + clean;
            return clean;
        }

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}
