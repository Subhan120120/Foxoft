using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddfgfgh34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SiteProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SiteProducts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SiteProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "SiteProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "SiteProducts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "SiteProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "SiteProducts");
        }
    }
}
