using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRolesToSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "StoreManager",
                column: "RoleDesc",
                value: "Mağaza Müdiri");

            migrationBuilder.InsertData(
                table: "DcRoles",
                columns: new[] { "RoleCode", "RoleDesc" },
                values: new object[,]
                {
                    { "Cashier", "Kassir" },
                    { "CreditSpecialist", "Kredit Mütəxəssisi" },
                    { "Manager", "Manager" },
                    { "Warehouseman", "Anbardar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "Cashier");

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "CreditSpecialist");

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "Manager");

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "Warehouseman");

            migrationBuilder.UpdateData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "StoreManager",
                column: "RoleDesc",
                value: "Mağaza müdiri");
        }
    }
}
