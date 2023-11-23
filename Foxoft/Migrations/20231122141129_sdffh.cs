using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdffh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TrProductBarcodes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "TrProductBarcodes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrProductBarcodes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrProductBarcodes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TrProductBarcodes");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "TrProductBarcodes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "TrProductBarcodes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserName",
                table: "TrProductBarcodes");
        }
    }
}
