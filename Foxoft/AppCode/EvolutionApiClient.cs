using System;
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
}
