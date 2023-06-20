using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdsdfgdh23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductFeatures_FeatureCode",
                table: "TrProductFeatures",
                column: "FeatureCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode",
                table: "TrProductFeatures",
                column: "FeatureCode",
                principalTable: "DcFeatures",
                principalColumn: "FeatureCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode",
                table: "TrProductFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrProductFeatures_FeatureCode",
                table: "TrProductFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
