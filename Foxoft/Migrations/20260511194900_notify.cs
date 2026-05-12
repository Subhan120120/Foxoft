using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class notify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcNotificationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DaysBefore = table.Column<int>(type: "int", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcNotificationSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DcNotificationSettings",
                columns: new[] { "Id", "DaysBefore", "IsEnabled", "MessageTemplate", "NotificationType" },
                values: new object[,]
                {
                    { 1, 2, false, "Hormetli, Musteri! {StoreDesc} magazasindan goturdugunuz mehsulun ayliq odenisine {day} gun qalib. Elaqe nomresi: {StorePhone}", "InstallmentReminder" },
                    { 2, null, false, "{StoreDesc} magazasindan goturdugunuz mehsulun odenisinin bu gun vaxtidir. Xais edirik odenisinizi vaxtinda odeyesiz. Elaqe nomresi: {StorePhone}", "InstallmentDueDay" },
                    { 3, null, false, "Yeni cihasiniz xeyrli olsun. Bizi secdiyiniz ucun tesekkur edirik.", "ProductPurchase" },
                    { 4, null, false, "Hormetli mushteri sizin kreditiniz tam baglandi. Bizi secdiyiniz ucun tesekkurler! {StorePhone}", "CreditClosed" },
                    { 5, null, false, "{StoreDesc} magazasindan goturdugunuz mehsulun {paid} AZN ayliq krediti odendi. Qaliq borcunuz {debit} AZNdir.", "CreditPayment" },
                    { 6, null, false, "Deyerli Musterimiz sizi Ad Gunu Munasibeti ile {StoreDesc} adindan Tebrik edirik.", "Birthday" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcNotificationSettings");
        }
    }
}
