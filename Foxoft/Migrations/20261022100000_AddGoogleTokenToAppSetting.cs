using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261022100000_AddGoogleTokenToAppSetting")]
    public partial class AddGoogleTokenToAppSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'GoogleToken')
BEGIN
    ALTER TABLE [dbo].[AppSettings] ADD [GoogleToken] NVARCHAR(MAX) NULL;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[AppSettings]') AND name = 'GoogleToken')
BEGIN
    ALTER TABLE [dbo].[AppSettings] DROP COLUMN [GoogleToken];
END
");
        }
    }
}
