using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrBarcodeOperation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarcodeOperationHeaderId",
                table: "trBarcodeOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrBarcodeOperationHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrBarcodeOperationHeader", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trBarcodeOperations_BarcodeOperationHeaderId",
                table: "trBarcodeOperations",
                column: "BarcodeOperationHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_trBarcodeOperations_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "trBarcodeOperations",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trBarcodeOperations_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "trBarcodeOperations");

            migrationBuilder.DropTable(
                name: "TrBarcodeOperationHeader");

            migrationBuilder.DropIndex(
                name: "IX_trBarcodeOperations_BarcodeOperationHeaderId",
                table: "trBarcodeOperations");

            migrationBuilder.DropColumn(
                name: "BarcodeOperationHeaderId",
                table: "trBarcodeOperations");
        }
    }
}
