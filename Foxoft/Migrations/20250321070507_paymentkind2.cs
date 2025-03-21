using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class paymentkind2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKind",
                table: "TrPaymentHeaders");

            migrationBuilder.RenameColumn(
                name: "PaymentKind",
                table: "TrPaymentHeaders",
                newName: "PaymentKindId");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentHeaders_PaymentKind",
                table: "TrPaymentHeaders",
                newName: "IX_TrPaymentHeaders_PaymentKindId");

            migrationBuilder.UpdateData(
                table: "DcPaymentKinds",
                keyColumn: "PaymentKindId",
                keyValue: (byte)1,
                column: "PaymentKindDesc",
                value: "Payment");

            migrationBuilder.UpdateData(
                table: "DcPaymentKinds",
                keyColumn: "PaymentKindId",
                keyValue: (byte)2,
                column: "PaymentKindDesc",
                value: "Invoice");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders",
                column: "PaymentKindId",
                principalTable: "DcPaymentKinds",
                principalColumn: "PaymentKindId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DeleteData(
                table: "DcPaymentKinds",
                keyColumn: "PaymentKindId",
                keyValue: (byte)0);

            migrationBuilder.RenameColumn(
                name: "PaymentKindId",
                table: "TrPaymentHeaders",
                newName: "PaymentKind");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentHeaders_PaymentKindId",
                table: "TrPaymentHeaders",
                newName: "IX_TrPaymentHeaders_PaymentKind");

            migrationBuilder.UpdateData(
                table: "DcPaymentKinds",
                keyColumn: "PaymentKindId",
                keyValue: (byte)1,
                column: "PaymentKindDesc",
                value: "Invoice");

            migrationBuilder.UpdateData(
                table: "DcPaymentKinds",
                keyColumn: "PaymentKindId",
                keyValue: (byte)2,
                column: "PaymentKindDesc",
                value: "Payment");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 12,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, OperationType\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKind",
                table: "TrPaymentHeaders",
                column: "PaymentKind",
                principalTable: "DcPaymentKinds",
                principalColumn: "PaymentKindId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
