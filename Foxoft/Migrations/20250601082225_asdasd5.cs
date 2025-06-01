using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcProductScales",
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
                    table.PrimaryKey("PK_DcProductScales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcProductScales_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcProductScales_ProductCode",
                table: "DcProductScales",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcProductScales_ScaleProductNumber",
                table: "DcProductScales",
                column: "ScaleProductNumber",
                unique: true,
                filter: "[ScaleProductNumber] IS NOT NULL");
        }
    }
}
