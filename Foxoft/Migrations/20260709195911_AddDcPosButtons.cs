using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddDcPosButtons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcPosButtons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButtonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ButtonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    BackColorArgb = table.Column<int>(type: "int", nullable: true),
                    ForeColorArgb = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPosButtons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DcPosButtons",
                columns: new[] { "Id", "BackColorArgb", "ButtonDescription", "ButtonName", "ForeColorArgb", "IsVisible", "SortOrder" },
                values: new object[,]
                {
                    { 1, null, "Məhsul Axtar", "btn_ProductSearch", null, true, 0 },
                    { 2, null, "Satıcı", "btn_SalesPerson", null, true, 1 },
                    { 3, null, "Sətri Sil", "btn_DeleteLine", null, true, 2 },
                    { 4, null, "Çeki Ləğv Et", "btn_CancelInvoice", null, true, 3 },
                    { 5, null, "Natamam Fakturalar", "btn_UncomplatedInvoices", null, true, 4 },
                    { 6, null, "Çap", "btn_Print", null, true, 5 },
                    { 7, null, "Çap Görünüş", "btn_PrintPreview", null, true, 6 },
                    { 8, null, "Gün Sonu", "btn_ReportZ", null, true, 7 },
                    { 9, null, "Səbətə At", "btn_AddBasket", null, true, 8 },
                    { 10, null, "Sətir Endirimi", "btn_LineDiscount", null, true, 9 },
                    { 11, null, "Qaimə Endirimi", "btn_InvoiceDiscount", null, true, 10 },
                    { 12, null, "Bonus Kart", "btn_LoyaltyCard", null, true, 11 },
                    { 13, null, "Faktura Açıqlama", "btn_Desc", null, true, 12 },
                    { 14, null, "Sətir Açıqlama", "btn_LineDesc", null, true, 13 },
                    { 15, null, "Kampaniya Tətbiq Et", "btn_CampaignApply", null, true, 14 },
                    { 16, null, "Kampaniyanı Sil", "btn_CampaignDelete", null, true, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcPosButtons_ButtonName",
                table: "DcPosButtons",
                column: "ButtonName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcPosButtons");
        }
    }
}
