using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class isCashOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrCampaignPaymentMethods");

            migrationBuilder.AddColumn<bool>(
                name: "IsCashOnly",
                table: "DcCampaigns",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCashOnly",
                table: "DcCampaigns");

            migrationBuilder.CreateTable(
                name: "TrCampaignPaymentMethods",
                columns: table => new
                {
                    CampaignPaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignPaymentMethods", x => x.CampaignPaymentMethodId);
                    table.ForeignKey(
                        name: "FK_TrCampaignPaymentMethods_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignPaymentMethods_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignPaymentMethods_CampaignId_PaymentMethodId",
                table: "TrCampaignPaymentMethods",
                columns: new[] { "CampaignId", "PaymentMethodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignPaymentMethods_PaymentMethodId",
                table: "TrCampaignPaymentMethods",
                column: "PaymentMethodId");
        }
    }
}
