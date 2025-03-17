WITH PaymentLinesSum AS (
    SELECT
        ph.InvoiceHeaderId,
        ph.CurrAccCode,
        SUM(pl.PaymentLoc) AS PaymentLinesSum
    FROM
        TrPaymentLines pl
    INNER JOIN
        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    INNER JOIN
        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE
        ph.OperationDate > i.DocumentDate -- Filter payments after DocumentDate
    GROUP BY
        ph.InvoiceHeaderId, ph.CurrAccCode
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.DocumentDate,
        i.PaymentPlanCode,
        i.Amount + COALESCE(ril.NetAmount, 0) AS Amount,
        i.AmountLoc + COALESCE(ril.NetAmountLoc, 0) AS AmountLoc, -- Geri qaytarma məbləğini çıxırıq
        i.CurrencyCode,
        i.ExchangeRate,
        (i.AmountLoc + i.Commission) + COALESCE(ril.NetAmountLoc, 0) AS AmountWithComLoc, -- Geri qaytarma məbləğini çıxırıq
		ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        p.DurationInMonths,
        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid
    FROM
        TrInstallments i
    INNER JOIN
        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    INNER JOIN
        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
    INNER JOIN
        DcPaymentPlans p ON i.PaymentPlanCode = p.PaymentPlanCode
    LEFT JOIN
        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
    LEFT JOIN
        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 
    LEFT JOIN
        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId
),
CalculatedData AS (
    SELECT
        InstallmentId,
        InvoiceHeaderId,
		CurrAccDesc,
		PhoneNum,
        DocumentNumber,
        DocumentDate,
        PaymentPlanCode,
        Amount,
        AmountWithComLoc,
        CurrencyCode,
        ExchangeRate,
        TotalPaid,
        AmountWithComLoc - TotalPaid AS RemainingBalance,
        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,
        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,
        DATEADD(MONTH, FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) + 1, DocumentDate) AS OverdueDate
    FROM
        InstallmentData
)
SELECT
    InstallmentId,
    InvoiceHeaderId,
	CurrAccDesc,
	PhoneNum,
	DocumentNumber,
    DocumentDate,
    PaymentPlanCode,
    Amount,
    [Tutar Faizi ilə] = AmountWithComLoc,
    CurrencyCode,
    ExchangeRate,
    [Toplam Ödəniş] = TotalPaid,
    [Qalıq] = RemainingBalance,
    [Aylıq Ödəniş] = MonthlyPayment,
	MonthlyPayment,
    [Ödənilməli məbləğ] = TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,
    [Gecikmə tarixi] = OverdueDate,
    [Gecikmiş Günlər] = CASE 
        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())
        ELSE 0
    END
FROM
    CalculatedData;