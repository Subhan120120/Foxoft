
   
--Declare @invoiceHeader nvarchar(50) = '9cee94d8-b308-4f75-bc43-2dac5d59f04e'


select  InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, DcProducts.ProductCode
, ProductDescription
, Qty = QtyIn - QtyOut
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
, CurrAccBalance = (select NetAmount from TrInvoiceLines il join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode)
, WarehouseCode
, TrInvoiceHeaders.StoreCode
from TrInvoiceLines

join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode

where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader

order by TrInvoiceLines.CreatedDate










