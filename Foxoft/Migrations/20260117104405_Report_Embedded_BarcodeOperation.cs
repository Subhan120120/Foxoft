using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class Report_Embedded_BarcodeOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { 8, null, null, "", "Report_Embedded_BarcodeOperation", "\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, pro.ProductDesc\r\n	, pro.WholesalePrice\r\n	, pro.RetailPrice\r\n	, bl.*\r\nFROM TrBarcodeOperationLines bl\r\nJOIN DcProducts pro on pro.ProductCode = bl.ProductCode\r\nJOIN TrBarcodeOperationHeaders bh on bh.Id = bl.BarcodeOperationHeaderId\r\nJOIN master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < bl.Qty\r\n", (byte)0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.ProductDesc\r\n	, DcProducts.WholesalePrice\r\n	, pb.*\r\nFROM    TrProductBarcodes pb\r\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\r\n");
        }
    }
}
