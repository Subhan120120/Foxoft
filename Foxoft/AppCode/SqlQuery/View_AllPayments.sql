






select 
*
from TrPaymentLines
join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
where OperationType = 'invoice'