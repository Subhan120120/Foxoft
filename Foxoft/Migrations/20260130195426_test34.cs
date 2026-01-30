using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class test34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "IsRedirected", "PaymentMethodDesc", "PaymentTypeCode", "RedirectedCurrAccCode" },
                values: new object[] { false, "Daxili Kredit", (byte)3, null });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                columns: new[] { "IsRedirected", "PaymentMethodDesc", "PaymentTypeCode", "RedirectedCurrAccCode" },
                values: new object[] { true, "Bir Kart", (byte)2, "C-000006" });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Çatdırılma zamanı nağd ödə", (byte)1 });

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "IsDefault", "IsRedirected", "PaymentMethodDesc", "PaymentTypeCode", "RedirectedCurrAccCode" },
                values: new object[] { 5, null, false, false, "Saytda nağd ödə", (byte)2, null });
        }
    }
}
