WITH InstallmentPaymentSum AS (
    SELECT
        ph.InvoiceHeaderId,
        ph.CurrAccCode,
        SUM(pl.PaymentLoc) AS InstallmentPaymentSum
    FROM TrPaymentLines pl
    INNER JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    INNER JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE ph.PaymentKindId = 3
    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode
),
DownPaymentSum AS (
    SELECT
        i.InvoiceHeaderId,
        SUM(pl.PaymentLoc) AS DownPaymentSum
    FROM TrInstallments i
    INNER JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId  
    INNER JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId AND ih.CurrAccCode = ph.CurrAccCode
    INNER JOIN TrPaymentLines pl ON ph.PaymentHeaderId = pl.PaymentHeaderId
    WHERE ph.PaymentKindId <> 3
    GROUP BY i.InvoiceHeaderId
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.InstallmentDate,
        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS Amount,
        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc, 
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountWithComLoc,
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,
        ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        ip.DurationInMonths,
        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaidSum,
        COALESCE(dps.DownPaymentSum, 0) AS DownPayment
    FROM TrInstallments i
    INNER JOIN TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId
    INNER JOIN DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
    INNER JOIN DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode
    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 
    LEFT JOIN TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId
    GROUP BY 
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.InstallmentDate,
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
        InstallmentDate,
        Amount,
        AmountWithComLoc,
        InstallmentAmount,
        DownPayment,
        InstallmentPaidSum,
        DurationInMonths,
        InstallmentAmount - InstallmentPaidSum AS RemainingBalance,
        ((InstallmentAmount) / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,
        FLOOR(InstallmentPaidSum / (InstallmentAmount / NULLIF(DurationInMonths, 0))) AS MonthsPaid,
        -- Keçən ayları hesabla, 0-dan aşağı olmasın və maksimum DurationInMonths olsun
        CASE 
            WHEN GETDATE() < InstallmentDate THEN 0
            ELSE
                CASE 
                    WHEN DATEDIFF(MONTH, InstallmentDate, GETDATE()) > DurationInMonths 
                        THEN DurationInMonths
                    ELSE DATEDIFF(MONTH, InstallmentDate, GETDATE())
                END
        END AS MonthsElapsedCapped,
        CASE 
            WHEN DurationInMonths = 0 THEN InstallmentDate
            ELSE DATEADD(MONTH, FLOOR(InstallmentPaidSum / (NULLIF(InstallmentAmount / NULLIF(DurationInMonths, 0), 0))) + 1, InstallmentDate)
        END AS OverdueDate,
        ENDDATE = DATEADD(MONTH, DurationInMonths, InstallmentDate)
    FROM InstallmentData
)
SELECT
    InstallmentId,
    InvoiceHeaderId,
    CurrAccDesc,
    PhoneNum,
    DocumentNumber,
    InstallmentDate,
    Amount,
    MonthsPaid,
    MonthlyPayment,
    [Tutar Faizi ilə] = AmountWithComLoc,
    [Kredit Məbləği] = InstallmentAmount,
    [Ay] = DurationInMonths,
    [İlkin Ödəniş] = DownPayment,
    [Toplam Ödəniş] = InstallmentPaidSum,
    [Qalıq] = RemainingBalance,
    [Aylıq Ödəniş] = MonthlyPayment,
    [Ödənilməli məbləğ] = InstallmentPaidSum - (MonthsElapsedCapped * MonthlyPayment),
    [Gecikmə tarixi] = OverdueDate,
    [Gecikmiş Günlər] = CASE 
        WHEN DATEDIFF(DAY, ENDDATE, OverdueDate) > 0 THEN 0
        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())
        ELSE 0
    END
FROM CalculatedData;
