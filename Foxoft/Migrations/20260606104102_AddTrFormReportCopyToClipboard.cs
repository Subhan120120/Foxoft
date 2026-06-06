using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    [Migration("20260606104102_AddTrFormReportCopyToClipboard")]
    public partial class AddTrFormReportCopyToClipboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CopyToClipboard",
                table: "TrFormReports",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopyToClipboard",
                table: "TrFormReports");
        }
    }
}
