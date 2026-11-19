using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261120000000_AddNumberFormatToAppSetting")]
    public partial class AddNumberFormatToAppSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberDecimalSeparator')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [NumberDecimalSeparator] NVARCHAR(10) NULL;
END

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberGroupSeparator')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [NumberGroupSeparator] NVARCHAR(10) NULL;
END

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberDecimalDigits')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [NumberDecimalDigits] INT NULL;
END

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'QuantityDecimalDigits')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [QuantityDecimalDigits] INT NULL;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberDecimalSeparator')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [NumberDecimalSeparator];
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberGroupSeparator')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [NumberGroupSeparator];
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'NumberDecimalDigits')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [NumberDecimalDigits];
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'QuantityDecimalDigits')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [QuantityDecimalDigits];
END
");
        }
    }
}
