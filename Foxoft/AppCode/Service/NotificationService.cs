using Foxoft.Models;
using Foxoft.Properties;
using Foxoft.AppCode;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Foxoft.AppCode.Service
{
    public class NotificationService
    {
        /// <summary>
        /// Sends scheduled notifications (installment reminders, due day, birthday).
        /// Returns (sentCount, failedCount).
        /// </summary>
        public async Task<(int Sent, int Failed)> SendScheduledNotificationsAsync()
        {
            int sent = 0;
            int failed = 0;

            using var db = new subContext();
            var settings = db.DcNotificationSettings.ToList();

            var apiSetting = db.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl) ||
                string.IsNullOrEmpty(apiSetting.InstanceName) || string.IsNullOrEmpty(apiSetting.ApiKey))
                return (0, 0);

            // 1. Installment Reminder (X days before due date)
            var reminderSetting = settings.FirstOrDefault(s => s.NotificationType == "InstallmentReminder");
            if (reminderSetting?.IsEnabled == true && !string.IsNullOrEmpty(reminderSetting.MessageTemplate))
            {
                var result = await SendInstallmentReminderNotificationsAsync(apiSetting, reminderSetting);
                sent += result.Sent;
                failed += result.Failed;
            }

            // 2. Installment Due Day
            var dueDaySetting = settings.FirstOrDefault(s => s.NotificationType == "InstallmentDueDay");
            if (dueDaySetting?.IsEnabled == true && !string.IsNullOrEmpty(dueDaySetting.MessageTemplate))
            {
                var result = await SendInstallmentDueDayNotificationsAsync(apiSetting, dueDaySetting);
                sent += result.Sent;
                failed += result.Failed;
            }

            // 3. Birthday
            var birthdaySetting = settings.FirstOrDefault(s => s.NotificationType == "Birthday");
            if (birthdaySetting?.IsEnabled == true && !string.IsNullOrEmpty(birthdaySetting.MessageTemplate))
            {
                var result = await SendBirthdayNotificationsAsync(apiSetting, birthdaySetting);
                sent += result.Sent;
                failed += result.Failed;
            }

            return (sent, failed);
        }

        /// <summary>
        /// Sends notification after a payment is made on an installment sale.
        /// </summary>
        public async Task SendPaymentNotificationAsync(Guid invoiceHeaderId, decimal paid, decimal remaining)
        {
            using var db = new subContext();
            var setting = db.DcNotificationSettings.FirstOrDefault(s => s.NotificationType == "CreditPayment");
            if (setting?.IsEnabled != true || string.IsNullOrEmpty(setting.MessageTemplate))
                return;

            var apiSetting = db.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl))
                return;

            // Get customer info from invoice header
            var header = db.TrInvoiceHeaders.FirstOrDefault(h => h.InvoiceHeaderId == invoiceHeaderId);
            if (header == null || string.IsNullOrEmpty(header.CurrAccCode))
                return;

            var currAcc = db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == header.CurrAccCode);
            if (currAcc == null || string.IsNullOrEmpty(currAcc.PhoneNum))
                return;

            var store = db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == header.StoreCode);

            string message = ApplyPlaceholders(setting.MessageTemplate, currAcc, store, null);
            message = message.Replace("{paid}", paid.ToString("N2"))
                             .Replace("{debit}", remaining.ToString("N2"));


            await SendAndLogAsync(apiSetting, currAcc.PhoneNum, message, "CreditPayment",
                                  currAcc.CurrAccCode, invoiceHeaderId);

            // Check if credit is fully closed
            if (remaining <= 0)
            {
                var closedSetting = db.DcNotificationSettings.FirstOrDefault(s => s.NotificationType == "CreditClosed");
                if (closedSetting?.IsEnabled == true && !string.IsNullOrEmpty(closedSetting.MessageTemplate))
                {
                    string closedMsg = ApplyPlaceholders(closedSetting.MessageTemplate, currAcc, store, null);
                    await SendAndLogAsync(apiSetting, currAcc.PhoneNum, closedMsg, "CreditClosed",
                                          currAcc.CurrAccCode, invoiceHeaderId);
                }
            }
        }

        /// <summary>
        /// Sends notification when a product is purchased (IS process invoice saved).
        /// </summary>
        public async Task SendProductPurchaseNotificationAsync(string currAccCode, string phoneNum)
        {
            using var db = new subContext();
            var setting = db.DcNotificationSettings.FirstOrDefault(s => s.NotificationType == "ProductPurchase");
            if (setting?.IsEnabled != true || string.IsNullOrEmpty(setting.MessageTemplate))
                return;

            if (string.IsNullOrEmpty(phoneNum))
                return;

            var apiSetting = db.DcWhatsAppProviderSettings.FirstOrDefault(x => x.Id == 1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl))
                return;

            var currAcc = db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == currAccCode);
            var store = currAcc != null ? db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == currAcc.StoreCode) : null;

            string message = ApplyPlaceholders(setting.MessageTemplate, currAcc, store, null);

            await SendAndLogAsync(apiSetting, phoneNum, message, "ProductPurchase", currAccCode, null);
        }

        private async Task<(int Sent, int Failed)> SendInstallmentReminderNotificationsAsync(
            DcWhatsAppProviderSetting apiSetting, DcNotificationSetting setting)
        {
            int sent = 0, failed = 0;
            int daysBefore = setting.DaysBefore ?? 2;

            // Use the installment SQL to find customers whose due date is X days from now
            var installments = GetInstallmentsDueInDays(daysBefore);

            foreach (var row in installments)
            {
                try
                {
                    string phoneNum = row["PhoneNum"]?.ToString();
                    if (string.IsNullOrEmpty(phoneNum)) continue;

                    string currAccDesc = row["CurrAccDesc"]?.ToString() ?? "";

                    string message = setting.MessageTemplate
                        .Replace("{day}", daysBefore.ToString())
                        .Replace("{CurrAccDesc}", currAccDesc);

                    // Apply store placeholders from settings
                    message = ApplyStorePlaceholders(message);

                    bool isSent = await SendAndLogAsync(apiSetting, phoneNum, message, "InstallmentReminder",
                                                        null, null);
                    if (isSent) sent++;
                    else failed++;
                }
                catch (Exception ex)
                {
                    Debug.Print($"InstallmentReminder notification error: {ex.Message}");
                    failed++;
                }
            }

            return (sent, failed);
        }

        private async Task<(int Sent, int Failed)> SendInstallmentDueDayNotificationsAsync(
            DcWhatsAppProviderSetting apiSetting, DcNotificationSetting setting)
        {
            int sent = 0, failed = 0;

            // Customers whose due date is today
            var installments = GetInstallmentsDueInDays(0);

            foreach (var row in installments)
            {
                try
                {
                    string phoneNum = row["PhoneNum"]?.ToString();
                    if (string.IsNullOrEmpty(phoneNum)) continue;

                    string currAccDesc = row["CurrAccDesc"]?.ToString() ?? "";

                    string message = setting.MessageTemplate
                        .Replace("{CurrAccDesc}", currAccDesc);

                    message = ApplyStorePlaceholders(message);

                    bool isSent = await SendAndLogAsync(apiSetting, phoneNum, message, "InstallmentDueDay",
                                                        null, null);
                    if (isSent) sent++;
                    else failed++;
                }
                catch (Exception ex)
                {
                    Debug.Print($"InstallmentDueDay notification error: {ex.Message}");
                    failed++;
                }
            }

            return (sent, failed);
        }

        private async Task<(int Sent, int Failed)> SendBirthdayNotificationsAsync(
            DcWhatsAppProviderSetting apiSetting, DcNotificationSetting setting)
        {
            int sent = 0, failed = 0;

            using var db = new subContext();
            var today = DateTime.Today;

            // Find customers whose birthday is today
            var customers = db.DcCurrAccs
                .Where(c => c.BirthDate.HasValue
                         && c.BirthDate.Value.Month == today.Month
                         && c.BirthDate.Value.Day == today.Day
                         && !string.IsNullOrEmpty(c.PhoneNum))
                .ToList();

            foreach (var customer in customers)
            {
                try
                {
                    var store = db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == customer.StoreCode);
                    string message = ApplyPlaceholders(setting.MessageTemplate, customer, store, null);

                    bool isSent = await SendAndLogAsync(apiSetting, customer.PhoneNum, message, "Birthday",
                                                        customer.CurrAccCode, null);
                    if (isSent) sent++;
                    else failed++;
                }
                catch (Exception ex)
                {
                    Debug.Print($"Birthday notification error: {ex.Message}");
                    failed++;
                }
            }

            return (sent, failed);
        }

        private List<DataRow> GetInstallmentsDueInDays(int daysFromNow)
        {
            var adoMethods = new AdoMethods();
            DateTime targetDate = DateTime.Today.AddDays(daysFromNow);

            // Use the existing installment SQL query to find active installments
            string query = @"
                ;WITH InstallmentPaymentSum AS (
                    SELECT ph.InvoiceHeaderId, ph.CurrAccCode, SUM(pl.PaymentLoc) AS InstallmentPaymentSum
                    FROM TrPaymentLines pl
                    JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
                    JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
                    WHERE ph.PaymentKindId = 3
                    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode
                ),
                DownPaymentSum AS (
                    SELECT i.InvoiceHeaderId, SUM(pl.PaymentLoc) AS DownPaymentSum
                    FROM TrInstallments i
                    JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId
                    JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId AND ih.CurrAccCode = ph.CurrAccCode
                    JOIN TrPaymentLines pl ON ph.PaymentHeaderId = pl.PaymentHeaderId
                    WHERE ph.PaymentKindId != 3
                    GROUP BY i.InvoiceHeaderId
                ),
                InstallmentData AS (
                    SELECT i.InstallmentId, i.InvoiceHeaderId, i.InstallmentDate,
                        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc,
                        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)
                          - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,
                        ca.CurrAccDesc, ca.PhoneNum, ip.DurationInMonths,
                        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaid,
                        COALESCE(dps.DownPaymentSum, 0) AS DownPayment
                    FROM TrInstallments i
                    JOIN TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
                    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId
                    JOIN DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
                    JOIN DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode
                    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
                    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
                    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1
                    LEFT JOIN TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId
                    GROUP BY i.InstallmentId, i.InvoiceHeaderId, i.InstallmentDate,
                        ca.CurrAccDesc, ca.PhoneNum, ip.DurationInMonths, i.Commission,
                        psum.InstallmentPaymentSum, dps.DownPaymentSum
                )
                SELECT id.CurrAccDesc, id.PhoneNum
                FROM InstallmentData id
                OUTER APPLY (
                    SELECT MonthlyPayment = CASE WHEN NULLIF(id.DurationInMonths, 0) IS NULL OR COALESCE(id.InstallmentAmount, 0) = 0 THEN 0.0
                        ELSE COALESCE(id.InstallmentAmount, 0) * 1.0 / NULLIF(id.DurationInMonths, 0) END
                ) mp
                OUTER APPLY (
                    SELECT RawPassed = DATEDIFF(MONTH, id.InstallmentDate, CAST(GETDATE() AS date))
                ) rp
                OUTER APPLY (
                    SELECT PassedMonth = CASE WHEN rp.RawPassed < 0 THEN 0
                        WHEN rp.RawPassed > COALESCE(id.DurationInMonths, 0) THEN COALESCE(id.DurationInMonths, 0)
                        ELSE rp.RawPassed END
                ) pm
                OUTER APPLY (
                    SELECT PaidMonth = CASE WHEN mp.MonthlyPayment <= 0 THEN 0
                        ELSE CASE WHEN FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment) > COALESCE(id.DurationInMonths, 0)
                            THEN COALESCE(id.DurationInMonths, 0)
                            ELSE FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment) END END
                ) p2
                OUTER APPLY (
                    SELECT DueDate = CASE WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) <= 0 THEN NULL
                        ELSE DATEADD(MONTH, p2.PaidMonth + 1, id.InstallmentDate) END
                ) dd
                WHERE COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) > 0
                  AND dd.DueDate IS NOT NULL
                  AND CAST(dd.DueDate AS date) = @TargetDate
                  AND id.PhoneNum IS NOT NULL AND id.PhoneNum != ''
            ";

            SqlParameter[] parameters = { new SqlParameter("@TargetDate", targetDate.Date) };
            DataTable dt = adoMethods.SqlGetDt(query, parameters);

            return dt.Rows.Cast<DataRow>().ToList();
        }

        private string ApplyPlaceholders(string template, DcCurrAcc customer, DcCurrAcc store, int? daysBefore)
        {
            if (string.IsNullOrEmpty(template))
                return template;

            template = template
                .Replace("{CurrAccDesc}", customer?.CurrAccDesc ?? "")
                .Replace("{CurrAccCode}", customer?.CurrAccCode ?? "")
                .Replace("{PhoneNum}", customer?.PhoneNum ?? "");

            if (daysBefore.HasValue)
                template = template.Replace("{day}", daysBefore.Value.ToString());

            template = ApplyStorePlaceholders(template, store);

            return template;
        }

        private string ApplyStorePlaceholders(string template, DcCurrAcc store = null)
        {
            if (store != null)
            {
                template = template
                    .Replace("{StoreDesc}", store.CurrAccDesc ?? "")
                    .Replace("{StorePhone}", store.PhoneNum ?? "");
            }
            else
            {
                // Fallback: use authorization store info
                using var db = new subContext();
                var authStore = db.DcCurrAccs.FirstOrDefault(c => c.CurrAccCode == Authorization.StoreCode);
                template = template
                    .Replace("{StoreDesc}", authStore?.CurrAccDesc ?? "")
                    .Replace("{StorePhone}", authStore?.PhoneNum ?? "");
            }

            return template;
        }

        private async Task<bool> SendAndLogAsync(DcWhatsAppProviderSetting apiSetting, string phoneNum,
            string message, string messageType, string currAccCode, Guid? documentHeaderId)
        {
            string formattedNumber = phoneNum.Trim().Replace("+", "").Replace(" ", "");

            using var db = new subContext();
            var logEntry = new TrWhatsAppMessageLog
            {
                WhatsAppMessageLogId = Guid.NewGuid(),
                DocumentHeaderId = documentHeaderId,
                ReceiverPhoneNumber = formattedNumber,
                MessageType = messageType,
                Message = message,
                Sender = Authorization.CurrAccCode,
                CurrAccCode = currAccCode
            };
            if (!WhatsAppCreditService.HasEnoughBalance(db))
            {
                logEntry.IsSuccessful = false;

                db.TrWhatsAppMessageLogs.Add(logEntry);
                db.SaveChanges();
                return false;
            }

            try
            {
                using var client = new EvolutionApiClient(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);
                await client.SendTextAsync(formattedNumber, message);

                logEntry.IsSuccessful = true;

                db.TrCredits.Add(WhatsAppCreditService.CreateUsage(messageType, formattedNumber));

                db.TrWhatsAppMessageLogs.Add(logEntry);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logEntry.IsSuccessful = false;
                db.TrWhatsAppMessageLogs.Add(logEntry);
                db.SaveChanges();

                var mainForm = System.Windows.Forms.Application.OpenForms.OfType<System.Windows.Forms.Form>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.Invoke((Action)(() =>
                    {
                        var alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
                        alertControl.AutoFormDelay = 4000;
                        alertControl.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Fast;
                        alertControl.Show(mainForm, Resources.Common_ErrorTitle, string.Format(Resources.Common_WhatsAppSendError, ex.Message));
                    }));
                }

                return false;
            }
        }
    }
}
