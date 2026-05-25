using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode
{
    public static class AppFontSettings
    {
        public const string DefaultFontName = "Tahoma";
        public const decimal DefaultFontSize = 10M;
        public const decimal MinFontSize = 8M;
        public const decimal MaxFontSize = 24M;

        public static void Apply(decimal? fontSize = null)
        {
            float normalizedFontSize = (float)NormalizeFontSize(fontSize);
            Font font = new(DefaultFontName, normalizedFontSize);

            WindowsFormsSettings.DefaultFont = font;
            WindowsFormsSettings.DefaultMenuFont = font;
            WindowsFormsSettings.DefaultPrintFont = font;
        }

        public static void ApplyFromDatabase()
        {
            Apply(GetConfiguredFontSize());
        }

        public static decimal GetConfiguredFontSize()
        {
            try
            {
                using subContext dbContext = new();

                decimal fontSize = dbContext.AppSettings
                    .AsNoTracking()
                    .Where(x => x.Id == 1)
                    .Select(x => x.AppFontSize)
                    .FirstOrDefault();

                return NormalizeFontSize(fontSize);
            }
            catch
            {
                return DefaultFontSize;
            }
        }

        public static decimal NormalizeFontSize(decimal? fontSize)
        {
            decimal value = fontSize.GetValueOrDefault(DefaultFontSize);

            if (value <= 0)
                value = DefaultFontSize;

            if (value < MinFontSize)
                value = MinFontSize;
            else if (value > MaxFontSize)
                value = MaxFontSize;

            return Math.Round(value, 1);
        }
    }
}
