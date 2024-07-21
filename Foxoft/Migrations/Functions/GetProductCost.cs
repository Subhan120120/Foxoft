using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class GetProductCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                CREATE OR ALTER FUNCTION [dbo].[GetProductCost] (
                                    @productCode VARCHAR(50),    -- Assuming productCode is a string with a maximum length
                                    @documentDatetime DATETIME = NULL  -- Optional parameter, default value is NULL
                                )
                                RETURNS DECIMAL(18, 2)
                                AS
                                BEGIN
                                    DECLARE @result DECIMAL(18, 2);
                                
                                    SELECT @result = CAST(
                                        (
                                            SELECT TOP 1 AVG(ISNULL(PriceDiscounted, 0)) + SUM(ISNULL(LineExpences, 0))
                                            FROM TrInvoiceLines il
                                            JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = il.InvoiceHeaderId
                                            LEFT JOIN trInvoiceLineExts ilE ON ilE.InvoiceLineId = il.InvoiceLineId
                                            WHERE ih.ProcessCode IN ('RP', 'CI')
                                                AND ih.IsReturn = 0
                                                AND il.ProductCode = @productCode
                                                AND (@documentDatetime IS NULL OR (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME) < @documentDatetime))
                                            GROUP BY ih.ProcessCode, ih.IsReturn, ProductCode, DocumentDate
                                            ORDER BY DocumentDate DESC
                                        ) AS DECIMAL(18, 2)
                                    );
                                
                                    RETURN @result;
                                END;

                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
