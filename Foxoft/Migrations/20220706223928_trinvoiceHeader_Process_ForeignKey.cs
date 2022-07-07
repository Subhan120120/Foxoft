using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class trinvoiceHeader_Process_ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_ProcessCode",
                table: "TrInvoiceHeaders",
                column: "ProcessCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcProcesses_ProcessCode",
                table: "TrInvoiceHeaders",
                column: "ProcessCode",
                principalTable: "DcProcesses",
                principalColumn: "ProcessCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcProcesses_ProcessCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_ProcessCode",
                table: "TrInvoiceHeaders");
        }
    }
}
