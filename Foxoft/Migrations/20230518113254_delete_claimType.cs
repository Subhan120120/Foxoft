using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class delete_claimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimTypes_dcClaimTypeClaimTypeCode",
                table: "DcClaims");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_dcClaimTypeClaimTypeCode",
                table: "DcClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcClaimTypes",
                table: "DcClaimTypes");

            migrationBuilder.DropColumn(
                name: "dcClaimTypeClaimTypeCode",
                table: "DcClaims");

            migrationBuilder.RenameTable(
                name: "DcClaimTypes",
                newName: "dcClaimType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dcClaimType",
                table: "dcClaimType",
                column: "ClaimTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dcClaimType",
                table: "dcClaimType");

            migrationBuilder.RenameTable(
                name: "dcClaimType",
                newName: "DcClaimTypes");

            migrationBuilder.AddColumn<byte>(
                name: "dcClaimTypeClaimTypeCode",
                table: "DcClaims",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcClaimTypes",
                table: "DcClaimTypes",
                column: "ClaimTypeCode");

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
    }
}
