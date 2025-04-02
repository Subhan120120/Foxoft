using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class currAccFeatureSystem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccFeatures_DcFeatureCurrAccs_FeatureCode_FeatureTypeId",
                table: "TrCurrAccFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccFeatures_DcFeatureTypeCurrAccs_FeatureTypeId",
                table: "TrCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcFeatureCurrAccs");

            migrationBuilder.DropTable(
                name: "DcFeatureTypeCurrAccs");


            migrationBuilder.RenameColumn(
                name: "FeatureCode",
                table: "TrCurrAccFeatures",
                newName: "CurrAccFeatureCode");

            migrationBuilder.RenameColumn(
                name: "FeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "CurrAccFeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrCurrAccFeatures_FeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "IX_TrCurrAccFeatures_CurrAccFeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrCurrAccFeatures_FeatureCode_FeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "IX_TrCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId");

            migrationBuilder.CreateTable(
                name: "DcCurrAccFeatureTypes",
                columns: table => new
                {
                    CurrAccFeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccFeatureTypes", x => x.CurrAccFeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccFeatures",
                columns: table => new
                {
                    CurrAccFeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrAccFeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccFeatures", x => new { x.CurrAccFeatureCode, x.CurrAccFeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcCurrAccFeatures_DcCurrAccFeatureTypes_CurrAccFeatureTypeId",
                        column: x => x.CurrAccFeatureTypeId,
                        principalTable: "DcCurrAccFeatureTypes",
                        principalColumn: "CurrAccFeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransferReturnCustom",
                column: "ClaimDesc",
                value: "Məhsul Transferi Xüsusi Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType",
                column: "ClaimDesc",
                value: "Məhsul Özəllik Tipləri");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccFeatures_CurrAccFeatureTypeId",
                table: "DcCurrAccFeatures",
                column: "CurrAccFeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccFeatures_DcCurrAccFeatureTypes_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                column: "CurrAccFeatureTypeId",
                principalTable: "DcCurrAccFeatureTypes",
                principalColumn: "CurrAccFeatureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccFeatures_DcCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                columns: new[] { "CurrAccFeatureCode", "CurrAccFeatureTypeId" },
                principalTable: "DcCurrAccFeatures",
                principalColumns: new[] { "CurrAccFeatureCode", "CurrAccFeatureTypeId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccFeatures_DcCurrAccFeatureTypes_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccFeatures_DcCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatureTypes");

            migrationBuilder.RenameColumn(
                name: "CurrAccFeatureCode",
                table: "TrCurrAccFeatures",
                newName: "FeatureCode");

            migrationBuilder.RenameColumn(
                name: "CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "FeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "IX_TrCurrAccFeatures_FeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                newName: "IX_TrCurrAccFeatures_FeatureCode_FeatureTypeId");

            migrationBuilder.CreateTable(
                name: "DcFeatureTypeCurrAccs",
                columns: table => new
                {
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureTypeCurrAccs", x => x.FeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatureCurrAccs",
                columns: table => new
                {
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureCurrAccs", x => new { x.FeatureCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcFeatureCurrAccs_DcFeatureTypeCurrAccs_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypeCurrAccs",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransferReturnCustom",
                column: "ClaimDesc",
                value: "Məhsul Transferi Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType",
                column: "ClaimDesc",
                value: "Məhsul Özəlliyi");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "HierarchyFeatureType", 18, "Özəlliyi İyerarxiyaya Bağlama", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_DcFeatureCurrAccs_FeatureTypeId",
                table: "DcFeatureCurrAccs",
                column: "FeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccFeatures_DcFeatureCurrAccs_FeatureCode_FeatureTypeId",
                table: "TrCurrAccFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" },
                principalTable: "DcFeatureCurrAccs",
                principalColumns: new[] { "FeatureCode", "FeatureTypeId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccFeatures_DcFeatureTypeCurrAccs_FeatureTypeId",
                table: "TrCurrAccFeatures",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypeCurrAccs",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
