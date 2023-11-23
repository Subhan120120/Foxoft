using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddgfghl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[] { "20", null, "Barkod" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "20");
        }
    }
}
