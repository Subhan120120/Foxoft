using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261022000000_AddOpenAiSettingsToAppSetting")]
    public partial class AddOpenAiSettingsToAppSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'OpenAIApiKey')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [OpenAIApiKey] NVARCHAR(MAX) NULL;
END

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'OpenAIModel')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [OpenAIModel] NVARCHAR(50) NULL CONSTRAINT [DF_AppSettings_OpenAIModel] DEFAULT ('gpt-4o');
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'OpenAIApiKey')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [OpenAIApiKey];
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'OpenAIModel')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP CONSTRAINT IF EXISTS [DF_AppSettings_OpenAIModel];
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [OpenAIModel];
END
");
        }
    }
}
