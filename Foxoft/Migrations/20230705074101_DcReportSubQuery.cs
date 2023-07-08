using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcReportSubQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrShipmentLines");

            migrationBuilder.DropTable(
                name: "TrShipmentHeaders");

            migrationBuilder.RenameColumn(
                name: "QueryText",
                table: "DcReportQueries",
                newName: "SubQueryText");

            migrationBuilder.RenameColumn(
                name: "QueryName",
                table: "DcReportQueries",
                newName: "SubQueryName");

            migrationBuilder.RenameColumn(
                name: "QueryId",
                table: "DcReportQueries",
                newName: "SubQueryId");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosDiscount",
                column: "ClaimTypeId",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportTypeId",
                value: (byte)1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubQueryText",
                table: "DcReportQueries",
                newName: "QueryText");

            migrationBuilder.RenameColumn(
                name: "SubQueryName",
                table: "DcReportQueries",
                newName: "QueryName");

            migrationBuilder.RenameColumn(
                name: "SubQueryId",
                table: "DcReportQueries",
                newName: "QueryId");

            migrationBuilder.CreateTable(
                name: "TrShipmentHeaders",
                columns: table => new
                {
                    ShipmentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyCode = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomsDocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsOrderBase = table.Column<bool>(type: "bit", nullable: false),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false),
                    IsTransferApproved = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    OfficeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ShipTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippingNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShippingPostalAddressId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 60, nullable: false),
                    ShippingTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ToWarehouseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TransferApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentHeaders", x => x.ShipmentHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentLines",
                columns: table => new
                {
                    ShipmentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LineDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDimensionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    SalespersonCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ShipmentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UsedBarcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentLines", x => x.ShipmentLineId);
                    table.ForeignKey(
                        name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                        column: x => x.ShipmentHeaderId,
                        principalTable: "TrShipmentHeaders",
                        principalColumn: "ShipmentHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosDiscount",
                column: "ClaimTypeId",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportTypeId",
                value: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_TrShipmentLines_ShipmentHeaderId",
                table: "TrShipmentLines",
                column: "ShipmentHeaderId");
        }
    }
}
