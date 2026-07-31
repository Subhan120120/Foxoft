using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallmentDueNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NotificationRule",
                keyColumn: "NotificationRuleId",
                keyValue: 26,
                columns: new[] { "ChannelCodes", "ThrottleMinutes" },
                values: new object[] { "InApp,WhatsApp", 1440 });

            migrationBuilder.InsertData(
                table: "NotificationTemplate",
                columns: new[] { "NotificationTemplateId", "BodyTemplate", "IsEnabled", "LanguageCode", "NotificationTypeCode", "TitleTemplate" },
                values: new object[] { 4, "Hörmətli müştəri! {StoreDesc} mağazasından götürdüyünüz məhsulun aylıq ödənişinə {day} gün qalıb. Əlaqə nömrəsi: {StorePhone}", true, "az", "InstallmentDueSoon", "Kredit ödənişinə xatırlatma" });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeCode", "CategoryCode", "DefaultSeverity", "DisplayOrder", "IsEnabled", "NotificationTypeDesc" },
                values: new object[] { "InstallmentDueToday", "Installment", "Warning", 265, true, "Installment Due Today" });

            migrationBuilder.InsertData(
                table: "NotificationRecipientRule",
                columns: new[] { "NotificationRecipientRuleId", "IsEnabled", "NotificationTypeCode", "RoleCode", "StoreCode" },
                values: new object[] { 40, true, "InstallmentDueToday", "Admin", null });

            migrationBuilder.InsertData(
                table: "NotificationRule",
                columns: new[] { "NotificationRuleId", "ChannelCodes", "IsEnabled", "NotificationTypeCode", "PopupMinSeverity", "RuleName", "StoreCode", "ThrottleMinutes" },
                values: new object[] { 40, "InApp,WhatsApp", true, "InstallmentDueToday", "High", "Installment Due Today", null, 1440 });

            migrationBuilder.InsertData(
                table: "NotificationTemplate",
                columns: new[] { "NotificationTemplateId", "BodyTemplate", "IsEnabled", "LanguageCode", "NotificationTypeCode", "TitleTemplate" },
                values: new object[] { 5, "{StoreDesc} mağazasından götürdüyünüz məhsulun ödənişinin bu gün vaxtıdır. Xahiş edirik, ödənişinizi vaxtında ödəyəsiniz. Əlaqə nömrəsi: {StorePhone}", true, "az", "InstallmentDueToday", "Kredit ödəniş günü" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationRecipientRule",
                keyColumn: "NotificationRecipientRuleId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "NotificationRule",
                keyColumn: "NotificationRuleId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "NotificationTemplate",
                keyColumn: "NotificationTemplateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NotificationTemplate",
                keyColumn: "NotificationTemplateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeCode",
                keyValue: "InstallmentDueToday");

            migrationBuilder.UpdateData(
                table: "NotificationRule",
                keyColumn: "NotificationRuleId",
                keyValue: 26,
                columns: new[] { "ChannelCodes", "ThrottleMinutes" },
                values: new object[] { "InApp", 60 });
        }
    }
}
