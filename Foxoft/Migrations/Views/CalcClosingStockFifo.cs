using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class CalcClosingStockFifo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW CalcClosingStockFifo AS
SELECT 
    TOP 1 WITH TIES *
    , closing_stock_sum = SUM(closing_stock) OVER (PARTITION BY ProductCode)
    , fifo_corg = SUM(closing_stock) OVER (PARTITION BY ProductCode) / NULLIF(cumulative, 0)
FROM 
(
    SELECT *,
           CASE 
               WHEN cumulative > 0 AND qty >= cumulative THEN cumulative * PriceLoc 
               WHEN cumulative > 0 AND qty < cumulative THEN qty * PriceLoc 
               ELSE 0 
           END AS closing_stock 
    FROM (
        SELECT *, 
               SUM(qty) OVER (PARTITION BY ProductCode ORDER BY srl) AS cumulative 
        FROM (
            SELECT 0 AS srl
                   , ProductCode
                   , 0 - QtyOut as qty
                   , PriceLoc 
                   --, DocumentDate
                   --, ProcessCode
            FROM TrInvoiceLines 
            LEFT JOIN TrInvoiceHeaders ON TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
            WHERE ProcessCode = 'RS' --and ProductCode = 'P-000484'
            UNION ALL
            SELECT ROW_NUMBER() OVER (PARTITION BY ProductCode ORDER BY DocumentDate) AS srl
                   , ProductCode
                   , QtyIn as qty
                   , PriceLoc
                   --, DocumentDate
                   --, ProcessCode
            FROM TrInvoiceLines 
            LEFT JOIN TrInvoiceHeaders ON TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
            WHERE (ProcessCode = 'RP' OR ProcessCode = 'CI')  --and ProductCode = 'P-000484'
        ) AS tab
    ) AS maintab
    --ORDER BY item_code, srl
) AS ne
ORDER BY ROW_NUMBER() OVER (PARTITION BY ne.ProductCode ORDER BY ProductCode, srl DESC);

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
