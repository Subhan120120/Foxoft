using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261107213000_ChangeSalesBonusTxnInvoiceHeaderCascadeDelete")]
    public partial class ChangeSalesBonusTxnInvoiceHeaderCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrSalesBonusTxns_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrSalesBonusTxns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrSalesBonusTxns_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrSalesBonusTxns",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrSalesBonusTxns_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrSalesBonusTxns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrSalesBonusTxns_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrSalesBonusTxns",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
