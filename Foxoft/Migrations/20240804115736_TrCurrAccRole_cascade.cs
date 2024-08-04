using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrCurrAccRole_cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
