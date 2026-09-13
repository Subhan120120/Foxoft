using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddDcBackupJobsAndTrBackupLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Create DcBackupJobs table
IF OBJECT_ID(N'dbo.DcBackupJobs', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcBackupJobs](
        [BackupJobId] [int] IDENTITY(1,1) NOT NULL,
        [JobName] [nvarchar](100) NOT NULL,
        [IsEnabled] [bit] NOT NULL CONSTRAINT [DF_DcBackupJobs_IsEnabled] DEFAULT (1),
        [DatabaseNames] [nvarchar](1000) NOT NULL CONSTRAINT [DF_DcBackupJobs_DatabaseNames] DEFAULT (N'*'),
        [BackupType] [tinyint] NOT NULL CONSTRAINT [DF_DcBackupJobs_BackupType] DEFAULT (0),
        [CompressionType] [tinyint] NOT NULL CONSTRAINT [DF_DcBackupJobs_CompressionType] DEFAULT (1),
        [LocalPath] [nvarchar](500) NOT NULL,
        [UploadToCloud] [bit] NOT NULL CONSTRAINT [DF_DcBackupJobs_UploadToCloud] DEFAULT (0),
        [CloudProvider] [nvarchar](50) NOT NULL CONSTRAINT [DF_DcBackupJobs_CloudProvider] DEFAULT (N'GoogleDrive'),
        [CloudFolderId] [nvarchar](200) NULL,
        [RetentionDays] [int] NOT NULL CONSTRAINT [DF_DcBackupJobs_RetentionDays] DEFAULT (7),
        [ScheduleType] [tinyint] NOT NULL CONSTRAINT [DF_DcBackupJobs_ScheduleType] DEFAULT (1),
        [IntervalMinutes] [int] NOT NULL CONSTRAINT [DF_DcBackupJobs_IntervalMinutes] DEFAULT (60),
        [StartTime] [time](7) NOT NULL CONSTRAINT [DF_DcBackupJobs_StartTime] DEFAULT ('09:00:00'),
        [EndTime] [time](7) NOT NULL CONSTRAINT [DF_DcBackupJobs_EndTime] DEFAULT ('18:00:00'),
        [DailyTime] [time](7) NOT NULL CONSTRAINT [DF_DcBackupJobs_DailyTime] DEFAULT ('23:00:00'),
        [SelectedDaysOfWeek] [nvarchar](50) NOT NULL CONSTRAINT [DF_DcBackupJobs_SelectedDaysOfWeek] DEFAULT (N'1,2,3,4,5,6,7'),
        [LastRunTime] [datetime2](7) NULL,
        [NextRunTime] [datetime2](7) NULL,
        [LastStatus] [nvarchar](50) NOT NULL CONSTRAINT [DF_DcBackupJobs_LastStatus] DEFAULT (N'Pending'),
        [LastErrorMessage] [nvarchar](2000) NULL,
        [CreatedDate] [datetime2](7) NOT NULL CONSTRAINT [DF_DcBackupJobs_CreatedDate] DEFAULT (sysdatetime()),
        [ModifiedDate] [datetime2](7) NULL,
        CONSTRAINT [PK_DcBackupJobs] PRIMARY KEY CLUSTERED ([BackupJobId] ASC)
    );
END

-- 2. Create TrBackupLogs table
IF OBJECT_ID(N'dbo.TrBackupLogs', N'U') IS NOT NULL AND COL_LENGTH('dbo.TrBackupLogs', 'BackupJobId') IS NULL
BEGIN
    DROP TABLE [dbo].[TrBackupLogs];
END

IF OBJECT_ID(N'dbo.TrBackupLogs', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrBackupLogs](
        [BackupLogId] [bigint] IDENTITY(1,1) NOT NULL,
        [BackupJobId] [int] NOT NULL,
        [JobName] [nvarchar](100) NOT NULL,
        [DatabaseName] [nvarchar](128) NOT NULL,
        [BackupType] [nvarchar](20) NOT NULL,
        [BackupFileName] [nvarchar](260) NOT NULL,
        [BackupFilePath] [nvarchar](500) NOT NULL,
        [FileSizeBytes] [bigint] NOT NULL,
        [CompressedSizeBytes] [bigint] NULL,
        [IsUploadedToCloud] [bit] NOT NULL,
        [CloudFileId] [nvarchar](200) NULL,
        [StartTime] [datetime2](7) NOT NULL,
        [EndTime] [datetime2](7) NOT NULL,
        [DurationSeconds] [float] NOT NULL,
        [IsSuccess] [bit] NOT NULL,
        [ErrorMessage] [nvarchar](4000) NULL,
        CONSTRAINT [PK_TrBackupLogs] PRIMARY KEY CLUSTERED ([BackupLogId] ASC),
        CONSTRAINT [FK_TrBackupLogs_DcBackupJobs] FOREIGN KEY([BackupJobId]) REFERENCES [dbo].[DcBackupJobs]([BackupJobId]) ON DELETE CASCADE
    );

    CREATE NONCLUSTERED INDEX [IX_TrBackupLogs_BackupJobId] ON [dbo].[TrBackupLogs]([BackupJobId] ASC);
    CREATE NONCLUSTERED INDEX [IX_TrBackupLogs_StartTime] ON [dbo].[TrBackupLogs]([StartTime] DESC);
END

-- 3. Add columns to AppSettings if missing
IF COL_LENGTH('dbo.AppSettings', 'AutoBackupEnabled') IS NULL
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [AutoBackupEnabled] [bit] NOT NULL CONSTRAINT [DF_AppSettings_AutoBackupEnabled] DEFAULT (1);
END

IF COL_LENGTH('dbo.AppSettings', 'RarExePath') IS NULL
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [RarExePath] [nvarchar](500) NULL;
END

-- 4. Add Claims if missing
IF NOT EXISTS (SELECT 1 FROM [dbo].[DcClaims] WHERE [ClaimCode] = 'BackupSettings')
BEGIN
    INSERT INTO [dbo].[DcClaims] ([ClaimCode], [ClaimDesc], [ClaimTypeId], [CategoryId])
    VALUES ('BackupSettings', N'Baza Nüsxələnməsi (Backup)', 1, 15);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[TrRoleClaims] WHERE [ClaimCode] = 'BackupSettings' AND [RoleCode] = 'Admin')
BEGIN
    DECLARE @nextRoleClaimId INT = ISNULL((SELECT MAX(RoleClaimId) FROM [dbo].[TrRoleClaims]), 0) + 1;
    INSERT INTO [dbo].[TrRoleClaims] ([RoleClaimId], [RoleCode], [ClaimCode])
    VALUES (@nextRoleClaimId, 'Admin', 'BackupSettings');
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.TrBackupLogs', N'U') IS NOT NULL
    DROP TABLE [dbo].[TrBackupLogs];

IF OBJECT_ID(N'dbo.DcBackupJobs', N'U') IS NOT NULL
    DROP TABLE [dbo].[DcBackupJobs];
");
        }
    }
}
