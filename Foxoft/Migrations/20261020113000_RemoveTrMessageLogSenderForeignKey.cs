using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20261020113000_RemoveTrMessageLogSenderForeignKey")]
    public partial class RemoveTrMessageLogSenderForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_TrMessageLogs_DcCurrAccs_Sender')
BEGIN
    ALTER TABLE [dbo].[TrMessageLogs] DROP CONSTRAINT [FK_TrMessageLogs_DcCurrAccs_Sender];
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_TrMessageLogs_DcCurrAccs_Sender')
BEGIN
    ALTER TABLE [dbo].[TrMessageLogs] ADD CONSTRAINT [FK_TrMessageLogs_DcCurrAccs_Sender] FOREIGN KEY([Sender]) REFERENCES [dbo].[DcCurrAccs] ([CurrAccCode]);
END
");
        }
    }
}
