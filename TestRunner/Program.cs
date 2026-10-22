using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

public class ProductMatchOptions
{
    public bool MatchByBarcodeAndCode { get; set; } = true;
    public bool MatchByCategoryStopWords { get; set; } = false;
    public bool MatchByModelAndBrand { get; set; } = true;
    public bool MatchByTokenOverlap { get; set; } = true;
    public bool MatchByFuzzySimilarity { get; set; } = false;
    public bool MatchByVendorHistory { get; set; } = true;
    public int FuzzyMinSimilarityPercent { get; set; } = 85;
}

public class ProductCatalogItem
{
    public string ProductCode { get; set; } = "";
    public string ProductDesc { get; set; } = "";
    public decimal PurchasePrice { get; set; }
    public int DefaultUnitOfMeasureId { get; set; }
    public HashSet<string> Barcodes { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public HashSet<string> Tokens { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public string NormalizedModel { get; set; } = "";
    public string Brand { get; set; } = "";
    public string NormalizedDesc { get; set; } = "";
}

class Program
{
    static readonly HashSet<string> StopWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "SOYUDUCU", "QABYUYAN", "PALTARYUYAN", "TELEVİZOR", "TV", "KONDİSİONER",
        "TOZSORAN", "SOBA", "PLİTƏ", "ÜTÜ", "KOMBİ", "FEN", "ASPİRATOR",
        "MİKRODALĞALI", "ƏTÇƏKƏN", "ETCEKEN", "SUPURGE", "SÜPÜRGƏ", "DOLAB", "DOLAP",
        "XALADILNIK", "ХОЛОДИЛЬНИК", "СТИРАЛЬНАЯ", "ПОСУДОМОЕЧНАЯ"
    };

    static void Main()
    {
        string connStr = "Data Source=.\\SUBSQL;Initial Catalog=Tokla;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=sql123_";
        var catalog = new List<ProductCatalogItem>();

        var sw = Stopwatch.StartNew();
        using (var conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand("SELECT ProductCode, ProductDesc, ISNULL(PurchasePrice,0), DefaultUnitOfMeasureId FROM DcProducts WHERE ProductDesc IS NOT NULL", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string code = reader.GetString(0).Trim();
                    string desc = reader.GetString(1).Trim();
                    decimal price = reader.GetDecimal(2);
                    int uom = reader.GetInt32(3);

                    var tokens = Tokenize(desc);
                    string model = ExtractModelCode(tokens);
                    string brand = tokens.FirstOrDefault(t => !t.Any(char.IsDigit) && t.Length >= 3) ?? "";

                    catalog.Add(new ProductCatalogItem
                    {
                        ProductCode = code,
                        ProductDesc = desc,
                        PurchasePrice = price,
                        DefaultUnitOfMeasureId = uom,
                        Tokens = tokens,
                        NormalizedModel = NormalizeAlphanumeric(model),
                        Brand = brand,
                        NormalizedDesc = NormalizeAlphanumeric(desc)
                    });
                }
            }
        }
        sw.Stop();
        Console.WriteLine($"Loaded {catalog.Count} products in {sw.ElapsedMilliseconds} ms.");

        var options = new ProductMatchOptions(); // Defaults: 1=true, 2=false, 3=true, 4=true, 5=false, 6=true

        var testCases = new[]
        {
            "TOSHIBA QLED 65M450RE",
            "SOYUDUCU HOFFMANN NFFD-179BGT",
            "QABYUYAN TOSHIBA DW-14F7(B)-CIS"
        };

        foreach (var test in testCases)
        {
            var match = FindMatch(test, catalog, options);
            Console.WriteLine($"Input: '{test}'");
            if (match != null)
                Console.WriteLine($"   -> Matched: {match.Product.ProductCode} | {match.Product.ProductDesc} (via {match.TierName})\n");
            else
                Console.WriteLine("   -> NOT MATCHED!\n");
        }
    }

    static HashSet<string> Tokenize(string text)
    {
        return Regex.Split(text.ToUpperInvariant(), @"[\s,;+()\/\\-]+")
            .Where(t => !string.IsNullOrWhiteSpace(t) && t.Length > 1)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
    }

