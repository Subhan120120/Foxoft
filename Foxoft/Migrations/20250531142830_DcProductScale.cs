using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcProductScale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dcProductScales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ScaleProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleProductNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcProductScales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dcProductScales_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dcProductScales_ProductCode",
                table: "dcProductScales",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dcProductScales_ScaleProductNumber",
                table: "dcProductScales",
                column: "ScaleProductNumber",
                unique: true,
                filter: "[ScaleProductNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dcProductScales");
        }
    }
}
