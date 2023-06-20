using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcFeatureColumnOrder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "DcFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureCode", "FeatureTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AlterColumn<byte>(
                name: "FeatureTypeId",
                table: "DcFeatures",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId" });
        }
    }
}
