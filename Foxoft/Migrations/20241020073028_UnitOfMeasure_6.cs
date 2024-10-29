using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcUnitOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasureDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUnitOfMeasure", x => x.UnitOfMeasureId);
                });


            migrationBuilder.InsertData(
                table: "DcUnitOfMeasure",
                columns: new[] { "UnitOfMeasureId", "Level", "UnitOfMeasureDesc" },
                values: new object[,]
                {
                    { 1, (byte)1, "Ədəd" },
                    { 2, (byte)1, "Qutu" }
                });


            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasure_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasure_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "DcUnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts");
        }
    }
}
