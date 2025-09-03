using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhatsAppClient : IDisposable
{
    private readonly HttpClient _http;
    private readonly string _phoneId;
    private readonly JsonSerializerOptions _json = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <param name="accessToken">Bearer token with whatsapp_business_messaging (and usually whatsapp_business_management)</param>
    /// <param name="phoneId">WhatsApp PHONE_NUMBER_ID</param>
    /// <param name="apiVersion">Graph API version, e.g. "v20.0"</param>
    public WhatsAppClient(string accessToken, string phoneId, string apiVersion = "v20.0")
    {
        if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
        if (string.IsNullOrWhiteSpace(phoneId)) throw new ArgumentNullException(nameof(phoneId));

        _phoneId = phoneId;
        _http = new HttpClient
        {
            BaseAddress = new Uri($"https://graph.facebook.com/{apiVersion}/")
        };
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    /// <summary>
    /// Upload a local image file to WhatsApp and get MEDIA_ID back.
    /// </summary>
    public async Task<string> UploadImageAsync(string filePath, string contentType = "image/jpeg", string? fileName = null, CancellationToken ct = default)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);
        fileName ??= Path.GetFileName(filePath);

        using var form = new MultipartFormDataContent();
        form.Add(new StringContent("whatsapp"), "messaging_product");
        form.Add(new StringContent(contentType), "type");
        form.Add(new StringContent(fileName), "file_name");

        using var stream = File.OpenRead(filePath);
        using var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        form.Add(fileContent, "file", fileName);

        using var resp = await _http.PostAsync($"{_phoneId}/media", form, ct);
        var body = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new HttpRequestException($"Upload failed ({(int)resp.StatusCode}): {body}");

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Upload an image from any Stream (e.g., MemoryStream) and get MEDIA_ID back.
    /// The input stream is NOT disposed.
    /// </summary>
    public async Task<string> UploadImageAsync(Stream stream, string contentType, string fileName, CancellationToken ct = default)
    {
        if (stream == null) throw new ArgumentNullException(nameof(stream));
        if (string.IsNullOrWhiteSpace(contentType)) throw new ArgumentNullException(nameof(contentType));
        if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

        if (stream.CanSeek) stream.Position = 0;
        var bytes = await ReadAllBytesAsync(stream, ct);

        using var form = new MultipartFormDataContent();
        form.Add(new StringContent("whatsapp"), "messaging_product");
        form.Add(new StringContent(contentType), "type");
        form.Add(new StringContent(fileName), "file_name");

        using var fileContent = new ByteArrayContent(bytes);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        form.Add(fileContent, "file", fileName);

        using var resp = await _http.PostAsync($"{_phoneId}/media", form, ct);
        var body = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new HttpRequestException($"Upload failed ({(int)resp.StatusCode}): {body}");

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Send an image by previously uploaded MEDIA_ID.
    /// Returns messages[0].id when available.
    /// </summary>
    public async Task<string> SendImageByIdAsync(string to, string mediaId, string? caption = null, CancellationToken ct = default)
    {
        var payload = new
        {
            messaging_product = "whatsapp",
            to,
            type = "image",
            image = new { id = mediaId, caption }
        };

        var content = new StringContent(JsonSerializer.Serialize(payload, _json), Encoding.UTF8, "application/json");
        using var resp = await _http.PostAsync($"{_phoneId}/messages", content, ct);
        var body = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new HttpRequestException($"Send failed ({(int)resp.StatusCode}): {body}");

        using var doc = JsonDocument.Parse(body);
        if (doc.RootElement.TryGetProperty("messages", out var msgs) && msgs.ValueKind == JsonValueKind.Array && msgs.GetArrayLength() > 0)
        {
            var msgId = msgs[0].GetProperty("id").GetString();
            return msgId ?? body;
        }
        return body;
    }

    /// <summary>
    /// Send an image by public URL (no upload step).
    /// Returns messages[0].id when available.
    /// </summary>
    public async Task<string> SendImageByUrlAsync(string to, string imageUrl, string? caption = null, CancellationToken ct = default)
    {
        var payload = new
        {
            messaging_product = "whatsapp",
            to,
            type = "image",
            image = new { link = imageUrl, caption }
        };

        var content = new StringContent(JsonSerializer.Serialize(payload, _json), Encoding.UTF8, "application/json");
        using var resp = await _http.PostAsync($"{_phoneId}/messages", content, ct);
        var body = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new HttpRequestException($"Send failed ({(int)resp.StatusCode}): {body}");

        using var doc = JsonDocument.Parse(body);
        if (doc.RootElement.TryGetProperty("messages", out var msgs) && msgs.ValueKind == JsonValueKind.Array && msgs.GetArrayLength() > 0)
        {
            var msgId = msgs[0].GetProperty("id").GetString();
            return msgId ?? body;
        }
        return body;
    }

    /// <summary>
    /// Convenience: upload local image and send to a recipient in one call.
    /// </summary>
    public async Task<string> UploadAndSendImageAsync(string to, string filePath, string? caption = null, string contentType = "image/jpeg", CancellationToken ct = default)
    {
        var mediaId = await UploadImageAsync(filePath, contentType, null, ct);
        return await SendImageByIdAsync(to, mediaId, caption, ct);
    }

    /// <summary>
    /// Convenience: upload from Stream and immediately send to a recipient.
    /// The input stream is NOT disposed.
    /// </summary>
    public async Task<string> UploadAndSendImageAsync(string to, Stream stream, string? caption = null,
                                                      string fileName = "image.jpg", string contentType = "image/jpeg",
                                                      CancellationToken ct = default)
    {
        var mediaId = await UploadImageAsync(stream, contentType, fileName, ct);
        return await SendImageByIdAsync(to, mediaId, caption, ct);
    }

    private static async Task<byte[]> ReadAllBytesAsync(Stream stream, CancellationToken ct)
    {
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms, 81920, ct);
        return ms.ToArray();
    }

    public void Dispose() => _http.Dispose();
}
