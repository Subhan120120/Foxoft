
  --Declare @StartDate Date = '2022-06-22' -- getdate() --
  --Declare @EndDate Date = '2022-06-22' -- getdate() --

SELECT ProcessCode
, ProcessDesc
, StoreCode
, Qty = sum(Qty)
, Amount = sum(Amount)
, PosDiscount = sum(PosDiscount)
, NetAmount = sum(NetAmount)
, IsReturn = IsReturn
--, Cash = sum(Cash)
--, Cashless = sum(Cashless)
, DocumentDate
--, TrInvoiceHeaders.InvoiceHeaderId
FROM Transactions

--left join 
--			(select InvoiceHeaderId
--			, Cash = sum(case when PaymentTypeCode = 1 then Payment else 0 end) / 1.703
--			, Cashless = sum(case when PaymentTypeCode = 2 then Payment else 0 end) / 1.703
--			from TrPaymentLines 
--			left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
--			where TrPaymentHeaders.OperationDate BETWEEN @StartDate AND @EndDate
--			group by InvoiceHeaderId
--			) as Payments on Payments.InvoiceHeaderId = Transactions.InvoiceHeaderId

WHERE DocumentDate BETWEEN @StartDate AND @EndDate AND ProcessCode != 'EX'
GROUP BY StoreCode
		, ProcessCode
		, ProcessDesc
		, IsReturn
		, DocumentDate
		--, InvoiceHeaderId
ORDER BY DocumentDate


