using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToWhatsAppMessageLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "TrWhatsAppMessageLogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "TrWhatsAppMessageLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MessageTemplate",
                value: "Hörmətli müştəri! {StoreDesc} mağazasından götürdüyünüz məhsulun aylıq ödənişinə {day} gün qalıb. Əlaqə nömrəsi: {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "MessageTemplate",
                value: "{StoreDesc} mağazasından götürdüyünüz məhsulun ödənişinin bu gün vaxtıdır. Xahiş edirik, ödənişinizi vaxtında ödəyəsiniz. Əlaqə nömrəsi: {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "MessageTemplate",
                value: "Yeni cihazınız xeyirli olsun. Bizi seçdiyiniz üçün təşəkkür edirik.");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "MessageTemplate",
                value: "Hörmətli müştəri, sizin kreditiniz tam bağlandı. Bizi seçdiyiniz üçün təşəkkürlər! {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "MessageTemplate",
                value: "{StoreDesc} mağazasından götürdüyünüz məhsulun {paid} AZN aylıq krediti ödəndi. Qalıq borcunuz {debit} AZN-dir.");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "MessageTemplate",
                value: "Dəyərli müştərimiz, sizi ad günü münasibətilə {StoreDesc} adından təbrik edirik.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MessageTemplate",
                value: "Hormetli, Musteri! {StoreDesc} magazasindan goturdugunuz mehsulun ayliq odenisine {day} gun qalib. Elaqe nomresi: {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "MessageTemplate",
                value: "{StoreDesc} magazasindan goturdugunuz mehsulun odenisinin bu gun vaxtidir. Xais edirik odenisinizi vaxtinda odeyesiz. Elaqe nomresi: {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "MessageTemplate",
                value: "Yeni cihasiniz xeyrli olsun. Bizi secdiyiniz ucun tesekkur edirik.");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "MessageTemplate",
                value: "Hormetli mushteri sizin kreditiniz tam baglandi. Bizi secdiyiniz ucun tesekkurler! {StorePhone}");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "MessageTemplate",
                value: "{StoreDesc} magazasindan goturdugunuz mehsulun {paid} AZN ayliq krediti odendi. Qaliq borcunuz {debit} AZNdir.");

            migrationBuilder.UpdateData(
                table: "DcNotificationSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "MessageTemplate",
                value: "Deyerli Musterimiz sizi Ad Gunu Munasibeti ile {StoreDesc} adindan Tebrik edirik.");
        }
    }
}
