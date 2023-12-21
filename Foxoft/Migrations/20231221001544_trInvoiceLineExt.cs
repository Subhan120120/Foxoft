using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class trInvoiceLineExt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "trInvoiceLineExt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDiscounted = table.Column<decimal>(type: "money", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trInvoiceLineExt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trInvoiceLineExt_TrInvoiceLines_PaymentLineId",
                        column: x => x.PaymentLineId,
                        principalTable: "TrInvoiceLines",
                        principalColumn: "InvoiceLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trInvoiceLineExt_PaymentLineId",
                table: "trInvoiceLineExt",
                column: "PaymentLineId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trInvoiceLineExt");

            migrationBuilder.CreateTable(
                name: "GetNextDocNum",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
