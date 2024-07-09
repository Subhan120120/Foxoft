using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class HasComputedColumnSql_GetProductCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "ProductCost",
            //    table: "TrInvoiceLines",
            //    type: "decimal(18,2)",
            //    nullable: true,
            //    computedColumnSql: "[dbo].[GetProductCost]([ProductCode])",
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)",
            //    oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductCost",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComputedColumnSql: "[dbo].[GetProductCost]([ProductCode])");
        }
    }
}
