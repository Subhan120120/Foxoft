using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddfgdfhghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DcFeatures_FeatureTypeId",
                table: "DcFeatures",
                column: "FeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcFeatures_DcFeatureTypes_FeatureTypeId",
                table: "DcFeatures",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcFeatures_DcFeatureTypes_FeatureTypeId",
                table: "DcFeatures");

            migrationBuilder.DropIndex(
                name: "IX_DcFeatures_FeatureTypeId",
                table: "DcFeatures");
        }
    }
}
