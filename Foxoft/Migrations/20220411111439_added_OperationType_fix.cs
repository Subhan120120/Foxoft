using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class added_OperationType_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "TrPaymentLines");

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "TrPaymentHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "TrPaymentHeaders");

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "TrPaymentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
