using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdasdsl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "CurrAccTypeCode",
                value: (byte)3);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName" },
                values: new object[] { (byte)3, "Mudir", "Mudir" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "NewPassword" },
                values: new object[] { (byte)3, "Operator", "Operator", "123" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                columns: new[] { "FirstName", "LastName", "NewPassword" },
                values: new object[] { "Satici", "Satici", "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "CurrAccTypeCode",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName" },
                values: new object[] { (byte)1, "Cemil", "Cavadov" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                columns: new[] { "CurrAccTypeCode", "FirstName", "LastName", "NewPassword" },
                values: new object[] { (byte)2, "Orxan", "Sederek", "456" });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                columns: new[] { "FirstName", "LastName", "NewPassword" },
                values: new object[] { "Vagif", "Mustafayev", "456" });
        }
    }
}
