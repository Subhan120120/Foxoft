using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddfgfgh344567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_SiteProducts_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts");

            migrationBuilder.DropIndex(
                name: "IX_SiteProducts_ProductCode",
                table: "SiteProducts");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "SiteProductId",
                table: "DcProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "SiteProducts",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts",
                column: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "SiteProducts",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AddColumn<int>(
                name: "SiteProductId",
                table: "DcProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteProducts_ProductCode",
                table: "SiteProducts",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                unique: true,
                filter: "[SiteProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_SiteProducts_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                principalTable: "SiteProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
