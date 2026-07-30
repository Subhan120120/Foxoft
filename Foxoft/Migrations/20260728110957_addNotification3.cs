using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class addNotification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "DcClaims",
            columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
            values: new object[,]
            {
                            { "NotificationRules", 15, "Bildiriş Qaydaları", (byte)1 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
