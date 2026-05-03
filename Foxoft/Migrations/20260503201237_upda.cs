using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class upda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwilioToken",
                table: "AppSettings");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "TrWhatsAppMessageLogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyBalanceWarningLevel",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "ChangeExchangeRate", 2, "Məzənnə Kursu Dəyişmə", (byte)1 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangeExchangeRate");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropColumn(
                name: "NotifyBalanceWarningLevel",
                table: "AppSettings");

            migrationBuilder.AddColumn<string>(
                name: "TwilioToken",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "TwilioToken",
                value: null);
        }
    }
}
