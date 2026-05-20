using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddHRClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaimCategories",
                columns: new[] { "CategoryId", "CategoryDesc", "CategoryLevel", "CategoryParentId", "Order" },
                values: new object[] { 23, "İnsan Resursları", 0, null, 0 });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "Attendances", 23, "Davamiyyət", (byte)1 },
                    { "Departments", 23, "Şöbələr", (byte)1 },
                    { "EmployeeContracts", 23, "İşçi Müqavilələri", (byte)1 },
                    { "EmployeePositions", 23, "İşçi Vəzifələri", (byte)1 },
                    { "EmploymentTypes", 23, "Məşğulluq Növləri", (byte)1 },
                    { "PayrollPeriods", 23, "Əməkhaqqı Dövrləri", (byte)1 },
                    { "Payrolls", 23, "Əməkhaqqı Siyahısı", (byte)1 },
                    { "Positions", 23, "Vəzifələr", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 70, "Departments", "Admin" },
                    { 71, "Positions", "Admin" },
                    { 72, "EmploymentTypes", "Admin" },
                    { 73, "EmployeePositions", "Admin" },
                    { 74, "EmployeeContracts", "Admin" },
                    { 75, "PayrollPeriods", "Admin" },
                    { 76, "Payrolls", "Admin" },
                    { 77, "Attendances", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Attendances");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Departments");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EmployeeContracts");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EmployeePositions");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EmploymentTypes");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PayrollPeriods");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Payrolls");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Positions");

            migrationBuilder.DeleteData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 23);
        }
    }
}
