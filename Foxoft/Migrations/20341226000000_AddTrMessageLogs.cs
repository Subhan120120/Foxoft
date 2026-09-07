using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddTrMessageLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Handle TrWhatsAppMessageLogs to TrMessageLogs transition
IF OBJECT_ID(N'dbo.TrWhatsAppMessageLogs', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrMessageLogs', N'U') IS NULL
BEGIN
    EXEC sp_rename N'dbo.TrWhatsAppMessageLogs', N'TrMessageLogs';
    IF COL_LENGTH('dbo.TrMessageLogs', 'WhatsAppMessageLogId') IS NOT NULL
        EXEC sp_rename N'dbo.TrMessageLogs.WhatsAppMessageLogId', N'MessageLogId', 'COLUMN';
END
ELSE IF OBJECT_ID(N'dbo.TrMessageLogs', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrMessageLogs](
        [MessageLogId] [uniqueidentifier] NOT NULL,
        [DocumentHeaderId] [uniqueidentifier] NULL,
        [ReceiverPhoneNumber] [nvarchar](30) NULL,
        [ChannelCode] [nvarchar](30) NOT NULL CONSTRAINT [DF_TrMessageLogs_ChannelCode] DEFAULT (N'WhatsApp'),
        [MessageType] [nvarchar](50) NULL,
        [Message] [nvarchar](1000) NULL,
        [IsSuccessful] [bit] NOT NULL,
        [Sender] [nvarchar](30) NULL,
        [CurrAccCode] [nvarchar](30) NULL,
        [ImageFileName] [nvarchar](100) NULL,
        [TryCount] [int] NOT NULL CONSTRAINT [DF_TrMessageLogs_TryCount] DEFAULT ((0)),
        [LastTryDate] [datetime2](7) NULL,
        [LastError] [nvarchar](max) NULL,
        [CreatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrMessageLogs_CreatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrMessageLogs_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrMessageLogs_LastUpdatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrMessageLogs_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_TrMessageLogs] PRIMARY KEY CLUSTERED ([MessageLogId] ASC)
    );
END

IF OBJECT_ID(N'dbo.TrWhatsAppMessageLogs', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrMessageLogs', N'U') IS NOT NULL
BEGIN
    -- Drop constraints referencing TrWhatsAppMessageLogs if any
    IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrWhatsAppMessageLogs_DcCurrAccs_CurrAccCode')
        ALTER TABLE [dbo].[TrWhatsAppMessageLogs] DROP CONSTRAINT [FK_TrWhatsAppMessageLogs_DcCurrAccs_CurrAccCode];
    IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrWhatsAppMessageLogs_DcCurrAccs_Sender')
        ALTER TABLE [dbo].[TrWhatsAppMessageLogs] DROP CONSTRAINT [FK_TrWhatsAppMessageLogs_DcCurrAccs_Sender];
    DROP TABLE [dbo].[TrWhatsAppMessageLogs];
END

-- 2. Ensure columns exist on TrMessageLogs
IF COL_LENGTH('dbo.TrMessageLogs', 'ChannelCode') IS NULL
    ALTER TABLE [dbo].[TrMessageLogs] ADD [ChannelCode] [nvarchar](30) NULL;

IF COL_LENGTH('dbo.TrMessageLogs', 'TryCount') IS NULL
    ALTER TABLE [dbo].[TrMessageLogs] ADD [TryCount] [int] NOT NULL CONSTRAINT [DF_TrMessageLogs_TryCount] DEFAULT ((0));

IF COL_LENGTH('dbo.TrMessageLogs', 'LastTryDate') IS NULL
    ALTER TABLE [dbo].[TrMessageLogs] ADD [LastTryDate] [datetime2](7) NULL;

IF COL_LENGTH('dbo.TrMessageLogs', 'LastError') IS NULL
    ALTER TABLE [dbo].[TrMessageLogs] ADD [LastError] [nvarchar](max) NULL;

-- 3. Backfill ChannelCode
UPDATE [dbo].[TrMessageLogs] SET [ChannelCode] = N'WhatsApp' WHERE [ChannelCode] IS NULL;

-- 4. Foreign keys and indexes for TrMessageLogs
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrMessageLogs_DcCurrAccs_CurrAccCode')
    ALTER TABLE [dbo].[TrMessageLogs] WITH CHECK ADD CONSTRAINT [FK_TrMessageLogs_DcCurrAccs_CurrAccCode] FOREIGN KEY([CurrAccCode]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]);

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrMessageLogs_DcCurrAccs_Sender')
    ALTER TABLE [dbo].[TrMessageLogs] WITH CHECK ADD CONSTRAINT [FK_TrMessageLogs_DcCurrAccs_Sender] FOREIGN KEY([Sender]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_TrMessageLogs_CurrAccCode' AND object_id = OBJECT_ID(N'dbo.TrMessageLogs'))
    CREATE NONCLUSTERED INDEX [IX_TrMessageLogs_CurrAccCode] ON [dbo].[TrMessageLogs]([CurrAccCode]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_TrMessageLogs_Sender' AND object_id = OBJECT_ID(N'dbo.TrMessageLogs'))
    CREATE NONCLUSTERED INDEX [IX_TrMessageLogs_Sender] ON [dbo].[TrMessageLogs]([Sender]);

-- 5. Ensure AppSettings columns exist
IF COL_LENGTH('dbo.AppSettings', 'UseInvoiceExpenses') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [UseInvoiceExpenses] [bit] NOT NULL CONSTRAINT [DF_AppSettings_UseInvoiceExpenses] DEFAULT ((1));

IF COL_LENGTH('dbo.AppSettings', 'UseLoyalty') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [UseLoyalty] [bit] NOT NULL CONSTRAINT [DF_AppSettings_UseLoyalty] DEFAULT ((1));

IF COL_LENGTH('dbo.AppSettings', 'UseWhatsApp') IS NULL
    ALTER TABLE [dbo].[AppSettings] ADD [UseWhatsApp] [bit] NOT NULL CONSTRAINT [DF_AppSettings_UseWhatsApp] DEFAULT ((1));

-- 6. Loyalty Programs Note nullable
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.DcLoyaltyPrograms') AND name = 'Note' AND is_nullable = 0)
    ALTER TABLE [dbo].[DcLoyaltyPrograms] ALTER COLUMN [Note] [nvarchar](200) NULL;

-- 7. TrPayrollLines foreign key with cascade
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId')
    ALTER TABLE [dbo].[TrPayrollLines] DROP CONSTRAINT [FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId];

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId')
    ALTER TABLE [dbo].[TrPayrollLines] WITH CHECK ADD CONSTRAINT [FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId] FOREIGN KEY([PayrollHeaderId]) REFERENCES [dbo].[TrPayrollHeaders] ([Id]) ON DELETE CASCADE;

-- 8. Seed claims and role claims
IF NOT EXISTS (SELECT * FROM [dbo].[DcClaims] WHERE [ClaimCode] = 'MessageLog')
    INSERT INTO [dbo].[DcClaims] ([ClaimCode], [CategoryId], [ClaimDesc], [ClaimTypeId]) VALUES ('MessageLog', 15, N'Mesaj Jurnalı', 1);

UPDATE [dbo].[TrRoleClaims] SET [ClaimCode] = 'MessageLog' WHERE [ClaimCode] = 'WhatsAppMessageLog';

DELETE FROM [dbo].[DcClaims] WHERE [ClaimCode] = 'WhatsAppMessageLog';

IF NOT EXISTS (SELECT * FROM [dbo].[TrRoleClaims] WHERE [RoleClaimId] = 69)
BEGIN
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] ON;
    INSERT INTO [dbo].[TrRoleClaims] ([RoleClaimId], [ClaimCode], [RoleCode]) VALUES (69, 'MessageLog', 'Admin');
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] OFF;
END
ELSE
BEGIN
    UPDATE [dbo].[TrRoleClaims] SET [ClaimCode] = 'MessageLog' WHERE [RoleClaimId] = 69;
END

IF NOT EXISTS (SELECT * FROM [dbo].[TrRoleClaims] WHERE [RoleClaimId] = 212)
BEGIN
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] ON;
    INSERT INTO [dbo].[TrRoleClaims] ([RoleClaimId], [ClaimCode], [RoleCode]) VALUES (212, 'BonusEarn', 'Admin');
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] OFF;
END

