using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PrefixNotificationEntitiesDcTr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Rename existing tables if present
IF OBJECT_ID(N'dbo.NotificationType', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.DcNotificationTypes', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationType', N'DcNotificationTypes';

IF OBJECT_ID(N'dbo.NotificationRule', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.DcNotificationRules', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationRule', N'DcNotificationRules';

IF OBJECT_ID(N'dbo.NotificationRecipientRule', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.DcNotificationRecipientRules', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationRecipientRule', N'DcNotificationRecipientRules';

IF OBJECT_ID(N'dbo.NotificationTemplate', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.DcNotificationTemplates', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationTemplate', N'DcNotificationTemplates';

IF OBJECT_ID(N'dbo.Notification', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrNotifications', N'U') IS NULL
    EXEC sp_rename N'dbo.Notification', N'TrNotifications';

IF OBJECT_ID(N'dbo.NotificationRecipient', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrNotificationRecipients', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationRecipient', N'TrNotificationRecipients';

IF OBJECT_ID(N'dbo.NotificationChannelOutbox', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrNotificationChannelOutboxes', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationChannelOutbox', N'TrNotificationChannelOutboxes';

IF OBJECT_ID(N'dbo.NotificationAudit', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TrNotificationAudits', N'U') IS NULL
    EXEC sp_rename N'dbo.NotificationAudit', N'TrNotificationAudits';

-- 2. Create tables if they do not exist
IF OBJECT_ID(N'dbo.DcNotificationTypes', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcNotificationTypes](
        [NotificationTypeCode] [nvarchar](50) NOT NULL,
        [CategoryCode] [nvarchar](30) NOT NULL,
        [NotificationTypeDesc] [nvarchar](200) NOT NULL,
        [DefaultSeverity] [nvarchar](20) NOT NULL,
        [AllowPopup] [bit] NOT NULL,
        [IsEnabled] [bit] NOT NULL,
        [DisplayOrder] [int] NOT NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationTypes_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationTypes_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_DcNotificationTypes] PRIMARY KEY CLUSTERED ([NotificationTypeCode] ASC)
    );
    CREATE NONCLUSTERED INDEX [IX_DcNotificationTypes_CategoryCode] ON [dbo].[DcNotificationTypes]([CategoryCode] ASC);
END

IF OBJECT_ID(N'dbo.DcNotificationRules', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcNotificationRules](
        [NotificationRuleId] [int] IDENTITY(1,1) NOT NULL,
        [RuleName] [nvarchar](150) NOT NULL,
        [NotificationTypeCode] [nvarchar](50) NOT NULL,
        [StoreCode] [nvarchar](30) NULL,
        [IsEnabled] [bit] NOT NULL,
        [ThrottleMinutes] [int] NOT NULL,
        [ChannelCodes] [nvarchar](200) NOT NULL,
        [PopupMinSeverity] [nvarchar](20) NOT NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationRules_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationRules_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_DcNotificationRules] PRIMARY KEY CLUSTERED ([NotificationRuleId] ASC)
    );
END

IF OBJECT_ID(N'dbo.DcNotificationRecipientRules', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcNotificationRecipientRules](
        [NotificationRecipientRuleId] [int] IDENTITY(1,1) NOT NULL,
        [NotificationTypeCode] [nvarchar](50) NOT NULL,
        [RoleCode] [nvarchar](450) NOT NULL,
        [StoreCode] [nvarchar](30) NULL,
        [IsEnabled] [bit] NOT NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationRecipientRules_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationRecipientRules_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_DcNotificationRecipientRules] PRIMARY KEY CLUSTERED ([NotificationRecipientRuleId] ASC)
    );
END

IF OBJECT_ID(N'dbo.DcNotificationTemplates', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcNotificationTemplates](
        [NotificationTemplateId] [int] IDENTITY(1,1) NOT NULL,
        [NotificationTypeCode] [nvarchar](50) NOT NULL,
        [LanguageCode] [nvarchar](10) NOT NULL,
        [TitleTemplate] [nvarchar](300) NOT NULL,
        [BodyTemplate] [nvarchar](max) NOT NULL,
        [IsEnabled] [bit] NOT NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationTemplates_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_DcNotificationTemplates_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_DcNotificationTemplates] PRIMARY KEY CLUSTERED ([NotificationTemplateId] ASC)
    );
END

IF OBJECT_ID(N'dbo.TrNotifications', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrNotifications](
        [NotificationId] [bigint] IDENTITY(1,1) NOT NULL,
        [NotificationKey] [nvarchar](200) NOT NULL,
        [NotificationTypeCode] [nvarchar](50) NOT NULL,
        [Severity] [nvarchar](20) NOT NULL,
        [Title] [nvarchar](300) NOT NULL,
        [Body] [nvarchar](max) NOT NULL,
        [EntityType] [nvarchar](50) NULL,
        [EntityKey] [nvarchar](100) NULL,
        [StoreCode] [nvarchar](30) NULL,
        [Status] [nvarchar](20) NOT NULL CONSTRAINT [DF_TrNotifications_Status] DEFAULT (N'Active'),
        [LastRaisedDate] [datetime2](7) NOT NULL CONSTRAINT [DF_TrNotifications_LastRaisedDate] DEFAULT (sysdatetime()),
        [ResolvedDate] [datetime2](7) NULL,
        [ExpireDate] [datetime2](7) NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrNotifications_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrNotifications_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_TrNotifications] PRIMARY KEY CLUSTERED ([NotificationId] ASC)
    );
END

IF OBJECT_ID(N'dbo.TrNotificationRecipients', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrNotificationRecipients](
        [NotificationRecipientId] [bigint] IDENTITY(1,1) NOT NULL,
        [NotificationId] [bigint] NOT NULL,
        [CurrAccCode] [nvarchar](30) NOT NULL,
        [Status] [nvarchar](20) NOT NULL CONSTRAINT [DF_TrNotificationRecipients_Status] DEFAULT (N'Unread'),
        [ReadDate] [datetime2](7) NULL,
        [DismissedDate] [datetime2](7) NULL,
        [SnoozedUntil] [datetime2](7) NULL,
        [LastPopupShownDate] [datetime2](7) NULL,
        [CreatedUserName] [nvarchar](20) NULL,
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrNotificationRecipients_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL,
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrNotificationRecipients_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_TrNotificationRecipients] PRIMARY KEY CLUSTERED ([NotificationRecipientId] ASC)
    );
END

IF OBJECT_ID(N'dbo.TrNotificationChannelOutboxes', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrNotificationChannelOutboxes](
        [OutboxId] [bigint] IDENTITY(1,1) NOT NULL,
        [NotificationId] [bigint] NOT NULL,
        [ChannelCode] [nvarchar](30) NOT NULL,
        [Receiver] [nvarchar](200) NOT NULL,
        [Payload] [nvarchar](max) NOT NULL,
        [Status] [nvarchar](20) NOT NULL CONSTRAINT [DF_TrNotificationChannelOutboxes_Status] DEFAULT (N'Pending'),
        [TryCount] [int] NOT NULL CONSTRAINT [DF_TrNotificationChannelOutboxes_TryCount] DEFAULT ((0)),
        [LastTryDate] [datetime2](7) NULL,
        [LastError] [nvarchar](max) NULL,
        [CreatedDate] [datetime2](7) NOT NULL CONSTRAINT [DF_TrNotificationChannelOutboxes_CreatedDate] DEFAULT (sysdatetime()),
        CONSTRAINT [PK_TrNotificationChannelOutboxes] PRIMARY KEY CLUSTERED ([OutboxId] ASC)
    );
END

IF OBJECT_ID(N'dbo.TrNotificationAudits', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrNotificationAudits](
        [NotificationAuditId] [bigint] IDENTITY(1,1) NOT NULL,
        [NotificationId] [bigint] NULL,
        [NotificationRecipientId] [bigint] NULL,
        [ActionType] [nvarchar](30) NOT NULL,
        [ActorCurrAccCode] [nvarchar](30) NULL,
        [ChannelCode] [nvarchar](30) NULL,
        [ActionDate] [datetime2](7) NOT NULL CONSTRAINT [DF_TrNotificationAudits_ActionDate] DEFAULT (sysdatetime()),
        [Note] [nvarchar](max) NULL,
        CONSTRAINT [PK_TrNotificationAudits] PRIMARY KEY CLUSTERED ([NotificationAuditId] ASC)
    );
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.DcNotificationTypes', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationType', N'U') IS NULL
    EXEC sp_rename N'dbo.DcNotificationTypes', N'NotificationType';

IF OBJECT_ID(N'dbo.DcNotificationRules', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationRule', N'U') IS NULL
    EXEC sp_rename N'dbo.DcNotificationRules', N'NotificationRule';

IF OBJECT_ID(N'dbo.DcNotificationRecipientRules', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationRecipientRule', N'U') IS NULL
    EXEC sp_rename N'dbo.DcNotificationRecipientRules', N'NotificationRecipientRule';

IF OBJECT_ID(N'dbo.DcNotificationTemplates', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationTemplate', N'U') IS NULL
    EXEC sp_rename N'dbo.DcNotificationTemplates', N'NotificationTemplate';

IF OBJECT_ID(N'dbo.TrNotifications', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.Notification', N'U') IS NULL
    EXEC sp_rename N'dbo.TrNotifications', N'Notification';

IF OBJECT_ID(N'dbo.TrNotificationRecipients', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationRecipient', N'U') IS NULL
    EXEC sp_rename N'dbo.TrNotificationRecipients', N'NotificationRecipient';

IF OBJECT_ID(N'dbo.TrNotificationChannelOutboxes', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationChannelOutbox', N'U') IS NULL
    EXEC sp_rename N'dbo.TrNotificationChannelOutboxes', N'NotificationChannelOutbox';

IF OBJECT_ID(N'dbo.TrNotificationAudits', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.NotificationAudit', N'U') IS NULL
    EXEC sp_rename N'dbo.TrNotificationAudits', N'NotificationAudit';
");
        }
    }
}
