using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdsdffgh22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_StoreCode",
                table: "TrPaymentHeaders",
                column: "StoreCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_StoreCode",
                table: "TrPaymentHeaders");
        }
    }
}
