

WITH PaymentLinesSum AS (
    SELECT
        ph.InvoiceHeaderId,
        ph.CurrAccCode,
        SUM(pl.PaymentLoc) AS PaymentLinesSum
    FROM
        TrPaymentLines pl
    INNER JOIN
        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    GROUP BY
        ph.InvoiceHeaderId, ph.CurrAccCode
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.DocumentDate,
        i.PaymentPlanCode,
        i.Amount,
        i.AmountLoc,
        i.CurrencyCode,
        i.ExchangeRate,
        i.AmountLoc + i.Commission AS AmountWithComLoc,
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
),
CalculatedData AS (
    SELECT
        InstallmentId,
        InvoiceHeaderId,
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
    DocumentDate,
    PaymentPlanCode,
    Amount,
    AmountWithComLoc,
    CurrencyCode,
    ExchangeRate,
    TotalPaid,
    RemainingBalance,
    MonthlyPayment,
    TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment AS DueAmount,
    OverdueDate,
    CASE 
        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())
        ELSE 0
    END AS OverdueDays
FROM
    CalculatedData;
