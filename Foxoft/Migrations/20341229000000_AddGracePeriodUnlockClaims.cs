using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20341229000000_AddGracePeriodUnlockClaims")]
    public partial class AddGracePeriodUnlockClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM [dbo].[DcClaims] WHERE [ClaimCode] = N'UnlockGracePeriodInvoice')
    INSERT INTO [dbo].[DcClaims] ([ClaimCode], [CategoryId], [ClaimDesc], [ClaimTypeId])
    VALUES (N'UnlockGracePeriodInvoice', 2, N'Müddəti Bitmiş Qaiməni Dəyiş', 1);

IF NOT EXISTS (SELECT 1 FROM [dbo].[DcClaims] WHERE [ClaimCode] = N'UnlockGracePeriodPayment')
    INSERT INTO [dbo].[DcClaims] ([ClaimCode], [CategoryId], [ClaimDesc], [ClaimTypeId])
    VALUES (N'UnlockGracePeriodPayment', 21, N'Müddəti Bitmiş Ödənişi Dəyiş', 1);

IF NOT EXISTS (SELECT 1 FROM [dbo].[TrRoleClaims] WHERE [RoleCode] = N'Admin' AND [ClaimCode] = N'UnlockGracePeriodInvoice')
    INSERT INTO [dbo].[TrRoleClaims] ([RoleCode], [ClaimCode], [CreatedDate], [LastUpdatedDate])
    VALUES (N'Admin', N'UnlockGracePeriodInvoice', GETDATE(), GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[TrRoleClaims] WHERE [RoleCode] = N'Admin' AND [ClaimCode] = N'UnlockGracePeriodPayment')
    INSERT INTO [dbo].[TrRoleClaims] ([RoleCode], [ClaimCode], [CreatedDate], [LastUpdatedDate])
    VALUES (N'Admin', N'UnlockGracePeriodPayment', GETDATE(), GETDATE());
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM [dbo].[TrRoleClaims] WHERE [ClaimCode] IN (N'UnlockGracePeriodInvoice', N'UnlockGracePeriodPayment');
DELETE FROM [dbo].[DcClaims] WHERE [ClaimCode] IN (N'UnlockGracePeriodInvoice', N'UnlockGracePeriodPayment');
");
        }
    }
}
