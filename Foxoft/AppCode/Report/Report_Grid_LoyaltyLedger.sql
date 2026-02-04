SELECT
      lt.LoyaltyTxnId
    , lt.TxnType
    , ih.DocumentNumber AS InvoiceDocumentNumber
    , ph.DocumentNumber AS PaymentDocumentNumber
    , Faiz       = ISNULL(inv.NetAmountLoc, 0) * lp.EarnPercent / 100
    , NetAmountLoc= ISNULL(inv.NetAmountLoc, 0)
    , Balance    = (ISNULL(inv.NetAmountLoc, 0) * lp.EarnPercent / 100) - ISNULL(pay.PaymentLoc, 0)
    , PaymentLoc = ISNULL(pay.PaymentLoc, 0)
    , lt.Note
    , lt.InvoiceHeaderId
    , lt.PaymentHeaderId
FROM TrLoyaltyTxns lt
JOIN DcLoyaltyCards lc
    ON lc.LoyaltyCardId = lt.LoyaltyCardId
JOIN DcLoyaltyPrograms lp
    ON lp.LoyaltyProgramId = lc.LoyaltyProgramId
LEFT JOIN TrInvoiceHeaders ih
    ON ih.InvoiceHeaderId = lt.InvoiceHeaderId
LEFT JOIN TrPaymentHeaders ph
    ON ph.PaymentHeaderId = lt.PaymentHeaderId

OUTER APPLY
(
    SELECT SUM(il.NetAmountLoc) AS NetAmountLoc
    FROM TrInvoiceLines il
    WHERE il.InvoiceHeaderId = lt.InvoiceHeaderId
) inv

OUTER APPLY
(
    SELECT SUM(pl.PaymentLoc) AS PaymentLoc
    FROM TrPaymentLines pl
    WHERE pl.PaymentHeaderId = lt.PaymentHeaderId
    -- Əgər yalnız Bonus ödənişi toplamalıdırsa, aşağıdakı sətri aç:
    -- AND pl.PaymentTypeCode = 3
) pay;
