using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class paymentDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "float",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "float",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");
        }
    }
}
