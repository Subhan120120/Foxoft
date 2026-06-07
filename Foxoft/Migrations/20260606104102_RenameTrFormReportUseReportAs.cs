using Foxoft.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20260606104102_RenameTrFormReportUseReportAs")]
    public partial class RenameTrFormReportUseReportAs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CopyToClipboard",
                table: "TrFormReports",
                newName: "UseReportAs");

            migrationBuilder.AlterColumn<byte>(
                name: "UseReportAs",
                table: "TrFormReports",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)2,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.Sql(
                "UPDATE TrFormReports SET UseReportAs = CASE WHEN UseReportAs = 1 THEN 3 ELSE 2 END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE TrFormReports SET UseReportAs = CASE WHEN UseReportAs IN (1, 3) THEN 1 ELSE 0 END");

            migrationBuilder.AlterColumn<bool>(
                name: "UseReportAs",
                table: "TrFormReports",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)2);

            migrationBuilder.RenameColumn(
                name: "UseReportAs",
                table: "TrFormReports",
                newName: "CopyToClipboard");
        }
    }
}
