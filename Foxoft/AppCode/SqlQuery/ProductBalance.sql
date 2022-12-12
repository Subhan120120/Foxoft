

declare @StartDate date = dateadd(DAY, 1, getdate())
declare @StartTime time =  '00:00:00.000'
select 
*
, Balance = isnull([depo-01],0) + isnull([depo-02],0) + isnull([depo-03],0)
from (
	select DcProducts.ProductCode
	, DcProducts.ProductDesc
	, WarehouseCode
	, LastPurchasePrice = (select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  
								from TrInvoiceLines 
								join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
								where TrInvoiceLines.ProductCode = DcProducts.ProductCode
								and (TrInvoiceHeaders.ProcessCode = 'RP' or TrInvoiceHeaders.ProcessCode = 'CI')
								and TrInvoiceHeaders.IsReturn = 0
								ORDER BY TrInvoiceHeaders.DocumentDate desc
											, TrInvoiceLines.CreatedDate desc
								)											 

	, SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0)) Balance 
	--, LastPurchasePrice = ()
	from DcProducts
	
	left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode
	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
	
	where (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
		(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
		--and il.ProductCode = '5503'
	
	group by DcProducts.ProductCode
		, DcProducts.ProductDesc
		, WarehouseCode
) AS SourceTable  
PIVOT  
(  
 AVG(Balance)
  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  
) AS PivotTable;  



