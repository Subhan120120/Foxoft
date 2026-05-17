using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asddfd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignCategories_DcCampaigns_CampaignId",
                table: "TrCampaignCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignCustomers_DcCampaigns_CampaignId",
                table: "TrCampaignCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignProducts_DcCampaigns_CampaignId",
                table: "TrCampaignProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignStores_DcCampaigns_CampaignId",
                table: "TrCampaignStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignWarehouses_DcCampaigns_CampaignId",
                table: "TrCampaignWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceCampaignLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignCategories_DcCampaigns_CampaignId",
                table: "TrCampaignCategories",
                column: "CampaignId",
                principalTable: "DcCampaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignCustomers_DcCampaigns_CampaignId",
                table: "TrCampaignCustomers",
                column: "CampaignId",
                principalTable: "DcCampaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignProducts_DcCampaigns_CampaignId",
                table: "TrCampaignProducts",
                column: "CampaignId",
                principalTable: "DcCampaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignStores_DcCampaigns_CampaignId",
                table: "TrCampaignStores",
                column: "CampaignId",
                principalTable: "DcCampaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignWarehouses_DcCampaigns_CampaignId",
                table: "TrCampaignWarehouses",
                column: "CampaignId",
                principalTable: "DcCampaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
