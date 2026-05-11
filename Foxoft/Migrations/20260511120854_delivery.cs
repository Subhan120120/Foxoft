using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "TrInvoiceHeaders",
                type: "date",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrWhatsAppMessageLogs_CurrAccCode",
                table: "TrWhatsAppMessageLogs",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrWhatsAppMessageLogs_Sender",
                table: "TrWhatsAppMessageLogs",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_CurrAccCode",
                table: "TrWhatsAppMessageLogs",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_Sender",
                table: "TrWhatsAppMessageLogs",
                column: "Sender",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_CurrAccCode",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_Sender",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_TrWhatsAppMessageLogs_CurrAccCode",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_TrWhatsAppMessageLogs_Sender",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "TrInvoiceHeaders");
        }
    }
}
