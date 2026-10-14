using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261014104000_AddTrUserStores")]
    public partial class AddTrUserStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Create TrUserStores table
IF OBJECT_ID(N'dbo.TrUserStores', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrUserStores](
        [UserStoreId] [int] IDENTITY(1,1) NOT NULL,
        [UserName] [nvarchar](30) NOT NULL,
        [StoreCode] [nvarchar](30) NOT NULL,
        [CreatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrUserStores_CreatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrUserStores_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrUserStores_LastUpdatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrUserStores_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_TrUserStores] PRIMARY KEY CLUSTERED ([UserStoreId] ASC),
        CONSTRAINT [FK_TrUserStores_DcCurrAccs_StoreCode] FOREIGN KEY([StoreCode]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]) ON DELETE CASCADE
    );

    CREATE UNIQUE NONCLUSTERED INDEX [IX_TrUserStores_UserName] ON [dbo].[TrUserStores] ([UserName] ASC);
    CREATE NONCLUSTERED INDEX [IX_TrUserStores_StoreCode] ON [dbo].[TrUserStores] ([StoreCode] ASC);

    IF EXISTS (SELECT 1 FROM [dbo].[DcCurrAccs] WHERE [CurrAccCode] = 'MGZ01')
    BEGIN
        SET IDENTITY_INSERT [dbo].[TrUserStores] ON;
        INSERT INTO [dbo].[TrUserStores] ([UserStoreId], [UserName], [StoreCode]) VALUES
        (1, N'admin', N'MGZ01'),
        (2, N'C-000001', N'MGZ01'),
        (3, N'CA-1', N'MGZ01');
        SET IDENTITY_INSERT [dbo].[TrUserStores] OFF;
    END
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.TrUserStores', N'U') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[TrUserStores];
END
");
        }
    }
}
