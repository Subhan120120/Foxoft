using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class loyaltyServis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_LoyaltyCardId",
                table: "TrInvoiceHeaders",
                column: "LoyaltyCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcLoyaltyCards_LoyaltyCardId",
                table: "TrInvoiceHeaders",
                column: "LoyaltyCardId",
                principalTable: "DcLoyaltyCards",
                principalColumn: "LoyaltyCardId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcLoyaltyCards_LoyaltyCardId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_LoyaltyCardId",
                table: "TrInvoiceHeaders");
        }
    }
}
