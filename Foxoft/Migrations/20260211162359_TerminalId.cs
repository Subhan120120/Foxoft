using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TerminalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterminalId",
                table: "TrPaymentHeaders");

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "TrPaymentHeaders",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CashRegisterCode",
                table: "DcTerminals",
                type: "nvarchar(30)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DcTerminals_CashRegisterCode",
                table: "DcTerminals",
                column: "CashRegisterCode");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DcTerminals_DcCurrAccs_CashRegisterCode",
            //    table: "DcTerminals",
            //    column: "CashRegisterCode",
            //    principalTable: "DcCurrAccs",
            //    principalColumn: "CurrAccCode",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.DropIndex(
                name: "IX_DcTerminals_CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.AddColumn<short>(
                name: "PosterminalId",
                table: "TrPaymentHeaders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 22,
                column: "ReportQuery",
                value: "SELECT\r\n      lt.LoyaltyTxnId\r\n    , lt.TxnType\r\n    , ih.DocumentNumber AS InvoiceDocumentNumber\r\n    , ph.DocumentNumber AS PaymentDocumentNumber\r\n    , Faiz       = ISNULL(inv.NetAmountLoc, 0) * lp.EarnPercent / 100\r\n    , NetAmountLoc= ISNULL(inv.NetAmountLoc, 0)\r\n    , Balance    = (ISNULL(inv.NetAmountLoc, 0) * lp.EarnPercent / 100) - ISNULL(pay.PaymentLoc, 0)\r\n    , PaymentLoc = ISNULL(pay.PaymentLoc, 0)\r\n    , lt.Note\r\n    , lt.InvoiceHeaderId\r\n    , lt.PaymentHeaderId\r\nFROM TrLoyaltyTxns lt\r\nJOIN DcLoyaltyCards lc\r\n    ON lc.LoyaltyCardId = lt.LoyaltyCardId\r\nJOIN DcLoyaltyPrograms lp\r\n    ON lp.LoyaltyProgramId = lc.LoyaltyProgramId\r\nLEFT JOIN TrInvoiceHeaders ih\r\n    ON ih.InvoiceHeaderId = lt.InvoiceHeaderId\r\nLEFT JOIN TrPaymentHeaders ph\r\n    ON ph.PaymentHeaderId = lt.PaymentHeaderId\r\n\r\nOUTER APPLY\r\n(\r\n    SELECT SUM(il.NetAmountLoc) AS NetAmountLoc\r\n    FROM TrInvoiceLines il\r\n    WHERE il.InvoiceHeaderId = lt.InvoiceHeaderId\r\n) inv\r\n\r\nOUTER APPLY\r\n(\r\n    SELECT SUM(pl.PaymentLoc) AS PaymentLoc\r\n    FROM TrPaymentLines pl\r\n    WHERE pl.PaymentHeaderId = lt.PaymentHeaderId\r\n    -- Əgər yalnız Bonus ödənişi toplamalıdırsa, aşağıdakı sətri aç:\r\n    -- AND pl.PaymentTypeCode = 3\r\n) pay;\r\n");
        }
    }
}
