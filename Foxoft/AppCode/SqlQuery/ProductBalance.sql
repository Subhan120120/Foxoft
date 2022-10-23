
declare @StartDate date = dateadd(DAY, 1, getdate())
declare @StartTime time =  '00:00:00.000'

select DcProducts.ProductCode
, DcProducts.ProductDesc
, SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0)) Balance 
--, LastPurchasePrice = ()
from DcProducts

left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode
left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId

where (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
	--and il.ProductCode = 'P-000063'

group by DcProducts.ProductCode
	, DcProducts.ProductDesc



