using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ProductBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW ProductBalance
                AS 
                									
                select * from (
                				select ProductCode
                								, WarehouseCode
                								, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
                				from TrInvoiceLines il
                				left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
							    where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )
                				group by ProductCode
                								, WarehouseCode
                ) AS SourceTable  
                PIVOT  
                ( AVG(Balance)
                  FOR WarehouseCode IN ([depo-01]) 
                ) AS PivotTable"
                );

            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW ProductBalanceSerialNumber
                AS 
                									
                select * from (
                				select ProductCode
                								, WarehouseCode
                								, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
                                                , SerialNumberCode
                				from TrInvoiceLines il
                				left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
                                where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )
                				group by ProductCode
                								, WarehouseCode
                                                , SerialNumberCode
                ) AS SourceTable  
                PIVOT  
                ( AVG(Balance)
                  FOR WarehouseCode IN ([depo-01]) 
                ) AS PivotTable"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
