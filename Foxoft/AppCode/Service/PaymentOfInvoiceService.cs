using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;

namespace Foxoft.AppCode.Services
{
    public sealed class PaymentService
    {
        private readonly EfMethods _ef;
        private readonly DcProcess _process;

        public PaymentService(DcProcess process)
        {
            _ef = new EfMethods();
            _process = process ?? throw new ArgumentNullException(nameof(process));
        }

        /// <summary>
        /// Invoice xətlərinə əsasən PaymentHeader + PaymentLine-ları yenidən qurur.
        /// (Səndəki SavePayment logic eyni)
        /// </summary>
        public void RebuildPaymentsFromInvoice(TrInvoiceHeader invoice, string? cashRegisterCode)
        {
            if (invoice is null) throw new ArgumentNullException(nameof(invoice));
            if (string.IsNullOrWhiteSpace(Authorization.CurrAccCode)) throw new ArgumentNullException(nameof(Authorization.CurrAccCode));

            TrPaymentHeader paymentHeader = BuildPaymentHeaderDefaults(invoice, Authorization.CurrAccCode);

            decimal invoiceSumLoc = Math.Abs(_ef.SelectInvoiceSum(invoice.InvoiceHeaderId));
            if (Convert.ToBoolean(CustomExtensions.DirectionIsIn(invoice.ProcessCode)))
                invoiceSumLoc *= (-1);

            bool isNegativ = invoiceSumLoc < 0;

            bool paymentHeadExist = _ef.PaymentExistByInvoice(invoice.InvoiceHeaderId);
            if (paymentHeadExist)
            {
                paymentHeader = _ef.SelectPaymentHeaderByInvoice(invoice.InvoiceHeaderId);
            }
            else
            {
                string newDocNum = _ef.GetNextDocNum(
                    DefisExist: true,
                    processCode: "PA",
                    columnName: nameof(TrPaymentHeader.DocumentNumber),
                    tableName: nameof(subContext.TrPaymentHeaders),
                    ReplicateNum: 6);

                paymentHeader.DocumentNumber = newDocNum;
                paymentHeader.Description = invoice.Description;

                _ef.InsertEntity(paymentHeader);
            }

            // köhnə lines-ları sil
            _ef.DeletePaymentLinesByPaymentHeader(paymentHeader.PaymentHeaderId);

            // yeni lines-ları qur
            List<TrInvoiceLine> invoiceLines = _ef.SelectInvoiceLines(invoice.InvoiceHeaderId);
            foreach (TrInvoiceLine il in invoiceLines)
            {
                if (il.NetAmount == 0) continue;

                TrPaymentLine line = BuildPaymentLineDefaults(invoice, Authorization.CurrAccCode);

                line.PaymentHeaderId = paymentHeader.PaymentHeaderId;
                line.PaymentLineId = il.InvoiceLineId;

                line.Payment = isNegativ ? il.NetAmount * (-1) : il.NetAmount;
                line.CurrencyCode = il.CurrencyCode;
                line.ExchangeRate = il.ExchangeRate;

                line.CashRegisterCode = cashRegisterCode;
                line.LineDescription = il.LineDescription;

                line.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;

                _ef.InsertEntity(line);
            }
        }

        /// <summary>SavePayment
        /// Label-lar üçün ödənilmiş məbləğləri qaytarır.
        /// (Səndəki CalcPaidAmount logic eyni)
        /// </summary>
        public PaidSummary GetPaidSummary(Guid invoiceHeaderId, string currAccCode, int processDir)
        {
            int sign = (processDir == 1) ? -1 : 1;

            decimal cash = _ef.SelectPaymentLinesCashSumByInvoice(invoiceHeaderId, currAccCode) * sign;
            decimal cashless = _ef.SelectPaymentLinesCashlessSumByInvoice(invoiceHeaderId, currAccCode) * sign;
            decimal loyalty = _ef.SelectPaymentLinesLoyaltySumByInvoice(invoiceHeaderId, currAccCode) * sign;
            decimal total = _ef.SelectPaymentLinesSumByInvoice(invoiceHeaderId, currAccCode) * sign;

            return new PaidSummary(
                Cash: Math.Round(cash, 2),
                Cashless: Math.Round(cashless, 2),
                Loyalty: Math.Round(loyalty, 2),
                Total: Math.Round(total, 2),
                CurrencyCode: Settings.Default.AppSetting.LocalCurrencyCode
            );
        }

        private TrPaymentHeader BuildPaymentHeaderDefaults(TrInvoiceHeader invoice, string userName)
        {
            var ph = new TrPaymentHeader
            {
                PaymentHeaderId = Guid.NewGuid(),
                CurrAccCode = invoice.CurrAccCode,
                ProcessCode = _process.ProcessCode,
                CreatedUserName = userName,
                OfficeCode = invoice.OfficeCode,
                StoreCode = invoice.StoreCode,
                IsMainTF = true,
                DocumentDate = invoice.DocumentDate,
                DocumentTime = invoice.DocumentTime,
                InvoiceHeaderId = invoice.InvoiceHeaderId,
                OperationDate = invoice.DocumentDate,
                OperationTime = invoice.DocumentTime,
                PaymentKindId = 2
            };

            return ph;
        }

        private TrPaymentLine BuildPaymentLineDefaults(TrInvoiceHeader invoice, string userName)
        {
            var pl = new TrPaymentLine
            {
                PaymentTypeCode = PaymentType.Cash,
                PaymentMethodId = 1,
                CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode,
                ExchangeRate = 1f,
                CashRegisterCode = _ef.SelectCashRegisterByTerminal(Settings.Default.TerminalId),
                CreatedUserName = userName
            };

            return pl;
        }
    }

    public sealed record PaidSummary(
        decimal Cash,
        decimal Cashless,
        decimal Loyalty,
        decimal Total,
        string CurrencyCode
    );
}