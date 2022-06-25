using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "P");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "W");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "PR");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "W");

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "ProcessDescription" },
                values: new object[,]
                {
                    { "PA", "Ödəmə" },
                    { "WS", "Toptan Satış" }
                });

            migrationBuilder.UpdateData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "P",
                column: "VariableDesc",
                value: "Məhsul");

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "C", null, "Cari" },
                    { "PA", null, "Ödəmə" },
                    { "WS", null, "Toptan Satış" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PA");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WS");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "PA");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "WS");

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "ProcessDescription" },
                values: new object[,]
                {
                    { "P", "Ödəmə" },
                    { "W", "Toptan Satış" }
                });

            migrationBuilder.UpdateData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "P",
                column: "VariableDesc",
                value: "Ödəmə");

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "CA", null, "Cari" },
                    { "PR", null, "Məhsul" },
                    { "W", null, "Toptan Satış" }
                });
        }
    }
}
