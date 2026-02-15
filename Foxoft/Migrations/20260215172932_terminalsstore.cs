using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class terminalsstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "StoreCode",
                table: "DcTerminals",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                column: "StoreCode",
                value: "MGZ01");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                column: "StoreCode",
                value: "MGZ01");

            migrationBuilder.CreateIndex(
                name: "IX_DcTerminals_StoreCode",
                table: "DcTerminals",
                column: "StoreCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_StoreCode",
                table: "DcTerminals",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_StoreCode",
                table: "DcTerminals");

            migrationBuilder.DropIndex(
                name: "IX_DcTerminals_StoreCode",
                table: "DcTerminals");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "TerminalList");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "KASSA01");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "MGZ01");

            migrationBuilder.DropColumn(
                name: "StoreCode",
                table: "DcTerminals");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                column: "StoreCode",
                value: "mgz01");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000006",
                column: "StoreCode",
                value: "mgz01");

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "FatherName", "FirstName", "Gender", "IdentityNum", "IsDefault", "LanguageCode", "LastName", "MaritalStatus", "NewPassword", "OfficeCode", "PersonalTypeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[] { "kassa01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nağd Kassa", (byte)5, null, null, null, (byte)0, null, true, null, null, (byte)0, "456", "ofs01", null, null, null, "mgz01", null, null, null });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "FatherName", "FirstName", "Gender", "IdentityNum", "LanguageCode", "LastName", "MaritalStatus", "NewPassword", "OfficeCode", "PersonalTypeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[] { "mgz01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merkez Mağaza", (byte)4, null, null, null, (byte)0, null, null, null, (byte)0, "456", "ofs01", null, "", null, "mgz01", null, null, null });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "\r\n\r\n	select CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Kassa Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 5 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	order by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                column: "CashRegisterCode",
                value: "kassa01");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                column: "CashRegisterCode",
                value: "kassa01");

            migrationBuilder.UpdateData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-01",
                column: "StoreCode",
                value: "mgz01");

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                column: "StoreCode",
                value: "mgz01");
        }
    }
}
