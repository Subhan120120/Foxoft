using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
