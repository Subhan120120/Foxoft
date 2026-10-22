using System;
using System.Text.Json;
using Foxoft.Properties;

namespace Foxoft.Models
{
    public class ProductMatchOptions
    {
        /// <summary>
        /// Pillə 1: Ştrixkod və daxili məhsul kodu ilə dəqiq axtarış (Default: true)
        /// </summary>
        public bool MatchByBarcodeAndCode { get; set; } = true;

        /// <summary>
        /// Pillə 2: Kateqoriya (iyerarxiya) və xüsusi stop-words prefikslərinin təmizlənməsi (Default: false)
        /// </summary>
        public bool MatchByCategoryStopWords { get; set; } = false;

        /// <summary>
        /// İstifadəçi tərəfindən daxil edilən xüsusi təmizlənəcək sözlər (vergüllə ayrılmış)
        /// </summary>
        public string CustomStopWords { get; set; } = string.Empty;

        /// <summary>
        /// Pillə 3: Alfasayısal Model / Part Number və brend üzrə uyğunlaşdırma (Default: true)
        /// </summary>
        public bool MatchByModelAndBrand { get; set; } = true;

        /// <summary>
        /// Pillə 4: Sıradan asılı olmayan Token Overlap və Jaccard oxşarlığı (Default: true)
        /// </summary>
        public bool MatchByTokenOverlap { get; set; } = true;

        /// <summary>
        /// Pillə 5: Qeyri-səlis (Fuzzy / Levenshtein) oxşarlıq (Default: false)
        /// </summary>
        public bool MatchByFuzzySimilarity { get; set; } = false;

        /// <summary>
        /// Pillə 6: Təchizatçı alış tarixi və əvvəlki qaimə adlarının yaddaşı (Default: true)
        /// </summary>
        public bool MatchByVendorHistory { get; set; } = true;

        /// <summary>
        /// Fuzzy minimal oxşarlıq faizi (Default: 85%)
        /// </summary>
        public int FuzzyMinSimilarityPercent { get; set; } = 85;

        public static ProductMatchOptions Load()
        {
            try
            {
                string json = Settings.Default.ProductMatchSettings;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var opt = JsonSerializer.Deserialize<ProductMatchOptions>(json);
                    if (opt != null)
                        return opt;
                }
            }
            catch
            {
                // Fall back to default
            }

            return new ProductMatchOptions();
        }

        public void Save()
        {
            try
            {
                Settings.Default.ProductMatchSettings = JsonSerializer.Serialize(this);
                Settings.Default.Save();
            }
            catch
            {
                // Ignore save errors
            }
        }

        public void ResetToDefaults()
        {
            MatchByBarcodeAndCode = true;       // Pillə 1
            MatchByCategoryStopWords = false;   // Pillə 2
            CustomStopWords = string.Empty;
            MatchByModelAndBrand = true;        // Pillə 3
            MatchByTokenOverlap = true;         // Pillə 4
            MatchByFuzzySimilarity = false;     // Pillə 5
            MatchByVendorHistory = true;        // Pillə 6
            FuzzyMinSimilarityPercent = 85;
        }
    }
}
