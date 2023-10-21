







select Price
, ProductDesc
, CurrencyCode
, NetAmountLoc
, DocumentDate 
, LineDescription
, StoreCode
from TrInvoiceLines
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
where ProcessCode = 'EX'