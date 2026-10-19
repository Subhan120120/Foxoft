SELECT 
    GrossProfit = Sales - Cost                  -- Ümumi Mənfəət
  , NetProfit   = Sales - Cost - Expense        -- Xalis Mənfəət
  , *
FROM (
    SELECT  
        TrInvoiceLines.InvoiceLineId
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
      , Sales     = CASE WHEN TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') THEN NetAmountLoc ELSE 0 END
      , Cost      = CASE WHEN TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') THEN (QtyOut - QtyIn) * COALESCE(ProductCost, 0) ELSE 0 END
      , Expense   = CASE WHEN TrInvoiceHeaders.ProcessCode = 'EX' THEN NetAmountLoc ELSE 0 END
      , Increase  = CASE WHEN TrInvoiceHeaders.ProcessCode = 'CI' THEN NetAmountLoc ELSE 0 END
      , WriteOff  = CASE WHEN TrInvoiceHeaders.ProcessCode = 'CO' THEN NetAmountLoc ELSE 0 END
      , IsReturn
      , ProductCost
      , LineDescription
      , SalesPersonCode
      , CurrencyCode
      , ExchangeRate
      , TrInvoiceHeaders.ProcessCode
      , ProcessDesc
      , InvoiceNumber = DocumentNumber
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
    FROM TrInvoiceLines 
    LEFT JOIN TrInvoiceHeaders ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
    LEFT JOIN TrInvoiceLineExts ON TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId
    LEFT JOIN DcProducts ON TrInvoiceLines.ProductCode = DcProducts.ProductCode
    LEFT JOIN DcProductTypes ON DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode
    LEFT JOIN DcCurrAccs ON TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
    LEFT JOIN DcCurrAccTypes ON DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
    LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
    LEFT JOIN DcCurrAccs AS SalesPerson ON TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode    
    WHERE TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'WS', 'RS', 'IS', 'EX')

    UNION ALL

    SELECT 
        InvoiceLineId      = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
      , InvoiceHeaderId    = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
      , ProductCode        = ''
      , ProductDesc        = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)
      , Price              = Calc.GrossSalary
      , PriceLoc           = Calc.GrossSalary
      , Amount             = Calc.GrossSalary
      , NetAmountLoc       = Calc.GrossSalary
      , PosDiscount        = CAST(0 AS DECIMAL(18, 2))
      , QtyIn              = CAST(0 AS DECIMAL(18, 4))
      , QtyOut             = CAST(0 AS DECIMAL(18, 4))
      , Sales              = CAST(0 AS DECIMAL(18, 2))
      , Cost               = CAST(0 AS DECIMAL(18, 2))
      , Expense            = Calc.GrossSalary
      , Increase           = CAST(0 AS DECIMAL(18, 2))
      , WriteOff           = CAST(0 AS DECIMAL(18, 2))
      , IsReturn           = CAST(0 AS BIT)
      , ProductCost        = CAST(0 AS DECIMAL(18, 2))
      , LineDescription    = CONCAT(Prp.PeriodYear, ' / ', RIGHT('0' + CAST(Prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')
      , SalesPersonCode    = ''
      , CurrencyCode       = 'AZN'
      , ExchangeRate       = CAST(1 AS DECIMAL(18, 4))
      , ProcessCode        = 'PR'
      , ProcessDesc        = N'Əməkhaqqı'
      , InvoiceNumber      = CONCAT('PR-', Prp.PeriodYear, '-', RIGHT('0' + CAST(Prp.PeriodMonth AS VARCHAR(2)), 2))
      , DocumentDate       = EOMONTH(DATEFROMPARTS(Prp.PeriodYear, Prp.PeriodMonth, 1))
      , DocumentTime       = CAST('23:59:59' AS TIME)
      , OperationDate      = EOMONTH(DATEFROMPARTS(Prp.PeriodYear, Prp.PeriodMonth, 1))
      , OperationTime      = CAST('23:59:59' AS TIME)
      , Description        = CONCAT(Prp.PeriodYear, ' / ', RIGHT('0' + CAST(Prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı')
      , CurrAccCode        = Prh.CurrAccCode
      , CurrAccDesc        = DcCurrAccs.CurrAccDesc
      , CurrAccTypeDesc    = DcCurrAccTypes.CurrAccTypeDesc
      , CurrAccTypeCode    = DcCurrAccs.CurrAccTypeCode
      , OfficeCode         = ''
      , StoreCode          = DcCurrAccs.StoreCode
      , WarehouseCode      = ''
      , CustomsDocumentNumber = ''
      , IsSuspended        = CAST(0 AS BIT)
      , IsCompleted        = CAST(1 AS BIT)
      , IsSalesViaInternet = CAST(0 AS BIT)
      , IsLocked           = Prp.IsClosed
      , ProductTypeCode    = CAST(NULL AS INT)
      , ProductTypeDesc    = ''
      , UsePos             = CAST(0 AS BIT)
      , PromotionCode      = ''
      , TaxRate            = CAST(0 AS DECIMAL(18, 2))
      , RetailPrice        = CAST(0 AS DECIMAL(18, 2))
      , PurchasePrice      = CAST(0 AS DECIMAL(18, 2))
      , WholesalePrice     = CAST(0 AS DECIMAL(18, 2))
      , CreatedDate        = CAST(NULL AS DATETIME)
      , CreatedUserName    = ''
      , PriceDiscountedLoc = CAST(0 AS DECIMAL(18, 2))
    FROM TrPayrollHeaders Prh
    CROSS APPLY (
        SELECT GrossSalary = ISNULL(SUM(L.AmountLoc), 0)
        FROM TrPayrollLines L
        WHERE L.PayrollHeaderId = Prh.Id
          AND L.PayrollItemType IN (1, 2, 3)
    ) Calc
    LEFT JOIN DcPayrollPeriods Prp ON Prh.PayrollPeriodId = Prp.Id
    LEFT JOIN DcCurrAccs ON Prh.CurrAccCode = DcCurrAccs.CurrAccCode
    LEFT JOIN DcCurrAccTypes ON DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
) MovementQuery
ORDER BY MovementQuery.DocumentDate;