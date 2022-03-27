using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "NewPassword", "PhoneNum" },
                values: new object[] { (byte)1, "Cemil", "Cavadov", "123", "0519678909" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "PhoneNum" },
                values: new object[] { (byte)2, "Orxan", "Sederek", "0773628800" });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "ConfirmPassword", "CurrAccTypeCode", "CustomerPosDiscountRate", "CustomerTypeCode", "FirstName", "IsDisabled", "LastName", "NewPassword", "PhoneNum", "RowGuid", "VendorTypeCode" },
                values: new object[] { "CA-4", (byte)0, null, (byte)3, 0.0, (byte)0, "Vagif", false, "Mustafayev", "456", "0553628804", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4");

            
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "NewPassword", "PhoneNum" },
                values: new object[] { (byte)2, "Orxan", "Sederek", "456", "0773628800" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "PhoneNum" },
                values: new object[] { (byte)3, "Vagif", "Mustafayev", "0553628804" });
        }
    }
}
