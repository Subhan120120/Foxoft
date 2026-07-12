using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignAndPromoButtons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcPosButtons",
                columns: new[] { "Id", "BackColorArgb", "ButtonDescription", "ButtonName", "ForeColorArgb", "IsVisible", "SortOrder" },
                values: new object[,]
                {
                    { 17, null, "Kampaniya Log", "btn_CampaignLog", null, false, 16 },
                    { 18, null, "Promo Kod", "btn_PromoCode", null, false, 17 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPosButtons",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DcPosButtons",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
