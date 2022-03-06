using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "TrInvoiceLines");

            migrationBuilder.AddColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtyIn",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "QtyOut",
                table: "TrInvoiceLines");

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "TrInvoiceLines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "1");

        }
    }
}
