using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcReportVariable_And_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt");

            migrationBuilder.DropTable(
                name: "DcReportFilters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trInvoiceLineExt",
                table: "trInvoiceLineExt");

            migrationBuilder.RenameTable(
                name: "trInvoiceLineExt",
                newName: "TrInvoiceLineExt");

            migrationBuilder.RenameIndex(
                name: "IX_trInvoiceLineExt_InvoiceLineId",
                table: "TrInvoiceLineExt",
                newName: "IX_TrInvoiceLineExt_InvoiceLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInvoiceLineExt",
                table: "TrInvoiceLineExt",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dcReportVariableTypes",
                columns: table => new
                {
                    VariableTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    VariableTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcReportVariableTypes", x => x.VariableTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcReportVariables",
                columns: table => new
                {
                    VariableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    VariableTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    VariableProperty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VariableValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VariableOperatorType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Representative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportVariables", x => x.VariableId);
                    table.ForeignKey(
                        name: "FK_DcReportVariables_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DcReportVariables_dcReportVariableTypes_VariableTypeId",
                        column: x => x.VariableTypeId,
                        principalTable: "dcReportVariableTypes",
                        principalColumn: "VariableTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "dcReportVariableTypes",
                columns: new[] { "VariableTypeId", "VariableTypeDesc" },
                values: new object[] { (byte)1, "Parameter" });

            migrationBuilder.InsertData(
                table: "dcReportVariableTypes",
                columns: new[] { "VariableTypeId", "VariableTypeDesc" },
                values: new object[] { (byte)2, "Filter" });

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_ReportId",
                table: "DcReportVariables",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_VariableTypeId",
                table: "DcReportVariables",
                column: "VariableTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExt",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExt");

            migrationBuilder.DropTable(
                name: "DcReportVariables");

            migrationBuilder.DropTable(
                name: "dcReportVariableTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInvoiceLineExt",
                table: "TrInvoiceLineExt");

            migrationBuilder.RenameTable(
                name: "TrInvoiceLineExt",
                newName: "trInvoiceLineExt");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLineExt_InvoiceLineId",
                table: "trInvoiceLineExt",
                newName: "IX_trInvoiceLineExt_InvoiceLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trInvoiceLineExt",
                table: "trInvoiceLineExt",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DcReportFilters",
                columns: table => new
                {
                    FilterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilterOperatorType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilterProperty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilterValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Representative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportFilters", x => x.FilterId);
                    table.ForeignKey(
                        name: "FK_DcReportFilters_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcReportFilters_ReportId",
                table: "DcReportFilters",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
