using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class add_view_retailSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"CREATE VIEW [dbo].[RetailSales]
									AS
									
                                    select  TrInvoiceHeaders.InvoiceHeaderId
                                    , InvoiceLineId
                                    , TrInvoiceHeaders.StoreCode
                                    , DcStores.StoreDesc
                                    , DcWarehouses.WarehouseCode
                                    , WarehouseDesc
                                    , DcProcesses.ProcessCode
                                    , ProcessDescription
                                    , DocumentNumber
                                    , DocumentDate
                                    , DocumentTime
                                    , OperationDate
                                    , OperationTime
                                    , DcCurrAccs.CurrAccCode
                                    , DcCurrAccs.FirstName
                                    , DcCurrAccs.PhoneNum
                                    , CurrAccBalance = (select NetAmount from TrInvoiceLines il join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode)
                                    , DcProducts.ProductCode
                                    , ProductBalance = (select CASE WHEN IsReturn = 0 THEN SUM(QtyIn - QtyOut) ELSE SUM((QtyIn - QtyOut) * (-1)) END from TrInvoiceLines il where il.ProductCode = TrInvoiceLines.ProductCode)
                                    , ProductDescription
                                    , Qty = CASE WHEN IsReturn = 0 THEN QtyIn - QtyOut ELSE (QtyIn - QtyOut) * (-1) END
                                    , Price
                                    , TrInvoiceLines.PosDiscount
                                    , CurrencyCode
                                    , ExchangeRate
                                    , Amount
                                    , NetAmount
                                    , PriceLoc
                                    , AmountLoc
                                    , NetAmountLoc
                                    , SalesPersonCode
                                    , SalesPersonDesc = sp.FatherName
                                    , LineDescription
                                    , TrInvoiceLines.CreatedDate
                                    , TrInvoiceLines.CreatedUserName
                                    , TrInvoiceLines.LastUpdatedDate
                                    , TrInvoiceLines.LastUpdatedUserName
                                    , TrInvoiceLines.RelatedLineId
                                    from TrInvoiceLines
                                    
                                    join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
                                    left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
                                    left join DcCurrAccs sp on TrInvoiceLines.SalesPersonCode = sp.CurrAccCode
                                    left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
                                    left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
                                    left join DcStores on TrInvoiceHeaders.StoreCode = DcStores.StoreCode
                                    left join DcWarehouses on TrInvoiceHeaders.WarehouseCode = DcWarehouses.WarehouseCode
                                    
                                    where TrInvoiceHeaders.ProcessCode = 'RS'
                                    
                                                 
                                ";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP TABLE RetailSales";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
