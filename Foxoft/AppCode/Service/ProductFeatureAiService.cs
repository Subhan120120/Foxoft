using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service
{
    public class ProductFeatureAiTargetTypeDto
    {
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; } = string.Empty;
        public List<string> ExistingValues { get; set; } = new();
    }

    public class ProductFeatureAiResult
    {
        public string? ProductIdentified { get; set; }
        public List<ProductFeatureAiItem> Features { get; set; } = new();
    }

    public class ProductFeatureAiItem
    {
        public int FeatureTypeId { get; set; }
        public string? FeatureTypeName { get; set; }
        public string? ExtractedValue { get; set; }
        public string? MatchedFeatureCode { get; set; }
        public string? SuggestedNewCode { get; set; }
        public string? SuggestedNewDesc { get; set; }
        public bool IsMatched { get; set; }
        public string? Notes { get; set; }
    }

    public class ProductFeatureAiService
    {
        private static readonly HttpClient _httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(90)
        };

        private const string OpenAIResponsesUrl = "https://api.openai.com/v1/responses";
        private const string OpenAICompletionsUrl = "https://api.openai.com/v1/chat/completions";

        public async Task<ProductFeatureAiResult> ExtractFeaturesAsync(
            string productName,
            string? barcode,
            List<ProductFeatureAiTargetTypeDto> targetFeatureTypes,
            string apiKey,
            string model = "gpt-4o",
            List<KeyValuePair<string, string>>? knownAssignedFeatures = null,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException(Properties.Resources.Form_ProductFeature_ApiKeyRequired, nameof(apiKey));

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Məhsul adı və ya axtarış mətni daxil edilməlidir.", nameof(productName));

            string effectiveModel = string.IsNullOrWhiteSpace(model) ? "gpt-4o" : model.Trim();

            string systemPrompt = @"You are an expert product catalog and technical specification extraction assistant for ERP systems.
Your task is to search the web for the manufacturer technical specifications of the given product, and extract values ONLY for the specified target feature types in 'featureTypesToExtract'.
If 'alreadyAssignedFeatures' are provided, treat them as confirmed factual context to identify the exact product model and specifications, but DO NOT modify or re-extract them.
For each requested feature type:
1. Find the accurate, official attribute value for this exact product (e.g. brand name, model, color, storage capacity, RAM, screen size, material, country of manufacture, etc.).
2. Compare the found value against the provided 'existingValues' list for that feature type:
   - If an existing value matches or is an exact synonym/code, set 'matchedFeatureCode' to that existing value and set 'isMatched': true.
   - If no existing value matches, set 'matchedFeatureCode': null, 'isMatched': false, and suggest a clean 'suggestedNewCode' (short, uppercase/alphanumeric, e.g. 'TITAN_GRAY' or '256GB') and 'suggestedNewDesc' (human-readable title, e.g. 'Titanium Gray').
3. If a feature type does not apply to this product (e.g. RAM for a t-shirt), set extractedValue: null, isMatched: false.
4. Output strictly valid JSON matching this schema:
{
  ""productIdentified"": ""string"",
  ""features"": [
    {
      ""featureTypeId"": 1,
      ""featureTypeName"": ""string"",
      ""extractedValue"": ""string or null"",
      ""matchedFeatureCode"": ""string or null"",
      ""suggestedNewCode"": ""string or null"",
      ""suggestedNewDesc"": ""string or null"",
      ""isMatched"": true or false,
      ""notes"": ""string or null""
    }
  ]
}";

            var userPayloadObj = new
            {
                productName = productName.Trim(),
                barcode = string.IsNullOrWhiteSpace(barcode) ? null : barcode.Trim(),
                alreadyAssignedFeatures = (knownAssignedFeatures != null && knownAssignedFeatures.Count > 0)
                    ? knownAssignedFeatures.Select(k => new { feature = k.Key, value = k.Value }).ToList()
                    : null,
                featureTypesToExtract = targetFeatureTypes.Select(ft => new
                {
                    id = ft.FeatureTypeId,
                    name = ft.FeatureTypeName,
                    existingValues = ft.ExistingValues.Take(100).ToList()
                }).ToList()
            };

            string userPrompt = JsonSerializer.Serialize(userPayloadObj);

            // Attempt 1: Responses API with web_search tool
            try
            {
                var responsesRequestBody = new
                {
                    model = effectiveModel,
                    tools = new object[]
                    {
                        new { type = "web_search" }
                    },
                    input = $"Search web for official specs of this product:\n{userPrompt}",
                    instructions = systemPrompt
                };

                string responsesJson = JsonSerializer.Serialize(responsesRequestBody);
                using var request = new HttpRequestMessage(HttpMethod.Post, OpenAIResponsesUrl);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey.Trim());
                request.Content = new StringContent(responsesJson, Encoding.UTF8, "application/json");

                using var response = await _httpClient.SendAsync(request, ct);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync(ct);
                    var parsed = TryParseResponsesApiOutput(responseString);
                    if (parsed != null && parsed.Features.Count > 0)
                        return parsed;
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch
            {
                // Fall back to chat completions
            }

            // Attempt 2: Standard Chat Completions API with JSON mode
            var chatRequestBody = new
            {
                model = effectiveModel,
                temperature = 0.1,
                response_format = new { type = "json_object" },
                messages = new object[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = $"Search web or product specifications for:\n{userPrompt}" }
                }
            };

            string chatJson = JsonSerializer.Serialize(chatRequestBody);
            using var chatRequest = new HttpRequestMessage(HttpMethod.Post, OpenAICompletionsUrl);
            chatRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey.Trim());
            chatRequest.Content = new StringContent(chatJson, Encoding.UTF8, "application/json");

            using var chatResponse = await _httpClient.SendAsync(chatRequest, ct);
            string chatResponseString = await chatResponse.Content.ReadAsStringAsync(ct);

            if (!chatResponse.IsSuccessStatusCode)
            {
                string err = ExtractErrorMessage(chatResponseString) ?? $"HTTP {(int)chatResponse.StatusCode}: {chatResponse.ReasonPhrase}";
                throw new InvalidOperationException($"AI API xətası: {err}");
            }

            return ParseChatCompletionsResponse(chatResponseString);
        }

        private static ProductFeatureAiResult? TryParseResponsesApiOutput(string responseJson)
        {
            try
            {
                using var doc = JsonDocument.Parse(responseJson);
                var root = doc.RootElement;

                // Check "output_text" first
                if (root.TryGetProperty("output_text", out var outTextProp) && outTextProp.ValueKind == JsonValueKind.String)
                {
                    string txt = outTextProp.GetString() ?? string.Empty;
                    return ParseFeatureJson(txt);
                }

                // Check "output" array
                if (root.TryGetProperty("output", out var outArray) && outArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in outArray.EnumerateArray())
                    {
                        if (item.TryGetProperty("content", out var contentArray) && contentArray.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var c in contentArray.EnumerateArray())
                            {
                                if (c.TryGetProperty("text", out var textProp) && textProp.ValueKind == JsonValueKind.String)
                                {
                                    var res = ParseFeatureJson(textProp.GetString() ?? string.Empty);
                                    if (res != null) return res;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // return null if unable to parse responses API output
            }
            return null;
        }

        private static ProductFeatureAiResult ParseChatCompletionsResponse(string responseJson)
        {
            using var doc = JsonDocument.Parse(responseJson);
            var root = doc.RootElement;

            if (!root.TryGetProperty("choices", out var choices) || choices.GetArrayLength() == 0)
                throw new InvalidOperationException("AI cavabında 'choices' tapılmadı.");

            var firstChoice = choices[0];
            if (!firstChoice.TryGetProperty("message", out var message) ||
                !message.TryGetProperty("content", out var contentProp))
                throw new InvalidOperationException("AI cavabında 'message.content' tapılmadı.");

            string rawContent = contentProp.GetString() ?? string.Empty;
            var result = ParseFeatureJson(rawContent);
            if (result == null)
                throw new InvalidOperationException("AI cavabı JSON formatında təhlil edilə bilmədi.");

            return result;
        }

        private static ProductFeatureAiResult? ParseFeatureJson(string rawJson)
        {
            if (string.IsNullOrWhiteSpace(rawJson))
                return null;

            rawJson = rawJson.Trim();
            if (rawJson.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
                rawJson = rawJson.Substring(7);
            else if (rawJson.StartsWith("```"))
                rawJson = rawJson.Substring(3);

            if (rawJson.EndsWith("```"))
                rawJson = rawJson.Substring(0, rawJson.Length - 3);

            rawJson = rawJson.Trim();

            using var doc = JsonDocument.Parse(rawJson);
            var root = doc.RootElement;

            ProductFeatureAiResult res = new();
            if (root.TryGetProperty("productIdentified", out var prodProp) && prodProp.ValueKind == JsonValueKind.String)
                res.ProductIdentified = prodProp.GetString();

            if (root.TryGetProperty("features", out var featsProp) && featsProp.ValueKind == JsonValueKind.Array)
            {
                foreach (var elem in featsProp.EnumerateArray())
                {
                    ProductFeatureAiItem item = new();
                    if (elem.TryGetProperty("featureTypeId", out var ftProp) && ftProp.TryGetInt32(out int ftId))
                        item.FeatureTypeId = ftId;
                    if (elem.TryGetProperty("featureTypeName", out var nameProp) && nameProp.ValueKind == JsonValueKind.String)
                        item.FeatureTypeName = nameProp.GetString();
                    if (elem.TryGetProperty("extractedValue", out var valProp) && valProp.ValueKind == JsonValueKind.String)
                        item.ExtractedValue = valProp.GetString();
                    if (elem.TryGetProperty("matchedFeatureCode", out var codeProp) && codeProp.ValueKind == JsonValueKind.String)
                        item.MatchedFeatureCode = codeProp.GetString();
                    if (elem.TryGetProperty("suggestedNewCode", out var scProp) && scProp.ValueKind == JsonValueKind.String)
                        item.SuggestedNewCode = scProp.GetString();
                    if (elem.TryGetProperty("suggestedNewDesc", out var sdProp) && sdProp.ValueKind == JsonValueKind.String)
                        item.SuggestedNewDesc = sdProp.GetString();
                    if (elem.TryGetProperty("isMatched", out var matchProp) && matchProp.ValueKind is JsonValueKind.True or JsonValueKind.False)
                        item.IsMatched = matchProp.GetBoolean();
                    if (elem.TryGetProperty("notes", out var notesProp) && notesProp.ValueKind == JsonValueKind.String)
                        item.Notes = notesProp.GetString();

                    res.Features.Add(item);
                }
            }

            return res;
        }

        private static string? ExtractErrorMessage(string responseString)
        {
            try
            {
                using var doc = JsonDocument.Parse(responseString);
                if (doc.RootElement.TryGetProperty("error", out var errorElement))
                {
                    if (errorElement.TryGetProperty("message", out var msgElement))
                        return msgElement.GetString();
                }
            }
            catch
            {
                // Fallback to raw response
            }
            return null;
        }
    }
}
