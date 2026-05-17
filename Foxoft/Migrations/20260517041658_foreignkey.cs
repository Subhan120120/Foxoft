using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "DcWarehouses",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_DcWarehouses_StoreCode",
                table: "DcWarehouses",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_StoreCode",
                table: "DcCurrAccs",
                column: "StoreCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccs_StoreCode",
                table: "DcCurrAccs",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcWarehouses_DcCurrAccs_StoreCode",
                table: "DcWarehouses",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccs_StoreCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcWarehouses_DcCurrAccs_StoreCode",
                table: "DcWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_DcWarehouses_StoreCode",
                table: "DcWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_StoreCode",
                table: "DcCurrAccs");
        }
    }
}
