using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class paymenhedarer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentHeaders",
                type: "float",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentHeaders",
                type: "float",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 60,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");
        }
    }
}
