using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcClaimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaimTypeCode",
                table: "DcClaimTypes",
                newName: "ClaimTypeId");

            migrationBuilder.AddColumn<byte>(
                name: "ClaimTypeId",
                table: "DcClaims",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimTypeId",
                table: "DcClaims");

            migrationBuilder.RenameColumn(
                name: "ClaimTypeId",
                table: "DcClaimTypes",
                newName: "ClaimTypeCode");
        }
    }
}
