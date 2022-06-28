using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class @float : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLines",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "float",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLines",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");
        }
    }
}
