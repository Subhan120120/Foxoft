
select  TrInvoiceHeaders.InvoiceHeaderId
	, InvoiceLineId
	, DcOffices.OfficeCode
	, DcOffices.OfficeDesc
	, TrInvoiceHeaders.StoreCode
	, DcStores.CurrAccDesc
	, DcWarehouses.WarehouseCode
	, WarehouseDesc
	, DcProcesses.ProcessCode
	, ProcessDescription
	, DocumentNumber
	, IsReturn
	, DocumentDate
	, DocumentTime
	, OperationDate
	, OperationTime
	, DcCurrAccs.CurrAccCode
	, DcCurrAccs.FirstName
	, DcCurrAccs.PhoneNum
	, CurrAccBalance = ((select Sum(NetAmount) from TrInvoiceLines il 
						join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId 
						where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode) 
						- (select isnull(Sum(Payment), 0)/ 1.703 from TrPaymentLines pl 
						join TrPaymentHeaders as ph on ph.PaymentHeaderId = pl.PaymentHeaderId 
						where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode)), DcProducts.ProductCode
	, ProductDescription
	, ProductBalance = (select SUM(CASE WHEN ih.IsReturn = 0 THEN (QtyIn - QtyOut) ELSE (QtyIn - QtyOut) * (-1) END) ProductBalance
						from TrInvoiceLines il 
						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
						where il.ProductCode = TrInvoiceLines.ProductCode)
	, Qty = CASE WHEN IsReturn = 0 THEN QtyIn - QtyOut ELSE (QtyIn - QtyOut) * (-1) END
	, Price
	, TrInvoiceLines.PosDiscount
	, CurrencyCode
	, ExchangeRate
	, Amount = CASE WHEN IsReturn = 0 THEN (QtyIn - QtyOut) * Price ELSE ((QtyIn - QtyOut) * Price) * (-1) END
	, NetAmount = CASE WHEN IsReturn = 0 THEN (QtyIn - QtyOut) * Price ELSE ((QtyIn - QtyOut) * Price) * (-1) END
	, PriceLoc 
	, AmountLoc = CASE WHEN IsReturn = 0 THEN (QtyIn - QtyOut) * PriceLoc ELSE ((QtyIn - QtyOut) * PriceLoc) * (-1) END
	, NetAmountLoc = CASE WHEN IsReturn = 0 THEN (QtyIn - QtyOut) * PriceLoc ELSE ((QtyIn - QtyOut) * PriceLoc) * (-1) END
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
left join DcCurrAccs DcStores on TrInvoiceHeaders.StoreCode = DcStores.StoreCode
left join DcWarehouses on TrInvoiceHeaders.WarehouseCode = DcWarehouses.WarehouseCode
left join DcOffices on TrInvoiceHeaders.OfficeCode = DcOffices.OfficeCode
