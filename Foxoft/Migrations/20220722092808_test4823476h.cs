using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class test4823476h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1.703");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1.703",
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
