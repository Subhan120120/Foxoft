



select DcCurrAccs.CurrAccCode
, CurrAccDesc
, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)
, PhoneNum
, IsVIP
, CurrAccTypeCode
from 
DcCurrAccs 
left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode
where CurrAccTypeCode = 5 and IsDisabled = 0 and PaymentTypeCode = 1 
	--and DcCurrAccs.IsVIP = 1 
	--and balance.CurrAccCode = '1403'
group by DcCurrAccs.CurrAccCode
, CurrAccDesc
, PhoneNum
, IsVIP
, CurrAccTypeCode
order by CurrAccDesc






