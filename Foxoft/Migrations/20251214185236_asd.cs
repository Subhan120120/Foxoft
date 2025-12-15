using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "CategoryDesc",
                value: "Sayım");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCO",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountOut",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCO",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineCO",
                column: "CategoryId",
                value: 10);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "Count", 10, "Sayım", (byte)1 });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[] { "CN", null, "Sayım" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Count");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CN");

            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "CategoryDesc",
                value: "Sayım Artırma");

            migrationBuilder.InsertData(
                table: "DcClaimCategories",
                columns: new[] { "CategoryId", "CategoryDesc", "CategoryLevel", "CategoryParentId", "Order" },
                values: new object[] { 11, "Sayım Azaltma", 1, 2, 0 });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCO",
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountOut",
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCO",
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineCO",
                column: "CategoryId",
                value: 11);
        }
    }
}
