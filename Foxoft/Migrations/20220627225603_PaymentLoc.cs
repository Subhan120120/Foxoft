using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PaymentLoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaymentLoc",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureName",
                table: "DcFeatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "400",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentLoc",
                table: "TrPaymentLines");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureName",
                table: "DcFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "400");
        }
    }
}
