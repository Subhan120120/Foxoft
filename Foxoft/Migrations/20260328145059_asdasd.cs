using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignTypeCode",
                table: "TrInvoiceCampaignLogs");

            migrationBuilder.DropColumn(
                name: "CampaignTypeCode",
                table: "DcCampaigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignTypeCode",
                table: "TrInvoiceCampaignLogs",
                type: "int",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignTypeCode",
                table: "DcCampaigns",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 1);
        }
    }
}
