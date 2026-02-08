


--delete from TrLoyaltyTxns

select * from TrLoyaltyTxns


SELECT
      lt.LoyaltyTxnId
    , lt.TxnType
    , InvoiceDocumentNumber = ISNULL(ih.DocumentNumber, ph.DocumentNumber)
    , NetAmountLoc= inv.NetAmountLoc
    , EarnAmount       = inv.NetAmountLoc * lp.EarnPercent / 100
    , PaymentLoc = PaymentLoc
    , Balance    = (ISNULL(inv.NetAmountLoc, 0) * lp.EarnPercent / 100) - ISNULL(PaymentLoc, 0)
    , lt.Note
    , lt.InvoiceHeaderId
    , lt.PaymentLineId
    , lt.LoyaltyCardId
    , lp.LoyaltyProgramId
    , lp.EarnPercent

FROM TrLoyaltyTxns lt
JOIN DcLoyaltyCards lc
    ON lc.LoyaltyCardId = lt.LoyaltyCardId
JOIN DcLoyaltyPrograms lp
    ON lp.LoyaltyProgramId = lc.LoyaltyProgramId
LEFT JOIN TrInvoiceHeaders ih
    ON ih.InvoiceHeaderId = lt.InvoiceHeaderId AND TxnType IN (1, 2)
LEFT JOIN TrPaymentLines pl
    ON pl.PaymentLineId = lt.PaymentLineId --and TxnType = 2
LEFT JOIN TrPaymentHeaders ph
    ON ph.PaymentHeaderId = pl.PaymentHeaderId

OUTER APPLY
(
    SELECT SUM(il.NetAmountLoc) AS NetAmountLoc
    FROM TrInvoiceLines il
    WHERE il.InvoiceHeaderId = lt.InvoiceHeaderId AND TxnType IN (1, 2)
) inv

