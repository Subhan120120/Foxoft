using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dfgdfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "DcProducts");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.*\r\nFROM    TrProductBarcodes pb\r\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\r\n\r\n\r\n\r\n\r\n\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "DcProducts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "Barcode",
                value: "");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "Barcode",
                value: "");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "Barcode",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "Barcode",
                value: "2000000000013");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nSELECT  t1.*, t2.number + 1 RepeatNumber\r\nFROM    DcProducts t1\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < 1\r\n\r\n\r\n\r\n\r\n");
        }
    }
}
