using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class fgfjs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "TrProductBarcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TrProductBarcodes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TrProductBarcodes");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "TrProductBarcodes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes",
                column: "Barcode");
        }
    }
}
