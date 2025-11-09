using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class yenilik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrinterCopyNum",
                table: "AppSettings",
                newName: "PrintCount");

            migrationBuilder.RenameColumn(
                name: "GetPrint",
                table: "AppSettings",
                newName: "AutoPrint");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrintCount",
                table: "AppSettings",
                newName: "PrinterCopyNum");

            migrationBuilder.RenameColumn(
                name: "AutoPrint",
                table: "AppSettings",
                newName: "GetPrint");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "ReportQuery",
                value: "\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where 1=1 AND pl.PaymentTypeCode != 5\r\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc");
        }
    }
}
