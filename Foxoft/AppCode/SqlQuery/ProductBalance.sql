select DcProducts.ProductCode , SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0)) Balance from DcProducts
left join TrInvoiceLines on TrInvoiceLines.ProductCode = DcProducts.ProductCode
group by DcProducts.ProductCode
