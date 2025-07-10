using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcCashRegisterForeignKey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_CashRegisterCode",
                table: "TrPaymentLines",
                column: "CashRegisterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcCurrAccs_CashRegisterCode",
                table: "TrPaymentLines",
                column: "CashRegisterCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
