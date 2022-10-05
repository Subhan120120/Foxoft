using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrPrices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceLoc",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "WholesalePrice",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "RetailPrice",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0m, 4.5m, 0m });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0m, 2.5m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrPrices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PriceLoc",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "WholesalePrice",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "RetailPrice",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0.0, 4.5, 0.0 });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                columns: new[] { "PurchasePrice", "RetailPrice", "WholesalePrice" },
                values: new object[] { 0.0, 2.5, 0.0 });
        }
    }
}
