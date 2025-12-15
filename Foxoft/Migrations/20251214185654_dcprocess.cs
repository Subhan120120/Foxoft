using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class dcprocess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[] { "CN", null, "Sayım", (byte)0 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 61);
        }
    }
}
