using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class trInvoiceLineDefaultValueEfCore6part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");
        }
    }
}
