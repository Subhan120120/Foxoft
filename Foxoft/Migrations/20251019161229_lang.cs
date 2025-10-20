using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class lang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataLanguageCode",
                table: "DcCurrAccs",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.RenameColumn(
                name: "DataLanguageCode",
                table: "DcCurrAccs",
                newName: "LanguageCode");

            migrationBuilder.CreateTable(
                name: "DcUILanguages",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LanguageDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUILanguages", x => x.LanguageCode);
                });

            migrationBuilder.InsertData(
                table: "DcUILanguages",
                columns: new[] { "LanguageCode", "LanguageDesc" },
                values: new object[,]
                {
                    { "az", "Azərbaycanca" },
                    { "en", "English" },
                    { "ru", "Русский" },
                    { "tr", "Türkçe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_LanguageCode",
                table: "DcCurrAccs",
                column: "LanguageCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcUILanguages_LanguageCode",
                table: "DcCurrAccs",
                column: "LanguageCode",
                principalTable: "DcUILanguages",
                principalColumn: "LanguageCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcUILanguages_LanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "DcUILanguages");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_LanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.RenameColumn(
                name: "LanguageCode",
                table: "DcCurrAccs",
                newName: "DataLanguageCode");
        }
    }
}
