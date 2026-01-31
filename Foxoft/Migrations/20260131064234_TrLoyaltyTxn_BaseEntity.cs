using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrLoyaltyTxn_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TrLoyaltyTxns",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "TrLoyaltyTxns",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrLoyaltyTxns",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrLoyaltyTxns",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TrLoyaltyTxns");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "TrLoyaltyTxns");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "TrLoyaltyTxns");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserName",
                table: "TrLoyaltyTxns");
        }
    }
}
