using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrProcessPriceTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode",
                table: "TrProcessPriceTypes");

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode_PriceTypeCode",
                table: "TrProcessPriceTypes",
                columns: new[] { "ProcessCode", "PriceTypeCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode_PriceTypeCode",
                table: "TrProcessPriceTypes");

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode",
                table: "TrProcessPriceTypes",
                column: "ProcessCode");
        }
    }
}
