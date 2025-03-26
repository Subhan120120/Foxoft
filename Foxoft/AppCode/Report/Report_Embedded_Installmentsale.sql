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
        ph.OperationDate > i.DocumentDate -- payments without downpayments
    GROUP BY
        ph.InvoiceHeaderId, ph.CurrAccCode
),
DownPaymentSum AS (
    SELECT
        i.InvoiceHeaderId,
        SUM(pl.PaymentLoc) AS DownPaymentSum
    FROM
        TrPaymentLines pl
    INNER JOIN
        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    INNER JOIN
        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE
        ph.OperationDate <= i.DocumentDate -- only downpayments
    GROUP BY
        i.InvoiceHeaderId
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.DocumentDate,
        i.Amount + COALESCE(ril.NetAmount, 0) AS Amount,
        i.AmountLoc + COALESCE(ril.NetAmountLoc, 0) AS AmountLoc, 
        i.CurrencyCode,
        i.ExchangeRate,
        (i.AmountLoc + i.Commission) + COALESCE(ril.NetAmountLoc, 0) AS AmountWithComLoc,
        ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        pp.DurationInMonths,
        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid,
        COALESCE(dps.DownPaymentSum, 0) AS DownPayment
    FROM
        TrInstallments i
    INNER JOIN
        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    INNER JOIN
        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
    INNER JOIN
        DcPaymentPlans pp ON i.PaymentPlanCode = pp.PaymentPlanCode
    LEFT JOIN
        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
    LEFT JOIN
        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
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
        Amount,
        AmountWithComLoc,
        CurrencyCode,
        ExchangeRate,
        DownPayment,
        TotalPaid,
		DurationInMonths,
        AmountWithComLoc - TotalPaid AS RemainingBalance,
        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,
        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,
		DATEADD(MONTH, 
		    FLOOR(TotalPaid / COALESCE(NULLIF(AmountWithComLoc / NULLIF(DurationInMonths, 0), 0), 1)) + 1, DocumentDate
		) AS OverdueDate
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
    Amount,
    CurrencyCode,
    ExchangeRate,
    MonthlyPayment,
    [Tutar Faizi ilə] = AmountWithComLoc,
	[Ay] = DurationInMonths,
    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately
    [Toplam Ödəniş] = TotalPaid,   -- Payments excluding downpayment
    [Qalıq] = RemainingBalance,
    [Aylıq Ödəniş] = MonthlyPayment,
    [Ödənilməli məbləğ] = TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,
    [Gecikmə tarixi] = OverdueDate,
    [Gecikmiş Günlər] = CASE 
        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())
        ELSE 0
    END
FROM
    CalculatedData;
