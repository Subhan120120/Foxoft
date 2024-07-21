using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcSerialNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumberCode",
                table: "TrInvoiceLines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcSerialNumbers",
                columns: table => new
                {
                    SerialNumberCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSerialNumbers", x => x.SerialNumberCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_SerialNumberCode",
                table: "TrInvoiceLines",
                column: "SerialNumberCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcSerialNumbers_SerialNumberCode",
                table: "TrInvoiceLines",
                column: "SerialNumberCode",
                principalTable: "DcSerialNumbers",
                principalColumn: "SerialNumberCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcSerialNumbers_SerialNumberCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "DcSerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_SerialNumberCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "SerialNumberCode",
                table: "TrInvoiceLines");
        }
    }
}
