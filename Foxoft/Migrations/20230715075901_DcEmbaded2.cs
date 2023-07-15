using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcEmbaded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcEmbadeds");
        }
    }
}
