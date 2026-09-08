using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDcMessagingSettings_MigrateToNotificationTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Ensure AppSetting has InstallmentReminderDaysBefore column in its own batch
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.AppSettings', 'InstallmentReminderDaysBefore') IS NULL
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [InstallmentReminderDaysBefore] [int] NULL CONSTRAINT [DF_AppSettings_InstallmentReminderDaysBefore] DEFAULT ((2));
END
");

            // 2. Migrate notification data and drop DcMessagingSettings
            migrationBuilder.Sql(@"
-- Ensure NotificationType has ProductPurchase
IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationType] WHERE [NotificationTypeCode] = N'ProductPurchase')
BEGIN
    INSERT INTO [dbo].[NotificationType] ([NotificationTypeCode], [CategoryCode], [NotificationTypeDesc], [DefaultSeverity], [AllowPopup], [IsEnabled], [DisplayOrder], [CreatedUserName], [CreatedDate], [LastUpdatedUserName], [LastUpdatedDate])
    VALUES (N'ProductPurchase', N'Sale', N'Product Purchase', N'Info', 0, 1, 155, N'System', GETDATE(), N'System', GETDATE());
END

-- Ensure NotificationRule has ProductPurchase
IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationRule] WHERE [NotificationTypeCode] = N'ProductPurchase')
BEGIN
    INSERT INTO [dbo].[NotificationRule] ([RuleName], [NotificationTypeCode], [StoreCode], [IsEnabled], [ThrottleMinutes], [ChannelCodes], [PopupMinSeverity], [CreatedUserName], [CreatedDate], [LastUpdatedUserName], [LastUpdatedDate])
    VALUES (N'Product Purchase', N'ProductPurchase', NULL, 1, 60, N'InApp,WhatsApp', N'High', N'System', GETDATE(), N'System', GETDATE());
END

-- Ensure NotificationRules for customer messaging types include WhatsApp
UPDATE [dbo].[NotificationRule]
SET [ChannelCodes] = CASE 
    WHEN [ChannelCodes] IS NULL OR [ChannelCodes] = '' THEN N'InApp,WhatsApp'
    WHEN [ChannelCodes] NOT LIKE N'%WhatsApp%' THEN [ChannelCodes] + N',WhatsApp'
    ELSE [ChannelCodes] END
WHERE [NotificationTypeCode] IN (N'InstallmentDueSoon', N'InstallmentDueToday', N'InstallmentPaid', N'CreditClosed', N'ProductPurchase', N'CustomerBirthday');

-- Migrate data from DcMessagingSettings if table exists, then drop it
IF OBJECT_ID(N'dbo.DcMessagingSettings', N'U') IS NOT NULL
BEGIN
    DECLARE @DaysBefore INT = (SELECT TOP 1 [DaysBefore] FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N'InstallmentReminder' AND [DaysBefore] IS NOT NULL);
    IF @DaysBefore IS NOT NULL
    BEGIN
        EXEC sp_executesql N'UPDATE [dbo].[AppSettings] SET [InstallmentReminderDaysBefore] = @DaysBefore WHERE [Id] = 1', N'@DaysBefore INT', @DaysBefore = @DaysBefore;
    END

    EXEC(N'
    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''InstallmentDueSoon'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Kredit ödənişinə xatırlatma'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''InstallmentReminder''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''InstallmentDueToday'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Kredit ödəniş günü'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''InstallmentDueDay''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''ProductPurchase'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Məhsul satışı'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''ProductPurchase''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''CreditClosed'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Kredit bağlandı'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''CreditClosed''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''InstallmentPaid'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Kredit ödənişi'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''CreditPayment''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    MERGE [dbo].[NotificationTemplate] AS target
    USING (
        SELECT N''CustomerBirthday'' AS NotificationTypeCode, N''az'' AS LanguageCode, N''Ad günü təbriki'' AS TitleTemplate,
               MessageTemplate AS BodyTemplate, IsEnabled
        FROM [dbo].[DcMessagingSettings] WHERE [MessagingType] = N''Birthday''
    ) AS source
    ON (target.NotificationTypeCode = source.NotificationTypeCode AND target.LanguageCode = source.LanguageCode)
    WHEN MATCHED THEN
        UPDATE SET target.BodyTemplate = source.BodyTemplate, target.IsEnabled = source.IsEnabled
    WHEN NOT MATCHED THEN
        INSERT (NotificationTypeCode, LanguageCode, TitleTemplate, BodyTemplate, IsEnabled, CreatedDate, LastUpdatedDate)
        VALUES (source.NotificationTypeCode, source.LanguageCode, source.TitleTemplate, source.BodyTemplate, source.IsEnabled, GETDATE(), GETDATE());

    DROP TABLE [dbo].[DcMessagingSettings];
    ');
END

-- Ensure default templates exist if not yet created
IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationTemplate] WHERE [NotificationTypeCode] = N'ProductPurchase' AND [LanguageCode] = N'az')
    INSERT INTO [dbo].[NotificationTemplate] ([NotificationTypeCode], [LanguageCode], [TitleTemplate], [BodyTemplate], [IsEnabled], [CreatedDate], [LastUpdatedDate])
    VALUES (N'ProductPurchase', N'az', N'Məhsul satışı', N'Yeni cihazınız xeyirli olsun. Bizi seçdiyiniz üçün təşəkkür edirik.', 1, GETDATE(), GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationTemplate] WHERE [NotificationTypeCode] = N'CreditClosed' AND [LanguageCode] = N'az')
    INSERT INTO [dbo].[NotificationTemplate] ([NotificationTypeCode], [LanguageCode], [TitleTemplate], [BodyTemplate], [IsEnabled], [CreatedDate], [LastUpdatedDate])
    VALUES (N'CreditClosed', N'az', N'Kredit bağlandı', N'Hörmətli müştəri, sizin kreditiniz tam bağlandı. Bizi seçdiyiniz üçün təşəkkürlər! {StorePhone}', 1, GETDATE(), GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationTemplate] WHERE [NotificationTypeCode] = N'InstallmentPaid' AND [LanguageCode] = N'az')
    INSERT INTO [dbo].[NotificationTemplate] ([NotificationTypeCode], [LanguageCode], [TitleTemplate], [BodyTemplate], [IsEnabled], [CreatedDate], [LastUpdatedDate])
    VALUES (N'InstallmentPaid', N'az', N'Kredit ödənişi', N'{StoreDesc} mağazasından götürdüyünüz məhsulun {paid} AZN aylıq krediti ödəndi. Qalıq borcunuz {debit} AZN-dir.', 1, GETDATE(), GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[NotificationTemplate] WHERE [NotificationTypeCode] = N'CustomerBirthday' AND [LanguageCode] = N'az')
    INSERT INTO [dbo].[NotificationTemplate] ([NotificationTypeCode], [LanguageCode], [TitleTemplate], [BodyTemplate], [IsEnabled], [CreatedDate], [LastUpdatedDate])
    VALUES (N'CustomerBirthday', N'az', N'Ad günü təbriki', N'Dəyərli müştərimiz, sizi ad günü münasibətilə {StoreDesc} adından təbrik edirik.', 1, GETDATE(), GETDATE());
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.DcMessagingSettings', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcMessagingSettings](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [MessagingType] [nvarchar](50) NOT NULL,
        [IsEnabled] [bit] NOT NULL,
        [DaysBefore] [int] NULL,
        [MessageTemplate] [nvarchar](1000) NULL,
        CONSTRAINT [PK_DcMessagingSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
");
        }
    }
}
