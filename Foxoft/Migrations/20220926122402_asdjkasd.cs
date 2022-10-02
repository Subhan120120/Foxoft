using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdjkasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcProductDcFeatures",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductDcFeatures", x => new { x.ProductCode, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_DcProductDcFeatures_DcFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "DcFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcProductDcFeatures_FeatureId",
                table: "DcProductDcFeatures",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcProductDcFeatures");
        }
    }
}
