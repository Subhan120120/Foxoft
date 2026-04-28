using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ActivityTypeId",
                table: "TrCrmActivities",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.InsertData(
                table: "DcCrmActivityTypes",
                columns: new[] { "ActivityTypeId", "ActivityTypeDesc", "IsDisabled" },
                values: new object[,]
                {
                    { (byte)1, "Zəng", false },
                    { (byte)2, "Görüş", false },
                    { (byte)3, "Tapşırıq", false },
                    { (byte)4, "Email", false },
                    { (byte)5, "Ziyarət", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCrmActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "DcCrmActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "DcCrmActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "DcCrmActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "DcCrmActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: (byte)5);

            migrationBuilder.AlterColumn<byte>(
                name: "ActivityTypeId",
                table: "TrCrmActivities",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)1);
        }
    }
}
