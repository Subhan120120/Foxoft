using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcPriceListTypes",
                columns: table => new
                {
                    PriceListTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceListTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPriceListTypes", x => x.PriceListTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "TrPriceListHeaders",
                columns: table => new
                {
                    PriceListHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PriceListTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DueTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OfficeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsTexIncluded = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPriceListHeaders", x => x.PriceListHeaderId);
                    table.ForeignKey(
                        name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceListTypeCode",
                        column: x => x.PriceListTypeCode,
                        principalTable: "DcPriceListTypes",
                        principalColumn: "PriceListTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPriceListLines",
                columns: table => new
                {
                    PriceListLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceListHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    LineDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPriceListLines", x => x.PriceListLineId);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_DcCurrencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                        column: x => x.PriceListHeaderId,
                        principalTable: "TrPriceListHeaders",
                        principalColumn: "PriceListHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListHeaders_PriceListTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceListTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_CurrencyCode",
                table: "TrPriceListLines",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_PriceListHeaderId",
                table: "TrPriceListLines",
                column: "PriceListHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_ProductCode",
                table: "TrPriceListLines",
                column: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrPriceListLines");

            migrationBuilder.DropTable(
                name: "TrPriceListHeaders");

            migrationBuilder.DropTable(
                name: "DcPriceListTypes");
        }
    }
}
