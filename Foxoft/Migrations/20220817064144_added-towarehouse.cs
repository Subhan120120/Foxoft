using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedtowarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "ToWarehouseCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "EX",
                column: "ProcessDesc",
                value: "Xərc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToWarehouseCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "EX",
                column: "ProcessDesc",
                value: "Xərclər");
        }
    }
}
