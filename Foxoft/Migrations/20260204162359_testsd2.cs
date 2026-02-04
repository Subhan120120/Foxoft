using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class testsd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns",
                column: "InvoiceHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 22,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nselect  lt.LoyaltyTxnId\r\n, TxnType\r\n, PaymentTypeCode\r\n, ih.DocumentNumber\r\n, ph.DocumentNumber\r\n, Faiz = NetAmountLoc * EarnPercent / 100\r\n, NetAmountLoc\r\n, Balance = (NetAmountLoc * EarnPercent / 100) - ISNULL(PaymentLoc, 0)\r\n, PaymentLoc\r\n\r\nfrom TrLoyaltyTxns lt\r\njoin DcLoyaltyCards lc on lc.LoyaltyCardId = lt.LoyaltyCardId\r\njoin DcLoyaltyPrograms lp on lp.LoyaltyProgramId = lc.LoyaltyProgramId\r\nleft join TrInvoiceHeaders ih on ih.InvoiceHeaderId = lt.InvoiceHeaderId\r\nleft join TrInvoiceLines il on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\nleft join TrPaymentHeaders ph on ph.PaymentHeaderId = lt.PaymentHeaderId\r\nleft join TrPaymentLines pl on pl.PaymentHeaderId = ph.PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns",
                column: "InvoiceHeaderId",
                unique: true,
                filter: "[InvoiceHeaderId] IS NOT NULL");
        }
    }
}
