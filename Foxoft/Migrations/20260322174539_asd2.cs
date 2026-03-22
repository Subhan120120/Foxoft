using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
