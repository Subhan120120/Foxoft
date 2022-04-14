using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class added_OperationDate_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrPaymentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrPaymentHeaders",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrPaymentHeaders",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrPaymentHeaders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

        }
    }
}
