select sum(borc) 

from 

(
select * from (select DcCurrAccs.CurrAccCode
	, DcCurrAccs.FirstName
	, DcCurrAccs.CurrAccDesc
	, NetAmountRS = sales.NetAmountLoc
	, NetAmountRP= parchses.NetAmountLoc
	, NetAmountPR = payroll.NetAmountLoc
	, NetAmountLoc = ISNULL(ISNULL(sales.NetAmountLoc, 0) + ISNULL(parchses.NetAmountLoc, 0) + ISNULL(payroll.NetAmountLoc, 0), 0)
	, PaymentLoc = ISNULL(PaymentLoc, 0)
	, borclu =  (case when ISNULL(sales.NetAmountLoc, 0) + ISNULL(parchses.NetAmountLoc, 0) + ISNULL(payroll.NetAmountLoc, 0) + ISNULL(PaymentLoc, 0) > 0 then 1
					when ISNULL(sales.NetAmountLoc, 0) + ISNULL(parchses.NetAmountLoc, 0) + ISNULL(payroll.NetAmountLoc, 0) + ISNULL(PaymentLoc, 0) < 0 then 2 else 0 end )
	, borc = ISNULL(sales.NetAmountLoc, 0) + ISNULL(parchses.NetAmountLoc, 0) + ISNULL(payroll.NetAmountLoc, 0) + ISNULL(PaymentLoc, 0)
	from DcCurrAccs
	
	left join (select CurrAccCode 
			   ,NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100)) 
			   from TrInvoiceLines il
			   left join TrInvoiceHeaders as ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
			   where ih.ProcessCode = 'RS'
			   group by CurrAccCode
			   ) as sales on sales.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select CurrAccCode 
			   ,NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))
			   from TrInvoiceLines il
			   left join TrInvoiceHeaders as ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
			   where ih.ProcessCode = 'RP'
			   group by CurrAccCode
			   ) as parchses on parchses.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select prh.CurrAccCode 
			   ,NetAmountLoc = sum(case 
					when prl.PayrollItemType in (1, 2, 3) then prl.AmountLoc 
					when prl.PayrollItemType in (4, 5, 6) then -prl.AmountLoc 
					else 0 end)
			   from TrPayrollLines prl
			   inner join TrPayrollHeaders prh on prl.PayrollHeaderId = prh.Id
			   group by prh.CurrAccCode
			   ) as payroll on payroll.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select CurrAccCode
			  , PaymentLoc = sum(PaymentLoc)
			  from TrPaymentHeaders
			  left join TrPaymentLines on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId
			  group by CurrAccCode
			  ) as payment on payment.CurrAccCode = DcCurrAccs.CurrAccCode
	where CurrAccTypeCode in (1, 2, 3)
	) as invoice
where invoice.borclu <> 0
) asdmksf
