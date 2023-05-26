using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ClaimTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "dcClaimTypeClaimTypeCode",
                table: "DcClaims",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcClaimTypes",
                columns: table => new
                {
                    ClaimTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    ClaimTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClaimTypes", x => x.ClaimTypeCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_dcClaimTypeClaimTypeCode",
                table: "DcClaims",
                column: "dcClaimTypeClaimTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcClaims_DcClaimTypes_dcClaimTypeClaimTypeCode",
                table: "DcClaims",
                column: "dcClaimTypeClaimTypeCode",
                principalTable: "DcClaimTypes",
                principalColumn: "ClaimTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimTypes_dcClaimTypeClaimTypeCode",
                table: "DcClaims");

            migrationBuilder.DropTable(
                name: "DcClaimTypes");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_dcClaimTypeClaimTypeCode",
                table: "DcClaims");

            migrationBuilder.DropColumn(
                name: "dcClaimTypeClaimTypeCode",
                table: "DcClaims");
        }
    }
}
