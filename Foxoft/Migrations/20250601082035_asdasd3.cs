using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProductScale_DcProducts_ProductCode",
                table: "DcProductScale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProductScale",
                table: "DcProductScale");

            migrationBuilder.RenameTable(
                name: "DcProductScale",
                newName: "dcProductScales");

            migrationBuilder.RenameIndex(
                name: "IX_DcProductScale_ScaleProductNumber",
                table: "dcProductScales",
                newName: "IX_dcProductScales_ScaleProductNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DcProductScale_ProductCode",
                table: "dcProductScales",
                newName: "IX_dcProductScales_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dcProductScales",
                table: "dcProductScales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dcProductScales_DcProducts_ProductCode",
                table: "dcProductScales",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
