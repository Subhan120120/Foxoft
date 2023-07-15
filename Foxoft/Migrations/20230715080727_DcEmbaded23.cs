using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcEmbaded23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcEmbadeds");

            migrationBuilder.CreateTable(
                name: "DcForms",
                columns: table => new
                {
                    FormCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcForms", x => x.FormCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcForms");

            migrationBuilder.CreateTable(
                name: "DcEmbadeds",
                columns: table => new
                {
                    EmbadedCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmbadedDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcEmbadeds", x => x.EmbadedCode);
                });
        }
    }
}
