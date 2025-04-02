using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class contactdetail3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "DcCurrAccContactDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumberFormat",
                table: "DcCurrAccContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "DcContactType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberFormat",
                table: "DcContactType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcContactType",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "DefaultValue", "PhoneNumberFormat" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DcContactType",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "DefaultValue", "PhoneNumberFormat" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DcContactType",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "DefaultValue", "PhoneNumberFormat" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DcContactType",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "DefaultValue", "PhoneNumberFormat" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "DcContactType");

            migrationBuilder.DropColumn(
                name: "PhoneNumberFormat",
                table: "DcContactType");

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "DcCurrAccContactDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberFormat",
                table: "DcCurrAccContactDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
