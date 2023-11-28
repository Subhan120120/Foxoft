using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdsdffgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.*\r\nFROM    TrProductBarcodes pb\r\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\r\n\r\n\r\n\r\n\r\n\r\n");
        }
    }
}
