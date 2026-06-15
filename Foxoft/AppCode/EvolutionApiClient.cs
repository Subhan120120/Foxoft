using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.Properties;

namespace Foxoft.AppCode
{
    public sealed class EvolutionApiClient : IDisposable
    {
        private readonly HttpClient _http;
        private readonly string _serverUrl;
        private readonly string _instanceName;

        public EvolutionApiClient(string serverUrl, string instanceName, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(serverUrl)) throw new ArgumentNullException(nameof(serverUrl));
            if (string.IsNullOrWhiteSpace(instanceName)) throw new ArgumentNullException(nameof(instanceName));
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));

            _serverUrl = serverUrl.TrimEnd('/');
            _instanceName = instanceName;

            _http = new HttpClient();
            _http.DefaultRequestHeaders.Add("apikey", apiKey);
        }

        public async Task<string> SendImageBase64Async(string to, Stream stream, string? caption = null,
                                                      string mimeType = "image/png", CancellationToken ct = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (stream.CanSeek) stream.Position = 0;
            var bytes = await ReadAllBytesAsync(stream, ct);
            var base64String = Convert.ToBase64String(bytes);

            string url = $"{_serverUrl}/message/sendMedia/{_instanceName}";

            var payload = new
            {
                number = to,
                mediatype = "image",
                media = base64String,
                mimetype = mimeType,
                caption = caption ?? ""
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using var resp = await _http.PostAsync(url, content, ct);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw CreateSendException(resp, body);

            return body;
        }

        public async Task<string> SendTextAsync(string to, string message, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentNullException(nameof(to));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

            string url = $"{_serverUrl}/message/sendText/{_instanceName}";

            var payload = new
            {
                number = to,
                text = message
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using var resp = await _http.PostAsync(url, content, ct);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw CreateSendException(resp, body);

            return body;
        }

        public async Task<List<EvolutionGroupInfo>> FetchAllGroupsAsync(CancellationToken ct = default)
        {
            string url = $"{_serverUrl}/group/fetchAllGroups/{Uri.EscapeDataString(_instanceName)}?getParticipants=false";

            using var resp = await _http.GetAsync(url, ct);
            var body = await resp.Content.ReadAsStringAsync(ct);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(Resources.Common_WhatsAppApiSendFailed, body), null, resp.StatusCode);

            var groups = new List<EvolutionGroupInfo>();

            using JsonDocument doc = JsonDocument.Parse(body);
            JsonElement root = doc.RootElement;

            // Handle both array and object-with-array responses
            JsonElement groupArray = root.ValueKind == JsonValueKind.Array
                ? root
                : root.TryGetProperty("data", out JsonElement data) && data.ValueKind == JsonValueKind.Array
                    ? data
                    : default;

            if (groupArray.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in groupArray.EnumerateArray())
                {
                    string? id = item.TryGetProperty("id", out JsonElement idEl) && idEl.ValueKind == JsonValueKind.String
                        ? idEl.GetString() : null;
                    string? subject = item.TryGetProperty("subject", out JsonElement subEl) && subEl.ValueKind == JsonValueKind.String
                        ? subEl.GetString() : null;

                    if (!string.IsNullOrWhiteSpace(id))
                        groups.Add(new EvolutionGroupInfo(id!, subject ?? id!));
                }
            }

            return groups;
        }

        public async Task<EvolutionQrCodeResult> GetConnectionQrCodeAsync(CancellationToken ct = default)
        {
            string url = $"{_serverUrl}/instance/connect/{Uri.EscapeDataString(_instanceName)}";

            using var resp = await _http.GetAsync(url, ct);
            var body = await resp.Content.ReadAsStringAsync(ct);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(Resources.Common_WhatsAppApiConnectFailed, body), null, resp.StatusCode);

            return EvolutionQrCodeResult.FromJson(body);
        }

        public async Task<string> LogoutAsync(CancellationToken ct = default)
        {
            string url = $"{_serverUrl}/instance/logout/{Uri.EscapeDataString(_instanceName)}";

            using var resp = await _http.DeleteAsync(url, ct);
            var body = await resp.Content.ReadAsStringAsync(ct);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(Resources.Common_WhatsAppApiLogoutFailed, body), null, resp.StatusCode);

            return body;
        }

        private static HttpRequestException CreateSendException(HttpResponseMessage response, string body)
        {
            string? missingNumber = TryGetMissingWhatsAppNumber(body);
            if (!string.IsNullOrWhiteSpace(missingNumber))
                return new HttpRequestException(string.Format(Resources.Common_WhatsAppNumberNotFound, missingNumber), null, response.StatusCode);

            return new HttpRequestException(string.Format(Resources.Common_WhatsAppApiSendFailed, body), null, response.StatusCode);
        }

        private static string? TryGetMissingWhatsAppNumber(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
                return null;

            try
            {
                using JsonDocument document = JsonDocument.Parse(body);
                if (!document.RootElement.TryGetProperty("response", out JsonElement response) ||
                    !response.TryGetProperty("message", out JsonElement messages) ||
                    messages.ValueKind != JsonValueKind.Array)
                    return null;

                foreach (JsonElement message in messages.EnumerateArray())
                {
                    if (message.ValueKind != JsonValueKind.Object ||
                        !message.TryGetProperty("exists", out JsonElement exists) ||
                        exists.ValueKind != JsonValueKind.False)
                        continue;

                    if (message.TryGetProperty("number", out JsonElement number) &&
                        number.ValueKind == JsonValueKind.String &&
                        !string.IsNullOrWhiteSpace(number.GetString()))
                        return number.GetString();

                    if (message.TryGetProperty("jid", out JsonElement jid) &&
                        jid.ValueKind == JsonValueKind.String &&
                        !string.IsNullOrWhiteSpace(jid.GetString()))
                        return jid.GetString()?.Split('@')[0];
                }
            }
            catch (JsonException)
            {
            }

            return null;
        }

        private static async Task<byte[]> ReadAllBytesAsync(Stream stream, CancellationToken ct)
        {
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, 81920, ct);
            return ms.ToArray();
        }

        public void Dispose() => _http.Dispose();
    }

    public sealed class EvolutionQrCodeResult
    {
        private EvolutionQrCodeResult(string? code, string? base64, string? state, string body)
        {
            Code = code;
            Base64 = base64;
            State = state;
            Body = body;
        }

        public string? Code { get; }

        public string? Base64 { get; }

        public string? State { get; }

        public string Body { get; }

        public bool HasQrCode => !string.IsNullOrWhiteSpace(Code) || !string.IsNullOrWhiteSpace(Base64);

        public bool IsConnected => string.Equals(State, "open", StringComparison.OrdinalIgnoreCase);

        public static EvolutionQrCodeResult FromJson(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
                return new EvolutionQrCodeResult(null, null, null, body);

            using JsonDocument document = JsonDocument.Parse(body);
            JsonElement root = document.RootElement;

            string? code = TryGetNestedString(root, "code") ?? TryFindString(root, "code");
            string? base64 = TryGetNestedString(root, "base64") ?? TryFindString(root, "base64");
            string? state = TryGetNestedString(root, "state") ?? TryFindString(root, "state");

            return new EvolutionQrCodeResult(code, base64, state, body);
        }

        private static string? TryGetNestedString(JsonElement element, string propertyName)
        {
            if (element.ValueKind != JsonValueKind.Object)
                return null;

            if (element.TryGetProperty(propertyName, out JsonElement value) &&
                value.ValueKind == JsonValueKind.String &&
                !string.IsNullOrWhiteSpace(value.GetString()))
                return value.GetString();

            if (element.TryGetProperty("qrcode", out JsonElement qrCode) &&
                qrCode.ValueKind == JsonValueKind.Object &&
                qrCode.TryGetProperty(propertyName, out value) &&
                value.ValueKind == JsonValueKind.String &&
                !string.IsNullOrWhiteSpace(value.GetString()))
                return value.GetString();

            return null;
        }

        private static string? TryFindString(JsonElement element, string propertyName)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty property in element.EnumerateObject())
                    {
                        if (property.NameEquals(propertyName) &&
                            property.Value.ValueKind == JsonValueKind.String &&
                            !string.IsNullOrWhiteSpace(property.Value.GetString()))
                            return property.Value.GetString();

                        string? nestedValue = TryFindString(property.Value, propertyName);
                        if (!string.IsNullOrWhiteSpace(nestedValue))
                            return nestedValue;
                    }

                    break;
                case JsonValueKind.Array:
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        string? nestedValue = TryFindString(item, propertyName);
                        if (!string.IsNullOrWhiteSpace(nestedValue))
                            return nestedValue;
                    }

                    break;
            }

            return null;
        }
    }

    public sealed class EvolutionGroupInfo
    {
        public EvolutionGroupInfo(string id, string subject)
        {
            Id = id;
            Subject = subject;
        }

        public string Id { get; }
        public string Subject { get; }

        public override string ToString() => $"{Subject} ({Id})";
    }
}
