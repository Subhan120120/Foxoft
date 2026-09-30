
select  TrInvoiceHeaders.InvoiceHeaderId
	, InvoiceLineId
	, TrInvoiceHeaders.StoreCode
	, DcOffices.OfficeCode
	, DcOffices.OfficeDesc
	, StoreDesc = DcStores.CurrAccDesc
	, DcWarehouses.WarehouseCode
	, WarehouseDesc
	, DcProcesses.ProcessCode
	, ProcessDesc
	, DocumentNumber
	, IsReturn
	, DocumentDate
	, DocumentTime
	, OperationDate
	, OperationTime
	, DcCurrAccs.CurrAccCode
	, DcCurrAccs.CurrAccDesc
	, DcCurrAccs.FirstName
	, DcCurrAccs.PhoneNum
	, CurrAccBalance = ((select isnull(Sum(NetAmount), 0) from TrInvoiceLines il 
						join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId 
						where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode) 
						+ (select isnull(Sum(case 
								when prl.PayrollItemType in (1, 2, 3) then prl.AmountLoc 
								when prl.PayrollItemType in (4, 5, 6) then -prl.AmountLoc 
								else 0 end), 0) 
							from TrPayrollLines prl
							inner join TrPayrollHeaders prh on prl.PayrollHeaderId = prh.Id
							where prh.CurrAccCode = TrInvoiceHeaders.CurrAccCode)
						- (select isnull(Sum(PaymentLoc), 0) from TrPaymentLines pl 
						join TrPaymentHeaders as ph on ph.PaymentHeaderId = pl.PaymentHeaderId 
						where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode))
	, DcProducts.ProductCode
	, ProductDesc
	, ProductBalance = (select SUM(QtyIn - QtyOut) ProductBalance
						from TrInvoiceLines il 
						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
						where il.ProductCode = TrInvoiceLines.ProductCode
						and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT'))
	, Qty = QtyIn - QtyOut
	, Price
	, TrInvoiceLines.PosDiscount
	, CurrencyCode
	, ExchangeRate
	, Amount 
	, NetAmount 
	, PriceLoc 
	, AmountLoc 
	, NetAmountLoc
	, SalesPersonCode
	, SalesPersonDesc = sp.FirstName
	, LineDescription
	, TrInvoiceLines.CreatedDate
	, TrInvoiceLines.CreatedUserName
	, TrInvoiceLines.LastUpdatedDate
	, TrInvoiceLines.LastUpdatedUserName
	, TrInvoiceLines.RelatedLineId
from TrInvoiceLines

join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccs sp on TrInvoiceLines.SalesPersonCode = sp.CurrAccCode
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
left join DcCurrAccs DcStores on TrInvoiceHeaders.StoreCode = DcStores.CurrAccCode and DcStores.CurrAccTypeCode = 4
left join DcWarehouses on TrInvoiceHeaders.WarehouseCode = DcWarehouses.WarehouseCode
left join DcOffices on TrInvoiceHeaders.OfficeCode = DcOffices.OfficeCode

