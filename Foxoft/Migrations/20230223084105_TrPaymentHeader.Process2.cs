using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrPaymentHeaderProcess2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_ProcessCode",
                table: "TrPaymentHeaders",
                column: "ProcessCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcProcesses_ProcessCode",
                table: "TrPaymentHeaders",
                column: "ProcessCode",
                principalTable: "DcProcesses",
                principalColumn: "ProcessCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcProcesses_ProcessCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_ProcessCode",
                table: "TrPaymentHeaders");
        }
    }
}
