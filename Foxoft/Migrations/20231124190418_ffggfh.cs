using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ffggfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { 5, null, "", "Report_Embedded_Barcode", "\r\n\r\n\r\n\r\nSELECT  t1.*, t2.number + 1 RepeatNumber\r\nFROM    DcProducts t1\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < 1\r\n\r\n\r\n\r\n\r\n", (byte)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5);
        }
    }
}
