using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcProductsşHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HierarchyCode",
                table: "DcProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_HierarchyCode",
                table: "DcProducts",
                column: "HierarchyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcHierarchies_HierarchyCode",
                table: "DcProducts",
                column: "HierarchyCode",
                principalTable: "DcHierarchies",
                principalColumn: "HierarchyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcHierarchies_HierarchyCode",
                table: "DcProducts");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_HierarchyCode",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "HierarchyCode",
                table: "DcProducts");
        }
    }
}
