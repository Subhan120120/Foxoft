using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    [Migration("20260730120000_AddInstallmentDueNotificationsManual")]
    public partial class AddInstallmentDueNotificationsManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM dbo.NotificationType WHERE NotificationTypeCode = N'InstallmentDueToday')
BEGIN
    INSERT INTO dbo.NotificationType
        (NotificationTypeCode, CategoryCode, NotificationTypeDesc, DefaultSeverity, AllowPopup, IsEnabled, DisplayOrder, CreatedUserName, CreatedDate, LastUpdatedUserName, LastUpdatedDate)
    VALUES
        (N'InstallmentDueToday', N'Installment', N'Installment Due Today', N'Warning', CAST(0 AS bit), CAST(1 AS bit), 265, SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE(), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE());
END;

IF NOT EXISTS (SELECT 1 FROM dbo.NotificationRule WHERE NotificationTypeCode = N'InstallmentDueToday' AND StoreCode IS NULL)
BEGIN
    INSERT INTO dbo.NotificationRule
        (RuleName, NotificationTypeCode, StoreCode, IsEnabled, ThrottleMinutes, ChannelCodes, PopupMinSeverity, CreatedUserName, CreatedDate, LastUpdatedUserName, LastUpdatedDate)
    VALUES
        (N'Installment Due Today', N'InstallmentDueToday', NULL, CAST(1 AS bit), 1440, N'InApp,WhatsApp', N'High', SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE(), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE());
END;

UPDATE dbo.NotificationRule
SET
    ChannelCodes = N'InApp,WhatsApp',
    ThrottleMinutes = 1440,
    LastUpdatedUserName = SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20),
    LastUpdatedDate = GETDATE()
WHERE NotificationTypeCode = N'InstallmentDueSoon'
  AND StoreCode IS NULL;

IF NOT EXISTS (SELECT 1 FROM dbo.NotificationRecipientRule WHERE NotificationTypeCode = N'InstallmentDueToday' AND RoleCode = N'Admin' AND StoreCode IS NULL)
BEGIN
    INSERT INTO dbo.NotificationRecipientRule
        (NotificationTypeCode, RoleCode, StoreCode, IsEnabled, CreatedUserName, CreatedDate, LastUpdatedUserName, LastUpdatedDate)
    VALUES
        (N'InstallmentDueToday', N'Admin', NULL, CAST(1 AS bit), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE(), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE());
END;

IF EXISTS (SELECT 1 FROM dbo.NotificationTemplate WHERE NotificationTypeCode = N'InstallmentDueSoon' AND LanguageCode = N'az')
BEGIN
    UPDATE dbo.NotificationTemplate
    SET
        TitleTemplate = N'Kredit ödənişinə xatırlatma',
        BodyTemplate = N'Hörmətli müştəri! {StoreDesc} mağazasından götürdüyünüz məhsulun aylıq ödənişinə {day} gün qalıb. Əlaqə nömrəsi: {StorePhone}',
        IsEnabled = CAST(1 AS bit),
        LastUpdatedUserName = SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20),
        LastUpdatedDate = GETDATE()
    WHERE NotificationTypeCode = N'InstallmentDueSoon'
      AND LanguageCode = N'az';
END
ELSE
BEGIN
    INSERT INTO dbo.NotificationTemplate
        (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedUserName, CreatedDate, LastUpdatedUserName, LastUpdatedDate)
    VALUES
        (N'InstallmentDueSoon', N'az', N'Kredit ödənişinə xatırlatma', N'Hörmətli müştəri! {StoreDesc} mağazasından götürdüyünüz məhsulun aylıq ödənişinə {day} gün qalıb. Əlaqə nömrəsi: {StorePhone}', CAST(1 AS bit), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE(), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE());
END;

IF EXISTS (SELECT 1 FROM dbo.NotificationTemplate WHERE NotificationTypeCode = N'InstallmentDueToday' AND LanguageCode = N'az')
BEGIN
    UPDATE dbo.NotificationTemplate
    SET
        TitleTemplate = N'Kredit ödəniş günü',
        BodyTemplate = N'{StoreDesc} mağazasından götürdüyünüz məhsulun ödənişinin bu gün vaxtıdır. Xahiş edirik, ödənişinizi vaxtında ödəyəsiniz. Əlaqə nömrəsi: {StorePhone}',
        IsEnabled = CAST(1 AS bit),
        LastUpdatedUserName = SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20),
        LastUpdatedDate = GETDATE()
    WHERE NotificationTypeCode = N'InstallmentDueToday'
      AND LanguageCode = N'az';
END
ELSE
BEGIN
    INSERT INTO dbo.NotificationTemplate
        (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedUserName, CreatedDate, LastUpdatedUserName, LastUpdatedDate)
    VALUES
        (N'InstallmentDueToday', N'az', N'Kredit ödəniş günü', N'{StoreDesc} mağazasından götürdüyünüz məhsulun ödənişinin bu gün vaxtıdır. Xahiş edirik, ödənişinizi vaxtında ödəyəsiniz. Əlaqə nömrəsi: {StorePhone}', CAST(1 AS bit), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE(), SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20), GETDATE());
END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.NotificationTemplate
WHERE NotificationTypeCode = N'InstallmentDueToday'
  AND LanguageCode = N'az';

DELETE FROM dbo.NotificationRecipientRule
WHERE NotificationTypeCode = N'InstallmentDueToday'
  AND RoleCode = N'Admin'
  AND StoreCode IS NULL;

DELETE FROM dbo.NotificationRule
WHERE NotificationTypeCode = N'InstallmentDueToday'
  AND StoreCode IS NULL;

DELETE FROM dbo.NotificationType
WHERE NotificationTypeCode = N'InstallmentDueToday';

UPDATE dbo.NotificationRule
SET
    ChannelCodes = N'InApp',
    ThrottleMinutes = 60,
    LastUpdatedUserName = SUBSTRING(SUSER_NAME(), PATINDEX(N'%\%', SUSER_NAME()) + 1, 20),
    LastUpdatedDate = GETDATE()
WHERE NotificationTypeCode = N'InstallmentDueSoon'
  AND StoreCode IS NULL;");
        }
    }
}
