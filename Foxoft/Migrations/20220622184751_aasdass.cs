using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class aasdass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "OFS01");

            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "OFS02");

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "ofs01", 0m, false, "Bakıxanov Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "ofs02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "ofs01");

            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "ofs02");

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "OFS01", 0m, false, "Bakıxanov Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "OFS02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
