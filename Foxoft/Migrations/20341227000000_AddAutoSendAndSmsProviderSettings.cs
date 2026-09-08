using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoSendAndSmsProviderSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. AppSettings additions
IF COL_LENGTH('dbo.AppSettings', 'AutoSendUnsentMessages') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [AutoSendUnsentMessages] [bit] NOT NULL CONSTRAINT [DF_AppSettings_AutoSendUnsentMessages] DEFAULT ((1));

IF COL_LENGTH('dbo.AppSettings', 'AutoSendIntervalSeconds') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [AutoSendIntervalSeconds] [int] NOT NULL CONSTRAINT [DF_AppSettings_AutoSendIntervalSeconds] DEFAULT ((30));

IF COL_LENGTH('dbo.AppSettings', 'AutoSendMaxRetries') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [AutoSendMaxRetries] [int] NOT NULL CONSTRAINT [DF_AppSettings_AutoSendMaxRetries] DEFAULT ((5));

-- 2. DcSmsProviderSettings table
IF OBJECT_ID(N'dbo.DcSmsProviderSettings', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcSmsProviderSettings](
        [Id] [int] NOT NULL,
        [ProviderType] [nvarchar](50) NOT NULL CONSTRAINT [DF_DcSmsProviderSettings_ProviderType] DEFAULT (N'GenericHttp'),
        [ServerUrl] [nvarchar](500) NULL,
        [ApiKey] [nvarchar](250) NULL,
        [SenderTitle] [nvarchar](50) NULL,
        [Username] [nvarchar](100) NULL,
        [Password] [nvarchar](100) NULL,
        [IsEnabled] [bit] NOT NULL CONSTRAINT [DF_DcSmsProviderSettings_IsEnabled] DEFAULT ((0)),
        CONSTRAINT [PK_DcSmsProviderSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
    );

    INSERT INTO [dbo].[DcSmsProviderSettings] ([Id], [ProviderType], [IsEnabled])
    VALUES (1, N'GenericHttp', 0);
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.DcSmsProviderSettings', N'U') IS NOT NULL
    DROP TABLE [dbo].[DcSmsProviderSettings];

IF COL_LENGTH('dbo.AppSettings', 'AutoSendUnsentMessages') IS NOT NULL
    ALTER TABLE [dbo].[AppSettings] DROP CONSTRAINT [DF_AppSettings_AutoSendUnsentMessages], COLUMN [AutoSendUnsentMessages];

IF COL_LENGTH('dbo.AppSettings', 'AutoSendIntervalSeconds') IS NOT NULL
    ALTER TABLE [dbo].[AppSettings] DROP CONSTRAINT [DF_AppSettings_AutoSendIntervalSeconds], COLUMN [AutoSendIntervalSeconds];

IF COL_LENGTH('dbo.AppSettings', 'AutoSendMaxRetries') IS NOT NULL
    ALTER TABLE [dbo].[AppSettings] DROP CONSTRAINT [DF_AppSettings_AutoSendMaxRetries], COLUMN [AutoSendMaxRetries];
");
        }
    }
}
