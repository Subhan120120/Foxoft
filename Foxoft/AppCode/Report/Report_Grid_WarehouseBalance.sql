

select DcProducts.ProductCode
	, DcProducts.ProductDesc
	, TrInvoiceHeaders.WarehouseCode
	, Balance = sum(QtyIn - QtyOut)
	, ProductCost = (select top 1 PriceLoc * (100 - PosDiscount)/100
					from TrInvoiceLines 
					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
					where TrInvoiceLines.ProductCode = DcProducts.ProductCode
					and (ProcessCode = 'RP' or ProcessCode = 'CI') 
					{StartDate}
					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc
					)
	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100
					from TrInvoiceLines 
					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
					where TrInvoiceLines.ProductCode = DcProducts.ProductCode
					and (ProcessCode = 'RP' or ProcessCode = 'CI') 
					{StartDate}
					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc
					)
from TrInvoiceLines
LEFT JOIN TrInvoiceHeaders 
	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
LEFT JOIN DcProducts 
	on DcProducts.ProductCode = TrInvoiceLines.ProductCode
where DcProducts.ProductTypeCode = 1 --and TrInvoiceHeaders.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'CI', 'CO', 'IT')

{StartDate}
Group by DcProducts.ProductCode
	, DcProducts.ProductDesc
	, TrInvoiceHeaders.WarehouseCode

