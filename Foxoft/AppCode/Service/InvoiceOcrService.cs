using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.Models.ViewModel;

namespace Foxoft.AppCode.Service
{
    public class InvoiceOcrService
    {
        private static readonly HttpClient _httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(120)
        };

        private const string OpenAICompletionsUrl = "https://api.openai.com/v1/chat/completions";
        private const string OpenAIModelsUrl = "https://api.openai.com/v1/models";

        public async Task<(bool Success, string Message)> TestConnectionAsync(
            string apiKey,
            string model = "gpt-4o",
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                return (false, Properties.Resources.Form_InvoiceWizard_ApiKeyRequired);

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, OpenAIModelsUrl);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey.Trim());

                using var response = await _httpClient.SendAsync(request, ct);
                if (response.IsSuccessStatusCode)
                    return (true, Properties.Resources.Form_InvoiceWizard_ConnectionSuccess);

                string errorContent = await response.Content.ReadAsStringAsync(ct);
                string extractedError = ExtractErrorMessage(errorContent) ?? response.ReasonPhrase ?? response.StatusCode.ToString();

                return (false, string.Format(Properties.Resources.Form_InvoiceWizard_ConnectionFailed, extractedError));
            }
            catch (OperationCanceledException)
            {
                return (false, "Əməliyyat dayandırıldı.");
            }
            catch (Exception ex)
            {
                return (false, string.Format(Properties.Resources.Form_InvoiceWizard_ConnectionFailed, ex.Message));
            }
        }

        public async Task<InvoiceOcrResult> ExtractInvoiceDataAsync(
            IEnumerable<byte[]> imageBytesList,
            string apiKey,
            string model = "gpt-4o",
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException(Properties.Resources.Form_InvoiceWizard_ApiKeyRequired, nameof(apiKey));

            var imageList = imageBytesList?.Where(b => b != null && b.Length > 0).ToList();
            if (imageList == null || imageList.Count == 0)
                throw new ArgumentException(Properties.Resources.Form_InvoiceWizard_NoImageSelected, nameof(imageBytesList));

            string effectiveModel = string.IsNullOrWhiteSpace(model) ? "gpt-4o" : model.Trim();

            // Construct payload content array
            var userContentList = new List<object>
            {
                new
                {
                    type = "text",
                    text = "Extract invoice header information and all tabular item lines from the provided invoice document image(s). Ensure all numbers (quantities, prices, amounts, VAT rates) are parsed accurately. Return strictly valid JSON."
                }
            };

            foreach (var imgBytes in imageList)
            {
                string mimeType = DetectMimeType(imgBytes);
                string base64 = Convert.ToBase64String(imgBytes);
                userContentList.Add(new
                {
                    type = "image_url",
                    image_url = new
                    {
                        url = $"data:{mimeType};base64,{base64}",
                        detail = "high"
                    }
                });
            }

            string systemPrompt = @"You are an expert OCR and invoice extraction assistant for ERP systems.
Your task is to analyze invoice, bill, receipt, or waybill image(s) and extract data in strict JSON.
JSON schema:
{
  ""documentNumber"": string or null,
  ""documentDate"": ""yyyy-MM-dd"" or null,
  ""vendorName"": string or null,
  ""currency"": string or null,
  ""notes"": string or null,
  ""lines"": [
    {
      ""lineNumber"": integer,
      ""barcode"": string or null,
      ""productCode"": string or null,
      ""productName"": string,
      ""qty"": number,
      ""unit"": string or null,
      ""unitPrice"": number,
      ""amount"": number,
      ""vatRate"": number,
      ""lineDescription"": string or null
    }
  ]
}

Important rules:
1. Extract EVERY table line item faithfully.
2. Clean and preserve barcodes if visible (digits only, e.g. EAN13).
3. If unit price is missing but amount and quantity exist, calculate unitPrice = amount / qty.
4. If amount is missing, calculate amount = qty * unitPrice.
5. Provide dates in yyyy-MM-dd format.
6. Output ONLY valid, parsable JSON without markdown backticks or commentary.";

            var requestBody = new
            {
                model = effectiveModel,
                temperature = 0.1,
                response_format = new { type = "json_object" },
                messages = new object[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userContentList }
                }
            };

            string jsonPayload = JsonSerializer.Serialize(requestBody);

            using var request = new HttpRequestMessage(HttpMethod.Post, OpenAICompletionsUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey.Trim());
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, ct);
            string responseString = await response.Content.ReadAsStringAsync(ct);

            if (!response.IsSuccessStatusCode)
            {
                string err = ExtractErrorMessage(responseString) ?? $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}";
                throw new InvalidOperationException($"OpenAI API xətası: {err}");
            }

            return ParseOpenAiResponse(responseString);
        }

        private static InvoiceOcrResult ParseOpenAiResponse(string responseJson)
        {
            using var doc = JsonDocument.Parse(responseJson);
            var root = doc.RootElement;

            if (!root.TryGetProperty("choices", out var choices) || choices.GetArrayLength() == 0)
                throw new InvalidOperationException("OpenAI cavabında 'choices' tapılmadı.");

            var firstChoice = choices[0];
            if (!firstChoice.TryGetProperty("message", out var message) ||
                !message.TryGetProperty("content", out var contentProp))
                throw new InvalidOperationException("OpenAI cavabında 'message.content' tapılmadı.");

            string rawContent = contentProp.GetString() ?? string.Empty;
            rawContent = rawContent.Trim();

            // Strip possible markdown fences ```json ... ```
            if (rawContent.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
                rawContent = rawContent.Substring(7);
            else if (rawContent.StartsWith("```"))
                rawContent = rawContent.Substring(3);

            if (rawContent.EndsWith("```"))
                rawContent = rawContent.Substring(0, rawContent.Length - 3);

            rawContent = rawContent.Trim();

            using var contentDoc = JsonDocument.Parse(rawContent);
            var contentRoot = contentDoc.RootElement;

            InvoiceOcrResult result = new();

            if (contentRoot.TryGetProperty("documentNumber", out var docNumProp) && docNumProp.ValueKind == JsonValueKind.String)
                result.DocumentNumber = docNumProp.GetString();

            if (contentRoot.TryGetProperty("documentDate", out var docDateProp) && docDateProp.ValueKind == JsonValueKind.String)
            {
                string dateStr = docDateProp.GetString() ?? string.Empty;
                if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt) ||
                    DateTime.TryParse(dateStr, out dt))
                {
                    result.DocumentDate = dt;
                }
            }

            if (contentRoot.TryGetProperty("vendorName", out var vendorProp) && vendorProp.ValueKind == JsonValueKind.String)
                result.VendorName = vendorProp.GetString();

            if (contentRoot.TryGetProperty("currency", out var currProp) && currProp.ValueKind == JsonValueKind.String)
                result.Currency = currProp.GetString();

            if (contentRoot.TryGetProperty("notes", out var notesProp) && notesProp.ValueKind == JsonValueKind.String)
                result.Notes = notesProp.GetString();

            if (contentRoot.TryGetProperty("lines", out var linesProp) && linesProp.ValueKind == JsonValueKind.Array)
            {
                int index = 1;
                foreach (var lineElem in linesProp.EnumerateArray())
                {
                    InvoiceOcrLineVM line = new();
                    line.Selected = true;

                    if (lineElem.TryGetProperty("lineNumber", out var lnProp) && lnProp.TryGetInt32(out var ln))
                        line.LineNumber = ln;
                    else
                        line.LineNumber = index;

                    if (lineElem.TryGetProperty("barcode", out var bcProp) && bcProp.ValueKind == JsonValueKind.String)
                        line.OcrBarcode = bcProp.GetString();

                    if (lineElem.TryGetProperty("productCode", out var codeProp) && codeProp.ValueKind == JsonValueKind.String)
                        line.OcrProductCode = codeProp.GetString();

                    if (lineElem.TryGetProperty("productName", out var nameProp) && nameProp.ValueKind == JsonValueKind.String)
                        line.OcrProductName = nameProp.GetString();

                    if (lineElem.TryGetProperty("qty", out var qtyProp))
                        line.Qty = GetDecimal(qtyProp, 1m);

                    if (lineElem.TryGetProperty("unit", out var unitProp) && unitProp.ValueKind == JsonValueKind.String)
                        line.UnitOfMeasureName = unitProp.GetString();

                    if (lineElem.TryGetProperty("unitPrice", out var priceProp))
                        line.Price = GetDecimal(priceProp, 0m);

                    if (lineElem.TryGetProperty("amount", out var amountProp))
                        line.Amount = GetDecimal(amountProp, 0m);

                    if (lineElem.TryGetProperty("vatRate", out var vatProp))
                        line.VatRate = (float)GetDecimal(vatProp, 0m);

                    if (lineElem.TryGetProperty("lineDescription", out var descProp) && descProp.ValueKind == JsonValueKind.String)
                        line.LineDescription = descProp.GetString();

                    if (line.Amount == 0 && line.Qty > 0 && line.Price > 0)
                        line.UpdateAmount();

                    result.Lines.Add(line);
                    index++;
                }
            }

            return result;
        }

        private static decimal GetDecimal(JsonElement element, decimal defaultValue)
        {
            if (element.ValueKind == JsonValueKind.Number && element.TryGetDecimal(out var d))
                return d;

            if (element.ValueKind == JsonValueKind.String &&
                decimal.TryParse(element.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
                return parsed;

            return defaultValue;
        }

        private static string? ExtractErrorMessage(string responseJson)
        {
            try
            {
                using var doc = JsonDocument.Parse(responseJson);
                if (doc.RootElement.TryGetProperty("error", out var errorObj))
                {
                    if (errorObj.TryGetProperty("message", out var msgProp))
                        return msgProp.GetString();
                }
            }
            catch
            {
                // ignore parsing failure
            }
            return null;
        }

        public static string DetectMimeType(byte[] bytes)
        {
            if (bytes.Length >= 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF)
                return "image/jpeg";
            if (bytes.Length >= 8 && bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
                return "image/png";
            if (bytes.Length >= 2 && bytes[0] == 0x42 && bytes[1] == 0x4D)
                return "image/bmp";
            if (bytes.Length >= 12 && bytes[0] == 0x52 && bytes[1] == 0x49 && bytes[2] == 0x46 && bytes[3] == 0x46 &&
                bytes[8] == 0x57 && bytes[9] == 0x45 && bytes[10] == 0x42 && bytes[11] == 0x50)
                return "image/webp";

            return "image/jpeg";
        }
    }
}
