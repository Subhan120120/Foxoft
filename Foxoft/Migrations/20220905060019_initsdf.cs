using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class initsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "TrInvoiceHeaders");

            migrationBuilder.RenameColumn(
                name: "isDefaultCustomer",
                table: "DcCurrAccs",
                newName: "IsDefaultCustomer");

            migrationBuilder.AddColumn<byte>(
                name: "PrintCount",
                table: "TrInvoiceHeaders",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintCount",
                table: "TrInvoiceHeaders");

            migrationBuilder.RenameColumn(
                name: "IsDefaultCustomer",
                table: "DcCurrAccs",
                newName: "isDefaultCustomer");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "TrInvoiceHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }
    }
}
