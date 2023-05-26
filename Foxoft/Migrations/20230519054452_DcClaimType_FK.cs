using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcClaimType_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_ClaimTypeId",
                table: "DcClaims",
                column: "ClaimTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcClaims_DcClaimTypes_ClaimTypeId",
                table: "DcClaims",
                column: "ClaimTypeId",
                principalTable: "DcClaimTypes",
                principalColumn: "ClaimTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimTypes_ClaimTypeId",
                table: "DcClaims");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_ClaimTypeId",
                table: "DcClaims");
        }
    }
}
