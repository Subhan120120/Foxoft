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
                CREATE OR ALTER FUNCTION [dbo].[GetProductCost]
                (
                    @ProductCode NVARCHAR(30),
                    @DocumentDatetime DATETIME = NULL
                )
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    DECLARE @Result DECIMAL(18, 2);
                    DECLARE @FilterDate DATE;
                    DECLARE @FilterTime TIME;
                
                    SET @FilterDate = CONVERT(DATE, @DocumentDatetime);
                    SET @FilterTime = CONVERT(TIME, @DocumentDatetime);
                
                    IF @DocumentDatetime IS NULL
                    BEGIN
                        SELECT
                            @Result = CONVERT
                            (
                                DECIMAL(18, 2),
                                AVG
                                (
                                    CONVERT
                                    (
                                        DECIMAL(38, 6),
                                        ISNULL(ilE.PriceDiscountedLoc, 0)
                                        + ISNULL(ilE.LineExpences, 0)
                                    )
                                )
                            )
                        FROM
                        (
                            SELECT TOP (1)
                                InvoiceHeaderId = il.InvoiceHeaderId
                            FROM dbo.TrInvoiceLines il
                            INNER JOIN dbo.TrInvoiceHeaders ih
                                ON ih.InvoiceHeaderId = il.InvoiceHeaderId
                            WHERE il.ProductCode = @ProductCode
                              AND ih.ProcessCode IN ('RP', 'CI')
                              AND ih.IsReturn = 0
                            ORDER BY
                                ih.DocumentDate DESC,
                                ih.DocumentTime DESC,
                                ih.InvoiceHeaderId DESC
                        ) LatestPurchase
                        INNER JOIN dbo.TrInvoiceLines il
                            ON il.InvoiceHeaderId = LatestPurchase.InvoiceHeaderId
                           AND il.ProductCode = @ProductCode
                        LEFT JOIN dbo.TrInvoiceLineExts ilE
                            ON ilE.InvoiceLineId = il.InvoiceLineId;
                    END
                    ELSE
                    BEGIN
                        SELECT
                            @Result = CONVERT
                            (
                                DECIMAL(18, 2),
                                AVG
                                (
                                    CONVERT
                                    (
                                        DECIMAL(38, 6),
                                        ISNULL(ilE.PriceDiscountedLoc, 0)
                                        + ISNULL(ilE.LineExpences, 0)
                                    )
                                )
                            )
                        FROM
                        (
                            SELECT TOP (1)
                                InvoiceHeaderId = il.InvoiceHeaderId
                            FROM dbo.TrInvoiceLines il
                            INNER JOIN dbo.TrInvoiceHeaders ih
                                ON ih.InvoiceHeaderId = il.InvoiceHeaderId
                            WHERE il.ProductCode = @ProductCode
                              AND ih.ProcessCode IN ('RP', 'CI')
                              AND ih.IsReturn = 0
                              AND
                              (
                                  ih.DocumentDate < @FilterDate
                                  OR
                                  (
                                      ih.DocumentDate = @FilterDate
                                      AND ih.DocumentTime < @FilterTime
                                  )
                              )
                            ORDER BY
                                ih.DocumentDate DESC,
                                ih.DocumentTime DESC,
                                ih.InvoiceHeaderId DESC
                        ) LatestPurchase
                        INNER JOIN dbo.TrInvoiceLines il
                            ON il.InvoiceHeaderId = LatestPurchase.InvoiceHeaderId
                           AND il.ProductCode = @ProductCode
                        LEFT JOIN dbo.TrInvoiceLineExts ilE
                            ON ilE.InvoiceLineId = il.InvoiceLineId;
                    END;
                
                    RETURN @Result;
                END;

                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
