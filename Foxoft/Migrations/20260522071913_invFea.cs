using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class invFea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcInvoiceLineFeatureTypes",
                columns: table => new
                {
                    InvoiceLineFeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcInvoiceLineFeatureTypes", x => x.InvoiceLineFeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcInvoiceLineFeatures",
                columns: table => new
                {
                    InvoiceLineFeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceLineFeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcInvoiceLineFeatures", x => new { x.InvoiceLineFeatureCode, x.InvoiceLineFeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcInvoiceLineFeatures_DcInvoiceLineFeatureTypes_InvoiceLineFeatureTypeId",
                        column: x => x.InvoiceLineFeatureTypeId,
                        principalTable: "DcInvoiceLineFeatureTypes",
                        principalColumn: "InvoiceLineFeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLineFeatures",
                columns: table => new
                {
                    InvoiceLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceLineFeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    InvoiceLineFeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceLineFeatures", x => new { x.InvoiceLineId, x.InvoiceLineFeatureTypeId, x.InvoiceLineFeatureCode });
                    table.ForeignKey(
                        name: "FK_TrInvoiceLineFeatures_DcInvoiceLineFeatureTypes_InvoiceLineFeatureTypeId",
                        column: x => x.InvoiceLineFeatureTypeId,
                        principalTable: "DcInvoiceLineFeatureTypes",
                        principalColumn: "InvoiceLineFeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLineFeatures_DcInvoiceLineFeatures_InvoiceLineFeatureCode_InvoiceLineFeatureTypeId",
                        columns: x => new { x.InvoiceLineFeatureCode, x.InvoiceLineFeatureTypeId },
                        principalTable: "DcInvoiceLineFeatures",
                        principalColumns: new[] { "InvoiceLineFeatureCode", "InvoiceLineFeatureTypeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLineFeatures_TrInvoiceLines_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "TrInvoiceLines",
                        principalColumn: "InvoiceLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcInvoiceLineFeatures_InvoiceLineFeatureTypeId",
                table: "DcInvoiceLineFeatures",
                column: "InvoiceLineFeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLineFeatures_InvoiceLineFeatureCode_InvoiceLineFeatureTypeId",
                table: "TrInvoiceLineFeatures",
                columns: new[] { "InvoiceLineFeatureCode", "InvoiceLineFeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLineFeatures_InvoiceLineFeatureTypeId",
                table: "TrInvoiceLineFeatures",
                column: "InvoiceLineFeatureTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrInvoiceLineFeatures");

            migrationBuilder.DropTable(
                name: "DcInvoiceLineFeatures");

            migrationBuilder.DropTable(
                name: "DcInvoiceLineFeatureTypes");
        }
    }
}
