using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class delete_queryParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcQueryParams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcQueryParams",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParameterType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcQueryParams", x => x.ParameterId);
                    table.ForeignKey(
                        name: "FK_DcQueryParams_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_ReportId",
                table: "DcQueryParams",
                column: "ReportId");
        }
    }
}
