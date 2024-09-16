using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DaxiliKredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Daxili Kredit", (byte)2 });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "PaymentMethodDesc",
                value: "Bir Kart");

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Çatdırılma zamanı nağd ödə", (byte)1 });

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { 5, null, "Saytda nağd ödə", (byte)2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Çatdırılma zamanı nağd ödə", (byte)1 });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "PaymentMethodDesc",
                value: "Saytda nağd ödə");

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Bir Kart", (byte)2 });
        }
    }
}
