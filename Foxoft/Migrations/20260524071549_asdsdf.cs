using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "KASSA01",
                column: "CashRegPaymentTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "\r\n\r\n	select CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Kassa Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, StoreCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 5 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	, StoreCode\r\n	order by CurrAccDesc");
        }
    }
}
