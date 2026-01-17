
SELECT   t2.number + 1 RepeatNumber
	, DcProducts.ProductDesc
	, DcProducts.WholesalePrice
	, DcProducts.RetailPrice
	, TrBarcodeOperationLines.*
FROM TrBarcodeOperationLines
JOIN DcProducts on DcProducts.ProductCode = TrBarcodeOperationLines.ProductCode
JOIN TrBarcodeOperationHeaders on TrBarcodeOperationHeaders.Id = TrBarcodeOperationLines.BarcodeOperationHeaderId
JOIN master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < TrBarcodeOperationLines.Qty
