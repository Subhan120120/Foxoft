using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfggsj3456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodCode",
                table: "TrPaymentLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcPaymentMethods",
                columns: table => new
                {
                    PaymentMethodCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentMethodDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentMethods", x => x.PaymentMethodCode);
                    table.ForeignKey(
                        name: "FK_DcPaymentMethods_DcPaymentTypes_PaymentTypeCode",
                        column: x => x.PaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)2,
                column: "PaymentTypeDesc",
                value: "Nağdsız");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentMethodCode",
                table: "TrPaymentLines",
                column: "PaymentMethodCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_PaymentTypeCode",
                table: "DcPaymentMethods",
                column: "PaymentTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodCode",
                table: "TrPaymentLines",
                column: "PaymentMethodCode",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodCode",
                table: "TrPaymentLines");

            migrationBuilder.DropTable(
                name: "DcPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentLines_PaymentMethodCode",
                table: "TrPaymentLines");

            migrationBuilder.DropColumn(
                name: "PaymentMethodCode",
                table: "TrPaymentLines");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)2,
                column: "PaymentTypeDesc",
                value: "Visa");
        }
    }
}
