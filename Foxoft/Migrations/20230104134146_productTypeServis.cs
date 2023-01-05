using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class productTypeServis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProductTypes",
                columns: new[] { "ProductTypeCode", "ProductTypeDesc" },
                values: new object[] { (byte)3, "Servis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProductTypes",
                keyColumn: "ProductTypeCode",
                keyValue: (byte)3);
        }
    }
}
