using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class test45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
