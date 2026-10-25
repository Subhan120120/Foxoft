using System;
using System.Linq;
using Foxoft.Models;

namespace Foxoft.AppCode
{
    public static class CreditService
    {
        // Tariff / Cost Constants
        public const decimal WhatsAppCost = 0.05m;
        public const decimal OcrCreditCost = 0.10m;
        public const decimal ProductFeatureAiCost = 0.05m;
        public const decimal AiCostMultiplier = 6.8m;

        // Service Type Constants (matches TrCredit.ServiceType)
        public const string ServiceTypeWhatsApp = "WhatsApp";
        public const string ServiceTypeAiOcr = "AI OCR";
        public const string ServiceTypeProductFeatureAi = "AI Feature";

        #region Balance Inquiries

        public static decimal GetBalance(subContext db)
        {
            return db.TrCredits.Sum(x => (decimal?)x.Amount) ?? 0m;
        }

        public static decimal GetBalance()
        {
            using var db = new subContext();
            return GetBalance(db);
        }

        public static bool HasEnoughBalance(subContext db, decimal requiredAmount)
        {
            return GetBalance(db) >= requiredAmount;
        }

        public static bool HasEnoughBalance(decimal requiredAmount)
        {
            using var db = new subContext();
            return HasEnoughBalance(db, requiredAmount);
        }

        public static bool HasEnoughWhatsAppBalance(subContext db)
        {
            return HasEnoughBalance(db, WhatsAppCost);
        }

        public static bool HasEnoughWhatsAppBalance()
        {
            using var db = new subContext();
            return HasEnoughWhatsAppBalance(db);
        }

        public static bool HasEnoughOcrBalance(subContext db, decimal requiredAmount = OcrCreditCost)
        {
            return HasEnoughBalance(db, requiredAmount);
        }

        public static bool HasEnoughOcrBalance(decimal requiredAmount = OcrCreditCost)
        {
            using var db = new subContext();
            return HasEnoughOcrBalance(db, requiredAmount);
        }

        public static bool HasEnoughFeatureAiBalance(subContext db, decimal requiredAmount = ProductFeatureAiCost)
        {
            return HasEnoughBalance(db, requiredAmount);
        }

        public static bool HasEnoughFeatureAiBalance(decimal requiredAmount = ProductFeatureAiCost)
        {
            using var db = new subContext();
            return HasEnoughFeatureAiBalance(db, requiredAmount);
        }

        public static decimal CalculateCreditFromCost(decimal costUsd, decimal multiplier = AiCostMultiplier)
        {
            if (costUsd <= 0) return 0m;
            decimal credit = costUsd * multiplier;
            return Math.Max(0.01m, Math.Round(credit, 2, MidpointRounding.AwayFromZero));
        }

        public static decimal CalculateCostUsd(string model, int inputTokens, int outputTokens, int webSearchCount = 0)
        {
            if (inputTokens <= 0 && outputTokens <= 0)
            {
                inputTokens = 1000;
                outputTokens = 300;
            }

            string m = (model ?? string.Empty).ToLowerInvariant().Trim();

            decimal inputRatePerMillion;
            decimal outputRatePerMillion;

            if (m.Contains("mini") && !m.Contains("o1") && !m.Contains("o3"))
            {
                // gpt-4o-mini, gpt-4.1-mini: $0.15 input / $0.60 output per 1M tokens
                inputRatePerMillion = 0.15m;
                outputRatePerMillion = 0.60m;
            }
            else if (m.Contains("o3-mini") || m.Contains("o1-mini"))
            {
                // o3-mini: $1.10 / $4.40 per 1M tokens
                inputRatePerMillion = 1.10m;
                outputRatePerMillion = 4.40m;
            }
            else if (m.Contains("o1"))
            {
                // o1: $15.00 / $60.00 per 1M tokens
                inputRatePerMillion = 15.00m;
                outputRatePerMillion = 60.00m;
            }
            else if (m.Contains("gpt-4-turbo") || m.Contains("gpt-4-0125") || m.Contains("gpt-4-1106"))
            {
                // gpt-4-turbo: $10.00 / $30.00 per 1M tokens
                inputRatePerMillion = 10.00m;
                outputRatePerMillion = 30.00m;
            }
            else if (m.Contains("gpt-4.1"))
            {
                // gpt-4.1: $2.00 / $8.00 per 1M tokens
                inputRatePerMillion = 2.00m;
                outputRatePerMillion = 8.00m;
            }
            else if (m.Contains("gpt-3.5"))
            {
                // gpt-3.5-turbo: $0.50 / $1.50 per 1M tokens
                inputRatePerMillion = 0.50m;
                outputRatePerMillion = 1.50m;
            }
            else
            {
                // Default: gpt-4o ($2.50 input / $10.00 output per 1M tokens)
                inputRatePerMillion = 2.50m;
                outputRatePerMillion = 10.00m;
            }

            decimal tokenCost = (inputTokens * (inputRatePerMillion / 1_000_000m))
                              + (outputTokens * (outputRatePerMillion / 1_000_000m));

            // OpenAI web search tool pricing: $5.00 per 1,000 queries = $0.005 per query
            decimal webSearchCost = webSearchCount * 0.005m;

            return tokenCost + webSearchCost;
        }

