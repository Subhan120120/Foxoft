;WITH InstallmentPaymentSum AS (
    SELECT
        ph.InvoiceHeaderId,
        ph.CurrAccCode,
        SUM(pl.PaymentLoc) AS InstallmentPaymentSum
    FROM TrPaymentLines pl
    JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE ph.PaymentKindId = 3
    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode
),
DownPaymentSum AS (
    SELECT
        i.InvoiceHeaderId,
        SUM(pl.PaymentLoc) AS DownPaymentSum
    FROM TrInstallments i
    JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId
    JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId
                             AND ih.CurrAccCode     = ph.CurrAccCode
    JOIN TrPaymentLines pl   ON ph.PaymentHeaderId  = pl.PaymentHeaderId
    WHERE ph.PaymentKindId != 3
    GROUP BY i.InvoiceHeaderId
),
InstallmentData AS (
    SELECT
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.InstallmentDate,
        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0)                                AS AmountLoc,
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)               AS AmountWithComLoc,
        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)
          - COALESCE(dps.DownPaymentSum, 0)                                                      AS InstallmentAmount,
        ih.DocumentNumber,
        ca.CurrAccDesc,
        ca.PhoneNum,
        ip.DurationInMonths,
        COALESCE(psum.InstallmentPaymentSum, 0)                                                  AS InstallmentPaid,
        COALESCE(dps.DownPaymentSum, 0)                                                          AS DownPayment
    FROM TrInstallments i
    JOIN TrInvoiceHeaders ih    ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId
    JOIN DcCurrAccs ca          ON ih.CurrAccCode = ca.CurrAccCode
    JOIN DcInstallmentPlan ip   ON i.InstallmentPlanCode = ip.InstallmentPlanCode
    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId
                                         AND ih.CurrAccCode     = psum.CurrAccCode
    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1
    LEFT JOIN TrInvoiceLines ril   ON ril.InvoiceHeaderId  = rih.InvoiceHeaderId
                                   AND ril.RelatedLineId   = il.InvoiceLineId
    GROUP BY
        i.InstallmentId, i.InvoiceHeaderId, i.InstallmentDate,
        ih.DocumentNumber, ca.CurrAccDesc, ca.PhoneNum,
        ip.DurationInMonths, i.Commission, psum.InstallmentPaymentSum, dps.DownPaymentSum
)
SELECT
    id.InstallmentId,
    id.InvoiceHeaderId,
    id.DocumentNumber,
    id.CurrAccDesc,
    id.PhoneNum,
	id.InstallmentDate,
    [Kredit Məbləği]     = id.InstallmentAmount,
    [Müddət Ay]          = id.DurationInMonths,
    [Ödənilmiş Məbləğ]   = id.InstallmentPaid,

    [Qalıq] = CASE
        WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) < 0 THEN 0
        ELSE COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0)
    END,

    [Aylıq Ödəniş]   = mp.MonthlyPayment,

    [Keçən Aylar]    = pm.PassedMonth,

    [Ödənilmiş Ay]   = p2.PaidMonth,

    [Gecikən Məbləğ] = CASE
        WHEN pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid,0) < 0 THEN 0
        ELSE pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid,0)
    END,

    [Gecikmə Tarixi] = dd.DueDate,

    [Gecikmiş Günlər] = od.OverDueDays

FROM InstallmentData id
OUTER APPLY (
    SELECT MonthlyPayment =
        CASE
            WHEN NULLIF(id.DurationInMonths, 0) IS NULL OR COALESCE(id.InstallmentAmount,0) = 0 THEN 0.0
            ELSE COALESCE(id.InstallmentAmount,0) * 1.0 / NULLIF(id.DurationInMonths, 0)
        END
) mp
OUTER APPLY (
    SELECT RawPassed =
        DATEDIFF(MONTH, id.InstallmentDate, CAST(GETDATE() AS date))
) rp
OUTER APPLY (
    SELECT PassedMonth =
        CASE
            WHEN rp.RawPassed < 0 THEN 0
            WHEN rp.RawPassed > COALESCE(id.DurationInMonths, 0) THEN COALESCE(id.DurationInMonths, 0)
            ELSE rp.RawPassed
        END
) pm
OUTER APPLY (

    SELECT PaidMonth =
        CASE
            WHEN mp.MonthlyPayment <= 0 THEN 0
            ELSE
                CASE
                    WHEN FLOOR(COALESCE(id.InstallmentPaid,0) * 1.0 / mp.MonthlyPayment) > COALESCE(id.DurationInMonths,0)
                        THEN COALESCE(id.DurationInMonths,0)
                    ELSE FLOOR(COALESCE(id.InstallmentPaid,0) * 1.0 / mp.MonthlyPayment)
                END
        END
) p2
OUTER APPLY (

    SELECT DueDate =
        CASE
            WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, p2.PaidMonth + 1, id.InstallmentDate)
        END
) dd
OUTER APPLY (
    SELECT OverDueDays =
        CASE
            WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) <= 0 OR dd.DueDate IS NULL THEN 0
            WHEN CAST(GETDATE() AS date) <= CAST(dd.DueDate AS date) THEN 0
            ELSE DATEDIFF(DAY, CAST(dd.DueDate AS date), CAST(GETDATE() AS date))
        END
) od;
