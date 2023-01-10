using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class yenile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Administrator", null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "PhoneNum",
                value: null);

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "DataLanguageCode", "FatherName", "FirstName", "IdentityNum", "IsDefault", "LastName", "NewPassword", "OfficeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "VendorTypeCode" },
                values: new object[] { "CA-5", null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ümumi Müştəri", (byte)1, null, null, null, "Ümumi Müştəri", null, true, null, "123", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null });

            migrationBuilder.UpdateData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-01",
                columns: new[] { "IsDefault", "WarehouseDesc" },
                values: new object[] { true, "Mərkəz deposu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-5");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sübhan", "Hüseynzadə" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "PhoneNum",
                value: "");

            migrationBuilder.UpdateData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-01",
                columns: new[] { "IsDefault", "WarehouseDesc" },
                values: new object[] { false, "Bakıxanov deposu" });
        }
    }
}
