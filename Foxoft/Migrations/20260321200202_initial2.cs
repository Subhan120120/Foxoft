using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders");

            migrationBuilder.AddColumn<string>(
                name: "DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses",
                column: "DcWarehouseWarehouseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCampaignWarehouses_DcWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses",
                column: "DcWarehouseWarehouseCode",
                principalTable: "DcWarehouses",
                principalColumn: "WarehouseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignWarehouses_DcWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrCampaignWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CampaignList");

            migrationBuilder.DropColumn(
                name: "DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
