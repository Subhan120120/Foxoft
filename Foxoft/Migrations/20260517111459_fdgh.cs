using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class fdgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "TransferApprovalStatus",
                table: "TrInvoiceHeaders",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "TransferAutoApprove",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransferAutoApprove",
                value: true);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "TransferApproval", 14, "Transfer Təsdiqi", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "TransferApproval");

            migrationBuilder.DropColumn(
                name: "TransferApprovalStatus",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TransferAutoApprove",
                table: "AppSettings");
        }
    }
}
