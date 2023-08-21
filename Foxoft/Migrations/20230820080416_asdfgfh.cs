using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfgfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { 2, null, "Çatdırılma zamanı nağd ödə", (byte)1 });

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { 3, null, "Saytda nağd ödə", (byte)2 });

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { 4, null, "Bir Kart", (byte)2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4);
        }
    }
}
