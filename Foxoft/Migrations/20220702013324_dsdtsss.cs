using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dsdtsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "NewPassword", "PhoneNum", "RowGuid", "StoreCode", "VendorTypeCode" },
                values: new object[] { "kassa01", (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nağd Kassa", (byte)5, null, "456", "", new Guid("00000000-0000-0000-0000-000000000000"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01");
        }
    }
}
