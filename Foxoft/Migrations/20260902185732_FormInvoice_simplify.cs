using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class FormInvoice_simplify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "DcLoyaltyPrograms",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "UseInvoiceExpenses",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<bool>(
                name: "UseLoyalty",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<bool>(
                name: "UseWhatsApp",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UseInvoiceExpenses", "UseLoyalty", "UseWhatsApp" },
                values: new object[] { true, true, true });


            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 314, "LoyaltyPrograms", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "LoyaltyPrograms");

            migrationBuilder.DropColumn(
                name: "UseInvoiceExpenses",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "UseLoyalty",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "UseWhatsApp",
                table: "AppSettings");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "DcLoyaltyPrograms",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
