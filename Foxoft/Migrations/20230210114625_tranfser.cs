using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class tranfser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainTF",
                table: "TrInvoiceHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[,]
                {
                    { "IT", null, "Mal Transferi", (byte)2 },
                    { "CT", null, "Pul Transferi", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "IT", null, "Mal Transferi" },
                    { "CT", null, "Pul transferi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CT");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "IT");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CI");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CT");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "IT");

            migrationBuilder.DropColumn(
                name: "IsMainTF",
                table: "TrInvoiceHeaders");
        }
    }
}
