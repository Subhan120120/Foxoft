

SELECT 
 Menfeet = Satis - Maya
, [Net Menfeet] = Satis - Maya - Xərc
, *
FROM  (
select  TrInvoiceLines.InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, TrInvoiceLines.ProductCode
, ProductDesc
, Price
, PriceLoc
, Amount
, NetAmountLoc
, TrInvoiceLines.PosDiscount
, QtyIn
, QtyOut
, Satis = case when TrInvoiceHeaders.ProcessCode = 'WS' then NetAmountLoc else 0 end
, Maya = CASE WHEN TrInvoiceHeaders.ProcessCode = 'WS' THEN (QtyOut - QtyIn) * COALESCE(ProductCost, 0) ELSE 0 END
, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end
, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end
, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end
, IsReturn
, ProductCost
--, SonQiymet = dbo.GetProductCost(TrInvoiceLines.ProductCode, CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))
, LineDescription
, SalesPersonCode
, CurrencyCode
, ExchangeRate
, TrInvoiceHeaders.ProcessCode
, ProcessDesc
, InvoiceNumber = DocumentNumber
--, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)
, DocumentDate
, DocumentTime
, OperationDate
, OperationTime
, Description
, TrInvoiceHeaders.CurrAccCode
, DcCurrAccs.CurrAccDesc
, DcCurrAccTypes.CurrAccTypeDesc
, DcCurrAccs.CurrAccTypeCode
, TrInvoiceHeaders.OfficeCode
, TrInvoiceHeaders.StoreCode
, WarehouseCode
, CustomsDocumentNumber
, PosTerminalId
, IsSuspended
, IsCompleted
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
, TrInvoiceLines.CreatedUserName
, TrInvoiceLineExts.PriceDiscountedLoc

from TrInvoiceLines 
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
left join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
left join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	

where TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'WS', 'EX')
--and DocumentNumber = 'RS-000012'
) Dvijok
order by Dvijok.DocumentDate








