using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addMigrat3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashRegisterCode",
                table: "TrInvoiceLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CashRegisterCode",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
