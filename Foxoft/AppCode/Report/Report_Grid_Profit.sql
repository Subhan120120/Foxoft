


SELECT Maya = (-1)*(case when Dvijok.ProcessCode in ('RS', 'WS') then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0) else 0 end)
, Menfeet = (-1)*(case when ProcessCode in ('RS', 'WS') then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end)
, [Net Menfeet] = (-1)*(case when ProcessCode in ('RS', 'WS') then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end) - Xərc
, *
FROM (
select  InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, TrInvoiceLines.ProductCode
, ProductDesc
, Qty = (QtyIn-QtyOut)*(-1)
, Price
, PriceLoc
, Amount
, TrInvoiceLines.PosDiscount
, QtyIn
, QtyOut
, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end
, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode in ('RS', 'WS') then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)
, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end
, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end
, ProductCost
, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  
					from TrInvoiceLines il
					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId
					where il.ProductCode = TrInvoiceLines.ProductCode
					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')
					and ih.IsReturn = 0
					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))
					ORDER BY ih.DocumentDate desc
					, il.CreatedDate desc )	

, LineDescription
, SalesPersonCode
, CurrencyCode
, ExchangeRate
, TrInvoiceHeaders.ProcessCode
, ProcessDesc
, InvoiceNumber = DocumentNumber
, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)
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

from TrInvoiceLines 
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
left join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
left join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	

where TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'WS', 'EX')
--and DocumentNumber = 'RS-000012'
) Dvijok
order by Dvijok.DocumentDate







