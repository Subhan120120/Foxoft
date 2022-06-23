
   
--Declare @invoiceHeader nvarchar(50) = 'd07160d7-51fd-4623-bec8-bdb79207c923'
--Declare @exRate real = 1.703

select  InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, DcProducts.ProductCode
, ProductDescription
, QtyIn = QtyIn
, QtyOut = QtyOut
, Price
, CurrencyCode
, NetAmount
, LineDescription
, PriceLoc
, NetAmountLoc
, DocumentNumber
, DocumentDate
, DocumentTime
, DcCurrAccs.CurrAccCode
, FirstName
, PhoneNum
, CurrAccBalance = ((select Sum(NetAmount) from TrInvoiceLines il 
						join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId 
						where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode) 
						- (select isnull(Sum(Payment), 0)/ 1.703 from TrPaymentLines pl 
						join TrPaymentHeaders as ph on ph.PaymentHeaderId = pl.PaymentHeaderId 
						where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode))
, WarehouseCode
, TrInvoiceHeaders.StoreCode
from TrInvoiceLines

join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode

where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader

order by TrInvoiceLines.CreatedDate





