using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { 7, null, null, "", "Report_Embedded_StoreList", "\r\n\r\n	select CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Mağaza Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 4 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	order by CurrAccDesc", (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ConversionRate",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ConversionRate",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "ConversionRate",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "ConversionRate",
                value: 1m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ConversionRate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ConversionRate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "ConversionRate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "ConversionRate",
                value: 0m);
        }
    }
}
