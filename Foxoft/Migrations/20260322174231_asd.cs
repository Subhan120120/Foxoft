using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCampaignWarehouses_DcWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceCampaignLogs");

            migrationBuilder.DropIndex(
                name: "IX_TrCampaignWarehouses_DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            migrationBuilder.DropColumn(
                name: "DcWarehouseWarehouseCode",
                table: "TrCampaignWarehouses");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
            //    table: "TrInvoiceCampaignLogs",
            //    column: "InvoiceLineId",
            //    principalTable: "TrInvoiceLines",
            //    principalColumn: "InvoiceLineId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceCampaignLogs");

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
                name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
