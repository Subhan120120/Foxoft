using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrProcessPriceTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrProcessPriceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    PriceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProcessPriceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrProcessPriceTypes_DcPriceTypes_PriceTypeCode",
                        column: x => x.PriceTypeCode,
                        principalTable: "DcPriceTypes",
                        principalColumn: "PriceTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProcessPriceTypes_DcProcesses_ProcessCode",
                        column: x => x.ProcessCode,
                        principalTable: "DcProcesses",
                        principalColumn: "ProcessCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_PriceTypeCode",
                table: "TrProcessPriceTypes",
                column: "PriceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode",
                table: "TrProcessPriceTypes",
                column: "ProcessCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrProcessPriceTypes");
        }
    }
}
