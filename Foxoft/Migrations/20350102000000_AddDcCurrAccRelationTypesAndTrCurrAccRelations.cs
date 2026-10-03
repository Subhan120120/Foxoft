using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20350102000000_AddDcCurrAccRelationTypesAndTrCurrAccRelations")]
    public partial class AddDcCurrAccRelationTypesAndTrCurrAccRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Create DcCurrAccRelationTypes table
IF OBJECT_ID(N'dbo.DcCurrAccRelationTypes', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DcCurrAccRelationTypes](
        [RelationTypeId] [int] IDENTITY(1,1) NOT NULL,
        [RelationTypeName] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_DcCurrAccRelationTypes] PRIMARY KEY CLUSTERED ([RelationTypeId] ASC)
    );

    SET IDENTITY_INSERT [dbo].[DcCurrAccRelationTypes] ON;
    INSERT INTO [dbo].[DcCurrAccRelationTypes] ([RelationTypeId], [RelationTypeName]) VALUES
    (1, N'Qardaşı'),
    (2, N'Valideyni'),
    (3, N'Övladı'),
    (4, N'Həyat yoldaşı'),
    (5, N'Filialı'),
    (6, N'Ana şirkəti'),
    (7, N'Zamin'),
    (8, N'Nümayəndə'),
    (9, N'Digər');
    SET IDENTITY_INSERT [dbo].[DcCurrAccRelationTypes] OFF;
END

-- 2. Create TrCurrAccRelations table
IF OBJECT_ID(N'dbo.TrCurrAccRelations', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TrCurrAccRelations](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [CurrAccCode] [nvarchar](30) NOT NULL,
        [RelatedCurrAccCode] [nvarchar](30) NOT NULL,
        [RelationTypeId] [int] NULL,
        [Note] [nvarchar](200) NULL,
        [CreatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrCurrAccRelations_CreatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrCurrAccRelations_CreatedDate] DEFAULT (getdate()),
        [LastUpdatedUserName] [nvarchar](20) NULL CONSTRAINT [DF_TrCurrAccRelations_LastUpdatedUserName] DEFAULT (substring(suser_name(),patindex('%\%',suser_name())+(1),(20))),
        [LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_TrCurrAccRelations_LastUpdatedDate] DEFAULT (getdate()),
        CONSTRAINT [PK_TrCurrAccRelations] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_TrCurrAccRelations_DcCurrAccs_CurrAccCode] FOREIGN KEY([CurrAccCode]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]),
        CONSTRAINT [FK_TrCurrAccRelations_DcCurrAccs_RelatedCurrAccCode] FOREIGN KEY([RelatedCurrAccCode]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]),
        CONSTRAINT [FK_TrCurrAccRelations_DcCurrAccRelationTypes_RelationTypeId] FOREIGN KEY([RelationTypeId]) REFERENCES [dbo].[DcCurrAccRelationTypes] ([RelationTypeId]) ON DELETE SET NULL
    );

    CREATE NONCLUSTERED INDEX [IX_TrCurrAccRelations_CurrAccCode] ON [dbo].[TrCurrAccRelations] ([CurrAccCode] ASC);
    CREATE NONCLUSTERED INDEX [IX_TrCurrAccRelations_RelatedCurrAccCode] ON [dbo].[TrCurrAccRelations] ([RelatedCurrAccCode] ASC);
    CREATE NONCLUSTERED INDEX [IX_TrCurrAccRelations_RelationTypeId] ON [dbo].[TrCurrAccRelations] ([RelationTypeId] ASC);
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.TrCurrAccRelations', N'U') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[TrCurrAccRelations];
END

IF OBJECT_ID(N'dbo.DcCurrAccRelationTypes', N'U') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[DcCurrAccRelationTypes];
END
");
        }
    }
}
