using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class add_claimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dcClaimType",
                table: "dcClaimType");

            migrationBuilder.RenameTable(
                name: "dcClaimType",
                newName: "DcClaimTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcClaimTypes",
                table: "DcClaimTypes",
                column: "ClaimTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcClaimTypes",
                table: "DcClaimTypes");

            migrationBuilder.RenameTable(
                name: "DcClaimTypes",
                newName: "dcClaimType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dcClaimType",
                table: "dcClaimType",
                column: "ClaimTypeCode");
        }
    }
}
