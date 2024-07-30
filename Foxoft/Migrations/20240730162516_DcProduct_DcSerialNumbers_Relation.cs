using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcProduct_DcSerialNumbers_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 24,
                column: "ClaimCode",
                value: "Session");
        }
    }
}
