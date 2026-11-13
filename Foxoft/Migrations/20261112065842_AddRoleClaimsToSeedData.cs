using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleClaimsToSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int id = 228; id <= 528; id++)
            {
                migrationBuilder.DeleteData(
                    table: "TrRoleClaims",
                    keyColumn: "RoleClaimId",
                    keyValue: id);
            }
        }
    }
}
