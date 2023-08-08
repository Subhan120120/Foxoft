using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfggsj345678 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethodCode",
                table: "DcPaymentMethods",
                newName: "PaymentMethodId");

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { 1, "Nağd", (byte)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "DcPaymentMethods",
                newName: "PaymentMethodCode");
        }
    }
}
