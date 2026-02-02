


select  lt.LoyaltyTxnId
, TxnType
, PaymentTypeCode
, ih.DocumentNumber
, ph.DocumentNumber
, Faiz = NetAmountLoc * EarnPercent / 100
, NetAmountLoc
, Balance = (NetAmountLoc * EarnPercent / 100) - ISNULL(PaymentLoc, 0)
, PaymentLoc

from TrLoyaltyTxns lt
join DcLoyaltyCards lc on lc.LoyaltyCardId = lt.LoyaltyCardId
join DcLoyaltyPrograms lp on lp.LoyaltyProgramId = lc.LoyaltyProgramId
left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = lt.InvoiceHeaderId
left join TrInvoiceLines il on il.InvoiceHeaderId = ih.InvoiceHeaderId
left join TrPaymentHeaders ph on ph.PaymentHeaderId = lt.PaymentHeaderId
left join TrPaymentLines pl on pl.PaymentHeaderId = ph.PaymentHeaderId