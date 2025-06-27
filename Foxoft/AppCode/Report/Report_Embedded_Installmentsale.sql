

WITH InstallmentPaymentSum AS (
    SELECT
        ph.InvoiceHeaderId,
        ph.CurrAccCode,
        SUM(pl.PaymentLoc) AS InstallmentPaymentSum
    FROM
        TrPaymentLines pl
    INNER JOIN
        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    INNER JOIN
        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE
        ph.PaymentKindId = 3
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
        ph.PaymentKindId != 3
    GROUP BY
        i.InvoiceHeaderId
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.DocumentDate,
        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmount), 0) AS Amount,
        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc, 
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountWithComLoc,
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,
        ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        ip.DurationInMonths,
        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaid,
        COALESCE(dps.DownPaymentSum, 0) AS DownPayment
    FROM
        TrInstallments i
    INNER JOIN
        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    LEFT JOIN
        TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId
    INNER JOIN
        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
    INNER JOIN
        DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode
    LEFT JOIN
        InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
    LEFT JOIN
        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
    LEFT JOIN
        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 
    LEFT JOIN
        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId
    GROUP BY 
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.DocumentDate,
        ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        ip.DurationInMonths,
        i.Commission,
        psum.InstallmentPaymentSum,
        dps.DownPaymentSum

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
        InstallmentAmount,
        DownPayment,
        InstallmentPaid,
		DurationInMonths,
        InstallmentAmount - InstallmentPaid AS RemainingBalance,
        ((InstallmentAmount) / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,
        FLOOR(InstallmentPaid / ((InstallmentAmount) / NULLIF(DurationInMonths, 0))) AS MonthsPaid,
		DATEADD(MONTH, 
		    FLOOR(InstallmentPaid / COALESCE(NULLIF((InstallmentAmount)/ NULLIF(DurationInMonths, 0), 0), 1)) + 1, DocumentDate
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
    MonthlyPayment,
    [Tutar Faizi ilə] = AmountWithComLoc,
    [Kredit Məbləği] = InstallmentAmount,
	[Ay] = DurationInMonths,
    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately
    [Toplam Ödəniş] = InstallmentPaid,   -- Payments excluding downpayment
    [Qalıq] = RemainingBalance,
    [Aylıq Ödəniş] = MonthlyPayment,
    [Ödənilməli məbləğ] = InstallmentPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,
    [Gecikmə tarixi] = OverdueDate,
    [Gecikmiş Günlər] = CASE 
        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())
        ELSE 0
    END
FROM
    CalculatedData;