        #endregion

        #region Usage Creation

        public static TrCredit CreateUsage(string serviceType, decimal cost, string? description)
        {
            return new TrCredit
            {
                CreditId = Guid.NewGuid(),
                TransactionType = CreditTransactionType.Usage,
                Amount = -Math.Abs(cost),
                ServiceType = serviceType,
                Description = description
            };
        }

        public static TrCredit CreateWhatsAppUsage(string? messageType, string receiverPhone)
        {
            return CreateUsage(ServiceTypeWhatsApp, WhatsAppCost, $"WhatsApp {messageType} - {receiverPhone}");
        }

        public static TrCredit CreateOcrUsage(decimal cost = OcrCreditCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "Qaimə AI OCR oxunuşu";
            return CreateUsage(ServiceTypeAiOcr, cost, desc);
        }

        public static TrCredit CreateFeatureAiUsage(decimal cost = ProductFeatureAiCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "Məhsul özəlliklərinin AI axtarışı";
            return CreateUsage(ServiceTypeProductFeatureAi, cost, desc);
        }

        #endregion

        #region Deduction

        public static bool TryDeduct(subContext db, string serviceType, decimal cost, string? description, out string? errorMessage)
        {
            if (!HasEnoughBalance(db, cost))
            {
                errorMessage = Properties.Resources.Common_InsufficientBalance;
                return false;
            }

            var usage = CreateUsage(serviceType, cost, description);
            db.TrCredits.Add(usage);
            errorMessage = null;
            return true;
        }

        public static bool TryDeduct(out string? errorMessage, string serviceType, decimal cost, string? description)
        {
            try
            {
                using var db = new subContext();
                if (!TryDeduct(db, serviceType, cost, description, out errorMessage))
                    return false;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public static bool TryDeductOcrCredit(out string? errorMessage, decimal cost = OcrCreditCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "Qaimə AI OCR oxunuşu";
            return TryDeduct(out errorMessage, ServiceTypeAiOcr, cost, desc);
        }

        public static bool TryDeductFeatureAiCredit(out string? errorMessage, decimal cost = ProductFeatureAiCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "Məhsul özəlliklərinin AI axtarışı";
            return TryDeduct(out errorMessage, ServiceTypeProductFeatureAi, cost, desc);
        }

        #endregion

        #region Refund

        public static void Refund(subContext db, string serviceType, decimal cost, string? description = null)
        {
            var refund = new TrCredit
            {
                CreditId = Guid.NewGuid(),
                TransactionType = CreditTransactionType.Purchase,
                Amount = Math.Abs(cost),
                ServiceType = serviceType,
                Description = description
            };
            db.TrCredits.Add(refund);
        }

        public static void Refund(string serviceType, decimal cost, string? description = null)
        {
            try
            {
                using var db = new subContext();
                Refund(db, serviceType, cost, description);
                db.SaveChanges();
            }
            catch
            {
                // Ignore refund failures
            }
        }

        public static void RefundOcrCredit(decimal cost = OcrCreditCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "AI OCR geri qaytarılma";
            Refund(ServiceTypeAiOcr, cost, desc);
        }

        public static void RefundFeatureAiCredit(decimal cost = ProductFeatureAiCost, string? description = null)
        {
            string desc = !string.IsNullOrWhiteSpace(description) ? description : "Məhsul özəllikləri AI ləğv edildi (kredit qaytarıldı)";
            Refund(ServiceTypeProductFeatureAi, cost, desc);
        }

        #endregion
    }

    public class AiCancelledException : OperationCanceledException
    {
        public decimal ActualCostUsd { get; }
        public decimal CreditRequired { get; }
        public int InputTokens { get; }
        public int OutputTokens { get; }
        public string Description { get; }

        public AiCancelledException(
            decimal actualCostUsd,
            decimal creditRequired,
            int inputTokens,
            int outputTokens,
            string description,
            Exception? innerException = null)
            : base(description, innerException)
        {
            ActualCostUsd = actualCostUsd;
            CreditRequired = creditRequired;
            InputTokens = inputTokens;
            OutputTokens = outputTokens;
            Description = description;
        }
    }
}
