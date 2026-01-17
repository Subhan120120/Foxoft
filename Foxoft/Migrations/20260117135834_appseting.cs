using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class appseting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "POSFindProductBy",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "POSShowQuantityDialog",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "POSShowSalesmanCodeDialog",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "POSFindProductBy", "POSShowQuantityDialog", "POSShowSalesmanCodeDialog" },
                values: new object[] { false, false, false });
}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "POSFindProductBy",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "POSShowQuantityDialog",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "POSShowSalesmanCodeDialog",
                table: "AppSettings");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 8,
                column: "ReportQuery",
                value: "\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, pro.ProductDesc\r\n	, pro.WholesalePrice\r\n	, pro.RetailPrice\r\n	, bl.*\r\nFROM TrBarcodeOperationLines bl\r\nJOIN DcProducts pro on pro.ProductCode = bl.ProductCode\r\nJOIN TrBarcodeOperationHeaders bh on bh.Id = bl.BarcodeOperationHeaderId\r\nJOIN master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < bl.Qty\r\n");
        }
    }
}
