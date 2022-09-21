using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dcProductDcFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrFeatures");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcFeatureDcProduct");

            migrationBuilder.CreateTable(
                name: "TrFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrFeatures_DcFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "DcFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrFeatures_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_FeatureId_ProductCode",
                table: "TrFeatures",
                columns: new[] { "FeatureId", "ProductCode" },
                unique: true,
                filter: "[ProductCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_ProductCode",
                table: "TrFeatures",
                column: "ProductCode");
        }
    }
}
