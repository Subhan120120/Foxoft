using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service
{
    public static class InvoiceOcrProductMatcher
    {

        private class CachedProductItem
        {
            public DcProduct Product { get; set; } = null!;
            public string ProductCode { get; set; } = string.Empty;
            public string ProductDesc { get; set; } = string.Empty;
            public HashSet<string> Barcodes { get; set; } = new(StringComparer.OrdinalIgnoreCase);
            public HashSet<string> Tokens { get; set; } = new(StringComparer.OrdinalIgnoreCase);
            public string NormalizedModel { get; set; } = string.Empty;
            public string Brand { get; set; } = string.Empty;
            public string NormalizedDesc { get; set; } = string.Empty;
            public bool IsVendorProduct { get; set; }
        }

        public static void MatchLines(
            IEnumerable<InvoiceOcrLineVM> lines,
            byte[]? productTypeArr = null,
            ProductMatchOptions? options = null,
            string? vendorCode = null)
        {
            if (lines == null)
                return;

            options ??= ProductMatchOptions.Load();

            using subContext db = new();

            var units = db.DcUnitOfMeasures.AsNoTracking().ToList();

            // Load products once into memory
            IQueryable<DcProduct> prodQuery = db.DcProducts.AsNoTracking().Where(p => p.ProductDesc != null);
            if (productTypeArr != null && productTypeArr.Length > 0)
            {
                prodQuery = prodQuery.Where(p => productTypeArr.Contains(p.ProductTypeCode));
            }
            var dbProducts = prodQuery.ToList();

            // Load barcodes
            var barcodes = db.TrProductBarcodes
                .AsNoTracking()
                .Where(b => !string.IsNullOrEmpty(b.Barcode))
                .Select(b => new { b.ProductCode, b.Barcode })
                .ToList();

            var barcodeLookup = barcodes
                .GroupBy(b => b.Barcode.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().ProductCode, StringComparer.OrdinalIgnoreCase);

            var productBarcodes = barcodes
                .GroupBy(b => b.ProductCode.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().Barcode.Trim(), StringComparer.OrdinalIgnoreCase);

            // Tier 6: Vendor history lookup
            HashSet<string> vendorProductCodes = new(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, string> vendorDescToProductCode = new(StringComparer.OrdinalIgnoreCase);

            if (options.MatchByVendorHistory && !string.IsNullOrWhiteSpace(vendorCode))
            {
                try
                {
                    string cleanVendor = vendorCode.Trim();
                    var pastLines = db.TrInvoiceLines
                        .AsNoTracking()
                        .Where(l => l.TrInvoiceHeader.CurrAccCode == cleanVendor && !string.IsNullOrEmpty(l.ProductCode))
                        .OrderByDescending(l => l.CreatedDate)
                        .Take(500)
                        .Select(l => new { l.ProductCode, l.ProductDesc, l.LineDescription })
                        .ToList();

                    foreach (var pl in pastLines)
                    {
                        vendorProductCodes.Add(pl.ProductCode.Trim());
                        if (!string.IsNullOrWhiteSpace(pl.LineDescription))
                        {
                            string key = pl.LineDescription.Trim();
                            if (!vendorDescToProductCode.ContainsKey(key))
                                vendorDescToProductCode[key] = pl.ProductCode.Trim();
                        }
                        if (!string.IsNullOrWhiteSpace(pl.ProductDesc))
                        {
                            string key = pl.ProductDesc.Trim();
                            if (!vendorDescToProductCode.ContainsKey(key))
                                vendorDescToProductCode[key] = pl.ProductCode.Trim();
                        }
                    }
                }
                catch
                {
                    // Ignore vendor history load failures
                }
            }

            // Index catalog items in memory
            var catalog = new List<CachedProductItem>(dbProducts.Count);
            var productCodeLookup = new Dictionary<string, CachedProductItem>(dbProducts.Count, StringComparer.OrdinalIgnoreCase);

            foreach (var p in dbProducts)
            {
                string code = p.ProductCode?.Trim() ?? string.Empty;
                string desc = p.ProductDesc?.Trim() ?? string.Empty;
                var tokens = Tokenize(desc);
                string model = ExtractModelCode(tokens);
                string brand = tokens.FirstOrDefault(t => !t.Any(char.IsDigit) && t.Length >= 3) ?? string.Empty;

                var item = new CachedProductItem
                {
                    Product = p,
                    ProductCode = code,
                    ProductDesc = desc,
                    Tokens = tokens,
                    NormalizedModel = NormalizeAlphanumeric(model),
                    Brand = brand,
                    NormalizedDesc = NormalizeAlphanumeric(desc),
                    IsVendorProduct = vendorProductCodes.Contains(code)
                };

                catalog.Add(item);
                if (!string.IsNullOrEmpty(code) && !productCodeLookup.ContainsKey(code))
                    productCodeLookup[code] = item;
            }

            // Dynamic Stop-Words: loaded from Database Hierarchy + User Custom Settings
            HashSet<string> dynamicStopWords = new(StringComparer.OrdinalIgnoreCase);
            try
            {
                var hierarchyDescs = db.DcHierarchies
                    .AsNoTracking()
                    .Select(h => h.HierarchyDesc)
                    .Where(d => !string.IsNullOrEmpty(d))
                    .ToList();

                foreach (var hDesc in hierarchyDescs)
                {
                    foreach (var token in Tokenize(hDesc))
                    {
                        if (token.Length >= 3)
                            dynamicStopWords.Add(token);
                    }
                }
            }
            catch
            {
                // Ignore hierarchy load failures
            }

            if (!string.IsNullOrWhiteSpace(options.CustomStopWords))
            {
                foreach (var token in Tokenize(options.CustomStopWords))
                {
                    if (token.Length >= 2)
                        dynamicStopWords.Add(token);
                }
            }

            // Process each OCR line through enabled tiers
            foreach (var line in lines)
            {
                CachedProductItem? matchedItem = null;
                string? matchedBarcode = null;
                string matchReason = string.Empty;

                // -------------------------------------------------------------
                // PILLƏ 1: Ştrixkod və Artikul (Dəqiq kod)
                // -------------------------------------------------------------
                if (options.MatchByBarcodeAndCode)
                {
                    // 1a. Barcode check
                    if (!string.IsNullOrWhiteSpace(line.OcrBarcode))
                    {
                        string cleanBarcode = line.OcrBarcode.Trim();
                        if (barcodeLookup.TryGetValue(cleanBarcode, out var pCode) && productCodeLookup.TryGetValue(pCode, out var found))
                        {
                            matchedItem = found;
                            matchedBarcode = cleanBarcode;
                            matchReason = "Pillə 1: Ştrixkod";
                        }
                    }

                    // 1b. Product Code (SKU) check
                    if (matchedItem == null && !string.IsNullOrWhiteSpace(line.OcrProductCode))
                    {
                        string cleanCode = line.OcrProductCode.Trim();
                        if (productCodeLookup.TryGetValue(cleanCode, out var found))
                        {
                            matchedItem = found;
                            matchReason = "Pillə 1: Məhsul Kodu";
                        }
                    }
                }

                // -------------------------------------------------------------
                // PILLƏ 6: Təchizatçı Yaddaşı / Keçmiş Alışlar (Vendor History)
                // -------------------------------------------------------------
                if (matchedItem == null && options.MatchByVendorHistory && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    string cleanName = line.OcrProductName.Trim();
                    if (vendorDescToProductCode.TryGetValue(cleanName, out var pCode) && productCodeLookup.TryGetValue(pCode, out var found))
                    {
                        matchedItem = found;
                        matchReason = "Pillə 6: Təchizatçı Yaddaşı";
                    }
                }

                // -------------------------------------------------------------
                // PILLƏ 3: Model / Part Number Normalizasiyası və Brend Yoxlaması
                // -------------------------------------------------------------
                if (matchedItem == null && options.MatchByModelAndBrand && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    var ocrTokens = Tokenize(line.OcrProductName);
                    var filteredTokens = dynamicStopWords.Count > 0
                        ? ocrTokens.Where(t => !dynamicStopWords.Contains(t)).ToHashSet(StringComparer.OrdinalIgnoreCase)
                        : ocrTokens;
                    string ocrModel = NormalizeAlphanumeric(ExtractModelCode(ocrTokens));
                    string ocrBrand = filteredTokens.FirstOrDefault(t => !t.Any(char.IsDigit) && t.Length >= 3) ?? string.Empty;

                    if (!string.IsNullOrEmpty(ocrModel))
                    {
                        var modelCandidates = catalog.Where(p =>
                            p.NormalizedModel == ocrModel ||
                            (p.NormalizedModel.Length >= 5 && ocrModel.Length >= 5 && (p.NormalizedModel.Contains(ocrModel) || ocrModel.Contains(p.NormalizedModel)))
                        ).ToList();

                        if (!string.IsNullOrEmpty(ocrBrand))
                        {
                            var brandMatches = modelCandidates.Where(p => p.Tokens.Contains(ocrBrand)).ToList();
                            if (brandMatches.Count > 0)
                                modelCandidates = brandMatches;
                        }

                        if (modelCandidates.Count == 1)
                        {
                            matchedItem = modelCandidates[0];
                            matchReason = "Pillə 3: Model & Brend";
                        }
                        else if (modelCandidates.Count > 1)
                        {
                            // Rank candidates by token overlap and vendor loyalty
                            var best = modelCandidates
                                .OrderByDescending(p => p.IsVendorProduct ? 1 : 0)
                                .ThenByDescending(p => p.Tokens.Intersect(ocrTokens).Count())
                                .First();

                            matchedItem = best;
                            matchReason = "Pillə 3: Model Sıralaması";
                        }
                    }
                }

                // -------------------------------------------------------------
                // PILLƏ 2: Kateqoriya (İyerarxiya) və Xüsusi Stop-words Təmizlənməsi
                // -------------------------------------------------------------
                if (matchedItem == null && options.MatchByCategoryStopWords && dynamicStopWords.Count > 0 && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    var ocrTokens = Tokenize(line.OcrProductName);
                    var cleanTokens = ocrTokens.Where(t => !dynamicStopWords.Contains(t)).ToList();
                    string cleanOcr = string.Join(" ", cleanTokens).Trim();

                    if (!string.IsNullOrWhiteSpace(cleanOcr))
                    {
                        var exactClean = catalog.FirstOrDefault(p =>
                            p.ProductDesc.Equals(cleanOcr, StringComparison.OrdinalIgnoreCase) ||
                            p.ProductDesc.IndexOf(cleanOcr, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            cleanOcr.IndexOf(p.ProductDesc, StringComparison.OrdinalIgnoreCase) >= 0);

                        if (exactClean != null)
                        {
                            matchedItem = exactClean;
                            matchReason = "Pillə 2: Kateqoriya / Stop-words";
                        }
                    }
                }

                // -------------------------------------------------------------
                // PILLƏ 4: Sıradan Asılı Olmayan Token Overlap & Jaccard
                // -------------------------------------------------------------
                if (matchedItem == null && options.MatchByTokenOverlap && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    var ocrTokens = Tokenize(line.OcrProductName);
                    var filteredTokens = dynamicStopWords.Count > 0
                        ? ocrTokens.Where(t => !dynamicStopWords.Contains(t)).ToHashSet(StringComparer.OrdinalIgnoreCase)
                        : ocrTokens;

                    if (filteredTokens.Count > 0)
                    {
                        var allContained = catalog
                            .Where(p => filteredTokens.All(t => p.Tokens.Contains(t)))
                            .OrderByDescending(p => p.IsVendorProduct ? 1 : 0)
                            .ToList();

                        if (allContained.Count > 0)
                        {
                            matchedItem = allContained[0];
                            matchReason = "Pillə 4: Bütün Tokenlər";
                        }
                        else
                        {
                            var bestJaccard = catalog
                                .Select(p =>
                                {
                                    int inter = p.Tokens.Intersect(filteredTokens).Count();
                                    int union = p.Tokens.Union(filteredTokens).Count();
                                    double score = union > 0 ? (double)inter / union : 0;
                                    if (p.IsVendorProduct) score += 0.15; // vendor bonus
                                    return new { Product = p, Score = score, Inter = inter };
                                })
                                .Where(x => x.Inter >= 2 && x.Score >= 0.45)
                                .OrderByDescending(x => x.Score)
                                .FirstOrDefault();

                            if (bestJaccard != null)
                            {
                                matchedItem = bestJaccard.Product;
                                matchReason = $"Pillə 4: Token Kəsişməsi ({bestJaccard.Score:P0})";
                            }
                        }
                    }
                }

                // -------------------------------------------------------------
                // PILLƏ 5: Qeyri-səlis (Fuzzy / Levenshtein) Oxşarlıq
                // -------------------------------------------------------------
                if (matchedItem == null && options.MatchByFuzzySimilarity && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    string normOcr = NormalizeAlphanumeric(line.OcrProductName);
                    double minThreshold = (options.FuzzyMinSimilarityPercent > 0 ? options.FuzzyMinSimilarityPercent : 85) / 100.0;

                    if (normOcr.Length >= 4)
                    {
                        var bestFuzzy = catalog
                            .Select(p => new
                            {
                                Product = p,
                                Sim = CalculateLevenshteinSimilarity(normOcr, p.NormalizedDesc)
                            })
                            .Where(x => x.Sim >= minThreshold)
                            .OrderByDescending(x => x.Sim)
                            .FirstOrDefault();

                        if (bestFuzzy != null)
                        {
                            matchedItem = bestFuzzy.Product;
                            matchReason = $"Pillə 5: Fuzzy Oxşarlıq ({bestFuzzy.Sim:P0})";
                        }
                    }
                }

                // -------------------------------------------------------------
                // Nəticənin Təyini
                // -------------------------------------------------------------
                if (matchedItem != null)
                {
                    line.MatchedProductCode = matchedItem.Product.ProductCode;
                    line.MatchedProductName = matchedItem.Product.ProductDesc;

                    if (string.IsNullOrWhiteSpace(matchedBarcode) && productBarcodes.TryGetValue(matchedItem.ProductCode, out var bCode))
                        matchedBarcode = bCode;

                    line.MatchedBarcode = matchedBarcode;
                    line.IsMatched = true;
                    line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusMatched;

                    if (line.Price == 0 && matchedItem.Product.PurchasePrice > 0)
                        line.Price = matchedItem.Product.PurchasePrice;

                    if (!line.UnitOfMeasureId.HasValue && matchedItem.Product.DefaultUnitOfMeasureId > 0)
                    {
                        line.UnitOfMeasureId = matchedItem.Product.DefaultUnitOfMeasureId;
                        line.UnitOfMeasureName = units.FirstOrDefault(u => u.UnitOfMeasureId == matchedItem.Product.DefaultUnitOfMeasureId)?.UnitOfMeasureDesc;
                    }
                }
                else
                {
                    line.IsMatched = false;
                    line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
                }

                // Map Unit of Measure if missing
                if (!line.UnitOfMeasureId.HasValue && !string.IsNullOrWhiteSpace(line.UnitOfMeasureName))
                {
                    var uom = MapUnitOfMeasure(line.UnitOfMeasureName, units);
                    if (uom != null)
                    {
                        line.UnitOfMeasureId = uom.UnitOfMeasureId;
                        line.UnitOfMeasureName = uom.UnitOfMeasureDesc;
                    }
                }

                if (line.Amount == 0 && line.Qty > 0 && line.Price > 0)
                    line.UpdateAmount();
            }
        }

        public static void UpdateMatchedProduct(InvoiceOcrLineVM line, string productCode)
        {
            if (line == null)
                return;

            if (string.IsNullOrWhiteSpace(productCode))
            {
                line.MatchedProductCode = null;
                line.MatchedProductName = null;
                line.IsMatched = false;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
                return;
            }

            using subContext db = new();
            var product = db.DcProducts.AsNoTracking().FirstOrDefault(x => x.ProductCode == productCode.Trim());
            if (product != null)
            {
                line.MatchedProductCode = product.ProductCode;
                line.MatchedProductName = product.ProductDesc;
                line.IsMatched = true;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusMatched;

                if (!line.UnitOfMeasureId.HasValue && product.DefaultUnitOfMeasureId > 0)
                {
                    line.UnitOfMeasureId = product.DefaultUnitOfMeasureId;
                    var uom = db.DcUnitOfMeasures.AsNoTracking().FirstOrDefault(u => u.UnitOfMeasureId == product.DefaultUnitOfMeasureId);
                    if (uom != null)
                        line.UnitOfMeasureName = uom.UnitOfMeasureDesc;
                }

                if (line.Price == 0 && product.PurchasePrice > 0)
                    line.Price = product.PurchasePrice;

                line.MatchedBarcode = db.TrProductBarcodes
                    .AsNoTracking()
                    .Where(x => x.ProductCode == product.ProductCode)
                    .Select(x => x.Barcode)
                    .FirstOrDefault();
            }
            else
            {
                line.MatchedProductCode = productCode;
                line.MatchedProductName = string.Empty;
                line.IsMatched = false;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
            }
        }

        private static HashSet<string> Tokenize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return Regex.Split(text.ToUpperInvariant(), @"[\s,;+()\/\\-]+")
                .Where(t => !string.IsNullOrWhiteSpace(t) && t.Length > 1)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
        }

        private static string ExtractModelCode(HashSet<string> tokens)
        {
            return tokens
                .Where(t => t.Length >= 4 && t.Any(char.IsDigit) && t.Any(char.IsLetter))
                .OrderByDescending(t => t.Length)
                .FirstOrDefault() ?? string.Empty;
        }

        private static string NormalizeAlphanumeric(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text.ToUpperInvariant(), @"[^A-Z0-9ƏŞĞÖÜIÇ]", string.Empty);
        }

        private static double CalculateLevenshteinSimilarity(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return 0.0;

            if (s1 == s2)
                return 1.0;

            int len1 = s1.Length;
            int len2 = s2.Length;
            int[,] d = new int[len1 + 1, len2 + 1];

            for (int i = 0; i <= len1; i++) d[i, 0] = i;
            for (int j = 0; j <= len2; j++) d[0, j] = j;

            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            int maxLen = Math.Max(len1, len2);
            return maxLen == 0 ? 1.0 : (1.0 - (double)d[len1, len2] / maxLen);
        }

        private static DcUnitOfMeasure? MapUnitOfMeasure(string unitText, List<DcUnitOfMeasure> units)
        {
            if (string.IsNullOrWhiteSpace(unitText) || units == null || units.Count == 0)
                return null;

            string normalized = unitText.Trim().ToLowerInvariant();

            // Direct desc match
            var exact = units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant() == normalized);
            if (exact != null)
                return exact;

            // Common aliases
            if (normalized is "ədəd" or "əd" or "ed" or "eded" or "pcs" or "piece" or "ad." or "pc" or "əd.")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("əd"));

            if (normalized is "kq" or "kg" or "kilo" or "kilogram")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("k"));

            if (normalized is "litr" or "l" or "lt" or "liter")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("lit"));

            if (normalized is "metr" or "m" or "meter")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("metr"));

            if (normalized is "qutu" or "box")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("qut"));

            if (normalized is "dəst" or "set")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("dəs"));

            return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains(normalized));
        }
    }
}
