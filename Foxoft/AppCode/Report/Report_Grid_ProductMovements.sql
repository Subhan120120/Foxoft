




select  InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, TrInvoiceLines.ProductCode
, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') 
		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') 
		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') 
		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')
		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') 
		  + isnull(' ' + Feature29,'') 


, ProductDesc
, QtyIn
, QtyOut
, Price
, PriceLoc
, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))
, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))
, Amount
, NetAmountLoc
, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines 
		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId
		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)
, LineDescription
, SalesPersonCode
, CurrencyCode
, ExchangeRate
, TrInvoiceHeaders.ProcessCode
, ProcessDesc
, DocumentNumber
, IsReturn
, ProductCost
, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)
, DocumentDate
, DocumentTime
, OperationDate
, OperationTime
, Description
, TrInvoiceLines.PosDiscount
, TrInvoiceHeaders.CurrAccCode
, DcCurrAccs .CurrAccDesc
, DcCurrAccTypes.CurrAccTypeDesc
, DcCurrAccs.CurrAccTypeCode
, TrInvoiceHeaders.OfficeCode
, TrInvoiceHeaders.StoreCode
, WarehouseCode
, CustomsDocumentNumber
, PosTerminalId
, IsSuspended
, IsCompleted
, PrintCount
, IsSalesViaInternet
, IsLocked
, DcProducts.ProductTypeCode
, ProductTypeDesc
, UsePos
, PromotionCode
, TaxRate
, RetailPrice
, PurchasePrice
, WholesalePrice
, TrInvoiceLines.CreatedDate
, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il 
					left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId
					where il.ProductCode = TrInvoiceLines.ProductCode
					and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'CI', 'CO', 'IT'))
, TrInvoiceHeaders.CreatedUserName
, ImagePath
--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  

from TrInvoiceLines 
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
left join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
left join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode
left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode


order by DocumentDate, DocumentTime


