using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class IsRedirected_RedirectedCurrAccCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.RenameColumn(
                name: "DefaultCurrAccCode",
                table: "DcPaymentMethods",
                newName: "RedirectedCurrAccCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_RedirectedCurrAccCode");

            migrationBuilder.AddColumn<bool>(
                name: "IsRedirected",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "IsRedirected",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "IsRedirected",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "IsRedirected",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "IsRedirected",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "IsRedirected",
                value: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                column: "RedirectedCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsRedirected",
                table: "DcPaymentMethods");

            migrationBuilder.RenameColumn(
                name: "RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                newName: "DefaultCurrAccCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_DefaultCurrAccCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                column: "DefaultCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
