using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ChangedNameCloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "StoreCode",
                table: "DcCurrAccs");

            migrationBuilder.RenameColumn(
                name: "CurrAccTypeDescription",
                table: "DcCurrAccTypes",
                newName: "CurrAccTypeDesc");

            migrationBuilder.AlterColumn<string>(
                name: "NewPassword",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrAccTypeDesc",
                table: "DcCurrAccTypes",
                newName: "CurrAccTypeDescription");

            migrationBuilder.AlterColumn<string>(
                name: "NewPassword",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreCode",
                table: "DcCurrAccs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