    static string ExtractModelCode(HashSet<string> tokens)
    {
        return tokens
            .Where(t => t.Length >= 4 && t.Any(char.IsDigit) && t.Any(char.IsLetter))
            .OrderByDescending(t => t.Length)
            .FirstOrDefault() ?? "";
    }

    static string NormalizeAlphanumeric(string text)
    {
        return Regex.Replace(text.ToUpperInvariant(), @"[^A-Z0-9ƏŞĞÖÜIÇ]", "");
    }

    class MatchOutput
    {
        public ProductCatalogItem Product { get; set; } = null!;
        public string TierName { get; set; } = "";
    }

    static MatchOutput? FindMatch(string ocrName, List<ProductCatalogItem> catalog, ProductMatchOptions options)
    {
        var ocrTokens = Tokenize(ocrName);
        var filteredTokens = ocrTokens.Where(t => !StopWords.Contains(t)).ToHashSet(StringComparer.OrdinalIgnoreCase);
        string ocrModel = NormalizeAlphanumeric(ExtractModelCode(ocrTokens));
        string ocrBrand = filteredTokens.FirstOrDefault(t => !t.Any(char.IsDigit) && t.Length >= 3) ?? "";

        // Tier 3: Model & Brand Match
        if (options.MatchByModelAndBrand && !string.IsNullOrEmpty(ocrModel))
        {
            var candidates = catalog.Where(p =>
                p.NormalizedModel == ocrModel ||
                (p.NormalizedModel.Length >= 5 && ocrModel.Length >= 5 && (p.NormalizedModel.Contains(ocrModel) || ocrModel.Contains(p.NormalizedModel)))
            ).ToList();

            if (!string.IsNullOrEmpty(ocrBrand))
            {
                var brandMatch = candidates.Where(p => p.Tokens.Contains(ocrBrand)).ToList();
                if (brandMatch.Count > 0)
                    candidates = brandMatch;
            }

            if (candidates.Count == 1)
                return new MatchOutput { Product = candidates[0], TierName = "Pillə 3 (Model & Brend)" };
            if (candidates.Count > 1)
            {
                var best = candidates
                    .OrderByDescending(p => p.Tokens.Intersect(filteredTokens).Count())
                    .First();
                return new MatchOutput { Product = best, TierName = "Pillə 3 (Model & Çoxsaylı Token)" };
            }
        }

        // Tier 2: Stop-words / Category stripped match
        if (options.MatchByCategoryStopWords)
        {
            string cleanOcr = string.Join(" ", filteredTokens);
            if (!string.IsNullOrWhiteSpace(cleanOcr))
            {
                var subMatch = catalog.FirstOrDefault(p =>
                    p.ProductDesc.IndexOf(cleanOcr, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    cleanOcr.IndexOf(p.ProductDesc, StringComparison.OrdinalIgnoreCase) >= 0);
                if (subMatch != null)
                    return new MatchOutput { Product = subMatch, TierName = "Pillə 2 (Kateqoriya Təmizlənməsi)" };
            }
        }

        // Tier 4: Token Overlap (All or high overlap)
        if (options.MatchByTokenOverlap && filteredTokens.Count > 0)
        {
            var allContained = catalog.Where(p => filteredTokens.All(t => p.Tokens.Contains(t))).ToList();
            if (allContained.Count == 1)
                return new MatchOutput { Product = allContained[0], TierName = "Pillə 4 (Bütün Tokenlər Mövcuddur)" };
            if (allContained.Count > 1)
                return new MatchOutput { Product = allContained[0], TierName = "Pillə 4 (Bütün Tokenlər - Sıralanmış)" };

            var bestJaccard = catalog
                .Select(p =>
                {
                    int inter = p.Tokens.Intersect(filteredTokens).Count();
                    int union = p.Tokens.Union(filteredTokens).Count();
                    double score = union > 0 ? (double)inter / union : 0;
                    return new { Product = p, Score = score, Inter = inter };
                })
                .Where(x => x.Inter >= 2 && x.Score >= 0.45)
                .OrderByDescending(x => x.Score)
                .FirstOrDefault();

            if (bestJaccard != null)
                return new MatchOutput { Product = bestJaccard.Product, TierName = $"Pillə 4 (Token Jaccard {bestJaccard.Score:P0})" };
        }

        return null;
    }
}
