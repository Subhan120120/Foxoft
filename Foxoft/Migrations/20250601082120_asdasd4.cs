using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProductScales_DcProducts_ProductCode",
                table: "DcProductScales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProductScales",
                table: "DcProductScales");

            migrationBuilder.RenameTable(
                name: "DcProductScales",
                newName: "DcProductScale");

            migrationBuilder.RenameIndex(
                name: "IX_DcProductScales_ScaleProductNumber",
                table: "DcProductScale",
                newName: "IX_DcProductScale_ScaleProductNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DcProductScales_ProductCode",
                table: "DcProductScale",
                newName: "IX_DcProductScale_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcProductScale",
                table: "DcProductScale",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProductScale_DcProducts_ProductCode",
                table: "DcProductScale",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
