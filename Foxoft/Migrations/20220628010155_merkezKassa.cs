using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class merkezKassa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDesc", "IsDisabled", "RowGuid" },
                values: new object[] { (byte)5, "Kassa", false, new Guid("00000000-0000-0000-0000-000000000000") });


            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CurrAccTypeCode",
                value: (byte)3);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01",
                columns: new[] { "CurrAccDesc", "CurrAccTypeCode", "FirstName" },
                values: new object[] { "Merkez Mağaza", (byte)4, null });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "ConfirmPassword", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "NewPassword", "PhoneNum", "RowGuid", "StoreCode", "VendorTypeCode" },
                values: new object[] { "kassa01", (byte)0, null, "Merkez Kassa", (byte)5, null, "456", "", new Guid("00000000-0000-0000-0000-000000000000"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CurrAccTypeCode",
                value: (byte)4);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01",
                columns: new[] { "CurrAccDesc", "CurrAccTypeCode", "FirstName" },
                values: new object[] { "Merkez", (byte)3, "Orxan" });

            migrationBuilder.DeleteData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)5);
        }
    }
}
