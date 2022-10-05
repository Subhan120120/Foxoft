using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrPaymentHeader4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPaymentHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPaymentHeaders",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPaymentHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPaymentHeaders",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
