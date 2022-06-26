using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasssa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<byte>(
                name: "FiscalPrintedState",
                table: "TrInvoiceHeaders",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<byte>(
                name: "FiscalPrintedState",
                table: "TrInvoiceHeaders",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "0");
        }
    }
}
