using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class reportType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ReportTypeId",
                table: "DcReports",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "DcReportTypes",
                columns: table => new
                {
                    ReportTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ReportTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportTypes", x => x.ReportTypeId);
                });

            migrationBuilder.InsertData(
                table: "DcReportTypes",
                columns: new[] { "ReportTypeId", "IsDisabled", "ReportTypeDesc", "RowGuid" },
                values: new object[] { (byte)1, false, "Grid", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcReportTypes",
                columns: new[] { "ReportTypeId", "IsDisabled", "ReportTypeDesc", "RowGuid" },
                values: new object[] { (byte)2, false, "Detail", new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcReportTypes");

            migrationBuilder.DropColumn(
                name: "ReportTypeId",
                table: "DcReports");
        }
    }
}