IF NOT EXISTS (SELECT * FROM [dbo].[TrRoleClaims] WHERE [RoleClaimId] = 213)
BEGIN
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] ON;
    INSERT INTO [dbo].[TrRoleClaims] ([RoleClaimId], [ClaimCode], [RoleCode]) VALUES (213, 'BonusPayment', 'Admin');
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] OFF;
END

IF NOT EXISTS (SELECT * FROM [dbo].[TrRoleClaims] WHERE [RoleClaimId] = 214)
BEGIN
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] ON;
    INSERT INTO [dbo].[TrRoleClaims] ([RoleClaimId], [ClaimCode], [RoleCode]) VALUES (214, 'LoyaltyPrograms', 'Admin');
    SET IDENTITY_INSERT [dbo].[TrRoleClaims] OFF;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.TrMessageLogs', N'U') IS NOT NULL
    DROP TABLE [dbo].[TrMessageLogs];

DELETE FROM [dbo].[DcClaims] WHERE [ClaimCode] = 'MessageLog';

IF EXISTS (SELECT * FROM [dbo].[TrRoleClaims] WHERE [RoleClaimId] = 69)
    UPDATE [dbo].[TrRoleClaims] SET [ClaimCode] = 'WhatsAppMessageLog' WHERE [RoleClaimId] = 69;
");
        }
    }
}