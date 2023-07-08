using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId", "FeatureCode" });
        }
    }
}
