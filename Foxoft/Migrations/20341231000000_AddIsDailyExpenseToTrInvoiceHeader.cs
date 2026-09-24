using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20341231000000_AddIsDailyExpenseToTrInvoiceHeader")]
    public partial class AddIsDailyExpenseToTrInvoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Add IsDailyExpense to TrInvoiceHeaders
IF COL_LENGTH(N'dbo.TrInvoiceHeaders', N'IsDailyExpense') IS NULL
BEGIN
    ALTER TABLE [dbo].[TrInvoiceHeaders] 
    ADD [IsDailyExpense] bit NOT NULL CONSTRAINT [DF_TrInvoiceHeaders_IsDailyExpense] DEFAULT (0);
END

-- 2. Add IsDailyExpense to TrInvoiceHeadersDeleted if table exists
IF OBJECT_ID(N'dbo.TrInvoiceHeadersDeleted', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TrInvoiceHeadersDeleted', N'IsDailyExpense') IS NULL
BEGIN
    ALTER TABLE [dbo].[TrInvoiceHeadersDeleted] 
    ADD [IsDailyExpense] bit NOT NULL CONSTRAINT [DF_TrInvoiceHeadersDeleted_IsDailyExpense] DEFAULT (0);
END

-- 3. Seed Claim for DailyExpense
IF NOT EXISTS (SELECT 1 FROM [dbo].[DcClaims] WHERE [ClaimCode] = N'DailyExpense')
BEGIN
    INSERT INTO [dbo].[DcClaims] ([ClaimCode], [CategoryId], [ClaimDesc], [ClaimTypeId])
    VALUES (N'DailyExpense', 9, N'Gündəlik Xərc', 1);
END

-- 4. Seed RoleClaim for Admin
IF NOT EXISTS (SELECT 1 FROM [dbo].[TrRoleClaims] WHERE [RoleCode] = N'Admin' AND [ClaimCode] = N'DailyExpense')
BEGIN
    INSERT INTO [dbo].[TrRoleClaims] ([RoleCode], [ClaimCode], [CreatedDate], [LastUpdatedDate])
    VALUES (N'Admin', N'DailyExpense', GETDATE(), GETDATE());
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM [dbo].[TrRoleClaims] WHERE [ClaimCode] = N'DailyExpense';
DELETE FROM [dbo].[DcClaims] WHERE [ClaimCode] = N'DailyExpense';

IF COL_LENGTH(N'dbo.TrInvoiceHeaders', N'IsDailyExpense') IS NOT NULL
BEGIN
    DECLARE @ConstraintName nvarchar(200);
    SELECT @ConstraintName = d.name
    FROM sys.default_constraints d
    JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
    WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrInvoiceHeaders') AND c.name = N'IsDailyExpense';

    IF @ConstraintName IS NOT NULL
        EXEC(N'ALTER TABLE [dbo].[TrInvoiceHeaders] DROP CONSTRAINT [' + @ConstraintName + N']');

    ALTER TABLE [dbo].[TrInvoiceHeaders] DROP COLUMN [IsDailyExpense];
END

IF OBJECT_ID(N'dbo.TrInvoiceHeadersDeleted', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TrInvoiceHeadersDeleted', N'IsDailyExpense') IS NULL
BEGIN
    DECLARE @DelConstraintName nvarchar(200);
    SELECT @DelConstraintName = d.name
    FROM sys.default_constraints d
    JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
    WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrInvoiceHeadersDeleted') AND c.name = N'IsDailyExpense';

    IF @DelConstraintName IS NOT NULL
        EXEC(N'ALTER TABLE [dbo].[TrInvoiceHeadersDeleted] DROP CONSTRAINT [' + @DelConstraintName + N']');

    ALTER TABLE [dbo].[TrInvoiceHeadersDeleted] DROP COLUMN [IsDailyExpense];
END
");
        }
    }
}
