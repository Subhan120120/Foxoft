using Foxoft.Models;
using System.Linq;

namespace Foxoft.AppCode
{
    public static class WhatsAppCreditService
    {
        public const decimal MessageCreditAmount = 0.05m;

        public static decimal GetBalance(subContext db)
        {
            return db.TrCredits.Sum(x => (decimal?)x.Amount) ?? 0m;
        }

        public static bool HasEnoughBalance(subContext db)
        {
            return GetBalance(db) >= MessageCreditAmount;
        }

        public static bool HasEnoughBalance()
        {
            using var db = new subContext();
            return HasEnoughBalance(db);
        }

        public static TrCredit CreateUsage(string messageType, string receiverPhone)
        {
            return new TrCredit
            {
                CreditId = Guid.NewGuid(),
                TransactionType = CreditTransactionType.Usage,
                Amount = -MessageCreditAmount,
                ServiceType = "WhatsApp",
                Description = $"WhatsApp {messageType} - {receiverPhone}"
            };
        }
    }
}
