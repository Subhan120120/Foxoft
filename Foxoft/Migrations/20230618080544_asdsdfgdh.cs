using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdsdfgdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureDesc",
                table: "TrProductFeatures",
                newName: "FeatureCode");

            migrationBuilder.CreateTable(
                name: "DcFeatures",
                columns: table => new
                {
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatures", x => x.FeatureCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcFeatures");

            migrationBuilder.RenameColumn(
                name: "FeatureCode",
                table: "TrProductFeatures",
                newName: "FeatureDesc");
        }
    }
}
