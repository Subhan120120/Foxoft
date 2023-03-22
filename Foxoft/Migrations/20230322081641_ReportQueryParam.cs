using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ReportQueryParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcReportQueries",
                columns: table => new
                {
                    QueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    QueryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueryText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportQueries", x => x.QueryId);
                });

            migrationBuilder.CreateTable(
                name: "DcQueryParams",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryId = table.Column<int>(type: "int", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParameterType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DcReportQueryQueryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcQueryParams", x => x.ParameterId);
                    table.ForeignKey(
                        name: "FK_DcQueryParams_DcReportQueries_DcReportQueryQueryId",
                        column: x => x.DcReportQueryQueryId,
                        principalTable: "DcReportQueries",
                        principalColumn: "QueryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_DcReportQueryQueryId",
                table: "DcQueryParams",
                column: "DcReportQueryQueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcQueryParams");

            migrationBuilder.DropTable(
                name: "DcReportQueries");
        }
    }
}
