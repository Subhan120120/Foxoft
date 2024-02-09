using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class orderİnvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[,]
                {
                    { "RPO", null, "Alış Sifarişi", (byte)1 },
                    { "RSO", null, "Satış Sifarişi", (byte)2 },
                    { "SBO", null, "Toptan Alış Sifarişi", (byte)1 },
                    { "WSO", null, "Toptan Satış Sifarişi", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "RSO", null, "Pərakəndə Satış Sifarişi" },
                    { "RPO", null, "Pərakəndə Alış Sifarişi" },
                    { "SBO", null, "Toptan Alış Sifarişi" },
                    { "WSO", null, "Topdan Satış Sifarişi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RPO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RSO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "SBO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WSO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RPO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RSO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "SBO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "WSO");
        }
    }
}
