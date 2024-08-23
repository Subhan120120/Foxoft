using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AlterView_ProductBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
									CREATE OR ALTER TRIGGER [dbo].[CreateView_ProductBalance]
									ON [dbo].[DcWarehouses]
									AFTER INSERT, UPDATE, DELETE
									AS
									BEGIN
										DECLARE  @colsPivot AS NVARCHAR(MAX), @SQL AS NVARCHAR(MAX);
									
										SELECT @colsPivot = COALESCE(@colsPivot + ', ', '') + QUOTENAME(WarehouseCode) FROM DcWarehouses
									
									    SET @SQL = N'
										CREATE OR ALTER VIEW ProductBalance
										AS 
									
										select * from (
											select ProductCode
												, WarehouseCode
												, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
											from TrInvoiceLines il
											left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
											where ih.ProcessCode in (''RP'', ''WP'', ''RS'', ''WS'', ''CI'', ''CO'', ''IT'' )
											group by ProductCode
												, WarehouseCode
										) AS SourceTable  
										PIVOT  
										( AVG(Balance)
										  FOR WarehouseCode IN (' + @colsPivot  + ') 
										) AS PivotTable ';
									    
									    EXEC sp_executesql @SQL;
									END;
									
									");

            migrationBuilder.Sql(@"
									CREATE OR ALTER TRIGGER [dbo].[CreateView_ProductBalanceSerialNumber]
									ON [dbo].[DcWarehouses]
									AFTER INSERT, UPDATE, DELETE
									AS
									BEGIN
										DECLARE  @colsPivot AS NVARCHAR(MAX), @SQL AS NVARCHAR(MAX);
									
										SELECT @colsPivot = COALESCE(@colsPivot + ', ', '') + QUOTENAME(WarehouseCode) FROM DcWarehouses
									
									    SET @SQL = N'
										CREATE OR ALTER VIEW ProductBalanceSerialNumber
										AS 
									
										select * from (
											select ProductCode
												, WarehouseCode
												, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
                                                , SerialNumberCode
											from TrInvoiceLines il
											left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
											where ih.ProcessCode in (''RP'', ''WP'', ''RS'', ''WS'', ''CI'', ''CO'', ''IT'' )
											group by ProductCode
												, WarehouseCode
                                                , SerialNumberCode
										) AS SourceTable  
										PIVOT  
										( AVG(Balance)
										  FOR WarehouseCode IN (' + @colsPivot  + ') 
										) AS PivotTable ';
									    
									    EXEC sp_executesql @SQL;
									END;
									
									");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
