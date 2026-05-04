using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class Shortcut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcShortcuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ButtonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortcutKeys = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcShortcuts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DcShortcuts",
                columns: new[] { "Id", "ButtonDescription", "ButtonName", "FormName", "ShortcutKeys" },
                values: new object[,]
                {
                    { 1, "Məhsul Axtar", "btn_ProductSearch", "UcRetailSale", "F2" },
                    { 2, "Nağd Ödəmə", "btn_Cash", "UcRetailSale", "F3" },
                    { 3, "Nağdsız Ödəmə", "btn_Cashless", "UcRetailSale", "" },
                    { 4, "Bonus Ödəmə", "btn_CustomerBonus", "UcRetailSale", "" },
                    { 5, "Sətir Endirimi", "btn_LineDiscount", "UcRetailSale", "" },
                    { 6, "Çeki Ləğv Et", "btn_CancelInvoice", "UcRetailSale", "" },
                    { 7, "Sətri Sil", "btn_DeleteLine", "UcRetailSale", "" },
                    { 8, "Satıcı", "btn_SalesPerson", "UcRetailSale", "" },
                    { 9, "Qaimə Endirimi", "btn_InvoiceDiscount", "UcRetailSale", "" },
                    { 10, "Yeni Faktura", "btn_NewInvoice", "UcRetailSale", "" },
                    { 11, "Səbətə At", "btn_AddBasket", "UcRetailSale", "" },
                    { 12, "Natamam Fakturalar", "btn_UncomplatedInvoices", "UcRetailSale", "" },
                    { 13, "Bonus Kart", "btn_LoyaltyCard", "UcRetailSale", "" },
                    { 14, "Çap", "btn_Print", "UcRetailSale", "" },
                    { 15, "Çap Görünüş", "btn_PrintPreview", "UcRetailSale", "" },
                    { 16, "Gün Sonu", "btn_ReportZ", "UcRetailSale", "" },
                    { 17, "Kampaniya Tətbiq Et", "btn_CampaignApply", "UcRetailSale", "" },
                    { 18, "Kampaniyanı Sil", "btn_CampaignDelete", "UcRetailSale", "" },
                    { 19, "Kampaniya Log", "btn_CampaignLog", "UcRetailSale", "" },
                    { 20, "Promo Kod", "btn_PromoCode", "UcRetailSale", "" },
                    { 21, "Saxla", "bBI_Save", "FormInvoice", "" },
                    { 22, "Saxla və Yeni", "bBI_SaveAndNew", "FormInvoice", "" },
                    { 23, "Saxla və Bağla", "bBI_SaveAndQuit", "FormInvoice", "F12" },
                    { 24, "Ödəniş", "bBI_Payment", "FormInvoice", "" },
                    { 25, "Yeni", "bBI_New", "FormInvoice", "Ctrl+N" },
                    { 26, "Çap Görünüşü", "bBI_reportPreview", "FormInvoice", "" },
                    { 27, "Fakturanı Sil", "bBI_DeleteInvoice", "FormInvoice", "" },
                    { 28, "Ödənişi Sil", "bBI_PaymentDelete", "FormInvoice", "" },
                    { 29, "Fakturanı Kopyala", "bBI_CopyInvoice", "FormInvoice", "" },
                    { 30, "WhatsApp Göndər", "bBI_Whatsapp", "FormInvoice", "" },
                    { 31, "Fakturanı Dəyiş", "BBI_EditInvoice", "FormInvoice", "" },
                    { 32, "Excelə İxrac", "BBI_exportXLSX", "FormInvoice", "" },
                    { 33, "Exceldən Al", "BBI_ImportExcel", "FormInvoice", "" },
                    { 34, "Sürətli Çap", "BBI_ReportPrintFast", "FormInvoice", "" },
                    { 35, "Faktura Endirimi", "BBI_InvoiceDiscount", "FormInvoice", "" },
                    { 36, "Satıcı", "BBI_Salesman", "FormInvoice", "" },
                    { 37, "Eyni Məhsulları Birləşdir", "BBI_SumSameProducts", "FormInvoice", "" },
                    { 38, "Bonus Kart", "BBI_LoyaltyCardInput", "FormInvoice", "" },
                    { 39, "Kampaniya Tətbiq Et", "bBI_CampaignApply", "FormInvoice", "" },
                    { 40, "Kampaniya Log", "bBI_CampaignLog", "FormInvoice", "" },
                    { 41, "Promo Kod", "BBI_PromoCodeCampaign", "FormInvoice", "" },
                    { 42, "Kampaniyanı Sil", "bBI_CampaignDelete", "FormInvoice", "" },
                    { 43, "Şəkillər", "BBI_picture", "FormInvoice", "" },
                    { 44, "Xərclər", "BBI_InvoiceExpenses", "FormInvoice", "" },
                    { 45, "Stok Sayım", "BBI_CountingStock", "FormInvoice", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcShortcuts_FormName_ButtonName",
                table: "DcShortcuts",
                columns: new[] { "FormName", "ButtonName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcShortcuts");
        }
    }
}
