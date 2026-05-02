using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

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
                throw new HttpRequestException($"Send failed ({(int)resp.StatusCode}): {body}");

            return body;
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
