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
}
