using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure_deleted3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DcUnitOfMeasureUnitOfMeasureCode",
                table: "TrInvoiceLines",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DcUnitOfMeasureUnitOfMeasureCode",
                table: "DcProducts",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcUnitOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUnitOfMeasure", x => x.UnitOfMeasureCode);
                });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_DcUnitOfMeasureUnitOfMeasureCode",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                column: "DcUnitOfMeasureUnitOfMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_DcUnitOfMeasureUnitOfMeasureCode",
                table: "DcProducts",
                column: "DcUnitOfMeasureUnitOfMeasureCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasure_DcUnitOfMeasureUnitOfMeasureCode",
                table: "DcProducts",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasure_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasure_DcUnitOfMeasureUnitOfMeasureCode",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
