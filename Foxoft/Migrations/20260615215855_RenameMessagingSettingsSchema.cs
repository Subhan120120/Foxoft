using Foxoft.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20260615215855_RenameMessagingSettingsSchema")]
    public partial class RenameMessagingSettingsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "DcNotificationSettings",
                newName: "DcMessagingSettings");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "DcMessagingSettings",
                newName: "MessagingType");

            migrationBuilder.Sql(
                @"
IF EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'NotificationSettings')
BEGIN
    IF NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'MessagingSettings')
    BEGIN
        INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
        SELECT N'MessagingSettings', N'Mesajlaşma Tənzimləmələri', ClaimTypeId, CategoryId
        FROM DcClaims
        WHERE ClaimCode = N'NotificationSettings';
    END

    UPDATE TrRoleClaims
    SET ClaimCode = N'MessagingSettings'
    WHERE ClaimCode = N'NotificationSettings';

    UPDATE TrClaimReports
    SET ClaimCode = N'MessagingSettings'
    WHERE ClaimCode = N'NotificationSettings';

    DELETE FROM DcClaims
    WHERE ClaimCode = N'NotificationSettings';
END

UPDATE DcClaims
SET ClaimDesc = N'Mesajlaşma Tənzimləmələri'
WHERE ClaimCode = N'MessagingSettings';
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
IF EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'MessagingSettings')
BEGIN
    IF NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'NotificationSettings')
    BEGIN
        INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
        SELECT N'NotificationSettings', N'Bildiriş Tənzimləmələri', ClaimTypeId, CategoryId
        FROM DcClaims
        WHERE ClaimCode = N'MessagingSettings';
    END

    UPDATE TrRoleClaims
    SET ClaimCode = N'NotificationSettings'
    WHERE ClaimCode = N'MessagingSettings';

    UPDATE TrClaimReports
    SET ClaimCode = N'NotificationSettings'
    WHERE ClaimCode = N'MessagingSettings';

    DELETE FROM DcClaims
    WHERE ClaimCode = N'MessagingSettings';
END

UPDATE DcClaims
SET ClaimDesc = N'Bildiriş Tənzimləmələri'
WHERE ClaimCode = N'NotificationSettings';
");

            migrationBuilder.RenameColumn(
                name: "MessagingType",
                table: "DcMessagingSettings",
                newName: "NotificationType");

            migrationBuilder.RenameTable(
                name: "DcMessagingSettings",
                newName: "DcNotificationSettings");
        }
    }
}
