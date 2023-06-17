using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureId",
                table: "TrProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures");

            migrationBuilder.DropTable(
                name: "DcFeatureDcProduct");

            migrationBuilder.DropTable(
                name: "DcFeatures");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "TrProductFeatures",
                newName: "FeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductFeatures_FeatureId",
                table: "TrProductFeatures",
                newName: "IX_TrProductFeatures_FeatureTypeId");

            migrationBuilder.CreateTable(
                name: "DcFeatureTypes",
                columns: table => new
                {
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureTypes", x => x.FeatureTypeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatureTypes_FeatureTypeId",
                table: "TrProductFeatures",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcFeatureTypes_FeatureTypeId",
                table: "TrProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures");

            migrationBuilder.DropTable(
                name: "DcFeatureTypes");

            migrationBuilder.RenameColumn(
                name: "FeatureTypeId",
                table: "TrProductFeatures",
                newName: "FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductFeatures_FeatureTypeId",
                table: "TrProductFeatures",
                newName: "IX_TrProductFeatures_FeatureId");

            migrationBuilder.CreateTable(
                name: "DcFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatureDcProduct",
                columns: table => new
                {
                    DcFeaturesId = table.Column<int>(type: "int", nullable: false),
                    DcProductsProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureDcProduct", x => new { x.DcFeaturesId, x.DcProductsProductCode });
                    table.ForeignKey(
                        name: "FK_DcFeatureDcProduct_DcFeatures_DcFeaturesId",
                        column: x => x.DcFeaturesId,
                        principalTable: "DcFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcFeatureDcProduct_DcProducts_DcProductsProductCode",
                        column: x => x.DcProductsProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcFeatureDcProduct_DcProductsProductCode",
                table: "DcFeatureDcProduct",
                column: "DcProductsProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureId",
                table: "TrProductFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
