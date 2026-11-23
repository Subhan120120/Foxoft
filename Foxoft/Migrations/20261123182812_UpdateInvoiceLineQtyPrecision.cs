using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceLineQtyPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrBarcodeOperationLines",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrBarcodeOperationLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 1m);
        }
    }
}
