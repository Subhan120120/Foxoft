using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class myMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseRequestReason",
                table: "DocumentLocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseRequestedAtUtc",
                table: "DocumentLocks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CloseRequestedByUserId",
                table: "DocumentLocks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseRequestReason",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "CloseRequestedAtUtc",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "CloseRequestedByUserId",
                table: "DocumentLocks");
        }
    }
}
