using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class WaybillMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines",
                column: "RelatedLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines",
                column: "RelatedLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines");
        }
    }
}
