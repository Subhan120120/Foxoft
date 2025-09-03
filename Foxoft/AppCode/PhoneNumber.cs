using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public static class PhoneNumberFormat
    {

        static readonly Regex RxNormalize = new(@"(?!^\+)\D+", RegexOptions.Compiled);
        static readonly Regex RxE164 = new(@"^\+[1-9]\d{6,14}$", RegexOptions.Compiled);
        static readonly Regex RxSplit = new(@"^\+(?<cc>[1-9]\d{0,2})(?<nn>\d{3,14})$", RegexOptions.Compiled);

        public static string FormatIntlPhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // 1) Normalizasiya: yalnız rəqəmlər və başdakı +
            var s = RxNormalize.Replace(input.Trim(), "");
            if (!s.StartsWith("+")) s = "+" + s.TrimStart('+'); // məcburi +

            // 2) E.164 yoxla
            if (!RxE164.IsMatch(s)) return s; // etibarsızsa dəyişmirik ki, istifadəçi düzəltsin

            // 3) Ölkə kodu və milli hissə
            var m = RxSplit.Match(s);
            if (!m.Success) return s;

            var cc = m.Groups["cc"].Value;
            var nn = m.Groups["nn"].Value; // milli nömrə (yalnız rəqəm)

            string formattedNational = nn;

            // 4) Ölkəyə görə peşəkar qruplaşdırma (tez-tez istifadə olunanlar)
            formattedNational = cc switch
            {
                // NANP (ABŞ/Kanada): 3-3-4
                "1" when nn.Length == 10 => Regex.Replace(nn, @"(\d{3})(\d{3})(\d{4})", "$1 $2 $3"),

                // Türkiyə: +90 XXX XXX XX XX
                "90" when nn.Length == 10 => Regex.Replace(nn, @"(\d{3})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4"),

                // Azərbaycan: +994 XX XXX XX XX (9 rəqəm)
                "994" when nn.Length == 9 => Regex.Replace(nn, @"(\d{2})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4"),

                // Rusiya/Kazaxıstan: +7 XXX XXX XX XX
                "7" when nn.Length == 10 => Regex.Replace(nn, @"(\d{3})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4"),

                // Ukrayna: +380 XX XXX XX XX
                "380" when nn.Length == 9 => Regex.Replace(nn, @"(\d{2})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4"),

                // Gürcüstan: +995 XXX XXX XXX (9 rəqəm)
                "995" when nn.Length == 9 => Regex.Replace(nn, @"(\d{3})(\d{3})(\d{3})", "$1 $2 $3"),

                // Böyük Britaniya (sadə ümumi qayda): 3-3-3 və ya 4-3-3
                "44" when nn.Length is >= 9 and <= 10 => Regex.Replace(nn, @"(\d{3,4})(\d{3})(\d{3})", "$1 $2 $3"),

                // Fallback: soldan 3-lük bloklar
                _ => Regex.Replace(nn, @"(\d{3})(?=\d)", "$1 ")
            };

            return $"+{cc} {formattedNational}".Trim();
        }



    }
}
