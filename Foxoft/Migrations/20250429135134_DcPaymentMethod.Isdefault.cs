using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcPaymentMethodIsdefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "IsDefault",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DcPaymentMethods");
        }
    }
}
