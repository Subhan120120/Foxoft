using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddfgas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityColumn",
                table: "TrProductHierarchies");

            migrationBuilder.AddColumn<int>(
                name: "IdentityColumn",
                table: "TrProductFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityColumn",
                table: "TrProductFeatures");

            migrationBuilder.AddColumn<int>(
                name: "IdentityColumn",
                table: "TrProductHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
