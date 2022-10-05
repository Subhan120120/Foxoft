using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "TrPaymentHeaders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "TrPaymentHeaders",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

        }
    }
}
