using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class initiadasfhj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromCashRegCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainTF",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<string>(
                name: "ToCashRegCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "FromCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "IsMainTF",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "ToCashRegCode",
                table: "TrPaymentHeaders");
        }
    }
}
