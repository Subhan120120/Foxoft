


SELECT   t2.number + 1 RepeatNumber
	, DcProducts.ProductDesc
	, DcProducts.WholesalePrice
	, DcProducts.RetailPrice
	, pb.*
FROM    TrProductBarcodes pb
JOIN DcProducts on DcProducts.ProductCode = pb.ProductCode
JOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty
