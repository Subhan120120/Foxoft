using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dfgfghjs24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "DcProducts");

            migrationBuilder.AddColumn<int>(
                name: "SiteProductId",
                table: "DcProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SiteProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteProduct", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_SiteProduct_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                unique: true,
                filter: "[SiteProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SiteProduct_ProductCode",
                table: "SiteProduct",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_SiteProduct_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                principalTable: "SiteProduct",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_SiteProduct_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropTable(
                name: "SiteProduct");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "SiteProductId",
                table: "DcProducts");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "DcProducts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
