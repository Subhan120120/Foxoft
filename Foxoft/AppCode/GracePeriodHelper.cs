namespace Foxoft.AppCode
{
    public static class GracePeriodHelper
    {
        public static bool IsExpired(DateTime documentDate, int? graceDays)
        {
            if (graceDays is null)
                return false;

            int normalizedGraceDays = Math.Max(0, graceDays.Value);
            DateTime cutoffDate = DateTime.Today.AddDays(-normalizedGraceDays);

            return documentDate.Date < cutoffDate;
        }
    }
}
