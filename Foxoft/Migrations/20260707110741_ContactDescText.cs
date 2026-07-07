using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ContactDescText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcContactType",
                columns: new[] { "Id", "ContactTypeDesc", "DefaultValue", "PhoneNumberFormat" },
                values: new object[] { (byte)5, "WhatsApp Qrupu", null, null });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "SELECT CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Kassa Adı] = CurrAccDesc\r\n    , CurrAccDesc\r\n    , Balance = ISNULL(SUM(CAST(PaymentLoc AS money)), 0)\r\n    , PhoneNum\r\n    , IsVIP\r\n    , CurrAccTypeCode\r\n    , StoreCode\r\nFROM DcCurrAccs\r\nLEFT JOIN TrPaymentLines \r\n    ON TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\r\n    AND TrPaymentLines.PaymentTypeCode IN (1, 2)\r\nWHERE \r\n    CurrAccTypeCode = 5\r\n    AND IsDisabled = 0\r\nGROUP BY \r\n     DcCurrAccs.CurrAccCode\r\n    , CashRegisterCode\r\n    , CurrAccDesc\r\n    , PhoneNum\r\n    , IsVIP\r\n    , CurrAccTypeCode\r\n    , StoreCode\r\n--ORDER BY CurrAccDesc;\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcContactType",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Kassa Adı] = CurrAccDesc\r\n    , CurrAccDesc\r\n    , Balance = ISNULL(SUM(CAST(PaymentLoc AS money)), 0)\r\n    , PhoneNum\r\n    , IsVIP\r\n    , CurrAccTypeCode\r\n    , StoreCode\r\nFROM DcCurrAccs\r\nLEFT JOIN TrPaymentLines \r\n    ON TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\r\n    AND TrPaymentLines.PaymentTypeCode IN (1, 2)\r\nWHERE \r\n    CurrAccTypeCode = 5\r\n    AND IsDisabled = 0\r\nGROUP BY \r\n     DcCurrAccs.CurrAccCode\r\n    , CashRegisterCode\r\n    , CurrAccDesc\r\n    , PhoneNum\r\n    , IsVIP\r\n    , CurrAccTypeCode\r\n    , StoreCode\r\n--ORDER BY CurrAccDesc;\r\n");
        }
    }
}
